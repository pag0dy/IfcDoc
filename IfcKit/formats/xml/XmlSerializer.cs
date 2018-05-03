// Name:        XmlSerializer.cs
// Description: XML serializer
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2017 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace BuildingSmart.Serialization.Xml
{
    public class XmlSerializer : Serializer
    {
        public XmlSerializer(Type type) : base(type)
        {
            // get the XML namespace
        }

        public override object ReadObject(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            // pull it into a memory stream so we can make multiple passes (can't assume it's a file; could be web service)
            //...MemoryStream memstream = new MemoryStream();

            Dictionary<string, object> instances = null;
            return ReadObject(stream, out instances);
        }

        /// <summary>
        /// Reads an object graph and provides access to instance identifiers from file.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="instances"></param>
        /// <returns></returns>
        public object ReadObject(Stream stream, out Dictionary<string, object> instances)
        {
            instances = new Dictionary<string, object>();

            // first pass: read header to verify schema and model view definitions...

            // second pass: read instances
            ReadContent(stream, instances, false);

            // third pass: read fields
            ReadContent(stream, instances, true);

            // stash project in empty string key
            object root = null;
            if (instances.TryGetValue(String.Empty, out root))
            {
                return root;
            }

            return null; // could not find the single project object
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="idmap"></param>
        /// <param name="parsefields">True to populate fields; False to load instances only.</param>
        private void ReadContent(Stream stream, Dictionary<string, object> idmap, bool parsefields)
        {
            stream.Position = 0;

            using (XmlReader reader = XmlReader.Create(stream))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "ex:iso_10303_28")
                            {
                                //ReadIsoStep(reader, fixups, instances, inversemap);
                            }
                            else if (reader.LocalName.Equals("ifcXML"))
                            {
                                //ReadPopulation(reader, fixups, instances, inversemap);

                                while (reader.Read())
                                {
                                    switch (reader.NodeType)
                                    {
                                        case XmlNodeType.Element:
                                            ReadEntity(reader, idmap, reader.LocalName, parsefields);
                                            break;

                                        case XmlNodeType.EndElement:
                                            return;
                                    }
                                }

                            }
                            break;
                    }
                }
            }
        }

        private object ReadEntity(XmlReader reader, IDictionary<string, object> instances, string typename, bool parsefields)
        {
            object o = null;
            Type t = this.GetTypeByName(typename);
            if (t != null)
            {
                // map instance id if used later
                string sid = reader.GetAttribute("id");
                if (!String.IsNullOrEmpty(sid) && !instances.TryGetValue(sid, out o))
                {
                    o = FormatterServices.GetUninitializedObject(t);
                    instances.Add(sid, o);
                }
                else if (o == null)
                {
                    o = FormatterServices.GetUninitializedObject(t);
                    if (!String.IsNullOrEmpty(sid))
                    {
                        instances.Add(sid, o);
                    }
                }

                // stash project using blank index
                if (this.RootType.IsInstanceOfType(o) && !instances.ContainsKey(String.Empty))
                {
                    instances.Add(String.Empty, o);
                }

                if (parsefields)
                {
                    // ensure all lists/sets are instantiated
                    IList<PropertyInfo> fields = GetFieldsOrdered(t);
                    foreach (PropertyInfo f in fields)
                    {
                        Type type = f.PropertyType;

                        if (IsEntityCollection(type))
                        {
                            Type typeCollection = this.GetCollectionInstanceType(type);
                            object collection = Activator.CreateInstance(typeCollection);
                            f.SetValue(o, collection);
                        }
                    }

                    // read attribute properties
                    for (int i = 0; i < reader.AttributeCount; i++)
                    {
                        reader.MoveToAttribute(i);
                        if (!reader.LocalName.Equals("id"))
                        {
                            string match = reader.LocalName;
                            PropertyInfo f = GetFieldByName(t, match);
                            if (f != null)
                            {
                                ReadValue(reader, o, f, f.PropertyType);
                            }
                        }
                    }
                }

                reader.MoveToElement();

                // now read attributes or end of entity
                if (!reader.IsEmptyElement)
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                ReadAttribute(reader, o, instances);
                                break;

                            case XmlNodeType.Attribute:
                                break;

                            case XmlNodeType.EndElement:
                                return o;
                        }
                    }
                }
            }

            return o;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="o"></param>
        /// <param name="instances"></param>
        private void ReadAttribute(XmlReader reader, object o, IDictionary<string, object> instances)
        {
            if (o == null)
                throw new ArgumentNullException("o");

            // read attribute of object
            string a = reader.LocalName;

            string match = a;
            PropertyInfo f = GetFieldByName(o.GetType(), match);

            // inverse
            if (f == null)
            {
                //...f = GetFieldByNameInverse(o.GetType(), match);
                IList<PropertyInfo> fields = this.GetFieldsInverseAll(o.GetType());
                foreach (PropertyInfo field in fields)
                {
                    if (field != null && field.Name.Equals(match))
                    {
                        f = field;
                        break;
                    }
                }
            }

            if (f == null)
            {

                //Log("IFCXML: " + o.GetType().Name + "::" + reader.LocalName + " attribute name does not exist.");
                return;
            }

            // read attribute properties
            string reftype = null;

            if (!f.PropertyType.IsGenericType && !f.PropertyType.IsInterface)
            {
                reftype = f.PropertyType.Name;
            }
            string t = reader.GetAttribute("xsi:type");
            string r = reader.GetAttribute("href");
            if (t != null)
            {
                reftype = t;
                if (t.Contains(":"))
                {
                    string[] parts = t.Split(':');
                    if (parts.Length == 2)
                    {
                        reftype = parts[1];
                    }
                }
            }

            if (reftype != null)
            {
                this.ReadReference(reader, o, f, instances, reftype);
            }
            else
            {
                // now read object(s) of attribute -- multiple indicates list
                if (!reader.IsEmptyElement)
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                ReadReference(reader, o, f, instances, reader.LocalName);
                                break;

                            case XmlNodeType.Text:
                            case XmlNodeType.CDATA:
                                ReadValue(reader, o, f, null);
                                break;

                            case XmlNodeType.EndElement:
                                return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Reads a reference or qualified value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="o"></param>
        /// <param name="f"></param>
        private void ReadReference(XmlReader reader, object o, PropertyInfo f, IDictionary<string, object> instances, string typename)
        {
            if (typename.EndsWith("-wrapper"))
            {
                typename = typename.Substring(0, typename.Length - 8);
            }

            Type vt = GetTypeByName(typename);
            if (reader.Name == "ex:double-wrapper")
            {
                // drill in
                if (!reader.IsEmptyElement)
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Text:
                                ReadValue(reader, o, f, typeof(double));
                                break;

                            case XmlNodeType.EndElement:
                                return;
                        }
                    }
                }
            }
            else if (vt != null)
            {
                Type et = f.PropertyType;
                if (typeof(IEnumerable).IsAssignableFrom(f.PropertyType))
                {
                    et = f.PropertyType.GetGenericArguments()[0];
                }

                if (vt.IsValueType)
                {
                    // drill in
                    if (!reader.IsEmptyElement)
                    {
                        bool hasvalue = false;
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Text:
                                case XmlNodeType.CDATA:
                                    if (ReadValue(reader, o, f, vt))
                                        return;
                                    hasvalue = true;
                                    break;

                                case XmlNodeType.EndElement:
                                    if (!hasvalue)
                                    {
                                        ReadValue(reader, o, f, vt);
                                    }
                                    return;
                            }
                        }
                    }
                }
                else
                {
                    // reference
                    string r = reader.GetAttribute("href");
                    if (r != null)
                    {
                        object value = null;
                        if (instances.TryGetValue(r, out value))
                        {
                            LoadEntityValue(o, f, value);
                        }
                        else
                        {
                            //fixups.Add(new Fixup(o, f, r));
                        }
                    }
                    else
                    {
                        // embedded entity definition
                        object v = this.ReadEntity(reader, instances, typename, true);
                        LoadEntityValue(o, f, v);
                    }
                }
            }
        }

        private void LoadEntityValue(object o, PropertyInfo f, object v)
        {
            if (v == null)
                return;

            if (!f.PropertyType.IsValueType &&
                typeof(IEnumerable).IsAssignableFrom(f.PropertyType) &&
                f.PropertyType.GetGenericArguments()[0].IsInstanceOfType(v))
            {
                if (false)//f.FieldType.GetGenericTypeDefinition() == typeof(SInverse<>))
                {
#if false
                    // set the direct field, map to inverse
                    DataLookupAttribute[] attrs = (DataLookupAttribute[])f.GetCustomAttributes(typeof(DataLookupAttribute), false);
                    FieldInfo fieldDirect = SEntity.GetFieldByName(v.GetType(), attrs[0].Name);
                    if (fieldDirect.FieldType.IsGenericType && typeof(IStepCollection).IsAssignableFrom(fieldDirect.FieldType))
                    {
                        IStepCollection list = fieldDirect.GetValue(v) as IStepCollection;
                        list.Load(o);
                    }
                    else
                    {
                        // single object
                        fieldDirect.SetValue(v, o);
                    }

                    // also add to inverse
                    System.Collections.IList listInv = (System.Collections.IList)f.GetValue(o);
                    if (listInv == null)
                    {
                        listInv = (System.Collections.IList)System.Activator.CreateInstance(f.FieldType);
                        f.SetValue(o, listInv);
                    }
                    listInv.Add(v);
#endif
                }
                else
                {
                    // add to set/list of values
                    IEnumerable list = f.GetValue(o) as IEnumerable;
                    if (list != null)
                    {
                        try
                        {
                            Type typeCollection = this.GetCollectionInstanceType(f.PropertyType);
                            MethodInfo methodAdd = typeCollection.GetMethod("Add");
                            methodAdd.Invoke(list, new object[] { v }); // perf!!
                        }
                        catch (Exception e)
                        {
                            // could be type that changed and is no longer compatible with schema -- try to keep going
                        }
                        
                        UpdateInverse(o, f, v);
                    }
                }
            }
            else
            {
                if (!f.PropertyType.IsInstanceOfType(v))
                {
                    //this.Log("IFCXML: #" + o.OID + ": " + o.GetType().Name + "." + f.Name + ": '" + v.GetType().Name + "' type is incompatible.");
                    return;
                }

                // set value
                f.SetValue(o, v);
                this.UpdateInverse(o, f, v);
            }

        }

        /// <summary>
        /// Reads a value
        /// </summary>
        /// <param name="reader">The xml reader</param>
        /// <param name="o">The entity</param>
        /// <param name="f">The field</param>
        /// <param name="ft">Optional explicit type, or null to use field type.</param>
        private bool ReadValue(XmlReader reader, object o, PropertyInfo f, Type ft)
        {
            bool endelement = false;

            if (ft == null)
            {
                ft = f.PropertyType;
            }

            if (ft.IsGenericType && ft.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // special case for Nullable types
                ft = ft.GetGenericArguments()[0];
            }

            object v = null;
            if (ft.IsEnum)
            {
                FieldInfo enumfield = ft.GetField(reader.Value, BindingFlags.IgnoreCase | BindingFlags.Public | System.Reflection.BindingFlags.Static);
                if (enumfield != null)
                {
                    v = enumfield.GetValue(null);
                }
            }
            else if (ft.IsValueType)
            {
                // defined type -- get the underlying field
                PropertyInfo[] fields = ft.GetProperties(BindingFlags.Instance | BindingFlags.Public); //perf: cache this
                if (fields.Length == 1)
                {
                    PropertyInfo fieldValue = fields[0];
                    object primval = ParsePrimitive(reader, fieldValue.PropertyType);
                    v = Activator.CreateInstance(ft);
                    fieldValue.SetValue(v, primval);
                }
            }

            LoadEntityValue(o, f, v);

            return endelement;
        }

        private static object ParsePrimitive(XmlReader reader, Type type)
        {
            object value = null;
            if (typeof(Int64) == type)
            {
                // INTEGER
                value = ParseInteger(reader.Value);
            }
            else if(typeof(Int32) == type)
            {
                value = (Int32)ParseInteger(reader.Value);
            }
            else if (typeof(Double) == type)
            {
                // REAL
                value = ParseReal(reader.Value);
            }
            else if (typeof(Single) == type)
            {
                value = (Single)ParseReal(reader.Value);
            }
            else if (typeof(Boolean) == type)
            {
                // BOOLEAN
                value = ParseBoolean(reader.Value);
            }
            else if (typeof(String) == type)
            {
                // STRING
                value = reader.Value;
            }
            else if (typeof(byte[]) == type)
            {
                // BINARY
                int bytecount = reader.Value.Length / 2;
                byte[] bytes = new byte[bytecount];
                reader.ReadContentAsBinHex(bytes, 0, bytes.Length);
                value = bytes;

                // modulo not supported for now
                //endelement = true;
            }

            return value;

            /*
            else if (typeof(IStepValueLogical).IsAssignableFrom(ft))
            {
                v = (IStepValueLogical)Activator.CreateInstance(ft);
                switch (reader.Value)
                {
                    case "unknown":
                        ((IStepValueLogical)v).Value = SLogicalEnum.U;
                        break;

                    case "true":
                        ((IStepValueLogical)v).Value = SLogicalEnum.T;
                        break;

                    case "false":
                        ((IStepValueLogical)v).Value = SLogicalEnum.F;
                        break;

                    default:
                        break;
                }
            }*/

            /*
            else if (ft.IsGenericType && ft.GetGenericTypeDefinition() == typeof(SList<>) && typeof(IStepValueReal).IsAssignableFrom(ft.GetGenericArguments()[0]))
            {
                // IfcMaterialLayerWithOffsets.OffsetValues
                string[] elements = reader.Value.Split(' ');
                v = System.Activator.CreateInstance(ft);

                System.Collections.IList list = (System.Collections.IList)v;
                foreach (string elem in elements)
                {
                    object elemv = Activator.CreateInstance(ft.GetGenericArguments()[0]);

                    double dv;
                    if (Double.TryParse(elem, out dv))
                    {
                        ((IStepValueReal)elemv).Value = dv;
                    }

                    list.Add(elemv);
                }
            }
            else if (ft.IsGenericType && ft.GetGenericTypeDefinition() == typeof(SList<>) && typeof(IStepValueInteger).IsAssignableFrom(ft.GetGenericArguments()[0]))
            {
                // IfcReference.ListPositions
                string[] elements = reader.Value.Split(' ');
                v = System.Activator.CreateInstance(ft);

                System.Collections.IList list = (System.Collections.IList)v;
                foreach (string elem in elements)
                {
                    object elemv = Activator.CreateInstance(ft.GetGenericArguments()[0]);

                    long dv;
                    if (Int64.TryParse(elem, out dv))
                    {
                        ((IStepValueInteger)elemv).Value = dv;
                    }

                    list.Add(elemv);
                }
            }
            else
            {
                //Log("IFCXML: #" + o.OID + "" + o.GetType() + "." + f.Name + ": '" + ft.Name + "' type is unsupported.");
                this.ToString();
            }
            */
        }

        private static bool ParseBoolean(string strval)
        {
            bool iv;
            if (Boolean.TryParse(strval, out iv))
            {
                return iv;
            }

            return false;
        }

        private static Int64 ParseInteger(string strval)
        {
            long iv;
            if (Int64.TryParse(strval, out iv))
            {
                return iv;
            }

            return 0;
        }

        private static Double ParseReal(string strval)
        {
            double iv;
            if (Double.TryParse(strval, out iv))
            {
                return iv;
            }

            return 0.0;
        }

        /// <summary>
        /// Writes an object graph to a stream in Step Physical File (SPF) format according to ISO 10303-21.
        /// </summary>
        /// <param name="stream">The stream to write.</param>
        /// <param name="root">The root object to write (typically IfcProject)</param>
        public override void WriteObject(Stream stream, object root)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            if (root == null)
                throw new ArgumentNullException("root");

            // pass 1: (first time ever encountering for serialization) -- determine which entities require IDs -- use a null stream
            int nextID = 0;
            int indent = 0;
            StreamWriter writer = new StreamWriter(Stream.Null);
            HashSet<object> saved = new HashSet<object>();
            Dictionary<object, long> idmap = new Dictionary<object, long>();
            Queue<object> queue = new Queue<object>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                object ent = queue.Dequeue();
                if (!saved.Contains(ent))
                {
                    this.WriteEntity(writer, ref indent, ent, saved, idmap, queue, ref nextID);
                }
            }

            // pass 2: write to file -- clear save map; retain ID map
            saved.Clear();
            indent = 0;
            writer = new StreamWriter(stream);

            this.WriteHeader(writer);

#if true
            // writer header info
            header h = new header();
            h.time_stamp = DateTime.UtcNow;
            h.preprocessor_version = this.Preprocessor;
            h.originating_system = this.Application;
            this.WriteEntity(writer, ref indent, h, saved, idmap, queue, ref nextID);
#endif

            bool rootdelim = false;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                // insert delimeter after first root object
                if (rootdelim)
                {
                    this.WriteRootDelimeter(writer);
                }
                rootdelim = true;

                object ent = queue.Dequeue();
                if (!saved.Contains(ent))
                {
                    this.WriteEntity(writer, ref indent, ent, saved, idmap, queue, ref nextID);
                }
            }

            this.WriteFooter(writer);

            writer.Flush();
        }

        protected virtual void WriteHeader(StreamWriter writer)
        {
            string header = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";

            string schema = "<ifc:ifcXML xsi:schemaLocation=\"" + this.BaseURI + " " + this.Schema + ".xsd\" " +
                "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:ifc=\"" + this.BaseURI + "\" " +
                "xmlns=\"" + this.BaseURI + "\">";

            writer.WriteLine(header);
            writer.WriteLine(schema);
        }

        protected virtual void WriteFooter(StreamWriter writer)
        {
            string footer = "</ifc:ifcXML>";
            writer.WriteLine(footer);
            writer.Write("\r\n\r\n");
        }

        protected virtual void WriteRootDelimeter(StreamWriter writer) 
        { 
        }

        protected virtual void WriteCollectionStart(StreamWriter writer, ref int indent) 
        { 
        }

        protected virtual void WriteCollectionDelimiter(StreamWriter writer, int indent) 
        { 
        }

        protected virtual void WriteCollectionEnd(StreamWriter writer, ref int indent) 
        { 
        }

        protected virtual void WriteEntityStart(StreamWriter writer, ref int indent) 
        {
        }

        protected virtual void WriteEntityEnd(StreamWriter writer, ref int indent) 
        {
        }

        private void WriteEntity(StreamWriter writer, ref int indent, object o, HashSet<object> saved, Dictionary<object, long> idmap, Queue<object> queue, ref int nextID)
        {
            // sanity check
            if (indent > 100)
            {
                return;
            }

            if (o == null)
                return;

            Type t = o.GetType();

            this.WriteStartElementEntity(writer, ref indent, t.Name);
            bool close = this.WriteEntityAttributes(writer, ref indent, o, saved, idmap, queue, ref nextID);
            if (close)
            {
                this.WriteEndElementEntity(writer, ref indent, t.Name);
            }
            else
            {
                this.WriteCloseElementEntity(writer, ref indent);
            }
        }

        /// <summary>
        /// Terminates the opening tag, to allow for sub-elements to be written
        /// </summary>
        protected virtual void WriteOpenElement(StreamWriter writer)
        {
            // end opening tag
            writer.WriteLine(">");
        }

        /// <summary>
        /// Terminates the opening tag, with no subelements
        /// </summary>
        protected virtual void WriteCloseElementEntity(StreamWriter writer, ref int indent)
        {
            writer.WriteLine(" />");
            indent--;
        }

        protected virtual void WriteCloseElementAttribute(StreamWriter writer, ref int indent)
        {
            this.WriteCloseElementEntity(writer, ref indent);
        }

        protected virtual void WriteStartElementEntity(StreamWriter writer, ref int indent, string name)
        {
            this.WriteIndent(writer, indent);
            writer.Write("<" + name);
            indent++;
        }

        protected virtual void WriteStartElementAttribute(StreamWriter writer, ref int indent, string name)
        {
            this.WriteStartElementEntity(writer, ref indent, name);
        }

        protected virtual void WriteEndElementEntity(StreamWriter writer, ref int indent, string name)
        {
            indent--;

            this.WriteIndent(writer, indent);
            writer.Write("</");
            writer.Write(name);
            writer.WriteLine(">");
        }

        protected virtual void WriteEndElementAttribute(StreamWriter writer, ref int indent, string name)
        {
            WriteEndElementEntity(writer, ref indent, name);
        }

        protected virtual void WriteIdentifier(StreamWriter writer, int indent, long oid)
        {
            // record id, and continue to write out all attributes (works properly on second pass)
            writer.Write(" id=\"i");
            writer.Write(oid);
            writer.Write("\"");
        }

        protected virtual void WriteReference(StreamWriter writer, int indent, long oid)
        {
            writer.Write(" xsi:nil=\"true\" href=\"i");
            writer.Write(oid);
            writer.Write("\"");
        }

        protected virtual void WriteType(StreamWriter writer, int indent, string type)
        {
            writer.Write(" xsi:type=\"");
            writer.Write(type);
            writer.Write("\"");
        }

        protected virtual void WriteTypedValue(StreamWriter writer, ref int indent, string type, string encodedvalue)
        {
            this.WriteIndent(writer, indent);
            writer.WriteLine("<" + type + "-wrapper>" + encodedvalue + "</" + type + "-wrapper>");
        }

        protected virtual void WriteStartAttribute(StreamWriter writer, int indent, string name)
        {
            writer.Write(" ");
            writer.Write(name);
            writer.Write("=\"");
        }

        protected virtual void WriteEndAttribute(StreamWriter writer)
        {
            writer.Write("\"");
        }

        protected virtual void WriteAttributeDelimiter(StreamWriter writer) 
        { 
        }

        protected virtual void WriteAttributeTerminator(StreamWriter writer)
        { 
        }

        private static bool IsEntityCollection(Type type)
        {
            return (type != typeof(string) && type != typeof(byte[]) && typeof(IEnumerable).IsAssignableFrom(type));
        }

        private static bool IsValueCollection(Type t)
        {
            return t.IsGenericType && 
                typeof(IEnumerable).IsAssignableFrom(t.GetGenericTypeDefinition()) &&
                t.GetGenericArguments()[0].IsValueType;
        }

        /// <summary>
        /// Returns true if any elements written (requiring closing tag); or false if not
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private bool WriteEntityAttributes(StreamWriter writer, ref int indent, object o, HashSet<object> saved, Dictionary<object, long> idmap, Queue<object> queue, ref int nextID)
        {
            Type t = o.GetType();

            long oid = 0;
            if (saved.Contains(o))
            {
                // give it an ID if needed (first pass)
                if (!idmap.TryGetValue(o, out oid))
                {
                    nextID++;
                    idmap[o] = nextID;
                }

                // reference existing; return
                this.WriteReference(writer, indent, oid);
                return false;
            }

            // mark as saved
            saved.Add(o);

            if (idmap.TryGetValue(o, out oid))
            {
                this.WriteIdentifier(writer, indent, oid);
            }

            bool previousattribute = false;

            // write fields as attributes
            bool haselements = false;
            IList<PropertyInfo> fields = this.GetFieldsAll(t);
            foreach (PropertyInfo f in fields)
            {
                if (f != null) // derived fields are null
                {
                    DocXsdFormatEnum? xsdformat = this.GetXsdFormat(f);

                    if (f.IsDefined(typeof(DataMemberAttribute)) && (xsdformat == null || (xsdformat != DocXsdFormatEnum.Element && xsdformat != DocXsdFormatEnum.Attribute)))
                    {
                        // direct field

                        Type ft = f.PropertyType;

                        bool isvaluelist = IsValueCollection(ft);
                        bool isvaluelistlist = ft.IsGenericType && // e.g. IfcTriangulatedFaceSet.Normals
                            typeof(System.Collections.IEnumerable).IsAssignableFrom(ft.GetGenericTypeDefinition()) &&
                            IsValueCollection(ft.GetGenericArguments()[0]);

                        if (isvaluelistlist || isvaluelist || ft.IsValueType)
                        {
                            object v = f.GetValue(o);
                            if (v != null)
                            {
                                if (previousattribute)
                                {
                                    this.WriteAttributeDelimiter(writer);
                                }

                                previousattribute = true;
                                this.WriteStartAttribute(writer, indent, f.Name.TrimStart('_'));

                                if (isvaluelistlist)
                                {
                                    ft = ft.GetGenericArguments()[0].GetGenericArguments()[0];
                                    PropertyInfo fieldValue = ft.GetProperty("Value");
                                    if (fieldValue != null)
                                    {
                                        System.Collections.IList list = (System.Collections.IList)v;
                                        for (int i = 0; i < list.Count; i++)
                                        {
                                            System.Collections.IList listInner = (System.Collections.IList)list[i];
                                            for (int j = 0; j < listInner.Count; j++)
                                            {
                                                if (i > 0 || j > 0)
                                                {
                                                    writer.Write(" ");
                                                }

                                                object elem = listInner[j];
                                                if (elem != null) // should never be null, but be safe
                                                {
                                                    elem = fieldValue.GetValue(elem);
                                                    string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                                                    writer.Write(encodedvalue);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.ToString();
                                    }
                                }
                                else if (isvaluelist)
                                {
                                    ft = ft.GetGenericArguments()[0];
                                    PropertyInfo fieldValue = ft.GetProperty("Value");

                                    IEnumerable list = (IEnumerable)v;
                                    //for (int i = 0; i < list.Count; i++)
                                    int i = 0;
                                    foreach (object e in list)
                                    {
                                        if (i > 0)
                                        {
                                            writer.Write(" ");
                                        }

                                        //object elem = list[i];
                                        if (e != null) // should never be null, but be safe
                                        {
                                            object elem = e;
                                            if (fieldValue != null)
                                            {
                                                elem = fieldValue.GetValue(e);
                                            }

                                            if (elem is byte[])
                                            {
                                                // IfcPixelTexture.Pixels
                                                byte[] bytes = (byte[])elem;

                                                char[] s_hexchar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                                                StringBuilder sb = new StringBuilder(bytes.Length * 2);
                                                for (int z = 0; z < bytes.Length; z++)
                                                {
                                                    byte b = bytes[z];
                                                    sb.Append(s_hexchar[b / 0x10]);
                                                    sb.Append(s_hexchar[b % 0x10]);
                                                }
                                                v = sb.ToString();
                                                writer.Write(v);
                                            }
                                            else
                                            {
                                                string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                                                writer.Write(encodedvalue);
                                            }
                                        }

                                        i++;
                                    }

                                }
                                else
                                {
                                    if (ft.IsGenericType && ft.GetGenericTypeDefinition() == typeof(Nullable<>))
                                    {
                                        // special case for Nullable types
                                        ft = ft.GetGenericArguments()[0];
                                    }

                                    Type typewrap = null;
                                    while (ft.IsValueType && !ft.IsPrimitive)
                                    {
                                        PropertyInfo fieldValue = ft.GetProperty("Value");
                                        if (fieldValue != null)
                                        {
                                            v = fieldValue.GetValue(v);
                                            if (typewrap == null)
                                            {
                                                typewrap = ft;
                                            }
                                            ft = fieldValue.PropertyType;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    if (ft.IsEnum || ft == typeof(bool))
                                    {
                                        v = v.ToString().ToLowerInvariant();
                                    }

                                    if (v is System.Collections.IList)
                                    {
                                        // IfcCompoundPlaneAngleMeasure
                                        System.Collections.IList list = (System.Collections.IList)v;
                                        for (int i = 0; i < list.Count; i++)
                                        {
                                            if (i > 0)
                                            {
                                                writer.Write(" ");
                                            }

                                            object elem = list[i];
                                            if (elem != null) // should never be null, but be safe
                                            {
                                                string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                                                writer.Write(encodedvalue);
                                            }
                                        }
                                    }
                                    else if (v != null)
                                    {
                                        string encodedvalue = System.Security.SecurityElement.Escape(v.ToString());
                                        writer.Write(encodedvalue);
                                    }
                                }

                                this.WriteEndAttribute(writer);
                            }
                        }
                        else
                        {
                            haselements = true;
                        }
                    }
                    else
                    {
                        // inverse
                        haselements = true;
                    }
                }
            }

            if (haselements)
            {
                bool open = false;

                // write direct object references and lists
                foreach (PropertyInfo f in fields)
                {
                    if (f != null) // derived attributes are null
                    {
                        DocXsdFormatEnum? format = GetXsdFormat(f);
                        if (f.IsDefined(typeof(DataMemberAttribute)) && (format == null || (format != DocXsdFormatEnum.Element && format != DocXsdFormatEnum.Attribute)))
                        {
                            Type ft = f.PropertyType;
                            bool isvaluelist = IsValueCollection(ft);
                            bool isvaluelistlist = ft.IsGenericType && // e.g. IfcTriangulatedFaceSet.Normals
                                typeof(IEnumerable).IsAssignableFrom(ft.GetGenericTypeDefinition()) &&
                                IsValueCollection(ft.GetGenericArguments()[0]);

                            // hide fields where inverse attribute used instead
                            if (!f.PropertyType.IsValueType && !isvaluelist && !isvaluelistlist &&
                                (format == null || (format != DocXsdFormatEnum.Hidden)))
                            {
                                object value = f.GetValue(o);
                                if (value != null)
                                {
                                    if (!open)
                                    {
                                        WriteOpenElement(writer);
                                        open = true;
                                    }

                                    if (previousattribute)
                                    {
                                        this.WriteAttributeDelimiter(writer);
                                    }
                                    previousattribute = true;

                                    WriteAttribute(writer, ref indent, o, f, saved, idmap, queue, ref nextID);
                                }
                            }
                        }
                        else if (format != null && (format == DocXsdFormatEnum.Element || format == DocXsdFormatEnum.Attribute))
                        {
                            object value = f.GetValue(o);
                            if (value != null)
                            {
                                // for collection is must be non-zero (e.g. IfcProject.IsNestedBy)
                                bool showit = true; //...check: always include tag if Attribute (even if zero); hide if Element 
                                if (value is IEnumerable) // what about IfcProject.RepresentationContexts if empty? include???
                                {
                                    showit = false;
                                    IEnumerable enumerate = (IEnumerable)value;
                                    foreach (object check in enumerate)
                                    {
                                        showit = true; // has at least one element
                                        break;
                                    }
                                }

                                if (showit)
                                {
                                    if (!open)
                                    {
                                        WriteOpenElement(writer);
                                        open = true;
                                    }

                                    if (previousattribute)
                                    {
                                        this.WriteAttributeDelimiter(writer);
                                    }
                                    previousattribute = true;

                                    WriteAttribute(writer, ref indent, o, f, saved, idmap, queue, ref nextID);
                                }
                            }
                        }
                        else
                        {
                            object value = f.GetValue(o);

                            // inverse
                            // record it for downstream serialization
                            if (value is IEnumerable)
                            {
                                IEnumerable invlist = (IEnumerable)value;
                                foreach (object invobj in invlist)
                                {
                                    if (!saved.Contains(invobj))
                                    {
                                        queue.Enqueue(invobj);
                                    }
                                }
                            }
                        }
                    }
                }

                this.WriteAttributeTerminator(writer);
                return open;
            }
            else
            {
                this.WriteAttributeTerminator(writer);
                return false;
            }
        }

        private void WriteAttribute(StreamWriter writer, ref int indent, object o, PropertyInfo f, HashSet<object> saved, Dictionary<object, long> idmap, Queue<object> queue, ref int nextID)
        {
            object v = f.GetValue(o);
            if (v == null)
                return;

            this.WriteStartElementAttribute(writer, ref indent, f.Name.TrimStart('_'));

            Type ft = f.PropertyType;

            DocXsdFormatEnum? format = GetXsdFormat(f);
            if (format == null || format != DocXsdFormatEnum.Attribute || f.Name.Equals("InnerCoordIndices")) //hackhack -- need to resolve...
            {
                this.WriteOpenElement(writer);
            }

            if (IsEntityCollection(ft))
            {
                System.Collections.IEnumerable list = (System.Collections.IEnumerable)v;

                // for nested lists, flatten; e.g. IfcBSplineSurfaceWithKnots.ControlPointList
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(ft.GetGenericArguments()[0]))
                {
                    // special case
                    if (f.Name.Equals("InnerCoordIndices")) //hack
                    {
                        foreach (System.Collections.IEnumerable innerlist in list)
                        {
                            string entname = "Seq-IfcPositiveInteger-wrapper"; // hack
                            this.WriteStartElementEntity(writer, ref indent, entname);
                            this.WriteOpenElement(writer);
                            foreach (object e in innerlist)
                            {
                                object ev = e.GetType().GetField("Value").GetValue(e);

                                writer.Write(ev.ToString());
                                writer.Write(" ");
                            }
                            writer.WriteLine();
                            this.WriteEndElementEntity(writer, ref indent, entname);
                        }
                        WriteEndElementAttribute(writer, ref indent, f.Name.TrimStart('_'));
                        return;
                    }

                    System.Collections.ArrayList flatlist = new System.Collections.ArrayList();
                    foreach (System.Collections.ICollection innerlist in list)
                    {
                        foreach (object e in innerlist)
                        {
                            flatlist.Add(e);
                        }
                    }

                    list = flatlist;
                }

                foreach (object e in list)
                {
                    // if collection is non-zero and contains entity instances
                    if (!e.GetType().IsValueType && !(e is string) && !(e is System.Collections.IEnumerable))
                    {
                        this.WriteCollectionStart(writer, ref indent);
                    }
                    break;
                }

                bool needdelim = false;
                foreach (object e in list)
                {
                    if (e != null) // could be null if buggy file -- not matching schema
                    {
                        if (e is System.Collections.IList)
                        {
                            System.Collections.IList listInner = (System.Collections.IList)e;
                            for (int j = 0; j < listInner.Count; j++)
                            {
                                object oi = listInner[j];

                                Type et = oi.GetType();
                                while (et.IsValueType && !et.IsPrimitive)
                                {
                                    PropertyInfo fieldValue = et.GetProperty("Value");
                                    if (fieldValue != null)
                                    {
                                        oi = fieldValue.GetValue(oi);
                                        et = fieldValue.PropertyType;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                // write each value in sequence with spaces delimiting
                                string sval = oi.ToString();
                                writer.Write(sval);
                                writer.Write(" ");
                            }
                        }
                        else if (!e.GetType().IsValueType && !(e is string)) // presumes an entity
                        {
                            if (needdelim)
                            {
                                this.WriteCollectionDelimiter(writer, indent);
                            }

                            if (format != null && format == DocXsdFormatEnum.Attribute)
                            {
                                // only one item, e.g. StyledByItem\IfcStyledItem
                                this.WriteEntityStart(writer, ref indent);
                                bool closeelem = this.WriteEntityAttributes(writer, ref indent, e, saved, idmap, queue, ref nextID);
                                if (!closeelem)
                                {
                                    this.WriteCloseElementAttribute(writer, ref indent);
                                    return;
                                }
                                this.WriteEntityEnd(writer, ref indent);
                            }
                            else
                            {
                                this.WriteEntity(writer, ref indent, e, saved, idmap, queue, ref nextID);
                            }

                            needdelim = true;
                        }
                        else
                        {
                            // if flat-list (e.g. structural load Locations) or list of strings (e.g. IfcPostalAddress.AddressLines), must wrap
                            this.WriteValueWrapper(writer, ref indent, e);
                        }
                    }
                }

                foreach (object e in list)
                {
                    if (e != null && !e.GetType().IsValueType && !(e is string))
                    {
                        this.WriteCollectionEnd(writer, ref indent);
                    }
                    break;
                }
            }
            else if (f.PropertyType.IsInterface && v is ValueType)
            {
                this.WriteValueWrapper(writer, ref indent, v);
            }
            else if (f.PropertyType.IsValueType) // must be IfcBinary
            {
                PropertyInfo fieldValue = f.PropertyType.GetProperty("Value");
                if (fieldValue != null)
                {
                    v = fieldValue.GetValue(v);
                    if (v is byte[])
                    {
                        this.WriteOpenElement(writer);

                        // binary data type - we don't support anything other than 8-bit aligned, though IFC doesn't either so no point in supporting extraBits
                        byte[] bytes = (byte[])v;

                        StringBuilder sb = new StringBuilder(bytes.Length * 2);
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            byte b = bytes[i];
                            sb.Append(HexChars[b / 0x10]);
                            sb.Append(HexChars[b % 0x10]);
                        }
                        v = sb.ToString();
                        writer.WriteLine(v);
                    }
                }
            }
            else
            {
                if (format != null && format == DocXsdFormatEnum.Attribute)
                {
                    this.WriteEntityStart(writer, ref indent);

                    Type vt = v.GetType();
                    if (ft != vt)
                    {
                        this.WriteType(writer, indent, vt.Name);
                    }

                    bool closeelem = this.WriteEntityAttributes(writer, ref indent, v, saved, idmap, queue, ref nextID);

                    if (!closeelem)
                    {
                        this.WriteCloseElementEntity(writer, ref indent);
                        return;
                    }

                    this.WriteEntityEnd(writer, ref indent);
                }
                else
                {
                    // if rooted, then check if we need to use reference; otherwise embed
                    this.WriteEntity(writer, ref indent, v, saved, idmap, queue, ref nextID);
                }
            }

            WriteEndElementAttribute(writer, ref indent, f.Name.TrimStart('_'));
        }

        private void WriteValueWrapper(StreamWriter writer, ref int indent, object v)
        {
            Type vt = v.GetType();
            PropertyInfo fieldValue = vt.GetProperty("Value");
            if (fieldValue != null)
            {
                v = fieldValue.GetValue(v);
                if (v != null)
                {
                    Type wt = v.GetType();
                    if (wt.IsEnum || wt == typeof(bool))
                    {
                        v = v.ToString().ToLowerInvariant();
                    }
                }
            }

            string encodedvalue = String.Empty;
            if (v is System.Collections.IList)
            {
                // IfcIndexedPolyCurve.Segments
                System.Collections.IList list = (System.Collections.IList)v;
                StringBuilder sb = new StringBuilder();
                foreach (object o in list)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" ");
                    }

                    PropertyInfo fieldValueInner = o.GetType().GetProperty("Value");
                    if (fieldValueInner != null)
                    {
                        object vInner = fieldValueInner.GetValue(o);
                        sb.Append(vInner.ToString());
                    }
                    else
                    {
                        sb.Append(o.ToString());
                    }
                }

                encodedvalue = sb.ToString();
            }
            else if (v != null)
            {
                encodedvalue = System.Security.SecurityElement.Escape(v.ToString());
            }

            this.WriteTypedValue(writer, ref indent, vt.Name, encodedvalue);
        }

        private DocXsdFormatEnum? GetXsdFormat(PropertyInfo field)
        {
            // direct fields marked ignore are ignored
            if (field.IsDefined(typeof(XmlIgnoreAttribute)))
                return DocXsdFormatEnum.Hidden;

            if (field.IsDefined(typeof(XmlAttributeAttribute)))
                return null;

            XmlElementAttribute attrElement = field.GetCustomAttribute<XmlElementAttribute>();
            if (attrElement != null)
            {
                if (!String.IsNullOrEmpty(attrElement.ElementName))
                {
                    return DocXsdFormatEnum.Element; // tag according to attribute AND element name
                }
                else
                {
                    return DocXsdFormatEnum.Attribute; // tag according to attribute name
                }
            }

            // inverse fields not marked with XmlElement are ignored
            if (attrElement == null && field.IsDefined(typeof(InversePropertyAttribute)))
                return DocXsdFormatEnum.Hidden;

            return null; //?
        }

        private enum DocXsdFormatEnum
        {
            //Default = 0,//IfcDoc.Schema.CNF.exp_attribute.unspecified,
            Hidden = 1,//IfcDoc.Schema.CNF.exp_attribute.no_tag,    // for direct attribute, don't include as inverse is defined instead
            Attribute = 2,//IfcDoc.Schema.CNF.exp_attribute.attribute_tag, // represent as attribute
            Element = 3,//IfcDoc.Schema.CNF.exp_attribute.double_tag,   // represent as element
            //Content = 4,//IfcDoc.Schema.CNF.exp_attribute.attribute_content,   // represent as content
            //Type = 5,//IfcDoc.Schema.CNF.exp_attribute.type_tag,
            //Simple = 6,//IfcDoc.Schema.CNF.exp_attribute.no_tag_simple
        }
    }

}




/*

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Constructivity.Data;
using Constructivity.Schema;
using Constructivity.Schema.IFC;


namespace Constructivity.Format.ISO
{
    public class FormatIFX :
        IDisposable,
        IExtensionFormat,
        IExtensionStream
    {
        Stream m_stream;
        string m_url;
        IBinder m_binder;
        IBrokerExecute m_broker;
        object m_target;
        
        long m_progressTotal;
        long m_progressCurrent;

        Dictionary<string, Type> m_typemap;
        IList<SHeader> m_headers;

        const string NamespaceXsi = "http://www.w3.org/2001/XMLSchema-instance";
        const string NamespaceIfc = "http://www.buildingsmart-tech.org/ifcXML/IFC4/Add1";

        const string PrefixXsi = "xsi";

        public FormatIFX()
        {
            m_typemap = new Dictionary<string, Type>();
            m_headers = new List<SHeader>();

            System.Reflection.Assembly asm = typeof(IfcRoot).Assembly;
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                if (t.IsPublic && !t.IsAbstract && 
                    (typeof(SEntity).IsAssignableFrom(t) || typeof(IStepValue).IsAssignableFrom(t)))
                {
                    //TODO: check schema version...
                    m_typemap.Add(t.Name, t);
                }
            }
        }


        public IExtensionError[] Load()
        {            
            List<Fixup> fixups = new List<Fixup>(8192);
            Dictionary<string, SEntity> instances = new Dictionary<string,SEntity>();
            this.m_progressTotal = this.m_stream.Length;

            Type[] types = IfcRoot.GetSchemaTypes(SchemaPlatform.IFC4x1);
            Dictionary<string, Type> typemap = new Dictionary<string, Type>();
            Dictionary<FieldInfo, List<FieldInfo>> inversemap = new Dictionary<FieldInfo, List<FieldInfo>>();
            SEntity.BuildSchemaMaps(types, typemap, inversemap);


            // for now, use xml api directly
            using (XmlReader reader = XmlReader.Create(this.m_stream))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "ex:iso_10303_28")
                            {
                                ReadIsoStep(reader, fixups, instances, inversemap);
                            }
                            else if (reader.LocalName.Equals("ifcXML"))
                            {
                                ReadPopulation(reader, fixups, instances, inversemap);
                            }
                            break;
                    }
                }
            }

            // now, fixup references -- danger: LIST ORDER MAY NOT BE PRESERVED!!!! TBD
            foreach (Fixup fixup in fixups)
            {
                SEntity value = null;
                if (instances.TryGetValue(fixup.ValueID, out value))
                {
                    LoadEntityValue(fixup.Entity, fixup.Field, value, inversemap);
                }
                else
                {
                    Log("IFCXML: " + fixup.ValueID + ": " + fixup.Entity.GetType().Name + "." + fixup.Field.Name + ": referenced entity does not exist.");                
                }
            }

            return null;
        }

        private void ReadIsoStep(XmlReader reader, IList<Fixup> fixups, IDictionary<string, SEntity> instances, Dictionary<FieldInfo, List<FieldInfo>> inversemap)
        {
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "ex:uos")
                        {
                            string schema = reader.GetAttribute("configuration"); // e.g. 'i-ifc2x3'
                            if (schema != null && schema.StartsWith("i-"))
                            {
                                schema = schema.Substring(2).ToUpper();
                                switch (schema)
                                {
                                    case "IFC2X3":
                                    case "IFC2X4_RC1":
                                    case "IFC2X4_RC2":
                                    case "IFC2X4_RC3":
                                    case "IFC2X4":
                                    case "IFC4_FINAL":
                                        ReadPopulation(reader, fixups, instances, inversemap);
                                        break;
                                }
                            }
                        }
                        else if (reader.Name == "ex:iso_10303_28_header")
                        {
                            ReadHeader(reader);
                        }
                        else if (reader.LocalName.StartsWith("Ifc"))
                        {
                            ReadEntity(reader, fixups, instances, inversemap, reader.LocalName);
                            this.m_progressCurrent = this.m_stream.Position;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        return;
                }
            }
        }

        private void ReadHeader(XmlReader reader)
        {
            FILE_NAME header = new FILE_NAME(null, null, null);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        ReadAttribute(reader, header, null, null, null);
                        break;

                    case XmlNodeType.EndElement:
                        return;
                }
            }

            this.m_headers.Add(header);
        }

        private void ReadPopulation(XmlReader reader, IList<Fixup> fixups, IDictionary<string, SEntity> instances, Dictionary<FieldInfo, List<FieldInfo>> inversemap)
        {
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        ReadEntity(reader, fixups, instances, inversemap, reader.LocalName);
                        break;

                    case XmlNodeType.EndElement:
                        return;
                }

                this.m_progressCurrent = this.m_stream.Position;
            }
        }




    /// <summary>
    /// Holds deferred value reference
    /// </summary>
    internal struct Fixup
    {
        SRecord m_entity;
        FieldInfo m_field;
        string m_ref;

        public Fixup(SRecord entity, FieldInfo field, string id)
        {
            this.m_entity = entity;
            this.m_field = field;
            this.m_ref = id;
        }

        public SRecord Entity
        {
            get
            {
                return this.m_entity;
            }
        }

        public FieldInfo Field
        {
            get
            {
                return this.m_field;
            }
        }

        public string ValueID
        {
            get
            {
                return this.m_ref;
            }
        }
    }
}
*/
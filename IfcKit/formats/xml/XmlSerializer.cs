// Name:        XmlSerializer.cs
// Description: XML serializer
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2017 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BuildingSmart.Serialization.Xml
{
    public class XmlSerializer : Serializer
    {
        public XmlSerializer(Type type) : base(type)
        {
            // get the XML namespace
        }

        public string XsdURI
        {
            get
            {
                return "http://www.buildingsmart-tech.org/ifcXML/" + this.Schema + "/" + this.Release;
            }
        }

        public override object ReadObject(Stream stream)
        {
            throw new NotImplementedException();
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

            string schema = "<ifc:ifcXML xsi:schemaLocation=\"" + this.XsdURI + " " + this.Schema + ".xsd\" " +
                "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:ifc=\"" + this.XsdURI + "\" " +
                "xmlns=\"" + this.XsdURI + "\">";

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

        protected void WriteIndent(StreamWriter writer, int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                writer.Write(" ");
            }
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
            IList<FieldInfo> fields = this.GetFieldsAll(t);
            foreach (FieldInfo f in fields)
            {
                DocXsdFormatEnum? xsdformat = this.GetXsdFormat(f);

                if (f.IsDefined(typeof(DataMemberAttribute)) && (xsdformat == null || (xsdformat != DocXsdFormatEnum.Element && xsdformat != DocXsdFormatEnum.Attribute)))
                {
                    // direct field

                    Type ft = f.FieldType;

                    bool isvaluelist = (ft.IsGenericType && ft.GetGenericTypeDefinition() == typeof(List<>) && ft.GetGenericArguments()[0].IsValueType);
                    bool isvaluelistlist = (ft.IsGenericType && // e.g. IfcTriangulatedFaceSet.Normals
                        ft.GetGenericTypeDefinition() == typeof(List<>) &&
                        ft.GetGenericArguments()[0].IsGenericType &&
                        ft.GetGenericArguments()[0].GetGenericTypeDefinition() == typeof(List<>) &&
                        ft.GetGenericArguments()[0].GetGenericArguments()[0].IsValueType);

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
                                FieldInfo fieldValue = ft.GetField("Value");

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
                            else if (isvaluelist)
                            {
                                ft = ft.GetGenericArguments()[0];
                                FieldInfo fieldValue = ft.GetField("Value");

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
                                        elem = fieldValue.GetValue(elem);
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
                                    FieldInfo fieldValue = ft.GetField("Value");
                                    if (fieldValue != null)
                                    {
                                        v = fieldValue.GetValue(v);
                                        if (typewrap == null)
                                        {
                                            typewrap = ft;
                                        }
                                        ft = fieldValue.FieldType;
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

            if (haselements)
            {
                bool open = false;

                // write direct object references and lists
                foreach (FieldInfo f in fields)
                {
                    DocXsdFormatEnum? format = GetXsdFormat(f);
                    if (f.IsDefined(typeof(DataMemberAttribute)) && (format == null || (format != DocXsdFormatEnum.Element && format != DocXsdFormatEnum.Attribute)))
                    {
                        Type ft = f.FieldType;
                        bool isvaluelist = (ft.IsGenericType && ft.GetGenericTypeDefinition() == typeof(List<>) && ft.GetGenericArguments()[0].IsValueType);
                        bool isvaluelistlist = (ft.IsGenericType && // e.g. IfcTriangulatedFaceSet.Normals
                            ft.GetGenericTypeDefinition() == typeof(List<>) &&
                            ft.GetGenericArguments()[0].IsGenericType &&
                            ft.GetGenericArguments()[0].GetGenericTypeDefinition() == typeof(List<>) &&
                            ft.GetGenericArguments()[0].GetGenericArguments()[0].IsValueType);

                        // hide fields where inverse attribute used instead
                        if (!f.FieldType.IsValueType && !isvaluelist && !isvaluelistlist &&
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
                            if (value is System.Collections.IEnumerable) // what about IfcProject.RepresentationContexts if empty? include???
                            {
                                showit = false;
                                System.Collections.IEnumerable enumerate = (System.Collections.IEnumerable)value;
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
                        if (value is System.Collections.IEnumerable)
                        {
                            System.Collections.IEnumerable invlist = (System.Collections.IEnumerable)value;
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

                this.WriteAttributeTerminator(writer);
                return open;
            }
            else
            {
                this.WriteAttributeTerminator(writer);
                return false;
            }
        }

        private void WriteAttribute(StreamWriter writer, ref int indent, object o, FieldInfo f, HashSet<object> saved, Dictionary<object, long> idmap, Queue<object> queue, ref int nextID)
        {
            object v = f.GetValue(o);
            if (v == null)
                return;

            this.WriteStartElementAttribute(writer, ref indent, f.Name.TrimStart('_'));

            Type ft = f.FieldType;

            DocXsdFormatEnum? format = GetXsdFormat(f);
            if (format == null || format != DocXsdFormatEnum.Attribute || f.Name.Equals("InnerCoordIndices")) //hackhack -- need to resolve...
            {
                this.WriteOpenElement(writer);
            }

            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(ft))
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
                                    FieldInfo fieldValue = et.GetField("Value");
                                    if (fieldValue != null)
                                    {
                                        oi = fieldValue.GetValue(oi);
                                        et = fieldValue.FieldType;
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
            else if (f.FieldType.IsInterface && v is ValueType)
            {
                this.WriteValueWrapper(writer, ref indent, v);
            }
            else if (f.FieldType.IsValueType) // must be IfcBinary
            {
                FieldInfo fieldValue = f.FieldType.GetField("Value");
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
            FieldInfo fieldValue = vt.GetField("Value");
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

                    FieldInfo fieldValueInner = o.GetType().GetField("Value");
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

        private DocXsdFormatEnum? GetXsdFormat(FieldInfo field)
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

            return DocXsdFormatEnum.Attribute; //?
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

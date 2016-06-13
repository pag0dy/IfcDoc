// Name:        FormatTTL.cs
// Description: Reads/writes TTL File (RDF, compliant with ifcOWL).
// Author:      Pieter Pauwels
// Origination: Work performed for BuildingSmart by Pieter Pauwels
// Copyright:   (c) 2016 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;
using System.Reflection;

namespace IfcDoc
{
    public class FormatTTL_Stream: IDisposable,
        IFormatData
    {
        Stream m_stream;
        string m_owlURI;
        string m_baseURI;

        Dictionary<long, SEntity> m_instances;
        bool m_markup;
        int m_indent;
        StreamWriter m_writer;

        //dictionary with extra entities that need to be defined so that the RDF graphs is correct (e.g. Lists and labels and ...)
        Dictionary<string, URIObject> m_valueObjects;
        Dictionary<string, ListObject> m_listOfListObjects;
        Dictionary<string, ListObject> m_listObjects;
        Dictionary<string, URIObject> m_objectProperties;
        Dictionary<string, ObjectProperty> m_fullpropertynames;
        
        HashSet<SEntity> m_saved; // keeps track of entities already written, which can be referenced
        
        long m_nextID = 0;

        public FormatTTL_Stream(Stream stream, string owlURI)
        {
            this.m_stream = stream;
            this.m_owlURI = owlURI;
            string timeLog = DateTime.Now.ToString("yyyyMMdd_HHmmss"); //h:mm:ss tt
            this.m_baseURI = "http://linkedbuildingdata.net/ifc/resources" + timeLog + "/";
            this.LoadPropertyNamesFromCSV();
        }

        private class ListObject
        {
            public ListObject() { }
            public ListObject(string URI, string listtype, string ifcowlclass, List<string> values, string XSDType)
            {
                this.URI = URI;
                this.ifcowlclass = ifcowlclass;
                this.values = values;
                this.XSDType = XSDType;
                this.listtype = listtype;
            }
            public string URI;
            public string listtype;
            public string ifcowlclass;
            public List<string> values;
            public string XSDType;
        }

        private class URIObject
        {
            public URIObject(string URI, string ifcowlclass, string encodedvalue, string XSDtype)
            {
                this.URI = URI;
                this.ifcowlclass = ifcowlclass;
                this.encodedvalue = encodedvalue;
                this.XSDType = XSDtype;
            }
            public string URI;
            public string ifcowlclass;
            public string encodedvalue;
            public string XSDType;
        }

        private class ObjectProperty
        {
            public ObjectProperty(string domain, string originalName, string name, string setorlist)
            {
                this.domain = domain;
                this.originalName = originalName;
                this.name = char.ToLower(name[0]) + name.Substring(1);
                this.setorlist = setorlist;
            }
            public string domain;
            public string originalName;
            public string name;
            public string setorlist; //ENTITY, SET, LISTOFLIST, LIST, ARRAY
        }

        private void LoadPropertyNamesFromCSV()
        {
            m_fullpropertynames = new Dictionary<string, ObjectProperty>();
            try
            {
                //TODO: make this work for multiple schemas
                //TODO: get the schema from the internal code, instead of from an external CSV file
                string x = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "proplistIFC4_ADD1.csv");
                using (StreamReader readFile = new StreamReader(x))
                {
                    string line;
                    string[] row;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        //string s = char.ToLower(row[1][0]) + row[1].Substring(1);
                        m_fullpropertynames.Add(row[1] + "_" + row[0], new ObjectProperty(row[0], row[1], row[2], row[3]));
                    }
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("ERROR FormatTTL_Stream.cs: unable to read file: " + "proplistIFC4_ADD1.csv" + " - "+e.InnerException);
            }
        }

        /// <summary>
        /// The dictionary with all project instances
        /// </summary>
        public Dictionary<long, SEntity> Instances
        {
            set
            {
                this.m_instances = value;
            }
        }
        
        /// <summary>
        /// Whether to save as HTML with hyperlinks for object references (to anchors within file) and entity references (to topics within documentation).
        /// </summary>
        public bool Markup
        {
            get
            {
                return this.m_markup;
            }
            set
            {
                this.m_markup = value;
            }
        }
        
        //WRITING ENTITIES
        public void Save()
        {
            if (m_instances == null || m_instances.Count == 0)
                return;

            //get highest available ID and start counting from there
            m_nextID = m_instances.Keys.Aggregate((l, r) => l > r ? l : r);
            
            // pass 2: write to file -- clear save map; retain ID map
            //this.m_saved.Clear(); //NOT NECESSARY WHEN NOT DOING THE ABOVE FIRST RUN
            
            this.m_saved = new HashSet<SEntity>();
            this.m_writer = new StreamWriter(this.m_stream);
            this.m_valueObjects = new Dictionary<string, URIObject>();
            this.m_listObjects = new Dictionary<string, ListObject>();
            this.m_listOfListObjects = new Dictionary<string, ListObject>();
            this.m_objectProperties = new Dictionary<string, URIObject>();

            //header
            WriteHeader();

            //contents: entities and properties
            foreach (KeyValuePair<long, SEntity> entry in this.m_instances)
            {
                m_indent = 0;
                long num = entry.Key;
                SEntity ent = entry.Value;
                this.WriteEntity(ent, num);
            }

            //write additional entities
            Console.Out.WriteLine("\r\n+ start writing additional entities +");
            foreach (KeyValuePair<string, URIObject> entry in m_valueObjects)
            {
                URIObject obj = entry.Value;
                WriteExtraEntity(obj);
            }
            Console.Out.WriteLine("+ end writing additional entities +");

            Console.Out.WriteLine("\r\n+ start writing additional list objects +");
            foreach (KeyValuePair<string, ListObject> entry in m_listObjects)
            {
                ListObject obj = entry.Value;
                this.WriteExtraListObject(obj);
            }
            Console.Out.WriteLine("+ end writing additional list objects +");

            Console.Out.WriteLine("\r\n+ start writing additional list of list objects +");
            foreach (KeyValuePair<string, ListObject> entry in m_listOfListObjects)
            {
                ListObject obj = entry.Value;
                this.WriteExtraListOfListObject(obj);
            }
            Console.Out.WriteLine("+ end writing additional list of list objects +");

            //footer
            if (this.m_markup)
            {
                this.m_writer.Write("<br/>\r\n");
                this.m_writer.Write("</tt>\r\n");

                this.m_writer.Write("  </body>\r\n");
                this.m_writer.Write("</html>\r\n");
                this.m_writer.Write("\r\n");
            }
            else
            {
                // nothing...
                this.m_writer.Write("\r\n\r\n");
            }
        }
                        
        private void WriteEntity(SEntity o, long ID)
        {
            string newline = "\r\n";
            if (this.m_markup)
                newline = "<br/>";

            Type t = o.GetType();
            string hyperlink = "../../schema/" + t.Namespace.ToLower() + "/lexical/" + t.Name.ToLower() + "_" + ID + ".htm";
            this.WriteStartElement(t.Name+"_"+ID, hyperlink);
            
            this.m_writer.Write(newline);
            m_indent++;
            Console.Out.WriteLine("\r\n--- Writing entity : " + t.Name.ToString());
            Console.Out.WriteLine("-----------------------------------");
            this.WriteType("ifcowl:" + t.Name.ToString());            
            this.WriteEntityAttributes(o);
            Console.Out.WriteLine("--------------done---------------------");
        }
        
        /// <summary>
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private void WriteEntityAttributes(SEntity o)
        {
            Type t = o.GetType();

            if (t.Name.Equals("IfcPixelTexture"))
            {
                this.ToString();
            }            

            IList<FieldInfo> fields = SEntity.GetFieldsAll(t);
            foreach (FieldInfo f in fields)
            {
                if (f.IsDefined(typeof(DataMemberAttribute)))
                {
                    // write data type properties
                    Type ft = f.FieldType;
                    Console.Out.WriteLine("\r\n++ writing attribute: " + ft.Name);

                    bool isvaluelist = (ft.IsGenericType && ft.GetGenericTypeDefinition() == typeof(List<>) && ft.GetGenericArguments()[0].IsValueType);
                    bool isvaluelistlist = (ft.IsGenericType && // e.g. IfcTriangulatedFaceSet.Normals
                        ft.GetGenericTypeDefinition() == typeof(List<>) &&
                        ft.GetGenericArguments()[0].IsGenericType &&
                        ft.GetGenericArguments()[0].GetGenericTypeDefinition() == typeof(List<>) &&
                        ft.GetGenericArguments()[0].GetGenericArguments()[0].IsValueType);

                    if (isvaluelistlist || isvaluelist || ft.IsValueType)
                    {
                        //Console.Out.WriteLine("WriteDataValueAttribute()");
                        object v = f.GetValue(o);
                        if (v != null)
                        {
                            m_writer.Write(";" + "\r\n");
                            //m_writer.Write(" ");
                            WriteIndent();
                            ObjectProperty p = GetObjectProperty(f.Name + "_" + t.Name);
                            if (p == null)
                                Console.Out.WriteLine("Warning: objectproperty not found : " + f.Name + "_" + t.Name);
                            
                            m_writer.Write("ifcowl:" + p.name + " ");

                            if (isvaluelistlist)
                            {
                                System.Collections.IList list = (System.Collections.IList)v;
                                WriteListOfListWithValues(ft, list);
                            }
                            else if (isvaluelist)
                            {
                                System.Collections.IList list = (System.Collections.IList)v;
                                WriteListWithValues(ft, list);                                
                            }
                            else
                            {
                                WriteTypeValue(ft,v);
                            }
                        }
                        else
                        {
                            //Console.Out.WriteLine("Empty value: skipping");
                        }
                    }
                    else
                    {
                        //Console.Out.WriteLine("WriteObjectPropertyAttribute()");
                        //Writing object properties            
                        ObjectProperty p = GetObjectProperty(f.Name + "_" + o.GetType().Name);
                        if (p == null)
                            Console.Out.WriteLine("Warning: objectproperty not found : " + f.Name + "_" + o.GetType().Name);

                        //Writing output
                        object v = f.GetValue(o);
                        if (v != null)
                        {
                            if (v.GetType() == typeof(SEntity))
                            {
                                //WriteAttribute(o, f, owlClass);
                                //m_writer.Write(owlClass + "_" + ((SEntity)value).OID);
                                Console.Out.WriteLine("WARNING: ATTR object prop exception : " + v.ToString() + " - " + f.Name + " - " + ft.ToString());
                            }
                            else
                            {
                                if (typeof(System.Collections.ICollection).IsAssignableFrom(ft))
                                {
                                    System.Collections.IList list = (System.Collections.IList)v;
                                    WriteListKindOfObjectProperty(f, v, ft, p, list);
                                }                            
                                else if (v is SEntity)
                                {
                                    //found simple object property. give propertyname and URI num
                                    m_writer.Write(";" + "\r\n");
                                    WriteIndent();
                                    m_writer.Write("ifcowl:" + p.name + " ");

                                    Type vt = v.GetType();
                                    this.m_writer.Write("inst:" + vt.Name + "_" + ((SEntity)v).OID);
                                    //There is more in the WriteAttibute method (HTM notation)
                                }
                                else if (f.FieldType.IsInterface && v is ValueType)
                                {
                                    m_writer.Write(";" + "\r\n");
                                    WriteIndent();
                                    m_writer.Write("ifcowl:" + p.name + " ");

                                    Type vt = v.GetType();
                                    Console.Out.WriteLine("WriteEntityAttributes.GetURIObject()");
                                    URIObject newUriObject = GetURIObject(vt.Name, vt.GetField("Value").GetValue(v).ToString(), vt.GetField("Value").FieldType.Name);
                                    m_writer.Write("inst:" + newUriObject.URI);
                                    //this.WriteValueWrapper(v);
                                }
                                else if (f.FieldType.IsValueType) // must be IfcBinary
                                {
                                    Console.Out.WriteLine("MESSAGE-CHECK: Write IfcBinary 1");
                                    m_writer.Write(";" + "\r\n");
                                    WriteIndent();
                                    m_writer.Write("ifcowl:" + p.name + " ");

                                    FieldInfo fieldValue = f.FieldType.GetField("Value");
                                    if (fieldValue != null)
                                    {
                                        v = fieldValue.GetValue(v);
                                        if (v is byte[])
                                        {
                                            // binary data type - we don't support anything other than 8-bit aligned, though IFC doesn't either so no point in supporting extraBits
                                            byte[] bytes = (byte[])v;

                                            char[] s_hexchar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                                            StringBuilder sb = new StringBuilder(bytes.Length * 2);
                                            for (int i = 0; i < bytes.Length; i++)
                                            {
                                                byte b = bytes[i];
                                                sb.Append(s_hexchar[b / 0x10]);
                                                sb.Append(s_hexchar[b % 0x10]);
                                            }
                                            v = sb.ToString();
                                            this.m_writer.WriteLine("\""+v+ "\"");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Out.WriteLine("Warning: Found some other kind of object property: " + p.domain + " - " + p.name);
                                }
                            }                        
                        }
                        else
                        {
                            Console.Out.WriteLine("Empty value: skipping");
                        }
                    }
                }
                else
                {
                    //Console.Out.WriteLine("Found inverse property - skipping : " + f.Name);
                }
            }

            m_writer.Write(".\r\n\r\n");
            Console.Out.WriteLine("End of attribute");

            return;
        }

        private void WriteListOfListWithValues(Type ft, System.Collections.IList list)
        {
            //Console.Out.WriteLine("WriteListOfListWithValues()");
            //example:
            //owl: allValuesFrom expr:INTEGER_List_List;
            //owl: onProperty ifc:coordIndex_IfcTriangulatedFaceSet
            ft = ft.GetGenericArguments()[0].GetGenericArguments()[0];
            FieldInfo fieldValue = ft.GetField("Value");
            
            List<string> listoflists = new List<string>();
            ListObject newListObject;

            for (int i = 0; i < list.Count; i++)
            {
                //new List of List
                List<string> valuelist = new List<string>();
                System.Collections.IList listInner = (System.Collections.IList)list[i];
                for (int j = 0; j < listInner.Count; j++)
                {
                    object elem = listInner[j];
                    if (elem != null) // should never be null, but be safe
                    {
                        elem = fieldValue.GetValue(elem);
                        string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                        valuelist.Add(encodedvalue);
                    }
                }

                //create listObject
                Console.Out.WriteLine("Message: Creating ListOfListWithValues with XSDType : " + fieldValue.FieldType.Name);
                //newListObject = GetListObject(ft.Name + "_List_", ft.Name, valuelist, fieldValue.GetType().Name);
                newListObject = GetListObject(ft.Name + "_List_", ft.Name, valuelist, fieldValue.FieldType.Name);

                //Console.Out.WriteLine("written list prop (as obj. prop - part of list of list): attr = " + "inst:" + newListObject.URI);

                //add to listOfList
                listoflists.Add(newListObject.URI);
            }

            ListObject newListOfListObject = GetListOfListObject(ft.Name, listoflists, "###LISTOFLIST###");
            m_writer.Write("inst:" + newListOfListObject.URI);
            Console.Out.WriteLine("written list of list prop (as obj. prop): attr = " + "inst:" + newListOfListObject.URI);
        }

        private void WriteListWithValues(Type ft, System.Collections.IList list)
        {
            //Console.Out.WriteLine("WriteListWithValues() started");
            ft = ft.GetGenericArguments()[0];

            List<string> valuelist = new List<string>();

            FieldInfo fieldValue = ft.GetField("Value");
            for (int i = 0; i < list.Count; i++)
            {
                object elem = list[i];
                if (elem != null) // should never be null, but be safe
                {
                    elem = fieldValue.GetValue(elem);
                    if (elem is byte[])
                    {
                        // IfcPixelTexture.Pixels
                        if (i == 0)
                            Console.Out.WriteLine("MESSAGE-CHECK: Write IfcBinary 2");
                        byte[] bytes = (byte[])elem;

                        char[] s_hexchar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                        StringBuilder sb = new StringBuilder(bytes.Length * 2);
                        for (int z = 0; z < bytes.Length; z++)
                        {
                            byte b = bytes[z];
                            sb.Append(s_hexchar[b / 0x10]);
                            sb.Append(s_hexchar[b % 0x10]);
                        }
                        valuelist.Add(sb.ToString());
                    }
                    else
                    {
                        //Simple list: like an IfcCartesianPoint
                        string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                        valuelist.Add(encodedvalue);
                    }
                }
            }

            Console.Out.WriteLine("Message: Creating WriteListWithValues with XSDType : " + fieldValue.FieldType.Name);
            //Console.Out.WriteLine("Warning: Creating WriteListWithValues with XSDType : " + fieldValue.GetType().Name);
            ListObject newListObject = GetListObject(ft.Name + "_List_", ft.Name, valuelist, fieldValue.FieldType.Name);
            m_writer.Write("inst:" + newListObject.URI);
            //Console.Out.WriteLine("WriteListWithValues() finished");
        }

        private void WriteTypeValue(Type ft, object v)
        {
            string owlClass = ft.Name;
            if (owlClass.StartsWith("Nullable"))
                owlClass = ft.GetGenericArguments()[0].Name;

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

            if (ft.IsEnum)
            {
                //write enumproperty
                m_writer.Write("ifcowl:" + v);
            }
            if (ft == typeof(bool))
            {
                v = v.ToString().ToLowerInvariant();
            }

            if (v is System.Collections.IList)
            {
                // IfcBinary!!
                Console.Out.WriteLine("WARNING-TOCHECK: Write IfcBinary 3");
                System.Collections.IList list = (System.Collections.IList)v;

                //TODO: make sure this is also valid for othter Types with Lists
                if (owlClass == "IfcCompoundPlaneAngleMeasure")
                {
                    List<String> valuelist = new List<String>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        object elem = list[i];
                        if (elem != null) // should never be null, but be safe
                        {
                            string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                            valuelist.Add(encodedvalue);
                        }
                    }
                    ft = ft.GetGenericArguments()[0];
                    string s = ft.Name;
                    if (s == "Int64" || s == "Double" || s == "String" || s == "Number" || s == "Real" || s == "Integer" || s == "Logical" || s == "Boolean" || s == "Binary")
                        s = CheckForExpressPrimaryTypes(s);
                    Console.Out.WriteLine("Message: Creating IfcCompoundPlaneAngleMeasure list with XSDType : " + ft.Name);
                    ListObject newListObject = GetListObject(owlClass + "_List_", s, valuelist, ft.Name);
                    m_writer.Write("inst:" + newListObject.URI);
                }
                else
                {
                    string fullvalue = "";
                    for (int i = 0; i < list.Count; i++)
                    {
                        object elem = list[i];
                        if (elem != null) // should never be null, but be safe
                        {
                            string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());

                            fullvalue += Int32.Parse(encodedvalue).ToString("X");
                        }
                    }
                    this.m_writer.Write(fullvalue);
                }                
            }
            else if (v != null && !ft.IsEnum)
            {
                string encodedvalue = System.Security.SecurityElement.Escape(v.ToString());

                if (owlClass == "Int64" || owlClass == "Double" || owlClass == "String" || owlClass == "Number" || owlClass == "Real" || owlClass == "Integer" || owlClass == "Logical" || owlClass == "Boolean" || owlClass == "Binary")
                    owlClass = CheckForExpressPrimaryTypes(owlClass);
                Console.Out.WriteLine("WriteTypeValue.GetURIObject()");
                URIObject newUriObject = GetURIObject(owlClass, encodedvalue, ft.Name);
                m_writer.Write("inst:" + newUriObject.URI);                               
            }
        }

        private void WriteListKindOfObjectProperty(FieldInfo f, object v, Type ft, ObjectProperty p, System.Collections.IList list)
        {
            Console.Out.WriteLine("WriteListKindOfObjectProperty()");
            if (p.setorlist.Equals("LIST"))
            {
                ft = ft.GetGenericArguments()[0];
                //inst:IfcLengthMeasure_List_42.
                List<String> valuelist = new List<String>();
                m_writer.Write(";" + "\r\n");
                this.WriteIndent();
                m_writer.Write("ifcowl:" + p.name + " ");
                string xsdt = "";

                for (int i = 0; i < list.Count; i++)
                {
                    object e = list[i];
                    if (e is SEntity)
                    {
                        Type vt = e.GetType();
                        xsdt = vt.Name;
                        valuelist.Add(vt.Name + "_" + ((SEntity)e).OID);
                    }
                    else
                    {
                        Type vt = e.GetType();
                        xsdt = ft.Name;

                        object x = vt.GetField("Value").GetValue(e);

                        if (x is System.Collections.IList)
                        {
                            //IfcLineIndex, IfcArcIndex
                            //IfcSegmentIndexSelect
                            System.Collections.IList l = (System.Collections.IList)x;
                            List<string> sl = new List<string>();
                            for (int j = 0; j < l.Count; j++)
                            {
                                object elem = l[j];
                                if (elem != null) // should never be null, but be safe
                                {
                                    string encodedvalue = System.Security.SecurityElement.Escape(elem.GetType().GetField("Value").GetValue(elem).ToString());
                                    sl.Add(encodedvalue);
                                }                                
                            }

                            Console.Out.WriteLine("Message: Creating WriteListKindOfObjectProperty list with XSDType : " + l[0].GetType().GetField("Value").FieldType.Name);
                            ListObject newTypeListObject = GetListObject(vt.Name+"_", l[0].GetType().Name.ToString(), sl, l[0].GetType().GetField("Value").FieldType.Name); 
                            
                            Console.Out.WriteLine("Handling list of types - newListObject.URI : " + newTypeListObject.URI + " with type " + l[0].GetType().GetField("Value").FieldType.Name);
                            valuelist.Add(newTypeListObject.URI);
                        }
                        else
                        {
                            Console.Out.WriteLine("WriteInnerListKindOfObjectProperty.GetURIObject()");
                            URIObject newUriObject = GetURIObject(vt.Name, vt.GetField("Value").GetValue(e).ToString(), vt.GetField("Value").FieldType.Name);
                            Console.Out.WriteLine("Handling list of types - newUriObject.URI : " + newUriObject.URI + " with type " + vt.GetField("Value").FieldType.Name);
                            valuelist.Add(newUriObject.URI);
                        }

                    }
                }

                Console.Out.WriteLine("Message: Creating WriteListKindOfObjectProperty list with XSDType : " + "###ENTITY###");
                ListObject newListObject = GetListObject(xsdt + "_List_", xsdt, valuelist, "###ENTITY###");
                m_writer.Write("inst:" + newListObject.URI);
                //IfcRepresentation_List_#121_#145_#137
            }

            else if (p.setorlist.Equals("LISTOFLIST"))
            {
                //example:
                //owl: allValuesFrom expr:INTEGER_List_List;
                //owl: onProperty ifc:coordIndex_IfcTriangulatedFaceSet
                ft = ft.GetGenericArguments()[0].GetGenericArguments()[0];

                m_writer.Write(";" + "\r\n");
                this.WriteIndent();
                m_writer.Write("ifcowl:" + p.name + " ");

                List<string> listoflists = new List<string>();
                ListObject newListObject;

                for (int i = 0; i < list.Count; i++)
                {
                    //new List of List
                    List<string> valuelist = new List<string>();
                    System.Collections.IList listInner = (System.Collections.IList)list[i];
                    for (int j = 0; j < listInner.Count; j++)
                    {
                        object e = listInner[j];
                        if (e != null) // should never be null, but be safe
                        {
                            if (e is SEntity)
                            {
                                Type vt = e.GetType();
                                valuelist.Add(vt.Name + "_" + ((SEntity)e).OID);
                            }
                            else
                            {
                                Console.Out.WriteLine("WARNING - unhandled list of list: " + e.ToString());
                            }
                        }
                    }

                    //create listObject
                    Console.Out.WriteLine("Message: Creating WriteListKindOfObjectProperty list with XSDType : " + "###ENTITY###");
                    newListObject = GetListObject(ft.Name+"_List_", ft.Name, valuelist, "###ENTITY###");

                    //add to listOfList
                    listoflists.Add(newListObject.URI);
                }

                ListObject newListOfListObject = GetListOfListObject(ft.Name, listoflists, "###LISTOFLIST###");
                m_writer.Write("inst:" + newListOfListObject.URI);
                //Console.Out.WriteLine("written list of list prop (as obj. prop): attr = " + "inst:" + newListOfListObject.URI);
            }

            else {
                for (int i = 0; i < list.Count; i++)
                {
                    object e = list[i];
                    if (e is SEntity)
                    {
                        if (p.setorlist.Equals("SET"))
                        {
                            m_writer.Write(";" + "\r\n");
                            WriteIndent();
                            m_writer.Write("ifcowl:" + p.name + " ");

                            Type vt = e.GetType();
                            this.m_writer.Write("inst:" + vt.Name + "_" + ((SEntity)e).OID);
                            Console.Out.WriteLine("written object prop to SET:" + p.name + " - " + vt.Name + "_" + ((SEntity)e).OID);
                        }
                        else if (p.setorlist.Equals("LIST") || p.setorlist.Equals("LISTOFLIST"))
                        {
                            //Already handled in the code above
                        }
                        else
                        {
                            Console.Out.WriteLine("Warning: Found something that should not be possible : " + p.name + " - " + ((SEntity)e).OID + " - not handled");
                        }
                    }
                    else if (e is System.Collections.IList)
                    {
                        Console.Out.WriteLine("Skipping: because already handled above (LIST OF LIST)");
                    }
                    else
                    {
                        //#77= IFCTRIMMEDCURVE(#83,(IFCPARAMETERVALUE(0.0),#78),(IFCPARAMETERVALUE(1.52202550844946),#79),.T.,.PARAMETER.);
                        //#78= IFCCARTESIANPOINT((0.0,0.0,0.0));
                        
                        // if flat-list (e.g. structural load Locations) or list of strings (e.g. IfcPostalAddress.AddressLines), must wrap
                        //this.WriteValueWrapper(e);
                        m_writer.Write(";" + "\r\n");
                        WriteIndent();
                        m_writer.Write("ifcowl:" + p.name + " ");
                        Type vt = e.GetType();
                        Console.Out.WriteLine("WriteListKindOfObjectProperty.GetURIObject() - A");
                        URIObject newUriObject = GetURIObject(vt.Name, vt.GetField("Value").GetValue(e).ToString(), vt.GetField("Value").FieldType.Name);
                        if (newUriObject.XSDType == "Value")
                            Console.Out.WriteLine("warning: found Value XSDType");
                        m_writer.Write("inst:" + newUriObject.URI);
                        Console.Out.WriteLine("WARNING-TOCHECK: found list of data values - handled : " + "ifcowl:" + p.name + " inst: " + newUriObject.URI);
                    }
                }
            }
        }

        //WRITE HELPER METHODS
        private void WriteHeader()
        {
            if (this.m_markup)
            {
                string style = "../../";

                this.m_writer.Write("<!DOCTYPE HTML>\r\n");
                this.m_writer.Write("<html>\r\n");
                this.m_writer.Write("  <head>\r\n");
                this.m_writer.Write("    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\r\n");
                this.m_writer.Write("    <link rel=\"stylesheet\" type=\"text/css\" href=\"" + style + "ifc-styles.css\">\r\n");
                this.m_writer.Write("    <link rel=\"stylesheet\" type=\"text/css\" href=\"" + style + "details-shim.css\">\r\n");
                this.m_writer.Write("    <script type=\"text/javascript\" src=\"" + style + "details-shim.js\"></script>\r\n");
                this.m_writer.Write("    <title>" + "Example" + "</title>\r\n");
                this.m_writer.Write("  </head>\r\n");
                this.m_writer.Write("  <body>\r\n");
                this.m_writer.Write("\r\n");

                this.m_writer.Write("<tt class=\"spf\">\r\n");
            }

            string newline = "\r\n";

            string header = "# baseURI: " + m_baseURI + newline;
            header += "# imports: " + m_owlURI + newline + newline;

            string schema = "@prefix ifcowl: <" + m_owlURI + "> ." + newline;
            schema += "@prefix inst: <" + m_baseURI + "> ." + newline;
            schema += "@prefix list: <" + "https://w3id.org/list#" + "> ." + newline;
            schema += "@prefix express: <" + "https://w3id.org/express#" + "> ." + newline;
            schema += "@prefix rdf: <" + "http://www.w3.org/1999/02/22-rdf-syntax-ns#" + "> ." + newline;
            schema += "@prefix xsd: <" + "http://www.w3.org/2001/XMLSchema#" + "> ." + newline;
            schema += "@prefix owl: <" + "http://www.w3.org/2002/07/owl#" + "> ." + newline + newline;

            if (this.m_markup)
            {
                header = System.Net.WebUtility.HtmlEncode(header);// +"<br/>";
                schema = System.Net.WebUtility.HtmlEncode(schema);// +"<br/>";
            }

            this.m_writer.Write(header);
            this.m_writer.Write(schema);

            this.m_writer.Write("inst:" + newline);
            m_indent = 0;
            m_indent++;
            WriteIndent();
            this.m_writer.Write("rdf:type owl:Ontology;" + newline);
            WriteIndent();
            if (this.m_markup)
                this.m_writer.Write("owl:imports &lt;" + m_owlURI + "&gt; ." + newline + newline);
            else
                this.m_writer.Write("owl:imports <" + m_owlURI + "> ." + newline + newline);
        }

        private void WriteIndent()
        {
            if (this.m_markup)
            {
                for (int i = 0; i < this.m_indent; i++)
                {
                    this.m_writer.Write("&nbsp;");
                }
            }
            else
            {
                for (int i = 0; i < this.m_indent; i++)
                {
                    this.m_writer.Write(" ");
                }
            }
        }

        private void WriteStartElement(string name, string hyperlink)
        {
            this.WriteIndent();
            if (this.m_markup)
            {
                this.m_writer.Write("inst:");
                if (hyperlink != null)
                {
                    this.m_writer.Write("<a href=\"" + hyperlink + "\">" + name + "</a>");
                }
                else
                {
                    this.m_writer.Write(name);
                }
            }
            else
            {
                this.m_writer.Write("inst:" + name);
            }
        }

        private void WriteType(string type)
        {
            this.WriteIndent();
            this.m_writer.Write("rdf:type " + type);
        }

        private string CheckForExpressPrimaryTypes(string owlClass)
        {
            if (owlClass.Equals("integer", StringComparison.CurrentCultureIgnoreCase) || owlClass.Equals("Int64", StringComparison.CurrentCultureIgnoreCase))
                return "INTEGER";
            else if (owlClass.Equals("real", StringComparison.CurrentCultureIgnoreCase))
                return "REAL";
            else if (owlClass.Equals("double", StringComparison.CurrentCultureIgnoreCase))
                return "DOUBLE";
            else if (owlClass.Equals("Binary", StringComparison.CurrentCultureIgnoreCase))
                return "BINARY";
            else if (owlClass.Equals("boolean", StringComparison.CurrentCultureIgnoreCase))
                return "BOOLEAN";
            else if (owlClass.Equals("logical", StringComparison.CurrentCultureIgnoreCase))
                return "LOGICAL";
            else if (owlClass.Equals("string", StringComparison.CurrentCultureIgnoreCase))
                return "STRING";
            else {
                Console.Out.WriteLine("WARNING: found xsdType " + owlClass + " - not sure what to do with it");
            }

            return "";
        }

        private void WriteLiteralValue(string xsdType, string literalString)
        {
            Console.Out.WriteLine("WriteLiteralValue: " + "xsdtype: " + xsdType + " - literalString " + literalString);
            WriteIndent();
            if (xsdType.Equals("integer", StringComparison.CurrentCultureIgnoreCase) || xsdType.Equals("Int64", StringComparison.CurrentCultureIgnoreCase))
                m_writer.Write("express:hasInteger" + " " + literalString + " ");
            else if (xsdType.Equals("double", StringComparison.CurrentCultureIgnoreCase))
                m_writer.Write("express:has" + xsdType + " \"" + literalString.Replace(',','.') + "\"^^xsd:double ");
            else if (xsdType.Equals("hexBinary", StringComparison.CurrentCultureIgnoreCase))
                m_writer.Write("express:has" + xsdType + " " + literalString + " ");
            else if (xsdType.Equals("boolean", StringComparison.CurrentCultureIgnoreCase))
                m_writer.Write("express:has" + xsdType + " " + literalString.ToLower() + " ");
            else if (xsdType.Equals("logical", StringComparison.CurrentCultureIgnoreCase))
            {
                if (literalString.Equals(".F.", StringComparison.CurrentCultureIgnoreCase))
                    m_writer.Write("express:has" + xsdType + " express:FALSE ");
                else if (literalString.Equals(".T.", StringComparison.CurrentCultureIgnoreCase))
                    m_writer.Write("express:has" + xsdType + " express:TRUE ");
                else if (literalString.Equals(".U.", StringComparison.CurrentCultureIgnoreCase))
                    m_writer.Write("express:has" + xsdType + " express:UNKNOWN ");
                else
                    Console.Out.WriteLine("WARNING: found odd logical value: " + literalString);
            }
            else if (xsdType.Equals("string", StringComparison.CurrentCultureIgnoreCase))
                m_writer.Write("express:has" + xsdType + " \"" + literalString + "\" ");
            else {
                m_writer.Write("express:has" + xsdType + " \"" + literalString + "\" ");
                Console.Out.WriteLine("WARNING: found xsdType " + xsdType + " - not sure what to do with it");
            }

            return;
        }

        //WRITE EXTRAS
        private void WriteExtraEntity(URIObject obj)
        {
            m_indent = 0;
            m_writer.Write("inst:" + obj.URI + "\r\n");
            m_indent++;
            string ns = "ifcowl:";
            if (obj.ifcowlclass.Equals("INTEGER") || obj.ifcowlclass.Equals("REAL") || obj.ifcowlclass.Equals("DOUBLE") || obj.ifcowlclass.Equals("BINARY") || obj.ifcowlclass.Equals("BOOLEAN") || obj.ifcowlclass.Equals("LOGICAL") || obj.ifcowlclass.Equals("STRING"))
                ns = "express:";
            WriteType(ns + obj.ifcowlclass + ";\r\n");
            Console.Out.WriteLine("WriteExtraEntity: " + "obj.URI: " + obj.URI + " - xsdtype " + obj.XSDType);
            WriteLiteralValue(obj.XSDType, obj.encodedvalue);
            m_writer.Write(".\r\n\r\n");
            Console.Out.WriteLine("written URIObject: " + "inst:" + obj.URI + " with VALUE " + obj.encodedvalue + " and TYPE " + obj.XSDType);
            return;
        }
        
        private void WriteExtraListOfListObject(ListObject obj)
        {
            if (obj.XSDType == "###LISTOFLIST###")
            {
                string ns = "ifcowl:";
                if (obj.ifcowlclass.Equals("INTEGER") || obj.ifcowlclass.Equals("REAL") || obj.ifcowlclass.Equals("DOUBLE") || obj.ifcowlclass.Equals("BINARY") || obj.ifcowlclass.Equals("BOOLEAN") || obj.ifcowlclass.Equals("LOGICAL") || obj.ifcowlclass.Equals("STRING"))
                    ns = "express:";

                //int c = obj.values.Count;                
                for (int i = 0; i < obj.values.Count; i++)
                {
                    m_indent = 0;
                    if (i == 0)
                    {
                        m_writer.Write("inst:" + obj.URI + "\r\n");
                        Console.Out.WriteLine("written ListOfListObject: " + "inst:" + obj.URI + " with TYPE " + obj.XSDType);
                    }
                    else
                    {
                        m_writer.Write("inst:" + obj.ifcowlclass + "_List_List_" + m_nextID + "\r\n");
                        Console.Out.WriteLine("written ListOfListObject: " + "inst:" + obj.ifcowlclass + "_List_List_" + m_nextID + " with TYPE " + obj.XSDType);
                    }
                 
                    //m_writer.Write("inst:" + obj.URI + "\r\n");
                    m_indent++;
                    WriteType(ns + obj.ifcowlclass + "_List_List" + ";\r\n");
                    WriteIndent();
                    m_nextID++;
                    m_writer.Write("list:hasContents inst:" + obj.values[i]);

                    //generate
                    //List<string> values_double = obj.values;
                    //values_double.RemoveAt(0);
                    //ListObject x = new ListObject(obj.ifcowlclass + "_List_List_" + m_nextID, obj.ifcowlclass, values_double, "###LISTOFLIST###");

                    if ((obj.values.Count - i) > 1)
                    {
                        m_writer.Write(";\r\n");
                        WriteIndent();
                        m_writer.Write("list:hasNext inst:" + obj.ifcowlclass + "_List_List_" + m_nextID);
                    }
                    m_writer.Write(".\r\n\r\n");
                }
            }
            else
            {
                Console.Out.WriteLine("Warning: this should not be possible: LISTOFLIST expected.");
            }
        }

        private void WriteExtraListObject(ListObject obj)
        {
            string ns = "ifcowl:";
            if (obj.listtype.Equals("INTEGER") || obj.listtype.Equals("REAL") || obj.listtype.Equals("DOUBLE") || obj.listtype.Equals("BINARY") || obj.listtype.Equals("BOOLEAN") || obj.listtype.Equals("LOGICAL") || obj.listtype.Equals("STRING"))
                ns = "express:";
            
            for (int i = 0; i < obj.values.Count; i++)
            {
                m_indent = 0;

                if (i == 0)
                //{
                    m_writer.Write("inst:" + obj.URI + "\r\n");
                    //Console.Out.WriteLine("written ListObject: " + "inst:" + obj.URI + " with TYPE " + obj.XSDType);
                //}
                else
                //{
                    m_writer.Write("inst:" + obj.listtype + "_" + m_nextID + "\r\n");
                //    Console.Out.WriteLine("written ListObject: " + "inst:" + obj.listtype + "_" + m_nextID + " with TYPE " + obj.XSDType);
                //}
                
                m_indent++;
                WriteType(ns + obj.listtype + ";\r\n");
                WriteIndent();

                m_writer.Write("list:hasContents inst:" + obj.values[i]);

                //generate
                m_nextID++;

                if ((obj.values.Count-i) > 1)
                {
                    m_writer.Write(";\r\n");
                    WriteIndent();
                    m_writer.Write("list:hasNext inst:" + obj.listtype + "_" + m_nextID);
                }
                m_writer.Write(".\r\n\r\n");
            }            

            return;
        }

        private bool URIObjectExists(string URIObjectconcat)
        {
            if (!m_valueObjects.ContainsKey(URIObjectconcat))
                return false;
            else
                return true;
        }
        
        private bool ListOfListObjectExists(string ListObjectConcat)
        {
            if (!m_listOfListObjects.ContainsKey(ListObjectConcat))
                return false;
            else
                return true;
        }

        private ObjectProperty GetObjectProperty(string x)
        {
            ObjectProperty p;
            if (m_fullpropertynames.TryGetValue(x, out p))
                return p;
            else
            {
                Console.Out.WriteLine("ERROR: propertyname not found: " + x);
                return null;
            }
        }

        private URIObject GetURIObject(string domain, string encodedvalue, string XSDType)
        {
            if (XSDType.Equals("RTFieldInfo", StringComparison.CurrentCultureIgnoreCase))
                Console.Out.WriteLine("Warning: Found RTFieldInfo XSDType for encodedvalue: " + encodedvalue);
            else
                Console.Out.WriteLine("Found seemingly ok XSDType for encodedvalue : " + encodedvalue + " - " + domain);

            //WARNING: _VALUE_ and _TYPE_ could be in the other strings
            string fullObject = domain + "_VALUE_" + encodedvalue + "_TYPE_" + XSDType;

            URIObject obj;
            if (!URIObjectExists(fullObject))
            {
                m_nextID++;
                obj = new URIObject(domain + "_" + m_nextID, domain, encodedvalue, XSDType);
                m_valueObjects.Add(fullObject, obj);
            }
            else { 
                obj = (URIObject)m_valueObjects[fullObject];
            }

            return obj;
        }

        private ListObject GetListOfListObject(string ifcowlclass, List<string> values, string XSDType)
        {
            //Console.Out.WriteLine("started GetListOfListObject run for list with number of elements: " + values.Count);
            ListObject obj;

            string encodedvalue = "";
            foreach (string s in values)
            {
                encodedvalue += s;
                encodedvalue += "_";
            }

            //WARNING: _LIST_ could be in the other strings
            encodedvalue = ifcowlclass + "_LIST_LIST_" + encodedvalue;
            if (!ListOfListObjectExists(encodedvalue))
            {
                m_nextID++;
                obj = new ListObject(ifcowlclass + "_List_List_" + m_nextID, ifcowlclass + "_List_List", ifcowlclass, values, "###LISTOFLIST###"); // ifcowlclass + "_List");
                m_listOfListObjects.Add(encodedvalue, obj);
                return obj;
            }
            else {
                obj = (ListObject)m_listOfListObjects[encodedvalue];
                return obj;
            }
        }

        //XSDType has 'XSD Data Type', '###ENTITY###', or '###LISTOFLIST###'
        private ListObject GetListObject(string listname, string ifcowlclass, List<string> values, string XSDType)
        {
            //Console.Out.WriteLine("started GetListObject run for list with number of elements: " + values.Count);
            ListObject obj;

            string encodedvalue = "";
            for (int i=0; i < values.Count; i++)
            {
                if (XSDType != "###ENTITY###")
                {
                    Console.Out.WriteLine("GetListObject().GetURIObject()");
                    //URIObject uo = GetURIObject(ifcowlclass, values[i], values[i].GetType().Name);
                    URIObject uo = GetURIObject(ifcowlclass, values[i], XSDType);
                    values[i] = uo.URI;
                    encodedvalue += uo.URI;
                }
                else {
                    encodedvalue += values[i];
                }
                encodedvalue += "_";
            }

            //WARNING: _LIST_ could be in the other strings
            //IfcLengthMeasure_List_0_0_0
            //IfcRepresentation_List_#121_#145_#137
            //encodedvalue = ifcowlclass + "_LIST_" + encodedvalue;
            encodedvalue = listname + encodedvalue;

            if (m_listObjects.ContainsKey(encodedvalue))
                return (ListObject)m_listObjects[encodedvalue]; 

            m_nextID++;

            if (XSDType == "###ENTITY###")
            {
                Console.Out.WriteLine("Creating GetListObject list with XSDType : " + ifcowlclass);
                obj = new ListObject(listname + m_nextID, listname.Substring(0,listname.Length-1), ifcowlclass, values, ifcowlclass);
            }
            else
            {
                //create the additional datatype value
                Console.Out.WriteLine("Creating GetListObject list with XSDType : " + XSDType);
                obj = new ListObject(listname + m_nextID, listname.Substring(0, listname.Length - 1), ifcowlclass, values, XSDType);
            }

            m_listObjects.Add(encodedvalue, obj);

            //Console.Out.WriteLine("finished GetListObject run for list with number of elements: " + values.Count);
            return obj;       
        }        
        
        public void Dispose()
        {
            if (this.m_writer != null)
            {
                this.m_writer.Flush();
                this.m_writer.Close();
            }

            if (this.m_stream != null)
            {
                this.m_stream.Close();
            }
        }

        public string FormatData(DocPublication docPublication, DocExchangeDefinition docExchange, Dictionary<string, DocObject> map, Dictionary<long, SEntity> instances, SEntity root, bool markup)
        {
            this.m_stream = new System.IO.MemoryStream();
            this.Instances = instances;
            this.Markup = markup;
            this.Save();

            this.m_stream.Position = 0;
            StreamReader reader = new StreamReader(this.m_stream);
            string content = reader.ReadToEnd();
            return content;            
        }
    }
}

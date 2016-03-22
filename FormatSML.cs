// Name:        FormatSML.cs
// Description: Reads/writes ISO-10303-28 STEP XML File.
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2014 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;

namespace IfcDoc.Format.SML
{
    /// <summary>
    /// Formatter for ISO 10303-28 (STEP-XML), supporting IFC-XML. Observes CNF file settings for output.
    /// </summary>
    public class FormatSML : IDisposable
    {
        Stream m_stream;
        List<DocXsdFormat> m_xsdformats;
        string m_xsdURI;
        string m_xsdCode;

        SEntity m_instance;
        bool m_markup;
        int m_indent;
        StreamWriter m_writer;
        Queue<SEntity> m_queue; // queue of entities to be serialized at root level
        HashSet<SEntity> m_saved; // keeps track of entities already written, which can be referenced
        Dictionary<SEntity, long> m_idmap; // IDs allocated for entities that are referenced

        long m_nextID;

        public FormatSML(Stream stream, List<DocXsdFormat> formats, string xsdURI, string xsdCode)
        {
            this.m_stream = stream;
            this.m_xsdformats = formats;
            this.m_xsdURI = xsdURI;
            this.m_xsdCode = xsdCode;
        }

        /// <summary>
        /// The single root instance, e.g. IfcProject
        /// </summary>
        public SEntity Instance
        {
            get
            {
                return this.m_instance;
            }
            set
            {
                this.m_instance = value;
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

        public void Save()
        {
            // pass 1: (first time ever encountering for serialization) -- determine which entities require IDs -- use a null stream
            this.m_nextID = 0;
            this.m_writer = new StreamWriter(Stream.Null);
            this.m_saved = new HashSet<SEntity>();
            this.m_idmap = new Dictionary<SEntity, long>();
            this.m_queue = new Queue<SEntity>();
            this.m_queue.Enqueue(this.m_instance);
            while (this.m_queue.Count > 0)
            {
                SEntity ent = this.m_queue.Dequeue();
                if (!this.m_saved.Contains(ent))
                {
                    this.WriteEntity(ent);
                }
            }

            // pass 2: write to file -- clear save map; retain ID map
            this.m_saved.Clear();
            this.m_writer = new StreamWriter(this.m_stream);

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
            else
            {
                //...this.m_writer.WriteLine("<?xml version=\"1.0\"?>");

            }

            string header = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";

            string schema = "<ifc:ifcXML xsi:schemaLocation=\"" + this.m_xsdURI + " " + this.m_xsdCode + ".xsd\" " +
                "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:ifc=\"" + this.m_xsdURI + "\" " +
                "xmlns=\"" + this.m_xsdURI + "\">";
/*
            string schema = "<ifc:ifcXML xsi:schemaLocation=\"http://www.buildingsmart-tech.org/ifcXML/IFC4 ifcXML4.xsd\" " +
                "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:ifc=\"http://www.buildingsmart-tech.org/ifcXML/IFC4/final\" " +
                "xmlns=\"http://www.buildingsmart-tech.org/ifcXML/IFC4/final\">"; // TBD: make configurable
*/
            if (this.m_markup)
            {
                header = System.Net.WebUtility.HtmlEncode(header);// +"<br/>";
                schema = System.Net.WebUtility.HtmlEncode(schema);// +"<br/>";
            }

            this.m_writer.WriteLine(header);
            this.m_writer.WriteLine(schema);

            this.m_queue.Enqueue(this.m_instance);
            while(this.m_queue.Count > 0)
            {
                SEntity ent = this.m_queue.Dequeue();
                if (!this.m_saved.Contains(ent))
                {
                    this.WriteEntity(ent);
                }
            }

            string footer = "</ifc:ifcXML>";
            if(this.m_markup)
            {
                footer = System.Net.WebUtility.HtmlEncode(footer);
            }
            this.m_writer.WriteLine(footer);

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
                this.m_writer.Write("&lt;");
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
                this.m_writer.Write("<" + name);
            }

            this.m_indent++;
        }

        /// <summary>
        /// Terminates the opening tag, to allow for sub-elements to be written
        /// </summary>
        private void WriteOpenElement()
        {
            // end opening tag
            if (this.m_markup)
            {
                this.m_writer.WriteLine("&gt;");//<br/>");
            }
            else
            {
                this.m_writer.WriteLine(">");
            }
        }

        /// <summary>
        /// Terminates the opening tag, with no subelements
        /// </summary>
        private void WriteCloseElement()
        {
            // close opening tag
            if (this.m_markup)
            {
                this.m_writer.WriteLine(" /&gt;");//<br/>");
            }
            else
            {
                this.m_writer.WriteLine(" />");
            }

            this.m_indent--;
        }

        private void WriteEndElement(string name)
        {
            this.m_indent--;

            this.WriteIndent();
            if (this.m_markup)
            {
                this.m_writer.Write("&lt;/");
                this.m_writer.Write(name);
                this.m_writer.WriteLine("&gt;");//<br/>");
            }
            else
            {
                this.m_writer.Write("</");
                this.m_writer.Write(name);
                this.m_writer.WriteLine(">");
            }
        }

        private DocXsdFormat GetXsdFormat(FieldInfo f)
        {
            // go in reverse order so overridden configuration takes effect
            for (int i = this.m_xsdformats.Count - 1; i >= 0; i-- )
            {
                DocXsdFormat format = this.m_xsdformats[i];
                if (format.Entity.Equals(f.DeclaringType.Name) && format.Attribute.Equals(f.Name))
                {
                    return format;
                }
            }

            return null;
        }

        private void WriteEntity(SEntity o)
        {
            // sanity check
            if (this.m_indent > 100)
            {
                return;
            }

            if (o == null)
                return;

            Type t = o.GetType();

            string hyperlink = "../../schema/" + t.Namespace.ToLower() + "/lexical/" + t.Name.ToLower() + ".htm";
            this.WriteStartElement(t.Name, hyperlink);
            bool close = this.WriteEntityAttributes(o);
            if (close)
            {
                this.WriteEndElement(t.Name);
            }
            else
            {
                this.WriteCloseElement();
            }
        }

        /// <summary>
        /// Returns true if any elements written (requiring closing tag); or false if not
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private bool WriteEntityAttributes(SEntity o)
        {
            Type t = o.GetType();

            if(t.Name.Equals("IfcPixelTexture"))
            {
                this.ToString();
            }

            long oid = 0;
            if (this.m_saved.Contains(o))
            {
                // give it an ID if needed (first pass)
                if (!this.m_idmap.TryGetValue(o, out oid))
                {
                    this.m_nextID++;
                    this.m_idmap[o] = this.m_nextID;
                }

                // reference existing; return
                this.m_writer.Write(" xsi:nil=\"true\" href=\"i");
                this.m_writer.Write(oid);
                this.m_writer.Write("\"");
                return false;
            }

            // mark as saved
            this.m_saved.Add(o);

            if (this.m_idmap.TryGetValue(o, out oid))
            {
                // record id, and continue to write out all attributes (works properly on second pass)
                this.m_writer.Write(" id=\"i");
                this.m_writer.Write(oid);
                this.m_writer.Write("\"");
            }

            // write fields as attributes
            bool haselements = false;
            IList<FieldInfo> fields = SEntity.GetFieldsAll(t);
            foreach (FieldInfo f in fields)
            {
                DocXsdFormat xsdformat = this.GetXsdFormat(f);

                if (f.IsDefined(typeof(DataMemberAttribute)) && (xsdformat == null || (xsdformat.XsdFormat != DocXsdFormatEnum.Element && xsdformat.XsdFormat != DocXsdFormatEnum.Attribute)))
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
                            m_writer.Write(" ");
                            m_writer.Write(f.Name);
                            m_writer.Write("=\"");


                            if(isvaluelistlist)
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
                                            this.m_writer.Write(" ");
                                        }

                                        object elem = listInner[j];
                                        if (elem != null) // should never be null, but be safe
                                        {
                                            elem = fieldValue.GetValue(elem);
                                            string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                                            this.m_writer.Write(encodedvalue);
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
                                        this.m_writer.Write(" ");
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
                                            this.m_writer.Write(v);
                                        }
                                        else
                                        {
                                            string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                                            this.m_writer.Write(encodedvalue);
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
                                            this.m_writer.Write(" ");
                                        }

                                        object elem = list[i];
                                        if (elem != null) // should never be null, but be safe
                                        {
                                            //elem = fieldValue.GetValue(elem);
                                            string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                                            this.m_writer.Write(encodedvalue);
                                        }
                                    }
                                }
                                else if(v != null)
                                {
                                    string encodedvalue = System.Security.SecurityElement.Escape(v.ToString());
                                    m_writer.Write(encodedvalue); //... escape it
                                }
                            }
                            m_writer.Write("\"");
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
                    DocXsdFormat format = GetXsdFormat(f);
                    if (f.IsDefined(typeof(DataMemberAttribute)) && (format == null || (format.XsdFormat != DocXsdFormatEnum.Element && format.XsdFormat != DocXsdFormatEnum.Attribute)))
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
                            (format == null || (format.XsdFormat != DocXsdFormatEnum.Hidden)))
                        {
                            object value = f.GetValue(o);
                            if (value != null)
                            {
                                if (!open)
                                {
                                    WriteOpenElement();
                                    open = true;
                                }
                                WriteAttribute(o, f, format);
                            }
                        }
                    }
                    else if (format != null && (format.XsdFormat == DocXsdFormatEnum.Element || format.XsdFormat == DocXsdFormatEnum.Attribute))
                    {
                        object value = f.GetValue(o);
                        if (value != null)
                        {
                            if (!open)
                            {
                                WriteOpenElement();
                                open = true;
                            }

                            WriteAttribute(o, f, format);
                        }
                    }
                    else
                    {
                        object value = f.GetValue(o);

                        // inverse
                        // record it for downstream serialization
                        if(value is System.Collections.IList)
                        {
                            System.Collections.IList invlist = (System.Collections.IList)value;
                            foreach(SEntity invobj in invlist)
                            {
                                if(!this.m_saved.Contains(invobj))
                                {
                                    this.m_queue.Enqueue(invobj);
                                }
                            }
                        }
                    }
                }


                return open;
            }
            else
            {
                return false;
            }
        }

        private void WriteAttribute(SEntity o, FieldInfo f, DocXsdFormat format)
        {
            object v = f.GetValue(o);
            if (v == null)
                return;

            this.WriteStartElement(f.Name, null);

            Type ft = f.FieldType;

            if (format == null || format.XsdFormat != DocXsdFormatEnum.Attribute)
            {
                this.WriteOpenElement();
            }

            if (typeof(System.Collections.ICollection).IsAssignableFrom(ft))
            {
                System.Collections.IList list = (System.Collections.IList)v;

                // for nested lists, flatten; e.g. IfcBSplineSurfaceWithKnots.ControlPointList
                if (typeof(System.Collections.ICollection).IsAssignableFrom(ft.GetGenericArguments()[0]))
                {
                    System.Collections.ArrayList flatlist = new System.Collections.ArrayList();
                    foreach(System.Collections.ICollection innerlist in list)
                    {
                        foreach(object e in innerlist)
                        {
                            flatlist.Add(e);
                        }
                    }

                    list = flatlist;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    object e = list[i];
                    if (e is SEntity)
                    {
                        if (format != null && format.XsdFormat == DocXsdFormatEnum.Attribute)
                        {
                            // only one item, e.g. StyledByItem\IfcStyledItem
                            bool closeelem = this.WriteEntityAttributes((SEntity)e);
                            if (!closeelem)
                            {
                                this.WriteCloseElement();
                                return;
                            }
                        }
                        else
                        {
                            this.WriteEntity((SEntity)e);
                        }
                    }
                    else if(e is System.Collections.IList)
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
                            this.m_writer.Write(sval);
                            this.m_writer.Write(" ");

                        }
                    }
                    else
                    {
                        // if flat-list (e.g. structural load Locations) or list of strings (e.g. IfcPostalAddress.AddressLines), must wrap
                        this.WriteValueWrapper(e);
                    }
                }
            }
            else if (v is SEntity)
            {
                if (format != null && format.XsdFormat == DocXsdFormatEnum.Attribute)
                {
                    Type vt = v.GetType();
                    if (ft != vt)
                    {
                        if(ft.Name.Equals(vt.Name))
                        {
                            this.ToString();
                        }

                        this.m_writer.Write(" xsi:type=\"");
                        if (this.m_markup)
                        {
                            string hyperlink = "../../schema/" + vt.Namespace.ToLower() + "/lexical/" + vt.Name.ToLower() + ".htm";

                            this.m_writer.Write("<a href=\"");
                            this.m_writer.Write(hyperlink);
                            this.m_writer.Write("\">");
                        }
                        this.m_writer.Write(vt.Name);
                        if (this.m_markup)
                        {
                            this.m_writer.Write("</a>");
                        }
                        this.m_writer.Write("\"");
                    }

                    bool closeelem = this.WriteEntityAttributes((SEntity)v);
                    if (!closeelem)
                    {
                        this.WriteCloseElement();
                        return;
                    }
                }
                else
                {
                    // if rooted, then check if we need to use reference; otherwise embed
                    this.WriteEntity((SEntity)v);
                }
            }
            else if(f.FieldType.IsInterface && v is ValueType)
            {
                this.WriteValueWrapper(v);
            }
            else if(f.FieldType.IsValueType) // must be IfcBinary
            {
                FieldInfo fieldValue = f.FieldType.GetField("Value");
                if(fieldValue != null)
                {
                    v = fieldValue.GetValue(v);
                    if(v is byte[])
                    {
                        this.WriteOpenElement();

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
                        this.m_writer.WriteLine(v);
                    }
                }
            }
            else
            {
                //???
                this.ToString();
            }

            WriteEndElement(f.Name);
        }

        private void WriteValueWrapper(object v)
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

            string encodedvalue = System.Security.SecurityElement.Escape(v.ToString());

            //this.m_indent++;
            this.WriteIndent();

            if (this.m_markup)
            {
                string hyperlink = "../../schema/" + vt.Namespace.ToLower() + "/lexical/" + vt.Name.ToLower() + ".htm";
                this.m_writer.WriteLine("&lt;<a href=\"" + hyperlink + "\">" + vt.Name + "</a>-wrapper&gt;" + encodedvalue + "&lt;/" + vt.Name + "-wrapper&gt;");//<br/>");
            }
            else
            {
                this.m_writer.WriteLine("<" + vt.Name + "-wrapper>" + encodedvalue + "</" + vt.Name + "-wrapper>");
            }
            //this.m_indent--;
        }

        public void Dispose()
        {
            if(this.m_writer != null)
            {
                this.m_writer.Flush();
                this.m_writer.Close();
            }

            if (this.m_stream != null)
            {
                this.m_stream.Close();
            }
        }
    }
}

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
        SEntity m_instance;
        bool m_markup;
        int m_indent;
        StreamWriter m_writer;
        ObjectIDGenerator m_gen;
        List<DocXsdFormat> m_xsdformats;

        public FormatSML(Stream stream, List<DocXsdFormat> formats)
        {
            this.m_stream = stream;
            this.m_writer = new StreamWriter(this.m_stream);
            this.m_gen = new ObjectIDGenerator();
            this.m_xsdformats = formats;
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
                this.m_gen = new ObjectIDGenerator();
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
            if (this.m_markup)
            {
                string style = "../../../";

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
                //writer.Settings.Indent = true;
#if false
                writer.WriteWhitespace("\r\n"); // easier to read
                writer.WriteStartElement("ex", "iso_10303_28", "urn:iso.org:standard:10303:part(28):version(2):xmlschema:common");
                writer.WriteWhitespace("\r\n"); // easier to read
                writer.WriteStartElement("ex", "uos", "http://www.iai-tech.org/ifcXML/IFC2X4_RC2");//??? made up url, not yet exist
                writer.WriteStartAttribute("configuration");
                writer.WriteValue("i-ifc2x4_rc2");
                writer.WriteEndAttribute();
                writer.WriteWhitespace("\r\n"); // easier to read
#endif

            this.WriteEntity(this.m_instance);

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

        
        private void WriteStartElement(string name, string hyperlink)
        {
            if (this.m_markup)
            {
                for (int i = 0; i < this.m_indent; i++)
                {
                    this.m_writer.Write("&nbsp;");
                }

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
                for (int i = 0; i < this.m_indent; i++)
                {
                    this.m_writer.Write(" ");
                }
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
                this.m_writer.WriteLine("&gt;<br/>");
            }
            else
            {
                this.m_writer.WriteLine(">");
            }
        }

        private void WriteEndElement(string name)
        {
            this.m_indent--;

            if (this.m_markup)
            {
                for (int i = 0; i < this.m_indent; i++)
                {
                    this.m_writer.Write("&nbsp;");
                }

                this.m_writer.Write("&lt;/");
                this.m_writer.Write(name);
                this.m_writer.WriteLine("&gt;<br/>");
            }
            else
            {
                for (int i = 0; i < this.m_indent; i++)
                {
                    this.m_writer.Write(" ");
                }

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
            if(this.m_indent > 100)
            {
                return;
            }

            Type t = o.GetType();

            string hyperlink = "../../schema/" + t.Namespace.ToLower() + "/lexical/" + t.Name.ToLower() + ".htm";
            this.WriteStartElement(t.Name, hyperlink);

#if false
            // id
            if (gen != null)
            {
                bool firstTime;
                long id = gen.GetId(o, out firstTime);
                writer.WriteAttributeString("id", "i" + id.ToString());
            }
#endif
            /*
            writer.WriteStartAttribute("id");
            writer.WriteValue("i" + id.ToString());
            writer.WriteEndAttribute();*/

            // write fields as attributes
            bool haselements = false;
            IList<FieldInfo> fields = SEntity.GetFieldsOrdered(t);
            foreach (FieldInfo f in fields)
            {
                object v = f.GetValue(o);
                if(v != null)
                { 
                    if (f.FieldType.IsValueType)
                    {
                        Type ft = f.FieldType;
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

                        if (v != null)
                        {
                            string encodedvalue = System.Security.SecurityElement.Escape(v.ToString()); 

                            m_writer.Write(" ");
                            m_writer.Write(f.Name);
                            m_writer.Write("=\"");
                            m_writer.Write(encodedvalue); //... escape it
                            m_writer.Write("\"");
                        }
                    }
                    else
                    {
                        haselements = true;
                    }
                }
            }

            IList<FieldInfo> inverses = SEntity.GetFieldsInverse(t);

            if (haselements || inverses.Count > 0)
            {
                WriteOpenElement();

                // write direct object references and lists
                foreach (FieldInfo f in fields)
                {
                    DocXsdFormat format = GetXsdFormat(f);

                    // hide fields where inverse attribute used instead
                    if (!f.FieldType.IsValueType &&
                        (format == null || (format.XsdFormat != DocXsdFormatEnum.Hidden)))
                    {
                        WriteAttribute(o, f);
                    }
                }

                // write inverse object references and lists
                foreach (FieldInfo f in inverses)
                {
                    DocXsdFormat format = GetXsdFormat(f);
                    if (format != null && format.XsdFormat == DocXsdFormatEnum.Element)//... check this
                    {
                        WriteAttribute(o, f); //... careful - don't write back-references...
                    }
                }

                WriteEndElement(t.Name);
            }
            else
            {
                // close opening tag
                if (this.m_markup)
                {
                    this.m_writer.WriteLine("/&gt;<br/>");
                }
                else
                {
                    this.m_writer.WriteLine("/>");
                }

                this.m_indent--;
            }
        }

        private void WriteAttribute(SEntity o, FieldInfo f)
        {
            object v = f.GetValue(o);
            if (v == null)
                return;

            this.WriteStartElement(f.Name, null);
            this.WriteOpenElement();

            Type ft = f.FieldType;
            if (typeof(System.Collections.ICollection).IsAssignableFrom(ft))
            {
                System.Collections.IList list = (System.Collections.IList)v;
                for (int i = 0; i < list.Count; i++)
                {
                    object e = list[i];
                    if (e is SEntity)
                    {
                        this.WriteEntity((SEntity)e);

                        //...WriteReference(writer, (SEntity)e);
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
                        Type et = e.GetType();
                        while (et.IsValueType && !et.IsPrimitive)
                        {
                            FieldInfo fieldValue = et.GetField("Value");
                            if (fieldValue != null)
                            {
                                e = fieldValue.GetValue(e);
                                et = fieldValue.FieldType;
                            }
                            else
                            {
                                break;
                            }
                        }

                        // write each value in sequence with spaces delimiting
                        string sval = e.ToString();
                        this.m_writer.Write(sval);
                        this.m_writer.Write(" ");
                    }
                }
            }
            else if (v is SEntity)
            {
                // if rooted, then check if we need to use reference; otherwise embed
                this.WriteEntity((SEntity)v);
                //this.WriteReference(writer, (SEntity)v);
            }
            else
            {
                // qualified value type
                this.WriteValue(v);
            }

            WriteEndElement(f.Name);
        }

        private void WriteValue(object v)
        {
            if (v != null)
            {
                //writer.WriteValue(v.ToString());//...
            }
#if false
            if (typeof(IStepValueString).IsInstanceOfType(v))
            {
                writer.WriteValue(((IStepValueString)v).Value);
            }
            else if (typeof(IStepValueReal).IsInstanceOfType(v))
            {
                writer.WriteValue(((IStepValueReal)v).Value);
            }
            else if (typeof(IStepValueInteger).IsInstanceOfType(v))
            {
                writer.WriteValue(((IStepValueInteger)v).Value);
            }
            else if (typeof(IStepValueLogical).IsInstanceOfType(v))
            {
                switch (((IStepValueLogical)v).Value)
                {
                    case SLogicalEnum.F:
                        writer.WriteValue("false");
                        break;

                    case SLogicalEnum.T:
                        writer.WriteValue("true");
                        break;

                    case SLogicalEnum.U:
                        writer.WriteValue("unknown");
                        break;
                }
            }
            else if (typeof(IStepValueBoolean).IsInstanceOfType(v))
            {
                writer.WriteValue(((IStepValueBoolean)v).Value);
            }
            else if (v.GetType().IsEnum)
            {
                writer.WriteValue(v.ToString().ToLower());
            }
#endif
        }

        private void WriteReference(XmlWriter writer, SEntity r)
        {
            writer.WriteStartElement(r.GetType().Name);

            writer.WriteStartAttribute("xsi", "nil", null);
            writer.WriteValue(true);
            writer.WriteEndAttribute();

            writer.WriteStartAttribute("ref");
            writer.WriteValue("i" + r.OID.ToString());
            writer.WriteEndAttribute();

            writer.WriteEndElement();
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

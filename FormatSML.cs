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
using IfcDoc.Format.SMF;

namespace IfcDoc.Format.SML
{
    /// <summary>
    /// Formatter for ISO 10303-28 (STEP-XML), supporting IFC-XML. Observes CNF file settings for output.
    /// </summary>
    public class FormatSML : FormatSMF,
        IFormatData
    {
        public FormatSML(Stream stream, List<DocXsdFormat> formats, string xsdURI, string xsdCode) :
            base(stream, formats, xsdURI, xsdCode)
        {
        }

        /// <summary>
        /// Terminates the opening tag, to allow for sub-elements to be written
        /// </summary>
        protected override void WriteOpenElement()
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
        protected override void WriteCloseElementEntity()
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

        protected override void WriteCloseElementAttribute()
        {
            this.WriteCloseElementEntity();
        }

        protected override void WriteStartElementEntity(string name, string hyperlink)
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

        protected override void WriteStartElementAttribute(string name, string hyperlink)
        {
            this.WriteStartElementEntity(name, hyperlink);
        }

        protected override void WriteEndElementEntity(string name)
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

        protected override void WriteEndElementAttribute(string name)
        {
            WriteEndElementEntity(name);
        }

        protected override void WriteIdentifier(long oid)
        {
            // record id, and continue to write out all attributes (works properly on second pass)
            this.m_writer.Write(" id=\"i");
            this.m_writer.Write(oid);
            this.m_writer.Write("\"");
        }

        protected override void WriteReference(long oid)
        {
            this.m_writer.Write(" xsi:nil=\"true\" href=\"i");
            this.m_writer.Write(oid);
            this.m_writer.Write("\"");
        }

        protected override void WriteType(string type, string hyperlink)
        {
            this.m_writer.Write(" xsi:type=\"");
            if (this.m_markup)
            {
                this.m_writer.Write("<a href=\"");
                this.m_writer.Write(hyperlink);
                this.m_writer.Write("\">");
            }
            this.m_writer.Write(type);
            if (this.m_markup)
            {
                this.m_writer.Write("</a>");
            }
            this.m_writer.Write("\"");
        }

        protected override void WriteTypedValue(string type, string hyperlink, string encodedvalue)
        {
            this.WriteIndent();

            if (this.m_markup)
            {
                this.m_writer.WriteLine("&lt;<a href=\"" + hyperlink + "\">" + type + "</a>-wrapper&gt;" + encodedvalue + "&lt;/" + type + "-wrapper&gt;");//<br/>");
            }
            else
            {
                this.m_writer.WriteLine("<" + type + "-wrapper>" + encodedvalue + "</" + type + "-wrapper>");
            }
        }

        protected override void WriteStartAttribute(string name)
        {
            m_writer.Write(" ");
            m_writer.Write(name);
            m_writer.Write("=\"");
        }

        protected override void WriteEndAttribute()
        {
            m_writer.Write("\"");
        }

        protected override void WriteHeader()
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
            else
            {
                //...this.m_writer.WriteLine("<?xml version=\"1.0\"?>");

            }

            string header = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";

            string schema = "<ifc:ifcXML xsi:schemaLocation=\"" + this.m_xsdURI + " " + this.m_xsdCode + ".xsd\" " +
                "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:ifc=\"" + this.m_xsdURI + "\" " +
                "xmlns=\"" + this.m_xsdURI + "\">";

            if (this.m_markup)
            {
                header = System.Net.WebUtility.HtmlEncode(header);
                schema = System.Net.WebUtility.HtmlEncode(schema);
            }

            this.m_writer.WriteLine(header);
            this.m_writer.WriteLine(schema);
        }

        protected override void WriteFooter()
        {
            string footer = "</ifc:ifcXML>";
            if (this.m_markup)
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

        public string FormatData(DocProject docProject, DocPublication docPublication, DocExchangeDefinition docExchange, Dictionary<string, DocObject> map, Dictionary<long, SEntity> instances, SEntity root, bool markup)
        {
            this.m_stream = new System.IO.MemoryStream();
            this.Instance = root;
            this.Markup = markup;
            this.Save();

            this.m_stream.Position = 0;
            StreamReader reader = new StreamReader(this.m_stream);
            string content = reader.ReadToEnd();
            return content;
        }
    }
}

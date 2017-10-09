// Name:        FormatJSN.cs
// Description: Reads/writes JSON file.
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2016 BuildingSmart International Ltd.
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

namespace IfcDoc.Format.JSN
{
    public class FormatJSN : FormatSMF,
        IFormatData
    {
        public FormatJSN(List<DocXsdFormat> formats, string xsdURI, string xsdCode) :
            base(new System.IO.MemoryStream(), formats, xsdURI, xsdCode)
        {
        }

        /// <summary>
        /// Terminates the opening tag, to allow for sub-elements to be written
        /// </summary>
        protected override void WriteOpenElement()
        {
            // do nothing
        }

        /// <summary>
        /// Terminates the opening tag, with no subelements
        /// </summary>
        protected override void WriteCloseElementEntity()
        {
            this.m_indent--;
            this.WriteIndent();
            this.m_writer.WriteLine("}");
        }

        protected override void WriteCloseElementAttribute()
        {
             // do nothing
        }

        protected override void WriteEntityStart()
        {
            this.WriteIndent();
            this.m_writer.WriteLine("{");
            this.m_indent++;
        }

        protected override void WriteEntityEnd()
        {
            this.m_indent--;
            this.WriteIndent();
            this.m_writer.Write("}");
        }

        protected override void WriteStartElementEntity(string name, string hyperlink)
        {
            this.WriteIndent();
            this.m_writer.WriteLine("{");
            this.m_indent++;
            this.WriteType(name, hyperlink);
            //this.WriteIndent();
            //this.m_writer.WriteLine("\"type\": \"" + name + "\",");
        }

        protected override void WriteStartElementAttribute(string name, string hyperlink)
        {
            this.WriteIndent();
            this.m_writer.WriteLine("\"" + name + "\": ");
        }

        protected override void WriteEndElementEntity(string name)
        {
            this.m_indent--;
            this.WriteIndent();
            this.m_writer.Write("}");
        }

        protected override void WriteEndElementAttribute(string name)
        {
            // do nothing
        }

        protected override void WriteIdentifier(long oid)
        {
            this.WriteIndent();
            this.m_writer.Write("\"id\": ");
            if (this.m_markup)
            {
                this.m_writer.Write("<a id=\"i");
                this.m_writer.Write(oid);
                this.m_writer.Write("\">");
            }
            this.m_writer.Write(oid);
            if (this.m_markup)
            {
                this.m_writer.Write("</a>");
            }
            this.m_writer.WriteLine(",");
        }

        protected override void WriteReference(long oid)
        {
            this.WriteIndent();
            this.m_writer.Write("\"href\": ");
            if(this.m_markup)
            {
                this.m_writer.Write("<a href=\"#i");
                this.m_writer.Write(oid);
                this.m_writer.Write("\">");
            }
            this.m_writer.Write(oid);
            if(this.m_markup)
            {
                this.m_writer.Write("</a>");
            }
            this.m_writer.WriteLine();
        }

        protected override void WriteType(string type, string hyperlink)
        {
            this.WriteIndent();
            this.m_writer.Write("\"type\": \"");
            if (this.m_markup)
            {
                this.m_writer.Write("<a href=\"");
                this.m_writer.Write(hyperlink);
                this.m_writer.Write("\">");

            }
            this.m_writer.Write(type);
            if(this.m_markup)
            {
                this.m_writer.Write("</a>");
            }
            this.m_writer.WriteLine("\",");
        }

        protected override void WriteTypedValue(string type, string hyperlink, string value)
        {
            this.WriteEntityStart();
            this.WriteType(type, hyperlink);
            this.WriteIndent();
            this.m_writer.WriteLine("\"value\": \"" + value + "\"");
            this.WriteEntityEnd();
        }

        protected override void WriteStartAttribute(string name)
        {
            this.WriteIndent();
            this.m_writer.Write("\"" + name + "\": \"");
        }

        protected override void WriteEndAttribute()
        {
            this.m_writer.Write("\"");
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
        }

        protected override void WriteFooter()
        {
            if(this.m_markup)
            {
                this.m_writer.Write("<br/>\r\n");
                this.m_writer.Write("</tt>\r\n");

                this.m_writer.Write("  </body>\r\n");
                this.m_writer.Write("</html>\r\n");
                this.m_writer.Write("\r\n");
            }
        }

        protected override void WriteAttributeDelimiter()
        {
            this.m_writer.WriteLine(",");
        }

        protected override void WriteAttributeTerminator()
        {
            this.m_writer.WriteLine(); // ensure closing bracket is on next line
        }

        protected override void WriteCollectionDelimiter()
        {
            this.WriteIndent();
            this.m_writer.WriteLine(",");
        }

        protected override void WriteCollectionStart()
        {
            this.WriteIndent();
            this.m_writer.WriteLine("[");
            this.m_indent++;
        }

        protected override void WriteCollectionEnd()
        {
            this.m_writer.WriteLine();
            this.m_indent--;
            this.WriteIndent();
            this.m_writer.WriteLine("]");
        }

        public void FormatData(Stream stream, DocProject docProject, DocPublication docPublication, DocExchangeDefinition docExchange, Dictionary<string, DocObject> map, Dictionary<string, Type> typemap, Dictionary<long, SEntity> instances, SEntity root, bool markup)
        {
            this.m_indent = 0;
            this.m_stream = stream;
            this.Instance = root;
            this.Markup = markup;
            this.Save();
        }
    }
}

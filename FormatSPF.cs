// Name:        FormatSPF.cs
// Description: Reads/writes ISO-10303-21 STEP Physical File (SPF).
// Author:      Tim Chipman
// Origination: This is based on prior work of Constructivity donated to BuildingSmart at no charge.
// Copyright:   (c) 2010 BuildingSmart International Ltd., (c) 2006-2010 Constructivity.com LLC.
// Note:        This specific file has dual copyright such that both organizations maintain all rights to its use.
// License:     http://www.buildingsmart-tech.org/legal


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

using IfcDoc.Schema;

namespace IfcDoc.Format.SPF
{
    public class FormatSPF : IDisposable
    {        
        string m_url;
        Stream m_stream;

        Dictionary<string, Type> m_typemap;
        Dictionary<FieldInfo, List<FieldInfo>> m_inversemap;
        Dictionary<long, SEntity> m_instances;
        ParseScope m_parsescope;        
        IList m_headertags;

        /// <summary>
        /// Encapsulates a STEP Physical File (ISO-10303-21)
        /// </summary>
        /// <param name="file">Required file path</param>
        /// <param name="types">Required map of string identifiers and types</param>
        /// <param name="instances">Optional map of instance identifiers and objects (specified if saving)</param>
        public FormatSPF(
            string file, 
            Dictionary<string, Type> typemap,
            Dictionary<long, SEntity> instances)
        {
            m_url = file;
            m_stream = new System.IO.FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            m_headertags = new List<object>();
            m_typemap = typemap;
            m_inversemap = new Dictionary<FieldInfo, List<FieldInfo>>();
            m_instances = instances;
            if (this.m_instances == null)
            {
                m_instances = new Dictionary<long, SEntity>();
            }

            // map fields for quick loading of inverse fields
            foreach (Type t in typemap.Values)
            {
                FieldInfo[] fields = t.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (FieldInfo fTarget in fields)
                {
                    DataLookupAttribute[] attrs = (DataLookupAttribute[])fTarget.GetCustomAttributes(typeof(DataLookupAttribute), false);
                    if (attrs.Length == 1)
                    {
                        Type typeElement;
                        if (fTarget.FieldType.IsGenericType)
                        {
                            // inverse set (most common)
                            typeElement = fTarget.FieldType.GetGenericArguments()[0];
                        }
                        else
                        {
                            // inverse scalar (more obscure)
                            typeElement = fTarget.FieldType;
                        }

                        FieldInfo fSource = SEntity.GetFieldByName(typeElement, attrs[0].Name); // dictionary requires reference uniqueness

                        List<FieldInfo> listField = null;
                        if (!this.m_inversemap.TryGetValue(fSource, out listField))
                        {
                            listField = new List<FieldInfo>();
                            this.m_inversemap.Add(fSource, listField);
                        }

                        listField.Add(fTarget);
                    }
                }
            }
        }

        public void Dispose()
        {
            if (this.m_stream != null)
            {
                this.m_stream.Close();
                this.m_stream = null;
            }
        }

        public IList Headers
        {
            get
            {
                return m_headertags;
            }
        }

        public Dictionary<string, Type> Types
        {
            get
            {
                return this.m_typemap;
            }
        }

        public Dictionary<long, SEntity> Instances
        {
            get
            {
                return this.m_instances;
            }
        }

        private string FormatIdentifier
        {
            get
            {
                return "ISO-10303-21";
            }
        }

        /// <summary>
        /// Reads file either parsing objects or fields
        /// </summary>
        /// <param name="stream">The stream to read</param>
        /// <param name="bFields">If true, populates fields; if false, populates objects</param>
        private void ReadFile()
        {
            m_stream.Position = 0;
            System.IO.StreamReader reader = new System.IO.StreamReader(m_stream, Encoding.ASCII);

            ParseSection parse = ParseSection.Unknown;
            string commandline = ReadNext(reader);
            while (commandline != null)
            {
                switch (parse)
                {
                    case ParseSection.Unknown:
                        if (commandline.Equals(this.FormatIdentifier))
                        {
                            parse = ParseSection.IsoStep;
                        }
                        else
                        {
                            // invalid format
                            throw new NotSupportedException("Format is not " + this.FormatIdentifier);
                        }
                        break;

                    case ParseSection.IsoStep:
                        if (commandline.Equals("HEADER"))
                        {
                            parse = ParseSection.Header;
                        }
                        else if (commandline.Equals("DATA"))
                        {
                            parse = ParseSection.Data;
                        }
                        else if (commandline.Equals("END-" + this.FormatIdentifier))
                        {
                            parse = ParseSection.Unknown;
                        }
                        break;

                    case ParseSection.Header:
                        if (commandline.Equals("ENDSEC"))
                        {
                            if (this.m_parsescope == ParseScope.Header)
                            {
                                // got everything we need from header, so return
                                return;
                            }

                            parse = ParseSection.IsoStep;
                        }
                        else if(this.m_parsescope == ParseScope.Header)
                        {
                            // process header
                            object headertag = ParseConstructor(commandline);
                            if (headertag != null)
                            {
                                m_headertags.Add(headertag);
                            }
                        }
                        break;

                    case ParseSection.Data:
                        if (commandline.Equals("ENDSEC"))
                        {
                            parse = ParseSection.IsoStep;
                        }
                        else
                        {
                            // process data
                            ReadCommand(commandline);
                        }
                        break;
                }

                commandline = ReadNext(reader);
            }
        }

        private enum ParseScope
        {
            None = 0,
            Header = 1,
            DataInstances = 2,
            DataFields = 3,
        }

        private string ReadNext(StreamReader reader)
        {
            // reads the next expression
            // skips whitespace, goes until ";" (ignores comments and string literals)

            StringBuilder sb = new StringBuilder();

            ParseCommand parse = ParseCommand.Open;
            while (parse != ParseCommand.End)
            {
                int iChar = reader.Read();
                if (iChar == -1)
                {
                    // end of file
                    return null;
                }

                char ch = (char)iChar;
                bool bAppend = true;

                // case of "/**** " -> back in comment mode
                if (parse == ParseCommand.CommentLeave && ch != '/')
                {
                    parse = ParseCommand.Comment;
                }

                if (parse == ParseCommand.Comment)
                {
                    bAppend = false;
                }


                switch (ch)
                {
                    case ';': // done
                        if (parse == ParseCommand.Open)
                        {
                            return sb.ToString();
                        }
                        break;

                    case '/': // about to enter a command or about to leave a comment
                        if (parse == ParseCommand.Open)
                        {
                            parse = ParseCommand.CommentEnter;
                            bAppend = false;
                        }
                        else if (parse == ParseCommand.CommentLeave)
                        {
                            bAppend = false;
                            parse = ParseCommand.Open;
                        }
                        break;

                    case '*':
                        if (parse == ParseCommand.CommentEnter)
                        {
                            bAppend = false;
                            parse = ParseCommand.Comment;
                        }
                        else if (parse == ParseCommand.Comment)
                        {
                            parse = ParseCommand.CommentLeave;
                        }
                        break;

                    case ' ': // empty space
                    case '\r':
                    case '\n':
                    case '\t':
                        if (parse == ParseCommand.Open)
                        {
                            bAppend = false;
                        }
                        break;

                    case '\'':
                        if (parse == ParseCommand.Open)
                        {
                            parse = ParseCommand.String;
                        }
                        else if (parse == ParseCommand.String)
                        {
                            parse = ParseCommand.Open;
                        }
                        break;
                }

                if (bAppend)
                {
                    sb.Append(ch);
                }
            }

            return null; // end of file!
        }

        /// <summary>
        /// Reads an ISO-STEP command and populates broker according to scope
        /// </summary>
        /// <param name="command">The processed STEP line to parse</param>
        /// <param name="scope">If DataInstances, then reads instances.  If DataFields, then reads fields.</param>
        private void ReadCommand(string line)
        {
            if (line[0] != '#')
            {
                // invalid
                throw new FormatException("Bad format: command must start with '#'");
            }

            int iIdTail = line.IndexOf('=');
            if (iIdTail == -1)
            {
                throw new FormatException("Bad format: object identifier must be followed by '='");
            }
            string strId = line.Substring(1, iIdTail - 1);

            long id;
            if (!Int64.TryParse(strId, out id))
            {
                throw new FormatException("Bad format: object identifier must be 32-bit signed integer");
            }

            string strConstructor = line.Substring(iIdTail + 1);

            switch(m_parsescope)
            {
                case ParseScope.DataInstances:                    
                    {
                        Type t = ParseType(strConstructor);
                        if (t != null)
                        {
                            SEntity instance = (SEntity)this.CreateInstance(t);
                            instance.OID = id;

                            // set the object in position
                            this.m_instances.Add(id, instance);
                        }
                        else
                        {
                            throw new FormatException("Unrecognized type: " + strConstructor);                        }
                    }
                    break;

                case ParseScope.DataFields:
                    {
                        object instance = this.m_instances[id];
                        LoadFields(instance, strConstructor);
                    }
                    break;
            }
        }

        public virtual void Load()
        {
            // empty file: just return
            if (this.m_stream.Length == 0)
                return;

            // read header and validate
            m_parsescope = ParseScope.Header;
            ReadFile();

            // read instances
            m_parsescope = ParseScope.DataInstances;
            ReadFile();

            // read fields
            m_parsescope = ParseScope.DataFields;
            ReadFile();
        }

        private enum ParseSection
        {
            Unknown = 0, // waiting for ISO-STEP directive
            IsoStep = 1, // ISO-STEP; waiting for header or data
            Header = 2, // header; receiving header elements until END_HEADER
            Data = 3, // receiving data until end-data
        }

        public virtual void Save()
        {
            // reset stream            
            if (this.m_stream.CanSeek)
            {
                this.m_stream.SetLength(0);
            }
            
            // write file
            StreamWriter writer = new StreamWriter(m_stream);

            // write ISO file identifier
            writer.Write(this.FormatIdentifier);
            writer.WriteLine(";");

            // HEADERS
            writer.WriteLine("HEADER;");
            foreach (object tag in m_headertags)
            {
                string strheader = FormatConstructor(tag);
                writer.Write(strheader);
                writer.WriteLine(";");
            }
            writer.WriteLine("ENDSEC;");
            writer.WriteLine();

            // DATA
            writer.WriteLine("DATA;");

            // save objects -- pass in typeof(object) to get all live objects (exclude commands and deleted objects)
            foreach(SEntity entity in this.m_instances.Values)
            {                
                string strConstructor = FormatConstructor(entity);
                string strLine = "#" + entity.OID.ToString() + "= " + strConstructor + ";";
                writer.WriteLine(strLine);
            }
            writer.WriteLine("ENDSEC;");
            writer.WriteLine();
            writer.WriteLine("END-" + this.FormatIdentifier + ";");

            writer.Flush();
            m_stream.Flush();
        }

        public enum ParseCommand
        {
            Open = 0, // normal parsing
            End = 1, // end of 
            String = 2, // inside a string
            Comment = 3, // inside a comment
            CommentEnter = 4, // possibly entering a comment (/)
            CommentLeave = 5, // possibly leaving a comment (*)
        }

        public string FormatFields(object o)
        {
            if (o == null)
                return null;

            StringBuilder sb = new StringBuilder();

            Type t = o.GetType();

            IList<FieldInfo> fields = SEntity.GetFieldsOrdered(t);
            for (int iField = 0; iField < fields.Count; iField++)
            {
                if (iField != 0)
                {
                    sb.Append(",");
                }

                System.Reflection.FieldInfo field = fields[iField];

                if (t.GetProperty(field.Name) != null)
                {
                    // special case if field is overridden
                    sb.Append("*");
                }
                else if (field.FieldType.IsInterface)
                {
                    // may need to qualify constructor if not ID'd
                    object val = field.GetValue(o);

                    if (val is SEntity)
                    {
                        SEntity entity = (SEntity)val;
                        //System.Diagnostics.Debug.Assert(entity.OID != 0);
                        sb.Append("#" + entity.OID.ToString());
                    }
                    else if (val != null)
                    {
                        // must be value type
                        string strValue = FormatConstructor(val);
                        sb.Append(strValue);
                    }
                    else
                    {
                        sb.Append("$");
                    }
                }
                else
                {
                    object val = field.GetValue(o);
                    string strValue = FormatValue(val);
                    sb.Append(strValue);
                }
            }

            return sb.ToString();
        }

        protected string FormatConstructor(object o)
        {
            StringBuilder sb = new StringBuilder();
            
            Type t = o.GetType();
            string strType = t.Name.ToUpper();
            sb.Append(strType);
            sb.Append("(");

            IList<FieldInfo> fields = SEntity.GetFieldsOrdered(t);

            if (strType.Equals("IFCLABEL")) // hack until recompile
            {
                List<FieldInfo> custom = new List<FieldInfo>();
                custom.Add(t.GetField("Value"));
                fields = custom;
            }

            for (int iField = 0; iField < fields.Count; iField++)
            {
                if (iField != 0)
                {
                    sb.Append(",");
                }

                System.Reflection.FieldInfo field = fields[iField];

                if (t.GetProperty(field.Name) != null)
                {
                    // special case if field is overridden
                    sb.Append("*");
                }
                else if (field.FieldType.IsInterface)
                {
                    // may need to qualify constructor if not ID'd
                    object val = field.GetValue(o);

                    if (val is SEntity)
                    {
                        SEntity ent = (SEntity)val;
                        sb.Append("#" + ent.OID.ToString());
                    }
                    else if (val != null)
                    {
                        // value type
                        string strValue = FormatConstructor(val);
                        sb.Append(strValue);
                    }
                    else
                    {
                        sb.Append("$");
                    }
                }
                else
                {
                    object val = field.GetValue(o);
                    string strValue = FormatValue(val);
                    sb.Append(strValue);
                }
            }

            sb.Append(")");

            return sb.ToString();
        }

        private string FormatValue(object o)
        {
            if (o == null)
            {
                return "$";
            }

            Type t = o.GetType();

            if (t == typeof(Boolean))
            {
                bool bVal = (bool)o;
                if (bVal)
                {
                    return ".T.";
                }
                else
                {
                    return ".F.";
                }
            }
            else if (t == typeof(Double))
            {
                Double dval = (Double)o;
                string strval = dval.ToString(CultureInfo.InvariantCulture);
                if (!strval.Contains("."))
                {
                    // must have decimal point per ISO-10303-21
                    int indexE = strval.IndexOf('E');
                    if (indexE > 0)
                    {                        
                        strval = strval.Insert(indexE, ".0000000"); // vex always pads seven zeros in such case
                    }
                    else
                    {
                        strval = strval + ".";
                    }
                }

                return strval;
            }
            else if (t == typeof(String))
            {
                return "'" + FormatString((string)o) + "'";
            }
            else if (t == typeof(DateTime))
            {
                DateTime date = (DateTime)o;
                return "'" + FormatDateTime(date) + "'";
            }
            else if (t.IsEnum)
            {
                string strval = o.ToString();
                if (strval != "_NONE_")
                {
                    return "." + o.ToString() + ".";
                }
                else
                {
                    return "$";
                }
            }
            else if (t == typeof(Byte[]))
            {
                char[] s_hexchar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

                int modulo = 0; // we only support full bytes
                Byte[] valuevector = (Byte[])o;
                StringBuilder sb = new StringBuilder(valuevector.Length * 2 + 1);
                sb.Append("\"");
                byte b;
                int start;
                if (modulo >= 4)
                {
                    // 4-7
                    sb.Append((modulo - 4).ToString());
                    b = valuevector[0]; // only lo nibble is valid
                    sb.Append(s_hexchar[b % 0x10]);
                    start = 1;
                }
                else
                {
                    // 0-3
                    sb.Append(modulo.ToString());
                    start = 0;
                }

                for (int i = start; i < valuevector.Length; i++)
                {
                    b = valuevector[i];
                    sb.Append(s_hexchar[b / 0x10]);
                    sb.Append(s_hexchar[b % 0x10]);
                }

                sb.Append("\"");
                return sb.ToString();
            }
            else if (typeof(IList).IsAssignableFrom(t))
            {
                return FormatList((System.Collections.IList)o);
            }
            else if (t.IsValueType)
            {
                return o.ToString();
            }
            else if (o is SRecord)
            {
                SRecord record = (SRecord)o;
                return "#" + record.OID.ToString();
            }
            else
            {
                return FormatConstructor(o);
            }            
        }

        private string FormatString(string value)
        {
            if (value == null)
                return "";

            // check if encoding is required
            bool bRecode = false;
            for (int i = 0; i < value.Length; i++)
            {
                Char ch = value[i];
                if ((ch & 0xFF80) != 0 || ch == '\\' || ch == '\'' ||
                    ch == '\r' || ch == '\n' || ch == '\t')
                {
                    bRecode = true;
                    break;
                }
            }

            // return original if no recoding is required
            if (!bRecode)
            {
                return value;
            }

            bool unicode = false; // flag for indicating whether to store as unicode

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                Char ch = value[i];

                // handle unicode
                if (ch > 255)
                {
                    // extended encoding
                    if (!unicode)
                    {
                        sb.Append(@"\X2\");
                        unicode = true;
                    }

                    sb.Append(String.Format("{0:X4}", (int)ch));
                }
                else if(unicode)
                {
                    // end of unicode; terminate
                    sb.Append(@"\X0\");
                    unicode = false;
                }

                // then all other modes
                if (ch == '\\')
                {
                    // back-slash escaping
                    sb.Append(@"\\");
                }
                else if (ch == '\'')
                {
                    // single-quote escaping
                    sb.Append(@"''"); // single-quote repeated
                }
                else if (ch >= 32 && ch < 126)
                {
                    // direct encoding
                    sb.Append(ch);
                }
                else if (ch >= 128 + 32 && ch <= 128 + 126)
                {
                    // shifted encoding
                    Char chMod = (Char)(ch & 0x007F);
                    sb.Append(@"\S\");
                    sb.Append(chMod);
                }
                else if (ch < 255)
                {
                    // other character
                    sb.Append(@"\X\");
                    sb.Append(String.Format("{0:X2}", (int)ch));
                }
            }

            if (unicode)
            {
                // end of unicode; terminate
                sb.Append(@"\X0\");
                unicode = false;
            }

            return sb.ToString();
        }

        private string FormatDateTime(DateTime value)
        {
            // '2006-07-28T15:17:15'
            return value.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        private string FormatList(System.Collections.IList list)
        {
            Type typeElement = list.GetType().GetGenericArguments()[0];

            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < list.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }

                object o = list[i];

                // if value type for interface, must pre-qualify with constructor
                if (typeElement.IsInterface && o != null && o.GetType().IsValueType)
                {
                    string strConstructor = FormatConstructor(o);
                    sb.Append(strConstructor);
                }
                else
                {
                    string strElement = FormatValue(o);
                    sb.Append(strElement);
                }

            }

            sb.Append(")");
            return sb.ToString();
        }

        private object ParseValue(Type type, string strval)
        {
            if (strval == "$" || strval == "*")
            {
                return null;
            }

            if (type.IsGenericType && type.IsValueType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // special case for Nullable types
                type = type.GetGenericArguments()[0];
            }

            // value types
            Type typewrap = null;
            while (type.IsValueType && !type.IsPrimitive)
            {
                FieldInfo fieldValue = type.GetField("Value");
                if (fieldValue != null)
                {
                    if (typewrap == null)
                    {
                        typewrap = type;
                    }
                    type = fieldValue.FieldType;
                }
                else
                {
                    break;
                }
            }

            object value = null;

            if (typeof(Int32) == type)
            {
                value = Int32.Parse(strval, CultureInfo.InvariantCulture);
            }
            else if (typeof(Int64) == type)
            {
                value = Int64.Parse(strval, CultureInfo.InvariantCulture);
            }
            else if (typeof(Single) == type)
            {
                value = Single.Parse(strval, CultureInfo.InvariantCulture);
            }
            else if (typeof(Double) == type)
            {
                value = Double.Parse(strval, CultureInfo.InvariantCulture);
            }
            else if (typeof(Boolean) == type)
            {
                if (strval == ".T.")
                {
                    value = true;
                }
                else
                {
                    value = false;
                }
            }
            else if (typeof(String) == type)
            {
                // backward compatibility for Visual Express aggregation change
                if (strval[0] == '\'')
                {

                    strval = strval.Substring(1, strval.Length - 2); // remove quotes
                    //strval = strval.Trim('\''); // buggy!  if starts or ends with escaped quotes
                    value = ParseString(strval);
                }
                else
                {
                    // could be int64
                    value = strval;
                }
            }
            else if (typeof(DateTime) == type)
            {
                strval = strval.Trim('\'');
                value = DateTime.Parse(strval);
            }
            else if (type != null && type.IsEnum)
            {
                strval = strval.Trim('.');
                System.Reflection.FieldInfo enumfield = type.GetField(strval);
                if (enumfield != null)
                {
                    value = enumfield.GetValue(null);
                }
            }
            else if (typeof(Byte[]) == type)
            {
                // assume surrounded by quotes
                int len = (strval.Length - 3) / 2; // subtract surrounding quotes and modulus character

                Byte[] valuevector = new byte[len];
                int modulo = 0;

                int offset;
                if (strval.Length % 2 == 0)
                {
                    modulo = Convert.ToInt32(strval[1]) + 4;
                    offset = 1;

                    char ch = strval[2];
                    valuevector[0] = (ch >= 'A' ? (byte)(ch - 'A' + 10) : (byte)ch);
                }
                else
                {
                    modulo = Convert.ToInt32((strval[1] - '0')); // [0] is quote; [1] is modulo
                    offset = 0;
                }

                for (int i = offset; i < len; i++)
                {
                    char hi = strval[i * 2 + 2 - offset];
                    char lo = strval[i * 2 + 3 - offset];

                    byte val = (byte)(
                        ((hi >= 'A' ? +(int)(hi - 'A' + 10) : (int)(hi - '0')) << 4) +
                        ((lo >= 'A' ? +(int)(lo - 'A' + 10) : (int)(lo - '0'))));

                    valuevector[i] = val;
                }

                value = valuevector;
            }
            else if (typeof(IList).IsAssignableFrom(type))
            {
                value = ParseList(type, strval);
            }
            else
            {
                value = ParseObject(strval);
            }

            if (typewrap != null)
            {
                object wrap = Activator.CreateInstance(typewrap);
                FieldInfo fieldValue = typewrap.GetField("Value");
                fieldValue.SetValue(wrap, value);
                value = wrap;
            }

            return value;
        }

        private object ParseObject(string strval)
        {
            object value;
            if (strval[0] == '#')
            {
                // reference to another object
                int iIndex = Int32.Parse(strval.Substring(1));

                if (!this.m_instances.ContainsKey(iIndex))
                {
                    return null; // hack around buggy visual express files (such as IfcDateTimeResource from IFC2x4 Alpha)
                }

                value = this.m_instances[iIndex];
            }
            else
            {
                // inline
                value = ParseConstructor(strval);
            }

            return value;
        }

        private System.Collections.IList ParseList(Type t, string line)
        {
            System.Collections.IList list = (System.Collections.IList)Activator.CreateInstance(t);

            // set owner and member

            bool bQuote = false;
            bool bValue = false;
            int nNest = 0;
            int x = 1;
            int x0 = x;
            while (x < line.Length - 1)
            {
                char ch = line[x];
                switch (ch)
                {
                    case '\'': // entering or existing string
                        bQuote = !bQuote;
                        break;

                    case '(':
                        if (!bQuote)
                        {
                            nNest++;
                        }
                        break;

                    case ')':
                        if (!bQuote)
                        {
                            nNest--;
                        }
                        break;

                    case ',': // end of parameter
                        if (!bQuote && nNest == 0)
                        {
                            bValue = true;
                        }
                        break;
                }

                if (x == line.Length - 2)
                {
                    bValue = true;
                    x++;
                }

                if (bValue)
                {
                    // parse it out
                    string strval = line.Substring(x0, x - x0);

                    Type elemtype = t.GetGenericArguments()[0];
                    object value = ParseValue(elemtype, strval);

                    // assign the value
                    if (value != null)
                    {
                        list.Add(value);
                    }
                    else
                    {
                        //... LOG ERROR...
                    }

                    // reset to next
                    x0 = x + 1;

                    bValue = false;
                }

                x++;
            }

            return list;
        }

        private string ParseString(string encoded)
        {
            if (!encoded.Contains(@"\") && !encoded.Contains("'"))
            {
                return encoded;
            }

            bool bQuote = false;
            bool bEscape = false;
            bool bParse8bit = false;
            bool bUnicode = false;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encoded.Length; i++)
            {
                Char ch = encoded[i];

                if (bParse8bit)
                {
                    if (bEscape)
                    {
                        Char ch8 = (Char)(0x80 | ch);
                        sb.Append(ch8);
                        bParse8bit = false;
                        bEscape = false;
                    }
                    else if (ch == '\\')
                    {
                        bEscape = true;
                    }
                }
                else if (bEscape)
                {
                    if (ch == 'S')
                    {
                        bParse8bit = true;
                        bEscape = false;
                    }
                    else if (ch == 'X')
                    {
                        bEscape = false;

                        if (i + 6 < encoded.Length && encoded[i + 1] == '2' && encoded[i + 2] == '\\')
                        {
                            // NEW: unicode follows
                            if (this.Headers.Count == 0) // buggy older versions
                            {
                                // 2 bytes: Unicode
                                // \X2\0000
                                string strHex = encoded.Substring(i + 3, 4);
                                int hexval = Int32.Parse(strHex, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                                Char chHex = (Char)hexval;
                                sb.Append(chHex);
                                i += 6;
                            }
                            else
                            {
                                bUnicode = true;
                                i += 2;
                            }
                        }
                        else if (i + 2 < encoded.Length && encoded[i + 1] == '0' && encoded[i + 2] == '\\')
                        {
                            // end of unicode
                            bUnicode = false;
                            i += 2;
                        }
                        else if (i + 10 < encoded.Length && encoded[i + 1] == '4' && encoded[i + 2] == '\\')
                        {
                            // 4 bytes
                            // \X4\00000000
                            string strHex = encoded.Substring(i + 3, 8);
                            int hexval = Int32.Parse(strHex, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                            Char chHex = (Char)hexval;
                            sb.Append(chHex);
                            i += 10;
                        }
                        else if (i + 3 < encoded.Length && encoded[i + 1] == '\\')
                        {
                            // 1 byte
                            // \X\00
                            string strHex = encoded.Substring(i + 2, 2);
                            int hexval = Int32.Parse(strHex, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                            Char chHex = (Char)hexval;
                            sb.Append(chHex);
                            i += 3;
                        }
                        else
                        {
                            this.ToString(); // bad format
                        }
                    }
                    else if (ch == '\\')
                    {
                        // double-escape-sequence means back-slash
                        bEscape = false;
                        sb.Append(ch);
                    }
                }
                else if (ch == '\\')
                {
                    bEscape = true;
                }
                else if (ch == '\'')
                {
                    // quotes doubled up
                    if (bQuote)
                    {
                        sb.Append(ch);
                        bQuote = false;
                    }
                    else
                    {
                        bQuote = true;
                    }
                }
                else if (bUnicode)
                {
                    string strHex = encoded.Substring(i, 4);
                    int hexval = Int32.Parse(strHex, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                    Char chHex = (Char)hexval;
                    sb.Append(chHex);
                    i += 3; // account for 3 additional characters
                }
                else
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        private Type ParseType(string line)
        {
            int iParam = line.IndexOf('(');
            if (iParam == -1)
            {
                throw new InvalidDataException("Invalid Data: " + line);
            }

            string strType = line.Substring(0, iParam);
            strType = strType.Trim();

            Type t = null;

            if (this.m_parsescope == ParseScope.Header)
            {
                switch (strType)
                {
                    case "FILE_DESCRIPTION":
                        t = typeof(FILE_DESCRIPTION);
                        break;

                    case "FILE_SCHEMA":
                        t = typeof(FILE_SCHEMA);
                        break;

                    case "FILE_NAME":
                        t = typeof(FILE_NAME);
                        break;
                }
            }
            else
            {
                t = this.m_typemap[strType];
            }

            if (t == null)
            {                
                System.Diagnostics.Debug.WriteLine(strType);
                return null;
            }

            return t;
        }

        private object ParseConstructor(string line)
        {
            Type type = ParseType(line);
            if (type == null)
            {
                throw new FormatException("Unknown type: " + line);
            }

            object instance = this.CreateInstance(type);

            LoadFields(instance, line);

            return instance;
        }

        private void LoadFields(object instance, string line)
        {
            if (instance is Schema.VEX.AGGREGATES)
            {
                this.ToString();
            }

            try
            {
                Type t = instance.GetType();
                IList<FieldInfo> fields = SEntity.GetFieldsOrdered(t);

                int iParam = line.IndexOf('(');

                int n = 0;
                int x = iParam + 1;
                int x0 = x;
                bool bQuote = false;
                int nNest = 0;
                bool bValue = false;

                while (x < line.Length - 1 && n < fields.Count)
                {
                    char ch = line[x];
                    switch (ch)
                    {
                        case '\'': // entering or existing string
                            bQuote = !bQuote;
                            break;

                        case '(':
                            if (!bQuote)
                            {
                                nNest++;
                            }
                            break;

                        case ')':
                            if (!bQuote)
                            {
                                nNest--;
                            }
                            break;

                        case ',': // end of parameter
                            if (!bQuote && nNest == 0)
                            {
                                bValue = true;
                            }
                            break;
                    }

                    if (x == line.Length - 2)
                    {
                        bValue = true;
                        x++;
                    }

                    if (bValue)
                    {
                        // parse it out
                        System.Reflection.FieldInfo field = fields[n];

                        if (field == null)
                        {
                            throw new InvalidDataException();
                        }

                        string strval = line.Substring(x0, x - x0);

                        ParseField(field, instance, strval);

                        // reset to next
                        x0 = x + 1;
                        n++;

                        bValue = false;
                    }

                    x++;
                }
            }
            catch (System.Exception xxx)
            {
                // invalid data!
                xxx.ToString();
                System.Diagnostics.Debug.WriteLine("SPF Reader: " + xxx.ToString());
            }
        }

        private object CreateInstance(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            object o = FormatterServices.GetUninitializedObject(t);
            return o;
        }

        private void ParseField(FieldInfo field, object instance, string strval)
        {
            // "*" means accept existing/derived value
            if (strval.Length == 0 || strval[0] == '*')
            {
                return;
            }

            // assign the value
            object value = null;

            try
            {
                value = ParseValue(field.FieldType, strval);
                if (value != null)
                {
                    field.SetValue(instance, value);

                    // set inverse link for singular references
                    if (this.m_inversemap != null && (value is SEntity || value is IList))
                    {
                        List<FieldInfo> listField = null;
                        if (this.m_inversemap.TryGetValue(field, out listField))
                        {
                            if (value is SEntity)
                            {
                                foreach (FieldInfo fieldInverse in listField)
                                {
                                    if (fieldInverse.DeclaringType.IsInstanceOfType(value))
                                    {
                                        // set reverse field
                                        if (typeof(IList).IsAssignableFrom(fieldInverse.FieldType))
                                        {
                                            IList list = (IList)fieldInverse.GetValue(value);
                                            if (list == null)
                                            {
                                                // must allocate list
                                                list = (IList)Activator.CreateInstance(fieldInverse.FieldType);
                                                fieldInverse.SetValue(value, list);
                                            }

                                            // now add to inverse set
                                            list.Add(instance);
                                        }
                                        else
                                        {
                                            fieldInverse.SetValue(value, instance);
                                        }
                                    }
                                }
                            }
                            else if (value is IList)
                            {
                                // set reverse field
                                IList listSource = (IList)value;
                                foreach (SEntity itemSource in listSource)
                                {
                                    foreach (FieldInfo fieldInverse in listField)
                                    {
                                        if (fieldInverse.DeclaringType.IsInstanceOfType(itemSource) &&
                                            typeof(IList).IsAssignableFrom(fieldInverse.DeclaringType))
                                        {
                                            IList listTarget = (IList)fieldInverse.GetValue(itemSource);
                                            if (listTarget == null)
                                            {
                                                // must allocate list
                                                listTarget = (IList)Activator.CreateInstance(fieldInverse.FieldType);
                                                fieldInverse.SetValue(itemSource, listTarget);
                                            }

                                            // now add to inverse set
                                            listTarget.Add(instance);
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch
            {
                // eat it -- compatible file format change in v3.5 regarding DocDefinition.DiagramRectangle (entity) replacing TemplateStatus (integer)
            }
        }

        public void InitHeaders(string filename, string schema)
        {
            FILE_DESCRIPTION hDesc = new FILE_DESCRIPTION();
            hDesc.implementation_level = "2;1";

            FILE_NAME hName = new FILE_NAME();
            hName.Name = filename;
            hName.OriginatingSystem = "buildingSMART IFC Documentation Generator";
            hName.PreprocessorVersion = "buildingSMART IFCDOC 6.3"; // was "buildingSMART IFCDOC" for 2.7 and earlier;
            hName.Author.Add(System.Environment.UserName);
            hName.Organization.Add(System.Environment.UserDomainName);
            hName.Timestamp = DateTime.UtcNow;

            FILE_SCHEMA hSchema = new FILE_SCHEMA();
            hSchema.schema.Add(schema);

            this.Headers.Add(hDesc);
            this.Headers.Add(hName);
            this.Headers.Add(hSchema);            
        }
    }


}

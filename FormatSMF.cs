// Name:        FormatSMF.cs
// Description: Base class for writing instance files for XML or JSON
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

namespace IfcDoc.Format.SMF
{
    public abstract class FormatSMF :
        IDisposable
    {
        protected Stream m_stream;
        List<DocXsdFormat> m_xsdformats;
        protected string m_xsdURI;
        protected string m_xsdCode;

        SEntity m_instance;
        protected bool m_markup;
        protected int m_indent;
        protected StreamWriter m_writer;
        Queue<SEntity> m_queue; // queue of entities to be serialized at root level
        HashSet<SEntity> m_saved; // keeps track of entities already written, which can be referenced
        Dictionary<SEntity, long> m_idmap; // IDs allocated for entities that are referenced

        long m_nextID;

        public FormatSMF(Stream stream, List<DocXsdFormat> formats, string xsdURI, string xsdCode)
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
            this.m_indent = 0;
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
            this.m_indent = 0;
            this.m_writer = new StreamWriter(this.m_stream);

            this.WriteHeader();

            this.m_queue.Enqueue(this.m_instance);
            while (this.m_queue.Count > 0)
            {
                SEntity ent = this.m_queue.Dequeue();
                if (!this.m_saved.Contains(ent))
                {
                    this.WriteEntity(ent);
                }
            }

            this.WriteFooter();

            this.m_writer.Flush();
        }

        protected void WriteIndent()
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

        protected abstract void WriteHeader();
        protected abstract void WriteFooter();

        protected abstract void WriteStartElementEntity(string name, string hyperlink);
        protected abstract void WriteEndElementEntity(string name);
        protected abstract void WriteStartElementAttribute(string name, string hyperlink);
        protected abstract void WriteEndElementAttribute(string name);
        protected abstract void WriteOpenElement();
        protected abstract void WriteCloseElementEntity();
        protected abstract void WriteCloseElementAttribute();
        protected abstract void WriteIdentifier(long oid);
        protected abstract void WriteType(string type, string hyperlink);
        protected abstract void WriteReference(long oid);
        protected abstract void WriteStartAttribute(string name);
        protected abstract void WriteEndAttribute();
        protected abstract void WriteTypedValue(string type, string hyperlink, string value);

        protected virtual void WriteEntityStart() { }
        protected virtual void WriteEntityEnd() { }
        protected virtual void WriteAttributeDelimiter() { }
        protected virtual void WriteAttributeTerminator() { }
        protected virtual void WriteCollectionStart() { }
        protected virtual void WriteCollectionDelimiter() { }
        protected virtual void WriteCollectionEnd() { }

            
        private DocXsdFormat GetXsdFormat(FieldInfo f)
        {
            // go in reverse order so overridden configuration takes effect
            for (int i = this.m_xsdformats.Count - 1; i >= 0; i--)
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
            this.WriteStartElementEntity(t.Name, hyperlink);
            bool close = this.WriteEntityAttributes(o);
            if (close)
            {
                this.WriteEndElementEntity(t.Name);
            }
            else
            {
                this.WriteCloseElementEntity();
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
                this.WriteReference(oid);
                return false;
            }

            // mark as saved
            this.m_saved.Add(o);

            if (this.m_idmap.TryGetValue(o, out oid))
            {
                this.WriteIdentifier(oid);
            }

            bool previousattribute = false;

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
                            if (previousattribute)
                            {
                                this.WriteAttributeDelimiter();
                            }

                            previousattribute = true;
                            this.WriteStartAttribute(f.Name);

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
                                            string encodedvalue = System.Security.SecurityElement.Escape(elem.ToString());
                                            this.m_writer.Write(encodedvalue);
                                        }
                                    }
                                }
                                else if (v != null)
                                {
                                    string encodedvalue = System.Security.SecurityElement.Escape(v.ToString());
                                    m_writer.Write(encodedvalue); //... escape it
                                }
                            }

                            this.WriteEndAttribute();
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

                                if (previousattribute)
                                {
                                    this.WriteAttributeDelimiter();
                                }
                                previousattribute = true;

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

                            if (previousattribute)
                            {
                                this.WriteAttributeDelimiter();
                            }
                            previousattribute = true;

                            WriteAttribute(o, f, format);
                        }
                    }
                    else
                    {
                        object value = f.GetValue(o);

                        // inverse
                        // record it for downstream serialization
                        if (value is System.Collections.IList)
                        {
                            System.Collections.IList invlist = (System.Collections.IList)value;
                            foreach (SEntity invobj in invlist)
                            {
                                if (!this.m_saved.Contains(invobj))
                                {
                                    this.m_queue.Enqueue(invobj);
                                }
                            }
                        }
                    }
                }

                this.WriteAttributeTerminator();

                return open;
            }
            else
            {
                this.WriteAttributeTerminator();
                return false;
            }
        }

        private void WriteAttribute(SEntity o, FieldInfo f, DocXsdFormat format)
        {
            object v = f.GetValue(o);
            if (v == null)
                return;

            this.WriteStartElementAttribute(f.Name, null);

            Type ft = f.FieldType;

            if (format == null || format.XsdFormat != DocXsdFormatEnum.Attribute || f.Name.Equals("InnerCoordIndices")) //hackhack -- need to resolve...
            {
                this.WriteOpenElement();
            }

            if (typeof(System.Collections.ICollection).IsAssignableFrom(ft))
            {
                System.Collections.IList list = (System.Collections.IList)v;

                // for nested lists, flatten; e.g. IfcBSplineSurfaceWithKnots.ControlPointList
                if (typeof(System.Collections.ICollection).IsAssignableFrom(ft.GetGenericArguments()[0]))
                {
                    // special case
                    if(f.Name.Equals("InnerCoordIndices")) //hack
                    {
                        foreach (System.Collections.ICollection innerlist in list)
                        {
                            string entname = "Seq-IfcPositiveInteger-wrapper"; // hack
                            this.WriteStartElementEntity(entname, null);
                            this.WriteOpenElement();
                            foreach(object e in innerlist)
                            {
                                object ev = e.GetType().GetField("Value").GetValue(e);

                                this.m_writer.Write(ev.ToString());
                                this.m_writer.Write(" ");
                            }
                            this.m_writer.WriteLine();
                            this.WriteEndElementEntity(entname);
                        }
                        WriteEndElementAttribute(f.Name);
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

                if(list.Count > 0 && list[0] is SEntity)
                {
                    this.WriteCollectionStart();
                }

                for (int i = 0; i < list.Count; i++)
                {
                    object e = list[i];
                    if (e is SEntity)
                    {
                        if (format != null && format.XsdFormat == DocXsdFormatEnum.Attribute)
                        {
                            // only one item, e.g. StyledByItem\IfcStyledItem
                            this.WriteEntityStart();
                            bool closeelem = this.WriteEntityAttributes((SEntity)e);
                            if (!closeelem)
                            {
                                this.WriteCloseElementAttribute();
                                return;
                            }
                            this.WriteEntityEnd();
                        }
                        else
                        {
                            this.WriteEntity((SEntity)e);
                        }

                        if(i < list.Count-1)
                        {
                            this.WriteCollectionDelimiter();
                        }
                    }
                    else if (e is System.Collections.IList)
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

                if (list.Count > 0 && list[0] is SEntity)
                {
                    this.WriteCollectionEnd();
                }

            }
            else if (v is SEntity)
            {
                if (format != null && format.XsdFormat == DocXsdFormatEnum.Attribute)
                {
                    this.WriteEntityStart();

                    Type vt = v.GetType();
                    if (ft != vt)
                    {
                        string hyperlink = "../../schema/" + vt.Namespace.ToLower() + "/lexical/" + vt.Name.ToLower() + ".htm";
                        this.WriteType(vt.Name, hyperlink);
                    }

                    bool closeelem = this.WriteEntityAttributes((SEntity)v);

                    if (!closeelem)
                    {
                        this.WriteCloseElementEntity();
                        return;
                    }

                    this.WriteEntityEnd();
                }
                else
                {
                    // if rooted, then check if we need to use reference; otherwise embed
                    this.WriteEntity((SEntity)v);
                }
            }
            else if (f.FieldType.IsInterface && v is ValueType)
            {
                this.WriteValueWrapper(v);
            }
            else if (f.FieldType.IsValueType) // must be IfcBinary
            {
                FieldInfo fieldValue = f.FieldType.GetField("Value");
                if (fieldValue != null)
                {
                    v = fieldValue.GetValue(v);
                    if (v is byte[])
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

            WriteEndElementAttribute(f.Name);
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

            string encodedvalue = String.Empty;
            if (v is System.Collections.IList)
            {
                // IfcIndexedPolyCurve.Segments
                System.Collections.IList list = (System.Collections.IList)v;
                StringBuilder sb = new StringBuilder();
                foreach(object o in list)
                {
                    if(sb.Length > 0)
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

            //this.WriteIndent();

            string hyperlink = "../../schema/" + vt.Namespace.ToLower() + "/lexical/" + vt.Name.ToLower() + ".htm";
            this.WriteTypedValue(vt.Name, hyperlink, encodedvalue);
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
    }
}


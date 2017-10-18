// Name:        FormatCSC.cs
// Description: C# Code Generator
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2012 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.Text;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;

namespace IfcDoc.Format.CSC
{
    internal class FormatCSC : IDisposable,
        IFormatExtension
    {
        string m_filename;
        DocProject m_project;
        DocDefinition m_definition;
        Dictionary<string, DocObject> m_map;

        /// <summary>
        /// Generates folder of definitions
        /// </summary>
        /// <param name="path"></param>
        public static void GenerateCode(DocProject project, string path, Dictionary<string, DocObject> map)
        {
            foreach (DocSection docSection in project.Sections)
            {
                foreach(DocSchema docSchema in docSection.Schemas)
                {
                    foreach(DocType docType in docSchema.Types)
                    {
                        using (FormatCSC format = new FormatCSC(path + @"\" + docSchema.Name + @"\" + docType.Name + ".cs"))
                        {
                            format.Instance = project;
                            format.Definition = docType;
                            format.Map = map;
                            format.Save();
                        }
                    }

                    foreach (DocEntity docType in docSchema.Entities)
                    {
                        using (FormatCSC format = new FormatCSC(path + @"\" + docSchema.Name + @"\" + docType.Name + ".cs"))
                        {
                            format.Instance = project;
                            format.Definition = docType;
                            format.Map = map;
                            format.Save();
                        }
                    }
                }
            }

            // save properties
            using(FormatCSC format = new FormatCSC(path + @"\pset.cs"))
            {
                format.Instance = project;
                format.Map = map;
                format.Save();
            }
        }

        public FormatCSC()
        {
            this.m_filename = null;
        }

        public FormatCSC(string filename)
        {
            this.m_filename = filename;
        }

        public DocProject Instance
        {
            get
            {
                return this.m_project;
            }
            set
            {
                this.m_project = value;
            }
        }

        /// <summary>
        /// Optional definition to save, or null for all definitions in project.
        /// </summary>
        public DocDefinition Definition
        {
            get
            {
                return this.m_definition;
            }
            set
            {
                this.m_definition = value;
            }
        }

        public Dictionary<string, DocObject> Map
        {
            get
            {
                return this.m_map;
            }
            set
            {
                this.m_map = value;
            }
        }

        public void Save()
        {
            string dirpath = System.IO.Path.GetDirectoryName(this.m_filename);
            if (!System.IO.Directory.Exists(dirpath))
            {
                System.IO.Directory.CreateDirectory(dirpath);
            }

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(this.m_filename))
            {
                writer.WriteLine("// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.");
                writer.WriteLine("// IFC content is copyright (C) 1996-2017 BuildingSMART International Ltd.");
                writer.WriteLine();

                writer.WriteLine("using System;");
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine("using System.Runtime.Serialization;");
                writer.WriteLine();

                if (this.m_definition != null)
                {
                    writer.WriteLine("namespace BuildingSmart.IFC");
                    writer.WriteLine("{");

                    if (this.m_definition is DocDefined)
                    {
                        DocDefined docDefined = (DocDefined)this.m_definition;
                        string text = this.Indent(this.FormatDefined(docDefined, this.m_map, null), 1);
                        writer.WriteLine(text);
                    }
                    else if (this.m_definition is DocSelect)
                    {
                        DocSelect docSelect = (DocSelect)this.m_definition;
                        string text = this.Indent(this.FormatSelect(docSelect, this.m_map, null), 1);
                        writer.WriteLine(text);
                    }
                    else if (this.m_definition is DocEnumeration)
                    {
                        DocEnumeration docEnumeration = (DocEnumeration)this.m_definition;
                        string text = this.Indent(this.FormatEnumeration(docEnumeration, this.m_map, null), 1);
                        writer.WriteLine(text);
                    }
                    else if (this.m_definition is DocEntity)
                    {
                        DocEntity docEntity = (DocEntity)this.m_definition;
                        string text = this.Indent(this.FormatEntity(docEntity, this.m_map, null), 1);
                        writer.WriteLine(text);
                    }

                    writer.WriteLine("}");
                }
                else
                {

                    writer.WriteLine("namespace BuildingSmart.IFC.Properties");
                    writer.WriteLine("{");
                    writer.WriteLine();

                    Dictionary<string, string[]> mapEnums = new Dictionary<string, string[]>();

                    foreach (DocSection docSection in this.m_project.Sections)
                    {
                        foreach (DocSchema docSchema in docSection.Schemas)
                        {
                            foreach (DocPropertySet docPset in docSchema.PropertySets)
                            {
                                writer.WriteLine("    /// <summary>");
                                if (docPset.Documentation != null)
                                {
                                    writer.WriteLine("    /// " + docPset.Documentation.Replace('\r', ' ').Replace('\n', ' '));
                                }
                                writer.WriteLine("    /// </summary>");

                                writer.WriteLine("    public class " + docPset.Name + " : Pset");
                                writer.WriteLine("    {");

                                foreach (DocProperty docProperty in docPset.Properties)
                                {
                                    writer.WriteLine("        /// <summary>");
                                    if (docProperty.Documentation != null)
                                    {
                                        writer.WriteLine("        /// " + docProperty.Documentation.Replace('\r', ' ').Replace('\n', ' '));
                                    }
                                    writer.WriteLine("        /// </summary>");

                                    switch (docProperty.PropertyType)
                                    {
                                        case DocPropertyTemplateTypeEnum.P_SINGLEVALUE:
                                            writer.WriteLine("        public " + docProperty.PrimaryDataType + " " + docProperty.Name + " { get { return this.GetValue<" + docProperty.PrimaryDataType + ">(\"" + docProperty.Name + "\"); } set { this.SetValue<" + docProperty.PrimaryDataType + ">(\"" + docProperty.Name + "\", value); } }");
                                            break;

                                        case DocPropertyTemplateTypeEnum.P_ENUMERATEDVALUE:
                                            {
                                                string typename = docProperty.SecondaryDataType;
                                                if (typename == null)
                                                {
                                                    typename = docProperty.PrimaryDataType; // older version
                                                }
                                                int colon = typename.IndexOf(':');
                                                if(colon > 0)
                                                {
                                                    // backwards compatibility
                                                    typename = typename.Substring(0, colon);
                                                }
                                                writer.WriteLine("        public " + typename + " " + docProperty.Name + " { get { return this.GetValue<" + typename + ">(\"" + docProperty.Name + "\"); } set { this.SetValue<" + typename + ">(\"" + docProperty.Name + "\", value); } }");
                                            }
                                            break;

                                        case DocPropertyTemplateTypeEnum.P_BOUNDEDVALUE:
                                            writer.WriteLine("        public PBound<" + docProperty.PrimaryDataType + "> " + docProperty.Name + " { get { return this.GetBound<" + docProperty.PrimaryDataType + ">(\"" + docProperty.Name + "\"); } }");
                                            break;

                                        case DocPropertyTemplateTypeEnum.P_LISTVALUE:
                                            break;

                                        case DocPropertyTemplateTypeEnum.P_TABLEVALUE:
                                            writer.WriteLine("        public PTable<" + docProperty.PrimaryDataType + ", " + docProperty.SecondaryDataType + "> " + docProperty.Name + " { get { return this.GetTable<" + docProperty.PrimaryDataType + ", " + docProperty.SecondaryDataType + ">(\"" + docProperty.Name + "\"); } }");
                                            break;

                                        case DocPropertyTemplateTypeEnum.P_REFERENCEVALUE:
                                            if (docProperty.PrimaryDataType.Equals("IfcTimeSeries"))
                                            {
                                                string datatype = docProperty.SecondaryDataType;
                                                if (String.IsNullOrEmpty(datatype))
                                                {
                                                    datatype = "IfcReal";
                                                }
                                                writer.WriteLine("        public PTimeSeries<" + datatype + "> " + docProperty.Name + " { get { return this.GetTimeSeries<" + datatype + ">(\"" + docProperty.Name + "\"); } }");
                                            }
                                            // ... TBD
                                            break;

                                        case DocPropertyTemplateTypeEnum.COMPLEX:
                                            //... TBD
                                            break;
                                    }
                                }

                                writer.WriteLine("    }");
                                writer.WriteLine();
                            }

                            foreach (DocPropertyEnumeration docEnum in docSchema.PropertyEnums)
                            {
                                writer.WriteLine("    /// <summary>");
                                writer.WriteLine("    /// </summary>");
                                writer.WriteLine("    public enum " + docEnum.Name);
                                writer.WriteLine("    {");

                                int counter = 0;
                                foreach (DocPropertyConstant docConst in docEnum.Constants)
                                {
                                    int num = 0;
                                    string id = docConst.Name.ToUpper().Trim('.').Replace('-', '_');
                                    switch (id)
                                    {
                                        case "OTHER":
                                            num = -1;
                                            break;

                                        case "NOTKNOWN":
                                            num = -2;
                                            break;

                                        case "UNSET":
                                            num = 0;
                                            break;

                                        default:
                                            counter++;
                                            num = counter;
                                            break;
                                    }

                                    if (id[0] >= '0' && id[0] <= '9')
                                    {
                                        id = "_" + id; // avoid numbers
                                    }

                                    writer.WriteLine("        /// <summary></summary>");
                                    writer.WriteLine("        " + docConst.Name + " = " + num + ",");
                                }

                                writer.WriteLine("    }");
                                writer.WriteLine();
                            }

                            //writer.WriteLine("}");                        




#if false
                    // enums
                    foreach (string strEnum in mapEnums.Keys)
                    {
                        string[] enums = mapEnums[strEnum];

                        writer.WriteLine("    /// <summary>");
                        writer.WriteLine("    /// </summary>");
                        writer.WriteLine("    public enum " + strEnum);
                        writer.WriteLine("    {");

                        int counter = 0;
                        foreach (string val in enums)
                        {
                            int num = 0;
                            string id = val.ToUpper().Trim('.').Replace('-', '_');
                            switch (id)
                            {
                                case "OTHER":
                                    num = -1;
                                    break;

                                case "NOTKNOWN":
                                    num = -2;
                                    break;

                                case "UNSET":
                                    num = 0;
                                    break;

                                default:
                                    counter++;
                                    num = counter;
                                    break;
                            }

                            if (id[0] >= '0' && id[0] <= '9')
                            {
                                id = "_" + id; // avoid numbers
                            }

                            writer.WriteLine("        /// <summary></summary>");
                            writer.WriteLine("        " + id + " = " + num + ",");
                        }

                        writer.WriteLine("    }");
                        writer.WriteLine();
                    }

                    writer.WriteLine("}");
#endif
                        }
                    }
                }

                writer.Flush();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {            
        }

        #endregion

        /// <summary>
        /// Inserts tabs for each line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private string Indent(string text, int level)
        {
            for(int i = 0; i < level; i++)
            {
                text = "\t" + text;
                text = text.Replace("\r\n", "\r\n\t");
            }

            return text;
        }

        /// <summary>
        /// Builds syntax for referencing select
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="docEntity"></param>
        /// <param name="map"></param>
        /// <param name="included"></param>
        /// <param name="hasentry">Whether entries already listed; if not, then colon is added</param>
        private void BuildSelectEntries(StringBuilder sb, DocDefinition docEntity, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included, bool hasentry)
        {
            SortedList<string, DocSelect> listSelects = new SortedList<string, DocSelect>();
            foreach (DocObject obj in map.Values)
            {
                if (obj is DocSelect)
                {
                    DocSelect docSelect = (DocSelect)obj;
                    foreach (DocSelectItem docItem in docSelect.Selects)
                    {
                        if (docItem.Name != null && docItem.Name.Equals(docEntity.Name) && !listSelects.ContainsKey(docSelect.Name))
                        {
                            // found it; add it
                            listSelects.Add(docSelect.Name, docSelect);
                        }
                    }
                }
            }

            foreach (DocSelect docSelect in listSelects.Values)
            {
                if (docSelect == listSelects.Values[0] && !hasentry)
                {
                    sb.Append(" : ");
                }
                else
                {
                    sb.Append(", ");
                }
                sb.Append(docSelect.Name);
            }
        }

        public string FormatEntity(DocEntity docEntity, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("public partial ");
            if(docEntity.IsAbstract())
            {
                sb.Append("abstract ");
            }
            sb.Append("class " + docEntity.Name);

            bool hasentry = false;
            if(!String.IsNullOrEmpty(docEntity.BaseDefinition))
            {
                sb.Append(" : ");
                sb.Append(docEntity.BaseDefinition);
                hasentry = true;
            }

            // implement any selects
            BuildSelectEntries(sb, docEntity, map, included, hasentry);

            sb.AppendLine();
            sb.AppendLine("{");

            // fields
            int order = 0;
            foreach (DocAttribute docAttribute in docEntity.Attributes)
            {
                bool inscope = false;

                if (included != null)
                {
                    included.TryGetValue(docAttribute, out inscope);
                }
                else
                {
                    inscope = true;
                }

                if(docAttribute.Inverse == null)
                {
                    sb.Append("\t[DataMember(Order=" + order + ")] ");
                    order++;
                }
                else if(inscope)
                {
                    sb.Append("\t[DataLookup(\"" + docAttribute.Inverse + "\")] ");
                }

                if (docAttribute.Inverse == null || inscope)
                {
                    DocObject docRef = null;
                    if (docAttribute.DefinedType != null)
                    {
                        map.TryGetValue(docAttribute.DefinedType, out docRef);
                    }
                    string optional = "";
                    if(docAttribute.IsOptional && (docRef == null || docRef is DocDefined))
                    {
                        optional = "?";
                    }

                    switch (docAttribute.GetAggregation())
                    {
                        case DocAggregationEnum.SET:
                            sb.AppendLine("ISet<" + docAttribute.DefinedType + "> _" + docAttribute.Name + ";");
                            break;

                        case DocAggregationEnum.LIST:
                            sb.AppendLine("IList<" + docAttribute.DefinedType + "> _" + docAttribute.Name + ";");
                            break;

                        default:
                            sb.AppendLine(docAttribute.DefinedType + optional + " _" + docAttribute.Name + ";");
                            break;
                    }
                }
            }

#if false // make an option...
            // constructor
            sb.AppendLine();
            sb.AppendLine("\tpublic " + docEntity.Name + "()");
            sb.AppendLine("\t{");
            //... values...
            sb.AppendLine("\t}");
#endif

            // properties
#if false // make an option...
            foreach (DocAttribute docAttribute in docEntity.Attributes)
            {
                sb.AppendLine();

                switch (docAttribute.GetAggregation())
                {
                    case DocAggregationEnum.SET:
                        sb.AppendLine("\tpublic ICollection<" + docAttribute.DefinedType + "> " + docAttribute.Name);
                        break;

                    case DocAggregationEnum.LIST:
                        sb.AppendLine("\tpublic IList<" + docAttribute.DefinedType + "> " + docAttribute.Name);
                        break;

                    default:
                        sb.AppendLine("\tpublic " + docAttribute.DefinedType + " " + docAttribute.Name);
                        break;
                }
                sb.AppendLine("\t\t{");

                sb.AppendLine("\t\tget");
                sb.AppendLine("\t\t{");
                sb.AppendLine("\t\t\treturn this._" + docAttribute.Name + ";");
                sb.AppendLine("\t\t}");

                if (docAttribute.GetAggregation() == DocAggregationEnum.NONE)
                {
                    sb.AppendLine("\t\tset");
                    sb.AppendLine("\t\t{");

                    sb.AppendLine("\t\t\tthis.OnBeforePropertyChange(\"" + docAttribute.Name + "\");");
                    sb.AppendLine("\t\t\tthis._" + docAttribute.Name + " = value;");
                    sb.AppendLine("\t\t\tthis.OnAfterPropertyChange(\"" + docAttribute.Name + "\");");

                    sb.AppendLine("\t\t}");
                }

                sb.AppendLine("\t}");
            }
#endif

#if false // make an option...
            // serialization
            writer.WriteLine();
            writer.WriteLine("\t\tprivate void GetObjectData(SerializationInfo info, StreamingContext context)");
            writer.WriteLine("\t\t{");
            foreach (DocAttribute docAttribute in docEntity.Attributes)
            {
                if (docAttribute.Inverse == null && docAttribute.Derived == null)
                {
                    writer.WriteLine("\t\t\tinfo.AddValue(\"" + docAttribute.Name + "\", this._" + docAttribute.Name + ");");
                }
            }
            writer.WriteLine("\t\t}");

            writer.WriteLine();
            writer.WriteLine("\t\tprivate void SetObjectData(SerializationInfo info, StreamingContext context)");
            writer.WriteLine("\t\t{");
            foreach (DocAttribute docAttribute in docEntity.Attributes)
            {
                if (docAttribute.Inverse == null && docAttribute.Derived == null)
                {
                    string method = "GetValue";
                    writer.WriteLine("\t\t\tthis._" + docAttribute.Name + " = info." + method + "(\"" + docAttribute.Name + "\");");
                }
            }
            writer.WriteLine("\t\t}");
#endif

            sb.AppendLine("}");
            return sb.ToString();
        }

        public string FormatEnumeration(DocEnumeration docEnumeration, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public enum " + docEnumeration.Name);
            sb.AppendLine("{");
            int counter = 0;
            foreach (DocConstant docConstant in docEnumeration.Constants)
            {
                int val;

                if (docConstant.Name.Equals("NOTDEFINED"))
                {
                    val = 0;
                }
                else if (docConstant.Name.Equals("USERDEFINED"))
                {
                    val = -1;
                }
                else
                {
                    counter++;
                    val = counter;
                }

                sb.AppendLine("\t" + docConstant.Name + " = " + val + ",");
            }
            sb.Append("}");
            return sb.ToString();
        }

        public string FormatSelect(DocSelect docSelect, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public interface " + docSelect.Name);
                
            BuildSelectEntries(sb, docSelect, map, included, false);

            sb.AppendLine();
            sb.AppendLine("{"); 
            sb.AppendLine("}");
        
            return sb.ToString();
        }

        public string FormatDefined(DocDefined docDefined, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("public struct " + docDefined.Name);

            // implement any selects
            BuildSelectEntries(sb, docDefined, map, included, false);

            sb.AppendLine();
            sb.AppendLine("{");
            sb.AppendLine("\t" + docDefined.DefinedType + " Value;");
            sb.AppendLine("}");

            return sb.ToString();
        }

        public string FormatDefinitions(DocProject docProject, DocPublication docPublication, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DocSection docSection in docProject.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocType docType in docSchema.Types)
                    {
                        bool use = true;
                        if (included != null)
                        {
                            use = false;
                            included.TryGetValue(docType, out use);
                        }
                        if (use)
                        {
                            if (docType is DocDefined)
                            {
                                DocDefined docDefined = (DocDefined)docType;
                                string text = this.Indent(this.FormatDefined(docDefined, map, included), 1);
                                sb.AppendLine(text);
                            }
                            else if (docType is DocSelect)
                            {
                                DocSelect docSelect = (DocSelect)docType;
                                string text = this.Indent(this.FormatSelect(docSelect, map, included), 1);
                                sb.AppendLine(text);
                            }
                            else if (docType is DocEnumeration)
                            {
                                DocEnumeration docEnumeration = (DocEnumeration)docType;
                                string text = this.Indent(this.FormatEnumeration(docEnumeration, map, included), 1);
                                sb.AppendLine(text);
                            }
                        }
                    }

                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        bool use = true;
                        if(included != null)
                        {
                            use = false;
                            included.TryGetValue(docEntity, out use);
                        }
                        if (use)
                        {
                            string text = this.Indent(this.FormatEntity(docEntity, map, included), 1);
                            sb.AppendLine(text);
                        }
                    }
                }

            }

            return sb.ToString();
        }

        public string FormatData(DocPublication docPublication, DocExchangeDefinition docExchange, Dictionary<string, DocObject> map, Dictionary<long, SEntity> instances)
        {
            //...???
            return null;
        }
    }
}

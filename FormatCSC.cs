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

        /// <summary>
        /// Generates folder of definitions
        /// </summary>
        /// <param name="path"></param>
        public static void GenerateCode(DocProject project, string path)
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
                            format.Save();
                        }
                    }

                    foreach (DocEntity docType in docSchema.Entities)
                    {
                        using (FormatCSC format = new FormatCSC(path + @"\" + docSchema.Name + @"\" + docType.Name + ".cs"))
                        {
                            format.Instance = project;
                            format.Definition = docType;
                            format.Save();
                        }
                    }
                }
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

        public void Save()
        {
            string dirpath = System.IO.Path.GetDirectoryName(this.m_filename);
            if (!System.IO.Directory.Exists(this.m_filename))
            {
                System.IO.Directory.CreateDirectory(dirpath);
            }

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(this.m_filename))
            {
                writer.WriteLine("// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.");
                writer.WriteLine("// IFC content is copyright (C) 1996-2013 BuildingSMART International Ltd.");
                writer.WriteLine();

                writer.WriteLine("using System;");
                writer.WriteLine();

                if (this.m_definition != null)
                {
                    writer.WriteLine("namespace BuildingSmart.IFC");
                    writer.WriteLine("{");
                    
                    if (this.m_definition is DocDefined)
                    {
                        DocDefined docDefined = (DocDefined)this.m_definition;
                        string text = this.Indent(this.FormatDefined(docDefined), 1);
                        writer.WriteLine(text);
                    }
                    else if (this.m_definition is DocSelect)
                    {
                        DocSelect docSelect = (DocSelect)this.m_definition;
                        string text = this.Indent(this.FormatSelect(docSelect), 1);
                        writer.WriteLine(text);
                    }
                    else if (this.m_definition is DocEnumeration)
                    {
                        DocEnumeration docEnumeration = (DocEnumeration)this.m_definition;
                        string text = this.Indent(this.FormatEnumeration(docEnumeration), 1);
                        writer.WriteLine(text);
                    }
                    else if (this.m_definition is DocEntity)
                    {
                        DocEntity docEntity = (DocEntity)this.m_definition;
                        string text = this.Indent(this.FormatEntity(docEntity, null, null), 1);
                        writer.WriteLine(docEntity);
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
                                writer.WriteLine("    /// " + docPset.Documentation.Replace('\r', ' ').Replace('\n', ' '));
                                writer.WriteLine("    /// </summary>");

                                writer.WriteLine("    public class " + docPset.Name + " : Pset");
                                writer.WriteLine("    {");

                                foreach (DocProperty docProperty in docPset.Properties)
                                {
                                    writer.WriteLine("        /// <summary>");
                                    writer.WriteLine("        /// " + docProperty.Documentation.Replace('\r', ' ').Replace('\n', ' '));
                                    writer.WriteLine("        /// </summary>");

                                    switch (docProperty.PropertyType)
                                    {
                                        case DocPropertyTemplateTypeEnum.P_SINGLEVALUE:
                                            writer.WriteLine("        public " + docProperty.PrimaryDataType + " " + docProperty.Name + " { get { return this.GetValue<" + docProperty.PrimaryDataType + ">(\"" + docProperty.Name + "\"); } set { this.SetValue<" + docProperty.PrimaryDataType + ">(\"" + docProperty.Name + "\", value); } }");
                                            break;

                                        case DocPropertyTemplateTypeEnum.P_ENUMERATEDVALUE:
                                            // record enum for later
                                            {
                                                string[] parts = docProperty.SecondaryDataType.Split(':');
                                                if (parts.Length == 2)
                                                {
                                                    string typename = parts[0];
                                                    if (!mapEnums.ContainsKey(typename))
                                                    {
                                                        string[] enums = parts[1].Split(',');
                                                        mapEnums.Add(typename, enums);

                                                        writer.WriteLine("        public " + typename + " " + docProperty.Name + " { get { return this.GetValue<" + typename + ">(\"" + docProperty.Name + "\"); } set { this.SetValue<" + typename + ">(\"" + docProperty.Name + "\", value); } }");
                                                    }
                                                }
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
                        }
                    }

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
                }
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

        public string FormatEntity(DocEntity docEntity, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();

            string basedef = docEntity.BaseDefinition;
            if (String.IsNullOrEmpty(basedef))
            {
                basedef = "IfcBase";
            }

            sb.Append("public partial ");
            if(docEntity.IsAbstract())
            {
                sb.Append("abstract ");
            }
            sb.AppendLine("class " + docEntity.Name + " : " + basedef);
            sb.AppendLine("{");

            // fields
            int order = 0;
            foreach (DocAttribute docAttribute in docEntity.Attributes)
            {
                bool inscope = false;
                
                included.TryGetValue(docAttribute, out inscope);

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
                    map.TryGetValue(docAttribute.DefinedType, out docRef);

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

        public string FormatEnumeration(DocEnumeration docEnumeration)
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

        public string FormatSelect(DocSelect docSelect)
        {
            return 
                "public interface " + docSelect.Name + "\r\n" +
                "{\r\n"+ 
                "}";
        }

        public string FormatDefined(DocDefined docDefined)
        {
            return 
                "public struct " + docDefined.Name + "\r\n" + 
                "{\r\n" +
                "\t" + docDefined.DefinedType + " Value;\r\n" +
                "}";
        }

        public string FormatDefinitions(DocProject docProject, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DocSection docSection in docProject.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocType docType in docSchema.Types)
                    {
                        bool use = false;
                        included.TryGetValue(docType, out use);
                        if (use)
                        {
                            if (docType is DocDefined)
                            {
                                DocDefined docDefined = (DocDefined)docType;
                                string text = this.Indent(this.FormatDefined(docDefined), 1);
                                sb.AppendLine(text);
                            }
                            else if (docType is DocSelect)
                            {
                                DocSelect docSelect = (DocSelect)docType;
                                string text = this.Indent(this.FormatSelect(docSelect), 1);
                                sb.AppendLine(text);
                            }
                            else if (docType is DocEnumeration)
                            {
                                DocEnumeration docEnumeration = (DocEnumeration)docType;
                                string text = this.Indent(this.FormatEnumeration(docEnumeration), 1);
                                sb.AppendLine(text);
                            }
                        }
                    }

                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        bool use = false;
                        included.TryGetValue(docEntity, out use);
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

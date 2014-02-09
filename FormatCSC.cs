// Name:        FormatCSC.cs
// Description: C# Code Generator
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2012 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.Text;

using IfcDoc.Schema.DOC;

namespace IfcDoc.Format.CSC
{
    internal class FormatCSC : IDisposable
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

                        writer.WriteLine("\tpublic struct " + this.m_definition.Name);
                        writer.WriteLine("\t{");
                        writer.WriteLine("\t\t" + docDefined.DefinedType + " Value;"); 
                        writer.WriteLine("\t}");
                    }
                    else if (this.m_definition is DocSelect)
                    {
                        writer.WriteLine("\tpublic interface " + this.m_definition.Name);
                        writer.WriteLine("\t{");
                        writer.WriteLine("\t}");
                    }
                    else if (this.m_definition is DocEnumeration)
                    {
                        DocEnumeration docEnumumeration = (DocEnumeration)this.m_definition;

                        writer.WriteLine("\tpublic enum " + this.m_definition.Name);
                        writer.WriteLine("\t{");
                        int counter = 0;
                        foreach (DocConstant docConstant in docEnumumeration.Constants)
                        {
                            counter++;
                            int val = counter;

                            if (docConstant.Name.Equals("NOTDEFINED"))
                            {
                                val = 0;
                            }
                            else if (docConstant.Name.Equals("USERDEFINED"))
                            {
                                val = -1;
                            }

                            writer.WriteLine("\t\t" + docConstant.Name + " = " + val + ",");
                        }
                        writer.WriteLine("\t}");
                    }
                    else if (this.m_definition is DocEntity)
                    {
                        DocEntity docEntity = (DocEntity)this.m_definition;

                        string basedef = docEntity.BaseDefinition;
                        if (String.IsNullOrEmpty(basedef))
                        {
                            basedef = "IfcBase";
                        }

                        writer.WriteLine("\tpublic partial class " + this.m_definition.Name + " : " + basedef);
                        writer.WriteLine("\t{");

                        // fields
                        foreach (DocAttribute docAttribute in docEntity.Attributes)
                        {
                            switch (docAttribute.GetAggregation())
                            {
                                case DocAggregationEnum.SET:
                                    writer.WriteLine("\t\tprivate ICollection<" + docAttribute.DefinedType + "> _" + docAttribute.Name + ";");
                                    break;

                                case DocAggregationEnum.LIST:
                                    writer.WriteLine("\t\tprivate IList<" + docAttribute.DefinedType + "> _" + docAttribute.Name + ";");
                                    break;

                                default:
                                    writer.WriteLine("\t\tprivate " + docAttribute.DefinedType + " _" + docAttribute.Name + ";");
                                    break;
                            }
                        }

                        // constructor
                        writer.WriteLine();
                        writer.WriteLine("\t\tpublic " + docEntity.Name + "()");
                        writer.WriteLine("\t\t{");
                        //... values...
                        writer.WriteLine("\t\t}");

                        // properties
                        foreach (DocAttribute docAttribute in docEntity.Attributes)
                        {
                            writer.WriteLine();

                            switch(docAttribute.GetAggregation())
                            {
                                case DocAggregationEnum.SET:
                                    writer.WriteLine("\t\tpublic ICollection<" + docAttribute.DefinedType + "> " + docAttribute.Name);
                                    break;

                                case DocAggregationEnum.LIST:
                                    writer.WriteLine("\t\tpublic IList<" + docAttribute.DefinedType + "> " + docAttribute.Name);
                                    break;

                                default:
                                    writer.WriteLine("\t\tpublic " + docAttribute.DefinedType + " " + docAttribute.Name);
                                    break;
                            }
                            writer.WriteLine("\t\t{");

                            writer.WriteLine("\t\t\tget");
                            writer.WriteLine("\t\t\t{");
                            writer.WriteLine("\t\t\t\treturn this._" + docAttribute.Name + ";");
                            writer.WriteLine("\t\t\t}");

                            if (docAttribute.GetAggregation() == DocAggregationEnum.NONE)
                            {
                                writer.WriteLine("\t\t\tset");
                                writer.WriteLine("\t\t\t{");

                                writer.WriteLine("\t\t\t\tthis.OnBeforePropertyChange(\"" + docAttribute.Name + "\");");
                                writer.WriteLine("\t\t\t\tthis._" + docAttribute.Name + " = value;");
                                writer.WriteLine("\t\t\t\tthis.OnAfterPropertyChange(\"" + docAttribute.Name + "\");");

                                writer.WriteLine("\t\t\t}");
                            }

                            writer.WriteLine("\t\t}");
                        }

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

                        writer.WriteLine("\t}");
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
    }
}

// Name:        FormatCSC.cs
// Description: C# Code Generator
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2012 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

        private static void WriteResource(System.IO.StreamWriter writer, string resourcename)
        {
            using (System.IO.Stream stm = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream(resourcename))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stm))
                {
                    string block = reader.ReadToEnd();
                    writer.Write(block);
                }
            }
        }

        /// <summary>
        /// Returns the native .NET type to use for a given EXPRESS type.
        /// </summary>
        /// <param name="expresstype"></param>
        /// <returns></returns>
        private static Type GetNativeType(string expresstype)
        {
            switch(expresstype)
            {
                case "STRING":
                    return typeof(string);

                case "INTEGER":
                    return typeof(long);

                case "REAL":
                    return typeof(double);

                case "NUMBER":
                    return typeof(decimal);

                case "LOGICAL":
                    return typeof(bool?);

                case "BOOLEAN":
                    return typeof(bool);

                case "BINARY":
                    return typeof(byte[]);
            }

            return null;
        }

        /// <summary>
        /// Converts any native types into .NET types
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        private static string FormatIdentifier(string identifier)
        {
            Type typeNative = GetNativeType(identifier);
            if (typeNative != null)
            {
                if (typeNative.IsGenericType && typeNative.GetGenericTypeDefinition() == typeof(Nullable<>)) 
                {
                    return typeNative.GetGenericArguments()[0].Name + "?";
                }
                
                return typeNative.Name;
            }

            return identifier;
        }

        /// <summary>
        /// Generates folder of definitions
        /// </summary>
        /// <param name="path"></param>
        public static void GenerateCode(DocProject project, string path, Dictionary<string, DocObject> map)
        {
            using (StreamWriter writerProj = new StreamWriter(path + @"\ifc.csproj", false))
            {
                WriteResource(writerProj, "IfcDoc.csproj1.txt");
                foreach (DocSection docSection in project.Sections)
                {
                    foreach (DocSchema docSchema in docSection.Schemas)
                    {
                        foreach (DocType docType in docSchema.Types)
                        {
                            string file = docSchema.Name + @"\" + docType.Name + ".cs";
                            using (FormatCSC format = new FormatCSC(path + @"\" + file))
                            {
                                format.Instance = project;
                                format.Definition = docType;
                                format.Map = map;
                                format.Save();

                                writerProj.WriteLine("    <Compile Include=\"" + file + "\" />");
                            }
                        }

                        foreach (DocEntity docType in docSchema.Entities)
                        {
                            string file = docSchema.Name + @"\" + docType.Name + ".cs";
                            using (FormatCSC format = new FormatCSC(path + @"\" + file))
                            {
                                format.Instance = project;
                                format.Definition = docType;
                                format.Map = map;
                                format.Save();

                                writerProj.WriteLine("    <Compile Include=\"" + file + "\" />");
                            }
                        }
                    }
                }

                // save properties
                using (FormatCSC format = new FormatCSC(path + @"\pset.cs"))
                {
                    format.Instance = project;
                    format.Map = map;
                    format.Save();
                }

                WriteResource(writerProj, "IfcDoc.csproj2.txt");
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
                writer.WriteLine("using System.ComponentModel.DataAnnotations.Schema;");
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

            sb.Append("public ");
            if(docEntity.IsAbstract())
            {
                sb.Append("abstract ");
            }
            sb.Append("partial class " + docEntity.Name);

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

            sb.AppendLine();
            //sb.AppendLine("// Schema properties");
            //sb.AppendLine();

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
                    // System.Runtime.Serialization -- used by Windows Communication Foundation formatters to indicate data serialization inclusion and order
                    sb.AppendLine("\t[DataMember(Order=" + order + ")] ");
                    order++;
                }
                else if(inscope)
                {
                    // System.ComponentModel.DataAnnotations for capturing inverse properties -- EntityFramework navigation properties
                    sb.AppendLine("\t[InverseProperty(\"" + docAttribute.Inverse + "\")] ");
                }

                // documentation -- need to escape content...
                ////sb.AppendLine("\t[Description(\"" + docAttribute.Documentation + "\")]");

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
                            sb.AppendLine("\tpublic ISet<" + FormatIdentifier(docAttribute.DefinedType) + "> " + docAttribute.Name + " {get; set;}");
                            break;

                        case DocAggregationEnum.LIST:
                            sb.AppendLine("\tpublic IList<" + FormatIdentifier(docAttribute.DefinedType) + "> " + docAttribute.Name + " {get; set;}");
                            break;

                        default:
                            sb.AppendLine("\tpublic " + FormatIdentifier(docAttribute.DefinedType) + optional + " " + docAttribute.Name + " {get; set;}");
                            break;
                    }
                }

                sb.AppendLine();
            }

           // sb.AppendLine();

            //sb.AppendLine("// Exchange properties");

            // then, model views within scope
            foreach(DocModelView docView in this.m_project.ModelViews)
            {
                if (included == null || included.ContainsKey(docView)) // todo: make option when generating to indicate which views...
                {
                    foreach(DocConceptRoot docRoot in docView.ConceptRoots)
                    {
                        if (docRoot.ApplicableEntity == docEntity)
                        {
                            foreach(DocTemplateUsage docConcept in docRoot.Concepts)
                            {
                                // sub-templates: traverse through

                                if (docConcept.Items.Count > 0)
                                {
                                    string template = docConcept.Definition.Name.Replace(" ", "_");

                                    // no sub-templates: use direct (e.g. ports)
                                    foreach (DocTemplateItem docItem in docConcept.Items)
                                    {
                                        string name = docItem.GetParameterValue("Name");

                                        if (docItem.Concepts.Count > 0)
                                        {
                                            // drill into each concept
                                            foreach (DocTemplateUsage docInner in docItem.Concepts)
                                            {
                                                foreach (DocTemplateItem docInnerItem in docInner.Items)
                                                {
                                                    string attr = docInnerItem.GetParameterValue("PropertyName"); // temphack
                                                    string type = docInnerItem.GetParameterValue("Value");

                                                    if (attr != null && type != null && attr.Length > 1)
                                                    {
                                                        sb.AppendLine("\tpublic " + type + " " + attr);
                                                        sb.AppendLine("\t{");
                                                        sb.AppendLine("\t\tget");
                                                        sb.AppendLine("\t\t{");
                                                        sb.AppendLine("\t\t\treturn Template." + template + ".GetValue(this, \"" + name + "\", \"" + attr + "\") as " + type + ";");
                                                        sb.AppendLine("\t\t}");
                                                        sb.AppendLine("\t\tset");
                                                        sb.AppendLine("\t\t{");
                                                        sb.AppendLine("\t\t\tTemplate." + template + ".SetValue(this, \"" + name +"\", \"" + attr + "\", value);");
                                                        sb.AppendLine("\t\t}");
                                                        sb.AppendLine("\t}"); 
                                                        sb.AppendLine();
                                                    }

                                                }
                                                
                                            }
                                        }
                                        else
                                        {
                                            string type = docItem.GetParameterValue("Value");
                                            if (type == null)
                                            {
                                                // find type according to template
                                                //docConcept.Definition.
                                            }

                                            if (name != null && type != null)
                                            {
                                                sb.AppendLine("\tpublic " + type + " " + name);
                                                sb.AppendLine("\t{");
                                                sb.AppendLine("\t\tget");
                                                sb.AppendLine("\t\t{");
                                                sb.AppendLine("\t\t\treturn Template." + template + ".GetValue(this, \"" + name + "\") as " + type + ";");
                                                sb.AppendLine("\t\t}");
                                                sb.AppendLine("\t\tset");
                                                sb.AppendLine("\t\t{");
                                                sb.AppendLine("\t\t\tTemplate." + template + ".SetValue(this, \"" + name + "\", value);");
                                                sb.AppendLine("\t\t}");
                                                sb.AppendLine("\t}"); 
                                                sb.AppendLine();
                                            }
                                        }
                                    }
                                }
                            }
                        }
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
            sb.AppendLine("\t" + FormatIdentifier(docDefined.DefinedType) + " Value;");
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

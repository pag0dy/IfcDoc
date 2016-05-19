// Name:        FormatSQL.cs
// Description: Generates schema definitions and sample data in tabular formats according to SQL and comma delimited text.
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2016 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    class FormatSQL : 
        IFormatExtension,
        IFormatData
    {
        private void BuildFields(StringBuilder sb, DocEntity docEntity, Dictionary<string, DocObject> map)
        {
#if true //... make configurable... -- for now all classes are mapped as separate tables, where lookup must join each
            // super
            DocObject docSuper = null;
            if(docEntity.BaseDefinition != null && map.TryGetValue(docEntity.BaseDefinition, out docSuper) && docSuper is DocEntity)
            {
                BuildFields(sb, (DocEntity)docSuper, map);
            }
#endif
            foreach (DocAttribute docAttr in docEntity.Attributes)
            {
                if (docAttr.GetAggregation() == DocAggregationEnum.NONE && docAttr.Inverse == null) // don't deal with lists -- separate tables
                {
                    sb.Append(", ");
                    sb.AppendLine();

                    sb.Append("\t");
                    sb.Append(docAttr.Name);
                    sb.Append(" ");

                    DocObject docRef = null;

                    if (docAttr.DefinedType == null || !map.TryGetValue(docAttr.DefinedType, out docRef) || docRef is DocDefined)
                    {
                        string deftype = docAttr.DefinedType;
                        if(docRef is DocDefined)
                        {
                            DocDefined docDef = (DocDefined)docRef;
                            deftype = docDef.DefinedType;
                        }
                        switch (deftype)
                        {
                            case "BOOLEAN":
                                sb.Append(" BIT");
                                break;

                            case "INTEGER":
                                sb.Append(" INTEGER");
                                break;

                            case "REAL":
                                sb.Append(" FLOAT");
                                break;

                            case "BINARY":
                                sb.Append(" TEXT");
                                break;

                            case "STRING":
                            default:
                                sb.Append(" TEXT");
                                break;
                        }
                    }
                    else if (docRef is DocEntity) //... docselect...
                    {
                        // if non-rooted, then embed as XML...

                        sb.Append(" INTEGER"); // oid
                    }
                    else if (docRef is DocSelect)
                    {
                        sb.Append(" INTEGER"); // oid... and type...
                    }
                    else if (docRef is DocEnumeration)
                    {
                        sb.Append(" VARCHAR");
                    }
                }
            }

        }

        public string FormatEntity(DocEntity docEntity, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE ");
            sb.Append(docEntity.Name);
            sb.Append(" (oid INTEGER");

            BuildFields(sb, docEntity, map);

            sb.Append(");");
            sb.AppendLine();

            foreach (DocAttribute docAttr in docEntity.Attributes)
            {
                if (docAttr.GetAggregation() != DocAggregationEnum.NONE && docAttr.Inverse == null)
                {
                    sb.AppendLine();
                    sb.Append("CREATE TABLE ");
                    sb.Append(docEntity.Name);
                    sb.Append("_");
                    sb.Append(docAttr.Name);
                    sb.Append(" (source INTEGER, sequence INTEGER, target INTEGER);");
                }
            }

            return sb.ToString();
        }

        public string FormatEnumeration(DocEnumeration docEnumeration)
        {
            return null; // nothing to define
        }

        public string FormatSelect(DocSelect docSelect, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            return null; // nothing to define
        }

        public string FormatDefined(DocDefined docDefined)
        {
            return null; // nothing to define
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
                                string text = this.FormatDefined(docDefined);
                                sb.AppendLine(text);
                            }
                            else if (docType is DocSelect)
                            {
                                DocSelect docSelect = (DocSelect)docType;
                                string text = this.FormatSelect(docSelect, null, null);
                                sb.AppendLine(text);
                            }
                            else if (docType is DocEnumeration)
                            {
                                DocEnumeration docEnumeration = (DocEnumeration)docType;
                                string text = this.FormatEnumeration(docEnumeration);
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
                            string text = this.FormatEntity(docEntity, map, included);
                            sb.AppendLine(text);
                        }
                    }
                }

            }

            return sb.ToString();
        }

        public string FormatData(DocPublication docPublication, DocExchangeDefinition docExchange, Dictionary<string, DocObject> map, Dictionary<long, SEntity> instances, SEntity root, bool markup)
        {
            //Guid guidMapping = Guid.Parse("");//...

            StringBuilder sb = new StringBuilder();

            foreach (DocModelView docView in docPublication.Views)
            {
                foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                {
                    // look for specific concept root dealing with mappings
                    foreach (DocTemplateUsage docConcept in docRoot.Concepts)
                    {
                        if (docConcept.Definition != null && docConcept.Definition.Name.Equals("External Data Constraints") && docConcept.Items.Count > 0)//...
                        {
                            bool included = true;

                            if (docExchange != null)
                            {
                                included = false;
                                // if exhcnage specified, check for inclusion
                                foreach (DocExchangeItem docExchangeItem in docConcept.Exchanges)
                                {
                                    if (docExchangeItem.Exchange == docExchange && docExchangeItem.Requirement == DocExchangeRequirementEnum.Mandatory)
                                    {
                                        included = true;
                                        break;
                                    }
                                }
                            }

                            if (included)
                            {
                                string table = docConcept.Items[0].GetParameterValue("Table");
                                string query = docConcept.Items[0].GetParameterValue("Reference");

                                //if (query == null)
                                //{
                                //    query = String.Empty;
                                //}
                                
                                //int cap = query.IndexOf('.');
                                //string typename = query.Substring(0, cap);

                                // find corresponding type?
                                //instance.GetType().Assembly.GetType(typename);

                                // query all data of given type
                                //...

                                sb.AppendLine("<h4>" + docConcept.Name + "</h4>");
                                sb.AppendLine("<table class=\"gridtable\">");

                                // generate header row
                                sb.AppendLine("<tr>");
                                foreach (DocTemplateItem docItem in docConcept.Items)
                                {
                                    string name = docItem.GetParameterValue("Name");
                                    string color = docItem.GetParameterValue("Color");
                                    //... use color...

                                    sb.Append("<th>");
                                    sb.Append(name);
                                    sb.Append("</th>");
                                };
                                sb.AppendLine("</tr>");

                                // generate data rows
                                foreach (SEntity e in instances.Values)
                                {
                                    string eachname = e.GetType().Name;
                                    if (docRoot.ApplicableEntity.IsInstanceOfType(e))
                                    {
                                        sb.Append("<tr>");
                                        foreach (DocTemplateItem docItem in docConcept.Items)
                                        {
                                            sb.Append("<td>");

                                            string expr = docItem.GetParameterValue("Reference");
                                            CvtValuePath valpath = CvtValuePath.Parse(expr, map); //todo: move out of loop
                                            if (valpath != null)
                                            {
                                                object value = valpath.GetValue(e, null);

                                                if (value == e)
                                                {
                                                    value = e.GetType().Name;
                                                }
                                                else if (value is SEntity)
                                                {
                                                    // use name
                                                    FieldInfo fieldValue = value.GetType().GetField("Name");
                                                    if (fieldValue != null)
                                                    {
                                                        value = fieldValue.GetValue(value);
                                                    }
                                                }
                                                else if (value is System.Collections.IList)
                                                {
                                                    System.Collections.IList list = (System.Collections.IList)value;
                                                    StringBuilder sbList = new StringBuilder();
                                                    foreach(object elem in list)
                                                    {
                                                        FieldInfo fieldName = elem.GetType().GetField("Name");
                                                        if(fieldName != null)
                                                        {
                                                            object elemname = fieldName.GetValue(elem);
                                                            if(elemname != null)
                                                            {
                                                                FieldInfo fieldValue = elemname.GetType().GetField("Value");
                                                                if (fieldValue != null)
                                                                {
                                                                    object elemval = fieldValue.GetValue(elemname);
                                                                    sbList.Append(elemval.ToString());
                                                                }
                                                            }
                                                        }
                                                        sbList.Append("; <br/>");
                                                    }
                                                    value = sbList.ToString();
                                                }
                                                else if (value is Type)
                                                {
                                                    value = ((Type)value).Name;
                                                }

                                                if (value != null)
                                                {
                                                    FieldInfo fieldValue = value.GetType().GetField("Value");
                                                    if (fieldValue != null)
                                                    {
                                                        value = fieldValue.GetValue(value);
                                                    }

                                                    if (value != null)
                                                    {
                                                        sb.Append(value.ToString()); // todo: html-encode
                                                    }
                                                }
                                                else
                                                {
                                                    sb.Append("&nbsp;");
                                                }
                                            }

                                            sb.Append("</td>");
                                        }
                                        sb.AppendLine("</tr>");
                                    }
                                }

                                sb.AppendLine("</table>");
                                sb.AppendLine("<br/>");
                            }
                        }
                    }
                }
            }

            return sb.ToString();
        }
    }
}

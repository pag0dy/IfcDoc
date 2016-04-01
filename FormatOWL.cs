using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public class FormatOWL
    {
        public FormatOWL()
        {        }

        public string FormatEntity(DocEntity docEntity, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            return null;
        }

        public static string FormatEnumeration(DocEnumeration docEnumeration)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\tifc:");
            sb.Append(docEnumeration.Name);
            sb.AppendLine();

            sb.Append("\t\trdf:type owl:Class ;");
            sb.AppendLine();

            //Add parent SELECT classes
            
            //possibly add the items in a oneof
            sb.Append("\t\towl:equivalentClass");
            sb.AppendLine();
            sb.Append("\t\t\t[");
            sb.AppendLine();
            sb.Append("\t\t\t\trdf:type owl:Class ;");
            sb.AppendLine();
            sb.Append("\t\t\t\towl:oneOf ");
            sb.AppendLine();
            sb.Append("\t\t\t\t\t( ");
            sb.AppendLine();

            foreach (DocConstant docConst in docEnumeration.Constants)
            {
                sb.Append("\t\t\t\t\tifc:");
                sb.Append(docConst.Name.ToUpper());
                sb.Append(" ");
                sb.AppendLine();
            }

            //close oneof
            sb.Append("\t\t\t\t\t) ");
            sb.AppendLine();
            sb.Append("\t\t\t] ; ");
            sb.AppendLine();


            sb.Append("\t\trdfs: subClassOf expr:ENUMERATION .");
            sb.AppendLine();

            return sb.ToString();
        }

        public static string FormatSelect(DocSelect docSelect, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\tifc:");
            sb.Append(docSelect.Name);
            sb.AppendLine();

            sb.Append("\t\trdf:type owl:Class ;");
            sb.AppendLine();

            //Add parent SELECT classes

            //possibly add the individuals here as a union
            sb.Append("\t\towl:equivalentClass");
            sb.AppendLine();
            sb.Append("\t\t\t[");
            sb.AppendLine();
            sb.Append("\t\t\t\trdf:type owl:Class ;");
            sb.AppendLine();
            sb.Append("\t\t\t\towl:unionOf ");
            sb.AppendLine();
            sb.Append("\t\t\t\t\t( ");
            sb.AppendLine();

            Queue<DocSelectItem> queue = new Queue<DocSelectItem>();
            foreach (DocSelectItem docItem in docSelect.Selects)
            {
                queue.Enqueue(docItem);
            }

            // sort selects alphabetically
            SortedList<string, DocSelectItem> sort = new SortedList<string, DocSelectItem>();
            while (queue.Count > 0)
            {
                DocSelectItem docItem = queue.Dequeue();

                DocObject mapDef = null;
                if (map.TryGetValue(docItem.Name, out mapDef))
                {
                    if (mapDef is DocSelect)
                    {
                        // expand each
                        DocSelect docSub = (DocSelect)mapDef;
                        foreach (DocSelectItem dsi in docSub.Selects)
                        {
                            queue.Enqueue(dsi);
                        }
                    }
                    else if ((included == null || included.ContainsKey(mapDef)) && !sort.ContainsKey(docItem.Name))
                    {
                        //TODO: if abstract entity, then go through subtypes...
                        sort.Add(docItem.Name, docItem);
                    }
                }
            }

            // resolve selects into final elements

            // entities
            foreach (DocSelectItem docItem in sort.Values)
            {
                DocObject mapDef = null;
                if (map.TryGetValue(docItem.Name, out mapDef))
                {
                    if (included == null || included.ContainsKey(mapDef))
                    {
                        sb.Append("\t\t\t\t\t\tifc:");
                        sb.Append(docItem.Name + " ");
                        sb.AppendLine();
                    }
                }
            }

            //close unionof
            sb.Append("\t\t\t\t\t) ");
            sb.AppendLine();
            sb.Append("\t\t\t] ; ");
            sb.AppendLine();


            sb.Append("\t\trdfs: subClassOf expr:SELECT .");
            sb.AppendLine();

            return sb.ToString();
        }

        public static string ToXsdType(string typename)
        {
            string defined = "ifc:" + typename;
            switch (typename)
            {
                case "BOOLEAN":
                    defined = "xs:boolean";
                    break;

                case "LOGICAL":
                    defined = "ifc:logical";
                    break;

                case "INTEGER":
                    defined = "xs:long";
                    break;

                case "STRING":
                    defined = "xs:normalizedString";
                    break;

                case "REAL":
                case "NUMBER":
                    defined = "xs:double";
                    break;

                case "BINARY":
                case "BINARY (32)":
                    defined = "ifc:hexBinary";
                    break;
            }

            return defined;
        }

        public string FormatDefined(DocDefined docDefined)
        {
            string defined = ToXsdType(docDefined.DefinedType);

            StringBuilder sb = new StringBuilder();

            if (docDefined.Aggregation != null)
            {
                string aggtype = docDefined.Aggregation.GetAggregation().ToString().ToLower();

                if (docDefined.Aggregation.GetAggregation() == DocAggregationEnum.SET)
                {
                    sb.Append("\t<xs:complexType name=\"");
                    sb.Append(docDefined.Name);
                    sb.Append("\">");
                    sb.AppendLine();

                    sb.AppendLine("\t\t<xs:sequence>");
                    sb.Append("\t\t\t<xs:element ref=\"");
                    sb.Append(defined);
                    sb.AppendLine("\" maxOccurs=\"unbounded\"/>");
                    sb.AppendLine("\t\t</xs:sequence>");

                    sb.Append("\t\t<xs:attribute ref=\"ifc:itemType\" fixed=\"");
                    sb.Append(defined);
                    sb.AppendLine("\"/>");

                    sb.Append("\t\t<xs:attribute ref=\"ifc:cType\" fixed=\"");
                    sb.Append(aggtype);
                    sb.AppendLine("\"/>");

                    sb.Append("\t\t<xs:attribute ref=\"ifc:arraySize\" use=\"");
                    sb.Append("optional");
                    sb.AppendLine("\"/>");

                    sb.Append("\t</xs:complexType>");
                    sb.AppendLine();
                }
                else
                {

                    sb.Append("\t<xs:complexType name=\"");
                    sb.Append(docDefined.Name);
                    sb.Append("\">");
                    sb.AppendLine();

                    sb.AppendLine("\t\t<xs:simpleContent>");
                    sb.Append("\t\t\t<xs:extension base=\"ifc:List-");
                    sb.Append(docDefined.Name);
                    sb.AppendLine("\">");

                    sb.Append("\t\t\t\t<xs:attribute ref=\"ifc:itemType\" fixed=\"");
                    sb.Append(defined);
                    sb.AppendLine("\"/>");

                    sb.Append("\t\t\t\t<xs:attribute ref=\"ifc:cType\" fixed=\"");
                    sb.Append(aggtype);
                    sb.AppendLine("\"/>");

                    sb.Append("\t\t\t\t<xs:attribute ref=\"ifc:arraySize\" use=\"");
                    sb.Append("optional");
                    sb.AppendLine("\"/>");

                    sb.AppendLine("\t\t\t</xs:extension>");
                    sb.AppendLine("\t\t</xs:simpleContent>");

                    sb.Append("\t</xs:complexType>");
                    sb.AppendLine();

                    // simple type
                    sb.Append("\t<xs:simpleType name=\"List-");
                    sb.Append(docDefined.Name);
                    sb.Append("\">");
                    sb.AppendLine();

                    sb.AppendLine("\t\t<xs:restriction>");
                    sb.AppendLine("\t\t\t<xs:simpleType>");
                    sb.Append("\t\t\t\t<xs:list itemType=\"");
                    sb.Append(defined);
                    sb.AppendLine("\"/>");
                    sb.AppendLine("\t\t\t</xs:simpleType>");

                    if (docDefined.Aggregation.GetAggregation() == DocAggregationEnum.ARRAY)
                    {
                        sb.Append("\t\t\t<xs:minLength value=\"");
                        sb.Append(docDefined.Aggregation.GetAggregationNestingUpper());
                        sb.AppendLine("\"/>");
                    }
                    else if (docDefined.Aggregation.AggregationLower != null)
                    {
                        sb.Append("\t\t\t<xs:minLength value=\"");
                        sb.Append(docDefined.Aggregation.GetAggregationNestingLower());
                        sb.AppendLine("\"/>");
                    }

                    if (docDefined.Aggregation.AggregationUpper != null)
                    {
                        sb.Append("\t\t\t<xs:maxLength value=\"");
                        sb.Append(docDefined.Aggregation.GetAggregationNestingUpper());
                        sb.AppendLine("\"/>");
                    }

                    sb.AppendLine("\t\t</xs:restriction>");

                    sb.Append("\t</xs:simpleType>");
                    sb.AppendLine();
                }
            }
            else if (docDefined.DefinedType.Equals("BINARY"))
            {
                sb.Append("\t<xs:complexType name=\"");
                sb.Append(docDefined.Name);
                sb.Append("\">");
                sb.AppendLine();

                sb.AppendLine("\t\t<xs:simpleContent>");

                sb.Append("\t\t\t<xs:extension base=\"");
                sb.Append(defined);
                sb.AppendLine("\">");

                sb.AppendLine("\t\t\t</xs:extension>");

                sb.AppendLine("\t\t</xs:simpleContent>");

                sb.Append("\t</xs:complexType>");
                sb.AppendLine();
            }
            else
            {
                sb.Append("\t<xs:simpleType name=\"");
                sb.Append(docDefined.Name);
                sb.Append("\">");
                sb.AppendLine();

                sb.Append("\t\t<xs:restriction base=\"");
                sb.Append(defined);

                if (docDefined.Length > 0)
                {
                    sb.Append("\">");
                    sb.AppendLine();

                    sb.Append("\t\t\t<xs:maxLength value=\"");
                    sb.Append(docDefined.Length);
                    sb.AppendLine("\"/>");

                    sb.AppendLine("\t\t</xs:restriction>");
                }
                else if (docDefined.Length < 0)
                {
                    // fixed
                    sb.Append("\">");
                    sb.AppendLine();

                    sb.Append("\t\t\t<xs:minLength value=\"");
                    sb.Append(-docDefined.Length);
                    sb.AppendLine("\"/>");

                    sb.Append("\t\t\t<xs:maxLength value=\"");
                    sb.Append(-docDefined.Length);
                    sb.AppendLine("\"/>");

                    sb.AppendLine("\t\t</xs:restriction>");
                }
                else if (docDefined.Aggregation != null)
                {
                    sb.Append("\">");
                    sb.AppendLine();

                    if (docDefined.Aggregation.AggregationLower != null)
                    {
                        sb.Append("\t\t\t<xs:minLength value=\"");
                        sb.Append(docDefined.Aggregation.GetAggregationNestingLower());
                        sb.AppendLine("\"/>");
                    }

                    if (docDefined.Aggregation.AggregationUpper != null)
                    {
                        sb.Append("\t\t\t<xs:maxLength value=\"");
                        sb.Append(docDefined.Aggregation.GetAggregationNestingUpper());
                        sb.AppendLine("\"/>");
                    }

                    sb.AppendLine("\t\t</xs:restriction>");
                }
                else
                {
                    sb.Append("\"/>");
                    sb.AppendLine();
                }

                sb.Append("\t</xs:simpleType>");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string FormatDefinitions(DocProject docProject, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            return null;
        }

        public string FormatData(DocPublication docPublication, DocExchangeDefinition docExchange, Dictionary<string, DocObject> map, Dictionary<long, SEntity> instances)
        {
            return null;
        }
    }
}

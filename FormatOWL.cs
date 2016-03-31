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

        public string FormatDefined(DocDefined docDefined)
        {
            return null;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public class FormatOWL : IFormatExtension
    {
        public FormatOWL()
        {        }

        public string FormatEntity(DocEntity docEntity, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {

           StringBuilder sb = new StringBuilder();

           sb.Append("ifc:");
           sb.Append(docEntity.Name);
           sb.Append("\t\trdf:type \towl:Class ;");
           sb.AppendLine();
           sb.Append("\trdfs:label  \t\"");
           sb.Append(docEntity.Name);
           sb.Append("\" .");
           sb.AppendLine();

           // TO DO: to be completed

           return sb.ToString();
        }

        public string FormatEnumeration(DocEnumeration docEnumeration)
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


            sb.Append("\t\trdfs:subClassOf expr:ENUMERATION .");
            sb.AppendLine();

            return sb.ToString();
        }

       // version for computer interpretable listing
        public string FormatEnumerationCompListing(DocEnumeration docEnumeration)
        {
           StringBuilder sb = new StringBuilder();

           sb.Append("ifc:");
           sb.Append(docEnumeration.Name);
           sb.AppendLine();

           sb.AppendLine("\trdf:type owl:Class ;");
           sb.AppendLine("\trdfs:subClassOf expr:ENUMERATION .");
           sb.AppendLine();

           // define individuals
           foreach (DocConstant docConst in docEnumeration.Constants)
           {
              sb.AppendLine("ifc:" + docConst.Name.ToUpper() + "\trdf:type\t" + "ifc:" + docEnumeration.Name + " , owl:NamedIndividual ;");
              sb.AppendLine("\trdfs:label  \"" + docConst.Name.ToUpper() + "\" .");
              sb.AppendLine();
           }

           return sb.ToString();
        }

        public string FormatSelect(DocSelect docSelect, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
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

            // entities
            foreach (DocSelectItem docItem in docSelect.Selects)
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


            sb.Append("\t\trdfs:subClassOf expr:SELECT .");
            sb.AppendLine();

            return sb.ToString();
        }

        // version for computer interpretable listing
        public string FormatSelectCompListing(DocSelect docSelect, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
           StringBuilder sb = new StringBuilder();

           sb.Append("ifc:");
           sb.Append(docSelect.Name);
           sb.Append("\trdf:type owl:Class ;");
           sb.AppendLine();
           sb.AppendLine("\trdfs:subClassOf expr:SELECT ;");
           sb.Append("\trdfs:label  \"");
           sb.Append(docSelect.Name);
           sb.Append("\" .");
           sb.AppendLine();


           // entities
           foreach (DocSelectItem docItem in docSelect.Selects)
           {
              DocObject mapDef = null;
              if (map.TryGetValue(docItem.Name, out mapDef))
              {
                 if (included == null || included.ContainsKey(mapDef))
                 {
                    sb.AppendLine("ifc:" + docItem.Name + "\trdfs:subClassOf ifc:" + docSelect.Name + " .");
                    sb.AppendLine();
                 }
              }
           }

           return sb.ToString();
        }

        public static string ToXsdType(string typename)
        {
           //// TO DO: to be revised (also xsd in place of xs)

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

           //// TO DO (code copied from XSD case)
            //if (docDefined.Aggregation != null)
            //{
            //    string aggtype = docDefined.Aggregation.GetAggregation().ToString().ToLower();

            //    if (docDefined.Aggregation.GetAggregation() == DocAggregationEnum.SET)
            //    {
            //        sb.Append("\t<xs:complexType name=\"");
            //        sb.Append(docDefined.Name);
            //        sb.Append("\">");
            //        sb.AppendLine();

            //        sb.AppendLine("\t\t<xs:sequence>");
            //        sb.Append("\t\t\t<xs:element ref=\"");
            //        sb.Append(defined);
            //        sb.AppendLine("\" maxOccurs=\"unbounded\"/>");
            //        sb.AppendLine("\t\t</xs:sequence>");

            //        sb.Append("\t\t<xs:attribute ref=\"ifc:itemType\" fixed=\"");
            //        sb.Append(defined);
            //        sb.AppendLine("\"/>");

            //        sb.Append("\t\t<xs:attribute ref=\"ifc:cType\" fixed=\"");
            //        sb.Append(aggtype);
            //        sb.AppendLine("\"/>");

            //        sb.Append("\t\t<xs:attribute ref=\"ifc:arraySize\" use=\"");
            //        sb.Append("optional");
            //        sb.AppendLine("\"/>");

            //        sb.Append("\t</xs:complexType>");
            //        sb.AppendLine();
            //    }
            //    else
            //    {

            //        sb.Append("\t<xs:complexType name=\"");
            //        sb.Append(docDefined.Name);
            //        sb.Append("\">");
            //        sb.AppendLine();

            //        sb.AppendLine("\t\t<xs:simpleContent>");
            //        sb.Append("\t\t\t<xs:extension base=\"ifc:List-");
            //        sb.Append(docDefined.Name);
            //        sb.AppendLine("\">");

            //        sb.Append("\t\t\t\t<xs:attribute ref=\"ifc:itemType\" fixed=\"");
            //        sb.Append(defined);
            //        sb.AppendLine("\"/>");

            //        sb.Append("\t\t\t\t<xs:attribute ref=\"ifc:cType\" fixed=\"");
            //        sb.Append(aggtype);
            //        sb.AppendLine("\"/>");

            //        sb.Append("\t\t\t\t<xs:attribute ref=\"ifc:arraySize\" use=\"");
            //        sb.Append("optional");
            //        sb.AppendLine("\"/>");

            //        sb.AppendLine("\t\t\t</xs:extension>");
            //        sb.AppendLine("\t\t</xs:simpleContent>");

            //        sb.Append("\t</xs:complexType>");
            //        sb.AppendLine();

            //        // simple type
            //        sb.Append("\t<xs:simpleType name=\"List-");
            //        sb.Append(docDefined.Name);
            //        sb.Append("\">");
            //        sb.AppendLine();

            //        sb.AppendLine("\t\t<xs:restriction>");
            //        sb.AppendLine("\t\t\t<xs:simpleType>");
            //        sb.Append("\t\t\t\t<xs:list itemType=\"");
            //        sb.Append(defined);
            //        sb.AppendLine("\"/>");
            //        sb.AppendLine("\t\t\t</xs:simpleType>");

            //        if (docDefined.Aggregation.GetAggregation() == DocAggregationEnum.ARRAY)
            //        {
            //            sb.Append("\t\t\t<xs:minLength value=\"");
            //            sb.Append(docDefined.Aggregation.GetAggregationNestingUpper());
            //            sb.AppendLine("\"/>");
            //        }
            //        else if (docDefined.Aggregation.AggregationLower != null)
            //        {
            //            sb.Append("\t\t\t<xs:minLength value=\"");
            //            sb.Append(docDefined.Aggregation.GetAggregationNestingLower());
            //            sb.AppendLine("\"/>");
            //        }

            //        if (docDefined.Aggregation.AggregationUpper != null)
            //        {
            //            sb.Append("\t\t\t<xs:maxLength value=\"");
            //            sb.Append(docDefined.Aggregation.GetAggregationNestingUpper());
            //            sb.AppendLine("\"/>");
            //        }

            //        sb.AppendLine("\t\t</xs:restriction>");

            //        sb.Append("\t</xs:simpleType>");
            //        sb.AppendLine();
            //    }
            //}
            //else if (docDefined.DefinedType.Equals("BINARY"))
            //{
            //    sb.Append("\t<xs:complexType name=\"");
            //    sb.Append(docDefined.Name);
            //    sb.Append("\">");
            //    sb.AppendLine();

            //    sb.AppendLine("\t\t<xs:simpleContent>");

            //    sb.Append("\t\t\t<xs:extension base=\"");
            //    sb.Append(defined);
            //    sb.AppendLine("\">");

            //    sb.AppendLine("\t\t\t</xs:extension>");

            //    sb.AppendLine("\t\t</xs:simpleContent>");

            //    sb.Append("\t</xs:complexType>");
            //    sb.AppendLine();
            //}
            //else
            //{
            //    sb.Append("\t<xs:simpleType name=\"");
            //    sb.Append(docDefined.Name);
            //    sb.Append("\">");
            //    sb.AppendLine();

            //    sb.Append("\t\t<xs:restriction base=\"");
            //    sb.Append(defined);

            //    if (docDefined.Length > 0)
            //    {
            //        sb.Append("\">");
            //        sb.AppendLine();

            //        sb.Append("\t\t\t<xs:maxLength value=\"");
            //        sb.Append(docDefined.Length);
            //        sb.AppendLine("\"/>");

            //        sb.AppendLine("\t\t</xs:restriction>");
            //    }
            //    else if (docDefined.Length < 0)
            //    {
            //        // fixed
            //        sb.Append("\">");
            //        sb.AppendLine();

            //        sb.Append("\t\t\t<xs:minLength value=\"");
            //        sb.Append(-docDefined.Length);
            //        sb.AppendLine("\"/>");

            //        sb.Append("\t\t\t<xs:maxLength value=\"");
            //        sb.Append(-docDefined.Length);
            //        sb.AppendLine("\"/>");

            //        sb.AppendLine("\t\t</xs:restriction>");
            //    }
            //    else if (docDefined.Aggregation != null)
            //    {
            //        sb.Append("\">");
            //        sb.AppendLine();

            //        if (docDefined.Aggregation.AggregationLower != null)
            //        {
            //            sb.Append("\t\t\t<xs:minLength value=\"");
            //            sb.Append(docDefined.Aggregation.GetAggregationNestingLower());
            //            sb.AppendLine("\"/>");
            //        }

            //        if (docDefined.Aggregation.AggregationUpper != null)
            //        {
            //            sb.Append("\t\t\t<xs:maxLength value=\"");
            //            sb.Append(docDefined.Aggregation.GetAggregationNestingUpper());
            //            sb.AppendLine("\"/>");
            //        }

            //        sb.AppendLine("\t\t</xs:restriction>");
            //    }
            //    else
            //    {
            //        sb.Append("\"/>");
            //        sb.AppendLine();
            //    }

            //    sb.Append("\t</xs:simpleType>");
            //    sb.AppendLine();
            //}

            return sb.ToString();
        }

        public string FormatDefinitions(DocProject docProject, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
           StringBuilder sb = new StringBuilder();

           string ifcversion = "IFC4";
           // TO DO: customize the IFC version. In case of XSD, the piece of information (the full URL) is read from the .ifcdoc file

           string ifcxmlns = "http://www.buildingsmart-tech.org/ifcOWL/" + ifcversion;
      
           // namespace definitions
           sb.AppendLine("@prefix :      <" + ifcxmlns + "#> .");
           sb.AppendLine("@prefix rdfs:  <http://www.w3.org/2000/01/rdf-schema#> .");
           sb.AppendLine("@prefix dce:   <http://purl.org/dc/elements/1.1/> .");
           sb.AppendLine("@prefix owl:   <http://www.w3.org/2002/07/owl#> .");
           sb.AppendLine("@prefix xsd:   <http://www.w3.org/2001/XMLSchema#> .");
           sb.AppendLine("@prefix rdf:   <http://www.w3.org/1999/02/22-rdf-syntax-ns#> .");
           sb.AppendLine("@prefix vann:  <http://purl.org/vocab/vann/> .");
           sb.AppendLine("@prefix list:  <https://w3id.org/list#> .");
           sb.AppendLine("@prefix expr:  <https://w3id.org/express#> .");
           sb.AppendLine("@prefix ifc:   <" + ifcxmlns + "#> .");
           sb.AppendLine("@prefix cc:    <http://creativecommons.org/ns#> .");
           sb.AppendLine("");
            
            // ontology definition
           sb.AppendLine("<" + ifcxmlns + ">");
           sb.AppendLine("\ta                              owl:Ontology ;");
           sb.AppendLine("\trdfs:comment                   \"Ontology automatically generated from the EXPRESS schema 'IFC4_ADD1' using the 'IFC-to-RDF' converter developed by Pieter Pauwels (pipauwel.pauwels@ugent.be), based on the earlier versions from Jyrki Oraskari (jyrki.oraskari@aalto.fi) and Davy Van Deursen (davy.vandeursen@ugent.be)\" ;");
           sb.AppendLine("\tcc:license                     <http://creativecommons.org/licenses/by/3.0/> ;");
           sb.AppendLine("\tdce:contributor                \"Aleksandra Sojic (aleksandra.sojic@itia.cnr.it)\" , \"Jakob Beetz (j.beetz@tue.nl)\" , \"Maria Poveda Villalon (mpoveda@fi.upm.es)\" ;");
           sb.AppendLine("\tdce:creator                    \"Pieter Pauwels (pipauwel.pauwels@ugent.be)\" , \"Walter Terkaj  (walter.terkaj@itia.cnr.it)\" ;");
           sb.AppendLine("\tdce:date                       \"2015/10/02\" ;");
           sb.AppendLine("\tdce:description                \"OWL ontology for the IFC conceptual data schema and exchange file format for Building Information Model (BIM) data\" ;");
           sb.AppendLine("\tdce:identifier                 \""+ ifcversion +"\" ;");
           sb.AppendLine("\tdce:language                   \"en\" ;");
           sb.AppendLine("\tdce:title                      \""+ ifcversion +"\" ;");
           sb.AppendLine("\tvann:preferredNamespacePrefix  \"ifc\" ;");
           sb.AppendLine("\tvann:preferredNamespaceUri     \"" + ifcxmlns + "\" ;");
           sb.AppendLine("\towl:imports                    <https://w3id.org/express> .");

     

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
                          string text = this.FormatSelectCompListing(docSelect,map,included);
                          //string text = this.FormatSelect(docSelect);
                          sb.AppendLine(text);
                       }
                       else if (docType is DocEnumeration)
                       {
                          DocEnumeration docEnumeration = (DocEnumeration)docType;
                          string text = this.FormatEnumerationCompListing(docEnumeration);
                          //string text = this.FormatEnumeration(docEnumeration);
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

        public string FormatData(DocPublication docPublication, DocExchangeDefinition docExchange, Dictionary<string, DocObject> map, Dictionary<long, SEntity> instances)
        {
            return null;
        }
    }
}

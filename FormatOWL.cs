using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public class FormatOWL : IFormatExtension
    {
        public static ArrayList listPropertiesOutput = new ArrayList();

        public FormatOWL()
        {        }

        public string FormatEntity(DocEntity docEntity, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {

           StringBuilder sb = new StringBuilder();

           sb.AppendLine("ifc:" + docEntity.Name);
           sb.AppendLine("\trdf:type \towl:Class ;");
           sb.AppendLine("\trdfs:label  \t\"" + docEntity.Name + "\" .");
            sb.AppendLine();

            // TO DO: to be completed

            return sb.ToString();
        }

        public string FormatEnumeration(DocEnumeration docEnumeration)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ifc:" + docEnumeration.Name);
            sb.AppendLine("\trdf:type owl:Class ;");

            //Add parent SELECT classes
            
            //possibly add the items in a oneof
            sb.AppendLine("\towl:equivalentClass");
            sb.AppendLine("\t\t[");
            sb.AppendLine("\t\t\trdf:type owl:Class ;");
            sb.AppendLine("\t\t\towl:oneOf ");
            sb.AppendLine("\t\t\t\t( ");

            foreach (DocConstant docConst in docEnumeration.Constants)
            {
                sb.AppendLine("\t\t\t\tifc:" + docConst.Name.ToUpper() + " ");
            }

            //close oneof
            sb.AppendLine("\t\t\t\t) ");
            sb.AppendLine("\t\t] ; ");

            sb.AppendLine("\trdfs:subClassOf expr:ENUMERATION .");
            sb.AppendLine();

            return sb.ToString();
        }

       // version for computer interpretable listing
        public string FormatEnumerationCompListing(DocEnumeration docEnumeration)
        {
           StringBuilder sb = new StringBuilder();

           sb.AppendLine("ifc:"+ docEnumeration.Name);
           sb.AppendLine("\trdf:type owl:Class ;");
           sb.AppendLine("\trdfs:subClassOf expr:ENUMERATION .");
           sb.AppendLine();

           // define individuals
           foreach (DocConstant docConst in docEnumeration.Constants)
            {
                sb.AppendLine("ifc:" + docConst.Name.ToUpper());
                sb.AppendLine("\trdf:type " + "ifc:" + docEnumeration.Name + " , owl:NamedIndividual ;");
                sb.AppendLine("\trdfs:label  \"" + docConst.Name.ToUpper() + "\" .");
                sb.AppendLine();
            }

           return sb.ToString();
        }

        public string FormatSelect(DocSelect docSelect, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ifc:" + docSelect.Name);
            sb.AppendLine("\trdf:type owl:Class ;");

            //Add parent SELECT classes

            //possibly add the individuals here as a union
            sb.AppendLine("\towl:equivalentClass");
            sb.AppendLine("\t\t[");
            sb.AppendLine("\t\t\trdf:type owl:Class ;");
            sb.AppendLine("\t\t\towl:unionOf ");
            sb.AppendLine("\t\t\t\t( ");

            // entities
            foreach (DocSelectItem docItem in docSelect.Selects)
            {
               DocObject mapDef = null;
               if (map.TryGetValue(docItem.Name, out mapDef))
                {
                   if (included == null || included.ContainsKey(mapDef))
                    {
                        sb.AppendLine("\t\t\t\t\tifc:" + docItem.Name + " ");
                    }
                }
            }

            //close unionof
            sb.AppendLine("\t\t\t\t) ");
            sb.AppendLine("\t\t] ; ");
            sb.AppendLine("\trdfs:subClassOf expr:SELECT .");
            sb.AppendLine();

            return sb.ToString();
        }

        // version for computer interpretable listing
        public string FormatSelectCompListing(DocSelect docSelect, Dictionary<string, DocObject> map, Dictionary<DocObject, bool> included)
        {
           StringBuilder sb = new StringBuilder();

           sb.AppendLine("ifc:" + docSelect.Name);
           sb.AppendLine("\trdf:type owl:Class ;");
           sb.AppendLine("\trdfs:subClassOf expr:SELECT ;");
           sb.AppendLine("\trdfs:label  \"" + docSelect.Name + "\" .");
            sb.AppendLine();

            //Add parent SELECT classes

            // entities
            foreach (DocSelectItem docItem in docSelect.Selects)
           {
              DocObject mapDef = null;
              if (map.TryGetValue(docItem.Name, out mapDef))
              {
                 if (included == null || included.ContainsKey(mapDef))
                 {
                        sb.AppendLine("ifc:" + docItem.Name);
                        sb.AppendLine("\trdfs:subClassOf ifc:" + docSelect.Name + " .");
                        sb.AppendLine();
                 }
              }
           }

           return sb.ToString();
        }

        public static string ToXsdType(string typename)
        {
            string defined = "ifc:" + typename;
            switch (typename)
            {
                case "BOOLEAN":
                    defined = "expr:BOOLEAN";
                    break;

                case "LOGICAL":
                    defined = "expr:LOGICAL";
                    break;

                case "INTEGER":
                    defined = "expr:INTEGER";
                    break;

                case "STRING":
                    defined = "expr:STRING";
                    break;

                case "REAL":
                    defined = "expr:REAL";
                    break;

                case "NUMBER":
                    defined = "expr:NUMBER";
                    break;

                case "BINARY":
                    defined = "expr:BINARY";
                    break;

                case "BINARY (32)":
                    defined = "expr:BINARY";
                    break;
            }

            return defined;
        }

        private string WriteMinCardRestr(string className, string attrName, int minCard, bool asEntity)
        {
            string output = "";
		    output+=" ;\r\n";
            output += "\trdfs:subClassOf" + "\r\n";

            string tab = "\t";
		    if(asEntity==true){
                output += "\t\t[" + "\r\n";
                output += "\t\t\trdf:type owl:Restriction ; " + "\r\n";
                output += "\t\t\towl:onProperty ifc:" + attrName + " ;\r\n";
                output += "\t\t\towl:allValuesFrom" + "\r\n";
                tab += "\t\t";
            }
		    for (int i = 0; i <= minCard -1; i++) {
			    tab += "\t";
                output += tab + "[" + "\r\n";
                output += tab + "\trdf:type owl:Restriction ; " + "\r\n";
                output += tab + "\towl:onProperty list:hasNext ; " + "\r\n";
                output += tab + "\towl:someValuesFrom ";
                if(i!=minCard-1)
                    output += "\r\n";
            }
            output += className + "\r\n";
		    for (int i = 0; i <= minCard - 1; i++) {
				tab = tab.Substring(1);
                output += tab + "\t]";
                if (i != minCard - 1)
                    output += "\r\n";
            }

		    if(asEntity==true){
                output += "\t\t]";
		    }
            return output;
	    }

        private string WriteMaxCardRestr(string className, string attrName, int maxCard, bool asEntity)
        {
            string output = "";
            output += " ;\r\n";
            output += "\trdfs:subClassOf" + "\r\n";

            string tab = "\t";
            if (asEntity == true)
            {
                output += "\t\t[" + "\r\n";
                output += "\t\t\trdf:type owl:Restriction ; " + "\r\n";
                output += "\t\t\towl:onProperty ifc:" + attrName + " ;\r\n";
                output += "\t\t\towl:allValuesFrom" + "\r\n";
                tab += "\t\t";
            }
            for (int i = 0; i < maxCard - 1; i++)
            {
                tab += "\t";
                output += tab + "[" + "\r\n";
                output += tab + "\trdf:type owl:Restriction ; " + "\r\n";
                output += tab + "\towl:onProperty list:hasNext ; " + "\r\n";
                output += tab + "\towl:someValuesFrom ";
                if (i != maxCard)
                    output += "\r\n";
            }

            tab += "\t";
            output += tab + "[" + "\r\n";
            output += tab + "\trdf:type owl:Restriction ; " + "\r\n";
            output += tab + "\towl:onProperty list:hasNext ; " + "\r\n";
            output += tab + "\towl:onClass " + className + " ;" + "\r\n";
            output += tab + "\towl:qualifiedCardinality \"1\"^^xsd:nonNegativeInteger " + "\r\n";

            tab=tab.Substring(1);
            output += tab + "\t]" + "\r\n";	
		
		    for(int i = 0; i<maxCard-1;i++){		
			    tab=tab.Substring(1);
                output += tab + "\t]";
                if (i != maxCard)
                    output += "\r\n";
            }		
		    if(asEntity==true)
                output += "\t\t]";

            return output;
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
                    //IfcPropertySetDefinitionSet

                    sb.AppendLine("ifc:" + docDefined.Name);
                    sb.AppendLine("\trdf:type owl:Class ;");

                    //TODO:: Add (SELECT) parent classes  

                    sb.AppendLine("\trdfs:subClassOf ");
                    sb.AppendLine("\t\t[ ");
                    sb.AppendLine("\t\t\trdf:type owl:Restriction ;");
                    sb.AppendLine("\t\t\towl:allValuesFrom " + defined + " ;");
                    sb.AppendLine("\t\t\towl:onProperty expr:hasSet");
                    sb.AppendLine("\t\t] ;");
                    sb.AppendLine("\t" + "rdfs:subClassOf ");
                    sb.AppendLine("\t\t" + "[");
                    sb.AppendLine("\t\t\t" + "rdf:type owl:Restriction ;");
                    sb.AppendLine("\t\t\t" + "owl:minQualifiedCardinality \"" + 1
                        + "\"^^xsd:nonNegativeInteger ;");
                    sb.AppendLine("\t\t\towl:onProperty expr:hasSet ;");
                    sb.AppendLine("\t\t\t" + "owl:onClass " + defined);
                    sb.AppendLine("\t\t] .");
                    sb.AppendLine();
                }
                else if (docDefined.Aggregation.GetAggregation() == DocAggregationEnum.LIST || docDefined.Aggregation.GetAggregation() == DocAggregationEnum.ARRAY)
                {

                    //Console.Out.WriteLine("defined type --" + docDefined.Aggregation.GetAggregation() + "-- : " + docDefined.Name);

                    sb.AppendLine("ifc:" + docDefined.Name);
                    sb.AppendLine("\trdf:type owl:Class ;");
                    sb.Append("\trdfs:subClassOf " + defined + "_List ");

                    //TODO:: Add (SELECT) parent classes   

                    //check for cardinality restrictions and add if available
                    string cards = "";
                    if (docDefined.Aggregation.GetAggregationNestingLower() >= 1)
                        cards += WriteMinCardRestr(defined + "_List", "hasNext", docDefined.Aggregation.GetAggregationNestingLower(), false);
                    if (docDefined.Aggregation.GetAggregationNestingUpper() > 1)
                        cards += WriteMaxCardRestr(defined + "_EmptyList", "hasNext", docDefined.Aggregation.GetAggregationNestingUpper(), false);
                    cards += ".";
                    sb.AppendLine(cards);
                    sb.AppendLine();

                    if (defined.StartsWith("ifc"))
                    {
                        if (!listPropertiesOutput.Contains(defined))
                        {
                            // property already contained in resulting OWL file
                            // (.TTL) -> no need to write additional property		
                            listPropertiesOutput.Add(defined);

                            sb.AppendLine(defined + "_EmptyList");
                            sb.AppendLine("\trdf:type owl:Class ;");
                            sb.AppendLine("\trdfs:subClassOf list:EmptyList, " + defined + "_List" + " .");
                            sb.AppendLine();

                            sb.AppendLine(defined + "_List");
                            sb.AppendLine("\trdf:type owl:Class ;");
                            sb.AppendLine("\trdfs:subClassOf list:OWLList ;");
                            sb.AppendLine("\trdfs:subClassOf");
                            sb.AppendLine("\t\t[");
                            sb.AppendLine("\t\t\trdf:type owl:Restriction ;");
                            sb.AppendLine("\t\t\towl:onProperty list:hasContents ;");
                            sb.AppendLine("\t\t\towl:allValuesFrom " + defined);
                            sb.AppendLine("\t\t] ;");
                            sb.AppendLine("\trdfs:subClassOf");
                            sb.AppendLine("\t\t[");
                            sb.AppendLine("\t\t\trdf:type owl:Restriction ;");
                            sb.AppendLine("\t\t\towl:onProperty list:isFollowedBy ;");
                            sb.AppendLine("\t\t\towl:allValuesFrom " + defined + "_List");
                            sb.AppendLine("\t\t] ;");
                            sb.AppendLine("\trdfs:subClassOf");
                            sb.AppendLine("\t\t[");
                            sb.AppendLine("\t\t\trdf:type owl:Restriction ;");
                            sb.AppendLine("\t\t\towl:onProperty list:hasNext ;");
                            sb.AppendLine("\t\t\towl:allValuesFrom " + defined + "_List");
                            sb.AppendLine("\t\t] .");
                            sb.AppendLine();
                        }
                    }
                }
            }
            else
            {
                sb.AppendLine("ifc:" + docDefined.Name);
                sb.AppendLine("\trdf:type owl:Class ;");

                //TODO:: add parent selects

                sb.AppendLine("\trdfs:subClassOf " + defined + " .");
                sb.AppendLine();

                if (docDefined.Length > 0 || docDefined.Length < 0 || docDefined.Aggregation != null)
                {
                    //TODO: possibly add restrictions here

                    //TYPE IfcGloballyUniqueId = STRING(22) FIXED;
                    //END_TYPE;

                    //TYPE IfcIdentifier = STRING(255);
                    //END_TYPE;

                    //TYPE IfcLabel = STRING(255);
                    //END_TYPE;
                }
            }

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
            sb.AppendLine();




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
                          sb.Append(text);
                       }
                       else if (docType is DocSelect)
                       {
                          DocSelect docSelect = (DocSelect)docType;
                          string text = this.FormatSelectCompListing(docSelect,map,included);
                          //string text = this.FormatSelect(docSelect);
                          sb.Append(text);
                       }
                       else if (docType is DocEnumeration)
                       {
                          DocEnumeration docEnumeration = (DocEnumeration)docType;
                          string text = this.FormatEnumerationCompListing(docEnumeration);
                          //string text = this.FormatEnumeration(docEnumeration);
                          sb.Append(text);
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
                       sb.Append(text);
                    }
                 }
              }

           }
            listPropertiesOutput.Clear();
           return sb.ToString();
        }

        public string FormatData(DocPublication docPublication, DocExchangeDefinition docExchange, Dictionary<string, DocObject> map, Dictionary<long, SEntity> instances)
        {
            return null;
        }
    }
}

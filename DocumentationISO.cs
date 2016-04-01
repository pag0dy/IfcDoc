// Name:        DocumentationISO.cs
// Description: Generates documentation
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2010 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;
using IfcDoc.Schema.PSD;
using IfcDoc.Schema.MVD;
using IfcDoc.Format.EXP;
using IfcDoc.Format.CSC;
using IfcDoc.Format.HTM;
using IfcDoc.Format.XSD;
using IfcDoc.Format.XML;
using IfcDoc.Format.SML;
using IfcDoc.Format.SPF;
using IfcDoc.Format.PNG;

namespace IfcDoc
{
    public static class DocumentationISO
    {
        /// <summary>
        /// Capture link to table or figure
        /// </summary>
        public struct ContentRef
        {
            public string Caption; // caption to be displayed in table of contents
            public DocObject Page; // relative link to reference

            public ContentRef(string caption, DocObject page)
            {
                this.Caption = caption;
                this.Page = page;
            }
        }

        /// <summary>
        /// Exports file according to format.
        /// </summary>
        /// <param name="filepath">File path to export.</param>
        /// <param name="templates">Optional filter of templates to export.</param>
        /// <param name="views">Optional filter of views to export.</param>
        /// <param name="schemas">Optional filter of schemas to export.</param>
        /// <param name="locales">Optional filter of locales to export.</param>
        public static void DoExport(DocProject docProject, string filepath, DocModelView[] views, string[] locales, Dictionary<long, SEntity> instances)
        {
            string ext = System.IO.Path.GetExtension(filepath).ToLower();

            Dictionary<DocObject, bool> included = null;
            if (views != null)
            {
                included = new Dictionary<DocObject, bool>();
                foreach (DocModelView docView in views)
                {
                    docProject.RegisterObjectsInScope(docView, included);
                }
            }

            // special case for zip files -- determine based on special naming; make configurable in future
            Type typeExport = null;
            if (filepath.EndsWith("-psd.zip"))
            {
                typeExport = typeof(DocPropertySet);
            }
            else if(filepath.EndsWith("-qto.zip"))
            {
                typeExport = typeof(DocQuantitySet);
            }

            switch (ext)
            {
                case ".ifc":
                    using (FormatSPF format = new FormatSPF(filepath, Schema.IFC.SchemaIfc.Types, instances))
                    {
                        string filename = System.IO.Path.GetFileName(filepath);
                        format.InitHeaders(filename, "IFC4"); // we always use IFC4 (not later schema) for exporting templates, as that is the earliest version required.
                        Schema.IFC.IfcProject ifcProject = new IfcDoc.Schema.IFC.IfcProject();
                        Program.ExportIfc(ifcProject, docProject, included);
                        format.Save();
                    }
                    break;

                case ".ifcxml":
                    using (FormatXML format = new FormatXML(filepath, typeof(Schema.IFC.IfcProject), "http://www.buildingsmart-tech.org/ifcXML/IFC4"))
                    {
                        Schema.IFC.IfcProject ifcProject = new IfcDoc.Schema.IFC.IfcProject();
                        Program.ExportIfc(ifcProject, docProject, included);
                        format.Instance = ifcProject;
                        format.Save();
                    }
                    break;

                case ".mvdxml":
                    using (FormatXML format = new FormatXML(filepath, typeof(mvdXML), mvdXML.DefaultNamespace))
                    {
                        mvdXML mvd = new mvdXML();
                        Program.ExportMvd(mvd, docProject, included);
                        format.Instance = mvd;
                        format.Save();
                    }
                    break;

                case ".cs":
                    using (FormatCSC format = new FormatCSC(filepath))
                    {
                        format.Instance = docProject;
                        format.Save();
                    }
                    break;

                case ".exp":
                    // use currently visible model view(s)
                    using (FormatEXP format = new FormatEXP(filepath))
                    {
                        format.Instance = docProject;
                        format.ModelViews = views;
                        format.Save();
                    }
                    break;

                case ".xsd":
                    // use currently visible model view(s)
                    using (FormatXSD format = new FormatXSD(filepath))
                    {
                        format.Instance = docProject;
                        format.ModelViews = views;
                        format.Save();
                    }
                    break;

                case ".xml": // Express XSD Configuration
                    using (FormatXML format = new FormatXML(filepath, typeof(Schema.CNF.configuration), null, Schema.CNF.SchemaCNF.Prefixes))
                    {
                        Schema.CNF.configuration config = new Schema.CNF.configuration();
                        Program.ExportCnf(config, docProject, views, included);
                        format.Instance = config;
                        format.Save();
                    }
                    break;

                case ".txt":
                    // pick locale
                    using (FormatCSV format = new FormatCSV(filepath))
                    {
                        format.Instance = docProject;
                        format.Locales = locales;
                        format.Save();
                    }
                    break;

                case ".sch":
                    using (FormatXML format = new FormatXML(filepath, typeof(Schema.SCH.schema), "http://purl.oclc.org/dsdl/schematron"))
                    {
                        Schema.SCH.schema sch = new Schema.SCH.schema();
                        Program.ExportSch(sch, docProject, included);
                        format.Instance = sch;
                        format.Save();
                    }
                    break;

                case ".zip":
                    using (FormatZIP format = new FormatZIP(new System.IO.FileStream(filepath, System.IO.FileMode.Create), docProject, included, typeExport))
                    {
                        format.Save();
                    }
                    break;

            }

        }


        /// <summary>
        /// Copies files and folders recursively, skipping those that already exist.
        /// </summary>
        /// <param name="sourcepath">Path of source directory</param>
        /// <param name="targetpath">Path of target directory</param>
        private static void CopyFiles(string sourcepath, string targetpath)
        {
            if (!System.IO.Directory.Exists(sourcepath))
                return;

            string[] arrFiles = System.IO.Directory.GetFiles(sourcepath);
            foreach (string sourcefile in arrFiles)
            {
                string filename = System.IO.Path.GetFileName(sourcefile);
                string targetfile = System.IO.Path.Combine(targetpath, filename);

                try
                {
                    if (!System.IO.File.Exists(targetfile))
                    {
                        System.IO.File.Copy(sourcefile, targetfile);
                    }
                }
                catch
                {
                }
            }

            string[] arrDirectories = System.IO.Directory.GetDirectories(sourcepath);
            foreach (string sourcedir in arrDirectories)
            {
                string dirname = System.IO.Path.GetFileName(sourcedir);
                string targetdir = System.IO.Path.Combine(targetpath, dirname);

                try
                {
                    if (!System.IO.Directory.Exists(targetdir))
                    {
                        System.IO.Directory.CreateDirectory(targetdir);
                    }
                }
                catch
                {
                }

                CopyFiles(sourcedir, targetdir);
            }
        }

        /// <summary>
        /// Builds list of items in order, using inherited concepts.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="template"></param>
        /// <param name="view"></param>
        private static DocTemplateItem[] FindTemplateItems(DocProject docProject, DocEntity entity, DocTemplateDefinition template, DocModelView view)
        {
            // inherited concepts first

            List<DocTemplateItem> listItems = new List<DocTemplateItem>();
            DocEntity basetype = entity;
            bool inherit = true;
            while (basetype != null)
            {
                // find templates for base
                foreach (DocModelView docView in docProject.ModelViews)
                {
                    if (view == docView || view.BaseView == docView.Name)
                    {
                        foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                        {
                            if (docRoot.ApplicableEntity == basetype)
                            {
                                foreach (DocTemplateUsage eachusage in docRoot.Concepts)
                                {
                                    if (eachusage.Definition == template)
                                    {
                                        // found it

                                        string[] parameters = template.GetParameterNames();

                                        foreach (DocTemplateItem eachitem in eachusage.Items)
                                        {
                                            string[] values = new string[parameters.Length];
                                            for (int iparam = 0; iparam < parameters.Length; iparam++)
                                            {
                                                values[iparam] = eachitem.GetParameterValue(parameters[iparam]);
                                            }

                                            // new (IfcDoc 4.9d): only add if we don't override by parameters matching exactly
                                            bool include = true;
                                            foreach (DocTemplateItem existitem in listItems)
                                            {
                                                bool samevalues = true;

                                                for (int iparam = 0; iparam < parameters.Length; iparam++)
                                                {
                                                    string value = values[iparam];
                                                    string match = existitem.GetParameterValue(parameters[iparam]);
                                                    if (match != value || (match != null && !match.Equals(value, StringComparison.Ordinal)))
                                                    {
                                                        samevalues = false;
                                                        break;
                                                    }
                                                }

                                                if (samevalues)
                                                {
                                                    include = false;
                                                    break;
                                                }
                                            }

                                            if (include)
                                            {
                                                listItems.Add(eachitem);
                                            }
                                        }

                                        inherit = !eachusage.Override;
                                    }
                                }
                            }
                        }
                    }
                }

                // inherit concepts from supertypes unless overriding
                if (basetype.BaseDefinition != null && inherit)
                {
                    basetype = docProject.GetDefinition(basetype.BaseDefinition) as DocEntity;
                }
                else
                {
                    basetype = null;
                }
            }

            return listItems.ToArray();
        }

        /// <summary>
        /// Formats table for single exchange
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        private static string FormatExchange(DocProject docProject, DocModelView docView, DocExchangeDefinition def, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, DocPublication docPublication)
        {
            // format content
            StringBuilder sbMain = new StringBuilder();

            if(!String.IsNullOrEmpty(def.ExchangeClass))
            {
                sbMain.AppendLine("<table class=\"gridtable\">");
                sbMain.AppendLine("<tr><th>Process</th><th>Sender</th><th>Receiver</th></tr>");
                sbMain.AppendLine("<tr><td>" + def.ExchangeClass + "</td><td>" + def.SenderClass + "</td><td>" + def.ReceiverClass + "</td></tr>");
                sbMain.AppendLine("</table>");
            }

            // 1. manual content
            sbMain.Append(def.Documentation);

            // 2. map of entities and templates -- Identity | Template | Import | Export
            sbMain.AppendLine("<p></p>");//This exchange involves the following entities:</p>");

            SortedList<string, DocConceptRoot> sortlist = new SortedList<string, DocConceptRoot>();

            foreach (DocConceptRoot docRoot in docView.ConceptRoots)
            {
                foreach (DocTemplateUsage docUsage in docRoot.Concepts)
                {
                    foreach (DocExchangeItem docReq in docUsage.Exchanges)
                    {
                        //if (docReq.Exchange == def && docReq.Requirement != DocExchangeRequirementEnum.NotRelevant && docReq.Requirement != DocExchangeRequirementEnum.Excluded && !sortlist.ContainsKey(docRoot.ApplicableEntity.Name))
                        if (docReq.Exchange == def && docReq.Requirement != DocExchangeRequirementEnum.NotRelevant && !sortlist.ContainsKey(docRoot.ApplicableEntity.Name))
                        {
                            sortlist.Add(docRoot.ApplicableEntity.Name, docRoot);
                        }
                    }
                }
            }

            bool externaldataconstraints = false;

            // new style - table
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table class=\"exchange\">");
            sb.AppendLine("<tr><th colspan=\"5\"><img src=\"../../../img/mvd-" + MakeLinkName(def) + ".png\" />&nbsp; " + def.Name + "</th></tr>");
            sb.AppendLine("<tr><th>Entity/Concept</th><th>Attributes</th><th>Constraints</th><th>I</th><th>E</th></tr>");
            foreach (string ent in sortlist.Keys)
            {
                DocConceptRoot docRoot = sortlist[ent];

                sb.Append("<tr><td colspan=\"5\"><b><i>");
                sb.Append(docRoot.ApplicableEntity.Name);
                sb.AppendLine("</i></b></td></tr>");

                // determine schema
                string schema = mapSchema[ent];

                foreach (DocTemplateUsage docConcept in docRoot.Concepts)
                {
                    if (docConcept.Definition != null)
                    {
                        DocExchangeRequirementEnum reqImport = DocExchangeRequirementEnum.NotRelevant;
                        DocExchangeRequirementEnum reqExport = DocExchangeRequirementEnum.NotRelevant;
                        foreach (DocExchangeItem docReq in docConcept.Exchanges)
                        {
                            if (docReq.Exchange == def)
                            {
                                if (docReq.Applicability == DocExchangeApplicabilityEnum.Export)
                                {
                                    reqExport = docReq.Requirement;
                                }
                                else if (docReq.Applicability == DocExchangeApplicabilityEnum.Import)
                                {
                                    reqImport = docReq.Requirement;
                                }
                            }
                        }

                        if (reqImport != DocExchangeRequirementEnum.NotRelevant || reqExport != DocExchangeRequirementEnum.NotRelevant)
                        {
                            if (docConcept.Definition.Name.Equals("External Data Constraints"))
                            {
                                if(!externaldataconstraints)
                                {
                                    // show heading for first time
                                    sbMain.Append("<h4>Data Requirements for tabular formats</h4>");
                                    externaldataconstraints = true;
                                }

                                // new for GSA: cross-tab report to show mappings between exchanges and applications and vice-versa
                                List<DocModelView> listViewCross = new List<DocModelView>();
                                if (docPublication.Comparison)
                                {
                                    foreach (DocModelView docEachView in docProject.ModelViews)
                                    {
                                        if (docEachView != docView )
                                        {
                                            listViewCross.Add(docEachView);
                                        }
                                    }
                                }

                                // table and description
                                sbMain.Append("<h5>" + docConcept.Name + "</h5>");
                                sbMain.Append(docConcept.Documentation);

                                sbMain.AppendLine("<table class=\"gridtable\">");
                                sbMain.Append("<tr><th>Column</th><th>Mapping</th><th>Definition</th><th>Notes</th>");
                                foreach(DocModelView docViewCross in listViewCross)
                                {
                                    foreach (DocExchangeDefinition docExchangeCross in docViewCross.Exchanges)
                                    {
                                        sbMain.Append("<th><a href=\"../../views/");
                                        sbMain.Append(MakeLinkName(docViewCross));
                                        sbMain.Append("/");
                                        sbMain.Append(MakeLinkName(docExchangeCross));
                                        sbMain.Append(".htm\"><img width=\"16\" src=\"../../../img/mvd-");
                                        sbMain.Append(MakeLinkName(docExchangeCross));
                                        sbMain.Append(".png\" title=\"");
                                        sbMain.Append(docExchangeCross.Name);
                                        sbMain.Append("\"/></a></th>");
                                    }
                                }
                                sbMain.AppendLine("</tr>");
                                foreach(DocTemplateItem docItem in docConcept.Items)
                                {
                                    string name = docItem.GetParameterValue("Name");
                                    string refv = docItem.GetParameterValue("Reference");
                                    string mapp = FormatReference(docProject, refv);

                                    string desc = null;
                                    CvtValuePath valpath = CvtValuePath.Parse(refv, mapEntity);

                                    if (valpath != null && 
                                        valpath.Property != null && 
                                        valpath.Property.Name.Equals("IsDefinedBy") &&
                                        valpath.InnerPath != null && valpath.InnerPath.Type.Name.Equals("IfcRelDefinesByProperties"))
                                    {
                                        DocObject docPset = null;
                                        mapEntity.TryGetValue(valpath.Identifier, out docPset);

                                        if (docPset is DocPropertySet)
                                        {
                                            DocProperty docProp = ((DocPropertySet)docPset).GetProperty(valpath.InnerPath.InnerPath.Identifier);
                                            if (docProp != null)
                                            {
                                                desc = docProp.Documentation;// localize??
                                            }
                                        }
                                        else if (docPset is DocQuantitySet)
                                        {
                                            DocQuantity docProp = ((DocQuantitySet)docPset).GetQuantity(valpath.InnerPath.InnerPath.Identifier);
                                            if (docProp != null)
                                            {
                                                desc = docProp.Documentation;// localize??
                                            }
                                        }
                                    }
                                    else if (valpath != null &&
                                        valpath.Property != null &&
                                        valpath.Property.Name.Equals("HasPropertySets") &&
                                        valpath.InnerPath != null && valpath.InnerPath.Type.Name.Equals("IfcPropertySet"))
                                    {
                                        DocObject docPset = null;
                                        mapEntity.TryGetValue(valpath.Identifier, out docPset);

                                        if (docPset is DocPropertySet)
                                        {
                                            DocProperty docProp = ((DocPropertySet)docPset).GetProperty(valpath.InnerPath.Identifier);
                                            if (docProp != null)
                                            {
                                                desc = docProp.Documentation;// localize??
                                            }
                                        }
                                    }

                                    if (desc == null)
                                    {
                                        while (valpath != null && valpath.InnerPath != null && valpath.InnerPath.Property != null)
                                        {
                                            valpath = valpath.InnerPath;
                                        }
                                        if (valpath != null && valpath.Property != null)
                                        {
                                            desc = valpath.Property.Documentation;
                                        }
                                        else if(valpath != null)
                                        {
                                            desc = "The IFC class identifier indicating the subtype of object.";
                                        }
                                    }

                                    sbMain.Append("<tr><td>" + name + "</td><td>" + mapp + "</td><td>" + desc + "</td><td>" + docItem.Documentation + "</td>");
                                    foreach (DocModelView docViewCross in listViewCross)
                                    {
                                        foreach (DocExchangeDefinition docExchangeCross in docViewCross.Exchanges)
                                        {
                                            // find any table in that exchange containing a matching mapping
                                            sbMain.Append("<td>");

                                            foreach (DocConceptRoot docRootCross in docViewCross.ConceptRoots)
                                            {
                                                foreach (DocTemplateUsage docConceptCross in docRootCross.Concepts)
                                                {
                                                    if (docConceptCross.Definition != null && docConceptCross.Definition.Name.Equals("External Data Constraints"))
                                                    {
                                                        DocExchangeRequirementEnum reqImportCross = DocExchangeRequirementEnum.NotRelevant;
                                                        DocExchangeRequirementEnum reqExportCross = DocExchangeRequirementEnum.NotRelevant;
                                                        foreach (DocExchangeItem docReq in docConceptCross.Exchanges)
                                                        {
                                                            if (docReq.Exchange == docExchangeCross)
                                                            {
                                                                if (docReq.Applicability == DocExchangeApplicabilityEnum.Export)
                                                                {
                                                                    reqExportCross = docReq.Requirement;
                                                                }
                                                                else if (docReq.Applicability == DocExchangeApplicabilityEnum.Import)
                                                                {
                                                                    reqImportCross = docReq.Requirement;
                                                                }

                                                            }
                                                        }

                                                        // found it, now look for any matching data mappings
                                                        if (reqImportCross != DocExchangeRequirementEnum.NotRelevant || reqExportCross != DocExchangeRequirementEnum.NotRelevant)
                                                        {
                                                            foreach (DocTemplateItem docItemCross in docConceptCross.Items)
                                                            {
                                                                string crossrefv = docItemCross.GetParameterValue("Reference");
                                                                if (crossrefv != null && crossrefv.Equals(refv))
                                                                {
                                                                    string crosstabl = docItemCross.GetParameterValue("Table");
                                                                    string crossname = docItemCross.GetParameterValue("Name");

                                                                    sbMain.Append("<a href=\"../../views/");
                                                                    sbMain.Append(MakeLinkName(docViewCross));
                                                                    sbMain.Append("/");
                                                                    sbMain.Append(MakeLinkName(docExchangeCross));
                                                                    sbMain.Append(".htm\"><img width=\"16\" src=\"../../../img/attr-mandatory");
                                                                    sbMain.Append(".png\" title=\"");
                                                                    sbMain.Append(docExchangeCross.Name + ": " + crosstabl + "." + crossname);
                                                                    sbMain.Append("\"/></a>");

                                                                    //sbMain.Append(crosstabl + "." + crossname); //... use icon to show import or export, with tooltip showing name...
                                                                    break;
                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                            }
                                            sbMain.Append("</td>");
                                        }
                                    }
                                    sbMain.AppendLine("</tr>");
                                }
                                sbMain.AppendLine("</table>");

                                // bring out separately
                                //string table = FormatConceptTable(docProject, docView, docRoot.ApplicableEntity, docRoot, docConcept, mapEntity, mapSchema);
                                //sbMain.Append(table);
                            }
                            else
                            {
                                sb.Append("<tr><td>&nbsp;&nbsp;<a href=\"../../templates/");
                                sb.Append(MakeLinkName(docConcept.Definition));
                                sb.Append(".htm\">");
                                sb.Append(docConcept.Definition.Name);
                                sb.Append("</a></td><td>");

                                bool first = true;
                                if (docConcept.Definition.Rules != null)
                                {
                                    foreach (DocModelRule docRule in docConcept.Definition.Rules)
                                    {
                                        if (!first)
                                        {
                                            sb.Append("<br/>");
                                        }
                                        sb.Append(docRule.Name);
                                        first = false;
                                    }
                                }
                                sb.Append("</td><td>");


                                string table = FormatConceptTable(docProject, docView, docRoot.ApplicableEntity, docRoot, docConcept, mapEntity, mapSchema);
                                sb.Append(table);

                                sb.Append("</td><td>");
                                AppendRequirement(sb, reqImport, 3);
                                sb.Append("</td><td>");
                                AppendRequirement(sb, reqExport, 3);
                                sb.AppendLine("</td></tr>");
                            }
                        }
                    }
                }

            }
            sb.AppendLine("</table>");

            // then general table for IFC
            sbMain.AppendLine("<h4>Data Requirements for IFC formats</h4>");
            sbMain.Append(sb.ToString());

            return sbMain.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="docTemplate"></param>
        /// <param name="path">Path of templates</param>
        /// <param name="mapEntity"></param>
        /// <param name="mapSchema"></param>
        private static void GenerateTemplateLink(List<DocTemplateDefinition> path, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, Dictionary<DocObject, bool> included, DocPublication docPublication, string dirpath)
        {
            DocTemplateDefinition docTemplateLast = path[path.Count - 1];

            if (included != null && !included.ContainsKey(docTemplateLast))
                return;

            // flat list -- requires unique template names
            StringBuilder sbFile = new StringBuilder();
            sbFile.Append(dirpath);
            sbFile.Append(@"\link\");
            sbFile.Append(MakeLinkName(docTemplateLast));
            sbFile.Append(".htm");

            StringBuilder sbLink = new StringBuilder();
            sbLink.Append("../schema/templates/");
            sbLink.Append(MakeLinkName(docTemplateLast));
            sbLink.Append(".htm");

            using (FormatHTM htmLink = new FormatHTM(sbFile.ToString(), mapEntity, mapSchema, included))
            {
                htmLink.WriteLinkPage(sbLink.ToString(), docPublication);
            }

            if (docTemplateLast.Templates != null)
            {
                foreach (DocTemplateDefinition docSub in docTemplateLast.Templates)
                {
                    path.Add(docSub);
                    GenerateTemplateLink(path, mapEntity, mapSchema, included, docPublication, dirpath);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="docTemplate"></param>
        /// <param name="path">Path of templates</param>
        /// <param name="mapEntity"></param>
        /// <param name="mapSchema"></param>
        private static void GenerateExampleLink(List<DocExample> path, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, Dictionary<DocObject, bool> included, DocPublication docPublication, string dirpath)
        {
            DocExample docTemplateLast = path[path.Count - 1];

            if (included != null && !included.ContainsKey(docTemplateLast))
                return;

            // flat list -- requires unique template names
            StringBuilder sbFile = new StringBuilder();
            sbFile.Append(dirpath);
            sbFile.Append(@"\link\");
            sbFile.Append(MakeLinkName(docTemplateLast));
            sbFile.Append(".htm");

            StringBuilder sbLink = new StringBuilder();
            sbLink.Append("../annex/annex-e/");
            sbLink.Append(MakeLinkName(docTemplateLast));
            sbLink.Append(".htm");

            using (FormatHTM htmLink = new FormatHTM(sbFile.ToString(), mapEntity, mapSchema, included))
            {
                htmLink.WriteLinkPage(sbLink.ToString(), docPublication);
            }

            if (docTemplateLast.Examples != null)
            {
                foreach (DocExample docSub in docTemplateLast.Examples)
                {
                    path.Add(docSub);
                    GenerateExampleLink(path, mapEntity, mapSchema, included, docPublication, dirpath);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }


        private static string FormatDiagram(DocProject docProject, DocObject def, DocModelView docView, List<ContentRef> listFigures, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, string path)
        {
            // return if nothing to generate
            if (def is DocTemplateDefinition)
            {
                DocTemplateDefinition dtd = (DocTemplateDefinition)def;
                if (dtd.Rules == null || dtd.Rules.Count == 0)
                    return null;
            }
            else if (def is DocEntity)
            {
            }
            else
            {
                return null;
            }

            // create the figure file
            string filename = MakeLinkName(def) + ".png";
            Dictionary<Rectangle, DocModelRule> layout = new Dictionary<Rectangle, DocModelRule>();
            if (!Properties.Settings.Default.SkipDiagrams)
            {
                try
                {
                    if (def is DocTemplateDefinition)
                    {
                        System.IO.Directory.CreateDirectory(path + "\\schema\\templates\\diagrams");
                        using (Image image = IfcDoc.Format.PNG.FormatPNG.CreateTemplateDiagram((DocTemplateDefinition)def, mapEntity, layout, docProject, null))
                        {
                            if (image != null)
                            {
                                string filepath = path + "\\schema\\templates\\diagrams\\" + filename;
                                image.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
                            }
                        }
                    }
                    else if (def is DocEntity) // no longer used directly; now for each model view in annex D
                    {
                        System.IO.Directory.CreateDirectory(path + "\\diagrams\\" + MakeLinkName(docView));
                        using (Image image = IfcDoc.Format.PNG.FormatPNG.CreateConceptDiagram((DocEntity)def, docView, mapEntity, layout, docProject, null))
                        {
                            string filepath = path + "\\diagrams\\" + MakeLinkName(docView) + "\\" + filename;
                            image.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                }
                catch
                {
                }
            }

            // 2. figure
            StringBuilder sb = new StringBuilder();
            if (def is DocTemplateDefinition)
            {
                listFigures.Add(new ContentRef(def.Name + " instance diagram", def));

                // Per ISO guidelines, all figures must be referenced from text.
                sb.Append("<p class=\"fig-ref\">Figure ");
                sb.Append(listFigures.Count);
                sb.Append(" illustrates an instance diagram.</p>\r\n");
            }

            // include the figure with formatting below per ISO
            sb.Append("<table><tr><td><img alt=\"");
            sb.Append(def.Name);

            if (def is DocTemplateDefinition)
            {
                sb.Append("\" src=\"./diagrams/");
            }
            else
            {
                sb.Append("\" src=\"../../../diagrams/");
                sb.Append(MakeLinkName(docView));
                sb.Append("/");
            }
            sb.Append(filename);
            sb.Append("\" usemap=\"#f");
            sb.Append(listFigures.Count.ToString());
            sb.Append("\">");
            sb.Append("<map name=\"f");
            sb.Append(listFigures.Count.ToString());
            sb.Append("\">");
            foreach (Rectangle rc in layout.Keys)
            {
                DocModelRule rule = layout[rc];
                DocObject ruleObject = null;
                string strschema = null;

                string typename = null;
                if (rule != null)
                {
                    typename = rule.Name;
                }
                else if (def is DocTemplateDefinition)
                {
                    DocTemplateDefinition dtd = (DocTemplateDefinition)def;
                    typename = dtd.Type;
                }
                else if (def is DocObject)
                {
                    typename = def.Name;
                }

                if (mapEntity.TryGetValue(typename, out ruleObject) && mapSchema.TryGetValue(typename, out strschema))
                {
                    // hyperlink to IFC entity                       
                    // replace it with hyperlink                        
                    string relative = @"../";
                    if (def is DocEntity)
                    {
                        relative = "../../../schema/";
                    }
                    string hyperlink = relative + strschema.ToLower() + @"/lexical/" + ruleObject.Name.ToLower() + ".htm";

                    int indent = 0;
                    sb.Append("<area shape=\"rect\" coords=\"");
                    sb.Append(rc.Left + indent);
                    sb.Append(",");
                    sb.Append(rc.Top + indent);
                    sb.Append(",");
                    sb.Append(rc.Right + indent);
                    sb.Append(",");
                    sb.Append(rc.Bottom + indent);
                    sb.Append("\" href=\"");
                    sb.Append(hyperlink);
                    sb.Append("\" alt=\"");
                    sb.Append(ruleObject.Name);
                    sb.Append("\" />");
                }
            }
            sb.Append("</map>");

            // number figures in templates, but not annex
            if (def is DocTemplateDefinition)
            {
                sb.Append("</td></tr>");
                sb.Append("<tr><td><p class=\"figure\">Figure ");
                sb.Append(listFigures.Count);
                sb.Append(" &mdash; ");
                sb.Append(def.Name);
                sb.Append("</p></td></tr>");
            }

            sb.Append("</table>\r\n");
            sb.AppendLine();

            return sb.ToString();
        }


        private static string FormatTemplate(
            DocProject docProject, 
            DocTemplateDefinition def, 
            List<ContentRef> listFigures, 
            List<ContentRef> listTables, 
            Dictionary<string, DocObject> mapEntity, 
            Dictionary<string, string> mapSchema, 
            Dictionary<DocObject, bool> included,
            string path)
        {
            // format content
            StringBuilder sb = new StringBuilder();

            // 1. manual content
            sb.Append(def.Documentation);

            // 2. instance diagram
            sb.Append(FormatDiagram(docProject, def, null, listFigures, mapEntity, mapSchema, path));

            // 3. entity list                
            {
                foreach (DocModelView docView in docProject.ModelViews)
                {
                    if ((included == null || included.ContainsKey(docView)) && docView.Exchanges.Count > 0)
                    {
                        SortedList<string, DocTemplateUsage> mapUsage = new SortedList<string, DocTemplateUsage>();

                        foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                        {
                            foreach (DocTemplateUsage docUsage in docRoot.Concepts)
                            {
                                if (docUsage.Definition == def && !mapUsage.ContainsKey(docRoot.ApplicableEntity.Name))
                                {
                                    mapUsage.Add(docRoot.ApplicableEntity.Name, docUsage);
                                }
                            }
                        }

                        if (mapUsage.Count > 0)
                        {
                            sb.AppendLine("<hr/>");
                            sb.AppendLine("<h4>" + docView.Name + "</h4>");

                            int cExchange = docView.Exchanges.Count;

                            sb.AppendLine("<table class=\"exchange\">");
                            sb.Append("<tr><th>Entity</th>");

                            if (true)//Properties.Settings.Default.Requirement)
                            {
                                foreach (DocExchangeDefinition docExchange in docView.Exchanges)
                                {
                                    sb.Append("<th><a href=\"../views/");
                                    sb.Append(MakeLinkName(docView));
                                    sb.Append("/");
                                    sb.Append(MakeLinkName(docExchange));
                                    sb.Append(".htm\"><img width=\"16\" src=\"../../img/mvd-");
                                    sb.Append(MakeLinkName(docExchange));
                                    sb.Append(".png\" title=\"");
                                    sb.Append(docExchange.Name);
                                    sb.Append("\"/></a></th>");
                                    sb.AppendLine();
                                }
                            }
                            sb.Append("</tr>");

                            foreach (string entname in mapUsage.Keys)
                            {
                                DocTemplateUsage docUsage = mapUsage[entname];
                                if (docUsage.Definition == def)
                                {
                                    sb.Append("<tr><td><i>");
                                    sb.Append(entname);
                                    sb.Append("</i></td>");

                                    if (true)//Properties.Settings.Default.Requirement)
                                    {
                                        foreach (DocExchangeDefinition docExchange in docView.Exchanges)
                                        {
                                            sb.Append("<td>");

                                            DocExchangeRequirementEnum reqImport = DocExchangeRequirementEnum.NotRelevant;
                                            DocExchangeRequirementEnum reqExport = DocExchangeRequirementEnum.NotRelevant;

                                            foreach (DocExchangeItem dti in docUsage.Exchanges)
                                            {
                                                if (dti.Exchange == docExchange)
                                                {
                                                    if (dti.Applicability == DocExchangeApplicabilityEnum.Import)
                                                    {
                                                        reqImport = dti.Requirement;
                                                    }
                                                    else if (dti.Applicability == DocExchangeApplicabilityEnum.Export)
                                                    {
                                                        reqExport = dti.Requirement;
                                                    }
                                                }
                                            }

                                            AppendRequirement(sb, reqImport, 2);
                                            sb.Append("<br/>");
                                            AppendRequirement(sb, reqExport, 2);

                                            sb.Append("</td>");
                                            sb.AppendLine();
                                        }
                                    }

                                    sb.AppendLine("</tr>");
                                }
                            }

                            sb.AppendLine("</table>");
                        }
                    }
                }

            }

            return sb.ToString();
        }

        private static string FormatRequirements(DocTemplateUsage eachusage, DocModelView docModel, bool showexchanges)
        {
            if (eachusage.Exchanges == null || eachusage.Exchanges.Count == 0 && (eachusage.Items.Count == 0 || eachusage.Definition.Type == ""))
                return null; // don't show if no rules or exchanges

            //if (!Properties.Settings.Default.Requirement)
            //    return String.Empty;

            StringBuilder sb = new StringBuilder();

            if (showexchanges && docModel.Exchanges.Count > 0)
            {
                sb.AppendLine("<table class=\"exchange\">");

                sb.AppendLine("<tr>");
                sb.AppendLine("<th>Exchange</th>");
                foreach (DocExchangeDefinition docExchange in docModel.Exchanges)
                {
                    sb.Append("<th><a href=\"../../views/");
                    sb.Append(MakeLinkName(docModel));
                    sb.Append("/");
                    sb.Append(MakeLinkName(docExchange));
                    sb.Append(".htm\"><img width=\"16\" src=\"../../../img/mvd-");
                    sb.Append(MakeLinkName(docExchange));
                    sb.Append(".png\" title=\"");
                    sb.Append(docExchange.Name);
                    sb.Append("\"/></a></th>");
                    sb.AppendLine();
                }
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>Import</td>");
                foreach (DocExchangeDefinition docExchange in docModel.Exchanges)
                {
                    sb.Append("<td>");
                    foreach (DocExchangeItem dti in eachusage.Exchanges)
                    {
                        if (dti.Exchange == docExchange && dti.Applicability == DocExchangeApplicabilityEnum.Import)
                        {
                            AppendRequirement(sb, dti.Requirement, 3);
                        }
                    }
                    sb.Append("</td>");
                    sb.AppendLine();
                }
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>Export</td>");
                foreach (DocExchangeDefinition docExchange in docModel.Exchanges)
                {
                    sb.Append("<td>");
                    foreach (DocExchangeItem dti in eachusage.Exchanges)
                    {
                        if (dti.Exchange == docExchange && dti.Applicability == DocExchangeApplicabilityEnum.Export)
                        {
                            AppendRequirement(sb, dti.Requirement, 3);
                        }
                    }
                    sb.Append("</td>");
                    sb.AppendLine();
                }
                sb.AppendLine("</tr>");

                sb.AppendLine("</table>");
            }

            return sb.ToString();
        }


        /// <summary>
        /// Formats table for all exchanges within a view
        /// </summary>
        /// <param name="mvd"></param>
        /// <returns></returns>
        private static string FormatView(DocProject docProject, DocModelView docView, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema)
        {
            // format content
            StringBuilder sb = new StringBuilder();

            // 1. manual content
            sb.Append(docView.Documentation);

#if false // don't show anymore
            // 2. map of entities and templates -- Identity | Template | Import | Export
            sb.AppendLine("<p></p>");

            SortedList<string, DocConceptRoot> sortlist = new SortedList<string, DocConceptRoot>();

            // base view
            DocModelView docBase = docView;
            while (docBase != null)
            {
                foreach (DocConceptRoot docRoot in docBase.ConceptRoots)
                {
                    if (!sortlist.ContainsKey(docRoot.ApplicableEntity.Name))
                    {
                        sortlist.Add(docRoot.ApplicableEntity.Name, docRoot);
                    }
                }

                if (!String.IsNullOrEmpty(docBase.BaseView))
                {
                    docBase = docProject.GetView(Guid.Parse(docBase.BaseView));
                }
                else
                {
                    docBase = null;
                }
            }

            int cols = 3 + docView.Exchanges.Count;

            // new style - table
            sb.AppendLine("<table class=\"exchange\">");
            sb.AppendLine("<tr><th colspan=\"" + cols.ToString() + "\">" + docView.Name + "</th></tr>");
            sb.Append("<tr><th>Entity/Concept</th><th>Attributes</th><th>Constraints</th>");
            //<th>I</th><th>E</th></tr>");
            foreach (DocExchangeDefinition docExchange in docView.Exchanges)
            {
                sb.Append("<th>");
                sb.Append("<img src=\"../../../img/mvd-");
                sb.Append(docExchange.Name.ToLower().Replace(' ', '-'));
                sb.Append(".png\" title=\"");
                sb.Append(docExchange.Name);
                sb.Append("\" />");
                sb.Append("</th>");
            }
            sb.AppendLine("</tr>");

            foreach (string ent in sortlist.Keys)
            {
                DocConceptRoot docRoot = sortlist[ent];

                sb.Append("<tr><td colspan=\"" + cols.ToString() + "\"><b><i>");
                sb.Append(docRoot.ApplicableEntity.Name);
                sb.AppendLine("</i></b></td></tr>");

                // determine schema
                string schema = mapSchema[ent];

                foreach (DocTemplateUsage docConcept in docRoot.Concepts)
                {
                    if (docConcept.Definition != null)
                    {

                        sb.Append("<tr><td>&nbsp;&nbsp;<a href=\"../../");
                        sb.Append(schema.ToLower());
                        sb.Append("/lexical/");
                        sb.Append(ent.ToLower());
                        sb.Append(".htm#");
                        sb.Append(docConcept.Definition.Name.ToLower().Replace(' ', '-'));
                        sb.Append("\">");
                        sb.Append(docConcept.Definition.Name);
                        sb.Append("</a></td><td>");

                        bool first = true;
                        if (docConcept.Definition.Rules != null)
                        {
                            foreach (DocModelRule docRule in docConcept.Definition.Rules)
                            {
                                if (!first)
                                {
                                    sb.Append("<br/>");
                                }
                                sb.Append(docRule.Name);
                                first = false;
                            }
                        }

                        sb.Append("</td><td>");

                        // IfcDoc 6.4: use tables
                        string table = FormatConceptTable(docProject, docView, docRoot.ApplicableEntity, docRoot, docConcept, mapEntity, mapSchema);
                        sb.Append(table);
#if false
                    // build list of inherited items
                    first = true;
                    DocTemplateItem[] items = FindTemplateItems(docProject, docRoot.ApplicableEntity, docConcept.Definition, docView);
                    foreach (DocTemplateItem docItem in items)
                    {
                        if (!first)
                        {
                            sb.Append("<br/>");
                        }
                        sb.Append(docItem.RuleParameters);
                        first = false;
                    }
#endif

                        sb.Append("</td>");

                        foreach (DocExchangeDefinition docExchange in docView.Exchanges)
                        {
                            DocExchangeRequirementEnum reqExport = DocExchangeRequirementEnum.NotRelevant;
                            foreach (DocExchangeItem docItem in docConcept.Exchanges)
                            {
                                if (docItem.Exchange == docExchange && docItem.Applicability == DocExchangeApplicabilityEnum.Export)
                                {
                                    reqExport = docItem.Requirement;
                                }
                            }

                            sb.Append("<td>");
                            AppendRequirement(sb, reqExport, 3);
                            sb.Append("</td>");
                        }

                        sb.AppendLine("</tr>");
                    }

                }
            }
            sb.AppendLine("</table>");
#endif
            return sb.ToString();
        }

        private static void AppendRequirement(StringBuilder sb, DocExchangeRequirementEnum req, int level)
        {
            // new-style character (allows copy/paste into word without slowdown)
            switch (req)
            {
                case DocExchangeRequirementEnum.Excluded:
                    sb.Append("X");
                    break;

                case DocExchangeRequirementEnum.Mandatory:
                    sb.Append("R");
                    break;

                case DocExchangeRequirementEnum.NotRelevant:
                    sb.Append("-");
                    break;

                case DocExchangeRequirementEnum.Optional:
                    sb.Append("O");
                    break;
            }
        }

        private static void BuildExampleList(List<DocExample> listExample, DocExample docExample, DocObject docObject, Dictionary<DocObject, bool> included)
        {
            // check for view reference
            if (included != null)
            {
                bool viewref = false;
                foreach (DocModelView docView in docExample.Views)
                {
                    if (included.ContainsKey(docView))
                    {
                        viewref = true;
                        break;
                    }
                }

                if (!viewref)
                    return;
            }

            if (docExample.ApplicableType != null)
            {
                string[] types = docExample.ApplicableType.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string type in types)
                {
                    string[] parts = type.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 1)
                    {
                        if (parts[0].Equals(docObject.Name))
                        {
                            listExample.Add(docExample);
                        }
                    }
                }
            }

            // templates
            if (docExample.ApplicableTemplates != null && docObject is DocTemplateDefinition)
            {
                if (docExample.ApplicableTemplates.Contains((DocTemplateDefinition)docObject))
                {
                    listExample.Add(docExample);
                }
            }

            // recurse
            foreach (DocExample docSub in docExample.Examples)
            {
                BuildExampleList(listExample, docSub, docObject, included);
            }
        }


        /// <summary>
        /// Generates HTTP-compatible name for object
        /// </summary>
        /// <param name="docobj"></param>
        /// <returns></returns>
        public static string MakeLinkName(DocObject docobj)
        {
            if (docobj.Name == null)
                return docobj.Uuid.ToString();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < docobj.Name.Length; i++ )
            {
                Char ch = docobj.Name[i];
                if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9') || ch == '-' || ch == '_')
                {
                    sb.Append(ch);
                }
                else if (ch == ' ')
                {
                    sb.Append('-');
                }
            }

            return sb.ToString().ToLower();
        }

        /// <summary>
        /// If matching figure exists, generates HTML including the figure and increments the figure count.
        /// </summary>
        /// <param name="docProject">The project</param>
        /// <param name="definition">Object for which to find figure.</param>
        /// <param name="dtd">Optional template for which to find figure.</param>
        /// <param name="caption">Caption of definition used in determining figure caption, e.g. 'Beam'</param>
        /// <param name="listFigures">List of figures for determining numbering; appended as applicable by function.</param>
        /// <returns></returns>
        private static string FormatFigure(DocProject docProject, DocObject definition, DocTemplateDefinition dtd, string caption, List<ContentRef> listFigures, string path)
        {
            string title = null;
            string desc = null;
            if (!String.IsNullOrEmpty(caption))
            {
                title = caption;
                desc = caption.Substring(0, 1).ToUpper() + caption.Substring(1);
            }
            else
            {
                title = "<i>" + definition.Name + "</i>";
                desc = title;
            }

            StringBuilder sb = new StringBuilder();

            if (definition is DocDefinition) //TODO: property set figures
            {
                DocSchema docSchema = docProject.GetSchemaOfDefinition((DocDefinition)definition);

                string filename = MakeLinkName(definition);
                if (dtd != null)
                {
                    filename += "-" + MakeLinkName(dtd);
                }
                filename += ".png";

                string filepath = path + @"\figures\" + filename;
                if (System.IO.File.Exists(filepath))
                {
                    listFigures.Add(new ContentRef(desc, definition));

                    // "Sensor", "Port Use Definition" ==> "Sensor Port Use"
                    string figuredef = "usage";
                    if (dtd != null)
                    {
                        figuredef = dtd.Name.ToLower();
                    }

                    // Per ISO guidelines, all figures must be referenced from text.
                    sb.Append("<p>Figure ");
                    sb.Append(listFigures.Count);
                    sb.Append(" illustrates ");
                    sb.Append(title.ToLower());
                    sb.Append(" ");
                    sb.Append(figuredef.ToLower());
                    sb.Append(".</p>\r\n");

                    // include the figure with formatting below per ISO
                    sb.Append("<table><tr><td><img src=\"../../../figures/");
                    sb.Append(filename);
                    sb.Append("\" alt=\"");
                    sb.Append(figuredef);
                    sb.Append("\"></td></tr><tr><td><p class=\"figure\">Figure ");
                    sb.Append(listFigures.Count);
                    sb.Append(" &mdash; ");
                    sb.Append(desc);
                    sb.Append(" ");
                    sb.Append(figuredef);
                    sb.Append("</p></td></tr></table>\r\n");
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="docProject"></param>
        /// <param name="docModelView"></param>
        /// <param name="entity"></param>
        /// <param name="root"></param>
        /// <param name="usage">Optional usage or NULL to format table from concept root applicability</param>
        /// <param name="mapEntity"></param>
        /// <param name="mapSchema"></param>
        /// <returns></returns>
        private static string FormatConceptTable(
            DocProject docProject,
            DocModelView docModelView,
            DocEntity entity,
            DocConceptRoot root,
            DocTemplateUsage usage,
            Dictionary<string, DocObject> mapEntity,
            Dictionary<string, string> mapSchema)
        {
            StringBuilder sb = new StringBuilder();

            DocTemplateDefinition docTemplate = null;
            DocTemplateItem[] listItems = null;
            if (usage != null)
            {
                docTemplate = usage.Definition;
                listItems = FindTemplateItems(docProject, entity, usage.Definition, docModelView);

                if (usage.Override)
                {
                    listItems = usage.Items.ToArray();
                }

                if (listItems.Length == 0)
                {
                    // scenario for referenced inner templates
                    listItems = usage.Items.ToArray();
                }
            }
            else
            {
                docTemplate = root.ApplicableTemplate;
                listItems = root.ApplicableItems.ToArray();
            }

            // new way with table
            DocModelRule[] parameters = docTemplate.GetParameterRules();
            if (parameters != null && parameters.Length > 0 && listItems.Length > 0)
            {
                // check if descriptions are provided
                bool showdescriptions = false;
                foreach (DocTemplateItem item in listItems)
                {
                    if (item.Documentation != null)
                    {
                        showdescriptions = true;
                        break;
                    }
                }

                sb.AppendLine("<table class=\"gridtable\">");

                // header
                sb.Append("<tr>");
                foreach (DocModelRule parameter in parameters)
                {
                    sb.Append("<th><b>");

                    // hack until fixed in data
                    if (parameter.Identification.Equals("Name") && docTemplate.Name.Equals("External Data Constraints"))
                    {
                        sb.Append("Column");
                    }
                    else
                    {
                        sb.Append(parameter.Identification);
                    }
                    sb.Append("</b></th>");
                }
                if (showdescriptions)
                {
                    sb.Append("<th><b>Description</b></th>");
                }
                sb.AppendLine("</tr>");

                // items
                foreach (DocTemplateItem item in listItems)
                {
                    sb.Append("<tr>");
                    foreach (DocModelRule parameter in parameters)
                    {
                        string value = item.GetParameterValue(parameter.Identification);
                        string schema = null;

                        if(parameter.Name.Equals("Columns"))
                        {
                            parameter.ToString();
                        }

                        sb.Append("<td>");
                        //if (value != null)
                        {
                            DocDefinition docDef = docTemplate.GetParameterType(parameter.Identification, mapEntity);
                            if (docDef is DocEnumeration)
                            {
                                if(value != null)
                                {
                                    schema = mapSchema[docDef.Name];

                                    sb.Append("<a href=\"../../");
                                    sb.Append(schema.ToLower());
                                    sb.Append("/lexical/");
                                    sb.Append(docDef.Name.ToLower());
                                    sb.Append(".htm\">");
                                    sb.Append(value);
                                    sb.Append("</a>");
                                }
                            }
                            else if (docDef is DocEntity)
                            {
                                DocTemplateDefinition docTemplateInner = null;
                                if (parameter is DocModelRuleAttribute)
                                {
                                    DocModelRuleAttribute dma = (DocModelRuleAttribute)parameter;
                                    foreach(DocModelRule docInnerRule in dma.Rules)
                                    {
                                        if (docInnerRule is DocModelRuleEntity)
                                        {
                                            DocModelRuleEntity dme = (DocModelRuleEntity)docInnerRule;
                                            if (dme.References.Count == 1)
                                            {
                                                docTemplateInner = dme.References[0];

                                                DocTemplateUsage docConceptInner = item.GetParameterConcept(parameter.Identification, docTemplateInner);
                                                if (docConceptInner != null)
                                                {
                                                    string inner = FormatConceptTable(docProject, docModelView, (DocEntity)docDef, root, docConceptInner, mapEntity, mapSchema);
                                                    sb.Append("<a href=\"../../templates/" + MakeLinkName(docTemplateInner) + ".htm\">" + docTemplateInner.Name + "</a><br/>");
                                                    sb.Append(inner);
                                                }

                                            }
                                        }
                                    }
                                }

                                if (docTemplateInner == null && value != null && mapSchema.TryGetValue(value, out schema))
                                {
                                    if(value.StartsWith("Pset_"))
                                    {
                                        value.ToString();
                                    }

                                    sb.Append("<a href=\"../../");
                                    sb.Append(schema.ToLower());
                                    sb.Append("/lexical/");
                                    sb.Append(value.ToLower());
                                    sb.Append(".htm\">");
                                    sb.Append(value);
                                    sb.Append("</a>");
                                }
                                else if(docDef.Name.Equals("IfcReference"))
                                {
                                    // ...hyperlinks
                                    if(value != null)
                                    {
                                        string reftext = FormatReference(docProject, value);
                                        sb.Append(reftext);
                                    }
                                    //sb.Append(value);                                    
                                }
                                else if(value != null)
                                {
                                    sb.Append(value);
                                }
                            }
                            else if (docDef != null && value != null)
                            {
                                value = FormatField(docProject, value, value, docDef.Name, value);
                                sb.Append(value);
                            }
                            else if (value != null)
                            {
                                sb.Append(value);
                            }
                            else
                            {
                                sb.Append("&nbsp;");
                            }
                        }
                        sb.Append("</td>");
                    }

                    if (showdescriptions)
                    {
                        sb.Append("<td>");
                        if (item.Documentation != null)
                        {
                            sb.Append(item.Documentation);
                        }
                        else
                        {
                            sb.Append("&nbsp;");
                        }
                        sb.Append("</td>");
                    }

                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("</table>");
            }
            return sb.ToString();
        }

        private static string FormatReference(DocProject docProject, string value)
        {
            if (value == null)
                return null;

            StringBuilder sb = new StringBuilder();
            string[] parts = value.Split('\\');
            foreach (string part in parts)
            {
                string[] tokens = part.Split('.');
                if (tokens.Length > 0)
                {
                    sb.Append("\\");

                    DocDefinition docToken = docProject.GetDefinition(tokens[0]);
                    if (docToken != null)
                    {
                        DocSchema docSchema = docProject.GetSchemaOfDefinition(docToken);
                        string relative = @"../../";
                        string hyperlink = relative + docSchema.Name.ToLower() + @"/lexical/" + docToken.Name.ToLower() + ".htm";
                        string format = "<a href=\"" + hyperlink + "\">" + tokens[0] + "</a>";
                        sb.Append(format);
                    }

                    if (tokens.Length > 1)
                    {
                        sb.Append(".");
                        sb.Append(tokens[1]);
                    }

                    sb.Append("<br>");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Formats a template given an entity and optional template
        /// </summary>
        /// <param name="entity">The entity to format.</param>
        /// <param name="usage">Use definition to format, or null for all use definitions for entity.</param>
        /// <param name="iFigure">The last figure number used.</param>
        /// /// <param name="iFigure">The last table number used.</param>
        /// <returns></returns>
        private static string FormatConcept(
            DocProject docProject, 
            DocEntity entity, 
            DocConceptRoot root, 
            DocTemplateUsage usage, 
            Dictionary<string, DocObject> mapEntity, 
            Dictionary<string, string> mapSchema, 
            List<ContentRef> listFigures, 
            List<ContentRef> listTables,
            string path,
            DocPublication docPublication)
        {
            if (usage.Definition == null)
                return String.Empty;

            StringBuilder sb = new StringBuilder();

            string anchorid = MakeLinkName(usage.Definition);

            // anchor
            sb.Append("<a id=\"");
            sb.Append(anchorid);
            sb.Append("\" />");
            sb.AppendLine();

            string conceptcaption = usage.Name;
            if(String.IsNullOrEmpty(conceptcaption))
            {
                conceptcaption = usage.Definition.Name;
            }

            // Caption            
            sb.Append("<p class=\"use-head\">");
            sb.Append(conceptcaption);
            sb.Append("</p>");
            sb.AppendLine();

            // filter by particular model view
            DocModelView docModelView = null;
            if (root != null)
            {
                foreach (DocModelView docView in docProject.ModelViews)
                {
                    if (docView.ConceptRoots.Contains(root))
                    {
                        docModelView = docView;
                        break;
                    }
                }
            }

            // new (2.0): capture inherited properties too
            DocTemplateItem[] listItems = FindTemplateItems(docProject, entity, usage.Definition, docModelView);

            // add stock sentence

            // typical values: "Material Constituents", "Documents", "Aggregation", "Nesting", "Representations"
            // Usage of the <i>Material Constituents</i> concept is shown in Table XXXX.
            // Usage of the <i>Nesting</i> concept is shown in Table XXXX.
            // Usage of the <i>Aggregation</i> concept is shown in Table XXXX:

            // get link of usage
            string deflink = MakeLinkName(usage.Definition) + ".htm";

            if (listItems.Length > 0)
            {
                listTables.Add(new ContentRef(entity.Name + " " + usage.Definition.Name, entity));

                sb.Append("<p>The <a href=\"../../templates/");
                sb.Append(deflink);
                sb.Append("\">");
                sb.Append(usage.Definition.Name);
                sb.Append("</a> concept template applies to this entity as shown in Table ");
                sb.Append(listTables.Count);
                sb.Append(".");

                sb.AppendLine("<table>");
                sb.AppendLine("<tr><td>");

                string table = FormatConceptTable(docProject, docModelView, entity, root, usage, mapEntity, mapSchema);
                sb.Append(table);

                sb.AppendLine("</td></tr>");
                sb.Append("<tr><td><p class=\"table\">Table ");
                sb.Append(listTables.Count);
                sb.Append(" &mdash; ");
                sb.Append(entity.Name);
                sb.Append(" ");
                sb.Append(usage.Definition.Name);
                sb.AppendLine("</td></tr></table>");
                sb.AppendLine();
            }
            else
            {
                sb.Append("<p>The <a href=\"../../templates/");
                sb.Append(deflink);
                sb.Append("\">");
                sb.Append(usage.Definition.Name);
                sb.Append("</a> concept applies to this entity.</p>");
            }

            // add figure if it exists
            string fig = FormatFigure(docProject, entity, usage.Definition, entity.Text, listFigures, path);
            if (fig != null)
            {
                sb.Append(fig);
            }

            if (usage.Documentation != null)
            {
                sb.AppendLine(usage.Documentation); // special case if definition provides description, such as for classification
            }

            if (docPublication.Exchanges)
            {
                string req = FormatRequirements(usage, docModelView, true);
                if (req != null)
                {
                    sb.AppendLine(req);
                }
            }

            sb.AppendLine("<br/><br/>");

            return sb.ToString();
        }

        private static string FormatField(DocProject docProject, string content, string fieldname, string fieldtype, string fieldvalue)
        {
            DocDefinition docDef = docProject.GetDefinition(fieldtype);

            // hyperlink to enumerators
            if (docDef is DocEnumeration)
            {
                // hyperlink to enumeration definition

                // replace it with hyperlink
                DocSchema docSchema = docProject.GetSchemaOfDefinition(docDef);
                string relative = @"../../";
                string hyperlink = relative + docSchema.Name.ToLower() + @"/lexical/" + docDef.Name.ToLower() + ".htm";
                string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";

                return content.Replace(fieldname, format);
            }
            else if (docDef is DocEntity)//fieldvalue != null && fieldvalue.StartsWith("Ifc") && docProject.GetDefinition(fieldvalue) != null)
            {
                // replace it with hyperlink
                DocSchema docSchema = docProject.GetSchemaOfDefinition(docDef);
                string relative = @"../../";
                string hyperlink = relative + docSchema.Name.ToLower() + @"/lexical/" + docDef.Name.ToLower() + ".htm";
                string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";

                return content.Replace(fieldname, format);
            }
            else //if (docDef == null)
            {
                // hyperlink to property set definition
                DocSchema docSchema = null;
                DocObject docObj = docProject.FindPropertySet(fieldvalue, out docSchema);
                if (docObj is DocPropertySet)
                {
                    string relative = @"../../";
                    string hyperlink = relative + docSchema.Name.ToLowerInvariant() + @"/pset/" + docObj.Name.ToLower() + ".htm"; // case-sensitive on linux -- need to make schema all lowercase
                    string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";
                    return content.Replace(fieldname, format);
                }
                else if (docObj is DocQuantitySet)
                {
                    string relative = @"../../";
                    string hyperlink = relative + docSchema.Name.ToLowerInvariant() + @"/qset/" + docObj.Name.ToLower() + ".htm"; // case-sentive on linux -- need to make schema all lowercase
                    string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";
                    return content.Replace(fieldname, format);
                }

                if (docObj == null)
                {
                    // simple replace -- hyperlink may markup value later
                    return content.Replace(fieldname, fieldvalue);
                }
            }
            /*
            else
            {
                // simple replace -- hyperlink may markup value later
                return content.Replace(fieldname, fieldvalue);
            }*/

            return content;
        }

        private static void GenerateExample(
            DocPublication docPublication,
            DocExample docExample,
            List<DocXsdFormat> listFormats,
            string path,
            List<int> indexpath,
            Dictionary<DocObject, bool> included,
            Dictionary<string, DocObject> mapEntity,
            Dictionary<string, string> mapSchema,
            Dictionary<string, Type> typemap,
            List<ContentRef> listFigures, 
            List<ContentRef> listTables,
            FormatHTM htmTOC,
            FormatHTM htmSectionTOC,
            Dictionary<long, SEntity> outerinstancemap // instance data of parent example, if inherited
            )
        {
            if (included == null || included.ContainsKey(docExample))
            {
                indexpath[indexpath.Count - 1]++;

                StringBuilder indexpathname = new StringBuilder();
                indexpathname.Append("E");
                foreach(int x in indexpath)
                {
                    indexpathname.Append(".");
                    indexpathname.Append(x);
                }
                string indexpathstring = indexpathname.ToString();

                string pathExample = path + @"\annex\annex-e\" + MakeLinkName(docExample) + ".htm";
                using (FormatHTM htmExample = new FormatHTM(pathExample, mapEntity, mapSchema, included))
                {
                    htmExample.WriteHeader(docExample.Name, 2, docPublication.Header);
                    htmExample.WriteScript(-5, indexpath[0], 0, 0);
                    htmExample.WriteLine("<h3 class=\"std\">" + indexpathstring + " " + docExample.Name + "</h3>");

                    // table of files
                    if (docExample.File != null)
                    {
                        htmExample.Write("<table class=\"gridtable\">");
                        htmExample.Write("<tr><th>Format</th><th>ASCII</th><th>HTML</th></tr>");

                        foreach(DocFormat docFormat in docPublication.Formats)
                        {
                            if (docFormat.FormatOptions == DocFormatOptionEnum.Examples)
                            {
                                string ext = docFormat.ExtensionInstances;
                                htmExample.WriteLine("<tr><td>" + docFormat.FormatType.ToString() + "</td><td><a href=\"" + MakeLinkName(docExample) + "." + ext + "\">File</a></td><td><a href=\"" + MakeLinkName(docExample) + "." + ext + ".htm\">Markup</a></td></tr>");
                            }
                        }

                        htmExample.Write("</table>");

                        htmExample.Write("<table class=\"gridtable\">");
                        htmExample.Write("<tr><th>View</th></tr>");
                        foreach (DocModelView docView in docExample.Views)
                        {
                            if (included != null && included.ContainsKey(docView))
                            {
                                string hyperlink = "../../schema/views/" + MakeLinkName(docView) + "/index.htm";
                                htmExample.Write("<tr><td><a href=\"" + hyperlink + "\">" + docView.Name + "</td></tr>");
                            }
                        }
                        htmExample.Write("</table>");

                        if (docExample.ApplicableType != null)
                        {
                            string[] ApplicableTypesArray = docExample.ApplicableType.Split(',');
                            htmExample.Write("<table class=\"gridtable\">");
                            htmExample.Write("<tr><th>Entity</th></tr>");
                            for (int i = 0; i < ApplicableTypesArray.Length; i++)
                            {
                                string hyperlink = "../../schema/" + mapSchema[ApplicableTypesArray.GetValue(i).ToString()].ToString().ToLower() + "/lexical/" + ApplicableTypesArray.GetValue(i).ToString().ToLower() + ".htm";
                                htmExample.Write("<tr><td><a href=" + hyperlink + ">" + ApplicableTypesArray.GetValue(i) + "</td></tr>");
                            }
                            htmExample.Write("</table>");
                        }
                    }

                    docExample.Documentation = UpdateNumbering(docExample.Documentation, listFigures, listTables, docExample);

                    htmExample.WriteDocumentationMarkup(docExample.Documentation, docExample, docPublication);

                    if (docExample.File == null && outerinstancemap != null)
                    {
                        // if specific to exchange, capture inline
                        if (docExample.Views.Count > 0)
                        {
                            // hack for now based on example name matching exchange name -- make explicit later
                            foreach (DocExchangeDefinition docExchange in docExample.Views[0].Exchanges)
                            {
                                if (docExample.Name.Equals(docExchange.Name))
                                {
                                    // matches -- generate
                                    FormatSQL fmt = new FormatSQL();
                                    string content = fmt.FormatData(docPublication, docExchange, mapEntity, outerinstancemap);
                                    htmExample.Write(content);
                                    break;
                                }
                            }
                        }
                    }

                    htmExample.WriteLinkTo(docExample);
                    htmExample.WriteFooter(docPublication.Footer);
                }

                if (docExample.File != null && !Properties.Settings.Default.SkipDiagrams)
                {
                    string pathIFC = path + @"\annex\annex-e\" + MakeLinkName(docExample) + ".ifc";
                    using (System.IO.FileStream filestream = new System.IO.FileStream(pathIFC, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Read))
                    {
                        filestream.Write(docExample.File, 0, docExample.File.Length);
                    }

                    using (FormatSPF spfExample = new FormatSPF(new System.IO.MemoryStream(docExample.File, false), typemap, null))
                    {
                        string pathListing = path + @"\annex\annex-e\" + MakeLinkName(docExample) + ".ifc.htm";

                        if (docPublication.GetFormatOption(DocFormatTypeEnum.STEP) == DocFormatOptionEnum.Examples)//Properties.Settings.Default.ExampleSPF)
                        {
                            using (FormatHTM htmListing = new FormatHTM(pathListing, mapEntity, mapSchema, included))
                            {
                                htmListing.WriteHeader(docExample.Name, 2, docPublication.Header);

                                htmListing.WriteLine("<tt class=\"spf\">");
                                string htm = null;
                                try
                                {
                                    htm = spfExample.LoadMarkup();
                                    outerinstancemap = spfExample.Instances;
                                }
                                catch
                                {
                                }
                                htmListing.Write(htm);
                                htmListing.Write("</tt>");
                                htmListing.WriteFooter(String.Empty);
                            }
                        }
#if false
                        else if(Properties.Settings.Default.ExampleXML)
                        {
                            // must load file in any case in order to generate xml
                            try
                            {
                                spfExample.Load();
                            }
                            catch
                            {
                            }
                        }
#endif

                        // find the IfcProject
                        SEntity rootproject = null;
                        foreach (SEntity ent in spfExample.Instances.Values)
                        {
                            if (ent.GetType().Name.Equals("IfcProject"))
                            {
                                rootproject = ent;
                                break;
                            }
                        }

                        foreach (DocFormat docFormat in docPublication.Formats)
                        {
                            // generate example in other formats...
                            if (docFormat.FormatOptions == DocFormatOptionEnum.Examples)
                            {
                                switch(docFormat.FormatType)
                                {
                                    case DocFormatTypeEnum.STEP:
                                        break; // do nothing

                                    case DocFormatTypeEnum.XML:
                                        {

                                            // use xml namespace of first view
                                            string xmlns = "http://www.buildingsmart-tech.org/ifcXML/IFC4/final";
                                            if (docExample.Views.Count > 0 && !String.IsNullOrEmpty(docExample.Views[0].XsdUri))
                                            {
                                                xmlns = docExample.Views[0].XsdUri;
                                            }

                                            string pathXML = path + @"\annex\annex-e\" + MakeLinkName(docExample) + ".ifcxml";
                                            using (FormatSML xmlExample = new FormatSML(new System.IO.FileStream(pathXML, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite), listFormats, xmlns, docPublication.Code))
                                            {
                                                xmlExample.Instance = rootproject;
                                                xmlExample.Save();
                                            }

                                            string pathXMH = path + @"\annex\annex-e\" + MakeLinkName(docExample) + ".ifcxml.htm";
                                            using (FormatSML xmlExample = new FormatSML(new System.IO.FileStream(pathXMH, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite), listFormats, xmlns, docPublication.Code))
                                            {
                                                xmlExample.Instance = rootproject;
                                                xmlExample.Markup = true;
                                                xmlExample.Save();
                                            }
                                        }
                                        break;

                                    case DocFormatTypeEnum.SQL: // todo: support others...
                                        // use formatter
                                        {
                                            FormatSQL fmt = new FormatSQL();
                                            string content = fmt.FormatData(docPublication, null, mapEntity, spfExample.Instances);

                                            string pathRAW = path + @"\annex\annex-e\" + MakeLinkName(docExample) + "." + docFormat.ExtensionInstances;                                            
                                            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(pathRAW, false))
                                            {
                                                writer.Write(content);
                                            }

                                            string pathHTM = pathRAW + ".htm";
                                            using (FormatHTM fmtHTM = new FormatHTM(pathHTM, mapEntity, mapSchema, included))
                                            {
                                                fmtHTM.WriteHeader(docExample.Name, 2, docPublication.Header);
                                                fmtHTM.Write(content);
                                                fmtHTM.WriteFooter("");
                                            }
                                        }
                                        break;
                                }
                            }
                        }


                    }

                }

                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docExample) + ".htm", mapEntity, mapSchema, included))
                {
                    string linkurl = "../annex/annex-e/" + MakeLinkName(docExample) + ".htm";
                    htmLink.WriteLinkPage(linkurl, docPublication);
                }

                string urlExample = "annex-e/" + MakeLinkName(docExample) + ".htm";
                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/" + urlExample + "\" >" + indexpathstring + " " + docExample.Name + "</a>");

                string linkid = "";
                if(indexpath.Count == 1)
                {
                    linkid = indexpath[0].ToString();
                }
                string htmllink = "<a class=\"listing-link\" id=\"" + linkid + "\" href=\"" + urlExample + "\" target=\"info\">" + docExample.Name + "</a>";
                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + indexpathstring + " " + htmllink + "</td></tr>");

                if (docExample.Examples.Count > 0)
                {
                    indexpath.Add(0);
                    foreach(DocExample docSub in docExample.Examples)
                    {
                        GenerateExample(docPublication, docSub, listFormats, path, indexpath, included, mapEntity, mapSchema, typemap, listFigures, listTables, htmTOC, htmSectionTOC, outerinstancemap);
                    }
                    indexpath.RemoveAt(indexpath.Count - 1);
                }
            }

        }

        /// <summary>
        /// Generates documentation for template and all sub-templates recursively.
        /// </summary>
        /// <param name="docTemplate"></param>
        /// <param name="indexpath"></param>
        /// <param name="listFigures"></param>
        /// <param name="listTables"></param>
        private static void GenerateTemplate(
            DocProject docProject, 
            DocTemplateDefinition docTemplate, 
            Dictionary<string, DocObject> mapEntity, 
            Dictionary<string, string> mapSchema, 
            Dictionary<DocObject, bool> included, 
            int[] indexpath, 
            List<ContentRef> listFigures, 
            List<ContentRef> listTables,
            DocPublication docPublication,
            string path)
        {
            string pathTemplate = path + @"\schema\templates\" + MakeLinkName(docTemplate) + ".htm";
            using (FormatHTM htmTemplate = new FormatHTM(pathTemplate, mapEntity, mapSchema, included))
            {
                htmTemplate.WriteHeader(docTemplate.Name, 2, docPublication.Header);

                string indexer = "";
                foreach (int part in indexpath)
                {
                    if (indexer.Length != 0)
                    {
                        indexer += ".";
                    }
                    indexer += part.ToString();
                }

                htmTemplate.WriteLine(
                     "\r\n" +
                     "<script type=\"text/javascript\">\r\n" +
                     "<!--\r\n" +
                     "    parent.index.location.replace(\"../toc-4.htm#" + indexer + "\");\r\n" +
                     "//-->\r\n" +
                     "</script>\r\n");

                string tag = "h" + indexpath.Length.ToString(); // e.g. <h3>
                string id = MakeLinkName(docTemplate);
                htmTemplate.WriteLine("<" + tag + " class=\"std\">" + indexer + " " + docTemplate.Name + "</" + tag + ">");

                string doc = FormatTemplate(docProject, docTemplate, listFigures, listTables, mapEntity, mapSchema, included, path);
                htmTemplate.WriteDocumentationMarkup(doc, docTemplate, docPublication);

                if (docProject.Examples != null)
                {
                    List<DocExample> listExample = new List<DocExample>();
                    foreach (DocExample docExample in docProject.Examples)
                    {
                        BuildExampleList(listExample, docExample, docTemplate, included);
                    }
                    if (listExample.Count > 0)
                    {
                        htmTemplate.WriteLine("<p class=\"spec-head\">Examples:</p>");
                        htmTemplate.WriteLine("<ul>");
                        foreach (DocExample docExample in listExample)
                        {
                            if (docExample.Name != null)
                            {
                                htmTemplate.Write("<li><a href=\"../../annex/annex-e/");
                                htmTemplate.Write(MakeLinkName(docExample));
                                htmTemplate.Write(".htm\">");
                                htmTemplate.Write(docExample.Name);
                                htmTemplate.Write("</a></li>");
                                htmTemplate.WriteLine("");
                            }
                        }
                        htmTemplate.WriteLine("</ul>");
                    }
                }

                // write url for incoming page link                
                htmTemplate.WriteLinkTo(docTemplate);

                htmTemplate.WriteFooter(docPublication.Footer);
            }

            // recurse
            int iTemplate = 0;
            foreach (DocTemplateDefinition docSubTemplate in docTemplate.Templates)
            {
                if (included == null || included.ContainsKey(docSubTemplate))
                {
                    iTemplate++;
                    int[] subindexpath = new int[indexpath.Length + 1];
                    indexpath.CopyTo(subindexpath, 0);
                    subindexpath[subindexpath.Length - 1] = iTemplate;
                    GenerateTemplate(docProject, docSubTemplate, mapEntity, mapSchema, included, subindexpath, listFigures, listTables, docPublication, path);
                }
            }
        }

        private static string FormatEntityDescription(
            DocProject docProject,
            DocEntity entity,
            List<ContentRef> listFigures,
            List<ContentRef> listTables)
        {
            StringBuilder sb = new StringBuilder();
            entity.Documentation = UpdateNumbering(entity.Documentation, listFigures, listTables, entity);
            sb.Append(entity.Documentation);
            return sb.ToString();
        }

        private static string FormatEntityConcepts(
            DocProject docProject, 
            DocEntity entity, 
            Dictionary<string, DocObject> mapEntity, 
            Dictionary<string, string> mapSchema, 
            Dictionary<DocObject, bool> included, 
            List<ContentRef> listFigures, 
            List<ContentRef> listTables,
            string path,
            DocPublication docPublication)
        {
            if(entity.Name.Equals("IfcElement"))
            {
                entity.ToString();
            }

            StringBuilder sb = new StringBuilder();

            // find concepts for entity
            foreach (DocModelView docView in docProject.ModelViews)
            {
                if (included == null || included.ContainsKey(docView))
                {
                    // check if there are any applicable concepts
                    bool hasConceptsAtEntity = false;
                    foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                    {
                        if (docRoot.ApplicableEntity == entity)
                        {
                            hasConceptsAtEntity = true;
                        }
                    }

                    // inherited use definitions

                    // build list of inherited views
                    DocModelView[] listViews = docProject.GetViewInheritance(docView);
                    
                    List<string> listLines = new List<string>();
                    Dictionary<DocTemplateDefinition, DocTemplateUsage> mapSuper = new Dictionary<DocTemplateDefinition, DocTemplateUsage>();
                    List<DocTemplateDefinition> listSuppress = new List<DocTemplateDefinition>();
                    List<DocTemplateDefinition> listOverride = new List<DocTemplateDefinition>();
                    DocEntity docSuper = entity;
                    while (docSuper != null)
                    {
                        StringBuilder sbSuper = new StringBuilder();

                        // find parent concept roots
                        bool renderclass = false;
                        foreach (DocModelView docViewBase in listViews)
                        {
                            foreach (DocConceptRoot docSuperRoot in docViewBase.ConceptRoots)
                            {
                                if (docSuperRoot.ApplicableEntity == docSuper)
                                {
                                    string schema = mapSchema[docSuper.Name].ToLower();
                                    
                                    foreach (DocTemplateUsage docSuperUsage in docSuperRoot.Concepts)
                                    {
                                        bool flag = false;
                                        if (docSuperUsage.Suppress)
                                        {
                                            if (!listSuppress.Contains(docSuperUsage.Definition))
                                            {
                                                listSuppress.Add(docSuperUsage.Definition);
                                                flag = true;
                                            }
                                        }
                                        else if (docSuperUsage.Override)
                                        {
                                            if (!listOverride.Contains(docSuperUsage.Definition))
                                            {
                                                listOverride.Add(docSuperUsage.Definition);
                                                flag = true;
                                            }
                                        }

                                        if (docSuperUsage.Definition != null && !mapSuper.ContainsKey(docSuperUsage.Definition) && !docSuperUsage.Suppress)
                                        {
                                            if (!renderclass)
                                            {
                                                renderclass = true;

                                                sbSuper.Append("<tr><td colspan=\"3\">");
                                                sbSuper.Append("<a href=\"../../" + schema + "/lexical/" + MakeLinkName(docSuper) + ".htm\">");
                                                if (docSuper.IsAbstract())
                                                {
                                                    sbSuper.Append("<i>");
                                                    sbSuper.Append(docSuper.Name);
                                                    sbSuper.Append("</i>");
                                                }
                                                else
                                                {
                                                    sbSuper.Append(docSuper.Name);
                                                }
                                                sbSuper.Append("</a></td></tr>");
                                            }

                                            bool suppress = listSuppress.Contains(docSuperUsage.Definition);
                                            bool overiden = listOverride.Contains(docSuperUsage.Definition);

                                            foreach(DocTemplateDefinition dtd in listSuppress)
                                            {
                                                if (docSuperUsage.Definition == dtd || docSuperUsage.Definition.Templates.Contains(dtd))
                                                {
                                                    suppress = true;
                                                    break;
                                                }
                                            }

                                            foreach (DocTemplateDefinition dtd in listOverride)
                                            {
                                                if (docSuperUsage.Definition == dtd || docSuperUsage.Definition.Templates.Contains(dtd))
                                                {
                                                    overiden = true;
                                                    break;
                                                }
                                            }

                                            if(flag)
                                            {
                                                suppress = false;
                                                overiden = false;
                                            }

                                            sbSuper.Append("<tr><td> </td><td>");

                                            mapSuper.Add(docSuperUsage.Definition, docSuperUsage);

                                            string templateid = MakeLinkName(docSuperUsage.Definition);

                                            sbSuper.Append("<a href=\"../../");
                                            sbSuper.Append(schema);
                                            sbSuper.Append("/lexical/" + MakeLinkName(docSuper) + ".htm#" + templateid + "\">");
                                            if (suppress || overiden)
                                            {
                                                sbSuper.Append("<del>");
                                            }
                                            if (!String.IsNullOrEmpty(docSuperUsage.Name))
                                            {
                                                sbSuper.Append(docSuperUsage.Name);
                                            }
                                            else
                                            {
                                                sbSuper.Append(docSuperUsage.Definition.Name);
                                            }
                                            if (suppress || overiden)
                                            {
                                                sbSuper.Append("</del>");
                                            }
                                            sbSuper.Append("</a>");
                                            if(overiden)
                                            {
                                                sbSuper.Append(" (overridden)");
                                            }
                                            else if(suppress)
                                            {
                                                sbSuper.Append(" (suppressed)");
                                            }

                                            sbSuper.Append("</td><td>");
                                            sbSuper.Append("<a href=\"../../templates/" + MakeLinkName(docSuperUsage.Definition) + ".htm\">" + docSuperUsage.Definition + "</a>");
                                            sbSuper.Append("</td><td>");
                                            sbSuper.Append(docViewBase.Name);
                                            sbSuper.Append("</td></tr>");
                                            sbSuper.AppendLine();
                                        }
                                    }

                                }
                            }
                        }

                        listLines.Add(sbSuper.ToString());

                        // go to base type
                        docSuper = docProject.GetDefinition(docSuper.BaseDefinition) as DocEntity;
                    }

                    if (hasConceptsAtEntity || listLines.Count > 0)
                    {
                        sb.AppendLine("<section>");
                        sb.AppendLine("<h5 class=\"num\">Definitions applying to " + docView.Name + "</h5>");

                        // link to instance diagram
                        if (hasConceptsAtEntity)
                        {
                            string linkdiagram = MakeLinkName(docView) + "/" + MakeLinkName(entity) + ".htm";
                            sb.Append("<p><a href=\"../../../annex/annex-d/" + linkdiagram + "\"><img style=\"border: 0px\" src=\"../../../img/diagram.png\" />&nbsp;Instance diagram</a></p>");
                        }

                        sb.AppendLine("<hr />");

                        foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                        {
                            if (docRoot.ApplicableEntity == entity)
                            {
                                sb.Append("<h5>" + docRoot.Name + "</h5>");

                                if (docRoot.ApplicableTemplate != null)
                                {
                                    string applicabletemplatetable = FormatConceptTable(docProject, docView, entity, docRoot, null, mapEntity, mapSchema);
                                    sb.Append(applicabletemplatetable);
                                }

                                sb.Append(docRoot.Documentation);

                                if (docRoot.Concepts.Count > 0)
                                {
                                    sb.AppendLine("<details open=\"open\">");
                                    sb.AppendLine("<summary>Concept usage</summary>");
                                    foreach (DocTemplateUsage eachusage in docRoot.Concepts)
                                    {
                                        FormatEntityUsage(docProject, entity, docRoot, eachusage, mapEntity, mapSchema, listFigures, listTables, included, sb, path, docPublication);
                                    }
                                    sb.AppendLine("</details>");
                                }



                            }
                        }
                    }


                    // now format inherited use definitions
                    if (listLines.Count > 0)
                    {
                        sb.AppendLine("<section>");

                        sb.AppendLine("<details>");
                        sb.AppendLine("<summary>Concept inheritance</summary>");
                        sb.AppendLine("<p><table class=\"attributes\">");
                        sb.AppendLine("<tr><th><b>#</b></th><th><b>Concept</b></th><th><b>Template</b></th><th><b>Model View</b></th></tr>");
                        for (int iLine = listLines.Count - 1; iLine >= 0; iLine--)
                        {
                            // reverse order
                            sb.AppendLine(listLines[iLine]);
                        }
                        sb.AppendLine("</table>");
                        sb.AppendLine("</details>");
                        sb.AppendLine("</section>");

                    }


                    sb.AppendLine("</section>");
                }
            }

            sb = sb.Replace("<EPM-HTML>", "");
            sb = sb.Replace("</EPM-HTML>", "");

            return sb.ToString();
        }

        private static void FormatEntityUsage(DocProject docProject, DocEntity entity, DocConceptRoot docRoot, DocTemplateUsage eachusage, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, List<ContentRef> listFigures, List<ContentRef> listTables, Dictionary<DocObject, bool> included, StringBuilder sb, string path, DocPublication docPublication)
        {
            if (eachusage.Definition != null)
            {
                if (included == null || included.ContainsKey(eachusage.Definition))
                {
                    if (eachusage.Documentation != null)
                    {
                        eachusage.Documentation = UpdateNumbering(eachusage.Documentation, listFigures, listTables, entity);
                    }

                    string eachtext = FormatConcept(docProject, entity, docRoot, eachusage, mapEntity, mapSchema, listFigures, listTables, path, docPublication);
                    sb.Append(eachtext);
                    sb.AppendLine();

                    if (eachusage.Concepts.Count > 0)
                    {
                        sb.AppendLine("<details>");
                        sb.AppendLine("<summary>Concept alternates</summary>");

                        foreach (DocTemplateUsage innerusage in eachusage.Concepts)
                        {
                            FormatEntityUsage(docProject, entity, docRoot, innerusage, mapEntity, mapSchema, listFigures, listTables, included, sb, path, docPublication);
                        }
                        sb.AppendLine("</details>");
                    }
                }
            }
        }


        /// <summary>
        /// Updates content containing figure references
        /// </summary>
        /// <param name="html">Content to parse</param>
        /// <param name="figurenumber">Last figure number; returns updated last figure number</param>
        /// <param name="tablenumber">Last table number; returns updated last table number</param>
        /// <returns>Updated content</returns>
        private static string UpdateNumbering(string html, List<ContentRef> listFigures, List<ContentRef> listTables, DocObject target)
        {
            if (html == null)
                return null;

            html = UpdateNumbering(html, "Figure", "figure", listFigures, target);
            html = UpdateNumbering(html, "Table", "table", listTables, target);
            return html;
        }

        /// <summary>
        /// Updates numbering of figures or tables within HTML text
        /// </summary>
        /// <param name="html">The existing HTML</param>
        /// <param name="tag">The caption to find -- either 'Figure' or 'Table'</param>
        /// <param name="style">The style to find -- either 'figure' or 'table'</param>
        /// <param name="listRef">List of items where numbering begins and items are added.</param>
        /// <returns>The new HTML with figures or numbers updated</returns>
        private static string UpdateNumbering(string html, string tag, string style, List<ContentRef> listRef, DocObject target)
        {
            List<int> list = new List<int>();

            // first get numbers of existing figures (must be unique within page)
            int index = 0;
            for (int count = 0; ; count++)
            {
                index = html.IndexOf("<p class=\"" + style + "\">", index);
                if (index == -1)
                    break;

                // <p class="figure">Figure 278 &mdash; Circle geometry</p>
                // <p class="table">Table 278 &mdash; Circle geometry</p>

                // get the existing figure number, add it to list
                int head = index + 13 + tag.Length * 2; // was 25
                int tail = html.IndexOf(" &mdash;", index);
                if (tail > head)
                {
                    string exist = html.Substring(head, tail - head);
                    int result = 0;
                    if (Int32.TryParse(exist, out result))
                    {
                        list.Add(result);


                        int endcaption = html.IndexOf("<", tail);
                        string figuretext = html.Substring(tail + 9, endcaption - tail - 9);

                        listRef.Add(new ContentRef(figuretext, target));
                    }
                }

                index++;
            }

            // renumber in two phases (to avoid renumbering same)

            // now renumber
            for (int i = 0; i < list.Count; i++)
            {
                string captionold = tag + " " + list[i].ToString();// +" ";
                string captionnew = tag + "#" + (listRef.Count + i + 1).ToString();// +" ";

                // handle cases of space, comma, and period following figure reference
                html = html.Replace(captionold + " ", captionnew + " ");
                html = html.Replace(captionold + ",", captionnew + ",");
                html = html.Replace(captionold + ".", captionnew + ".");
            }

            // then replace all
            html = html.Replace(tag + "#", tag + " ");

            //itemnumber += list.Count;

            return html;
        }

        public static void Generate(
            DocProject docProject,
            string path,
            Dictionary<long, SEntity> instances,
            Dictionary<string, DocObject> mapEntity,
            Dictionary<string, string> mapSchema,
            DocPublication[] publications,
            BackgroundWorker worker,
            FormProgress formProgress)
        {
            foreach (DocPublication docPub in publications)
            {
                string relpath = path + @"\" + MakeLinkName(docPub);
                //GeneratePublicationStub(docProject, relpath, instances, mapEntity, mapSchema, docPub, worker, formProgress);
                GeneratePublication(docProject, relpath, instances, mapEntity, mapSchema, docPub, worker, formProgress);
            }

        }

        public static void GeneratePublicationStub(
            DocProject docProject,
            string path,
            Dictionary<long, SEntity> instances,
            Dictionary<string, DocObject> mapEntity,
            Dictionary<string, string> mapSchema,
            DocPublication docPublication,
            BackgroundWorker worker,
            FormProgress formProgress)
        {
            instances.Clear(); // clear out old state from mvdxml export
            docPublication.ErrorLog.Clear();


            Dictionary<DocFormatTypeEnum, IFormatExtension> mapFormats = new Dictionary<DocFormatTypeEnum, IFormatExtension>();
            foreach (DocFormat docFormat in docPublication.Formats)
            {
               switch (docFormat.FormatType)
               {
                  case DocFormatTypeEnum.OWL:
                     mapFormats.Add(docFormat.FormatType, new FormatOWL());
                     break;
               }
            }

            int iSection = 0;
            foreach (DocSection section in docProject.Sections)
            {
                iSection++;


                // each schema
                int iSchema = 0;
                foreach (DocSchema schema in section.Schemas)
                {
                        iSchema++;

                    // each type
                    if (schema.Types.Count > 0)
                    {

                        int iType = 0;

                        foreach (DocType type in schema.Types)
                        {

                            if (type.Name.Equals("IfcNullStyle", StringComparison.OrdinalIgnoreCase) && schema.Name.Equals("IfcConstructionMgmtDomain", StringComparison.OrdinalIgnoreCase))
                            {
                                // bug -- exclude
                            }
                            else
                            {
                                //using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + type.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                //{
                                    foreach (DocFormat docFormat in docPublication.Formats)
                                    {
                                        if (docFormat.FormatOptions != DocFormatOptionEnum.None)
                                        {
                                            // future: componentize all formats
                                            IFormatExtension formatext = null;
                                            mapFormats.TryGetValue(docFormat.FormatType, out formatext);
                                            switch (docFormat.FormatType)
                                            {
                                                case DocFormatTypeEnum.XML:
                                                    Console.Out.WriteLine("XSD Specification");
                                                    if (type is DocSelect)
                                                    {
                                                    Console.Out.WriteLine(FormatXSD.FormatSelect((DocSelect)type, mapEntity, null));
                                                    }
                                                    else if (type is DocEnumeration)
                                                    {
                                                    Console.Out.WriteLine(FormatXSD.FormatEnum((DocEnumeration)type));
                                                    }
                                                    else if (type is DocDefined)
                                                    {
                                                    Console.Out.WriteLine(FormatXSD.FormatDefined((DocDefined)type, mapEntity));
                                                    }
                                                    break;
                                                

                                                default:
                                                Console.Out.WriteLine("OWL or else");
                                                    if (formatext != null)
                                                    {
                                                       if (type is DocSelect)
                                                       {
                                                          Console.Out.WriteLine(formatext.FormatSelect((DocSelect)type, mapEntity, null));
                                                       }
                                                       else if (type is DocEnumeration)
                                                       {
                                                           Console.Out.WriteLine(formatext.FormatEnumeration((DocEnumeration)type));
                                                       }
                                                       else if (type is DocDefined)
                                                       {
                                                           Console.Out.WriteLine(formatext.FormatDefined((DocDefined)type));
                                                       }
                                                    }
                                                    break;
                                            }
                                        }
                                    //}
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void GeneratePublication(
            DocProject docProject, 
            string path,
            Dictionary<long, SEntity> instances,
            Dictionary<string, DocObject> mapEntity, 
            Dictionary<string, string> mapSchema, 
            DocPublication docPublication,
            BackgroundWorker worker, 
            FormProgress formProgress)
        {
            instances.Clear(); // clear out old state from mvdxml export
            docPublication.ErrorLog.Clear();

            DiagramFormat diagramformat = DiagramFormat.ExpressG;
            if(docPublication.UML)
            {
                diagramformat = DiagramFormat.UML;
            }

            DocModelView[] views = docPublication.Views.ToArray();
            string[] locales = docPublication.Locales.ToArray();

            Dictionary<DocFormatTypeEnum, IFormatExtension> mapFormats = new Dictionary<DocFormatTypeEnum, IFormatExtension>();
            foreach(DocFormat docFormat in docPublication.Formats)
            {
                switch(docFormat.FormatType)
                {
                    case DocFormatTypeEnum.OWL:
                        mapFormats.Add(docFormat.FormatType, new FormatOWL());
                        break;

                    case DocFormatTypeEnum.SQL:
                        mapFormats.Add(docFormat.FormatType, new FormatSQL());
                        break;

                    case DocFormatTypeEnum.CS:
                        mapFormats.Add(docFormat.FormatType, new FormatCSC());
                        break;

                    case DocFormatTypeEnum.JSON:
                        mapFormats.Add(docFormat.FormatType, new FormatJAV());
                        break;
                }
            }

            // copy over static content * if it doesn't already exist *
            string pathContent = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (pathContent.EndsWith(@"bin\x86\Debug") || pathContent.EndsWith(@"bin\x64\Debug")) // debugging
            {
                pathContent = System.IO.Path.GetDirectoryName(pathContent);
                pathContent = System.IO.Path.GetDirectoryName(pathContent);
                pathContent = System.IO.Path.GetDirectoryName(pathContent);
            }
            pathContent = System.IO.Path.Combine(pathContent, "content");

            if(!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            CopyFiles(pathContent, path);

            System.IO.Directory.CreateDirectory(path + "\\diagrams");

            Dictionary<string, DocPropertyEnumeration> mapPropEnum = new Dictionary<string, DocPropertyEnumeration>();
            foreach (DocSection docSection in docProject.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocPropertyEnumeration docEnum in docSchema.PropertyEnums)
                    {
                        mapPropEnum.Add(docEnum.Name, docEnum);
                    }
                }
            }

            Dictionary<DocObject, string> mapNumber = new Dictionary<DocObject, string>(); // map items to section (e.g. "1.1.1.1")

            string pathSchema = path + @"\schema";

            // count progress
            int progressTotal = docProject.Sections.Count + docProject.Annexes.Count + 2;
            formProgress.SetProgressTotal(progressTotal);
            worker.ReportProgress(0, "================================================================================");
            worker.ReportProgress(0, docPublication);

            int progressCurrent = 0;


            // build list of locales in use
            SortedList<string, string> listLocale = new SortedList<string, string>();
            foreach (DocObject eachobj in mapEntity.Values)
            {
                if (eachobj.Localization != null)
                {
                    foreach (DocLocalization doclocal in eachobj.Localization)
                    {
                        // only deal with languages, not regions
                        if (doclocal.Locale != null && doclocal.Locale.Length >= 2)
                        {
                            string language = doclocal.Locale.Substring(0, 2);

                            if (!listLocale.ContainsKey(language))
                            {
                                listLocale.Add(language, doclocal.Locale);
                            }
                        }
                    }
                }
            }

            // build filter
            Dictionary<DocObject, bool> included = null;
            if (views != null)
            {
                included = new Dictionary<DocObject, bool>();
                foreach (DocModelView docEachView in views)
                {
                    docProject.RegisterObjectsInScope(docEachView, included);
                }
            }

            Dictionary<DocObject, bool>[] dictionaryViews = new Dictionary<DocObject, bool>[docProject.ModelViews.Count];
            for (int i = 0; i < docProject.ModelViews.Count; i++)
            {
                DocModelView docView = docProject.ModelViews[i];
                if (included != null && included.ContainsKey(docView))
                {
                    dictionaryViews[i] = new Dictionary<DocObject, bool>();
                    docProject.RegisterObjectsInScope(docProject.ModelViews[i], dictionaryViews[i]);
                }
            }


            DocEntity docEntityRoot = docProject.GetDefinition("IfcRoot") as DocEntity;

            // upper contents page
            string pathHeaderFrame = path + "\\content.htm";
            using (FormatHTM htmProp = new FormatHTM(pathHeaderFrame, mapEntity, mapSchema, included))
            {
                string projectname = docPublication.Code;
                if (!String.IsNullOrEmpty(docPublication.Version))
                {
                    projectname += " - " + docPublication.Version;
                }
                if (!String.IsNullOrEmpty(docPublication.Status))
                {
                    projectname += " [" + docPublication.Status + "]";
                }
                string projectcopy = docPublication.Copyright;

                htmProp.Write(
"<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">\r\n" + 
"<html lang=\"en\">" + 
  "<head>" +
    "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=us-ascii\">" +
    "<link rel=\"STYLESHEET\" href=\"./ifc-styles.css\" type=\"text/css\">" +
  "</head>" +
  "<body class=\"image\">" +
    "<div class=\"content\">" +
      "<table summary=\"title\" class=\"content\" frameborder=\"0\">" +
        "<tr>" +
          "<td>" +
            "<p class=\"td\">" +
              "<b>" + projectname + "</b>" +
            "</p>" +
          "</td>" +
          "<td>" +
            "<p class=\"td right\">" +
              "<b>" + projectcopy + "</b>" +
            "</p>" +
          "</td>" +
        "</tr>" +
      "</table>" +
      "<table summary=\"short table of content\" class=\"content\">" +
        "<col width=\"15%\">" +
        "<col width=\"25%\">" +
        "<col width=\"20%\">" +
        "<col width=\"25%\">" +
        "<col width=\"15%\">" +
        "<tr>" +
          "<td class=\"content\">" +
            "<ol class=\"td none\">" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"cover.htm\" target=\"info\">Cover</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"toc.htm\" target=\"info\">Contents</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"foreword.htm\" target=\"info\">" + docPublication.Annotations[0].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"introduction.htm\" target=\"info\">" + docPublication.Annotations[1].Name + "</a></li>" +
            "</ol>" +
          "</td>" +
          "<td class=\"content\">" +
            "<ol class=\"td num\">" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"schema/chapter-1.htm\" target=\"info\">" + docProject.Sections[0].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"schema/chapter-2.htm\" target=\"info\">" + docProject.Sections[1].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"schema/chapter-3.htm\" target=\"info\">" + docProject.Sections[2].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"schema/chapter-4.htm\" target=\"info\">" + docProject.Sections[3].Name + "</a></li>" +
            "</ol>" +
          "</td>" +
          "<td class=\"content\">" +
            "<ol class=\"td num\" start=\"5\">" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"schema/chapter-5.htm\" target=\"info\">" + docProject.Sections[4].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"schema/chapter-6.htm\" target=\"info\">" + docProject.Sections[5].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"schema/chapter-7.htm\" target=\"info\">" + docProject.Sections[6].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"schema/chapter-8.htm\" target=\"info\">" + docProject.Sections[7].Name + "</a></li>" +
            "</ol>" +
          "</td>" +
          "<td class=\"content\">" +
            "<ol class=\"td alpha\">" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"annex/annex-a.htm\" target=\"info\">" + docProject.Annexes[0].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"annex/annex-b.htm\" target=\"info\">" + docProject.Annexes[1].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"annex/annex-c.htm\" target=\"info\">" + docProject.Annexes[2].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"annex/annex-d.htm\" target=\"info\">" + docProject.Annexes[3].Name + "</a></li>" +
            "</ol>" +
          "</td>" +
          "<td class=\"content\">" +
            "<ol class=\"td alpha\" start=\"5\">" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"annex/annex-e.htm\" target=\"info\">" + docProject.Annexes[4].Name + "</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"annex/annex-f.htm\" target=\"info\">" + docProject.Annexes[5].Name + "</a></li>" +
            "</ol>" +
            "<ol class=\"td none\">" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"bibliography.htm\" target=\"info\">Bibliography</a></li>" +
              "<li class=\"std\"><a class=\"listing-link\" href=\"doc_index.htm\" target=\"info\">Index</a></li>" +
            "</ol>" +
          "</td>" +
        "</tr>" +
      "</table>" +
    "</div>" +
  "</body>" +
"</html>");
            }

            // cover

            using (FormatHTM htmSection = new FormatHTM(path + "\\cover.htm", mapEntity, mapSchema, included))
            {
                htmSection.WriteHeader(docPublication.Name, 0, docPublication.Header);
                htmSection.Write(
                    "\r\n" +
                    "<script type=\"text/javascript\">\r\n" +
                    "<!--\r\n" +
                    "    parent.index.location.replace(\"credits.htm\");\r\n" +
                    "//-->\r\n" +
                    "</script>\r\n");
                htmSection.WriteLine(docPublication.Documentation);
                htmSection.WriteFooter(docPublication.Footer);
            }

            using (FormatHTM htmSection = new FormatHTM(path + "\\foreword.htm", mapEntity, mapSchema, included))
            {
                DocAnnotation docAnnotation = docPublication.Annotations[0];
                htmSection.WriteHeader(docAnnotation.Name, 0, docPublication.Header);
                htmSection.Write(
                    "\r\n" +
                    "<script type=\"text/javascript\">\r\n" +
                    "<!--\r\n" +
                    "    parent.index.location.replace(\"blank.htm\");\r\n" +
                    "//-->\r\n" +
                    "</script>\r\n");

                htmSection.WriteLine("      <h1 class=\"std\">" + docAnnotation.Name + "</h1>");
                htmSection.WriteLine(docAnnotation.Documentation);
                htmSection.WriteLinkTo("foreword", 0);
                htmSection.WriteFooter(docPublication.Footer);
            }

            using (FormatHTM htmSection = new FormatHTM(path + "\\introduction.htm", mapEntity, mapSchema, included))
            {
                DocAnnotation docAnnotation = docPublication.Annotations[1];
                htmSection.WriteHeader(docAnnotation.Name, 0, docPublication.Header);
                htmSection.Write(
                    "\r\n" +
                    "<script type=\"text/javascript\">\r\n" +
                    "<!--\r\n" +
                    "    parent.index.location.replace(\"blank.htm\");\r\n" +
                    "//-->\r\n" +
                    "</script>\r\n");

                htmSection.WriteLine("      <h1 class=\"std\">" + docAnnotation.Name + "</h1>");
                htmSection.WriteLine(docAnnotation.Documentation);
                htmSection.WriteLinkTo("introduction", 0);
                htmSection.WriteFooter(docPublication.Footer);
            }

            // NEW: property set index -- build index
            SortedList<string, SortedList<string, DocPropertySet>> mapProperty = new SortedList<string, SortedList<string, DocPropertySet>>();
            foreach (DocSection docSection in docProject.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocPropertySet docPset in docSchema.PropertySets)
                    {
                        if (included == null || included.ContainsKey(docPset))
                        {
                            // include locales
                            foreach (DocLocalization doclocal in docPset.Localization)
                            {
                                // only deal with languages, not regions
                                if (doclocal.Locale != null && doclocal.Locale.Length >= 2)
                                {
                                    string language = doclocal.Locale.Substring(0, 2);

                                    if (!listLocale.ContainsKey(language))
                                    {
                                        listLocale.Add(language, doclocal.Locale);
                                    }
                                }
                            }


                            foreach (DocProperty docProp in docPset.Properties)
                            {
                                string datatype = docProp.PrimaryDataType;
                                if (datatype == null)
                                {
                                    datatype = "IfcLabel"; // enumerations
                                }

                                string match = docProp.Name + " (" + docProp.PropertyType.ToString() + "/" + datatype.ToString() + ")";

                                SortedList<string, DocPropertySet> mapPset = null;
                                if (!mapProperty.TryGetValue(match, out mapPset))
                                {
                                    mapPset = new SortedList<string, DocPropertySet>();
                                    mapProperty.Add(match, mapPset);
                                }

                                mapPset.Add(docPset.Name, docPset);


                                // include locales
                                foreach (DocLocalization doclocal in docProp.Localization)
                                {
                                    // only deal with languages, not regions
                                    if (doclocal.Locale != null && doclocal.Locale.Length >= 2)
                                    {
                                        string language = doclocal.Locale.Substring(0, 2);

                                        if (!listLocale.ContainsKey(language))
                                        {
                                            listLocale.Add(language, doclocal.Locale);
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }

            // now format listing of properties
            StringBuilder sbProperties = new StringBuilder();
            foreach (string nameProp in mapProperty.Keys)
            {
                sbProperties.Append("<li>");
                sbProperties.Append(nameProp);

                sbProperties.Append("<ul>");
                SortedList<string, DocPropertySet> mapPset = mapProperty[nameProp];

                foreach (DocPropertySet pset in mapPset.Values)
                {
                    string proplinkurl = "../../schema/" + mapSchema[pset.Name].ToLower() + "/pset/" + pset.Name.ToLower() + ".htm";

                    sbProperties.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    sbProperties.Append("<a class=\"listing-link\" href=\"");
                    sbProperties.Append(proplinkurl);
                    sbProperties.Append("\">");
                    sbProperties.Append(pset.Name);
                    sbProperties.Append("</a><br/>");
                }

                sbProperties.Append("</ul></li>");
            }
            string pathProps = path + @"/annex/annex-b/alphabeticalorder_properties.htm";
            using (FormatHTM htmProp = new FormatHTM(pathProps, mapEntity, mapSchema, included))
            {
                htmProp.WriteHeader("Properties", 2, docPublication.Header);

                htmProp.WriteLine("<h2 class=\"annex\">Individual Properties (" + mapProperty.Count + ")</h2>");
                htmProp.WriteLine("<ul class=\"std\">");

                htmProp.WriteLine(sbProperties.ToString());

                htmProp.WriteLine("</ul>");

                htmProp.WriteFooter(docPublication.Footer);
            }

            // capture figures and tables
            List<ContentRef> listFigures = new List<ContentRef>();
            List<ContentRef> listTables = new List<ContentRef>();

            // NEW: section 4 templates
            int iTemplate = 0;
            foreach (DocTemplateDefinition docTemplate in docProject.Templates)
            {
                if (included == null || included.ContainsKey(docTemplate))
                {
                    iTemplate++;
                    int[] indexpath = new int[] { 4, iTemplate };
                    GenerateTemplate(docProject, docTemplate, mapEntity, mapSchema, included, indexpath, listFigures, listTables, docPublication, path);
                }
            }

            // NEW: model view definitions
            int iView = 0;
            if (true)//Properties.Settings.Default.ConceptTables)
            {
                foreach (DocModelView docProjectModelView in docProject.ModelViews)
                {
                    if (included == null || included.ContainsKey(docProjectModelView))
                    {
                        iView++;
                        string pathTemplate = pathSchema + @"\views\" + docProjectModelView.Name.Replace(' ', '-').ToLower() + "\\index.htm";
                        using (FormatHTM htmTemplate = new FormatHTM(pathTemplate, mapEntity, mapSchema, included))
                        {
                            htmTemplate.WriteHeader(docProjectModelView.Name, 1, iView, 0, 0, docPublication.Header);
                            htmTemplate.WriteScript(1, iView, 0, 0);
                            {
                                string indexer = "1." + iView.ToString();
                                string tag = "h3";
                                string id = docProjectModelView.Name.ToLower();
                                htmTemplate.WriteLine("<" + tag + "><a id=\"" + id + "\" name=\"" + id + "\">" + indexer + " " + docProjectModelView.Name + "</a></" + tag + ">");

                                // write table of status for MVD
                                htmTemplate.WriteLine("<table class=\"gridtable\">");
                                htmTemplate.WriteLine("<tr><th>Code</th><th>Version</th><th>Status</th><th>Author</th><th>Copyright</th></tr>");
                                htmTemplate.WriteLine("<tr><td>" + docProjectModelView.Code + "</td><td>" + docProjectModelView.Version + "</td><td>" + docProjectModelView.Status + "</td><td>" + docProjectModelView.Author + "</td><td>" + docProjectModelView.Copyright + "</td></tr>");
                                htmTemplate.WriteLine("</table>");

                                string viewtable = FormatView(docProject, docProjectModelView, mapEntity, mapSchema);
                                htmTemplate.WriteDocumentationMarkup(viewtable, docProjectModelView, docPublication);
                            }

                            htmTemplate.WriteFooter(docPublication.Footer);
                        }

                        // icon for view
                        if(docProjectModelView.Icon != null)
                        {
                            string pathIcon = path + @"\img\view-" + MakeLinkName(docProjectModelView) + ".png";

                            try
                            {
                                string pathIconDir = System.IO.Path.GetDirectoryName(pathIcon);
                                if (!System.IO.Directory.Exists(pathIconDir))
                                {
                                    System.IO.Directory.CreateDirectory(pathIconDir);
                                }

                                using (System.IO.FileStream fs = new System.IO.FileStream(pathIcon, System.IO.FileMode.Create))
                                {
                                    fs.Write(docProjectModelView.Icon, 0, docProjectModelView.Icon.Length);
                                    fs.Close();
                                }
                            }
                            catch
                            {
                            }
                        }

                        // each exchange... (or sub-page?)

                        if (true)//Properties.Settings.Default.Requirement)
                        {
                            for (int iExchange = 0; iExchange < docProjectModelView.Exchanges.Count; iExchange++)
                            {
                                DocExchangeDefinition docExchange = docProjectModelView.Exchanges[iExchange];

                                string pathExchange = pathSchema + @"\views\" + MakeLinkName(docProjectModelView) + "\\" + MakeLinkName(docExchange) + ".htm";
                                using (FormatHTM htmExchange = new FormatHTM(pathExchange, mapEntity, mapSchema, included))
                                {
                                    htmExchange.WriteHeader(docExchange.Name, 1, iView, 0, 0, docPublication.Header);
                                    htmExchange.WriteScript(1, iView, iExchange + 1, 0);

                                    string indexer = "1." + iView.ToString() + "." + (iExchange + 1).ToString();
                                    string tag = "h4";
                                    string id = docExchange.Name.ToLower();

                                    htmExchange.WriteLine("<" + tag + "><a id=\"" + id + "\" name=\"" + id + "\">" + indexer + " " + docExchange.Name + "</a></" + tag + ">");
                                    htmExchange.WriteLine("<p class=\"std\">");

                                    string exchangedoc = FormatExchange(docProject, docProjectModelView, docExchange, mapEntity, mapSchema, docPublication);
                                    htmExchange.WriteDocumentationMarkup(exchangedoc, docExchange, docPublication);
                                    htmExchange.WriteLine("</p>");
                                }

                                // icons for each exchange
                                if (docExchange.Icon != null)
                                {
                                    string pathIcon = path + @"\img\mvd-" + MakeLinkName(docExchange) + ".png";

                                    try
                                    {
                                        using (System.IO.FileStream fs = new System.IO.FileStream(pathIcon, System.IO.FileMode.Create))
                                        {
                                            fs.Write(docExchange.Icon, 0, docExchange.Icon.Length);
                                            fs.Close();
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }

            string pathTOC = path + @"\toc.htm";
            using (FormatHTM htmTOC = new FormatHTM(pathTOC, mapEntity, mapSchema, included))
            {
                htmTOC.WriteHeader("Contents", 0, docPublication.Header);

                htmTOC.WriteLine("    <script type=\"text/javascript\">");
                htmTOC.WriteLine("        <!--");
                htmTOC.WriteLine("        parent.index.location = \"blank.htm\";");
                htmTOC.WriteLine("        parent.menu.location = \"content.htm\"");
                htmTOC.WriteLine("        -->");
                htmTOC.WriteLine("    </script>");

                htmTOC.WriteLine("      <h1 class=\"std\">Contents</h1>");

                htmTOC.WriteLine("<p>");

                // each section
                int iSection = 0;
                foreach (DocSection section in docProject.Sections)
                {
                    worker.ReportProgress(++progressCurrent, section);
                    if (worker.CancellationPending)
                        return;

                    iSection++;
                    using (FormatHTM htmSectionTOC = new FormatHTM(pathSchema + @"\toc-" + iSection.ToString() + ".htm", mapEntity, mapSchema, included))
                    {

                        htmSectionTOC.WriteLine(
                            "<html> \r\n" +
                            "<head> \r\n" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"> \r\n" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"../ifc-styles.css\"> \r\n" +
                            "<title>Section Contents</title> \r\n" +
                            "</head> \r\n" +
                            "<body class=\"image\"> \r\n" +
                            "<div class=\"menu\">\r\n" +
                            "<table class=\"menu\" summary=\"Table of Contents\">\r\n");

                        htmTOC.WriteTOC(0, "<a class=\"listing-link\" href=\"schema/chapter-" + iSection.ToString() + ".htm\">" + iSection.ToString() + ". " + section.Name + "</a>");

                        mapNumber.Add(section, iSection.ToString() + ".");

                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + iSection + ". <a class=\"listing-link\" href=\"chapter-" + iSection + ".htm\" target=\"info\" >" + section.Name + "</a></td></tr>\r\n");

                        // write the section page
                        using (FormatHTM htmSection = new FormatHTM(pathSchema + @"\chapter-" + iSection.ToString() + @".htm", mapEntity, mapSchema, included))
                        {
                            htmSection.WriteHeader(section.Name, iSection - 1, 0, 0, 0, docPublication.Header);
                            htmSection.WriteScript(iSection, 0, 0, 0);
                            htmSection.WriteLine("<h1 class=\"num\" id=\"scope\">" + section.Name + "</h1>");

                            section.Documentation = UpdateNumbering(section.Documentation, listFigures, listTables, section);
                            htmSection.WriteDocumentationMarkup(section.Documentation, section, docPublication);


                            if (iSection == 1)
                            {
                                if (true)//Properties.Settings.Default.ConceptTables)
                                {
                                    int iModel = 0;
                                    foreach (DocModelView docModelView in docProject.ModelViews)
                                    {
                                        if (included == null || included.ContainsKey(docModelView))
                                        {
                                            iModel++;

                                            string htmllink = "<a class=\"listing-link\" href=\"views/" + MakeLinkName(docModelView) + "/index.htm\" target=\"info\">" +
                                                iSection.ToString() + "." + iModel.ToString() + " " + docModelView.Name + "</a>";
                                            htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"schema/views/" + MakeLinkName(docModelView) + "/index.htm\" >" +
                                                iSection.ToString() + "." + iModel.ToString() + " " + docModelView.Name + "</a>");
                                            htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + htmllink + "</td></tr>");

                                            if (true)//Properties.Settings.Default.Requirement)
                                            {
                                                int iExchange = 0;
                                                foreach (DocExchangeDefinition docExchange in docModelView.Exchanges)
                                                {
                                                    iExchange++;

                                                    htmllink = "<a class=\"listing-link\" href=\"views/" + MakeLinkName(docModelView) + "/" + MakeLinkName(docExchange) + ".htm\" target=\"info\">" +
                                                        iSection.ToString() + "." + iModel.ToString() + "." + iExchange.ToString() + " " + docExchange.Name + "</a>";

                                                    htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"schema/views/" + MakeLinkName(docModelView) + "/" + MakeLinkName(docExchange) + ".htm\" >" +
                                                        iSection.ToString() + "." + iModel.ToString() + "." + iExchange.ToString() + " " + docExchange.Name + "</a>");
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + htmllink + "</td></tr>");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (iSection == 2)
                            {
                                htmSection.WriteLine("<dl>");
                                if (docProject.NormativeReferences != null)
                                {
                                    foreach (DocReference docRef in docProject.NormativeReferences)
                                    {
                                        htmSection.WriteLine("<dt class=\"normativereference\"><a id=\"" + MakeLinkName(docRef) + "\">" + docRef.Name + "</a>, <i>" + docRef.Documentation + "</i></dt>");
                                        htmSection.WriteLine("<dd>&nbsp;</dd>");
                                    }
                                }
                                htmSection.WriteLine("</dl>");
                            }
                            else if (iSection == 3)
                            {
                                htmTOC.WriteTOC(0, "<a class=\"listing-link\" href=\"schema/chapter-3.htm#terms\">3.1 Terms and definitions</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">3.1 <a class=\"listing-link\" href=\"chapter-3.htm#terms\" target=\"info\" >Terms and definitions</a></td></tr>\r\n");

                                htmTOC.WriteTOC(0, "<a class=\"listing-link\" href=\"schema/chapter-3.htm#abbreviated\">3.2 Abbreviated terms</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">3.2 <a class=\"listing-link\" href=\"chapter-3.htm#abbreviated\" target=\"info\" >Abbreviated terms</a></td></tr>\r\n");

                                htmSection.WriteLine("<a id=\"terms\"/>");
                                htmSection.WriteLine("<h2>3.1 Terms and definitions</h2>");
                                htmSection.WriteLine("<dl>");
                                if (docProject.Terms != null)
                                {
                                    foreach(DocTerm docTerm in docProject.Terms)
                                    {
                                        htmSection.WriteTerm(docTerm);
                                    }
                                }
                                htmSection.WriteLine("</dl>");
                                htmSection.WriteLine("<a id=\"abbreviated\"/>");
                                htmSection.WriteLine("<h2>3.2 Abbreviated terms</h2>");
                                htmSection.WriteLine("<table class=\"abbreviatedterms\">");
                                if (docProject.Abbreviations != null)
                                {
                                    SortedList<string, DocAbbreviation> sl = new SortedList<string, DocAbbreviation>();
                                    foreach (DocAbbreviation docRef in docProject.Abbreviations)
                                    {
                                        sl.Add(docRef.Name, docRef);
                                    }

                                    foreach (string s in sl.Keys)
                                    {
                                        DocAbbreviation docRef = sl[s];
                                        htmSection.WriteLine("<tr><td class=\"abbreviatedterm\" id=\"" + MakeLinkName(docRef) + "\">" + docRef.Name + "</td>");
                                        htmSection.WriteLine("<td class=\"abbrebiatedterm\">" + docRef.Documentation + "</td></tr>");
                                    }
                                }
                                htmSection.WriteLine("</table>");
                            }
                            else if (iSection == 4)
                            {
                                FormatHTM.WriteTOCforTemplates(docProject.Templates, 1, iSection.ToString(), htmTOC, htmSectionTOC, included);

                                htmSection.WriteLine("<table class=\"gridtable\">");
                                htmSection.WriteLine("<tr><th>Template</th>");

                                for (int i = 0; i < docProject.ModelViews.Count; i++)
                                {
                                    DocModelView docView = docProject.ModelViews[i];
                                    if (included != null && included.ContainsKey(docView))
                                    {
                                        htmSection.WriteLine("<th>" + docProject.ModelViews[i].Name + "</th>");
                                    }
                                }

                                htmSection.WriteLine("</tr>");

                                foreach (DocTemplateDefinition docTemplateDefinition in docProject.Templates)
                                {
                                    htmSection.WriteTemplateTable(docProject, docTemplateDefinition, 0, dictionaryViews);
                                }
                                htmSection.WriteLine("</table>");


                            }

                            htmSection.WriteLine("<p>");

                            int iListSchema = 0;
                            foreach (DocSchema schema in section.Schemas)
                            {
                                if (included == null || included.ContainsKey(schema))
                                {
                                    iListSchema++;
                                    htmSection.WriteLine("<a class=\"listing-link\" href=\"" + schema.Name.ToLower() + "/content.htm\">" + iSection.ToString() + "." + iListSchema.ToString() + " " + schema.Name + "</a><br>");
                                }
                            }
                            htmSection.WriteLine("</p>");

                            htmSection.WriteLinkTo("chapter-" + iSection, 1);

                            htmSection.WriteFooter(docPublication.Footer);
                        }

                        // each schema
                        int iSchema = 0;
                        foreach (DocSchema schema in section.Schemas)
                        {
                            if (worker.CancellationPending)
                                return;

                            if (included == null || included.ContainsKey(schema))
                            {
                                iSchema++;

                                // ensure directory exists
                                System.IO.Directory.CreateDirectory(pathSchema + @"\" + schema.Name.ToLower() + @"\lexical\");

                                // create schema document
                                using (FormatHTM htmSchema = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + @"\content.htm", mapEntity, mapSchema, included))
                                {
                                    {
                                        mapNumber.Add(schema, iSection.ToString() + "." + iSchema.ToString());

                                        htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"schema/" + schema.Name.ToLower() + "/content.htm\">" + iSection.ToString() + "." + iSchema.ToString() + " " + schema.Name + "</a>");

                                        // extra line between each schema
                                        htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a id=\"" + iSection.ToString() + "." + iSchema.ToString() + "\">" + iSection.ToString() + "." + iSchema.ToString() + "</a> <a class=\"listing-link\" href=\"" + schema.Name.ToLower() + "/content.htm\" target=\"info\">" + schema.Name + "</a></td></tr>\r\n");

                                        htmSchema.WriteHeader(schema.Name, iSection, iSchema, 0, 0, docPublication.Header);

                                        htmSchema.WriteScript(iSection, iSchema, 0, 0);

                                        htmSchema.WriteLine("<h2 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + " " + schema.Name + "</h2>");

                                        int iSubSection = 1; // first subsection for schema semantic definition
                                        htmTOC.WriteTOC(2, iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Schema Definition");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Schema Definition</td></tr>\r\n");
                                        htmSchema.WriteLine("<h3 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Schema Definition</h3>");

                                        schema.Documentation = UpdateNumbering(schema.Documentation, listFigures, listTables, schema);
                                        htmSchema.WriteDocumentationMarkup(schema.Documentation, schema, docPublication);

                                        // each type
                                        if (schema.Types.Count > 0)
                                        {
                                            iSubSection++;

                                            htmTOC.WriteTOC(2, iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Types");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Types</td></tr>\r\n");
                                            int iType = 0;
                                            foreach (DocType type in schema.Types)
                                            {
                                                if (worker.CancellationPending)
                                                    return;

                                                if (type.Name.Equals("IfcNullStyle", StringComparison.OrdinalIgnoreCase) && schema.Name.Equals("IfcConstructionMgmtDomain", StringComparison.OrdinalIgnoreCase))
                                                {
                                                    // bug -- exclude
                                                }
                                                else if (included == null || included.ContainsKey(type))
                                                {
                                                    iType++;

                                                    string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iType.ToString();
                                                    mapNumber.Add(type, formatnum);

                                                    htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[type.Name].ToLower() + "/lexical/" + type.Name.ToLower() + ".htm\">" + formatnum.ToString() + " " + type.Name + "</a>");
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a id=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iType.ToString() + "</a> <a class=\"listing-link\" href=\"" + mapSchema[type.Name].ToLower() + "/lexical/" + type.Name.ToLower() + ".htm\" target=\"info\">" + type.Name + "</a><td></tr>\r\n");


                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + type.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(type.Name, iSection, iSchema, iSubSection, iType, docPublication.Header);

                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iType);

                                                        htmDef.WriteLine("<h4 class=\"num\">" + type.Name + "</h4>");

                                                        htmDef.WriteViewIcons(type, docProject, dictionaryViews, path);
                                                        htmDef.WriteLocalizedNames(type);
                                                        htmDef.WriteChangeLog(type, docProject);
                                                        htmDef.WriteLine("<section>");
                                                        htmDef.WriteLine("<h5 class=\"num\">Semantic definitions at the type</h5>");

                                                        if (type.Documentation != null)
                                                        {
                                                            type.Documentation = UpdateNumbering(type.Documentation, listFigures, listTables, type);
                                                        }

                                                        htmDef.WriteSummaryHeader("Type definition", true);
                                                        htmDef.WriteDocumentationMarkup(type.Documentation, type, docPublication);
                                                        htmDef.WriteSummaryFooter();

                                                        if(type is DocEnumeration)
                                                        {
                                                            DocEnumeration docEnumeration = (DocEnumeration)type;

                                                            htmDef.WriteSummaryHeader("Enumeration definition", true);
                                                            htmDef.WriteLine("<table class=\"attributes\">");
                                                            htmDef.WriteLine("<tr><th>Constant</th><th>Description</th></tr>");
                                                            foreach (DocConstant docConstant in docEnumeration.Constants)
                                                            {
                                                                htmDef.Write("<tr><td>");
                                                                htmDef.Write(docConstant.Name);
                                                                htmDef.Write("</td><td>");
                                                                htmDef.Write(docConstant.Documentation);
                                                                htmDef.Write("</td></tr>");
                                                            }
                                                            htmDef.WriteLine("</table>");
                                                            htmDef.WriteSummaryFooter();
                                                        }
                                                        else if (type is DocSelect)
                                                        {
                                                            DocSelect docSelect = (DocSelect)type;

                                                            htmDef.WriteSummaryHeader("Select definition", true);
                                                            htmDef.WriteLine("<table class=\"attributes\">");
                                                            htmDef.WriteLine("<tr><th>Type</th><th>Description</th></tr>");
                                                            foreach (DocSelectItem docSelectItem in docSelect.Selects)
                                                            {
                                                                DocObject docRef = null;
                                                                if (mapEntity.TryGetValue(docSelectItem.Name, out docRef))
                                                                {
                                                                    if (included == null || included.ContainsKey(docRef))
                                                                    {
                                                                        htmDef.Write("<tr><td>");
                                                                        htmDef.WriteDefinition(docSelectItem.Name);
                                                                        //htmDef.Write(docSelectItem.Name);
                                                                        htmDef.Write("</td><td>");
                                                                        htmDef.Write(docSelectItem.Documentation);
                                                                        htmDef.Write("</td></tr>");
                                                                    }
                                                                }
                                                            }
                                                            htmDef.WriteLine("</table>");
                                                            htmDef.WriteSummaryFooter();
                                                        }

                                                        htmDef.WriteLine("</section>");


                                                        // where rules (for defined types)

                                                        if (type is DocDefined && ((DocDefined)type).WhereRules != null && ((DocDefined)type).WhereRules.Count > 0)
                                                        {
                                                            DocDefined entity = (DocDefined)type;

                                                            // formal propositions
                                                            htmDef.WriteSummaryHeader("Formal Propositions", true);

                                                            htmDef.WriteLine("<table class=\"propositions\">");
                                                            htmDef.WriteLine("<tr><th>Rule</th><th>Description</th></tr>");
                                                            foreach (DocWhereRule docAttr in entity.WhereRules)
                                                            {
                                                                htmDef.Write("<tr><td>");
                                                                htmDef.Write(docAttr.Name);
                                                                htmDef.Write("</td><td>");
                                                                if (docAttr.Documentation != null)
                                                                {
                                                                    htmDef.WriteDocumentationMarkup(docAttr.Documentation, entity, docPublication);
                                                                }
                                                                htmDef.WriteLine("</td></tr>");
                                                            }
                                                            htmDef.WriteLine("</table>\r\n");

                                                            htmDef.WriteSummaryFooter();
                                                        }



                                                        htmDef.WriteLine("<section>");
                                                        htmDef.WriteLine("<h5 class=\"num\">Formal representations</h5>");

                                                        foreach (DocFormat docFormat in docPublication.Formats)
                                                        {
                                                            if (docFormat.FormatOptions != DocFormatOptionEnum.None)
                                                            {
                                                                // future: componentize all formats
                                                                IFormatExtension formatext = null;
                                                                mapFormats.TryGetValue(docFormat.FormatType, out formatext);
                                                                switch (docFormat.FormatType)
                                                                {
                                                                    case DocFormatTypeEnum.XML:
                                                                        htmDef.WriteSummaryHeader("XSD Specification", false);
                                                                        htmDef.Write("<div class=\"xsd\"><code class=\"xsd\">");
                                                                        if (type is DocSelect)
                                                                        {
                                                                            htmDef.WriteFormatted(FormatXSD.FormatSelect((DocSelect)type, mapEntity, included));
                                                                        }
                                                                        else if (type is DocEnumeration)
                                                                        {
                                                                            htmDef.WriteFormatted(FormatXSD.FormatEnum((DocEnumeration)type));
                                                                        }
                                                                        else if (type is DocDefined)
                                                                        {
                                                                            htmDef.WriteFormatted(FormatXSD.FormatDefined((DocDefined)type, mapEntity));
                                                                        }
                                                                        htmDef.Write("</code></div>");
                                                                        htmDef.WriteSummaryFooter();
                                                                        break;

                                                                    case DocFormatTypeEnum.STEP:
                                                                        htmDef.WriteExpressTypeAndDocumentation(type, !docPublication.HideHistory, docPublication.ISO);
                                                                        break;


                                                                    default:
                                                                        if (formatext != null)
                                                                        {
                                                                            string output = null;
                                                                            if (type is DocSelect)
                                                                            {
                                                                               output = formatext.FormatSelect((DocSelect)type, mapEntity, included);
                                                                            }
                                                                            else if (type is DocEnumeration)
                                                                            {
                                                                                output = formatext.FormatEnumeration((DocEnumeration)type);
                                                                            }
                                                                            else if (type is DocDefined)
                                                                            {
                                                                                output = formatext.FormatDefined((DocDefined)type);
                                                                            }
                                                                            if (output != null)
                                                                            {
                                                                                htmDef.WriteSummaryHeader(docFormat.FormatType.ToString() + " Specification", false);
                                                                                htmDef.Write("<div class=\"xsd\"><code class=\"xsd\">");
                                                                                htmDef.WriteExpression(output);
                                                                                htmDef.Write("</code></div>");
                                                                                htmDef.WriteSummaryFooter();
                                                                            }
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                        }

                                                        htmDef.WriteLine("</section>");

                                                        // write url for incoming page link
                                                        htmDef.WriteLinkTo(type);

                                                        htmDef.WriteFooter(docPublication.Footer);
                                                    }
                                                }
                                            }

                                        }

                                        // each entity
                                        if (schema.Entities.Count > 0)
                                        {
                                            iSubSection++;

                                            htmTOC.WriteTOC(2, iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Entities");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Entities</td></tr>\r\n");
                                            int iEntity = 0;
                                            foreach (DocEntity entity in schema.Entities)
                                            {
                                                if (worker.CancellationPending)
                                                    return;

                                                if (included == null || included.ContainsKey(entity))
                                                {
                                                    iEntity++;

                                                    string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString();
                                                    mapNumber.Add(entity, formatnum);

                                                    htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a id=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iSubSection, iEntity, docPublication.Header);
                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iEntity);

                                                        htmDef.WriteLine("<h4 class=\"num\">" + entity.Name + "</h4>");
                                                        htmDef.WriteViewIcons(entity, docProject, dictionaryViews, path);
                                                        htmDef.WriteLocalizedNames(entity);
                                                        htmDef.WriteChangeLog(entity, docProject);

                                                        htmDef.WriteLine("<section>");
                                                        htmDef.WriteLine("<h5 class=\"num\">Semantic definitions at the entity</h5>");

                                                        string entitydocumentation = FormatEntityDescription(docProject, entity, listFigures, listTables);

                                                        htmDef.WriteSummaryHeader("Entity definition", true);
                                                        htmDef.WriteDocumentationMarkup(entitydocumentation, entity, docPublication);
                                                        htmDef.WriteSummaryFooter();

                                                        if (entity.Attributes != null && entity.Attributes.Count > 0)
                                                        {
                                                            htmDef.WriteSummaryHeader("Attribute definitions", true);

                                                            htmDef.WriteLine("<table class=\"attributes\">");
                                                            htmDef.WriteLine("<tr><th>#</th><th>Attribute</th><th>Type</th><th>Cardinality</th><th>Description</th>");

                                                            if (views != null)
                                                            {
                                                                foreach (DocModelView docViewHeader in views)
                                                                {
                                                                    htmDef.Write("<th>");
                                                                    htmDef.Write(docViewHeader.Name.Substring(0, 1));
                                                                    htmDef.Write("</th>");
                                                                }
                                                            }
                                                            htmDef.WriteLine("</tr>");

                                                            int sequence = 0;

                                                            // count direct attributes of base classes
                                                            DocEntity docEntBase = entity;
                                                            DocObject docBase = null;
                                                            while(!String.IsNullOrEmpty(docEntBase.BaseDefinition) && mapEntity.TryGetValue(docEntBase.BaseDefinition, out docBase))
                                                            {
                                                                docEntBase = (DocEntity)docBase;
                                                                foreach(DocAttribute docAttrBase in docEntBase.Attributes)
                                                                {
                                                                    if (docAttrBase.Inverse == null && docAttrBase.Derived == null)
                                                                    {
                                                                        sequence++;
                                                                    }
                                                                }
                                                            }

                                                            htmDef.WriteEntityAttributes(entity, entity, views, dictionaryViews, docPublication, ref sequence);

                                                            htmDef.WriteLine("</table>");

                                                            htmDef.WriteSummaryFooter();
                                                        }

                                                        if (entity.WhereRules != null && entity.WhereRules.Count > 0)
                                                        {
                                                            // avoid attributes without descriptions
                                                            int cDescs = 0;
                                                            foreach (DocWhereRule docAttr in entity.WhereRules)
                                                            {
                                                                if (docAttr.Documentation != null)
                                                                {
                                                                    cDescs++;
                                                                }
                                                            }

                                                            if (cDescs > 0)
                                                            {
                                                                // formal propositions
                                                                htmDef.WriteSummaryHeader("Formal Propositions", true);

                                                                htmDef.WriteLine("<table class=\"propositions\">");
                                                                htmDef.WriteLine("<tr><th>Rule</th><th>Description</th></tr>");
                                                                foreach (DocWhereRule docAttr in entity.WhereRules)
                                                                {
                                                                    htmDef.Write("<tr><td>");
                                                                    htmDef.Write(docAttr.Name);
                                                                    htmDef.Write("</td><td>");
                                                                    if (docAttr.Documentation != null)
                                                                    {
                                                                        htmDef.WriteDocumentationMarkup(docAttr.Documentation, entity, docPublication);
                                                                    }
                                                                    htmDef.WriteLine("</td></tr>");
                                                                }
                                                                htmDef.WriteLine("</table>\r\n");

                                                                htmDef.WriteSummaryFooter();
                                                            }
                                                        }
                                                        
                                                        htmDef.WriteLine("</section>");

                                                        htmDef.WriteLine("<section>");
                                                        htmDef.WriteLine("<h5 class=\"num\">Inherited definitions from supertypes</h5>");

                                                        Dictionary<Rectangle, DocEntity> map = new Dictionary<Rectangle, DocEntity>();
                                                        using (Font font = new Font(FontFamily.GenericSansSerif, 8.0f))
                                                        {
                                                            using (Image img = FormatPNG.CreateInheritanceDiagramForEntity(docProject, included, entity, font, map))
                                                            {
                                                                try
                                                                {
                                                                    img.Save(path + "\\diagrams\\" + entity.Name.ToLower() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                                                                }
                                                                catch
                                                                {
                                                                    img.ToString();
                                                                }
                                                            }
                                                        }

                                                        htmDef.WriteSummaryHeader("Entity inheritance", true);
                                                        htmDef.WriteLine("<img src=\"../../../diagrams/" + entity.Name.ToLower() + ".png\" usemap=\"#f\"/>");

                                                        htmDef.WriteLine("<map name=\"f\">");
                                                        foreach (Rectangle rc in map.Keys)
                                                        {
                                                            DocEntity docEntref = map[rc];
                                                            DocSchema docEntsch = docProject.GetSchemaOfDefinition(docEntref);

                                                            string hyperlink = "../../../schema/" + docEntsch.Name.ToLower() + "/lexical/" + docEntref.Name.ToLower() + ".htm";
                                                            htmDef.WriteLine("<area shape=\"rect\" coords=\"" + rc.Left + "," + rc.Top + "," + rc.Right + "," + rc.Bottom + "\" href=\"" + hyperlink + "\" alt=\"" + docEntref.Name + "\" />");
                                                        }
                                                        htmDef.WriteLine("</map>");
                                                        
                                                        htmDef.WriteSummaryFooter();

                                                        htmDef.WriteSummaryHeader("Attribute inheritance", false);

                                                        htmDef.WriteLine("<table class=\"attributes\">");
                                                        htmDef.Write("<tr><th>#</th><th>Attribute</th><th>Type</th><th>Cardinality</th><th>Description</th>");
                                                        if(views != null)
                                                        {
                                                            foreach(DocModelView docViewHeader in views)
                                                            {
                                                                htmDef.Write("<th>");
                                                                htmDef.Write(docViewHeader.Name.Substring(0, 1));
                                                                htmDef.Write("</th>");
                                                            }
                                                        }
                                                        htmDef.WriteLine("</tr>");

                                                        int sequenceX = 0;
                                                        htmDef.WriteEntityInheritance(entity, entity, views, dictionaryViews, docPublication, ref sequenceX);

                                                        htmDef.WriteLine("</table>");

                                                        htmDef.WriteSummaryFooter();

                                                        string conceptdocumentation = FormatEntityConcepts(docProject, entity, mapEntity, mapSchema, included, listFigures, listTables, path, docPublication);
                                                        htmDef.WriteDocumentationMarkup(conceptdocumentation, entity, docPublication);

                                                        if (docProject.Examples != null)
                                                        {
                                                            List<DocExample> listExample = new List<DocExample>();
                                                            foreach (DocExample docExample in docProject.Examples)
                                                            {
                                                                BuildExampleList(listExample, docExample, entity, included);
                                                            }
                                                            if (listExample.Count > 0)
                                                            {
                                                                htmDef.WriteLine("<section>");
                                                                htmDef.WriteLine("<h5 class=\"num\">Examples</h5>");
                                                                //htmDef.WriteSummaryHeader("Examples", true);
                                                                htmDef.WriteLine("<ul>");
                                                                foreach (DocExample docExample in listExample)
                                                                {
                                                                    if (docExample.Name != null)
                                                                    {
                                                                        htmDef.Write("<li><a href=\"../../../annex/annex-e/");
                                                                        htmDef.Write(docExample.Name.Replace(' ', '-').ToLower());
                                                                        htmDef.Write(".htm\">");
                                                                        htmDef.Write(docExample.Name);
                                                                        htmDef.Write("</a></li>");
                                                                        htmDef.WriteLine("");
                                                                    }
                                                                }
                                                                htmDef.WriteLine("</ul>");
                                                                //htmDef.WriteSummaryFooter();
                                                                htmDef.WriteLine("</section>");
                                                            }
                                                        }

                                                        htmDef.WriteLine("<section>");
                                                        htmDef.WriteLine("<h5 class=\"num\">Formal representations</h5>");

                                                        foreach(DocFormat docFormat in docPublication.Formats)
                                                        {
                                                            if(docFormat.FormatOptions != DocFormatOptionEnum.None)
                                                            {
                                                                // future: componentize all formats
                                                                IFormatExtension formatext = null;
                                                                mapFormats.TryGetValue(docFormat.FormatType, out formatext);
                                                                switch(docFormat.FormatType)
                                                                {
                                                                    case DocFormatTypeEnum.XML:
                                                                        htmDef.WriteSummaryHeader("XSD Specification", false);
                                                                        htmDef.Write("<div class=\"xsd\"><code class=\"xsd\">");
                                                                        htmDef.WriteFormatted(FormatXSD.FormatEntity(entity, mapEntity, included));
                                                                        htmDef.Write("</code></div>");
                                                                        htmDef.WriteSummaryFooter();
                                                                        break;

                                                                    case DocFormatTypeEnum.STEP:
                                                                        htmDef.WriteExpressEntitySpecification(entity, !docPublication.HideHistory, docPublication.ISO);
                                                                        break;

                                                                    case DocFormatTypeEnum.OWL:
                                                                        htmDef.WriteSummaryHeader("OWL Specification (TTL)", false);
                                                                        htmDef.Write("<div class=\"owl\"><code class=\"owl\">");
                                                                        //TODO:: htmDef.WriteFormatted(FormatXSD.FormatEntity(entity, mapEntity, included));
                                                                        htmDef.Write("</code></div>");
                                                                        htmDef.WriteSummaryFooter();
                                                                        break;

                                                                    default:
                                                                        if(formatext != null)
                                                                        {
                                                                            string output = formatext.FormatEntity(entity, mapEntity, included);
                                                                            if (output != null)
                                                                            {
                                                                                htmDef.WriteSummaryHeader(docFormat.FormatType.ToString() + " Specification", false);
                                                                                htmDef.Write("<div class=\"xsd\"><code class=\"xsd\">");
                                                                                htmDef.WriteExpression(output);
                                                                                htmDef.Write("</code></div>");
                                                                                htmDef.WriteSummaryFooter();
                                                                            }
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                        }

                                                        htmDef.WriteLine("</section>");

                                                        // write url for incoming page link
                                                        htmDef.WriteLinkTo(entity);

                                                        htmDef.WriteFooter(docPublication.Footer);
                                                    }
                                                }
                                            }
                                        }

                                        // functions
                                        if (schema.Functions.Count > 0)
                                        {
                                            iSubSection++;

                                            htmTOC.WriteTOC(2, iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Functions");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Functions</td></tr>\r\n");
                                            int iEntity = 0;
                                            foreach (DocFunction entity in schema.Functions)
                                            {
                                                if (included == null || included.ContainsKey(entity))
                                                {
                                                    iEntity++;

                                                    string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString();
                                                    mapNumber.Add(entity, formatnum);

                                                    htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a id=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iSubSection, iEntity, docPublication.Header);
                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iEntity);

                                                        htmDef.WriteLine("<h4 class=\"num\">" + entity.Name + "</h4>");

                                                        htmDef.WriteLine("<section>");
                                                        htmDef.WriteLine("<h5 class=\"num\">Semantic definitions at the function</h5>");

                                                        htmDef.WriteSummaryHeader("Function Definition", true);
                                                        htmDef.WriteLine("<p>");
                                                        htmDef.WriteDocumentationMarkup(entity.Documentation, entity, docPublication);
                                                        htmDef.WriteLine("</p>");
                                                        htmDef.WriteSummaryFooter();

                                                        htmDef.WriteLine("</section>");

                                                        htmDef.WriteLine("<section>");
                                                        htmDef.WriteLine("<h5 class=\"num\">Formal representations</h5>");

                                                        htmDef.WriteSummaryHeader("EXPRESS Specification", true);
                                                        htmDef.Write("<div class=\"xsd\"><code class=\"xsd\">");
                                                        //htmDef.WriteLine("<span class=\"express\">\r\n");
                                                        htmDef.WriteExpressFunction(entity);
                                                        //htmDef.WriteLine("</span>\r\n");
                                                        htmDef.Write("</code></div>");
                                                        htmDef.WriteSummaryFooter();

                                                        htmDef.WriteLine("</section>");

                                                        // write url for incoming page link
                                                        htmDef.WriteLinkTo(entity);

                                                        htmDef.WriteFooter(docPublication.Footer);
                                                    }
                                                }
                                            }
                                        }

                                        // rules
                                        if (schema.GlobalRules.Count > 0)
                                        {
                                            iSubSection++;

                                            htmTOC.WriteTOC(2, iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Rules");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Rules</td></tr>\r\n");
                                            int iEntity = 0;
                                            foreach (DocGlobalRule entity in schema.GlobalRules)
                                            {
                                                if (included == null || included.ContainsKey(entity))
                                                {
                                                    iEntity++;

                                                    string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString();
                                                    mapNumber.Add(entity, formatnum);

                                                    htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a id=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + "</a> <a href=\"" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iSubSection, iEntity, docPublication.Header);
                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iEntity);

                                                        htmDef.WriteLine("<h4 class=\"num\">" + entity.Name + "</h4>");

                                                        htmDef.WriteLine("<section>");
                                                        htmDef.WriteLine("<h5 class=\"num\">Semantic definitions at the global rule</h5>");

                                                        htmDef.WriteSummaryHeader("Global Rule Definition", true);
                                                        htmDef.WriteLine("<p>");
                                                        htmDef.WriteDocumentationMarkup(entity.Documentation, entity, docPublication);
                                                        htmDef.WriteLine("</p>");
                                                        htmDef.WriteSummaryFooter();

                                                        htmDef.WriteLine("</section>");

                                                        htmDef.WriteLine("<section>");
                                                        htmDef.WriteLine("<h5 class=\"num\">Formal representations</h5>");

                                                        htmDef.WriteSummaryHeader("EXPRESS Specification", true);
                                                        htmDef.WriteLine("<span class=\"express\">\r\n");
                                                        htmDef.WriteExpressGlobalRule(entity);
                                                        htmDef.WriteLine("</span>\r\n");
                                                        htmDef.WriteSummaryFooter();

                                                        htmDef.WriteLine("</section>");

                                                        // write url for incoming page link
                                                        htmDef.WriteLinkTo(entity);

                                                        htmDef.WriteFooter(docPublication.Footer);
                                                    }
                                                }
                                            }
                                        }

                                        // property sets
                                        if (schema.PropertySets.Count > 0 || schema.PropertyEnums.Count > 0)
                                        {
                                            iSubSection++;

                                            htmTOC.WriteTOC(2, iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Property Sets");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Property Sets</td></tr>\r\n");
                                            int iPset = 0;
                                            foreach (DocPropertySet entity in schema.PropertySets)
                                            {
                                                if (worker.CancellationPending)
                                                    return;

                                                if (included == null || included.ContainsKey(entity))
                                                {
                                                    iPset++;

                                                    string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString();
                                                    mapNumber.Add(entity, formatnum);

                                                    htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a id=\"" + formatnum + "\">" + formatnum + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\pset\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iSubSection, iPset, docPublication.Header);
                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iPset);
                                                        htmDef.WriteLine("<h4 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString() + " " + entity.Name + "</h4>");

                                                        if (!String.IsNullOrEmpty(entity.ApplicableType))
                                                        {
                                                            htmDef.Write("<p>");
                                                            htmDef.WriteDefinition(entity.PropertySetType);
                                                            htmDef.WriteLine("/");

                                                            if (entity.ApplicableType != null && entity.ApplicableType.Contains("/"))
                                                            {
                                                                // break out, e.g. "IfcSensor/TEMPERATURESENSOR"
                                                                string[] applicableparts = entity.ApplicableType.Split('/');
                                                                for (int iapppart = 0; iapppart < applicableparts.Length; iapppart++)
                                                                {
                                                                    if (iapppart > 0)
                                                                    {
                                                                        htmDef.Write(" / ");
                                                                    }
                                                                    htmDef.WriteDefinition(applicableparts[iapppart]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                htmDef.WriteDefinition(entity.ApplicableType);
                                                            }
                                                            htmDef.Write("</p>");
                                                        }

                                                        // english by default
                                                        htmDef.WriteLine("<table>");

                                                        entity.Localization.Sort(); // ensure sorted
                                                        foreach (DocLocalization doclocal in entity.Localization)
                                                        {
                                                            string localname = doclocal.Name;
                                                            string localdesc = doclocal.Documentation;

                                                            string localid = doclocal.Locale.Substring(0, 2).ToLower();

                                                            if (localid.Equals("en", StringComparison.InvariantCultureIgnoreCase) && localdesc == null)
                                                            {
                                                                localdesc = entity.Documentation;
                                                            }

                                                            htmDef.WriteLine("<tr><td><img src=\"../../../img/locale-" + localid + ".png\" /></td><td><b> " + localname + ":</b> " + localdesc + "</td></tr>");
                                                        }

                                                        htmDef.WriteLine("</table>");

                                                        if (true)//!Properties.Settings.Default.NoXml)
                                                        {
                                                            ////htmDef.WriteLine("<p><a href=\"http://lookup.bsdd.buildingsmart.com/api/4.0/IfdPSet/search/" + entity.Name + "\" target=\"ifd\"><img src=\"../../../img/external.png\" title=\"Link to IFD\"/> buildingSMART Data Dictionary</a></p>\r\n");
                                                            //http://lookup.bsdd.buildingsmart.com/api/4.0/IfdPSet/search/Pset_ActionRequest

                                                            // use guid
                                                            string guid = IfcGloballyUniqueId.Format(entity.Uuid);
                                                            htmDef.WriteLine("<p><a href=\"http://lookup.bsdd.buildingsmart.com/api/4.0/IfdPSet/" + guid + "/ifcVersion/2x4\" target=\"ifd\"><img border=\"0\" src=\"../../../img/external.png\" title=\"Link to IFD\"/> buildingSMART Data Dictionary</a></p>\r\n");

                                                            htmDef.WriteLine("<p><a href=\"../../../psd/" + entity.Name + ".xml\"><img border=\"0\" src=\"../../../img/diagram.png\" title=\"Link to PSD-XML\"/> PSD-XML</a></p>\r\n");
                                                        }

                                                        // write diagram if it exists
                                                        htmDef.WriteLine(FormatFigure(docProject, entity, null, entity.Name, listFigures, path));
                                                        htmDef.WriteProperties(entity.Properties);

                                                        // write url for incoming page link
                                                        htmDef.WriteLinkTo(entity);

                                                        htmDef.WriteFooter(docPublication.Footer);
                                                    }

                                                    // generate PSD listing
                                                    using (FormatXML formatPSD = new FormatXML(path + @"\psd\" + entity.Name + ".xml", typeof(PropertySetDef)))//, PropertySetDef.DefaultNamespace)) // full casing for compatibility with original files
                                                    {
                                                        formatPSD.Instance = Program.ExportPsd(entity, mapPropEnum);
                                                        formatPSD.Save();
                                                    }
                                                }
                                            }

                                            foreach (DocPropertyEnumeration entity in schema.PropertyEnums)
                                            {
                                                if (worker.CancellationPending)
                                                    return;

                                                if (included == null || included.ContainsKey(entity))
                                                {
                                                    iPset++;

                                                    string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString();
                                                    mapNumber.Add(entity, formatnum);

                                                    htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a id=\"" + formatnum + "\">" + formatnum + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\pset\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iSubSection, iPset, docPublication.Header);
                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iPset);
                                                        htmDef.WriteLine("<h4 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString() + " " + entity.Name + "</h4>");

                                                        // english by default
                                                        htmDef.WriteLine("<table>");

                                                        entity.Localization.Sort(); // ensure sorted
                                                        foreach (DocLocalization doclocal in entity.Localization)
                                                        {
                                                            if (doclocal.Locale != null && doclocal.Locale.Length > 2)
                                                            {
                                                                string localname = doclocal.Name;
                                                                string localdesc = doclocal.Documentation;

                                                                string localid = doclocal.Locale.Substring(0, 2).ToLower();

                                                                if (localid.Equals("en", StringComparison.InvariantCultureIgnoreCase) && localdesc == null)
                                                                {
                                                                    localdesc = entity.Documentation;
                                                                }

                                                                htmDef.WriteLine("<tr><td><img src=\"../../../img/locale-" + localid + ".png\" /></td><td><b> " + localname + ":</b> " + localdesc + "</td></tr>");
                                                            }
                                                        }

                                                        htmDef.WriteLine("</table>");

                                                        htmDef.WriteLine("<table class=\"gridtable\">");
                                                        htmDef.WriteLine("<tr><th>Name</th><th>Description</th></tr>");

                                                        bool showdefaultdesc = true;

                                                        foreach (DocPropertyConstant docprop in entity.Constants)
                                                        {
                                                            htmDef.WriteLine("<tr><td>" + docprop.Name + "</td><td>");

                                                            if (docprop.Localization.Count > 0)
                                                            {
                                                                htmDef.WriteLine("<table class=\"gridtable\">");
                                                                docprop.Localization.Sort();
                                                                foreach (DocLocalization doclocal in docprop.Localization)
                                                                {
                                                                    string localname = doclocal.Name;
                                                                    string localdesc = doclocal.Documentation;

                                                                    string localid = doclocal.Locale.Substring(0, 2).ToLower();

                                                                    if (localid.Equals("en", StringComparison.InvariantCultureIgnoreCase) && localdesc == null)
                                                                    {
                                                                        localdesc = docprop.Documentation;
                                                                        showdefaultdesc = false;
                                                                    }

                                                                    htmDef.WriteLine("<tr><td><img src=\"../../../img/locale-" + localid + ".png\" /></td><td><b>" + localname + "</b></td><td>" + localdesc + "</td></tr>");
                                                                }
                                                                htmDef.WriteLine("</table>");
                                                            }

                                                            if(showdefaultdesc)
                                                            {
                                                                htmDef.WriteLine(docprop.Documentation);
                                                            }

                                                            htmDef.WriteLine("</td></tr>");
                                                        }

                                                        htmDef.WriteLine("</table>");

                                                        // write url for incoming page link
                                                        htmDef.WriteLinkTo(entity);

                                                        htmDef.WriteFooter(docPublication.Footer);
                                                    }
                                                }
                                            }

                                        }


                                        // quantity sets (assume properties always exist for such schemas so always section 4)
                                        if (schema.QuantitySets.Count > 0)
                                        {
                                            iSubSection++;

                                            htmTOC.WriteTOC(2, iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Quantity Sets");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Quantity Sets</td></tr>\r\n");
                                            int iPset = 0;
                                            foreach (DocQuantitySet entity in schema.QuantitySets)
                                            {
                                                if (worker.CancellationPending)
                                                    return;

                                                if (included == null || included.ContainsKey(entity))
                                                {
                                                    iPset++;

                                                    string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString();
                                                    mapNumber.Add(entity, formatnum);

                                                    htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/qset/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a id=\"" + formatnum + "\">" + formatnum + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/qset/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\qset\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iSubSection, iPset, docPublication.Header);
                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iPset);
                                                        htmDef.WriteLine("<h4 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString() + " " + entity.Name + "</h4>");

                                                        if (!String.IsNullOrEmpty(entity.ApplicableType))
                                                        {
                                                            htmDef.Write("<p>");

                                                            htmDef.WriteDefinition("QTO_TYPEDRIVENOVERRIDE");
                                                            htmDef.WriteLine("/");
                                                            htmDef.WriteDefinition(entity.ApplicableType);
                                                            htmDef.Write("</p>");
                                                        }

                                                        // english by default
                                                        htmDef.WriteLine("<table>");
                                                        entity.Localization.Sort(); // ensure sorted
                                                        foreach (DocLocalization doclocal in entity.Localization)
                                                        {
                                                            string localname = doclocal.Name;
                                                            string localdesc = doclocal.Documentation;
                                                            string localid = doclocal.Locale.Substring(0, 2).ToLower();

                                                            if (localid.Equals("en", StringComparison.InvariantCultureIgnoreCase) && localdesc == null)
                                                            {
                                                                localdesc = entity.Documentation;
                                                            }

                                                            htmDef.WriteLine("<tr valign=\"top\"><td><img src=\"../../../img/locale-" + localid + ".png\" title=\"Link to XML\"/></td><td><b>" + localname + "</b>: " + localdesc + "</td></tr>");
                                                        }

                                                        htmDef.WriteLine("</table>");

                                                        if (true)//!Properties.Settings.Default.NoXml)
                                                        {
                                                            htmDef.WriteLine("<p><a href=\"../../../qto/" + entity.Name + ".xml\"><img border=\"0\" src=\"../../../img/diagram.png\" title=\"Link to QTO-XML\"/> QTO-XML</a></p>\r\n");
                                                        }

                                                        // write each quantity
                                                        htmDef.WriteLine("<table class=\"gridtable\">");
                                                        htmDef.WriteLine("<tr><th>Name</th><th>Type</th><th>Description</th>");
                                                        foreach (DocQuantity docprop in entity.Quantities)
                                                        {
                                                            htmDef.WriteLine("<tr><td>" + docprop.Name + "</td><td>");
                                                            htmDef.WriteDefinition(docprop.QuantityType.ToString());
                                                            htmDef.WriteLine("</td><td>");

                                                            bool showdefaultdesc = false;
                                                            if(docprop.Localization.Count > 0)
                                                            {
                                                                htmDef.WriteLine("<table class=\"gridtable\">");

                                                                docprop.Localization.Sort();
                                                                foreach (DocLocalization doclocal in docprop.Localization)
                                                                {
                                                                    string localname = doclocal.Name;
                                                                    string localdesc = doclocal.Documentation;

                                                                    string localid = doclocal.Locale.Substring(0, 2).ToLower();

                                                                    if (String.IsNullOrEmpty(localdesc) && localid.Equals("en", StringComparison.InvariantCultureIgnoreCase) && localdesc == null)
                                                                    {
                                                                        localdesc = docprop.Documentation;
                                                                        showdefaultdesc = false;
                                                                    }

                                                                    htmDef.WriteLine("<tr><td><img src=\"../../../img/locale-" + localid + ".png\" /></td><td><b>" + localname + "</b></td><td>" + localdesc + "</td></tr>");
                                                                }
                                                                htmDef.WriteLine("</table>");
                                                            }
                                                            if(showdefaultdesc)
                                                            {
                                                                htmDef.WriteLine(docprop.Documentation);
                                                            }

                                                            htmDef.WriteLine("</td></tr>");
                                                        }
                                                        htmDef.WriteLine("</table>");

                                                        // write url for incoming page link
                                                        htmDef.WriteLinkTo(entity);

                                                        htmDef.WriteFooter(docPublication.Footer);
                                                    }

                                                    // generate PSD listing
                                                    using (FormatXML formatPSD = new FormatXML(path + @"\qto\" + entity.Name + ".xml", typeof(QtoSetDef), QtoSetDef.DefaultNamespace)) // full casing for compatibility with original files
                                                    {
                                                        formatPSD.Instance = Program.ExportQto(entity);
                                                        formatPSD.Save();
                                                    }

                                                }
                                            }
                                        }
                                    }

                                    // v1.8: write links to express-g                                
                                    htmSchema.WriteLine(
                                    "<p><a href=\"../../annex/annex-d/" + MakeLinkName(schema) + "/index.htm\" ><img src=\"../../img/diagram.png\" style=\"border: 0px\" title=\"Link to EXPRESS-G diagram\" alt=\"Link to EXPRESS-G diagram\">&nbsp;EXPRESS-G diagram</a></p>");

                                    // link to this page
                                    htmSchema.WriteLinkTo(schema);

                                    htmSchema.WriteFooter(docPublication.Footer);
                                }
                            }
                        }

                        htmSectionTOC.WriteLine(
                            "</table>\r\n" +
                            "</div>\r\n" +
                            "</body>\r\n" +
                            "</html>\r\n");
                    }
                }

                int iAnnex = 0;
                char chAnnex = 'A';
                foreach (DocAnnex docannex in docProject.Annexes)
                {
                    worker.ReportProgress(++progressCurrent, docannex);

                    iAnnex--;
                    htmTOC.WriteTOC(0, "<a class=\"listing-link\" href=\"annex/annex-" + chAnnex.ToString().ToLower() + ".htm\">Annex " + chAnnex.ToString() + ". " + docannex.Name + "</a>");

                    // write the section page
                    using (FormatHTM htmSection = new FormatHTM(path + @"\annex\annex-" + chAnnex.ToString().ToLower() + @".htm", mapEntity, mapSchema, included))
                    {
                        htmSection.WriteHeader(docannex.Name, iAnnex, 0, 0, 0, docPublication.Header);
                        htmSection.WriteScript(iAnnex, 0, 0, 0);
                        htmSection.WriteLine("<h1 class=\"annex\">Annex " + chAnnex.ToString() + "</h1>");
                        if (chAnnex == 'A')
                        {
                            htmSection.WriteLine("<div align=\"center\">(normative)</div>");
                        }
                        else
                        {
                            htmSection.WriteLine("<div align=\"center\">(informative)</div>");
                        }
                        htmSection.WriteLine("<h1 class=\"annex\">" + docannex.Name + "</h1>");

                        // no numbering for annex currently... docannex.Documentation = UpdateNumbering(section.Documentation, ref iFigure, ref iTable);
                        htmSection.WriteDocumentationMarkup(docannex.Documentation, docannex, docPublication);

                        // write listing of schemas
                        if (chAnnex == 'A')
                        {
                            // create page for model view
                            //htmSection.WriteComputerListing("IFC4", "ifc4", 0);

                            /*
                            DoExport(docProject, path + @"\annex\annex-a\default\ifc4.exp", null, null, instances, true);
                            DoExport(docProject, path + @"\annex\annex-a\default\ifcXML4.xsd", null, null, instances, true);
                            DoExport(docProject, path + @"\annex\annex-a\default\ifc4.ifc", null, null, instances, true);
                            DoExport(docProject, path + @"\annex\annex-a\default\ifc4.ifcxml", null, null, instances, true);

                            using (FormatHTM htmExpress = new FormatHTM(path + @"\annex\annex-a\default\ifc4.exp.htm", mapEntity, mapSchema, included))
                            {
                                htmExpress.UseAnchors = true;
                                htmExpress.WriteHeader("EXPRESS", 3);
                                htmExpress.WriteExpressSchema(docProject);
                                htmExpress.WriteFooter("");
                            }

                            using (FormatHTM htmXSD = new FormatHTM(path + @"\annex\annex-a\default\ifcXML4.xsd.htm", mapEntity, mapSchema, included))
                            {
                                string xsdcontent = null;
                                using (System.IO.StreamReader reader = new System.IO.StreamReader(path + @"\annex\annex-a\default\ifcXML4.xsd.txt"))
                                {
                                    xsdcontent = reader.ReadToEnd();
                                }

                                htmXSD.UseAnchors = false;
                                htmXSD.WriteHeader("XSD", 3);
                                htmXSD.Write("<span class=\"express\">");
                                htmXSD.WriteFormatted(xsdcontent);
                                htmXSD.Write("</span>");
                                htmXSD.WriteFooter("");
                            }
                             */
                        }
                        else if(chAnnex == 'C')
                        {
                            htmSection.WriteInheritanceMapping(docProject, views, docPublication);
                        }

                        htmSection.WriteLinkTo("annex-" + chAnnex.ToString().ToLower(), 1);
                        htmSection.WriteFooter(docPublication.Footer);
                    }

                    using (FormatHTM htmSectionTOC = new FormatHTM(path + @"\annex\toc-" + chAnnex.ToString().ToLower() + ".htm", mapEntity, mapSchema, included))
                    {
                        htmSectionTOC.WriteLine(
                            "<html> \r\n" +
                            "<head> \r\n" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"> \r\n" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"../ifc-styles.css\"> \r\n" +
                            "<title>Section Contents</title> \r\n" +
                            "</head> \r\n" +
                            "<body class=\"image\"> \r\n" +
                            "<div class=\"menu\">\r\n" +
                            "<table class=\"menu\" summary=\"Table of Contents\">\r\n");

                        // top level
                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + chAnnex + ". <a class=\"listing-link\" href=\"annex-" + chAnnex.ToString().ToLower() + ".htm\" target=\"info\" >" + docannex.Name + "</a></td></tr>\r\n");

                        switch (chAnnex)
                        {
                            case 'A':
                                // each MVD has specific schema
                                //if (Properties.Settings.Default.ConceptTables)
                                {
                                    int iCodeView = 0;
                                    foreach (DocModelView docModelView in docProject.ModelViews)
                                    {




                                        if ((included == null || included.ContainsKey(docModelView)) && !String.IsNullOrEmpty(docModelView.Code))
                                        {
                                            iCodeView++;
                                            htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-a/" + MakeLinkName(docModelView) + "/index.htm\" >A." + iCodeView.ToString() + " " + docModelView.Name + "</a>");

                                            htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">A." + iCodeView.ToString() + " <a href=\"annex-a/" + MakeLinkName(docModelView) + "/index.htm\" target=\"info\" >" + docModelView.Name + "</a></td></tr>");

                                            // create page for model view
                                            string pathRoot = path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\index.htm";
                                            using (FormatHTM htmRoot = new FormatHTM(pathRoot, mapEntity, mapSchema, included))
                                            {
                                                htmRoot.WriteComputerListing(docModelView.Name, docModelView.Code, iCodeView, docPublication);
                                            }

                                            // show filtered schemas for model views only if exchanges defined
                                            DocModelView[] modelviews = docProject.GetViewInheritance(docModelView);

                                            DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".exp", modelviews, locales, instances);
                                            DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".xsd", modelviews, locales, instances);
                                            DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".ifc", modelviews, locales, instances);
                                            //DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".ifcxml", modelviews, locales, instances);
                                            DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".xml", modelviews, locales, instances);
                                            DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + "-psd.zip", modelviews, locales, instances);
                                            DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + "-qto.zip", modelviews, locales, instances);

                                            if (docPublication.GetFormatOption(DocFormatTypeEnum.STEP) != DocFormatOptionEnum.None)
                                            {
                                                using (FormatHTM htmExpress = new FormatHTM(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".exp.htm", mapEntity, mapSchema, included))
                                                {
                                                    htmExpress.UseAnchors = true;
                                                    htmExpress.WriteHeader("EXPRESS", 3, docPublication.Header);
                                                    htmExpress.WriteExpressSchema(docProject);
                                                    htmExpress.WriteFooter("");
                                                }
                                            }

                                            if (docPublication.GetFormatOption(DocFormatTypeEnum.XML) != DocFormatOptionEnum.None)
                                            {
                                                using (FormatHTM htmXSD = new FormatHTM(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".xsd.htm", mapEntity, mapSchema, included))
                                                {
                                                    string xsdcontent = null;
                                                    using (System.IO.StreamReader reader = new System.IO.StreamReader(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".xsd"))
                                                    {
                                                        xsdcontent = reader.ReadToEnd();
                                                    }

                                                    htmXSD.UseAnchors = false;
                                                    htmXSD.WriteHeader("XSD", 3, docPublication.Header);
                                                    htmXSD.WriteFormatted(xsdcontent);
                                                    htmXSD.WriteFooter("");
                                                }
                                            }                                            

                                            DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".mvdxml", new DocModelView[] { docModelView }, locales, instances);


                                            // get included in view
                                            Dictionary<DocObject, bool> view_included = new Dictionary<DocObject, bool>();
                                            foreach (DocModelView docView in modelviews)
                                            {
                                               docProject.RegisterObjectsInScope(docView, view_included);
                                            }

                                            foreach(DocFormat docFormat in docPublication.Formats)
                                            {
                                                IFormatExtension formatextension = null;
                                                if (mapFormats.TryGetValue(docFormat.FormatType, out formatextension))
                                                {
                                                    //string content = formatextension.FormatDefinitions(docProject, mapEntity, included);
                                                    string content = formatextension.FormatDefinitions(docProject, mapEntity, view_included);
                                                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + "." + docFormat.ExtensionSchema, false))
                                                    {
                                                        writer.Write(content);
                                                    }

                                                    // write formatted
                                                    using(FormatHTM htmFormat = new FormatHTM(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + "." + docFormat.ExtensionSchema + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmFormat.UseAnchors = false;
                                                        htmFormat.WriteHeader(docFormat.ExtensionSchema, 3, docPublication.Header);
                                                        htmFormat.WriteExpression(content);
                                                        htmFormat.WriteFooter("");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                break;

                            case 'B':
                                // alphabetical listings
                                htmTOC.WriteTOC(1, "B.1 Definitions");
                                htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1 Definitions</td></tr>");

                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/alphabeticalorder_definedtypes.htm\" >B.1.1 Defined types</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1.1 <a href=\"annex-b/alphabeticalorder_definedtypes.htm\" target=\"info\" >Defined types</a></td></tr>");
                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/alphabeticalorder_enumtypes.htm\" >B.1.2 Enumeration types</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1.2 <a href=\"annex-b/alphabeticalorder_enumtypes.htm\" target=\"info\" >Enumeration types</a></td></tr>");
                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/alphabeticalorder_selecttypes.htm\" >B.1.3 Select types</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1.3 <a href=\"annex-b/alphabeticalorder_selecttypes.htm\" target=\"info\" >Select types</a></td></tr>");
                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/alphabeticalorder_entities.htm\" >B.1.4 Entities</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1.4 <a href=\"annex-b/alphabeticalorder_entities.htm\" target=\"info\" >Entities</a></td></tr>");
                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/alphabeticalorder_functions.htm\" >B.1.5 Functions</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1.5 <a href=\"annex-b/alphabeticalorder_functions.htm\" target=\"info\" >Functions</a></td></tr>");
                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/alphabeticalorder_rules.htm\" >B.1.6 Rules</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1.6 <a href=\"annex-b/alphabeticalorder_rules.htm\" target=\"info\" >Rules</a></td></tr>");
                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/alphabeticalorder_psets.htm\" >B.1.7 Property sets</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1.7 <a href=\"annex-b/alphabeticalorder_psets.htm\" target=\"info\" >Property sets</a></td></tr>");
                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/alphabeticalorder_qsets.htm\" >B.1.8 Quantity sets</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1.8 <a href=\"annex-b/alphabeticalorder_qsets.htm\" target=\"info\" >Quantity sets</a></td></tr>");

                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/alphabeticalorder_psets.htm\" >B.1.9 Individual properties</a>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B.1.9 <a href=\"annex-b/alphabeticalorder_properties.htm\" target=\"info\" >Individual properties</a></td></tr>");

                                // locales
                                int indexb = 1;
                                foreach (string locale in listLocale.Keys)
                                {
                                    indexb++;

                                    string localeheader = locale.ToUpper();
                                    if (locale == "zh")
                                    {
                                        localeheader += " [Chinese]"; // no language-generic info available
                                    }
                                    else
                                    {
                                        try
                                        {
                                            System.Globalization.CultureInfo cultureinfo = System.Globalization.CultureInfo.GetCultureInfo(locale);
                                            if (cultureinfo != null)
                                            {
                                                localeheader += " [" + cultureinfo.EnglishName + "]";
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }

                                    // each locale
                                    htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");

                                    htmTOC.WriteTOC(1, "B." + indexb.ToString() + " " + localeheader);
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B." + indexb.ToString() + " " + localeheader + "</td></tr>");

                                    htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/" + locale.ToLower() + "/alphabeticalorder_definedtypes.htm\" >B." + indexb.ToString() + ".1 Defined types</a>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B." + indexb.ToString() + ".1 <a href=\"annex-b/" + locale.ToLower() + "/alphabeticalorder_definedtypes.htm\" target=\"info\" >Defined types</a></td></tr>");
                                    htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/" + locale.ToLower() + "/alphabeticalorder_enumtypes.htm\" >B." + indexb.ToString() + ".2 Enumeration types</a>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B." + indexb.ToString() + ".2 <a href=\"annex-b/" + locale.ToLower() + "/alphabeticalorder_enumtypes.htm\" target=\"info\" >Enumeration types</a></td></tr>");
                                    htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/" + locale.ToLower() + "/alphabeticalorder_selecttypes.htm\" >B." + indexb.ToString() + ".3 Select types</a>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B." + indexb.ToString() + ".3 <a href=\"annex-b/" + locale.ToLower() + "/alphabeticalorder_selecttypes.htm\" target=\"info\" >Select types</a></td></tr>");
                                    htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/" + locale.ToLower() + "/alphabeticalorder_entities.htm\" >B." + indexb.ToString() + ".4 Entities</a>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B." + indexb.ToString() + ".4 <a href=\"annex-b/" + locale.ToLower() + "/alphabeticalorder_entities.htm\" target=\"info\" >Entities</a></td></tr>");
                                    htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/" + locale.ToLower() + "/alphabeticalorder_functions.htm\" >B." + indexb.ToString() + ".5 Functions</a>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B." + indexb.ToString() + ".5 <a href=\"annex-b/" + locale.ToLower() + "/alphabeticalorder_functions.htm\" target=\"info\" >Functions</a></td></tr>");
                                    htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/" + locale.ToLower() + "/alphabeticalorder_rules.htm\" >B." + indexb.ToString() + ".6 Rules</a>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">B." + indexb.ToString() + ".6 <a href=\"annex-b/" + locale.ToLower() + "/alphabeticalorder_rules.htm\" target=\"info\" >Rules</a></td></tr>");

                                    /* no translations currently -- enable in future
                                    htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/" + locale.ToLower() + "/alphabeticalorder_psets.htm\" >B." + indexb.ToString() + ".7 Property sets</a>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a href=\"annex-b/" + locale.ToLower() + "/alphabeticalorder_psets.htm\" target=\"info\" >B." + indexb.ToString() + ".7 Property sets</a></td></tr>");
                                    htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/annex-b/" + locale.ToLower() + "/alphabeticalorder_qsets.htm\" >B." + indexb.ToString() + ".8 Quantity sets</a>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a href=\"annex-b/" + locale.ToLower() + "/alphabeticalorder_qsets.htm\" target=\"info\" >B." + indexb.ToString() + ".8 Quantity sets</a></td></tr>");
                                     */
                                }

                                // generate alphabetical listings
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_definedtypes.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocDefined>("Defined Types", path, "definedtypes", docPublication);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_enumtypes.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocEnumeration>("Enumeration Types", path, "enumtypes", docPublication);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_selecttypes.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocSelect>("Select Types", path, "selecttypes", docPublication);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_entities.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocEntity>("Entities", path, "entities", docPublication);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_functions.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocFunction>("Functions", path, "functions", docPublication);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_rules.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocGlobalRule>("Rules", path, "rules", docPublication);
                                }
                                // no translations currently -- enable in future
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_psets.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocPropertySet>("Property Sets", path, "psets", docPublication);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_qsets.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocQuantitySet>("Quantity Sets", path, "qsets", docPublication);
                                }
                                

                                // generate localized listings
                                foreach (string locale in listLocale.Keys)
                                {
                                    string code = listLocale[locale]; // null for default

                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_definedtypes.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocDefined>("Defined Types", code, path, "definedtypes", docPublication);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_enumtypes.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocEnumeration>("Enumeration Types", code, path, "enumtypes", docPublication);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_selecttypes.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocSelect>("Select Types", code, path, "selecttypes", docPublication);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_entities.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocEntity>("Entities", code, path, "entities", docPublication);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_functions.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocFunction>("Functions", code, path, "functions", docPublication);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_rules.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocGlobalRule>("Rules", code, path, "rules", docPublication);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_psets.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocPropertySet>("Property Sets", code, path, "psets", docPublication);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_qsets.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocQuantitySet>("Quantity Sets", code, path, "qsets", docPublication);
                                    }

                                }
                                break;

                            case 'C':
                                // Inheritance listings

                                if (docProject.ModelViews != null)
                                {
                                    iView = 0;
                                    foreach (DocModelView docView in docProject.ModelViews)
                                    {
                                        if (included == null || included.ContainsKey(docView))
                                        {
                                            iView++;

                                            htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");

                                            htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/" + MakeLinkName(docView) + "/index.htm\" >C." + iView + " " + docView.Name + "</a>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C." + iView + " <a href=\"annex-c/" + MakeLinkName(docView) + "/index.htm\" target=\"info\" >" + docView.Name + "</a></td></tr>");

                                            // diagram for view
                                            if (!Properties.Settings.Default.SkipDiagrams)
                                            {
                                                Dictionary<DocObject, bool> viewinclude = new Dictionary<DocObject, bool>();
                                                Dictionary<Rectangle, DocEntity> mapRectangle = new Dictionary<Rectangle, DocEntity>();
                                                docProject.RegisterObjectsInScope(docView, viewinclude);
                                                using (Image imgDiagram = FormatPNG.CreateInheritanceDiagram(docProject, viewinclude, docEntityRoot, null, new Font(FontFamily.GenericSansSerif, 8.0f), mapRectangle))
                                                {
                                                    using (FormatHTM htmCover = new FormatHTM(path + @"\annex\annex-c\" + MakeLinkName(docView) + @"\index.htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmCover.WriteHeader(docView.Name, 3, docPublication.Header);
                                                        htmCover.WriteLine("<h2 class=\"std\">C." + iView + " " + docView.Name + " Inheritance</h2>");
                                                        htmCover.WriteLine("<img src=\"cover.png\" usemap=\"#f\"/>");
                                                        htmCover.WriteLine("<map name=\"f\">");

                                                        foreach (Rectangle rc in mapRectangle.Keys)
                                                        {
                                                            DocEntity docEntref = mapRectangle[rc];
                                                            DocSchema docEntsch = docProject.GetSchemaOfDefinition(docEntref);

                                                            string hyperlink = "../../../schema/" + docEntsch.Name.ToLower() + "/lexical/" + docEntref.Name.ToLower() + ".htm";
                                                            htmCover.WriteLine("<area shape=\"rect\" coords=\"" + rc.Left + "," + rc.Top + "," + rc.Right + "," + rc.Bottom + "\" href=\"" + hyperlink + "\" alt=\"" + docEntref.Name + "\" />");
                                                        }
                                                        htmCover.WriteLine("</map>");
                                                        htmCover.WriteLinkTo("inheritance-" + MakeLinkName(docView), 3);
                                                        htmCover.WriteFooter(String.Empty);

                                                        using (FormatHTM htmLink = new FormatHTM(path + "/link/inheritance-" + MakeLinkName(docView) + ".htm", mapEntity, mapSchema, included))
                                                        {
                                                            htmLink.WriteLinkPage("../annex/annex-c/" + DocumentationISO.MakeLinkName(docView) + "/index.htm", docPublication);
                                                        }
                                                    }

                                                    // create image after (depends on directory being created first)
                                                    try
                                                    {
                                                        imgDiagram.Save(path + @"\annex\annex-c\" + MakeLinkName(docView) + @"\cover.png");
                                                    }
                                                    catch
                                                    {

                                                    }
                                                }
                                            }

                                                                                            

                                            // all entities
                                            htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/" + MakeLinkName(docView) + "/all.htm\" >C." + iView + ".1 All entities</a>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C." + iView + ".1 <a href=\"annex-c/" + MakeLinkName(docView) + "/all.htm\" target=\"info\" >All entities</a></td></tr>");
                                            using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/" + MakeLinkName(docView) + "/all.htm", mapEntity, mapSchema, included))
                                            {
                                                htmInheritAll.WriteInheritanceListing(null, false, "All entities", docView, path, "all", docPublication);
                                            }

                                            // specific inheritance
                                            htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/" + MakeLinkName(docView) + "/roots.htm\" >C." + iView + ".2 Rooted entities</a>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C." + iView + ".2 <a href=\"annex-c/" + MakeLinkName(docView) + "/roots.htm\" target=\"info\" >Rooted entities</a></td></tr>");
                                            using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/" + MakeLinkName(docView) + "/roots.htm", mapEntity, mapSchema, included))
                                            {
                                                htmInheritAll.WriteInheritanceListing("IfcRoot", false, "Rooted entities", docView, path, "roots", docPublication);
                                            }

                                            htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/" + MakeLinkName(docView) + "/types.htm\" >C." + iView + ".3 Object types</a>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C." + iView + ".3 <a href=\"annex-c/" + MakeLinkName(docView) + "/types.htm\" target=\"info\" >Object types</a></td></tr>");
                                            using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/" + MakeLinkName(docView) + "/types.htm", mapEntity, mapSchema, included))
                                            {
                                                htmInheritAll.WriteInheritanceListing("IfcObject", true, "Object types", docView, path, "types", docPublication);
                                            }

                                            htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                        
                                        }
                                    }
                                }
                                break;

                            case 'D':
                                // Diagrams

                                // Express-G diagrams
                                htmTOC.WriteTOC(1, "D.1 Schema diagrams");
                                htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.1 Schema diagrams</td></tr>");

                                for (int iSchemaSection = 5; iSchemaSection <= 8; iSchemaSection++)
                                {
                                    DocSection docSection = docProject.Sections[iSchemaSection - 1];

                                    int iDiagramSection = iSchemaSection - 4;

                                    htmTOC.WriteTOC(2, "D.1." + iDiagramSection + " " + docSection.Name);
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.1." + iDiagramSection + " " + docSection.Name + "</td></tr>");


                                    int iSchema = 0;
                                    for (int iSchemaIndex = 1; iSchemaIndex <= docSection.Schemas.Count; iSchemaIndex++)
                                    {
                                        DocSchema docSchema = docSection.Schemas[iSchemaIndex - 1];
                                        if (included == null || included.ContainsKey(docSchema))
                                        {
                                            iSchema++;

                                            htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"annex/annex-d/" + MakeLinkName(docSchema) + "/index.htm\" >D.1." + iDiagramSection + "." + iSchema + " " + docSchema.Name + "</a>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.1." + iDiagramSection + "." + iSchema + " <a href=\"annex-d/" + MakeLinkName(docSchema) + "/index.htm\" target=\"info\" >" + docSchema.Name + "</a></td></tr>");

                                            // determine number of diagrams
                                            int iLastDiagram = docSchema.GetDiagramCount();

                                            // generate diagrams
                                            if (!Properties.Settings.Default.SkipDiagrams)
                                            {
                                                Image imageSchema = FormatPNG.CreateSchemaDiagram(docSchema, mapEntity, diagramformat);

                                                using (FormatHTM htmSchemaDiagram = new FormatHTM(path + "/annex/annex-d/" + MakeLinkName(docSchema) + "/index.htm", mapEntity, mapSchema, included))
                                                {
                                                    int iSub = 1;

                                                    htmSchemaDiagram.WriteHeader(docSection.Name, 3, docPublication.Header);
                                                    htmSchemaDiagram.WriteScript(iAnnex, iSub, iSection, 0);
                                                    htmSchemaDiagram.WriteLine("<h4 class=\"std\">D.1." + iDiagramSection + "." + iSchema + " " + docSchema.Name + "</h4>");

                                                    htmSchemaDiagram.WriteLine("<p>");

                                                    // write thumbnail links for each diagram
                                                    for (int iDiagram = 1; iDiagram <= iLastDiagram; iDiagram++)
                                                    {
                                                        string formatnumber = iDiagram.ToString("D4"); // 0001
                                                        htmSchemaDiagram.WriteLine("<a href=\"diagram_" + formatnumber + ".htm\">" +
                                                            "<img src=\"diagram_" + formatnumber + ".png\" width=\"300\" height=\"444\" /></a>"); // width=\"150\" height=\"222\"> 

                                                        // generate EXPRESS-G diagram
                                                        if (docSchema.DiagramPagesHorz != 0)
                                                        {
                                                            int pageY = (iDiagram - 1) / docSchema.DiagramPagesHorz;
                                                            int pageX = (iDiagram - 1) % docSchema.DiagramPagesHorz;
                                                            int pagePixelCX = CtlExpressG.PageX;
                                                            int pagePixelCY = CtlExpressG.PageY;
                                                            using (Image imagePage = new Bitmap(pagePixelCX, pagePixelCY))
                                                            {
                                                                using (Graphics g = Graphics.FromImage(imagePage))
                                                                {
                                                                    g.DrawImage(imageSchema, new Rectangle(0, 0, pagePixelCX, pagePixelCY), new Rectangle(pagePixelCX * pageX, pagePixelCY * pageY, pagePixelCX, pagePixelCY), GraphicsUnit.Pixel);
                                                                }
                                                                imagePage.Save(path + "/annex/annex-d/" + MakeLinkName(docSchema) + "/diagram_" + formatnumber + ".png");
                                                            }
                                                        }
                                                    }

                                                    htmSchemaDiagram.WriteLine("</p>");
                                                    htmSchemaDiagram.WriteFooter(docPublication.Footer);
                                                }


                                                double scale = 0.375; // hard-coded for now -- read from SCHEMATA.scale
                                                double pageCX = 1600; // hard-coded for now -- read from SCHEMATA.settings.page.width
                                                double pageCY = 2370; // hard-coded for now -- read from SCHEMATA.settings.page.height

                                                for (int iDiagram = 1; iDiagram <= iLastDiagram; iDiagram++)
                                                {
                                                    string formatnumber = iDiagram.ToString("D4");
                                                    using (FormatHTM htmSchema = new FormatHTM(path + "/annex/annex-d/" + MakeLinkName(docSchema) + "/diagram_" + formatnumber + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmSchema.WriteHeader(docSchema.Name, 3, docPublication.Header);
                                                        htmSchema.WriteScript(iAnnex, 1, iDiagramSection, iDiagram);

                                                        htmSchema.WriteLine("<h4 class=\"std\">");
                                                        if (iDiagram > 1)
                                                        {
                                                            htmSchema.Write("<a href=\"diagram_" + (iDiagram - 1).ToString("D4") + ".htm\"><img src=\"../../../img/navleft.png\" style=\"border: 0px\" /></a>");
                                                        }
                                                        else
                                                        {
                                                            // disabled
                                                            htmSchema.Write("<img src=\"../../../img/navleft.png\" style=\"border: 0px\" />");
                                                        }
                                                        if (iDiagram < iLastDiagram)
                                                        {
                                                            htmSchema.Write("<a href=\"diagram_" + (iDiagram + 1).ToString("D4") + ".htm\"><img src=\"../../../img/navright.png\" style=\"border: 0px\" /></a>");
                                                        }
                                                        else
                                                        {
                                                            // disabled
                                                            htmSchema.Write("<img src=\"../../../img/navright.png\" style=\"border: 0px\" />");
                                                        }
                                                        htmSchema.Write(" " + docSchema.Name + " (" + iDiagram + "/" + iLastDiagram + ")");
                                                        htmSchema.WriteLine("</h4>");

                                                        htmSchema.WriteLine("<img src=\"diagram_" + formatnumber + ".png\" usemap=\"#diagram\" >");
                                                        htmSchema.WriteLine("  <map name=\"diagram\" >");
                                                        foreach (DocType docType in docSchema.Types)
                                                        {
                                                            if ((included == null || included.ContainsKey(docType)) && docType.DiagramNumber == iDiagram && docType.DiagramRectangle != null)
                                                            {
                                                                double x0 = docType.DiagramRectangle.X % pageCX * scale;
                                                                double y0 = docType.DiagramRectangle.Y % pageCY * scale;
                                                                double x1 = docType.DiagramRectangle.X % pageCX * scale + docType.DiagramRectangle.Width % pageCX * scale;
                                                                double y1 = docType.DiagramRectangle.Y % pageCY * scale + docType.DiagramRectangle.Height % pageCY * scale;
                                                                string link = "../../../schema/" + mapSchema[docType.Name].ToLower() + "/lexical/" + docType.Name.ToLower() + ".htm";
                                                                htmSchema.WriteLine("    <area shape=\"rect\" coords=\"" + x0 + ", " + y0 + ", " + x1 + ", " + y1 + "\" alt=\"Navigate\" href=\"" + link + "\" />");
                                                            }
                                                        }
                                                        foreach (DocEntity docType in docSchema.Entities)
                                                        {
                                                            if ((included == null || included.ContainsKey(docType)) && docType.DiagramNumber == iDiagram && docType.DiagramRectangle != null)
                                                            {
                                                                double x0 = docType.DiagramRectangle.X % pageCX * scale;
                                                                double y0 = docType.DiagramRectangle.Y % pageCY * scale;
                                                                double x1 = docType.DiagramRectangle.X % pageCX * scale + docType.DiagramRectangle.Width % pageCX * scale;
                                                                double y1 = docType.DiagramRectangle.Y % pageCY * scale + docType.DiagramRectangle.Height % pageCY * scale;
                                                                string link = "../../../schema/" + mapSchema[docType.Name].ToLower() + "/lexical/" + docType.Name.ToLower() + ".htm";
                                                                htmSchema.WriteLine("    <area shape=\"rect\" coords=\"" + x0 + ", " + y0 + ", " + x1 + ", " + y1 + "\" alt=\"Navigate\" href=\"" + link + "\" />");
                                                            }
                                                        }
                                                        if (docSchema.PageTargets != null)
                                                        {
                                                            foreach (DocPageTarget docPageTarget in docSchema.PageTargets)
                                                            {
                                                                foreach (DocPageSource docPageSource in docPageTarget.Sources)
                                                                {
                                                                    if (docPageSource.DiagramNumber == iDiagram && docPageSource.DiagramRectangle != null)
                                                                    {
                                                                        double x0 = docPageSource.DiagramRectangle.X % pageCX * scale;
                                                                        double y0 = docPageSource.DiagramRectangle.Y % pageCY * scale;
                                                                        double x1 = docPageSource.DiagramRectangle.X % pageCX * scale + docPageSource.DiagramRectangle.Width % pageCX * scale;
                                                                        double y1 = docPageSource.DiagramRectangle.Y % pageCY * scale + docPageSource.DiagramRectangle.Height % pageCY * scale;
                                                                        string link = "diagram_" + docPageTarget.DiagramNumber.ToString("D4") + ".htm";
                                                                        htmSchema.WriteLine("    <area shape=\"rect\" coords=\"" + x0 + ", " + y0 + ", " + x1 + ", " + y1 + "\" alt=\"Navigate\" href=\"" + link + "\" />");
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        if (docSchema.SchemaRefs != null)
                                                        {
                                                            foreach (DocSchemaRef docSchemaRef in docSchema.SchemaRefs)
                                                            {
                                                                foreach (DocDefinitionRef docDefinitionRef in docSchemaRef.Definitions)
                                                                {
                                                                    if (docDefinitionRef.DiagramNumber == iDiagram && docDefinitionRef.DiagramRectangle != null)
                                                                    {
                                                                        double x0 = docDefinitionRef.DiagramRectangle.X % pageCX * scale;
                                                                        double y0 = docDefinitionRef.DiagramRectangle.Y % pageCY * scale;
                                                                        double x1 = docDefinitionRef.DiagramRectangle.X % pageCX * scale + docDefinitionRef.DiagramRectangle.Width % pageCX * scale;
                                                                        double y1 = docDefinitionRef.DiagramRectangle.Y % pageCY * scale + docDefinitionRef.DiagramRectangle.Height % pageCY * scale;

                                                                        if (mapSchema.ContainsKey(docDefinitionRef.Name))
                                                                        {
                                                                            DocDefinition docDef = mapEntity[docDefinitionRef.Name] as DocDefinition;
                                                                            if (included == null || included.ContainsKey(docDef))
                                                                            {
                                                                                string link = "../../../schema/" + mapSchema[docDefinitionRef.Name].ToLower() + "/lexical/" + docDefinitionRef.Name.ToLower() + ".htm";
                                                                                htmSchema.WriteLine("    <area shape=\"rect\" coords=\"" + x0 + ", " + y0 + ", " + x1 + ", " + y1 + "\" alt=\"Navigate\" href=\"" + link + "\" />");
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        htmSchema.WriteLine("  </map>");
                                                        htmSchema.WriteLine("</img>");
                                                        htmSchema.WriteFooter(docPublication.Footer);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                // Instance diagrams
                                htmTOC.WriteTOC(1, "D.2 Instance diagrams");
                                htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.2 Instance diagrams</td></tr>");

                                // D.1 -- schema diagrams - express-G
                                // D.1.1 -- core layer
                                // D.1.2 -- shared layer
                                // D.1.3 -- domain layer
                                // D.1.4 -- resource layer
                                // D.1.4.1~ schema

                                // D.2 -- instance diagrams
                                // D.2.1~  model view
                                // D.2.1.1~  entity

                                if (docProject.ModelViews != null)
                                {
                                    iView = 0;
                                    foreach (DocModelView docView in docProject.ModelViews)
                                    {
                                        if (included == null || included.ContainsKey(docView))
                                        {
                                            iView++;

                                            htmTOC.WriteTOC(2, "D.2." + iView.ToString() + " " + docView.Name);
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.2." + iView.ToString() + "<a href=\"annex-d/" + MakeLinkName(docView) + "/cover.htm\" target=\"info\"> " + docView.Name + "</a></td></tr>");


                                            Dictionary<DocObject, bool> viewinclude = new Dictionary<DocObject, bool>();
                                            Dictionary<Rectangle, DocEntity> mapRectangle = new Dictionary<Rectangle, DocEntity>();
                                            docProject.RegisterObjectsInScope(docView, viewinclude);
                                            using (FormatHTM htmCover = new FormatHTM(path + @"\annex\annex-d\" + MakeLinkName(docView) + @"\cover.htm", mapEntity, mapSchema, included))
                                            {
                                                htmCover.WriteHeader(docView.Name, 3, docPublication.Header);
                                                htmCover.WriteLine("<h3 class=\"std\">D.2." + iView + " " + docView.Name + " Diagrams</h3>");
                                                htmCover.WriteFooter(String.Empty);
                                            }

                                            // sort by entity name
                                            SortedList<string, DocConceptRoot> listEntity = new SortedList<string, DocConceptRoot>();
                                            foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                                            {
                                                if (docRoot.ApplicableEntity != null)
                                                {
                                                    if (!listEntity.ContainsKey(docRoot.ApplicableEntity.Name)) // only one concept root per entity per view currently supported
                                                    {
                                                        listEntity.Add(docRoot.ApplicableEntity.Name, docRoot);
                                                    }
                                                }
                                            }

                                            // now generate
                                            int iRoot = 0;
                                            foreach (DocConceptRoot docRoot in listEntity.Values)
                                            {
                                                iRoot++;

                                                htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"annex/annex-d/" + MakeLinkName(docView) + "/" + MakeLinkName(docRoot.ApplicableEntity) + ".htm\" >D.2." + iView.ToString() + "." + iRoot.ToString() + " " + docRoot.ApplicableEntity.Name + "</a>");
                                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.2." + iView.ToString() + "." + iRoot.ToString() + " <a href=\"annex-d/" + MakeLinkName(docView) + "/" + MakeLinkName(docRoot.ApplicableEntity) + ".htm\" target=\"info\">" + docRoot.ApplicableEntity.Name + "</a></td></tr>");

                                                string pathRoot = path + @"\annex\annex-d\" + MakeLinkName(docView) + @"\" + MakeLinkName(docRoot.ApplicableEntity) + ".htm";
                                                using (FormatHTM htmRoot = new FormatHTM(pathRoot, mapEntity, mapSchema, included))
                                                {
                                                    htmRoot.WriteHeader(docRoot.ApplicableEntity.Name, iAnnex, 2, 0, iView, docPublication.Header);
                                                    htmRoot.WriteScript(iAnnex, 2, iView, iRoot);
                                                    htmRoot.WriteLine("<h3 class=\"std\">D.2." + iView.ToString() + "." + iRoot.ToString() + " " + docRoot.ApplicableEntity.Name + "</h3>");

                                                    string diagram = FormatDiagram(docProject, docRoot.ApplicableEntity, docView, listFigures, mapEntity, mapSchema, path);
                                                    htmRoot.WriteLine(diagram);

                                                    htmRoot.WriteFooter(docPublication.Footer);
                                                }

                                            }
                                        }
                                    }
                                }                                
                                break;

                            case 'E':
                                if (docProject.Examples != null)
                                {
                                    List<DocXsdFormat> xsdFormatBase = new List<DocXsdFormat>();
                                    foreach(DocSection docSection in docProject.Sections)
                                    {
                                        foreach(DocSchema docSchema in docSection.Schemas)
                                        {
                                            foreach(DocEntity docEntity in docSchema.Entities)
                                            {
                                                foreach(DocAttribute docAttr in docEntity.Attributes)
                                                {
                                                    if(docAttr.XsdFormat != DocXsdFormatEnum.Default || docAttr.XsdTagless != null)
                                                    {
                                                        DocXsdFormat xsdformat = new DocXsdFormat();
                                                        xsdformat.Entity = docEntity.Name;
                                                        xsdformat.Attribute = docAttr.Name;
                                                        xsdformat.XsdFormat = docAttr.XsdFormat;
                                                        xsdformat.XsdTagless = docAttr.XsdTagless;
                                                        xsdFormatBase.Add(xsdformat);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    List<int> indexpath = new List<int>();
                                    indexpath.Add(0);
                                    foreach(DocExample docExample in docProject.Examples)
                                    {
                                        Dictionary<string, Type> typemap = new Dictionary<string, Type>();
                                        Compiler compiler = new Compiler(docProject, docExample.Views.ToArray(), null);
                                        System.Reflection.Emit.AssemblyBuilder assembly = compiler.Assembly;
                                        try
                                        {
                                            Type[] types = assembly.GetTypes();
                                            foreach (Type t in types)
                                            {
                                                typemap.Add(t.Name.ToUpper(), t);
                                            }
                                        }
                                        catch
                                        {
                                            // schema could not be compiled according to definition
                                        }

                                        List<DocXsdFormat> listFormats = new List<DocXsdFormat>(xsdFormatBase);
                                        if (docExample.Views.Count > 0)
                                        {
                                            foreach (DocXsdFormat customformat in docExample.Views[0].XsdFormats)
                                            {
                                                listFormats.Add(customformat);
                                            }
                                        }

                                        GenerateExample(docPublication, docExample, listFormats, path, indexpath, included, mapEntity, mapSchema, typemap, listFigures, listTables, htmTOC, htmSectionTOC, null);
                                    }
                                }
                                break;

                            case 'F':
                                if (docProject.ChangeSets != null)
                                {
                                    for (int iChangeset = 1; iChangeset <= docProject.ChangeSets.Count; iChangeset++)
                                    {
                                        DocChangeSet docChangeSet = docProject.ChangeSets[iChangeset - 1];

                                        // what's new page
                                        htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-f/" + MakeLinkName(docChangeSet) + "/index.htm\" >F." + iChangeset + " " + docChangeSet.Name + "</a>");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">F." + iChangeset + " <a href=\"annex-f/" + MakeLinkName(docChangeSet) + "/index.htm\" target=\"info\" >" + docChangeSet.Name + "</a></td></tr>");
                                        using (FormatHTM htmWhatsnew = new FormatHTM(path + @"\annex\annex-f\" + MakeLinkName(docChangeSet) + @"\index.htm", mapEntity, mapSchema, included))
                                        {
                                            htmWhatsnew.WriteHeader(docChangeSet.Name, 3, docPublication.Header);
                                            htmWhatsnew.WriteScript(iAnnex, iChangeset, 0, 0);
                                            htmWhatsnew.WriteLine("<h4 class=\"std\">F." + iChangeset + " " + docChangeSet.Name + "</h4>");
                                            htmWhatsnew.WriteDocumentationMarkup(docChangeSet.Documentation, docChangeSet, docPublication);
                                            htmWhatsnew.WriteLinkTo(MakeLinkName(docChangeSet), 3);
                                            htmWhatsnew.WriteFooter(docPublication.Footer);
                                        }

                                        // change log for entities
                                        htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-f/" + MakeLinkName(docChangeSet) + "/changelog.htm\" >F." + iChangeset + ".1 Entities</a>");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a href=\"annex-f/" + MakeLinkName(docChangeSet) + "/changelog.htm\" target=\"info\" >F." + iChangeset + ".1 Entities</a></td></tr>");
                                        string pathChange = path + @"\annex\annex-f\" + MakeLinkName(docChangeSet) + @"\changelog.htm";
                                        using (FormatHTM htmChange = new FormatHTM(pathChange, mapEntity, mapSchema, included))
                                        {
                                            htmChange.WriteHeader(docChangeSet.Name, 3, docPublication.Header);
                                            htmChange.WriteScript(iAnnex, iChangeset, 1, 0);
                                            htmChange.WriteLine("<h4 class=\"std\">F." + iChangeset + ".1 Entities</h4>");

                                            htmChange.WriteLine("<table class=\"gridtable\">");
                                            htmChange.WriteLine("<tr>" +
                                                "<th>Item</th>" +
                                                "<th>SPF</th>" +
                                                "<th>XML</th>" +
                                                "<th>Change</th>" +
                                                "<th>Description</th>" +
                                                "</tr>");

                                            foreach (DocChangeAction docChangeItem in docChangeSet.ChangesEntities)
                                            {
                                                htmChange.WriteChangeItem(docChangeItem, 0);
                                            }

                                            htmChange.WriteLine("</table>");
                                            htmChange.WriteLinkTo(MakeLinkName(docChangeSet) + "-changelog", 3);
                                            htmChange.WriteFooter(docPublication.Footer);
                                        }

                                        // change log for properties
                                        htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-f/" + MakeLinkName(docChangeSet) + "/properties.htm\" >F." + iChangeset + ".2 Properties</a>");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a href=\"annex-f/" + MakeLinkName(docChangeSet) + "/properties.htm\" target=\"info\" >F." + iChangeset + ".1 Properties</a></td></tr>");
                                        pathChange = path + @"\annex\annex-f\" + MakeLinkName(docChangeSet) + @"\properties.htm";
                                        using (FormatHTM htmChange = new FormatHTM(pathChange, mapEntity, mapSchema, included))
                                        {
                                            htmChange.WriteHeader(docChangeSet.Name, 3, docPublication.Header);
                                            htmChange.WriteScript(iAnnex, iChangeset, 1, 0);
                                            htmChange.WriteLine("<h4 class=\"std\">F." + iChangeset + ".2 Properties</h4>");

                                            htmChange.WriteLine("<table class=\"gridtable\">");
                                            htmChange.WriteLine("<tr>" +
                                                "<th>Item</th>" +
                                                "<th>SPF</th>" +
                                                "<th>XML</th>" +
                                                "<th>Change</th>" +
                                                "<th>Description</th>" +
                                                "</tr>");

                                            if (docChangeSet.ChangesProperties != null)
                                            {
                                                foreach (DocChangeAction docChangeItem in docChangeSet.ChangesProperties)
                                                {
                                                    htmChange.WriteChangeItem(docChangeItem, 0);
                                                }
                                            }

                                            htmChange.WriteLine("</table>");
                                            htmChange.WriteLinkTo(MakeLinkName(docChangeSet) + "-properties", 3);
                                            htmChange.WriteFooter(docPublication.Footer);
                                        }


                                        // change log for quantities
                                        htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-f/" + MakeLinkName(docChangeSet) + "/quantities.htm\" >F." + iChangeset + ".3 Quantities</a>");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a href=\"annex-f/" + MakeLinkName(docChangeSet) + "/quantities.htm\" target=\"info\" >F." + iChangeset + ".3 Quantities</a></td></tr>");
                                        pathChange = path + @"\annex\annex-f\" + MakeLinkName(docChangeSet) + @"\quantities.htm";
                                        using (FormatHTM htmChange = new FormatHTM(pathChange, mapEntity, mapSchema, included))
                                        {
                                            htmChange.WriteHeader(docChangeSet.Name, 3, docPublication.Header);
                                            htmChange.WriteScript(iAnnex, iChangeset, 1, 0);
                                            htmChange.WriteLine("<h4 class=\"std\">F." + iChangeset + ".3 Quantities</h4>");

                                            htmChange.WriteLine("<table class=\"gridtable\">");
                                            htmChange.WriteLine("<tr>" +
                                                "<th>Item</th>" +
                                                "<th>SPF</th>" +
                                                "<th>XML</th>" +
                                                "<th>Change</th>" +
                                                "<th>Description</th>" +
                                                "</tr>");

                                            if (docChangeSet.ChangesQuantities != null)
                                            {
                                                foreach (DocChangeAction docChangeItem in docChangeSet.ChangesQuantities)
                                                {
                                                    htmChange.WriteChangeItem(docChangeItem, 0);
                                                }
                                            }

                                            htmChange.WriteLine("</table>");
                                            htmChange.WriteLinkTo(MakeLinkName(docChangeSet) + "-quantities", 3);
                                            htmChange.WriteFooter(docPublication.Footer);
                                        }

                                    }
                                }
                                break;
                        }

                        htmSectionTOC.WriteLine(
                            "</table>\r\n" +
                            "</div>\r\n" +
                            "</body>\r\n" +
                            "</html>\r\n");
                    }

                    chAnnex++;
                }

                // bibliography
                try
                {
                    using (FormatHTM htmSection = new FormatHTM(path + @"\bibliography.htm", mapEntity, mapSchema, included))
                    {
                        htmSection.WriteHeader("Bibliography", 0, docPublication.Header);

                        htmSection.Write(
                            "\r\n" +
                            "<script type=\"text/javascript\">\r\n" +
                            "<!--\r\n" +
                            "    parent.index.location.replace(\"blank.htm\");\r\n" +
                            "//-->\r\n" +
                            "</script>\r\n");

                        htmSection.WriteLine("<h1>Bibliography</h1>");

                        htmSection.WriteLine("<dl>");
                        if (docProject.InformativeReferences != null)
                        {
                            foreach (DocReference docRef in docProject.InformativeReferences)
                            {
                                htmSection.WriteLine("<dt class=\"bibliographyreference\"><a id=\"" + MakeLinkName(docRef) + "\" id=\"" + MakeLinkName(docRef) + "\">" + docRef.Name + "</a>, <i>" + docRef.Documentation + "</i></dt>");
                                htmSection.WriteLine("<dd>&nbsp;</dd>");
                            }
                        }
                        htmSection.WriteLine("</dl>");

                        htmSection.WriteFooter(docPublication.Footer);
                    }
                }
                catch
                {
                    htmTOC.ToString();
                }

                htmTOC.WriteLine("</p>");


                // write figures
                htmTOC.WriteLine("<h1 class=\"std\">Figures</h1>");
                htmTOC.WriteLine("<p>");
                htmTOC.WriteContentRefs(listFigures, "Figure");
                htmTOC.WriteLine("</p>");

                htmTOC.WriteLine("<p></p>");

                // write tables
                htmTOC.WriteLine("<h1 class=\"std\">Tables</h1>");
                htmTOC.WriteLine("<p>");
                htmTOC.WriteContentRefs(listTables, "Table");
                htmTOC.WriteLine("</p>");

                htmTOC.WriteFooter(docPublication.Footer);
            }

            worker.ReportProgress(++progressCurrent, "Index");
            if (worker.CancellationPending)
                return;

            // generate index -- takes very long, so only run when changing
            SortedList<string, DocObject> listIndex = new SortedList<string, DocObject>();
            foreach (string key in mapEntity.Keys)
            {
                listIndex.Add(key, mapEntity[key]);
            }

            using (FormatHTM htmIndex = new FormatHTM(path + "/doc_index.htm", mapEntity, mapSchema, included)) // file name "doc_index" required by ISO
            {
                htmIndex.WriteHeader("Index", 0, docPublication.Header);

                htmIndex.Write(
                    "\r\n" +
                    "<script type=\"text/javascript\">\r\n" +
                    "<!--\r\n" +
                    "    parent.index.location.replace(\"blank.htm\");\r\n" +
                    "//-->\r\n" +
                    "</script>\r\n");

                htmIndex.WriteLine(
                    "<div class=\"not-numbered\">\r\n" +
                    "<h1 class=\"std\">Index</h1>\r\n" +
                    "<p class=\"std\">\r\n");

                foreach (string key in listIndex.Keys)
                {
                    DocObject obj = mapEntity[key];
                    if (included == null || included.ContainsKey(obj))
                    {
                        htmIndex.WriteLine("<b>" + key + "</b> ");

                        // build ordered list of references in documentation
                        SortedDictionary<string, string> mapRefs = new SortedDictionary<string, string>();
                        foreach (string refkey1 in listIndex.Keys)
                        {
                            string doc = mapEntity[refkey1].Documentation;
                            if (doc != null)// && key != refkey) // also include main ref for ISO
                            {
                                if (refkey1 == key || doc.Contains(key))
                                {
                                    DocObject refobj = (DocObject)mapEntity[refkey1];

                                    string refnumber = null;
                                    if (mapNumber != null && mapNumber.TryGetValue(refobj, out refnumber))
                                    {
                                        mapRefs.Add(refnumber, refkey1);
                                    }

                                }
                            }
                        }

                        // search references of terms in documentation
                        string comma = "";
                        foreach (string refnumber in mapRefs.Keys)
                        {
                            string refkey = mapRefs[refnumber];

                            DocObject refobj = (DocObject)mapEntity[refkey];
                            string display = refobj.Name;//refnumber; // new: use names for bSI; numbers for ISO

                            if (refobj is DocPropertySet || refobj is DocPropertyEnumeration)
                            {
                                htmIndex.Write(comma + "<a class=\"listing-link\" title=\"" + refobj.Name + "\" href=\"schema/" + mapSchema[refkey].ToLower() + "/pset/" + refobj.Name.ToLower() + ".htm\">" + display + "</a>");
                            }
                            else if (refobj is DocQuantitySet)
                            {
                                htmIndex.Write(comma + "<a class=\"listing-link\" title=\"" + refobj.Name + "\" href=\"schema/" + mapSchema[refkey].ToLower() + "/qset/" + refobj.Name.ToLower() + ".htm\">" + display + "</a>");
                            }
                            else
                            {
                                htmIndex.Write(comma + "<a class=\"listing-link\" title=\"" + refobj.Name + "\" href=\"schema/" + mapSchema[refkey].ToLower() + "/lexical/" + refobj.Name.ToLower() + ".htm\">" + display + "</a>");
                            }

                            comma = ", ";
                        }

                        htmIndex.WriteLine("<br />\r\n");
                    }
                }

                worker.ReportProgress(++progressCurrent, "Links");
                if (worker.CancellationPending)
                    return;

                // new: incoming links
                foreach(DocSection docLinkSection in docProject.Sections)
                {
                    int iSection = docProject.Sections.IndexOf(docLinkSection) + 1;
                    using (FormatHTM htmLink = new FormatHTM(path + "/link/chapter-" + iSection.ToString() + ".htm", mapEntity, mapSchema, included))
                    {
                        htmLink.WriteLinkPage("../schema/chapter-" + iSection.ToString() + ".htm", docPublication);
                    }

                    foreach (DocSchema docLinkSchema in docLinkSection.Schemas)
                    {
                        using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docLinkSchema) + ".htm", mapEntity, mapSchema, included))
                        {
                            htmLink.WriteLinkPage("../schema/" + docLinkSchema.Name.ToLower() + "/content.htm", docPublication);
                        }

                        foreach (DocEntity docLinkObj in docLinkSchema.Entities)
                        {
                            if (included == null || included.ContainsKey(docLinkObj))
                            {
                                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docLinkObj) + ".htm", mapEntity, mapSchema, included))
                                {
                                    htmLink.WriteLinkPage("../schema/" + docLinkSchema.Name.ToLower() + "/lexical/" + MakeLinkName(docLinkObj) + ".htm", docPublication);
                                }
                            }
                        }

                        foreach(DocType docLinkObj in docLinkSchema.Types)
                        {
                            if (included == null || included.ContainsKey(docLinkObj))
                            {
                                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docLinkObj) + ".htm", mapEntity, mapSchema, included))
                                {
                                    htmLink.WriteLinkPage("../schema/" + docLinkSchema.Name.ToLower() + "/lexical/" + MakeLinkName(docLinkObj) + ".htm", docPublication);
                                }
                            }
                        }

                        foreach (DocFunction docLinkObj in docLinkSchema.Functions)
                        {
                            if (included == null || included.ContainsKey(docLinkObj))
                            {
                                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docLinkObj) + ".htm", mapEntity, mapSchema, included))
                                {
                                    htmLink.WriteLinkPage("../schema/" + docLinkSchema.Name.ToLower() + "/lexical/" + MakeLinkName(docLinkObj) + ".htm", docPublication);
                                }
                            }
                        }

                        foreach (DocGlobalRule docLinkObj in docLinkSchema.GlobalRules)
                        {
                            if (included == null || included.ContainsKey(docLinkObj))
                            {
                                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docLinkObj) + ".htm", mapEntity, mapSchema, included))
                                {
                                    htmLink.WriteLinkPage("../schema/" + docLinkSchema.Name.ToLower() + "/lexical/" + MakeLinkName(docLinkObj) + ".htm", docPublication);
                                }
                            }
                        }

                        foreach (DocPropertySet docLinkObj in docLinkSchema.PropertySets)
                        {
                            if (included == null || included.ContainsKey(docLinkObj))
                            {
                                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docLinkObj) + ".htm", mapEntity, mapSchema, included))
                                {
                                    htmLink.WriteLinkPage("../schema/" + docLinkSchema.Name.ToLower() + "/pset/" + MakeLinkName(docLinkObj) + ".htm", docPublication);
                                }
                            }
                        }

                        foreach (DocPropertyEnumeration docLinkObj in docLinkSchema.PropertyEnums)
                        {
                            if (included == null || included.ContainsKey(docLinkObj))
                            {
                                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docLinkObj) + ".htm", mapEntity, mapSchema, included))
                                {
                                    htmLink.WriteLinkPage("../schema/" + docLinkSchema.Name.ToLower() + "/pset/" + MakeLinkName(docLinkObj) + ".htm", docPublication);
                                }
                            }
                        }

                        foreach (DocQuantitySet docLinkObj in docLinkSchema.QuantitySets)
                        {
                            if (included == null || included.ContainsKey(docLinkObj))
                            {
                                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docLinkObj) + ".htm", mapEntity, mapSchema, included))
                                {
                                    htmLink.WriteLinkPage("../schema/" + docLinkSchema.Name.ToLower() + "/qset/" + MakeLinkName(docLinkObj) + ".htm", docPublication);
                                }
                            }
                        }
                    }
                }

                char chAnnex = 'a';
                foreach(DocAnnex docAnnex in docProject.Annexes)
                {
                    using (FormatHTM htmLink = new FormatHTM(path + "/link/annex-" + chAnnex + ".htm", mapEntity, mapSchema, included))
                    {
                        htmLink.WriteLinkPage("../annex/annex-" + chAnnex + ".htm", docPublication);
                    }

                    chAnnex++;
                }

                foreach(DocAnnotation docAnnot in docProject.Annotations)
                {
                    using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docAnnot) + ".htm", mapEntity, mapSchema, included))
                    {
                        htmLink.WriteLinkPage("../" + MakeLinkName(docAnnot) + ".htm", docPublication);
                    }
                }

                foreach(DocChangeSet docChange in docProject.ChangeSets)
                {
                    using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docChange) + ".htm", mapEntity, mapSchema, included))
                    {
                        htmLink.WriteLinkPage("../annex/annex-f/" + MakeLinkName(docChange) + "/index.htm", docPublication);
                    }
                    using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docChange) + "-changelog.htm", mapEntity, mapSchema, included))
                    {
                        htmLink.WriteLinkPage("../annex/annex-f/" + MakeLinkName(docChange) + "/changelog.htm", docPublication);
                    }
                    using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docChange) + "-properties.htm", mapEntity, mapSchema, included))
                    {
                        htmLink.WriteLinkPage("../annex/annex-f/" + MakeLinkName(docChange) + "/properties.htm", docPublication);
                    }
                    using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docChange) + "-quantities.htm", mapEntity, mapSchema, included))
                    {
                        htmLink.WriteLinkPage("../annex/annex-f/" + MakeLinkName(docChange) + "/quantities.htm", docPublication);
                    }
                }

                foreach(DocModelView docView in docProject.ModelViews)
                {
                    if (docView.Code != null)
                    {
                        using (FormatHTM htmLink = new FormatHTM(path + "/link/listing-" + docView.Code.ToLower() + ".htm", mapEntity, mapSchema, included))
                        {
                            htmLink.WriteLinkPage("../annex/annex-a/" + MakeLinkName(docView) + "/index.htm", docPublication);
                        }
                    }
                }

#if false
                foreach (string key in listIndex.Keys)
                {
                    DocObject obj = mapEntity[key];
                    if (included == null || included.ContainsKey(obj))
                    {
                        string schemaname = null;
                        if (mapSchema.TryGetValue(obj.Name, out schemaname))
                        {
                            using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(obj) + ".htm", mapEntity, mapSchema, included))
                            {
                                string linkurl = "../schema/" + schemaname.ToLower() + "/lexical/" + MakeLinkName(obj) + ".htm";
                                if (obj is DocPropertySet || obj is DocPropertyEnumeration)
                                {
                                    linkurl = "../schema/" + schemaname.ToLower() + "/pset/" + MakeLinkName(obj) + ".htm";
                                }
                                else if (obj is DocQuantitySet)
                                {
                                    linkurl = "../schema/" + schemaname.ToLower() + "/qset/" + MakeLinkName(obj) + ".htm";
                                }

                                htmLink.WriteLinkPage(linkurl);
                            }
                        }
                    }
                }
#endif

                // write links for each concept template recursively
                List<DocTemplateDefinition> listLink = new List<DocTemplateDefinition>();
                foreach (DocTemplateDefinition docTemplate in docProject.Templates)
                {
                    listLink.Add(docTemplate);
                    GenerateTemplateLink(listLink, mapEntity, mapSchema, included, docPublication, path);
                    listLink.Clear();
                }

                // write links for each example recursively
                List<DocExample> listLinkExample = new List<DocExample>();
                if (docProject.Examples != null)
                {
                    foreach (DocExample docTemplate in docProject.Examples)
                    {
                        listLinkExample.Add(docTemplate);
                        GenerateExampleLink(listLinkExample, mapEntity, mapSchema, included, docPublication, path);
                        listLinkExample.Clear();
                    }
                }

                htmIndex.WriteLine("</p>");
                htmIndex.WriteFooter(docPublication.Footer);
            }
        }
    }
}

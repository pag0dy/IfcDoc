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
using IfcDoc.Format.SPF;
using IfcDoc.Format.PNG;

namespace IfcDoc
{
    public static class DocumentationISO
    {
        /// <summary>
        /// Exports file according to format.
        /// </summary>
        /// <param name="filepath">File path to export.</param>
        /// <param name="templates">Optional filter of templates to export.</param>
        /// <param name="views">Optional filter of views to export.</param>
        /// <param name="schemas">Optional filter of schemas to export.</param>
        /// <param name="locales">Optional filter of locales to export.</param>
        /// <param name="formatted">If true, appends .txt extension and generates formatted htm file for documentation purposes.</param>
        public static void DoExport(DocProject docProject, string filepath, DocModelView[] views, string[] locales, Dictionary<long, SEntity> instances, bool formatted)
        {
            string ext = System.IO.Path.GetExtension(filepath).ToLower();

            if (formatted)
            {
                filepath = filepath + ".txt";
            }

            Dictionary<DocObject, bool> included = null;
            if (views != null)
            {
                included = new Dictionary<DocObject, bool>();
                foreach (DocModelView docView in views)
                {
                    docProject.RegisterObjectsInScope(docView, included);
                }
            }

            switch (ext)
            {
                case ".ifc":
                    using (FormatSPF format = new FormatSPF(filepath, Schema.IFC.SchemaIfc.Types, instances))
                    {
                        format.InitHeaders(filepath, "IFC4");
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
        private static string FormatExchange(DocProject docProject, DocModelView docView, DocExchangeDefinition def, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema)
        {
            // format content
            StringBuilder sb = new StringBuilder();

            // 1. manual content
            sb.Append(def.Documentation);

            // 2. map of entities and templates -- Identity | Template | Import | Export
            sb.AppendLine("<p></p>");//This exchange involves the following entities:</p>");

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

            // new style - table
            sb.AppendLine("<table class=\"exchange\">");
            sb.AppendLine("<tr><th colspan=\"5\"><img src=\"../../../img/mvd-" + def.Name.ToLower().Replace(' ', '-') + ".png\" />&nbsp; " + def.Name + "</th></tr>");
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


                        string table = FormatConceptTable(docProject, docView, docRoot.ApplicableEntity, docRoot, docConcept, mapEntity, mapSchema);
                        sb.Append(table);
#if false
                    first = true;

                    // build list of inherited items
                    DocTemplateItem[] items = FindTemplateItems(docProject, docRoot.ApplicableEntity, docConcept.Definition, docModelView);
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
                        sb.Append("</td><td>");
                        AppendRequirement(sb, reqImport, 3);
                        sb.Append("</td><td>");
                        AppendRequirement(sb, reqExport, 3);
                        sb.AppendLine("</td></tr>");

                    }
                }

            }
            sb.AppendLine("</table>");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="docTemplate"></param>
        /// <param name="path">Path of templates</param>
        /// <param name="mapEntity"></param>
        /// <param name="mapSchema"></param>
        private static void GenerateTemplateLink(List<DocTemplateDefinition> path, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, Dictionary<DocObject, bool> included)
        {
            DocTemplateDefinition docTemplateLast = path[path.Count - 1];

            // flat list -- requires unique template names
            StringBuilder sbFile = new StringBuilder();
            sbFile.Append(Properties.Settings.Default.OutputPath);
            sbFile.Append(@"\link\");
            sbFile.Append(MakeLinkName(docTemplateLast));
            sbFile.Append(".htm");

            StringBuilder sbLink = new StringBuilder();
            sbLink.Append("../schema/templates/");
            sbLink.Append(MakeLinkName(docTemplateLast));
            sbLink.Append(".htm");

            using (FormatHTM htmLink = new FormatHTM(sbFile.ToString(), mapEntity, mapSchema, included))
            {
                htmLink.WriteLinkPage(sbLink.ToString());
            }

            if (docTemplateLast.Templates != null)
            {
                foreach (DocTemplateDefinition docSub in docTemplateLast.Templates)
                {
                    path.Add(docSub);
                    GenerateTemplateLink(path, mapEntity, mapSchema, included);
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
        private static void GenerateExampleLink(List<DocExample> path, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, Dictionary<DocObject, bool> included)
        {
            DocExample docTemplateLast = path[path.Count - 1];

            // flat list -- requires unique template names
            StringBuilder sbFile = new StringBuilder();
            sbFile.Append(Properties.Settings.Default.OutputPath);
            sbFile.Append(@"\link\");
            sbFile.Append(MakeLinkName(docTemplateLast));
            sbFile.Append(".htm");

            StringBuilder sbLink = new StringBuilder();
            sbLink.Append("../annex/annex-e/");
            sbLink.Append(MakeLinkName(docTemplateLast));
            sbLink.Append(".htm");

            using (FormatHTM htmLink = new FormatHTM(sbFile.ToString(), mapEntity, mapSchema, included))
            {
                htmLink.WriteLinkPage(sbLink.ToString());
            }

            if (docTemplateLast.Examples != null)
            {
                foreach (DocExample docSub in docTemplateLast.Examples)
                {
                    path.Add(docSub);
                    GenerateExampleLink(path, mapEntity, mapSchema, included);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }


        private static string FormatDiagram(DocProject docProject, DocObject def, DocModelView docView, ref int iFigure, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema)
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
            string filename = def.Name.ToLower().Replace(' ', '-') + ".png";
            Dictionary<Rectangle, DocModelRule> layout = new Dictionary<Rectangle, DocModelRule>();
            try
            {
                if (def is DocTemplateDefinition)
                {
                    System.IO.Directory.CreateDirectory(Properties.Settings.Default.OutputPath + "\\schema\\templates\\diagrams");
                    using (Image image = IfcDoc.Format.PNG.FormatPNG.CreateTemplateDiagram((DocTemplateDefinition)def, mapEntity, layout, docProject))
                    {
                        if (image != null)
                        {
                            string filepath = Properties.Settings.Default.OutputPath + "\\schema\\templates\\diagrams\\" + filename;
                            image.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                }
                else if (def is DocEntity) // no longer used directly; now for each model view in annex D
                {
                    System.IO.Directory.CreateDirectory(Properties.Settings.Default.OutputPath + "\\diagrams");
                    using (Image image = IfcDoc.Format.PNG.FormatPNG.CreateEntityDiagram((DocEntity)def, docView, mapEntity, layout, docProject))
                    {
                        string filepath = Properties.Settings.Default.OutputPath + "\\diagrams\\" + filename;
                        image.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
            catch
            {
            }

            // 2. figure
            StringBuilder sb = new StringBuilder();
            if (def is DocTemplateDefinition)
            {
                iFigure++;

                // Per ISO guidelines, all figures must be referenced from text.
                sb.Append("<p>Figure ");
                sb.Append(iFigure);
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
            }
            sb.Append(filename);
            sb.Append("\" usemap=\"#f");
            sb.Append(iFigure.ToString());
            sb.Append("\">");
            sb.Append("<map name=\"f");
            sb.Append(iFigure.ToString());
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
                sb.Append(iFigure);
                sb.Append(" &mdash; ");
                sb.Append(def.Name);
                sb.Append("</p></td></tr>");
            }

            sb.Append("</table>\r\n");
            sb.AppendLine();

            return sb.ToString();
        }


        private static string FormatTemplate(DocProject docProject, DocTemplateDefinition def, ref int iFigure, ref int iTable, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, Dictionary<DocObject, bool> included)
        {
            // format content
            StringBuilder sb = new StringBuilder();

            // 1. manual content
            sb.Append(def.Documentation);

            // 2. instance diagram
            if (Properties.Settings.Default.DiagramTemplate)
            {
                sb.Append(FormatDiagram(docProject, def, null, ref iFigure, mapEntity, mapSchema));
            }

            // 3. entity list                
            if (Properties.Settings.Default.Requirement)
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

                            sb.AppendLine("<p>This concept is used by entities for exchanges as shown.</p>");
                            int cExchange = docView.Exchanges.Count;

                            sb.AppendLine("<table class=\"exchange\">");
                            sb.Append("<tr><td></td>");
                            foreach (DocExchangeDefinition docExchange in docView.Exchanges)
                            {
                                string identifier = docExchange.Name.Replace(' ', '-').ToLower();

                                sb.Append("<td><a href=\"../views/");
                                sb.Append(docView.Name.Replace(' ', '-').ToLower());
                                sb.Append("/");
                                sb.Append(docExchange.Name.Replace(' ', '-').ToLower());
                                sb.Append(".htm\"><image width=\"16\" src=\"../../img/mvd-");
                                sb.Append(identifier);
                                sb.Append(".png\" title=\"");
                                sb.Append(docExchange.Name);
                                sb.Append("\"/></a></td>");
                                sb.AppendLine();
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

            if (!Properties.Settings.Default.Requirement)
                return String.Empty;

            StringBuilder sb = new StringBuilder();

            if (showexchanges && docModel.Exchanges.Count > 0)
            {
                sb.AppendLine("<table class=\"exchange\">");

                sb.AppendLine("<tr>");
                sb.AppendLine("<th>Exchange</th>");
                foreach (DocExchangeDefinition docExchange in docModel.Exchanges)
                {
                    string identifier = docExchange.Name.Replace(' ', '-').ToLower();

                    sb.Append("<th><a href=\"../../views/");
                    sb.Append(docModel.Name.Replace(' ', '-').ToLower());
                    sb.Append("/");
                    sb.Append(identifier);
                    sb.Append(".htm\"><image width=\"16\" src=\"../../../img/mvd-");
                    sb.Append(identifier);
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

            // 2. map of entities and templates -- Identity | Template | Import | Export
            sb.AppendLine("<p></p>");

            SortedList<string, DocConceptRoot> sortlist = new SortedList<string, DocConceptRoot>();

            foreach (DocConceptRoot docRoot in docView.ConceptRoots)
            {
                if (!sortlist.ContainsKey(docRoot.ApplicableEntity.Name))
                {
                    sortlist.Add(docRoot.ApplicableEntity.Name, docRoot);
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
            sb.AppendLine("</table>");

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
            if (docExample.ModelView != null && included != null && !included.ContainsKey(docExample.ModelView))
                return;

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
        private static string MakeLinkName(DocObject docobj)
        {
            if (docobj.Name == null)
                return docobj.Uuid.ToString();

            return docobj.Name.Replace(' ', '-').ToLower();
        }

        /// <summary>
        /// Resolves a template parameter type
        /// </summary>
        /// <param name="docTemplate"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private static DocDefinition GetTemplateParameterType(DocEntity docEntity, DocTemplateDefinition docTemplate, string parameter, Dictionary<string, DocObject> map)
        {
            foreach (DocModelRule rule in docTemplate.Rules)
            {
                if (rule is DocModelRuleAttribute)
                {
                    DocDefinition docAttr = docEntity.ResolveParameterType((DocModelRuleAttribute)rule, parameter, map);
                    if (docAttr != null)
                    {
                        return docAttr;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// If matching figure exists, generates HTML including the figure and increments the figure count.
        /// </summary>
        /// <param name="definition">Object for which to find figure.</param>
        /// <param name="dtd">Optional template for which to find figure.</param>
        /// <param name="caption">Caption of definition used in determining figure caption, e.g. 'Beam'</param>
        /// <param name="iFigure">Number of figure; will be incremented if figure is found.</param>
        /// <returns></returns>
        private static string FormatFigure(DocProject docProject, DocObject definition, DocTemplateDefinition dtd, string caption, ref int iFigure)
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

                string filename = definition.Name.ToLowerInvariant();
                if (dtd != null)
                {
                    filename += "-" + dtd.Name.Split(' ')[0].ToLower();
                }
                filename += ".png";

                string filepath = Properties.Settings.Default.OutputPath + @"\figures\" + filename;
                if (System.IO.File.Exists(filepath))
                {
                    iFigure++;

                    // "Sensor", "Port Use Definition" ==> "Sensor Port Use"
                    string figuredef = "usage";
                    if (dtd != null)
                    {
                        figuredef = dtd.Name.ToLower();
                    }


                    // Per ISO guidelines, all figures must be referenced from text.
                    sb.Append("<p>Figure ");
                    sb.Append(iFigure);
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
                    sb.Append(iFigure);
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

            DocTemplateItem[] listItems = FindTemplateItems(docProject, entity, usage.Definition, docModelView);

            if(listItems.Length == 0)
            {
                // scenario for referenced inner templates
                listItems = usage.Items.ToArray();
            }

            // new way with table
            DocModelRule[] parameters = usage.Definition.GetParameterRules();
            if (parameters != null && parameters.Length > 0)
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
                    sb.Append(parameter.Identification);
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
                            DocDefinition docDef = GetTemplateParameterType(entity, usage.Definition, parameter.Identification, mapEntity);
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
                                    if (dma.Rules.Count == 1 && dma.Rules[0] is DocModelRuleEntity)
                                    {
                                        DocModelRuleEntity dme = (DocModelRuleEntity)dma.Rules[0];
                                        if (dme.References.Count == 1)
                                        {
                                            docTemplateInner = dme.References[0];
                                        }
                                    }
                                }

                                if (docTemplateInner != null)
                                {
                                    DocTemplateUsage docConceptInner = item.GetParameterConcept(parameter.Identification, docTemplateInner);
                                    if (docConceptInner != null)
                                    {
                                        string inner = FormatConceptTable(docProject, docModelView, (DocEntity)docDef, root, docConceptInner, mapEntity, mapSchema);
                                        sb.Append(inner);
                                    }
                                }
                                else if (value != null && mapSchema.TryGetValue(value, out schema))
                                {
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
                                        string[] parts = value.Split('\\');
                                        foreach(string part in parts)
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
                        /*
                        else
                        {
                            sb.Append("&nbsp;");
                        }*/
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
            ref int iFigure, ref int iTable)
        {
            if (usage.Definition == null)
                return String.Empty;

            StringBuilder sb = new StringBuilder();

            string anchorid = usage.Definition.Name.ToLower().Replace(' ', '-');

            // anchor
            sb.Append("<a name=\"");
            sb.Append(anchorid);
            sb.Append("\" />");
            sb.AppendLine();

            // Caption            
            string identifier = usage.Definition.Name.Split()[0].ToLower();
            sb.Append("<p class=\"use-head\">");
            sb.Append(usage.Definition.Name);
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
            string deflink = usage.Definition.Name.Replace(' ', '-').ToLower() + ".htm";

            if (listItems.Length > 0)
            {
                iTable++;
                sb.Append("<p>The <a href=\"../../templates/");
                sb.Append(deflink);
                sb.Append("\">");
                sb.Append(usage.Definition.Name);
                sb.Append("</a> concept applies to this entity as shown in Table ");
                sb.Append(iTable);
                sb.Append(".");

                sb.AppendLine("<table>");
                sb.AppendLine("<tr><td>");

                string table = FormatConceptTable(docProject, docModelView, entity, root, usage, mapEntity, mapSchema);
                sb.Append(table);

                sb.AppendLine("</td></tr>");
                sb.Append("<tr><td><p class=\"table\">Table ");
                sb.Append(iTable);
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
            string fig = FormatFigure(docProject, entity, usage.Definition, entity.Text, ref iFigure);
            if (fig != null)
            {
                sb.Append(fig);
            }

            if (usage.Documentation != null)
            {
                sb.AppendLine(usage.Documentation); // special case if definition provides description, such as for classification
            }

            string req = FormatRequirements(usage, docModelView, true);
            if (req != null)
            {
                sb.AppendLine(req);
            }

            sb.AppendLine("<br/><br/>");

            return sb.ToString();
        }

        private static string FormatField(DocProject docProject, string content, string fieldname, string fieldtype, string fieldvalue)
        {
            // hyperlink to enumerators
            if (fieldtype != null && fieldtype.StartsWith("Ifc") && fieldtype.EndsWith("Enum") &&
                docProject.GetDefinition(fieldtype) != null)
            {
                // hyperlink to enumeration definition
                DocDefinition docDef = docProject.GetDefinition(fieldtype);

                // replace it with hyperlink
                DocSchema docSchema = docProject.GetSchemaOfDefinition(docDef);
                string relative = @"../../";
                string hyperlink = relative + docSchema.Name.ToLower() + @"/lexical/" + docDef.Name.ToLower() + ".htm";
                string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";

                return content.Replace(fieldname, format);
            }
            else if (fieldvalue != null && fieldvalue.StartsWith("Ifc") && docProject.GetDefinition(fieldvalue) != null)
            {
                // hyperlink to IFC entity
                DocDefinition docDef = docProject.GetDefinition(fieldvalue);
                if (docDef != null)
                {
                    // replace it with hyperlink
                    DocSchema docSchema = docProject.GetSchemaOfDefinition(docDef);
                    string relative = @"../../";
                    string hyperlink = relative + docSchema.Name.ToLower() + @"/lexical/" + docDef.Name.ToLower() + ".htm";
                    string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";

                    return content.Replace(fieldname, format);
                }
            }
            else if (fieldvalue != null && fieldvalue.StartsWith("Pset_"))
            {
                // hyperlink to property set definition
                DocSchema docSchema = null;
                DocPropertySet docDef = docProject.FindPropertySet(fieldvalue, out docSchema);
                if (docDef != null)
                {
                    string relative = @"../../";
                    string hyperlink = relative + docSchema.Name.ToLowerInvariant() + @"/pset/" + docDef.Name.ToLower() + ".htm"; // case-sensitive on linux -- need to make schema all lowercase
                    string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";
                    return content.Replace(fieldname, format);
                }
            }
            else if (fieldvalue != null && fieldvalue.StartsWith("Qto_"))
            {
                // hyperlink to quantity set definition
                DocSchema docSchema = null;
                DocQuantitySet docDef = docProject.FindQuantitySet(fieldvalue, out docSchema);
                if (docDef != null)
                {
                    string relative = @"../../";
                    string hyperlink = relative + docSchema.Name.ToLowerInvariant() + @"/qset" + docDef.Name.ToLower() + ".htm"; // case-sentive on linux -- need to make schema all lowercase
                    string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";
                    return content.Replace(fieldname, format);
                }
            }
            else
            {
                // simple replace -- hyperlink may markup value later
                return content.Replace(fieldname, fieldvalue);
            }

            return content;
        }



        /// <summary>
        /// Generates documentation for template and all sub-templates recursively.
        /// </summary>
        /// <param name="docTemplate"></param>
        /// <param name="indexpath"></param>
        /// <param name="iFigure"></param>
        /// <param name="iTable"></param>
        private static void GenerateTemplate(DocProject docProject, DocTemplateDefinition docTemplate, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, Dictionary<DocObject, bool> included, int[] indexpath, ref int iFigure, ref int iTable)
        {
            string pathTemplate = Properties.Settings.Default.OutputPath + @"\schema\templates\" + MakeLinkName(docTemplate) + ".htm";
            using (FormatHTM htmTemplate = new FormatHTM(pathTemplate, mapEntity, mapSchema, included))
            {
                htmTemplate.WriteHeader(docTemplate.Name, 2);

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
                     "<script language=\"JavaScript1.1\" type=\"text/javascript\">\r\n" +
                     "<!--\r\n" +
                     "    parent.index.location.replace(\"../toc-4.htm#" + indexer + "\");\r\n" +
                     "//-->\r\n" +
                     "</script>\r\n");

                string tag = "h" + indexpath.Length.ToString(); // e.g. <h3>
                string id = MakeLinkName(docTemplate);
                htmTemplate.WriteLine("<" + tag + " class=\"std\">" + indexer + " " + docTemplate.Name + "</" + tag + ">");

                string doc = FormatTemplate(docProject, docTemplate, ref iFigure, ref iTable, mapEntity, mapSchema, included);
                htmTemplate.WriteDocumentationForISO(doc, docTemplate, false);

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
                                htmTemplate.Write(docExample.Name.Replace(' ', '-').ToLower());
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
                htmTemplate.WriteLine("<p><a href=\"../../link/" + MakeLinkName(docTemplate) + ".htm\" target=\"_top\" ><img src=\"../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");

                htmTemplate.WriteFooter(Properties.Settings.Default.Footer);
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
                    GenerateTemplate(docProject, docSubTemplate, mapEntity, mapSchema, included, subindexpath, ref iFigure, ref iTable);
                }
            }
        }

        private static string FormatEntity(DocProject docProject, DocEntity entity, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, Dictionary<DocObject, bool> included, ref int iFigure, ref int iTable)
        {
            DocTemplateDefinition dtd = null;

            StringBuilder sb = new StringBuilder();

            entity.Documentation = UpdateNumbering(entity.Documentation, ref iFigure, ref iTable);
            sb.Append(entity.Documentation);

            // find concepts for entity
            foreach (DocModelView docView in docProject.ModelViews)
            {
                if (included == null || included.ContainsKey(docView))
                {
                    foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                    {
                        if (docRoot.ApplicableEntity == entity)
                        {
                            sb.AppendLine("<hr />");
                            sb.Append("<h2>");
                            sb.Append(docView.Name);
                            sb.Append("</h2>");
                            sb.Append(docRoot.Documentation);

                            // inherited use definitions
                            List<string> listLines = new List<string>();
                            Dictionary<DocTemplateDefinition, DocTemplateUsage> mapSuper = new Dictionary<DocTemplateDefinition, DocTemplateUsage>();
                            DocEntity docSuper = entity;
                            while (docSuper != null)
                            {
                                // find parent concept roots
                                foreach (DocConceptRoot docSuperRoot in docView.ConceptRoots)
                                {
                                    if (docSuperRoot.ApplicableEntity == docSuper)
                                    {
                                        int superusage = 0;
                                        StringBuilder sbSuper = new StringBuilder();
                                        sbSuper.Append("<li><i>");
                                        sbSuper.Append(docSuper.Name);
                                        sbSuper.Append("</i>: ");

                                        foreach (DocTemplateUsage docSuperUsage in docSuperRoot.Concepts)
                                        {
                                            if (!mapSuper.ContainsKey(docSuperUsage.Definition))
                                            {
                                                mapSuper.Add(docSuperUsage.Definition, docSuperUsage);

                                                superusage++;
                                                if (superusage > 1)
                                                {
                                                    sbSuper.Append(", ");
                                                }

                                                sbSuper.Append("<a href=\"../../templates/");
                                                sbSuper.Append(MakeLinkName(docSuperUsage.Definition));
                                                sbSuper.Append(".htm\">");
                                                sbSuper.Append(docSuperUsage.Definition.Name);
                                                sbSuper.Append("</a>");
                                            }
                                        }
                                        sbSuper.Append("</li>");

                                        if (docSuper != entity && superusage > 0)
                                        {
                                            listLines.Add(sbSuper.ToString());
                                        }

                                    }
                                }

                                // go to base type
                                docSuper = docProject.GetDefinition(docSuper.BaseDefinition) as DocEntity;
                            }

                            // now format inherited use definitions
                            if (listLines.Count > 0)
                            {
                                sb.AppendLine("<p>The following concepts are inherited at supertypes:</p>");
                                sb.AppendLine("<ul>");
                                for (int iLine = listLines.Count - 1; iLine >= 0; iLine--)
                                {
                                    // reverse order
                                    sb.AppendLine(listLines[iLine]);
                                }
                                sb.AppendLine("</ul>");
                            }

                            // link to instance diagram
                            if (Properties.Settings.Default.DiagramConcept)
                            {
                                string linkdiagram = MakeLinkName(docView) + "/" + MakeLinkName(entity) + ".htm";
                                sb.Append("<p><a href=\"../../../annex/annex-d/" + linkdiagram + "\"><img style=\"border: 0px\" src=\"../../../img/diagram.png\" />&nbsp;Instance diagram</a></p>");
                            }

                            foreach (DocTemplateUsage eachusage in docRoot.Concepts)
                            {
                                if (included == null || included.ContainsKey(eachusage.Definition))
                                {
                                    if (eachusage.Documentation != null)
                                    {
                                        eachusage.Documentation = UpdateNumbering(eachusage.Documentation, ref iFigure, ref iTable);
                                    }

                                    string eachtext = FormatConcept(docProject, entity, docRoot, eachusage, mapEntity, mapSchema, ref iFigure, ref iTable);
                                    sb.Append(eachtext);
                                    sb.AppendLine();
                                }
                            }
                        }
                    }
                }
            }

            sb.AppendLine("<hr />");

            // add figure if it exists
            string fig = FormatFigure(docProject, entity, dtd, entity.Text, ref iFigure);
            if (fig != null)
            {
                sb.Append(fig);
            }

            sb = sb.Replace("<EPM-HTML>", "");
            sb = sb.Replace("</EPM-HTML>", "");

            return sb.ToString();
        }


        /// <summary>
        /// Updates content containing figure references
        /// </summary>
        /// <param name="html">Content to parse</param>
        /// <param name="figurenumber">Last figure number; returns updated last figure number</param>
        /// <param name="tablenumber">Last table number; returns updated last table number</param>
        /// <returns>Updated content</returns>
        private static string UpdateNumbering(string html, ref int figurenumber, ref int tablenumber)
        {
            if (html == null)
                return null;

            html = UpdateNumbering(html, "Figure", "figure", ref figurenumber);
            html = UpdateNumbering(html, "Table", "table", ref tablenumber);
            return html;
        }

        private static string UpdateNumbering(string html, string tag, string style, ref int itemnumber)
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
                    }
                }

                index++;
            }

            // renumber in two phases (to avoid renumbering same)

            // now renumber
            for (int i = 0; i < list.Count; i++)
            {
                string captionold = tag + " " + list[i].ToString();// +" ";
                string captionnew = tag + "#" + (itemnumber + i + 1).ToString();// +" ";

                // handle cases of space, comma, and period following figure reference
                html = html.Replace(captionold + " ", captionnew + " ");
                html = html.Replace(captionold + ",", captionnew + ",");
                html = html.Replace(captionold + ".", captionnew + ".");
            }

            // then replace all
            html = html.Replace(tag + "#", tag + " ");

            itemnumber += list.Count;

            return html;
        }


        public static void GenerateDocumentation(
            DocProject docProject, 
            string path,
            Dictionary<long, SEntity> instances,
            Dictionary<string, DocObject> mapEntity, 
            Dictionary<string, string> mapSchema, 
            DocModelView[] views,
            string[] locales,
            BackgroundWorker worker, 
            FormProgress formProgress)
        {
            // copy over static content * if it doesn't already exist *
            string pathContent = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (pathContent.EndsWith(@"bin\x86\Debug")) // debugging
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

            int iFigure = 0;
            int iTable = 0;

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

            DocEntity docEntityRoot = docProject.GetDefinition("IfcRoot") as DocEntity;
            Dictionary<Rectangle, DocEntity> mapRectangle = new Dictionary<Rectangle, DocEntity>();
            using (Image imgDiagram = FormatPNG.CreateInheritanceDiagram(docProject, included, docEntityRoot, new Font(FontFamily.GenericSansSerif, 8.0f), mapRectangle))
            {
                imgDiagram.Save(path + @"\img\cover.png");
                    
                using (FormatHTM htmCover = new FormatHTM(path + @"\cover.htm", mapEntity, mapSchema, included))
                {
                    htmCover.WriteHeader(String.Empty, 1);

                    htmCover.WriteLine("<img src=\"" + path + "/img/cover.png\" usemap=\"#f\"/>");
                    htmCover.WriteLine("<map name=\"f\">");

                    foreach (Rectangle rc in mapRectangle.Keys)
                    {
                        DocEntity docEntref = mapRectangle[rc];
                        DocSchema docEntsch = docProject.GetSchemaOfDefinition(docEntref);

                        string hyperlink = "./schema/" + docEntsch.Name.ToLower() + "/lexical/" + docEntref.Name.ToLower() + ".htm";
                        htmCover.WriteLine("<area shape=\"rect\" coords=\"" + rc.Left + "," + rc.Top + "," + rc.Right + "," + rc.Bottom + "\" href=\"" + hyperlink + "\" alt=\"" + docEntref.Name + "\" />");
                    }
                    htmCover.WriteLine("</map>");


                    htmCover.WriteFooter(String.Empty);
                }
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
                htmProp.WriteHeader("Properties", 2);

                htmProp.WriteLine("<h2 class=\"annex\">Individual Properties (" + mapProperty.Count + ")</h2>");
                htmProp.WriteLine("<ul class=\"std\">");

                htmProp.WriteLine(sbProperties.ToString());

                htmProp.WriteLine("</ul>");

                htmProp.WriteFooter(Properties.Settings.Default.Footer);
            }

            // NEW: section 4 templates
            int iTemplate = 0;
            foreach (DocTemplateDefinition docTemplate in docProject.Templates)
            {
                if (included == null || included.ContainsKey(docTemplate))
                {
                    iTemplate++;
                    int[] indexpath = new int[] { 4, iTemplate };
                    GenerateTemplate(docProject, docTemplate, mapEntity, mapSchema, included, indexpath, ref iFigure, ref iTable);
                }
            }

            // NEW: model view definitions
            int iView = 0;
            if (Properties.Settings.Default.ConceptTables)
            {
                foreach (DocModelView docProjectModelView in docProject.ModelViews)
                {
                    if (included == null || included.ContainsKey(docProjectModelView))
                    {
                        iView++;
                        string pathTemplate = pathSchema + @"\views\" + docProjectModelView.Name.Replace(' ', '-').ToLower() + "\\index.htm";
                        using (FormatHTM htmTemplate = new FormatHTM(pathTemplate, mapEntity, mapSchema, included))
                        {
                            htmTemplate.WriteHeader(docProjectModelView.Name, 1, iView, 0, Properties.Settings.Default.Header);
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
                                htmTemplate.WriteDocumentationForISO(viewtable, docProjectModelView, false);
                            }

                            htmTemplate.WriteFooter(Properties.Settings.Default.Footer);
                        }
                        // each exchange... (or sub-page?)

                        for (int iExchange = 0; iExchange < docProjectModelView.Exchanges.Count; iExchange++)
                        {
                            DocExchangeDefinition docExchange = docProjectModelView.Exchanges[iExchange];

                            string pathExchange = pathSchema + @"\views\" + docProjectModelView.Name.Replace(' ', '-').ToLower() + "\\" + docExchange.Name.Replace(' ', '-').ToLower() + ".htm";
                            using (FormatHTM htmExchange = new FormatHTM(pathExchange, mapEntity, mapSchema, included))
                            {
                                htmExchange.WriteHeader(docExchange.Name, 1, iView, 0, Properties.Settings.Default.Header);
                                htmExchange.WriteScript(1, iView, iExchange + 1, 0);

                                string indexer = "1." + iView.ToString() + "." + (iExchange + 1).ToString();
                                string tag = "h4";
                                string id = docExchange.Name.ToLower();

                                htmExchange.WriteLine("<" + tag + "><a id=\"" + id + "\" name=\"" + id + "\">" + indexer + " " + docExchange.Name + "</a></" + tag + ">");
                                htmExchange.WriteLine("<p class=\"std\">");

                                string exchangedoc = FormatExchange(docProject, docProjectModelView, docExchange, mapEntity, mapSchema);
                                htmExchange.WriteDocumentationForISO(exchangedoc, docExchange, false);
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

            string pathTOC = path + @"\toc.htm";
            using (FormatHTM htmTOC = new FormatHTM(pathTOC, mapEntity, mapSchema, included))
            {
                htmTOC.WriteHeader("Contents", 0);

                htmTOC.WriteLine("    <script language=\"JavaScript1.1\" type=\"text/javascript\">");
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
                            htmSection.WriteHeader(section.Name, iSection, 0, 0, Properties.Settings.Default.Header);
                            htmSection.WriteScript(iSection, 0, 0, 0);
                            htmSection.WriteLine("<h1 class=\"std\">" + iSection.ToString() + " " + section.Name + "</h1>");

                            section.Documentation = UpdateNumbering(section.Documentation, ref iFigure, ref iTable);
                            htmSection.WriteDocumentationForISO(section.Documentation, section, Properties.Settings.Default.NoHistory);


                            if (iSection == 1)
                            {
                                if (Properties.Settings.Default.ConceptTables)
                                {
                                    int iModel = 0;
                                    foreach (DocModelView docModelView in docProject.ModelViews)
                                    {
                                        if (included == null || included.ContainsKey(docModelView))
                                        {
                                            iModel++;

                                            string htmllink = "<a class=\"listing-link\" href=\"views/" + docModelView.Name.Replace(' ', '-').ToLower() + "/index.htm\" target=\"info\">" +
                                                iSection.ToString() + "." + iModel.ToString() + " " + docModelView.Name + "</a>";
                                            htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"schema/views/" + docModelView.Name.Replace(' ', '-').ToLower() + "/index.htm\" >" +
                                                iSection.ToString() + "." + iModel.ToString() + " " + docModelView.Name + "</a>");
                                            htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + htmllink + "</td></tr>");

                                            int iExchange = 0;
                                            foreach (DocExchangeDefinition docExchange in docModelView.Exchanges)
                                            {
                                                iExchange++;

                                                htmllink = "<a class=\"listing-link\" href=\"views/" + docModelView.Name.Replace(' ', '-').ToLower() + "/" + docExchange.Name.Replace(' ', '-').ToLower() + ".htm\" target=\"info\">" +
                                                    iSection.ToString() + "." + iModel.ToString() + "." + iExchange.ToString() + " " + docExchange.Name + "</a>";

                                                htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"schema/views/" + docModelView.Name.Replace(' ', '-').ToLower() + "/" + docExchange.Name.Replace(' ', '-').ToLower() + ".htm\" >" +
                                                    iSection.ToString() + "." + iModel.ToString() + "." + iExchange.ToString() + " " + docExchange.Name + "</a>");
                                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + htmllink + "</td></tr>");
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
                                        htmSection.WriteLine("<dt><a name=\"" + MakeLinkName(docRef) + "\" id=\"" + MakeLinkName(docRef) + "\">" + docRef.Name + "</a>, <i>" + docRef.Documentation + "</i></dt>");
                                        htmSection.WriteLine("<dd>&nbsp;</dd>");
                                    }
                                }
                                htmSection.WriteLine("</dl>");
                            }
                            else if (iSection == 3)
                            {
                                htmSection.WriteLine("<h2>3.1 Terms and definitions</h2>");
                                htmSection.WriteLine("<dl>");
                                if (docProject.Terms != null)
                                {
                                    SortedList<string, DocTerm> sl = new SortedList<string, DocTerm>();
                                    foreach (DocTerm docRef in docProject.Terms)
                                    {
                                        sl.Add(docRef.Name, docRef);
                                    }
                                    foreach (string s in sl.Keys)
                                    {
                                        DocTerm docRef = sl[s];
                                        htmSection.WriteLine("<dt><strong name=\"" + MakeLinkName(docRef) + "\" id=\"" + MakeLinkName(docRef) + "\">" + docRef.Name + "</strong></dt>");
                                        htmSection.WriteLine("<dd>" + docRef.Documentation + "</dd>");
                                    }
                                }
                                htmSection.WriteLine("</dl>");
                                htmSection.WriteLine("<h2>3.2 Abbreviated terms</h2>");
                                htmSection.WriteLine("<dl>");
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
                                        htmSection.WriteLine("<dt><strong name=\"" + MakeLinkName(docRef) + "\" id=\"" + MakeLinkName(docRef) + "\">" + docRef.Name + "</strong></dt>");
                                        htmSection.WriteLine("<dd>" + docRef.Documentation + "</dd>");
                                    }
                                }
                                htmSection.WriteLine("</dl>");
                            }
                            else if (iSection == 4)
                            {
                                FormatHTM.WriteTOCforTemplates(docProject.Templates, 1, iSection.ToString(), htmTOC, htmSectionTOC, included);
                            }

                            htmSection.WriteFooter(Properties.Settings.Default.Footer);
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
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + iSection.ToString() + "." + iSchema.ToString() + "\">" + iSection.ToString() + "." + iSchema.ToString() + "</a> <a class=\"listing-link\" href=\"" + schema.Name.ToLower() + "/content.htm\" target=\"info\">" + schema.Name + "</a></td></tr>\r\n");

                                        htmSchema.WriteHeader(schema.Name, iSection, iSchema, 0, Properties.Settings.Default.Header);

                                        htmSchema.WriteScript(iSection, iSchema, 0, 0);

                                        htmSchema.WriteLine("<h2 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + " " + schema.Name + "</h2>");

                                        int iSubSection = 1; // first subsection for schema semantic definition
                                        htmTOC.WriteTOC(2, iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Schema Definition");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Schema Definition</td></tr>\r\n");
                                        htmSchema.WriteLine("<h3 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + " Schema Definition</h3>");

                                        schema.Documentation = UpdateNumbering(schema.Documentation, ref iFigure, ref iTable);
                                        htmSchema.WriteDocumentationForISO(schema.Documentation, schema, Properties.Settings.Default.NoHistory);

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
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iType.ToString() + "</a> <a class=\"listing-link\" href=\"" + mapSchema[type.Name].ToLower() + "/lexical/" + type.Name.ToLower() + ".htm\" target=\"info\">" + type.Name + "</a><td></tr>\r\n");


                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + type.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(type.Name, iSection, iSchema, iType, Properties.Settings.Default.Header);

                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iType);

                                                        htmDef.WriteLine("<h4 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iType.ToString() + " " + type.Name + "</h4>");

                                                        // localization
                                                        htmDef.WriteLine("<table>");
                                                        type.Localization.Sort();
                                                        foreach (DocLocalization doclocal in type.Localization)
                                                        {
                                                            string localname = doclocal.Name;
                                                            string localdesc = doclocal.Documentation;
                                                            string localid = doclocal.Locale.Substring(0, 2).ToLower();

                                                            if (!String.IsNullOrEmpty(localdesc))
                                                            {
                                                                localdesc = ": " + localdesc;
                                                            }

                                                            htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-" + localid + ".png\" /></td><td><b>" + localname + "</b>" + localdesc + "</td></tr>");
                                                        }
                                                        htmDef.WriteLine("</table>");


                                                        if (type.Documentation != null)
                                                        {
                                                            type.Documentation = UpdateNumbering(type.Documentation, ref iFigure, ref iTable);
                                                        }

                                                        htmDef.WriteDocumentationForISO(type.Documentation, type, Properties.Settings.Default.NoHistory);

                                                        if (!Properties.Settings.Default.NoXsd)
                                                        {
                                                            htmDef.Write("<p class=\"spec-head\">XSD Specification:</p>");
                                                            htmDef.Write("<span class=\"xsd\">");
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
                                                            htmDef.Write("</span>");
                                                        }

                                                        htmDef.WriteExpressTypeAndDocumentation(type, Properties.Settings.Default.NoHistory, Properties.Settings.Default.ExpressComments);

                                                        // write url for incoming page link
                                                        htmDef.WriteLine("<p><a href=\"../../../link/" + MakeLinkName(type) + ".htm\" target=\"_top\" ><img src=\"../../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");

                                                        htmDef.WriteFooter(Properties.Settings.Default.Footer);
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
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iEntity, Properties.Settings.Default.Header);
                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iEntity);

                                                        htmDef.WriteLine("<h4 class=\"std\">" + formatnum + " " + entity.Name + "</h4>");

                                                        // localization
                                                        htmDef.WriteLine("<table>");
                                                        entity.Localization.Sort();
                                                        foreach (DocLocalization doclocal in entity.Localization)
                                                        {
                                                            string localname = doclocal.Name;
                                                            string localdesc = doclocal.Documentation;
                                                            string localid = doclocal.Locale.Substring(0, 2).ToLower();

                                                            if (!String.IsNullOrEmpty(localdesc))
                                                            {
                                                                localdesc = ": " + localdesc;
                                                            }

                                                            htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-" + localid + ".png\" /></td><td><b>" + localname + "</b>" + localdesc + "</td></tr>");
                                                        }
                                                        htmDef.WriteLine("</table>");


                                                        string documentation = FormatEntity(docProject, entity, mapEntity, mapSchema, included, ref iFigure, ref iTable);

                                                        htmDef.WriteDocumentationForISO(documentation, entity, Properties.Settings.Default.NoHistory);

                                                        if (!Properties.Settings.Default.NoXsd)
                                                        {
                                                            htmDef.Write("<p class=\"spec-head\">XSD Specification:</p>");
                                                            htmDef.Write("<span class=\"xsd\">");
                                                            htmDef.WriteFormatted(FormatXSD.FormatEntity(entity, mapEntity, included));
                                                            htmDef.Write("</span>");
                                                        }

                                                        htmDef.WriteExpressEntityAndDocumentation(entity, Properties.Settings.Default.NoHistory, Properties.Settings.Default.ExpressComments);

                                                        if (docProject.Examples != null)
                                                        {
                                                            List<DocExample> listExample = new List<DocExample>();
                                                            foreach (DocExample docExample in docProject.Examples)
                                                            {
                                                                BuildExampleList(listExample, docExample, entity, included);
                                                            }
                                                            if (listExample.Count > 0)
                                                            {
                                                                htmDef.WriteLine("<p class=\"spec-head\">Examples:</p>");
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
                                                            }
                                                        }

                                                        // write url for incoming page link
                                                        htmDef.WriteLine("<p><a href=\"../../../link/" + MakeLinkName(entity) + ".htm\" target=\"_top\" ><img src=\"../../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");

                                                        htmDef.WriteFooter(Properties.Settings.Default.Footer);
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
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iEntity, Properties.Settings.Default.Header);
                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iEntity);

                                                        htmDef.WriteLine("<h4 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + " " + entity.Name + "</h4>");

                                                        htmDef.WriteLine("<p>");
                                                        htmDef.WriteDocumentationForISO(entity.Documentation, entity, Properties.Settings.Default.NoHistory);
                                                        htmDef.WriteLine("</p>");

                                                        htmDef.WriteLine("<p><b><u>EXPRESS Specification</u></b></p>\r\n");
                                                        htmDef.WriteLine("<span class=\"express\">\r\n");

                                                        htmDef.WriteExpressFunction(entity);

                                                        htmDef.WriteLine("</span>\r\n");

                                                        // write url for incoming page link
                                                        htmDef.WriteLine("<p><a href=\"../../../link/" + MakeLinkName(entity) + ".htm\" target=\"_top\" ><img src=\"../../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");

                                                        htmDef.WriteFooter(Properties.Settings.Default.Footer);
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
                                                iEntity++;

                                                string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString();
                                                mapNumber.Add(entity, formatnum);

                                                htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + "</a> <a href=\"" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                {
                                                    htmDef.WriteHeader(entity.Name, iSection, iSchema, iEntity, Properties.Settings.Default.Header);
                                                    htmDef.WriteScript(iSection, iSchema, iSubSection, iEntity);

                                                    htmDef.WriteLine("<h4 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + " " + entity.Name + "</h4>");
                                                    htmDef.WriteLine("<p>");
                                                    htmDef.WriteDocumentationForISO(entity.Documentation, entity, Properties.Settings.Default.NoHistory);
                                                    htmDef.WriteLine("</p>");

                                                    htmDef.WriteLine("<p><b><u>EXPRESS Definition</u></b></p>");

                                                    htmDef.WriteLine("<span class=\"express\">\r\n");

                                                    htmDef.WriteExpressGlobalRule(entity);

                                                    htmDef.WriteLine("</span>\r\n");

                                                    // write url for incoming page link
                                                    htmDef.WriteLine("<p><a href=\"../../../link/" + MakeLinkName(entity) + ".htm\" target=\"_top\" ><img src=\"../../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");

                                                    htmDef.WriteFooter(Properties.Settings.Default.Footer);
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
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + formatnum + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\pset\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iPset, Properties.Settings.Default.Header);
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

                                                            htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-" + localid + ".png\" /></td><td><b> " + localname + ":</b> " + localdesc + "</td></tr>");
                                                        }

                                                        htmDef.WriteLine("</table>");

                                                        if (!Properties.Settings.Default.NoXml)
                                                        {
                                                            ////htmDef.WriteLine("<p><a href=\"http://lookup.bsdd.buildingsmart.com/api/4.0/IfdPSet/search/" + entity.Name + "\" target=\"ifd\"><img src=\"../../../img/external.png\" title=\"Link to IFD\"/> buildingSMART Data Dictionary</a></p>\r\n");
                                                            //http://lookup.bsdd.buildingsmart.com/api/4.0/IfdPSet/search/Pset_ActionRequest

                                                            // use guid
                                                            string guid = IfcGloballyUniqueId.Format(entity.Uuid);
                                                            htmDef.WriteLine("<p><a href=\"http://lookup.bsdd.buildingsmart.com/api/4.0/IfdPSet/" + guid + "/ifcVersion/2x4\" target=\"ifd\"><img border=\"0\" src=\"../../../img/external.png\" title=\"Link to IFD\"/> buildingSMART Data Dictionary</a></p>\r\n");

                                                            htmDef.WriteLine("<p><a href=\"../../../psd/" + entity.Name + ".xml\"><img border=\"0\" src=\"../../../img/diagram.png\" title=\"Link to PSD-XML\"/> PSD-XML</a></p>\r\n");
                                                        }

                                                        // write diagram if it exists
                                                        htmDef.WriteLine(FormatFigure(docProject, entity, null, entity.Name, ref iFigure));
                                                        htmDef.WriteProperties(entity.Properties);

                                                        // write url for incoming page link
                                                        htmDef.WriteLine("<p><a href=\"../../../link/" + MakeLinkName(entity) + ".htm\" target=\"_top\" ><img src=\"../../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");

                                                        htmDef.WriteFooter(Properties.Settings.Default.Footer);
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
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + formatnum + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\pset\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iPset, Properties.Settings.Default.Header);
                                                        htmDef.WriteScript(iSection, iSchema, iSubSection, iPset);
                                                        htmDef.WriteLine("<h4 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString() + " " + entity.Name + "</h4>");

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

                                                            htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-" + localid + ".png\" /></td><td><b> " + localname + ":</b> " + localdesc + "</td></tr>");
                                                        }

                                                        htmDef.WriteLine("</table>");

                                                        htmDef.WriteLine("<ul>\r\n");
                                                        foreach (DocPropertyConstant docprop in entity.Constants)
                                                        {
                                                            htmDef.WriteLine("<li><b>" + docprop.Name + "</b><br/>");

                                                            htmDef.WriteLine("<table>");

                                                            docprop.Localization.Sort();
                                                            foreach (DocLocalization doclocal in docprop.Localization)
                                                            {
                                                                string localname = doclocal.Name;
                                                                string localdesc = doclocal.Documentation;

                                                                string localid = doclocal.Locale.Substring(0, 2).ToLower();

                                                                if (localid.Equals("en", StringComparison.InvariantCultureIgnoreCase) && localdesc == null)
                                                                {
                                                                    localdesc = docprop.Documentation;
                                                                }

                                                                htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-" + localid + ".png\" /></td><td><b>" + localname + "</b>: " + localdesc + "</td></tr>");
                                                            }
                                                            htmDef.WriteLine("</table>");

                                                            htmDef.WriteLine("</li>\r\n");
                                                        }
                                                        htmDef.WriteLine("</ul>\r\n");

                                                        // write url for incoming page link
                                                        //htmDef.WriteLine("<p><a href=\"../../../link/" + MakeLinkName(entity) + ".htm\" target=\"_top\" ><img src=\"../../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");

                                                        htmDef.WriteFooter(Properties.Settings.Default.Footer);
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
                                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + formatnum + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/qset/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\qset\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema, included))
                                                    {
                                                        htmDef.WriteHeader(entity.Name, iSection, iSchema, iPset, Properties.Settings.Default.Header);
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

                                                            htmDef.WriteLine("<tr valign=\"top\"><td><image src=\"../../../img/locale-" + localid + ".png\" title=\"Link to XML\"/></td><td><b>" + localname + "</b>: " + localdesc + "</td></tr>");
                                                        }

                                                        htmDef.WriteLine("</table>");

                                                        if (!Properties.Settings.Default.NoXml)
                                                        {
                                                            htmDef.WriteLine("<p><a href=\"../../../qto/" + entity.Name + ".xml\"><img border=\"0\" src=\"../../../img/diagram.png\" title=\"Link to QTO-XML\"/> QTO-XML</a></p>\r\n");
                                                        }

                                                        // write each quantity
                                                        htmDef.WriteLine("<ul>\r\n");
                                                        foreach (DocQuantity docprop in entity.Quantities)
                                                        {
                                                            htmDef.WriteLine("<li><b>" + docprop.Name + "</b><br/>");
                                                            htmDef.WriteDefinition(docprop.QuantityType.ToString());
                                                            htmDef.WriteLine("<br/>");

                                                            if (!Properties.Settings.Default.NoXml)
                                                            {
                                                                htmDef.WriteLine("<table>");

                                                                docprop.Localization.Sort();
                                                                foreach (DocLocalization doclocal in docprop.Localization)
                                                                {
                                                                    string localname = doclocal.Name;
                                                                    string localdesc = doclocal.Documentation;

                                                                    string localid = doclocal.Locale.Substring(0, 2).ToLower();

                                                                    if (localid.Equals("en", StringComparison.InvariantCultureIgnoreCase) && localdesc == null)
                                                                    {
                                                                        localdesc = docprop.Documentation;
                                                                    }

                                                                    htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-" + localid + ".png\" /></td><td><b>" + localname + "</b>: " + localdesc + "</td></tr>");
                                                                }
                                                                htmDef.WriteLine("</table>");
                                                            }
                                                            else
                                                            {
                                                                htmDef.WriteDocumentationForISO(docprop.Documentation + "</li>\r\n", null, Properties.Settings.Default.NoHistory);
                                                            }

                                                            htmDef.WriteLine("</li>\r\n");
                                                        }
                                                        htmDef.WriteLine("</ul>\r\n");

                                                        // write url for incoming page link
                                                        htmDef.WriteLine("<p><a href=\"../../../link/" + MakeLinkName(entity) + ".htm\" target=\"_top\" ><img src=\"../../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");

                                                        htmDef.WriteFooter(Properties.Settings.Default.Footer);
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
                                    if (Properties.Settings.Default.ExpressG)
                                    {
                                        htmSchema.WriteLine(
                                        "<p><a href=\"../../annex/annex-d/" + MakeLinkName(schema) + "/index.htm\" ><img src=\"../../img/diagram.png\" style=\"border: 0px\" title=\"Link to EXPRESS-G diagram\" alt=\"Link to EXPRESS-G diagram\">&nbsp;EXPRESS-G diagram</a></p>");
                                    }

                                    htmSchema.WriteFooter(Properties.Settings.Default.Footer);
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
                        htmSection.WriteHeader(docannex.Name, iAnnex, 0, 0, Properties.Settings.Default.Header);
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
                        htmSection.WriteDocumentationForISO(docannex.Documentation, docannex, Properties.Settings.Default.NoHistory);

                        // write listing of schemas
                        if (chAnnex == 'A')
                        {
                            // create page for model view
                            htmSection.WriteComputerListing("IFC4", "ifc4", 0);

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
                        }

                        htmSection.WriteFooter(Properties.Settings.Default.Footer);
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
                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + chAnnex + ". <a class=\"listing-link\" href=\"annex-" + chAnnex + ".htm\" target=\"info\" >" + docannex.Name + "</a></td></tr>\r\n");

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
                                                htmRoot.WriteComputerListing(docModelView.Name, docModelView.Code, iCodeView);
                                            }

                                            DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".mvdxml", new DocModelView[] { docModelView }, locales, instances, true);

                                            // show filtered schemas for model views only if exchanges defined
                                            if (Properties.Settings.Default.ConceptTables)
                                            {
                                                DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".exp", new DocModelView[] { docModelView }, locales, instances, true);
                                                DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".xsd", new DocModelView[] { docModelView }, locales, instances, true);
                                                DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".ifc", new DocModelView[] { docModelView }, locales, instances, true);
                                                DoExport(docProject, path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".ifcxml", new DocModelView[] { docModelView }, locales, instances, true);

                                                using (FormatHTM htmExpress = new FormatHTM(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".exp.htm", mapEntity, mapSchema, included))
                                                {
                                                    htmExpress.UseAnchors = true;
                                                    htmExpress.WriteHeader("EXPRESS", 3);
                                                    htmExpress.WriteExpressSchema(docProject);
                                                    htmExpress.WriteFooter("");
                                                }

                                                // Future: write XSD with html markup...
                                                using (FormatHTM htmXSD = new FormatHTM(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".xsd.htm", mapEntity, mapSchema, included))
                                                {
                                                    string xsdcontent = null;
                                                    using (System.IO.StreamReader reader = new System.IO.StreamReader(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".xsd.txt"))
                                                    {
                                                        xsdcontent = reader.ReadToEnd();
                                                    }

                                                    htmXSD.UseAnchors = false;
                                                    htmXSD.WriteHeader("XSD", 3);
                                                    htmXSD.WriteFormatted(xsdcontent);
                                                    htmXSD.WriteFooter("");
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
                                    htmAlpha1.WriteAlphabeticalListing<DocDefined>("Defined Types", Properties.Settings.Default.Footer);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_enumtypes.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocEnumeration>("Enumeration Types", Properties.Settings.Default.Footer);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_selecttypes.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocSelect>("Select Types", Properties.Settings.Default.Footer);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_entities.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocEntity>("Entities", Properties.Settings.Default.Footer);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_functions.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocFunction>("Functions", Properties.Settings.Default.Footer);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_rules.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocGlobalRule>("Rules", Properties.Settings.Default.Footer);
                                }
                                // no translations currently -- enable in future
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_psets.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocPropertySet>("Property Sets", Properties.Settings.Default.Footer);
                                }
                                using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_qsets.htm", mapEntity, mapSchema, included))
                                {
                                    htmAlpha1.WriteAlphabeticalListing<DocQuantitySet>("Quantity Sets", Properties.Settings.Default.Footer);
                                }


                                // generate localized listings
                                foreach (string locale in listLocale.Keys)
                                {
                                    string code = listLocale[locale]; // null for default

                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_definedtypes.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocDefined>("Defined Types", code);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_enumtypes.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocEnumeration>("Enumeration Types", code);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_selecttypes.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocSelect>("Select Types", code);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_entities.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocEntity>("Entities", code);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_functions.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocFunction>("Functions", code);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_rules.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocGlobalRule>("Rules", code);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_psets.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocPropertySet>("Property Sets", code);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_qsets.htm", mapEntity, mapSchema, included))
                                    {
                                        htmAlpha1.WriteLocalizedListing<DocQuantitySet>("Quantity Sets", code);
                                    }

                                }
                                break;

                            case 'C':
                                // Inheritance listings

                                // all entities
                                htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/inheritance_tree_all.htm\" >C.1 All entities</a>");
                                htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C.1 <a href=\"annex-c/inheritance_tree_all.htm\" target=\"info\" >All entities</a></td></tr>");
                                using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/inheritance_tree_all.htm", mapEntity, mapSchema, included))
                                {
                                    htmInheritAll.WriteInheritanceListing(null);
                                }

                                // specific inheritance
                                htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/inheritance_tree_IfcRoot.htm\" >C.2 Rooted entities</a>");
                                htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C.2 <a href=\"annex-c/inheritance_tree_IfcRoot.htm\" target=\"info\" >Rooted entities</a></td></tr>");
                                using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/inheritance_tree_IfcRoot.htm", mapEntity, mapSchema, included))
                                {
                                    htmInheritAll.WriteInheritanceListing("IfcRoot");
                                }

                                htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/inheritance_tree_IfcObject.htm\" >C.3 Object occurrence and type pairs</a>");
                                htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C.3 <a href=\"annex-c/inheritance_tree_IfcObject.htm\" target=\"info\" >Object occurrence and type pairs</a></td></tr>");
                                using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/inheritance_tree_IfcObject.htm", mapEntity, mapSchema, included))
                                {
                                    htmInheritAll.WriteInheritanceListing("IfcObject");
                                }

                                htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/inheritance_tree_IfcElement.htm\" >C.4 Element occurrence and type pairs</a>");
                                htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C.4 <a href=\"annex-c/inheritance_tree_IfcElement.htm\" target=\"info\" >Element occurrence and type pairs</a></td></tr>");
                                using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/inheritance_tree_IfcElement.htm", mapEntity, mapSchema, included))
                                {
                                    htmInheritAll.WriteInheritanceListing("IfcElement");
                                }

                                break;

                            case 'D':
                                // Diagrams

                                // Express-G diagrams
                                htmTOC.WriteTOC(1, "D.1 Schema diagrams");
                                htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.1 Schema diagrams</td></tr>");

                                if (Properties.Settings.Default.ExpressG)
                                {

                                    for (int iSchemaSection = 5; iSchemaSection <= 8; iSchemaSection++)
                                    {
                                        DocSection docSection = docProject.Sections[iSchemaSection - 1];

                                        htmTOC.WriteTOC(2, "D.1." + iSchemaSection + " " + docSection.Name);
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.1." + iSchemaSection + " " + docSection.Name + "</td></tr>");

                                        for (int iSchema = 1; iSchema <= docSection.Schemas.Count; iSchema++)
                                        {
                                            DocSchema docSchema = docSection.Schemas[iSchema - 1];
                                            htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"annex/annex-d/" + MakeLinkName(docSchema) + "/index.htm\" >D.1." + iSchemaSection + "." + iSchema + " " + docSchema.Name + "</a>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.1." + iSchemaSection + "." + iSchema + " <a href=\"annex-d/" + MakeLinkName(docSchema) + "/index.htm\" target=\"info\" >" + docSchema.Name + "</a></td></tr>");

                                            // determine number of diagrams
                                            int iLastDiagram = docSchema.GetDiagramCount();

                                            // generate diagrams
                                            Image imageSchema = FormatPNG.CreateSchemaDiagram(docSchema, mapEntity);

                                            using (FormatHTM htmSchemaDiagram = new FormatHTM(path + "/annex/annex-d/" + MakeLinkName(docSchema) + "/index.htm", mapEntity, mapSchema, included))
                                            {
                                                int iSub = 1;

                                                htmSchemaDiagram.WriteHeader(docSection.Name, 3);
                                                htmSchemaDiagram.WriteScript(iAnnex, iSub, iSection, 0);
                                                htmSchemaDiagram.WriteLine("<h4 class=\"std\">D.1." + iSection + "." + iSchema + " " + docSchema.Name + "</h4>");

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
                                                htmSchemaDiagram.WriteFooter(Properties.Settings.Default.Footer);
                                            }

                                            double scale = 0.375; // hard-coded for now -- read from SCHEMATA.scale
                                            double pageCX = 1600; // hard-coded for now -- read from SCHEMATA.settings.page.width
                                            double pageCY = 2370; // hard-coded for now -- read from SCHEMATA.settings.page.height

                                            for (int iDiagram = 1; iDiagram <= iLastDiagram; iDiagram++)
                                            {
                                                string formatnumber = iDiagram.ToString("D4");
                                                using (FormatHTM htmSchema = new FormatHTM(path + "/annex/annex-d/" + MakeLinkName(docSchema) + "/diagram_" + formatnumber + ".htm", mapEntity, mapSchema, included))
                                                {
                                                    htmSchema.WriteHeader(docSchema.Name, 3);
                                                    htmSchema.WriteScript(iAnnex, 1, iSchemaSection, iDiagram);

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
                                                        if (docType.DiagramNumber == iDiagram && docType.DiagramRectangle != null)
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
                                                        if (docType.DiagramNumber == iDiagram && docType.DiagramRectangle != null)
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
                                                                        string link = "../../../schema/" + mapSchema[docDefinitionRef.Name].ToLower() + "/lexical/" + docDefinitionRef.Name.ToLower() + ".htm";
                                                                        htmSchema.WriteLine("    <area shape=\"rect\" coords=\"" + x0 + ", " + y0 + ", " + x1 + ", " + y1 + "\" alt=\"Navigate\" href=\"" + link + "\" />");
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    htmSchema.WriteLine("  </map>");
                                                    htmSchema.WriteLine("</img>");
                                                    htmSchema.WriteFooter(Properties.Settings.Default.Footer);
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
                                            mapRectangle = new Dictionary<Rectangle, DocEntity>();
                                            docProject.RegisterObjectsInScope(docView, viewinclude);
                                            using (Image imgDiagram = FormatPNG.CreateInheritanceDiagram(docProject, viewinclude, docEntityRoot, new Font(FontFamily.GenericSansSerif, 8.0f), mapRectangle))
                                            {
                                                using (FormatHTM htmCover = new FormatHTM(path + @"\annex\annex-d\" + MakeLinkName(docView) + @"\cover.htm", mapEntity, mapSchema, included))
                                                {
                                                    htmCover.WriteHeader(docView.Name, 1);

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


                                                    htmCover.WriteFooter(String.Empty);
                                                }

                                                // create image after (depends on directory being created first)
                                                try
                                                {
                                                    imgDiagram.Save(path + @"\annex\annex-d\" + MakeLinkName(docView) + @"\cover.png");
                                                }
                                                catch
                                                {

                                                }
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
                                                    htmRoot.WriteHeader(docRoot.ApplicableEntity.Name, iAnnex, 2, iView, Properties.Settings.Default.Header);
                                                    htmRoot.WriteScript(iAnnex, 2, iView, iRoot);
                                                    htmRoot.WriteLine("<h3 class=\"std\">D.2." + iView.ToString() + "." + iRoot.ToString() + " " + docRoot.ApplicableEntity.Name + "</h3>");

                                                    string diagram = FormatDiagram(docProject, docRoot.ApplicableEntity, docView, ref iFigure, mapEntity, mapSchema);
                                                    htmRoot.WriteLine(diagram);

                                                    htmRoot.WriteFooter(Properties.Settings.Default.Footer);
                                                }

                                            }
                                        }
                                    }

                                }
                                break;

                            case 'E':
                                if (docProject.Examples != null)
                                {
                                    int iExampleNumber = 0;
                                    for (int iExample = 1; iExample <= docProject.Examples.Count; iExample++)
                                    {
                                        DocExample docExample = docProject.Examples[iExample - 1];

                                        if (included == null || included.ContainsKey(docExample))
                                        {
                                            iExampleNumber++;

                                            string pathExample = path + @"\annex\annex-e\" + MakeLinkName(docExample) + ".htm";
                                            using (FormatHTM htmExample = new FormatHTM(pathExample, mapEntity, mapSchema, included))
                                            {
                                                htmExample.WriteHeader(docExample.Name, 2);
                                                htmExample.WriteScript(iAnnex, iExampleNumber, 0, 0);
                                                htmExample.WriteLine("<h3 class=\"std\">E." + iExampleNumber.ToString() + " " + docExample.Name + "</h3>");
                                                htmExample.WriteDocumentationForISO(docExample.Documentation, docExample, false);
                                                htmExample.WriteLine("<p><a href=\"../../link/" + MakeLinkName(docExample) + ".htm\" target=\"_top\" ><img src=\"../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");
                                                htmExample.WriteFooter(Properties.Settings.Default.Footer);
                                            }

                                            using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docExample) + ".htm", mapEntity, mapSchema, included))
                                            {
                                                string linkurl = "../annex/annex-e/" + MakeLinkName(docExample) + ".htm";
                                                htmLink.WriteLinkPage(linkurl);
                                            }

                                            string urlExample = "annex-e/" + MakeLinkName(docExample) + ".htm";
                                            htmTOC.WriteTOC(2, "<a class=\"listing-link\" href=\"annex/" + urlExample + "\" >" + chAnnex.ToString() + "." + iExampleNumber + " " + docExample.Name + "</a>");

                                            string htmllink = chAnnex.ToString() + "." + iExampleNumber + " <a class=\"listing-link\" href=\"" + urlExample + "\" target=\"info\">" + docExample.Name + "</a>";
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + htmllink + "</td></tr>");

                                            if (docExample.Examples != null)
                                            {
                                                int iSubNumber = 0;
                                                for (int iSub = 1; iSub <= docExample.Examples.Count; iSub++)
                                                {
                                                    DocExample docSub = docExample.Examples[iSub - 1];

                                                    if (included == null || included.ContainsKey(docSub))
                                                    {
                                                        iSubNumber++;
                                                        string pathSub = path + @"\annex\annex-e\" + MakeLinkName(docSub) + ".htm";
                                                        using (FormatHTM htmSub = new FormatHTM(pathSub, mapEntity, mapSchema, included))
                                                        {
                                                            htmSub.WriteHeader(docSub.Name, 2);
                                                            htmSub.WriteScript(iAnnex, iExampleNumber, iSubNumber, 0);
                                                            htmSub.WriteLine("<h4 class=\"std\">E." + iExampleNumber + "." + iSubNumber + " " + docSub.Name + "</h4>");
                                                            htmSub.WriteDocumentationForISO(docSub.Documentation, docSub, false);
                                                            htmSub.WriteLine("<p><a href=\"../../link/" + MakeLinkName(docSub) + ".htm\" target=\"_top\" ><img src=\"../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");
                                                            htmSub.WriteFooter(Properties.Settings.Default.Footer);
                                                        }

                                                        using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docSub) + ".htm", mapEntity, mapSchema, included))
                                                        {
                                                            string linkurl = "../annex/annex-e/" + MakeLinkName(docSub) + ".htm";
                                                            htmLink.WriteLinkPage(linkurl);
                                                        }

                                                        string urlSub = "annex-e/" + MakeLinkName(docSub) + ".htm";
                                                        htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"annex/" + urlSub + "\" >" + chAnnex.ToString() + "." + iExampleNumber + "." + iSubNumber + " " + docSub.Name + "</a>");

                                                        string sublink = chAnnex.ToString() + "." + iExampleNumber + "." + iSubNumber + " <a class=\"listing-link\" href=\"" + urlSub + "\" target=\"info\">" + docSub.Name + "</a>";
                                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">" + sublink + "</td></tr>");
                                                    }
                                                }
                                            }
                                        }
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
                                            htmWhatsnew.WriteHeader(docChangeSet.Name, 3);
                                            htmWhatsnew.WriteScript(iAnnex, iChangeset, 0, 0);
                                            htmWhatsnew.WriteLine("<h4 class=\"std\">F." + iChangeset + " " + docChangeSet.Name + "</h4>");
                                            htmWhatsnew.WriteDocumentationForISO(docChangeSet.Documentation, docChangeSet, false);

                                            htmWhatsnew.WriteFooter(Properties.Settings.Default.Footer);
                                        }

                                        // change log for entities
                                        htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-f/" + MakeLinkName(docChangeSet) + "/changelog.htm\" >F." + iChangeset + ".1 Entities</a>");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a href=\"annex-f/" + MakeLinkName(docChangeSet) + "/changelog.htm\" target=\"info\" >F." + iChangeset + ".1 Entities</a></td></tr>");
                                        string pathChange = path + @"\annex\annex-f\" + MakeLinkName(docChangeSet) + @"\changelog.htm";
                                        using (FormatHTM htmChange = new FormatHTM(pathChange, mapEntity, mapSchema, included))
                                        {
                                            htmChange.WriteHeader(docChangeSet.Name, 3);
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
                                            htmChange.WriteFooter(Properties.Settings.Default.Footer);
                                        }

                                        // change log for properties
                                        htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-f/" + MakeLinkName(docChangeSet) + "/properties.htm\" >F." + iChangeset + ".2 Properties</a>");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a href=\"annex-f/" + MakeLinkName(docChangeSet) + "/properties.htm\" target=\"info\" >F." + iChangeset + ".1 Properties</a></td></tr>");
                                        pathChange = path + @"\annex\annex-f\" + MakeLinkName(docChangeSet) + @"\properties.htm";
                                        using (FormatHTM htmChange = new FormatHTM(pathChange, mapEntity, mapSchema, included))
                                        {
                                            htmChange.WriteHeader(docChangeSet.Name, 3);
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
                                            htmChange.WriteFooter(Properties.Settings.Default.Footer);
                                        }


                                        // change log for quantities
                                        htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-f/" + MakeLinkName(docChangeSet) + "/quantities.htm\" >F." + iChangeset + ".3 Quantities</a>");
                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a href=\"annex-f/" + MakeLinkName(docChangeSet) + "/quantities.htm\" target=\"info\" >F." + iChangeset + ".3 Quantities</a></td></tr>");
                                        pathChange = path + @"\annex\annex-f\" + MakeLinkName(docChangeSet) + @"\quantities.htm";
                                        using (FormatHTM htmChange = new FormatHTM(pathChange, mapEntity, mapSchema, included))
                                        {
                                            htmChange.WriteHeader(docChangeSet.Name, 3);
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
                                            htmChange.WriteFooter(Properties.Settings.Default.Footer);
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

                htmTOC.WriteLine("</p>");


                // write figures
                htmTOC.WriteLine("      <h1 class=\"std\">Figures</h1>");
                htmTOC.WriteLine("<p>");
                foreach (DocSection section in docProject.Sections)
                {
                    if (docProject.Sections.IndexOf(section) == 3)
                    {
                        int iFigureTemplate = 0;
                        foreach (DocTemplateDefinition docTemplate in docProject.Templates)
                        {
                            htmTOC.WriteFigureContentsForTemplate(docTemplate, ref iFigureTemplate);
                        }
                    }

                    foreach (DocSchema schema in section.Schemas)
                    {
                        if (included == null || included.ContainsKey(schema))
                        {
                            htmTOC.WriteFigureContents(schema);

                            foreach (DocType type in schema.Types)
                            {
                                htmTOC.WriteFigureContents(type);
                            }

                            foreach (DocEntity entity in schema.Entities)
                            {
                                htmTOC.WriteFigureContents(entity);
                            }
                        }
                    }
                }
                htmTOC.WriteLine("</p>");

                // write tables
                htmTOC.WriteLine("      <h1 class=\"std\">Tables</h1>");
                htmTOC.WriteLine("<p>");
                foreach (DocSection section in docProject.Sections)
                {
                    foreach (DocSchema schema in section.Schemas)
                    {
                        if (included == null || included.ContainsKey(schema))
                        {
                            htmTOC.WriteTableContents(schema);
                            foreach (DocType type in schema.Types)
                            {
                                htmTOC.WriteTableContents(type);
                            }

                            foreach (DocEntity entity in schema.Entities)
                            {
                                htmTOC.WriteTableContents(entity);
                            }
                        }
                    }
                }
                htmTOC.WriteLine("</p>");

                htmTOC.WriteFooter(Properties.Settings.Default.Footer);
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
                htmIndex.WriteHeader("Index", 0);

                htmIndex.Write(
                    "\r\n" +
                    "<script language=\"JavaScript1.1\" type=\"text/javascript\">\r\n" +
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

                            if (refobj is DocPropertySet)
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
                                if (obj is DocPropertySet)
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

                // write links for each concept template recursively
                List<DocTemplateDefinition> listLink = new List<DocTemplateDefinition>();
                foreach (DocTemplateDefinition docTemplate in docProject.Templates)
                {
                    listLink.Add(docTemplate);
                    GenerateTemplateLink(listLink, mapEntity, mapSchema, included);
                    listLink.Clear();
                }

                // write links for each example recursively
                List<DocExample> listLinkExample = new List<DocExample>();
                if (docProject.Examples != null)
                {
                    foreach (DocExample docTemplate in docProject.Examples)
                    {
                        listLinkExample.Add(docTemplate);
                        GenerateExampleLink(listLinkExample, mapEntity, mapSchema, included);
                        listLinkExample.Clear();
                    }
                }

                htmIndex.WriteLine("</p>");
                htmIndex.WriteFooter(Properties.Settings.Default.Footer);
            }
        }
    }
}

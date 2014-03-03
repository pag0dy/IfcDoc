// Name:        FormEdit.cs
// Description: Graphical User Interface for generating ISO documentation
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2010 BuildingSmart International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IfcDoc.Schema;
using IfcDoc.Schema.VEX;
using IfcDoc.Schema.DOC;
using IfcDoc.Schema.PSD;
using IfcDoc.Schema.MVD;
using IfcDoc.Schema.CNF;

using IfcDoc.Format.MDB;
using IfcDoc.Format.SPF;
using IfcDoc.Format.XML;
using IfcDoc.Format.HTM;
using IfcDoc.Format.CSC;
using IfcDoc.Format.EXP;
using IfcDoc.Format.XSD;
using IfcDoc.Format.PNG;

namespace IfcDoc
{
    public partial class FormEdit : Form
    {
        // file state
        string m_file; // the path of the current file, or null if no file yet
        string m_server; // the path of the server, or null if no server connection
        bool m_modified; // whether file has been modified such that user is prompted to save upon exiting or loading another file
        bool m_loading; // currently loading, so don't react to constructor serialization

        // edit state
        Dictionary<long, SEntity> m_instances; // cache of data, mapped by instance ID such as found in STEP file
        Dictionary<string, TreeNode> m_mapTree; // use to sync tree for navigation redirection, also to quickly lookup definitions by name
        DocProject m_project; // the root project object
        long m_lastid;

        // documentation generation
        DocModelView[] m_filterviews;
        string[] m_filterlocales;

        // clipboard
        DocObject m_clipboard;

        FormProgress m_formProgress;
        Exception m_exception;

        // maps type to image index for treeview
        internal static Type[] s_imagemap = new Type[]
        {
            null,
            typeof(DocAnnex),
            typeof(DocAttribute),
            typeof(DocConstant),
            typeof(DocDefined),
            typeof(DocEntity),
            typeof(DocEnumeration),
            typeof(DocFunction),
            typeof(DocGlobalRule),
            typeof(DocProperty),
            typeof(DocPropertySet),
            typeof(DocQuantity),
            typeof(DocQuantitySet),
            typeof(DocSchema),
            typeof(DocSection),
            typeof(DocSelect),
            typeof(DocTemplateItem),
            typeof(DocTemplateUsage),
            typeof(DocUniqueRule),
            typeof(DocWhereRule),
            null,
            null,
            null,
            typeof(DocTemplateDefinition),
            typeof(DocModelView),
            typeof(DocExchangeDefinition),
            typeof(DocExchangeItem),
            typeof(DocModelRuleAttribute),
            typeof(DocModelRuleEntity),            
            typeof(DocChangeSet),
            typeof(DocConceptRoot),
            typeof(DocExample),
            typeof(DocPropertyEnumeration),
            typeof(DocPropertyConstant),
            typeof(DocComment),
            typeof(DocPrimitive),
            typeof(DocPageTarget),
            typeof(DocPageSource),
            typeof(DocSchemaRef),
            typeof(DocDefinitionRef),
            typeof(DocTerm),
            typeof(DocAbbreviation),
        };

        private const int ImageIndexTemplateEntity = 20;
        private const int ImageIndexTemplateEnum = 21;
        private const int ImageIndexAttributeInverse = 22;

        public FormEdit() : this(null)
        {
        }

        public FormEdit(string[] args)
        {
            InitializeComponent();

            this.m_file = null;
            this.m_modified = false;
            this.m_loading = false;
            this.m_instances = new Dictionary<long, SEntity>();
            this.m_mapTree = new Dictionary<string, TreeNode>();
            this.m_lastid = 0;

            SEntity.EntityCreated += new EventHandler(SEntity_EntityCreated);
            SEntity.EntityDeleted += new EventHandler(SEntity_EntityDeleted);

            this.toolStripMenuItemFileNew_Click(this, EventArgs.Empty);

            // usage for command line arguments:
            // ifcdoc [filename] [output directory]

            // A. No arguments: new file
            // Example> ifcdoc.exe

            // B. One argument: loads file (for launching file in Windows)
            // ifcdoc.exe filepath.ifcdoc 
            // Example> ifcdoc.exe "C:\DOCS\COBIE-2012.ifcdoc"

            // C. Two arguments: loads file, generates documentation, closes (for calling by server to generate html and mvdxml files)
            // Example> ifcdoc.exe "C:\CMSERVER\9dafdaf41f5b42db97479cfc578a4c2b\00000001.ifcdoc" "C:\CMSERVER\9dafdaf41f5b42db97479cfc578a4c2b\html\"

            if (args.Length >= 1)
            {
                this.LoadFile(args[0]);
            }

            if (args.Length == 2)
            {                
                Properties.Settings.Default.OutputPath = args[1];
                //this.FilterInclude(
                this.GenerateDocumentation();
                this.Close();
            }
        }


        /// <summary>
        /// Updates the current file path used for saving and for displaying in window caption, and resets modified flag.
        /// </summary>
        /// <param name="path"></param>
        private void SetCurrentFile(string path)
        {
            this.m_file = path;
            this.m_server = null;
            this.m_modified = false;

            string appname = "IFC Documentation Generator";
            if (this.m_file != null)
            {
                string name = System.IO.Path.GetFileName(this.m_file);
                this.Text = name + " - " + appname;
            }
            else
            {
                this.Text = appname;
            }
        }

        void SEntity_EntityDeleted(object sender, EventArgs e)
        {
            SEntity entity = (SEntity)sender;
            this.m_instances.Remove(entity.OID);
        }

        void SEntity_EntityCreated(object sender, EventArgs e)
        {
            if (this.m_loading)
            {
                return;
            }

            this.m_lastid++;

            SEntity entity = (SEntity)sender;
            entity.OID = this.m_lastid;
            this.m_instances.Add(entity.OID, entity);
        }

        #region FILE

        /// <summary>
        /// Prompts to save if file has been modified.
        /// </summary>
        /// <returns>True if ok to proceed (user clicked Yes or No), False to not continue (user clicked Cancel)</returns>
        private bool PromptSave()
        {
            if (this.m_modified)
            {
                DialogResult res = MessageBox.Show(this, "Do you want to save changes?", "IFC Documentation Generator", MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        toolStripMenuItemFileSave_Click(this, EventArgs.Empty);
                        return true;

                    case DialogResult.No:
                        return true;

                    case DialogResult.Cancel:
                        return false;
                }
            }

            return true;
        }

        private void toolStripMenuItemFileNew_Click(object sender, EventArgs e)
        {
            if (!PromptSave())
                return;

            this.SetCurrentFile(null);

            this.m_lastid = 0;
            this.m_instances.Clear();
            this.m_mapTree.Clear();
            this.m_clipboard = null;

            // init defaults
            this.m_project = new DocProject();
            this.m_project.Sections = new List<DocSection>();
            this.m_project.Sections.Add(new DocSection("Scope"));
            this.m_project.Sections.Add(new DocSection("Normative references"));
            this.m_project.Sections.Add(new DocSection("Terms, definitions, and abbreviated terms"));
            this.m_project.Sections.Add(new DocSection("Fundamental concepts and assumptions"));
            this.m_project.Sections.Add(new DocSection("Core data schemas"));
            this.m_project.Sections.Add(new DocSection("Shared element data schemas"));
            this.m_project.Sections.Add(new DocSection("Domain specific data schemas"));
            this.m_project.Sections.Add(new DocSection("Resource definition data schemas"));
            this.m_project.Annexes.Add(new DocAnnex("Computer interpretable listings"));
            this.m_project.Annexes.Add(new DocAnnex("Alphabetical listings"));
            this.m_project.Annexes.Add(new DocAnnex("Inheritance listings"));
            this.m_project.Annexes.Add(new DocAnnex("Diagrams"));
            this.m_project.Annexes.Add(new DocAnnex("Examples"));
            this.m_project.Annexes.Add(new DocAnnex("Change logs"));

            this.splitContainerConcept.Panel2Collapsed = true;

            this.m_project.Annexes[1].Code = "IFC4"; // schema id

            LoadTree();
        }

        private void toolStripMenuItemFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult res = this.openFileDialogLoad.ShowDialog();
            if (res == DialogResult.OK)
            {
                LoadFile(this.openFileDialogLoad.FileName);
            }
        }

        private void LoadFile(string filename)
        {
            this.SetCurrentFile(filename);

            this.m_lastid = 0;
            this.m_instances.Clear();
            this.m_mapTree.Clear();
            this.m_clipboard = null;
            this.m_project = null;

            string ext = System.IO.Path.GetExtension(this.m_file).ToLower();
            try
            {
                switch (ext)
                {
                    case ".ifcdoc":
                        using (FormatSPF format = new FormatSPF(this.m_file, SchemaDOC.Types, this.m_instances))
                        {
                            format.Load();
                        }
                        break;

                    case ".mdb":
                        using (FormatMDB format = new FormatMDB(this.m_file, SchemaDOC.Types, this.m_instances))
                        {
                            format.Load();
                        }
                        break;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(this, x.Message, "Error", MessageBoxButtons.OK);
                return;
            }

            List<SEntity> listDelete = new List<SEntity>();
            List<DocTemplateDefinition> listTemplate = new List<DocTemplateDefinition>();

            // get the project, determine the next OID to use
            foreach (SEntity o in this.m_instances.Values)
            {
                if (o is DocProject)
                {
                    this.m_project = (DocProject)o;
                }
                else if (o is DocEntity)
                {
                    DocEntity docent = (DocEntity)o;

#if false
                    // files before V5.3 had Description field; no longer needed so use regular Documentation field again.
                    if (docent._Description != null)
                    {
                        docent.Documentation = docent._Description;
                        docent._Description = null;
                    }
#endif
                }
                else if (o is DocExchangeDefinition)
                {
                    // files before V4.9 had Description field; no longer needed so use regular Documentation field again.
                    DocExchangeDefinition docexchange = (DocExchangeDefinition)o;
                    if (docexchange._Description != null)
                    {
                        docexchange.Documentation = docexchange._Description;
                        docexchange._Description = null;
                    }
                }
                else if (o is DocTemplateDefinition)
                {
                    // files before V5.0 had Description field; no longer needed so use regular Documentation field again.
                    DocTemplateDefinition doctemplate = (DocTemplateDefinition)o;
                    if (doctemplate._Description != null)
                    {
                        doctemplate.Documentation = doctemplate._Description;
                        doctemplate._Description = null;
                    }

                    listTemplate.Add((DocTemplateDefinition)o);
                }

                // ensure all objects have valid guid
                if (o is DocObject)
                {
                    DocObject docobj = (DocObject)o;
                    if (docobj.Uuid == Guid.Empty)
                    {
                        docobj.Uuid = Guid.NewGuid();
                    }
                }

                if (o.OID > this.m_lastid)
                {
                    this.m_lastid = o.OID;
                }
            }

            if (this.m_project == null)
            {
                MessageBox.Show(this, "File is invalid; no project is defined.", "Error", MessageBoxButtons.OK);
                return;
            }

            // include collection if needed (2.7+)
            if (this.m_project.ModelViews == null)
            {
                this.m_project.ModelViews = new List<DocModelView>();
            }

            // now capture any template definitions (upgrade in V3.5)
            foreach (DocModelView docModelView in this.m_project.ModelViews)
            {
                if (docModelView.ConceptRoots == null)
                {
                    // must convert to new format
                    docModelView.ConceptRoots = new List<DocConceptRoot>();

                    foreach (DocSection docSection in this.m_project.Sections)
                    {
                        foreach (DocSchema docSchema in docSection.Schemas)
                        {
                            foreach (DocEntity docEntity in docSchema.Entities)
                            {
                                if (docEntity.__Templates != null)
                                {
                                    foreach (DocTemplateUsage docTemplateUsage in docEntity.__Templates)
                                    {
                                        // must generate or use existing concept root

                                        DocConceptRoot docConceptRoot = null;
                                        foreach (DocConceptRoot eachConceptRoot in docModelView.ConceptRoots)
                                        {
                                            if (eachConceptRoot.ApplicableEntity == docEntity)
                                            {
                                                docConceptRoot = eachConceptRoot;
                                                break;
                                            }
                                        }

                                        if (docConceptRoot == null)
                                        {
                                            docConceptRoot = new DocConceptRoot();
                                            docConceptRoot.ApplicableEntity = docEntity;
                                            docModelView.ConceptRoots.Add(docConceptRoot);
                                        }

                                        docConceptRoot.Concepts.Add(docTemplateUsage);
                                    }
                                }
                            }
                        }
                    }
                }
            }

#if false
            // temp fixup
            foreach (DocSection docSection in this.m_project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    //docSchema.PropertyEnums.Sort();

                    foreach (DocPropertyEnumeration docEnum in docSchema.PropertyEnums)
                    {
                        foreach(DocPropertyConstant docConst in docEnum.Constants)
                        {
                            docConst.Name = docConst.Name.ToUpper(); // ensure uppercase throughout

                            switch(docConst.Name)
                            {
                                case "OTHER":
                                    docConst.RegisterLocalization("en", "(other)", "Value is not listed.");
                                    break;

                                case "NOTKNOWN":
                                    docConst.RegisterLocalization("en", "(unknown)", "Value is unknown.");
                                    break;

                                case "UNSET":
                                    docConst.RegisterLocalization("en", "(unset)", "Value has not been specified.");
                                    break;
                            }
                        }
                    }
                }
            }
#endif

#if false
            // ensure property enumerations are defined (upgrade to V5.8) and provide localizations
            Dictionary<string, DocPropertyEnumeration> mapEnums = new Dictionary<string, DocPropertyEnumeration>();

            foreach(DocSection docSection in this.m_project.Sections)
            {
                foreach(DocSchema docSchema in docSection.Schemas)
                {
                    foreach(DocType docType in docSchema.Types)
                    {
                        EnsureLocalized(docType);
                    }

                    foreach(DocEntity docEntity in docSchema.Entities)
                    {
                        EnsureLocalized(docEntity);
                    }

                    foreach(DocFunction docFunction in docSchema.Functions)
                    {
                        EnsureLocalized(docFunction);
                    }

                    foreach(DocGlobalRule docRule in docSchema.GlobalRules)
                    {
                        EnsureLocalized(docRule);
                    }

                    foreach(DocPropertySet docPset in docSchema.PropertySets)
                    {
                        EnsureLocalized(docPset);

                        foreach(DocProperty docProp in docPset.Properties)
                        {
                            EnsureLocalized(docProp);

                            if (docProp.PropertyType == DocPropertyTemplateTypeEnum.P_ENUMERATEDVALUE)
                            {
                                // temporary migration
                                string match = "PEnum_Status:";
                                if (docProp.SecondaryDataType.StartsWith(match))
                                {
                                    docProp.SecondaryDataType = "PEnum_ElementStatus:" + docProp.SecondaryDataType.Substring(match.Length);
                                }

                                string[] enumhost = docProp.SecondaryDataType.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                if (enumhost.Length == 2)
                                {
                                    string enumname = enumhost[0];


                                    DocPropertyEnumeration docEnum = null;
                                    if (docProp.PrimaryDataType != null && !mapEnums.TryGetValue(enumname, out docEnum))
                                    {
                                        docEnum = new DocPropertyEnumeration();
                                        docEnum.Name = enumname;
                                        docSchema.PropertyEnums.Add(docEnum);

                                        mapEnums.Add(docEnum.Name, docEnum);

                                        string[] enumvals = enumhost[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                        foreach (string val in enumvals)
                                        {
                                            DocPropertyConstant docConstant = new DocPropertyConstant();
                                            docConstant.Name = val;
                                            docEnum.Constants.Add(docConstant);

                                            // localize constant
                                            StringBuilder sb = new StringBuilder();

                                            // if constant is entirely uppercase, then convert such that only first character is uppercase
                                            for (int i = 0; i < val.Length; i++ )
                                            {
                                                char ch = val[i];
                                                if (ch == '_')
                                                {
                                                    ch = ' ';
                                                }
                                                else if (Char.IsUpper(ch) && i > 0 && !Char.IsUpper(val[i - 1]))
                                                {
                                                    sb.Append(" ");
                                                }
                                                else if(Char.IsUpper(ch) && i > 0 && Char.IsUpper(val[i-1]))
                                                {
                                                    ch = Char.ToLower(ch);
                                                }

                                                sb.Append(ch);
                                            }

                                            // find description for constant
                                            string doc = null;
                                            int iDoc = docProp.Documentation.IndexOf(docConstant.Name + ":");
                                            if(iDoc > 0)
                                            {
                                                int iTail = docProp.Documentation.IndexOfAny(new char[] { '.', ';', '\r', '\n'}, iDoc+1);
                                                if (iTail == -1)
                                                {
                                                    iTail = docProp.Documentation.Length;
                                                }
                                                doc = docProp.Documentation.Substring(iDoc + docConstant.Name.Length + 2, iTail - iDoc - docConstant.Name.Length - 2);
                                            }

                                            docConstant.RegisterLocalization("en", sb.ToString(), doc);
                                        }

                                    }
                                }
                            }
                        }

                    }

                    foreach(DocQuantitySet docQset in docSchema.QuantitySets)
                    {
                        EnsureLocalized(docQset);

                        foreach(DocQuantity docQuantiy in docQset.Quantities)
                        {
                            EnsureLocalized(docQuantiy);
                        }
                    }
                }
            }
#endif

            // now clear out the lists going forward.
            LoadTree();
        }

        /// <summary>
        /// Temporary routine for providing English localization for definition
        /// </summary>
        /// <param name="def"></param>
        private static void EnsureLocalized(DocObject def)
        {
            string locale = "en";

            DocLocalization docLocal = def.GetLocalization(locale);
            if (docLocal != null)
                return;

            docLocal = def.RegisterLocalization(locale, null, null);

            string name = def.Name;

            // strip off prefix (Ifc, Pset_, Qto_)
            if (name.StartsWith("Ifc"))
            {
                name = name.Substring(3);
            }
            else if (name.StartsWith("Pset_"))
            {
                name = name.Substring(5);
            }
            else if (name.StartsWith("Qto_"))
            {
                name = name.Substring(4);
            }

            // if all caps (e.g. enum constants), then make first capital and rest lowercase

            // insert spaces before any capitalized word
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                char ch = name[i];

                if (Char.IsUpper(ch) && i > 0 && !Char.IsUpper(name[i - 1]))
                {
                    sb.Append(" ");
                }
               
                sb.Append(ch);
            }

            docLocal.Name = sb.ToString();
        }


        private void toolStripMenuItemFileSave_Click(object sender, EventArgs e)
        {
            if (this.m_file != null)
            {
                string ext = System.IO.Path.GetExtension(this.m_file).ToLower();

                try
                {
                    switch (ext)
                    {
                        case ".ifcdoc":
                            using (FormatSPF format = new FormatSPF(this.m_file, SchemaDOC.Types, this.m_instances))
                            {
                                format.InitHeaders(this.m_file, "IFCDOC_6_4");
                                format.Save();
                            }
                            break;

                        case ".mdb":
                            using (FormatMDB format = new FormatMDB(this.m_file, SchemaDOC.Types, this.m_instances))
                            {
                                format.Save();
                            }
                            break;
                    }
                    this.m_modified = false;
                }
                catch (System.Exception x)
                {
                    MessageBox.Show(x.Message);
                }

                // then optionally upload if connected to server
                if (this.m_server != null)
                {
                    this.toolStripMenuItemPublish_Click(this, EventArgs.Empty);
                }
            }
            else
            {
                toolStripMenuItemFileSaveAs_Click(sender, e);
            }
        }

        private void toolStripMenuItemFileSaveAs_Click(object sender, EventArgs e)
        {
            DialogResult res = this.saveFileDialogSave.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.SetCurrentFile(this.saveFileDialogSave.FileName);
                toolStripMenuItemFileSave_Click(sender, e);
            }
        }

        private void toolStripMenuItemFileImport_Click(object sender, EventArgs e)
        {
            StringBuilder sbErrors = new StringBuilder();

            DialogResult res = this.openFileDialogImport.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                List<DocSchema> importedschemas = new List<DocSchema>();

                bool updateDescriptions = false;
                if(this.openFileDialogImport.FileName.EndsWith(".vex"))
                {
                    DialogResult resUpdate = MessageBox.Show(this, "Do you want to update the documentation? Click Yes to update documentation and definitions, or No to update just definitions.", "Import VEX", MessageBoxButtons.YesNoCancel);
                    if (resUpdate == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    if (resUpdate == System.Windows.Forms.DialogResult.Yes)
                        updateDescriptions = true;
                }

                foreach (string filename in this.openFileDialogImport.FileNames)
                {
                    string ext = System.IO.Path.GetExtension(filename).ToLower();
                    switch (ext)
                    {
                        case ".vex":
                            using (FormatSPF format = new FormatSPF(filename, SchemaVEX.Types, null))
                            {
                                format.Load();

                                // get the root schemata
                                SCHEMATA vexschema = null;
                                foreach (SEntity entity in format.Instances.Values)
                                {
                                    if (entity is SCHEMATA)
                                    {
                                        vexschema = (SCHEMATA)entity;
                                        break;
                                    }
                                }

                                if (vexschema != null)
                                {
                                    DocSchema schema = Program.ImportVex(vexschema, this.m_project, updateDescriptions);
                                    importedschemas.Add(schema); // add schemas from multiple files first, process later
                                }
                            }
                            break;

                        case ".xml":
                            if (filename.Contains("Pset_"))
                            {
                                using (FormatXML format = new FormatXML(filename, typeof(PropertySetDef)))
                                {
                                    format.Load();
                                    PropertySetDef psd = (PropertySetDef)format.Instance;

                                    string schema = null;
                                    if (psd.Versions != null && psd.Versions.Count > 0)
                                    {
                                        schema = psd.Versions[0].schema;
                                    }

                                    if (String.IsNullOrEmpty(schema))
                                    {
                                        // guess the schema according to applicable type value
                                        string[] parts = psd.ApplicableTypeValue.Split(new char[] { '/', '[' });
                                        TreeNode tnEntity = null;
                                        if (this.m_mapTree.TryGetValue(parts[0].ToLowerInvariant(), out tnEntity))
                                        {
                                            DocSchema docschema = (DocSchema)tnEntity.Parent.Parent.Tag;
                                            schema = docschema.Name;
                                        }
                                    }

                                    // find the schema
                                    TreeNode tn = null;
                                    if (schema != null && this.m_mapTree.TryGetValue(schema.ToLowerInvariant(), out tn))
                                    {
                                        DocSchema docschema = (DocSchema)tn.Tag;

                                        // find existing pset if applicable
                                        DocPropertySet pset = docschema.RegisterPset(psd.Name);
                                        
                                        // use hashed guid
                                        if (pset.Uuid == Guid.Empty)
                                        {
                                            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                                            byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(pset.Name));
                                            pset.Uuid = new Guid(hash);
                                        }

                                        pset.Name = psd.Name;
                                        pset.Documentation = psd.Definition.Trim();
                                        pset.ApplicableType = psd.ApplicableTypeValue.Replace("Type", "").Replace("[PerformanceHistory]", ""); // organize at occurrences; use pset type to determine type applicability

                                        // for now, rely on naming convention (better to capture in pset schema eventually)
                                        if (psd.Name.Contains("PHistory")) // special naming convention
                                        {
                                            pset.PropertySetType = "PSET_PERFORMANCEDRIVEN";
                                        }
                                        else if (psd.Name.Contains("Occurrence"))
                                        {
                                            pset.PropertySetType = "PSET_OCCURRENCEDRIVEN";
                                        }
                                        else
                                        {
                                            pset.PropertySetType = "PSET_TYPEDRIVENOVERRIDE";
                                        }

                                        // import localized definitions
                                        if (psd.PsetDefinitionAliases != null)
                                        {
                                            foreach (PsetDefinitionAlias pl in psd.PsetDefinitionAliases)
                                            {
                                                pset.RegisterLocalization(pl.lang, null, pl.Value);
                                            }
                                        }

                                        foreach (PropertyDef subdef in psd.PropertyDefs)
                                        {
                                            DocProperty docprop = pset.RegisterProperty(subdef.Name);
                                            Program.ImportPsdPropertyTemplate(subdef, docprop);
                                        }

                                        // add to Use Definition at applicable entity
                                        string[] apptypes = pset.ApplicableType.Split('/');
                                        if (this.m_mapTree.TryGetValue(apptypes[0].ToLowerInvariant(), out tn))
                                        {
                                            DocEntity entity = (DocEntity)tn.Tag;

                                            if (this.m_project.ModelViews.Count == 0)
                                            {
                                                // must have at least one model view for populating property set links
                                                this.m_project.ModelViews.Add(new DocModelView());
                                            }

                                            foreach (DocModelView docView in this.m_project.ModelViews)
                                            {
                                                DocConceptRoot docRoot = null;
                                                foreach (DocConceptRoot eachRoot in docView.ConceptRoots)
                                                {
                                                    if (eachRoot.ApplicableEntity == entity)
                                                    {
                                                        docRoot = eachRoot;
                                                        break;
                                                    }
                                                }

                                                if (docRoot == null)
                                                {
                                                    docRoot = new DocConceptRoot();
                                                    docRoot.ApplicableEntity = entity;
                                                    docView.ConceptRoots.Add(docRoot);
                                                }

                                                // find the pset template
                                                DocTemplateUsage templateuse = null;
                                                foreach (DocTemplateUsage eachtemplateuse in docRoot.Concepts)
                                                {
                                                    if (eachtemplateuse.Definition != null && eachtemplateuse.Definition.Name.StartsWith("Property"))
                                                    {
                                                        templateuse = eachtemplateuse;
                                                        break;
                                                    }
                                                }

                                                DocTemplateDefinition docdefpset = this.m_project.GetTemplate(new Guid("f74255a6-0c0e-4f31-84ad-24981db62461"));
                                                if (docdefpset != null)
                                                {
                                                    // if no template, add it
                                                    if (templateuse == null)
                                                    {
                                                        // get the pset template
                                                        templateuse = new DocTemplateUsage();
                                                        docRoot.Concepts.Add(templateuse);
                                                        templateuse.Definition = docdefpset;
                                                    }

                                                    DocTemplateItem templateitem = new DocTemplateItem();
                                                    templateuse.Items.Add(templateitem);
                                                    templateitem.RuleInstanceID = "IfcPropertySet";

                                                    if (apptypes.Length == 2)
                                                    {
                                                        templateitem.RuleParameters += "PredefinedType=" + apptypes[1] + ";";
                                                    }
                                                    templateitem.RuleParameters += "Name=" + pset.Name + ";";
                                                    templateitem.RuleParameters += "TemplateType=" + pset.PropertySetType + ";";
                                                    // don't include documentation -- too wordy templateitem.Documentation = pset.Documentation;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            sbErrors.Append(System.IO.Path.GetFileNameWithoutExtension(filename) + ": unrecognized ApplicableTypeValue; ");
                                        }
                                    }
                                    else
                                    {
                                        sbErrors.Append(System.IO.Path.GetFileNameWithoutExtension(filename) + ": unrecognized schema; ");
                                    }

                                }
                            }
                            else if (filename.Contains("Qto_"))
                            {
                                using (FormatXML format = new FormatXML(filename, typeof(QtoSetDef)))
                                {
                                    format.Load();
                                    QtoSetDef qto = (QtoSetDef)format.Instance;

                                    string schema = qto.Versions[0].schema;
                                    TreeNode tn = null;
                                    if (schema != null && this.m_mapTree.TryGetValue(schema.ToLowerInvariant(), out tn))
                                    {
                                        DocSchema docschema = (DocSchema)tn.Tag;

                                        // find existing pset if applicable
                                        DocQuantitySet qset = docschema.RegisterQset(qto.Name);

                                        // use hashed guid
                                        if (qset.Uuid == Guid.Empty)
                                        {
                                            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                                            byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(qset.Name));
                                            qset.Uuid = new Guid(hash);
                                        }

                                        // everything is currently named "Base Quantities"; get name from file instead; e.g. "Qto_Beam"
                                        qset.Name = System.IO.Path.GetFileNameWithoutExtension(filename);
                                        qset.Documentation = qto.Definition;
                                        qset.ApplicableType = qto.ApplicableClasses[0].Value;

                                        // fix: remove "Type"
                                        if (qset.ApplicableType.EndsWith("Type"))
                                        {
                                            qset.ApplicableType = qset.ApplicableType.Substring(0, qset.ApplicableType.Length - 4);
                                        }

                                        // import localized definitions
                                        if (qto.QtoDefinitionAliases != null)
                                        {
                                            foreach (QtoDefinitionAlias pl in qto.QtoDefinitionAliases)
                                            {
                                                qset.RegisterLocalization(pl.lang, null, pl.Value);
                                            }
                                        }

                                        foreach (QtoDef qtodef in qto.QtoDefs)
                                        {
                                            DocQuantity q = qset.RegisterQuantity(qtodef.Name);
                                            q.Documentation = qtodef.Definition;

                                            switch (qtodef.QtoType)
                                            {
                                                case "IfcQuantityCount":
                                                    q.QuantityType = DocQuantityTemplateTypeEnum.Q_COUNT;
                                                    break;

                                                case "IfcQuantityLength":
                                                    q.QuantityType = DocQuantityTemplateTypeEnum.Q_LENGTH;
                                                    break;

                                                case "IfcQuantityArea":
                                                    q.QuantityType = DocQuantityTemplateTypeEnum.Q_AREA;
                                                    break;

                                                case "IfcQuantityVolume":
                                                    q.QuantityType = DocQuantityTemplateTypeEnum.Q_VOLUME;
                                                    break;

                                                case "IfcQuantityWeight":
                                                    q.QuantityType = DocQuantityTemplateTypeEnum.Q_WEIGHT;
                                                    break;

                                                case "IfcQuantityTime":
                                                    q.QuantityType = DocQuantityTemplateTypeEnum.Q_TIME;
                                                    break;
                                            }

                                            foreach (NameAlias namealias in qtodef.NameAliases)
                                            {
                                                string desc = null;
                                                foreach (DefinitionAlias docalias in qtodef.DefinitionAliases)
                                                {
                                                    if (docalias.lang.Equals(namealias.lang))
                                                    {
                                                        desc = docalias.Value;
                                                        break;
                                                    }
                                                }

                                                q.RegisterLocalization(namealias.lang, namealias.Value, desc);
                                            }

                                        }

                                        // map to use definition
                                        if (this.m_mapTree.TryGetValue(qset.ApplicableType.ToLowerInvariant(), out tn))
                                        {
                                            DocEntity entity = (DocEntity)tn.Tag;

                                            if (this.m_project.ModelViews.Count == 0)
                                            {
                                                // must have at least one model view for populating property set links
                                                this.m_project.ModelViews.Add(new DocModelView());
                                            }

                                            foreach (DocModelView docView in this.m_project.ModelViews)
                                            {
                                                DocConceptRoot docRoot = null;
                                                foreach (DocConceptRoot eachRoot in docView.ConceptRoots)
                                                {
                                                    if (eachRoot.ApplicableEntity == entity)
                                                    {
                                                        docRoot = eachRoot;
                                                        break;
                                                    }
                                                }

                                                if (docRoot == null)
                                                {
                                                    docRoot = new DocConceptRoot();
                                                    docRoot.ApplicableEntity = entity;
                                                    docView.ConceptRoots.Add(docRoot);
                                                }


                                                // find the qset template                                            
                                                DocTemplateUsage templateuse = null;
                                                foreach (DocTemplateUsage eachtemplateuse in docRoot.Concepts)
                                                {
                                                    if (eachtemplateuse.Definition.Name.StartsWith("Quantity"))
                                                    {
                                                        templateuse = eachtemplateuse;
                                                        break;
                                                    }
                                                }

                                                // if no template, add it
                                                if (templateuse == null)
                                                {
                                                    // get the pset template
                                                    templateuse = new DocTemplateUsage();
                                                    docRoot.Concepts.Add(templateuse);
                                                    templateuse.Definition = this.m_project.GetTemplate(new Guid("6652398e-6579-4460-8cb4-26295acfacc7"));
                                                }

                                                if (templateuse != null)
                                                {
                                                    DocTemplateItem templateitem = new DocTemplateItem();
                                                    templateuse.Items.Add(templateitem);
                                                    templateitem.RuleInstanceID = "IfcElementQuantity";
                                                    templateitem.RuleParameters = "Name=" + qset.Name + ";TemplateType=QTO_OCCURRENCEDRIVEN;";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        sbErrors.Append(System.IO.Path.GetFileNameWithoutExtension(filename) + ": unrecognized schema; ");
                                    }
                                }
                            }
                            else if (filename.Contains("ifcXML"))
                            {
                                using(FormatXML format = new FormatXML(filename, typeof(configuration), SchemaCNF.DefaultNamespace))
                                {
                                    try
                                    {
                                        this.m_loading = true; // prevent constructors from registering instances (xml serializer instantiates)
                                        format.Load();

                                        DocModelView docView = null;
                                        using(FormSelectView form = new FormSelectView(this.m_project))
                                        {
                                            if(form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                                            {
                                                docView = form.Selection;
                                            }
                                        }

                                        configuration cnf = (configuration)format.Instance;
                                        Program.ImportCnf(cnf, this.m_project, docView);
                                    }
                                    catch (Exception xx)
                                    {
                                        MessageBox.Show(this, xx.Message, "Import CNFXML");
                                    }
                                    finally
                                    {
                                        this.m_loading = false;
                                    }
                                }
                            }
                            break;

                        case ".mvdxml":
                            {
                                for(int iNS = 0; iNS < mvdXML.Namespaces.Length; iNS++)
                                {
                                    string xmlns = mvdXML.Namespaces[iNS];
                                    using (FormatXML format = new FormatXML(filename, typeof(mvdXML), xmlns))
                                    {
                                        try
                                        {
                                            this.m_loading = true; // prevent constructors from registering instances (xml serializer instantiates)
                                            format.Load();
                                            this.m_loading = false;
                                            mvdXML mvd = (mvdXML)format.Instance;
                                            Program.ImportMvd(mvd, this.m_project, filename);
                                            break;
                                        }
                                        catch (InvalidOperationException)
                                        {
                                            // keep going until successful

                                            if(iNS == mvdXML.Namespaces.Length-1)
                                            {
                                                MessageBox.Show(this, "The file is not of a supported format (mvdXML 1.0 or mvdXML 1.1).", "Import MVDXML");
                                            }
                                        }
                                        catch (Exception xx)
                                        {
                                            MessageBox.Show(this, xx.Message, "Import MVDXML");
                                            xmlns = null;
                                        }
                                        finally
                                        {
                                            this.m_loading = false;
                                        }
                                    }
                                }
                            }
                            break;

                        case ".txt":
                            using (FormatCSV format = new FormatCSV(filename))
                            {
                                try
                                {
                                    format.Instance = this.m_project;
                                    format.Load();
                                }
                                catch (System.Exception xx)
                                {
                                    MessageBox.Show(this, xx.Message, "Import CSV");
                                }
                            }
                            break;

                        case ".ifd":
                            using (FormatIFD format = new FormatIFD(filename))
                            {
                                try
                                {
                                    format.Instance = this.m_project;
                                    format.Load();
                                }
                                catch (System.Exception xx)
                                {
                                    MessageBox.Show(this, xx.Message, "Import IFD");
                                }
                            }
                            break;
                    }

                }

                // load tree before generating use definitions
                this.LoadTree();

                // load tree again to pick up definitions
                if (importedschemas.Count > 0)
                {
                    LoadTree();
                }
            }

            if (sbErrors.Length > 0)
            {
                MessageBox.Show(this, "Import succeeded, however one or more definitions have missing or incorrect information:\r\n" + sbErrors.ToString(), "Import Errors");
            }
        }

        private void toolStripMenuItemFileUpdate_Click(object sender, EventArgs e)
        {
            DialogResult res = this.openFileDialogUpdate.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                foreach (string filename in this.openFileDialogUpdate.FileNames)
                {
                    string ext = System.IO.Path.GetExtension(filename).ToLower();
                    switch (ext)
                    {
                        case ".vex":
                            using (FormatSPF format = new FormatSPF(filename, SchemaVEX.Types, null))
                            {
                                format.Load();

                                // loop through relevent entities, update from database
                                foreach (SEntity entity in format.Instances.Values)
                                {
                                    if (entity is ENTITIES)
                                    {
                                        ENTITIES ent = (ENTITIES)entity;
                                        if (ent.comment != null && ent.comment.text != null)
                                        {
                                            // get corresponding instance in documentation database
                                            TreeNode tn = null;
                                            if (this.m_mapTree.TryGetValue(ent.name.text.ToLowerInvariant(), out tn))
                                            {
                                                DocEntity docEntity = (DocEntity)tn.Tag;

                                                ent.comment.text.text = docEntity.Documentation;

                                                // also update attributes
                                                if (ent.attributes != null)
                                                {
                                                    foreach (ATTRIBUTE_DEF attr in ent.attributes)
                                                    {
                                                        if (attr.comment != null && attr.comment.text != null)
                                                        {
                                                            foreach (DocAttribute docattr in docEntity.Attributes)
                                                            {
                                                                if (docattr.Name.Equals(attr.name.text))
                                                                {
                                                                    attr.comment.text.text = docattr.Documentation;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                // where rules
                                                if (ent.wheres != null)
                                                {
                                                    foreach (WHERE_RULE attr in ent.wheres)
                                                    {
                                                        if (attr.comment != null && attr.comment.text != null)
                                                        {
                                                            foreach (DocWhereRule docattr in docEntity.WhereRules)
                                                            {
                                                                if (docattr.Name.Equals(attr.name))
                                                                {
                                                                    attr.comment.text.text = docattr.Documentation;
                                                                    attr.rule_context = docattr.Expression; // update where rule expression
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (entity is ENUMERATIONS)
                                    {
                                        ENUMERATIONS ent = (ENUMERATIONS)entity;
                                        if (ent.comment != null && ent.comment.text != null)
                                        {
                                            TreeNode tn = null;
                                            if (this.m_mapTree.TryGetValue(ent.name.text.ToLowerInvariant(), out tn))
                                            {
                                                DocEnumeration docEntity = (DocEnumeration)tn.Tag;
                                                ent.comment.text.text = docEntity.Documentation;
                                            }

                                        }
                                    }
                                    else if (entity is DEFINED_TYPE)
                                    {
                                        DEFINED_TYPE ent = (DEFINED_TYPE)entity;
                                        if (ent.comment != null && ent.comment.text != null)
                                        {
                                            TreeNode tn = null;
                                            if (this.m_mapTree.TryGetValue(ent.name.text.ToLowerInvariant(), out tn))
                                            {
                                                DocDefined docEntity = (DocDefined)tn.Tag;
                                                ent.comment.text.text = docEntity.Documentation;
                                            }
                                        }
                                    }
                                    else if (entity is SELECTS)
                                    {
                                        SELECTS ent = (SELECTS)entity;
                                        if (ent.comment != null && ent.comment.text != null)
                                        {
                                            TreeNode tn = null;
                                            if (this.m_mapTree.TryGetValue(ent.name.text.ToLowerInvariant(), out tn))
                                            {
                                                DocSelect docEntity = (DocSelect)tn.Tag;
                                                ent.comment.text.text = docEntity.Documentation;
                                            }
                                        }
                                    }
                                    else if (entity is GLOBAL_RULE)
                                    {
                                        GLOBAL_RULE rule = (GLOBAL_RULE)entity;
                                        if (rule.comment != null && rule.comment.text != null)
                                        {
                                            TreeNode tn = null;
                                            if (this.m_mapTree.TryGetValue(rule.name.ToLowerInvariant(), out tn))
                                            {
                                                DocGlobalRule docEntity = (DocGlobalRule)tn.Tag;
                                                rule.comment.text.text = docEntity.Documentation;
                                                rule.rule_context = docEntity.Expression;
                                            }
                                        }
                                    }
                                    else if (entity is USER_FUNCTION)
                                    {
                                        USER_FUNCTION func = (USER_FUNCTION)entity;
                                        TreeNode tn = null;
                                        if (func.name != null && this.m_mapTree.TryGetValue(func.name.ToLowerInvariant(), out tn))
                                        {
                                            DocFunction docFunc = (DocFunction)tn.Tag;
                                            if (func.comment != null && func.comment.text != null)
                                            {
                                                func.comment.text.text = docFunc.Documentation;
                                            }
                                            func.rule_context = docFunc.Expression;
                                        }
                                    }
                                    else if (entity is USER_PROCEDURE)
                                    {
                                        //?? unused for IFC
                                    }
                                    else if (entity is SCHEMATA)
                                    {
                                        SCHEMATA ent = (SCHEMATA)entity;
                                        if (ent.comment != null && ent.comment.text != null)
                                        {
                                            TreeNode tn = null;
                                            if (this.m_mapTree.TryGetValue(ent.name.ToLowerInvariant(), out tn))
                                            {
                                                DocSchema docSchema = (DocSchema)tn.Tag;
                                                ent.comment.text.text = docSchema.Documentation;
                                            }
                                        }
                                    }
                                }

                                format.Save();
                            }
                            break;
                    }
                }
            }
        }

        private void toolStripMenuItemFileExport_Click(object sender, EventArgs e)
        {
            using (FormFilter formFilter = new FormFilter(this.m_project))
            {
                DialogResult res = this.saveFileDialogExport.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    DocModelView[] views = null;
                    string[] locales = null;

                    string ext = System.IO.Path.GetExtension(this.saveFileDialogExport.FileName).ToLower();
                    switch(ext)
                    {
                        case ".txt":
                            // prompt for locale
                            using (FormSelectLocale form = new FormSelectLocale())
                            {
                                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                                {
                                    locales = new string[] { form.SelectedLocale.TwoLetterISOLanguageName };
                                }
                            }
                            break;

                        default:
                            // prompt for model view
                            using (FormSelectView form = new FormSelectView(this.m_project))
                            {
                                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (form.Selection != null)
                                    {
                                        views = new DocModelView[] { form.Selection };
                                    }
                                }
                            }
                            break;
                    }

                    // swap out instances temporarily
                    Dictionary<long, SEntity> old = this.m_instances;
                    long lid = this.m_lastid;

                    this.m_instances = new Dictionary<long, SEntity>();
                    this.m_lastid = 0;

                    try
                    {
                        DocumentationISO.DoExport(this.m_project, this.saveFileDialogExport.FileName, views, locales, this.m_instances, false);
                    }
                    catch(Exception x)
                    {
                        MessageBox.Show(x.Message, "Error");
                    }
                    finally
                    {
                        this.m_instances = old;
                        this.m_lastid = lid;
                    }
                }
            }
        }

        private void toolStripMenuItemFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!PromptSave())
            {
                e.Cancel = true;
            }

            base.OnClosing(e);
        }

        #endregion
        #region EDIT

        private void InsertUsage_Click(object sender, EventArgs e)
        {
            DocConceptRoot entity = this.treeView.SelectedNode.Tag as DocConceptRoot;
            if (entity == null)
                return;

            ToolStripMenuItem ts = (ToolStripMenuItem)sender;
            DocTemplateDefinition def = (DocTemplateDefinition)ts.Tag;

            DocTemplateUsage usage = new DocTemplateUsage();
            usage.Definition = def;
            entity.Concepts.Add(usage);

            TreeNode tn = LoadNode(this.treeView.SelectedNode, usage, def.Name, false);
            this.treeView.SelectedNode = tn;

            this.m_modified = true;
        }

        /// <summary>
        /// Generates HTTP-compatible name for object
        /// </summary>
        /// <param name="docobj"></param>
        /// <returns></returns>
        private static string MakeLinkName(DocObject docobj)
        {
            if(docobj.Name == null)
                return docobj.Uuid.ToString();

            return docobj.Name.Replace(' ','-').ToLower();
        }

        private string FormatTemplateRule(DocTemplateDefinition template, string key)
        {
            foreach (DocModelRule rule in template.Rules)
            {
                string format = FormatRule(rule, key);
                if (format != null)
                {
                    return format;
                }
            }

            return null;
        }

        private string FormatRule(DocModelRule rule, string key)
        {
            string comp = null;

            if (rule.Identification == null || !rule.Identification.Equals(key))
            {
                // recurse            
                foreach (DocModelRule sub in rule.Rules)
                {
                    comp = FormatRule(sub, key);
                    if (comp != null)
                    {
                        break;
                    }
                }

                if (comp == null)
                    return null;
            }

            // generate rule if found
            if (rule is DocModelRuleAttribute)
            {
                return "." + rule.Name + comp;
            }
            else if (rule is DocModelRuleEntity)
            {
                return @"\" + rule.Name + comp;
            }

            return null;
        }


        private void toolStripMenuItemEditDelete_Click(object sender, EventArgs e)
        {
            if (!this.treeView.Focused)
                return;

            this.ctlExpressG.ScrollToSelection = false;

            if (this.treeView.SelectedNode.Tag is DocTerm)
            {
                DocTerm docTerm = (DocTerm)this.treeView.SelectedNode.Tag;
                this.m_project.Terms.Remove(docTerm);
                this.treeView.SelectedNode.Remove();
                docTerm.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocAbbreviation)
            {
                DocAbbreviation docTerm = (DocAbbreviation)this.treeView.SelectedNode.Tag;
                this.m_project.Abbreviations.Remove(docTerm);
                this.treeView.SelectedNode.Remove();
                docTerm.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocTemplateItem)
            {
                DocTemplateItem item = (DocTemplateItem)this.treeView.SelectedNode.Tag;
                DocTemplateUsage usage = (DocTemplateUsage)this.treeView.SelectedNode.Parent.Tag;
                usage.Items.Remove(item);
                this.treeView.SelectedNode.Remove();
                item.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocConceptRoot)
            {
                DocConceptRoot conceptroot = (DocConceptRoot)this.treeView.SelectedNode.Tag;

                // find the model view
                foreach (DocModelView docView in this.m_project.ModelViews)
                {
                    if (docView.ConceptRoots != null && docView.ConceptRoots.Contains(conceptroot))
                    {
                        docView.ConceptRoots.Remove(conceptroot);
                        break;
                    }
                }

                this.treeView.SelectedNode.Remove();
                conceptroot.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocTemplateUsage)
            {
                DocTemplateUsage usage = (DocTemplateUsage)this.treeView.SelectedNode.Tag;
                DocConceptRoot entity = (DocConceptRoot)this.treeView.SelectedNode.Parent.Tag;
                entity.Concepts.Remove(usage);
                this.treeView.SelectedNode.Remove();
                usage.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocTemplateDefinition)
            {
                DocTemplateDefinition target = (DocTemplateDefinition)this.treeView.SelectedNode.Tag;
                DocTemplateDefinition parent = this.treeView.SelectedNode.Parent.Tag as DocTemplateDefinition;
                if (parent != null)
                {
                    parent.Templates.Remove(target);
                }
                else
                {
                    this.m_project.Templates.Remove(target);
                }
                this.treeView.SelectedNode.Remove();

                // delete all usage of template
                foreach (DocModelView docView in this.m_project.ModelViews)
                {
                    foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                    {
                        for (int i = docRoot.Concepts.Count - 1; i >= 0; i--)
                        {
                            DocTemplateUsage docUsage = docRoot.Concepts[i];
                            if (docUsage.Definition == target)
                            {
                                docRoot.Concepts.RemoveAt(i);
                                docUsage.Delete();
                            }
                        }
                    }
                }

                // delete referencing of template from examples
                if (this.m_project.Examples != null)
                {
                    foreach(DocExample docExample in this.m_project.Examples)
                    {
                        Dereference(docExample, target);
                    }
                }

                target.Delete();

                // refresh tree to remove referenced concept leafs
                this.LoadTree();
            }
            else if (this.treeView.SelectedNode.Tag is DocModelView)
            {
                DocModelView target = (DocModelView)this.treeView.SelectedNode.Tag;
                this.m_project.ModelViews.Remove(target);
                this.treeView.SelectedNode.Remove();
                target.Delete();

                // delete referencing of view from examples
                if (this.m_project.Examples != null)
                {
                    foreach (DocExample docExample in this.m_project.Examples)
                    {
                        Dereference(docExample, target);
                    }
                }

                // refresh tree to remove referenced concept roots
                this.LoadTree();
            }
            else if (this.treeView.SelectedNode.Tag is DocExchangeDefinition)
            {
                DocExchangeDefinition target = (DocExchangeDefinition)this.treeView.SelectedNode.Tag;
                DocModelView docView = (DocModelView)this.treeView.SelectedNode.Parent.Tag;
                docView.Exchanges.Remove(target);
                this.treeView.SelectedNode.Remove();

                // delete referenced exchange uses                    
                foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                {
                    foreach (DocTemplateUsage docUsage in docRoot.Concepts)
                    {
                        for (int i = docUsage.Exchanges.Count - 1; i >= 0; i--)
                        {
                            DocExchangeItem docItem = docUsage.Exchanges[i];
                            if (docItem.Exchange == target)
                            {
                                docUsage.Exchanges.RemoveAt(i);
                                docItem.Delete();
                            }
                        }
                    }
                }

                target.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocChangeSet)
            {
                DocChangeSet changeset = (DocChangeSet)this.treeView.SelectedNode.Tag;
                this.m_project.ChangeSets.Remove(changeset);
                this.treeView.SelectedNode.Remove();
                changeset.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocPropertySet)
            {
                DocPropertySet docTarget = (DocPropertySet)this.treeView.SelectedNode.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Tag;
                docSchema.PropertySets.Remove(docTarget);
                this.treeView.SelectedNode.Remove();
                docTarget.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocProperty)
            {
                DocProperty docTarget = (DocProperty)this.treeView.SelectedNode.Tag;
                DocPropertySet docPset = (DocPropertySet)this.treeView.SelectedNode.Parent.Tag;
                docPset.Properties.Remove(docTarget);
                this.treeView.SelectedNode.Remove();
                docTarget.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocQuantitySet)
            {
                DocQuantitySet docTarget = (DocQuantitySet)this.treeView.SelectedNode.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Tag;
                docSchema.QuantitySets.Remove(docTarget);
                this.treeView.SelectedNode.Remove();
                docTarget.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocQuantity)
            {
                DocQuantity docTarget = (DocQuantity)this.treeView.SelectedNode.Tag;
                DocQuantitySet docPset = (DocQuantitySet)this.treeView.SelectedNode.Parent.Tag;
                docPset.Quantities.Remove(docTarget);
                this.treeView.SelectedNode.Remove();
                docTarget.Delete();
            }
            else if(this.treeView.SelectedNode.Tag is DocSchema)
            {
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Tag;
                DocSection docSection = (DocSection)this.treeView.SelectedNode.Parent.Tag;
                docSection.Schemas.Remove(docSchema);
                this.treeView.SelectedNode.Remove();
                docSchema.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocEntity)
            {
                DocEntity docTarget = (DocEntity)this.treeView.SelectedNode.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Tag;
                docSchema.Entities.Remove(docTarget);
                docTarget.Delete();
                DeleteReferencesForSchemaDefinition(docSchema, docTarget);
                DeleteReferencesForDefinition(docTarget.Name);

                //this.treeView.SelectedNode.Remove();
            }
            else if(this.treeView.SelectedNode.Tag is DocAttribute)
            {
                DocEntity docEntity = (DocEntity)this.treeView.SelectedNode.Parent.Tag;
                DocAttribute docAttr = (DocAttribute)this.treeView.SelectedNode.Tag;
                docEntity.Attributes.Remove(docAttr);
                docAttr.Delete();
                DeleteReferencesForAttribute(docEntity.Name, docAttr.Name);
                
                //this.treeView.SelectedNode.Remove();
            }
            else if (this.treeView.SelectedNode.Tag is DocUniqueRule)
            {
                DocEntity docEntity = (DocEntity)this.treeView.SelectedNode.Parent.Tag;
                DocUniqueRule docAttr = (DocUniqueRule)this.treeView.SelectedNode.Tag;
                docEntity.UniqueRules.Remove(docAttr);
                this.treeView.SelectedNode.Remove();
                docAttr.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocWhereRule)
            {
                DocEntity docEntity = (DocEntity)this.treeView.SelectedNode.Parent.Tag;
                DocWhereRule docAttr = (DocWhereRule)this.treeView.SelectedNode.Tag;
                docEntity.WhereRules.Remove(docAttr);
                this.treeView.SelectedNode.Remove();
                docAttr.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocType)
            {
                DocType docTarget = (DocType)this.treeView.SelectedNode.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Tag;
                docSchema.Types.Remove(docTarget);
                docTarget.Delete();
                DeleteReferencesForSchemaDefinition(docSchema, docTarget);
                DeleteReferencesForDefinition(docTarget.Name);
            }
            else if(this.treeView.SelectedNode.Tag is DocConstant)
            {
                DocConstant docTarget = (DocConstant)this.treeView.SelectedNode.Tag;
                DocEnumeration docEnum = (DocEnumeration)this.treeView.SelectedNode.Parent.Tag;
                docEnum.Constants.Remove(docTarget);
                this.treeView.SelectedNode.Remove();
                docTarget.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocGlobalRule)
            {
                DocGlobalRule docTarget = (DocGlobalRule)this.treeView.SelectedNode.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Tag;
                docSchema.GlobalRules.Remove(docTarget);
                this.treeView.SelectedNode.Remove();
                docTarget.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocFunction)
            {
                DocFunction docTarget = (DocFunction)this.treeView.SelectedNode.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Tag;
                docSchema.Functions.Remove(docTarget);
                this.treeView.SelectedNode.Remove();
                docTarget.Delete();
            }
            else if (this.treeView.SelectedNode.Tag is DocExample)
            {
                DocExample docExample = (DocExample)this.treeView.SelectedNode.Tag;
                DocExample parent = this.treeView.SelectedNode.Parent.Tag as DocExample;

                if (parent != null)
                {
                    parent.Examples.Remove(docExample);
                }
                else
                {
                    this.m_project.Examples.Remove(docExample);
                }
                this.treeView.SelectedNode.Remove();
                docExample.Delete();
            }
            else if(this.treeView.SelectedNode.Tag is DocComment)
            {
                DocComment docComment = (DocComment)this.treeView.SelectedNode.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Tag;
                docSchema.Comments.Remove(docComment);
                this.treeView.SelectedNode.Remove();
                docComment.Delete();
            }
            else if(this.treeView.SelectedNode.Tag is DocPrimitive)
            {
                DocPrimitive docPrimitive = (DocPrimitive)this.treeView.SelectedNode.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Tag;
                docSchema.Primitives.Remove(docPrimitive);
                this.treeView.SelectedNode.Remove();
                docPrimitive.Delete();

                DeleteReferencesForSchemaDefinition(docSchema, docPrimitive);
                UpdateTreeDeletion();
                this.ctlExpressG.Redraw(); 
            }
            else if(this.treeView.SelectedNode.Tag is DocPageTarget)
            {
                DocPageTarget docPageTarget = (DocPageTarget)this.treeView.SelectedNode.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Tag;
                docSchema.PageTargets.Remove(docPageTarget);
                this.treeView.SelectedNode.Remove();
                docPageTarget.Delete();

                foreach(DocPageSource docPageSource in docPageTarget.Sources)
                {
                    DeleteReferencesForSchemaDefinition(docSchema, docPageSource);
                }
                UpdateTreeDeletion();
                this.ctlExpressG.Redraw(); 
            }
            else if (this.treeView.SelectedNode.Tag is DocPageSource)
            {
                DocPageSource docPageSource = (DocPageSource)this.treeView.SelectedNode.Tag;
                DocPageTarget docPageTarget = (DocPageTarget)this.treeView.SelectedNode.Parent.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Parent.Tag;
                docPageTarget.Sources.Remove(docPageSource);
                this.treeView.SelectedNode.Remove();
                docPageSource.Delete();

                DeleteReferencesForSchemaDefinition(docSchema, docPageSource);
                UpdateTreeDeletion();
                this.ctlExpressG.Redraw();
            }
            else if (this.treeView.SelectedNode.Tag is DocDefinitionRef)
            {
                DocDefinitionRef docDefRef = (DocDefinitionRef)this.treeView.SelectedNode.Tag;
                DocSchemaRef docSchemaRef = (DocSchemaRef)this.treeView.SelectedNode.Parent.Tag;
                DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Parent.Parent.Parent.Tag;
                docSchemaRef.Definitions.Remove(docDefRef);
                this.treeView.SelectedNode.Remove();
                docDefRef.Delete();

                DeleteReferencesForSchemaDefinition(docSchema, docDefRef);
                UpdateTreeDeletion();
                this.ctlExpressG.Redraw();
            }

            this.ctlExpressG.ScrollToSelection = true;
        }

        #endregion

        private void DeleteReferencesForSchemaDefinition(DocSchema docSchema, DocDefinition docDef)
        {
            // delete attribute(s) referencing the definition
            foreach (DocEntity docEnt in docSchema.Entities)
            {
                for (int iAttr = docEnt.Attributes.Count - 1; iAttr >= 0; iAttr--)
                {
                    DocAttribute docAttr = docEnt.Attributes[iAttr];
                    if (docAttr.Definition == docDef)
                    {
                        docAttr.Delete();
                        docEnt.Attributes.RemoveAt(iAttr);
                    }
                }
            }

            for(int iType = docSchema.Types.Count-1; iType >= 0; iType--)
            {
                DocType docType = docSchema.Types[iType];
                if (docType is DocDefined)
                {
                    DocDefined docDefined = (DocDefined)docType;
                    if (docDefined.Definition == docDef)
                    {
                        docDefined.Delete();
                        docSchema.Types.RemoveAt(iType);
                    }
                }
            }

            // delete page refs referencing the definition
            for (int iPage = docSchema.PageTargets.Count - 1; iPage >= 0; iPage--)
            {
                DocPageTarget docPageTarget = docSchema.PageTargets[iPage];
                if(docPageTarget.Definition == docDef)
                {
                    // cascade deletion of sources
                    foreach(DocPageSource docPageSource in docPageTarget.Sources)
                    {
                        DeleteReferencesForSchemaDefinition(docSchema, docPageSource);
                    }

                    docPageTarget.Delete();
                    docSchema.PageTargets.RemoveAt(iPage);
                }
            }

            this.ctlExpressG.Schema = docSchema; // redraw
        }

        /// <summary>
        /// Scans all data definitions and deletes any dependencies on the specified definition.
        /// </summary>
        /// <param name="definition">Required name of definition (entity, select, enumeration, defined-type)</param>
        private void DeleteReferencesForDefinition(string definition)
        {
            foreach (DocSection docSection in this.m_project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocType docType in docSchema.Types)
                    {
                        if (docType is DocSelect)
                        {
                            DocSelect docSel = (DocSelect)docType;
                            foreach (DocSelectItem docItem in docSel.Selects)
                            {
                                if (docItem.Name == definition)
                                {
                                    docSel.Selects.Remove(docItem);
                                    docItem.Delete();

                                    // delete any lines as well...
                                    break;
                                }
                            }
                        }
                    }

                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        if (docEntity.BaseDefinition == definition)
                        {
                            docEntity.BaseDefinition = null;
                        }

                        foreach (DocSubtype docSub in docEntity.Subtypes)
                        {
                            if (docSub.DefinedType == definition)
                            {
                                docEntity.Subtypes.Remove(docSub);
                                docSub.Delete();
                                break;
                            }
                        }

                        //... delete lines...

                        for (int iAttr = docEntity.Attributes.Count - 1; iAttr >= 0; iAttr--)
                        {
                            DocAttribute docAttr = docEntity.Attributes[iAttr];
                            if (docAttr.DefinedType == definition)
                            {
                                docAttr.Delete();
                                docEntity.Attributes.RemoveAt(iAttr);
                            }
                        }
                    }

                    foreach (DocPageTarget docPageTarget in docSchema.PageTargets)
                    {
                        //...check if target matches...if(docPageTarget.)
                    }

                    foreach (DocSchemaRef docSchemaRef in docSchema.SchemaRefs)
                    {
                        foreach (DocDefinitionRef docDefRef in docSchemaRef.Definitions)
                        {
                            // delete lines...
#if false
                            foreach(DocSubtype docSub in docDefRef.Subtypes)
                            {
                                foreach(DocSubtype docSubSub in docSub.Subtypes)
                                {
                                    foreach(DocSubtype docSubSubSub in docSubSub.Subtypes)
                                    {
                                        if(docSubSubSub.DefinedType == definition)
                                        {
                                            docSubSubSub.Delete();
                                            docSubSub.Subtypes.Remove(docSubSubSub);
                                            break;
                                        }
                                    }

                                    if (docSubSub.DefinedType == definition)
                                    {
                                        docSubSub.Delete();
                                        docSub.Subtypes.Remove(docSubSub);
                                        break;
                                    }
                                }

                                if (docSub.DefinedType == definition)
                                {
                                    docSub.Delete();
                                    docDefRef.Subtypes.Remove(docSub);
                                    break;
                                }
                            }
#endif

                            if (docDefRef.Name == definition)
                            {
                                docDefRef.Delete();
                                docSchemaRef.Definitions.Remove(docDefRef);
                            }
                            break;
                        }
                    }
                }
            }

            this.UpdateTreeDeletion();
        }

        /// <summary>
        /// Scans all data definitions and deletes any dependencies on the specified attribute.
        /// </summary>
        /// <param name="definition">Required name of entity</param>
        /// <param name="attribute">Required name of attribute</param>
        private void DeleteReferencesForAttribute(string definition, string attribute)
        {
            foreach (DocSection docSection in this.m_project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        for (int iAttr = docEntity.Attributes.Count - 1; iAttr >= 0; iAttr--)
                        {
                            DocAttribute docAttr = docEntity.Attributes[iAttr];
                            if (docAttr.Inverse == attribute && docAttr.DefinedType == definition)
                            {
                                docAttr.Delete();
                                docEntity.Attributes.RemoveAt(iAttr);
                            }
                        }
                    }
                }
            }

            this.UpdateTreeDeletion();
        }

        /// <summary>
        /// Clears out any deleted items from tree
        /// </summary>
        private void UpdateTreeDeletion()
        {
            this.UpdateTreeDeletionNode(this.treeView.Nodes);
        }

        private void UpdateTreeDeletionNode(TreeNodeCollection col)
        {
            bool recurse = true;
            for(int iNode = col.Count - 1; iNode >= 0; iNode--)
            {
                TreeNode tn = col[iNode];
                if (tn.Tag is SRecord)
                {
                    SRecord record = (SRecord)tn.Tag;
                    if (record.OID == -1)
                    {
                        tn.Remove();
                        recurse = false;
                    }
                }

                if (recurse)
                {
                    UpdateTreeDeletionNode(tn.Nodes);
                }
            }
        }

        private static void Dereference(DocExample docExample, DocTemplateDefinition docTemplate)
        {
            if (docExample.ApplicableTemplates != null && docExample.ApplicableTemplates.Contains(docTemplate))
            {
                docExample.ApplicableTemplates.Remove(docTemplate);
            }

            if (docExample.Examples != null)
            {
                foreach (DocExample docSub in docExample.Examples)
                {
                    Dereference(docSub, docTemplate);
                }
            }
        }

        private static void Dereference(DocExample docExample, DocModelView docModelView)
        {
            if (docExample.ModelView == docModelView)
            {
                docExample.ModelView = null;
            }

            if (docExample.Examples != null)
            {
                foreach (DocExample docSub in docExample.Examples)
                {
                    Dereference(docSub, docModelView);
                }
            }
        }

        #region TOOL

        private void BuildMaps(Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema)
        {
            foreach (SEntity entity in this.m_instances.Values)
            {
                if (entity is DocTemplateDefinition)
                {
                    // new in 4.5
                    DocTemplateDefinition docTemplate = (DocTemplateDefinition)entity;
                    if (docTemplate.Name != null && !mapEntity.ContainsKey(docTemplate.Name))
                    {
                        // TBD: "Body Geometry" occurs multiple times
                        mapEntity.Add(docTemplate.Name, docTemplate);
                    }
                }
                else if (entity is DocEntity)
                {
                    DocEntity docEntity = (DocEntity)entity;
                    if (docEntity.Name != null)
                    {
                        mapEntity.Add(docEntity.Name, docEntity);
                    }
                }
                else if (entity is DocType)
                {
                    DocType docType = (DocType)entity;
                    if (!mapEntity.ContainsKey(docType.Name))
                    {
                        mapEntity.Add(docType.Name, docType);
                    }
                }
                else if (entity is DocFunction)
                {
                    DocFunction docFunc = (DocFunction)entity;
                    if (!mapEntity.ContainsKey(docFunc.Name))
                    {

                        mapEntity.Add(docFunc.Name, docFunc);
                    }
                }
                else if (entity is DocGlobalRule)
                {
                    DocGlobalRule docFunc = (DocGlobalRule)entity;
                    mapEntity.Add(docFunc.Name, docFunc);
                }
                else if (entity is DocPropertySet)
                {
                    DocPropertySet docFunc = (DocPropertySet)entity;
                    mapEntity.Add(docFunc.Name, docFunc);
                }
                else if(entity is DocPropertyEnumeration)
                {
                    DocPropertyEnumeration docEnum = (DocPropertyEnumeration)entity;
                    mapEntity.Add(docEnum.Name, docEnum);
                }
                else if (entity is DocQuantitySet)
                {
                    DocQuantitySet docFunc = (DocQuantitySet)entity;
                    mapEntity.Add(docFunc.Name, docFunc);
                }
                else if (entity is DocSchema)
                {
                    DocSchema docSchema = (DocSchema)entity;
                    foreach (DocEntity def in docSchema.Entities)
                    {
                        if (def.Name != null)
                        {
                            mapSchema.Add(def.Name, docSchema.Name);
                        }
                    }
                    foreach (DocType def in docSchema.Types)
                    {
                        // bug in vex file: IfcNullStyle included twice (?)
                        if (!mapSchema.ContainsKey(def.Name))
                        {
                            mapSchema.Add(def.Name, docSchema.Name);
                        }
                    }
                    foreach (DocFunction def in docSchema.Functions)
                    {
                        // e.g. IfcDotProduct defined in multiple schemas!!!
                        if (!mapSchema.ContainsKey(def.Name))
                        {
                            mapSchema.Add(def.Name, docSchema.Name);
                        }
                    }
                    foreach (DocGlobalRule def in docSchema.GlobalRules)
                    {
                        mapSchema.Add(def.Name, docSchema.Name);
                    }
                    foreach (DocPropertySet def in docSchema.PropertySets)
                    {
                        mapSchema.Add(def.Name, docSchema.Name);
                    }
                    foreach (DocPropertyEnumeration def in docSchema.PropertyEnums)
                    {
                        mapSchema.Add(def.Name, docSchema.Name);
                    }
                    foreach (DocQuantitySet def in docSchema.QuantitySets)
                    {
                        mapSchema.Add(def.Name, docSchema.Name);
                    }
                }
            }
        }

        private void toolStripMenuItemToolsISO_Click(object sender, EventArgs e)
        {
            using (FormGenerate form = new FormGenerate())
            {
                form.Project = this.m_project;
                form.Views = this.m_filterviews;
                form.Locales = this.m_filterlocales;
                DialogResult res = form.ShowDialog(this);
                if (res != DialogResult.OK)
                    return;

                this.m_filterviews = form.Views;
                this.m_filterlocales = form.Locales;
            }

            this.GenerateDocumentation();
        }

        private void GenerateDocumentation()
        {
            using (this.m_formProgress = new FormProgress())
            {
                this.m_exception = null;
                this.m_formProgress.Text = "Generating Documentation";
                this.m_formProgress.Description = "Generating documentation...";
                this.backgroundWorkerGenerate.RunWorkerAsync();

                DialogResult res = this.m_formProgress.ShowDialog();
                if (res != DialogResult.OK)
                {
                    this.backgroundWorkerGenerate.CancelAsync();
                }
            }

            if (this.m_exception != null)
            {
                MessageBox.Show(this, this.m_exception.Message + "\r\n\r\n" + this.m_exception.StackTrace, "Error");
                this.m_exception = null;
            }
        }

        #endregion
        #region TREE

        /// <summary>
        /// Loads object into tree
        /// </summary>
        /// <param name="parent">The parent tree node</param>
        /// <param name="tag">Object corresponding to tree node</param>
        /// <param name="text">Text to display, or NULL to auto-generate and set if tag is a DocObject</param>
        /// <param name="unique">Indicates item must have unique name and to auto-generate if null.</param>
        /// <returns>The newly created tree node.</returns>
        private TreeNode LoadNode(TreeNode parent, object tag, string text, bool unique)
        {
            TreeNode tn = new TreeNode();
            tn.Tag = tag;

            // use text if provided, or else auto-generate based on type
            if (text == null && unique && tag is DocObject)
            {
                DocObject docObject = (DocObject)tag;

                string proposedname = null;
                int proposednumber = 0;
                bool nameavailable = false;
                while (!nameavailable)
                {
                    proposednumber++;
                    proposedname = docObject.GetType().Name.Substring(3) + proposednumber.ToString();
                    nameavailable = !this.m_mapTree.ContainsKey(proposedname.ToLowerInvariant());
                }

                docObject.Name = proposedname;
                text = proposedname;
            }

            tn.Text = text;
            if (unique)
            {
                if(this.m_mapTree.ContainsKey(text.ToLowerInvariant()))
                {
                    System.Diagnostics.Debug.WriteLine("Duplicate item: " + text);
                }
                else
                {
                    this.m_mapTree.Add(text.ToLowerInvariant(), tn);
                }
            }

            // lookup image
            if (tag != null)
            {
                for (int i = 0; i < s_imagemap.Length; i++)
                {
                    Type t = s_imagemap[i];
                    if (t != null && t.IsInstanceOfType(tag))
                    {
                        tn.ImageIndex = i;
                        tn.SelectedImageIndex = i;
                        break;
                    }
                }

#if false // no longer shown
                if (tag is DocObject)
                {
                    DocObject obj = (DocObject)tag;
                    if (!obj.Visible)
                    {
                        tn.ForeColor = Color.Gray;
                    }
                }
#endif
            }

            if (parent != null)
            {
                if (parent.ForeColor == Color.Gray)
                {
                    tn.ForeColor = parent.ForeColor; // inherit visibility
                }

                parent.Nodes.Add(tn);
            }
            else
            {
                this.treeView.Nodes.Add(tn);
            }

            return tn;
        }

        private void LoadNodeSchema(TreeNode tnSchema, DocSchema schema)
        {
            TreeNode tnTypeHeader = LoadNode(tnSchema, typeof(DocType), "Types", false);
            foreach (DocType type in schema.Types)
            {
                TreeNode tnType = LoadNode(tnTypeHeader, type, type.Name, true);
                if (type is DocEnumeration)
                {
                    DocEnumeration enumeration = (DocEnumeration)type;
                    foreach (DocConstant constant in enumeration.Constants)
                    {
                        LoadNode(tnType, constant, constant.Name, false);
                    }
                }
                else if (type is DocSelect)
                {
                    DocSelect select = (DocSelect)type;
                    foreach (DocSelectItem selitem in select.Selects)
                    {
                        LoadNode(tnType, selitem, selitem.Name, false);
                    }
                }
            }

            TreeNode tnEntityHeader = LoadNode(tnSchema, typeof(DocEntity), "Entities", false);
            foreach (DocEntity type in schema.Entities)
            {
                TreeNode tnType = LoadNode(tnEntityHeader, type, type.Name, true);

                string key = type.Name.ToLowerInvariant();

                foreach (DocAttribute attr in type.Attributes)
                {
                    TreeNode tnAttribute = LoadNode(tnType, attr, attr.Name, false);
                    if (!String.IsNullOrEmpty(attr.Inverse))
                    {
                        tnAttribute.ImageIndex = ImageIndexAttributeInverse;
                        tnAttribute.SelectedImageIndex = ImageIndexAttributeInverse;
                    }
                }

                foreach (DocWhereRule wr in type.WhereRules)
                {
                    LoadNode(tnType, wr, wr.Name, false);
                }

                foreach (DocUniqueRule ur in type.UniqueRules)
                {
                    LoadNode(tnType, ur, ur.Name, false);
                }

                // new style templates
                foreach (DocModelView docModelView in this.m_project.ModelViews)
                {
                    if (docModelView.ConceptRoots != null)
                    {
                        foreach (DocConceptRoot docConceptRoot in docModelView.ConceptRoots)
                        {
                            if (docConceptRoot.ApplicableEntity == type)
                            {
                                TreeNode tnConceptRoot = LoadNode(tnType, docConceptRoot, docModelView.Name, false);
                                foreach (DocTemplateUsage docConcept in docConceptRoot.Concepts)
                                {
                                    LoadNode(tnConceptRoot, docConcept, docConcept.Definition != null ? docConcept.Definition.Name : docConcept.Name, false);
                                }
                            }
                        }
                    }
                }
            }

            TreeNode tnGlobHeader = LoadNode(tnSchema, typeof(DocGlobalRule), "Global Rules", false);
            if (schema.GlobalRules.Count > 0)
            {
                foreach (DocGlobalRule func in schema.GlobalRules)
                {
                    LoadNode(tnGlobHeader, func, func.Name, true);
                }
            }

            TreeNode tnFuncHeader = LoadNode(tnSchema, typeof(DocFunction), "Functions", false);
            if (schema.Functions.Count > 0)
            {
                foreach (DocFunction func in schema.Functions)
                {
                    LoadNode(tnFuncHeader, func, func.Name, true);
                }
            }

            TreeNode tnPsetHeader = LoadNode(tnSchema, typeof(DocPropertySet), "Property Sets", false);
            foreach (DocPropertySet pset in schema.PropertySets)
            {
                TreeNode tnPset = LoadNode(tnPsetHeader, pset, pset.Name, true);
                foreach (DocProperty docprop in pset.Properties)
                {
                    TreeNode tnProp = LoadNode(tnPset, docprop, docprop.Name, false);

                    // complex properties
                    foreach (DocProperty docpropelem in docprop.Elements)
                    {
                        LoadNode(tnProp, docpropelem, docpropelem.Name, false);
                    }
                }
            }
            foreach (DocPropertyEnumeration en in schema.PropertyEnums)
            {
                TreeNode tnEnum = LoadNode(tnPsetHeader, en, en.Name, true);
                foreach (DocPropertyConstant docconst in en.Constants)
                {
                    LoadNode(tnEnum, docconst, docconst.Name, false);
                }
            }

            TreeNode tnQsetHeader = LoadNode(tnSchema, typeof(DocQuantitySet), "Quantity Sets", false);
            if (schema.QuantitySets.Count > 0)
            {
                foreach (DocQuantitySet qset in schema.QuantitySets)
                {
                    TreeNode tnQset = LoadNode(tnQsetHeader, qset, qset.Name, true);
                    foreach (DocQuantity docprop in qset.Quantities)
                    {
                        LoadNode(tnQset, docprop, docprop.Name, false);
                    }
                }
            }

            TreeNode tnGraphicsHeader = LoadNode(tnSchema, typeof(DocSchemaRef), "Schema References", false);
            foreach (DocSchemaRef docItem in schema.SchemaRefs)
            {
                TreeNode tnTarget = LoadNode(tnGraphicsHeader, docItem, docItem.Name, false);
                foreach (DocDefinitionRef docSource in docItem.Definitions)
                {
                    LoadNode(tnTarget, docSource, docSource.Name, false);
                }
            }
            tnGraphicsHeader = LoadNode(tnSchema, typeof(DocPageTarget), "Page References", false);
            foreach (DocPageTarget docItem in schema.PageTargets)
            {
                TreeNode tnTarget = LoadNode(tnGraphicsHeader, docItem, docItem.Name, false);
                foreach (DocPageSource docSource in docItem.Sources)
                {
                    LoadNode(tnTarget, docSource, docSource.Name, false);
                }
            }
            tnGraphicsHeader = LoadNode(tnSchema, typeof(DocPrimitive), "Primitive References", false);
            foreach (DocPrimitive docItem in schema.Primitives)
            {
                LoadNode(tnGraphicsHeader, docItem, docItem.Name, false);
            }
            tnGraphicsHeader = LoadNode(tnSchema, typeof(DocComment), "Comments", false);
            foreach (DocComment docItem in schema.Comments)
            {
                LoadNode(tnGraphicsHeader, docItem, docItem.Name, false);
            }
        }

        private void LoadTree()
        {
            this.treeView.Nodes.Clear();
            this.m_mapTree.Clear();

            if (this.m_project == null)
                return;

            // now populate tree
            foreach (DocSection section in this.m_project.Sections)
            {
                TreeNode tn = LoadNode(null, section, section.Name, false);

                if (this.m_project.Sections.IndexOf(section) == 0)
                {
                    // model views
                    if (this.m_project.ModelViews != null)
                    {
                        foreach (DocModelView docModel in this.m_project.ModelViews)
                        {
                            TreeNode tnModel = LoadNode(tn, docModel, docModel.Name, true);
                            foreach (DocExchangeDefinition docExchange in docModel.Exchanges)
                            {
                                LoadNode(tnModel, docExchange, docExchange.Name, false);
                            }
                        }
                    }
                }

                if (this.m_project.Sections.IndexOf(section)== 1)
                {
                    if(this.m_project.NormativeReferences != null)
                    {
                        foreach(DocReference docRef in this.m_project.NormativeReferences)
                        {
                            LoadNode(tn, docRef, docRef.Name, true);
                        }
                    }
                }

                if (this.m_project.Sections.IndexOf(section) == 2)
                {
                    //TreeNode tnTerms = LoadNode(tn, typeof(DocTerm), "Terms");
                    if (this.m_project.Terms != null)
                    {
                        foreach (DocTerm docTerm in this.m_project.Terms)
                        {
                            LoadNode(tn, docTerm, docTerm.Name, true);
                        }
                    }

                    //TreeNode tnAbbrev = LoadNode(tn, typeof(DocAbbreviation), "Abbreviations");
                    if (this.m_project.Abbreviations != null)
                    {
                        foreach (DocAbbreviation docTerm in this.m_project.Abbreviations)
                        {
                            LoadNode(tn, docTerm, docTerm.Name, true);
                        }
                    }
                }

                // special case for section 4 -- show templates and views
                if (this.m_project.Sections.IndexOf(section) == 3)
                {
                    // templates
                    if (this.m_project.Templates != null && this.m_project.Templates.Count > 0)
                    {
                        foreach (DocTemplateDefinition docTemplate in this.m_project.Templates)
                        {
                            LoadTreeTemplate(tn, docTemplate);
                        }
                    }
                }

#if false
                foreach (DocAnnotation annot in section.Annotations)
                {
                    TreeNode tnView = LoadNode(tn, annot, annot.Name);
                    foreach (DocAnnotation aroot in annot.Annotations)
                    {
                        TreeNode tnRoot = LoadNode(tnView, aroot, aroot.Name);
                        foreach (DocAnnotation anode in aroot.Annotations)
                        {
                            TreeNode tnNode = LoadNode(tnRoot, anode, anode.Name);
                            foreach (DocAnnotation aleaf in anode.Annotations)
                            {
                                LoadNode(tnNode, aleaf, aleaf.Name);
                            }
                        }
                    }
                }
#endif

                foreach (DocSchema schema in section.Schemas)
                {
                    TreeNode tnSchema = LoadNode(tn, schema, schema.Name, true);
                    LoadNodeSchema(tnSchema, schema);
                }
            }

            foreach (DocAnnex annex in this.m_project.Annexes)
            {
                TreeNode tn = LoadNode(null, annex, annex.Name, false);

                if (this.m_project.Annexes.IndexOf(annex) == 4 && this.m_project.Examples != null)
                {
                    // special case for examples
                    foreach (DocExample docExample in this.m_project.Examples)
                    {
                        TreeNode tnEx = LoadNode(tn, docExample, docExample.Name, true);
                        if (docExample.Examples != null)
                        {
                            foreach (DocExample docSub in docExample.Examples)
                            {
                                LoadTreeExample(tnEx, docSub);
                            }
                        }
                    }
                }

                if (this.m_project.Annexes.IndexOf(annex) == 5 && this.m_project.ChangeSets != null)
                {
                    // special case for change logs
                    foreach (DocChangeSet docChangeSet in this.m_project.ChangeSets)
                    {
                        TreeNode tnSet = LoadNode(tn, docChangeSet, docChangeSet.Name, true);
                        foreach (DocChangeAction docChangeItem in docChangeSet.ChangesEntities)
                        {
                            LoadTreeChange(tnSet, docChangeItem);
                        }
                    }
                }

            }

            // force update of main pain
            if (this.treeView.Nodes.Count > 0)
            {
                this.treeView.SelectedNode = this.treeView.Nodes[0];
            }
        }

        private void LoadTreeExample(TreeNode tnParent, DocExample docExample)
        {
            TreeNode tnChange = LoadNode(tnParent, docExample, docExample.Name, true);

            if (docExample.Examples != null)
            {
                foreach (DocExample docSub in docExample.Examples)
                {
                    LoadTreeExample(tnChange, docSub);
                }
            }
        }

        private void LoadTreeChange(TreeNode tnParent, DocChangeAction docChange)
        {
            TreeNode tnChange = LoadNode(tnParent, docChange, docChange.Name, false);

            if (docChange.Changes != null)
            {
                foreach (DocChangeAction docSub in docChange.Changes)
                {
                    LoadTreeChange(tnChange, docSub);
                }
            }
        }

        private void LoadTreeTemplate(TreeNode tnParent, DocTemplateDefinition docTemplate)
        {
            TreeNode tnTemplate = LoadNode(tnParent, docTemplate, docTemplate.Name, true);

            if (docTemplate.Templates != null)
            {
                foreach (DocTemplateDefinition docSub in docTemplate.Templates)
                {
                    LoadTreeTemplate(tnTemplate, docSub);
                }
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.toolStripMenuItemEditDelete.Enabled = false;
            this.toolStripMenuItemEditRename.Enabled = false;
            this.toolStripMenuItemEditProperties.Enabled = false;
            this.toolStripMenuItemEditMoveDown.Enabled = false;
            this.toolStripMenuItemEditMoveUp.Enabled = false;
            this.toolStripMenuItemEditMoveOut.Enabled = false;
            this.toolStripMenuItemEditMoveIn.Enabled = false;

            this.toolStripMenuItemInsertTemplate.Enabled = true;
            this.toolStripMenuItemInsertViewDefinition.Enabled = true;
            this.toolStripMenuItemInsertExchange.Enabled = false;
            this.toolStripMenuItemInsertConceptRoot.Enabled = false;
            this.toolStripMenuItemInsertConceptLeaf.Enabled = false;

            this.toolStripMenuItemInsertNormative.Enabled = true;

            this.ToolStripMenuItemInsertTerm.Enabled = true;
            this.ToolStripMenuItemInsertAbbreviatedTerm.Enabled = true;

            this.toolStripMenuItemInsertSchema.Enabled = false;
            this.toolStripMenuItemInsertEntity.Enabled = false;
            this.toolStripMenuItemInsertAttribute.Enabled = false;
            this.toolStripMenuItemInsertSelect.Enabled = false;
            this.toolStripMenuItemInsertDefined.Enabled = false;
            this.toolStripMenuItemInsertEnumeration.Enabled = false;
            this.toolStripMenuItemInsertEnumerationConstant.Enabled = false;
            this.toolStripMenuItemInsertWhere.Enabled = false;
            this.toolStripMenuItemInsertUnique.Enabled = false;
            this.toolStripMenuItemInsertGlobalRule.Enabled = false;
            this.toolStripMenuItemInsertFunction.Enabled = false;
            this.toolStripMenuItemInsertPrimitive.Enabled = false;
            this.toolStripMenuItemInsertReference.Enabled = false;
            this.toolStripMenuItemInsertComment.Enabled = false;

            this.toolStripMenuItemInsertPropertyset.Enabled = false;
            this.toolStripMenuItemInsertProperty.Enabled = false;
            this.toolStripMenuItemInsertQuantityset.Enabled = false;
            this.toolStripMenuItemInsertQuantity.Enabled = false;

            this.toolStripMenuItemInsertBibliography.Enabled = true;

            this.ToolStripMenuItemEditCut.Enabled = false;
            this.toolStripMenuItemEditCopy.Enabled = false;
            this.toolStripMenuItemEditPaste.Enabled = false;

            this.toolStripMenuItemContextInsertModelView.Visible = false;
            this.toolStripMenuItemContextInsertExchange.Visible = false;
            this.toolStripMenuItemContextInsertTemplate.Visible = false;
            this.toolStripMenuItemContextInsertRoot.Visible = false;
            this.toolStripMenuItemContextInsertLeaf.Visible = false;
            this.toolStripMenuItemContextInsertNormative.Visible = false;
            this.toolStripMenuItemContextInsertTerm.Visible = false;
            this.toolStripMenuItemContextInsertAbbreviatedTerm.Visible = false;
            this.toolStripMenuItemContextInsertPset.Visible = false;
            this.toolStripMenuItemContextInsertProperty.Visible = false;
            this.toolStripMenuItemContextInsertQset.Visible = false;
            this.toolStripMenuItemContextInsertQuantity.Visible = false;
            this.toolStripMenuItemContextInsertExample.Visible = false;
            this.toolStripMenuItemContextInsertBibliography.Visible = false;
            this.toolStripMenuItemContextInsert.Visible = false;


            this.toolStripMenuItemDiagramFormatPageRef.Enabled = (e.Node.Tag is DocDefinition);
            this.toolStripMenuItemDiagramFormatPageRef.Checked = false;
            if (e.Node.Tag is DocDefinition)
            {
                TreeNode tnSchema = e.Node;
                while (!(tnSchema.Tag is DocSchema) && tnSchema.Parent != null)
                {
                    tnSchema = tnSchema.Parent;
                }
                if (tnSchema.Tag is DocSchema)
                {
                    DocSchema docSchema = (DocSchema)tnSchema.Tag;
                    foreach(DocPageTarget docPageTarget in docSchema.PageTargets)
                    {
                        if (docPageTarget.Definition == e.Node.Tag)
                        {
                            this.toolStripMenuItemDiagramFormatPageRef.Checked = true;
                            break;
                        }
                    }
                }

            }

            this.toolStripMenuItemDiagramFormatTree.Enabled = (e.Node.Tag is IDocTreeHost && ((IDocTreeHost)e.Node.Tag).Tree.Count > 0);
            this.toolStripMenuItemDiagramFormatTree.Checked = (e.Node.Tag is IDocTreeHost && ((IDocTreeHost)e.Node.Tag).Tree.Count > 0 && ((IDocTreeHost)e.Node.Tag).Tree[0].Definition == null);

            if (e.Node.Tag is DocTerm)
            {
                this.toolStripMenuItemEditDelete.Enabled = true;
                this.toolStripMenuItemEditRename.Enabled = true;
            }
            if (e.Node.Tag is DocAbbreviation)
            {
                this.toolStripMenuItemEditDelete.Enabled = true;
                this.toolStripMenuItemEditRename.Enabled = true;
            }
            else if (e.Node.Tag is DocTemplateDefinition)
            {
                this.toolStripMenuItemEditDelete.Enabled = true;
                this.toolStripMenuItemEditRename.Enabled = true;
                this.toolStripMenuItemEditProperties.Enabled = true;

                this.toolStripMenuItemContextInsertTemplate.Visible = true;
                this.toolStripMenuItemContextInsert.Visible = true;

                DocTemplateDefinition obj = (DocTemplateDefinition)e.Node.Tag;
                this.SetContent(obj, obj.Documentation);

                if (e.Node.Parent.Tag is DocTemplateDefinition)
                {
                    DocTemplateDefinition ent = (DocTemplateDefinition)e.Node.Parent.Tag;
                    if (ent.Templates.IndexOf(obj) > 0)
                    {
                        this.toolStripMenuItemEditMoveUp.Enabled = true;
                        this.toolStripMenuItemEditMoveIn.Enabled = true;
                    }

                    if (ent.Templates.IndexOf(obj) < ent.Templates.Count - 1)
                    {
                        this.toolStripMenuItemEditMoveDown.Enabled = true;
                    }

                    this.toolStripMenuItemEditMoveOut.Enabled = true;
                }
                else
                {
                    if (this.m_project.Templates.IndexOf(obj) > 0)
                    {
                        this.toolStripMenuItemEditMoveUp.Enabled = true;
                    }

                    if (this.m_project.Templates.IndexOf(obj) < this.m_project.Templates.Count - 1)
                    {
                        this.toolStripMenuItemEditMoveDown.Enabled = true;
                    }
                }
            }
            else if (e.Node.Tag is DocTemplateUsage)
            {
                DocTemplateUsage obj = (DocTemplateUsage)e.Node.Tag;

                //int iFigure = 1;
                //int iTable = 1;
                DocConceptRoot root = (DocConceptRoot)e.Node.Parent.Tag;
                DocEntity ent = (DocEntity)e.Node.Parent.Parent.Tag;
                this.SetContent(obj, obj.Documentation);//DocumentationISO.FormatTemplate(this.m_project, ent, root, obj, ref iFigure, ref iTable));

                this.toolStripMenuItemEditCopy.Enabled = true;
                this.toolStripMenuItemEditDelete.Enabled = true;
                this.toolStripMenuItemEditProperties.Enabled = true;

                DocConceptRoot docRoot = (DocConceptRoot)e.Node.Parent.Tag;
                if (docRoot.Concepts.IndexOf(obj) > 0)
                {
                    this.toolStripMenuItemEditMoveUp.Enabled = true;
                }

                if (docRoot.Concepts.IndexOf(obj) < docRoot.Concepts.Count - 1)
                {
                    this.toolStripMenuItemEditMoveDown.Enabled = true;
                }
            }
            else if (e.Node.Tag is DocTemplateItem)
            {
                DocTemplateItem obj = (DocTemplateItem)e.Node.Tag;
                this.SetContent(null, null);

                this.toolStripMenuItemEditProperties.Enabled = true;
                this.toolStripMenuItemEditDelete.Enabled = true;
            }
            else if (e.Node.Tag is DocModelView)
            {
                DocModelView obj = (DocModelView)e.Node.Tag;
                this.SetContent(obj, obj.Documentation);

                this.toolStripMenuItemInsertExchange.Enabled = true;
                this.toolStripMenuItemEditProperties.Enabled = true;
                this.toolStripMenuItemEditDelete.Enabled = true;
                this.toolStripMenuItemEditRename.Enabled = true;
                this.toolStripMenuItemEditPaste.Enabled = (this.m_clipboard is DocExchangeDefinition);


                this.toolStripMenuItemContextInsertExchange.Visible = true;
                this.toolStripMenuItemContextInsert.Visible = true;

                if (this.m_project.ModelViews.IndexOf(obj) > 0)
                {
                    this.toolStripMenuItemEditMoveUp.Enabled = true;
                }

                if (this.m_project.ModelViews.IndexOf(obj) < this.m_project.ModelViews.Count - 1)
                {
                    this.toolStripMenuItemEditMoveDown.Enabled = true;
                }
            }
            else if (e.Node.Tag is DocExchangeDefinition)
            {
                DocExchangeDefinition obj = (DocExchangeDefinition)e.Node.Tag;
                this.SetContent(obj, obj.Documentation);

                this.toolStripMenuItemEditCopy.Enabled = true;
                this.toolStripMenuItemEditProperties.Enabled = true;
                this.toolStripMenuItemEditDelete.Enabled = true;
                this.toolStripMenuItemEditRename.Enabled = true;

                if (e.Node.Parent.Tag is DocModelView)
                {
                    DocModelView ent = (DocModelView)e.Node.Parent.Tag;
                    if (ent.Exchanges.IndexOf(obj) > 0)
                    {
                        this.toolStripMenuItemEditMoveUp.Enabled = true;
                    }

                    if (ent.Exchanges.IndexOf(obj) < ent.Exchanges.Count - 1)
                    {
                        this.toolStripMenuItemEditMoveDown.Enabled = true;
                    }
                }
            }
            else if (e.Node.Tag is DocChangeSet)
            {
                DocChangeSet obj = (DocChangeSet)e.Node.Tag;
                this.SetContent(obj, obj.Documentation);
                this.toolStripMenuItemEditProperties.Enabled = true;
                this.toolStripMenuItemEditDelete.Enabled = true;
            }
            else if (e.Node.Tag == typeof(DocPropertySet))
            {
                this.toolStripMenuItemInsertPropertyset.Enabled = true;
                this.toolStripMenuItemContextInsertPset.Visible = true;
                this.toolStripMenuItemContextInsert.Visible = true;
            }
            else if (e.Node.Tag == typeof(DocQuantitySet))
            {
                this.toolStripMenuItemInsertQuantityset.Enabled = true;
                this.toolStripMenuItemContextInsertQset.Visible = true;
                this.toolStripMenuItemContextInsert.Visible = true;
            }
            else if (e.Node.Tag is DocObject)
            {
                DocObject obj = (DocObject)e.Node.Tag;
                this.SetContent(obj, obj.Documentation);

                this.toolStripMenuItemEditRename.Enabled = true;
                this.toolStripMenuItemEditProperties.Enabled = true;

                if (obj is DocSchema)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;

                    this.toolStripMenuItemInsertPropertyset.Enabled = true;
                    this.toolStripMenuItemInsertQuantityset.Enabled = true;

                    this.toolStripMenuItemContextInsertPset.Visible = true;
                    this.toolStripMenuItemContextInsertQset.Visible = true;
                    this.toolStripMenuItemContextInsert.Visible = true;

                    this.toolStripMenuItemInsertEntity.Enabled = true;
                    this.toolStripMenuItemInsertEnumeration.Enabled = true;
                    this.toolStripMenuItemInsertSelect.Enabled = true;
                    this.toolStripMenuItemInsertDefined.Enabled = true;
                    this.toolStripMenuItemInsertGlobalRule.Enabled = true;
                    this.toolStripMenuItemInsertFunction.Enabled = true;
                    this.toolStripMenuItemInsertPrimitive.Enabled = true;
                    this.toolStripMenuItemInsertReference.Enabled = true;
                    this.toolStripMenuItemInsertComment.Enabled = true;
                }
                else if (obj is DocType)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;

                    if (obj is DocEnumeration)
                    {
                        toolStripMenuItemInsertEnumerationConstant.Enabled = true;
                    }
                    else if(obj is DocSelect)
                    {
                        DocSelect docSel = (DocSelect)obj;
                    }
                    this.toolStripMenuItemDiagramFormatPageRef.Enabled = true;
                }
                else if (obj is DocConstant)
                {
                    DocConstant docConst = (DocConstant)obj;
                    this.toolStripMenuItemEditDelete.Enabled = true;
                    DocEnumeration docEnum = (DocEnumeration)treeView.SelectedNode.Parent.Tag;
                    this.toolStripMenuItemEditMoveUp.Enabled = (docEnum.Constants.IndexOf(docConst) > 0);
                    this.toolStripMenuItemEditMoveDown.Enabled = (docEnum.Constants.IndexOf(docConst) < docEnum.Constants.Count - 1);
                }
                else if (obj is DocEntity)
                {
                    DocEntity entity = (DocEntity)obj;

                    this.toolStripMenuItemEditDelete.Enabled = true;
                    this.toolStripMenuItemEditPaste.Enabled = false;

                    this.toolStripMenuItemInsertAttribute.Enabled = true;
                    this.toolStripMenuItemInsertUnique.Enabled = true;
                    this.toolStripMenuItemInsertWhere.Enabled = true;
                    this.toolStripMenuItemInsertConceptRoot.Enabled = true;

                    this.toolStripMenuItemContextInsertRoot.Visible = true;
                    this.toolStripMenuItemContextInsert.Visible = true;

                    if (entity.Subtypes.Count > 0)
                    {
                        this.toolStripMenuItemDiagramFormatTree.Enabled = true;
                    }
                    this.toolStripMenuItemDiagramFormatPageRef.Enabled = true;
                }
                else if (obj is DocAttribute)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                }
                else if (obj is DocSchema)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                }
                else if (obj is DocFunction)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                }
                else if (obj is DocConceptRoot)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                    this.toolStripMenuItemEditPaste.Enabled = (this.m_clipboard is DocTemplateUsage);
                    this.toolStripMenuItemInsertConceptLeaf.Enabled = true;

                    this.toolStripMenuItemContextInsertLeaf.Visible = true;
                    this.toolStripMenuItemContextInsert.Visible = true;
                }
                else if (obj is DocPropertySet)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                    this.toolStripMenuItemInsertProperty.Enabled = true;

                    this.toolStripMenuItemContextInsertProperty.Visible = true;
                    this.toolStripMenuItemContextInsert.Visible = true;

                    DocSchema ent = (DocSchema)e.Node.Parent.Parent.Tag;
                    if (ent.PropertySets.IndexOf((DocPropertySet)obj) > 0)
                    {
                        this.toolStripMenuItemEditMoveUp.Enabled = true;
                    }

                    if (ent.PropertySets.IndexOf((DocPropertySet)obj) < ent.PropertySets.Count - 1)
                    {
                        this.toolStripMenuItemEditMoveDown.Enabled = true;
                    }
                }
                else if (obj is DocProperty)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;

                    DocPropertySet ent = (DocPropertySet)e.Node.Parent.Tag;
                    if (ent.Properties.IndexOf((DocProperty)obj) > 0)
                    {
                        this.toolStripMenuItemEditMoveUp.Enabled = true;
                    }

                    if (ent.Properties.IndexOf((DocProperty)obj) < ent.Properties.Count - 1)
                    {
                        this.toolStripMenuItemEditMoveDown.Enabled = true;
                    }
                }
                else if (obj is DocQuantitySet)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                    this.toolStripMenuItemInsertQuantity.Enabled = true;

                    this.toolStripMenuItemContextInsertQuantity.Visible = true;
                    this.toolStripMenuItemContextInsert.Visible = true;

                    DocSchema ent = (DocSchema)e.Node.Parent.Parent.Tag;
                    if (ent.QuantitySets.IndexOf((DocQuantitySet)obj) > 0)
                    {
                        this.toolStripMenuItemEditMoveUp.Enabled = true;
                    }

                    if (ent.QuantitySets.IndexOf((DocQuantitySet)obj) < ent.QuantitySets.Count - 1)
                    {
                        this.toolStripMenuItemEditMoveDown.Enabled = true;
                    }
                }
                else if (obj is DocQuantity)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;

                    DocQuantitySet ent = (DocQuantitySet)e.Node.Parent.Tag;
                    if (ent.Quantities.IndexOf((DocQuantity)obj) > 0)
                    {
                        this.toolStripMenuItemEditMoveUp.Enabled = true;
                    }

                    if (ent.Quantities.IndexOf((DocQuantity)obj) < ent.Quantities.Count - 1)
                    {
                        this.toolStripMenuItemEditMoveDown.Enabled = true;
                    }
                }
                else if (obj is DocExample)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;

                    if (e.Node.Parent.Tag is DocExample)
                    {
                        DocExample ent = (DocExample)e.Node.Parent.Tag;
                        if (ent.Examples.IndexOf((DocExample)obj) > 0)
                        {
                            this.toolStripMenuItemEditMoveUp.Enabled = true;
                            this.toolStripMenuItemEditMoveIn.Enabled = true;
                        }

                        if (ent.Examples.IndexOf((DocExample)obj) < ent.Examples.Count - 1)
                        {
                            this.toolStripMenuItemEditMoveDown.Enabled = true;
                        }

                        this.toolStripMenuItemEditMoveOut.Enabled = true;
                    }
                    else
                    {
                        if (this.m_project.Examples.IndexOf((DocExample)obj) > 0)
                        {
                            this.toolStripMenuItemEditMoveUp.Enabled = true;
                            this.toolStripMenuItemEditMoveIn.Enabled = true;
                        }

                        if (this.m_project.Examples.IndexOf((DocExample)obj) < this.m_project.Examples.Count - 1)
                        {
                            this.toolStripMenuItemEditMoveDown.Enabled = true;
                        }
                    }
                }
                else if (obj is DocComment)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                }
                else if (obj is DocPrimitive)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                    this.toolStripMenuItemEditRename.Enabled = false;
                }
                else if (obj is DocDefinitionRef)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                }
                else if (obj is DocPageSource)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                }
                else if (obj is DocPageTarget)
                {
                    this.toolStripMenuItemEditDelete.Enabled = true;
                }

                if (obj is DocSection)
                {
                    this.toolStripMenuItemEditRename.Enabled = false;
                    this.toolStripMenuItemEditProperties.Enabled = true; // for now, cannot delete sections

                    if (e.Node.Index >= 4 && e.Node.Index < 8)
                    {
                        this.toolStripMenuItemInsertSchema.Enabled = true;
                    }

                    // special cases
                    switch (e.Node.Index)
                    {
                        case 0: // scope
                            this.toolStripMenuItemContextInsertModelView.Visible = true;
                            this.toolStripMenuItemContextInsert.Visible = true;
                            break;

                        case 1: // normative references
                            this.toolStripMenuItemContextInsertNormative.Visible = true;
                            this.toolStripMenuItemContextInsert.Visible = true;
                            break;

                        case 2: // terms
                            this.toolStripMenuItemContextInsertTerm.Visible = true;
                            this.toolStripMenuItemContextInsertAbbreviatedTerm.Visible = true;
                            this.toolStripMenuItemContextInsert.Visible = true;
                            break;

                        case 3: // templates
                            this.toolStripMenuItemContextInsertTemplate.Visible = true;
                            this.toolStripMenuItemContextInsert.Visible = true;
                            break;
                    }
                }
                else if (obj is DocAnnex)
                {
                    this.toolStripMenuItemEditRename.Enabled = false;
                    if (e.Node.Index == 12)
                    {
                        this.toolStripMenuItemContextInsertExample.Visible = true;
                        this.toolStripMenuItemContextInsert.Visible = true;
                    }
                }
            }
            else
            {
                this.SetContent(null, null);
            }

            // copy state to context menu
            this.toolStripMenuItemContextSeparator.Visible = this.toolStripMenuItemContextInsert.Visible;
            this.deleteToolStripMenuItem.Enabled = this.toolStripMenuItemEditDelete.Enabled;
            this.propertiesToolStripMenuItem.Enabled = this.toolStripMenuItemEditProperties.Enabled;

            // copy state to toolbar
            this.ToolStripButtonEditCut.Enabled = this.ToolStripMenuItemEditCut.Enabled;
            this.ToolStripButtonEditCopy.Enabled = this.toolStripMenuItemEditCopy.Enabled;
            this.ToolStripButtonEditPaste.Enabled = this.toolStripMenuItemEditPaste.Enabled;
            this.toolStripButtonEditDelete.Enabled = this.toolStripMenuItemEditDelete.Enabled;
            this.toolStripButtonEditRename.Enabled = this.toolStripMenuItemEditRename.Enabled;
            this.toolStripButtonEditProperties.Enabled = this.toolStripMenuItemEditProperties.Enabled;

            this.toolStripButtonMoveUp.Enabled = this.toolStripMenuItemEditMoveUp.Enabled;
            this.toolStripButtonMoveDown.Enabled = this.toolStripMenuItemEditMoveDown.Enabled;
            this.toolStripButtonMoveOut.Enabled = this.toolStripMenuItemEditMoveOut.Enabled;
            this.toolStripButtonMoveIn.Enabled = this.toolStripMenuItemEditMoveIn.Enabled;

            // restore focus
            this.treeView.Focus();
        }

        #endregion
        #region BROWSER

        /// <summary>
        /// Sets content to web browser and text editing
        /// </summary>
        /// <param name="content"></param>
        private void SetContent(DocObject obj, string content)
        {
            string s = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\content\\ifc-styles.css";
            string header = "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"><link rel=\"stylesheet\" type=\"text/css\" href=\"" + s + "\"></head><body>";
            string footer = "</body></html>";

            // replace images to use hard-coded paths
            if (content != null)
            {
                int i = content.Length - 1;
                while (i > 0)
                {
                    i = content.LastIndexOf("<img src=\"", i - 1);
                    if (i >= 0)
                    {
                        int j = content.IndexOf(">", i + 1);
                        int t = content.IndexOf("\"", i + 10);
                        if (j >= 0 && t >= 0)
                        {
                            string imgold = content.Substring(i + 10, t - i - 10);
                            imgold = imgold.Substring(imgold.LastIndexOf('/') + 1);
                            string imgnew = Properties.Settings.Default.OutputPath + "\\figures\\" + imgold;

                            if (obj is DocExample)
                            {
                                imgnew = Properties.Settings.Default.OutputPath + "\\annex\\annex-e\\" + imgold;
                            }

                            content = content.Substring(0, i + 10) + imgnew + content.Substring(t);
                        }
                    }
                }
            }

            this.webBrowser.Navigate("about:blank");
            this.webBrowser.DocumentText = header + content + footer;

            if (obj != null)
            {
                // edit overall text
                this.textBoxHTML.Text = obj.Documentation;// content;
            }

            this.textBoxHTML.Tag = obj; // remember tag to ensure we update regardless of tree state       

            if (obj is DocTemplateDefinition)
            {
                DocTemplateDefinition docTemplate = (DocTemplateDefinition)obj;

                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();
                BuildMaps(mapEntity, mapSchema);
                this.ctlConcept.Map = mapEntity;
                this.ctlConcept.Project = this.m_project;
                this.ctlConcept.Template = docTemplate;

                this.ctlRules.Project = this.m_project;
                this.ctlRules.BaseTemplate = this.treeView.SelectedNode.Parent.Tag as DocTemplateDefinition;
                this.ctlRules.Template = docTemplate;

                this.ctlOperators.Project = this.m_project;
                this.ctlOperators.Template = docTemplate;
                this.ctlOperators.Rule = null;

                this.ctlInheritance.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.ctlExpressG.Visible = false;
                this.splitContainerConcept.Visible = true;
                this.splitContainerRules.Visible = true;
                this.ctlParameters.Visible = false;
            }
            else if (obj is DocModelView)
            {
                // for now, always refresh -- future: check for changes
                DocModelView docView = (DocModelView)obj;
                docView.Filter(null);

                this.ctlInheritance.Project = this.m_project;
                this.ctlInheritance.ModelView = docView;
                this.ctlInheritance.Entity = this.m_project.GetDefinition("IfcRoot") as DocEntity;

                this.ctlInheritance.Visible = true;
                this.ctlExpressG.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.splitContainerConcept.Visible = false;
                this.ctlParameters.Visible = false;
            }
            else if(obj is DocSection)
            {
                this.ctlInheritance.Project = this.m_project;
                this.ctlInheritance.ModelView = null;
                this.ctlInheritance.Entity = this.m_project.GetDefinition("IfcRoot") as DocEntity;

                this.ctlInheritance.Visible = true;
                this.ctlExpressG.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.splitContainerConcept.Visible = false;
                this.ctlParameters.Visible = false;
            }
            else if (obj is DocExchangeDefinition)
            {
                DocExchangeDefinition docExchange = (DocExchangeDefinition)obj;
                DocModelView docView = (DocModelView)this.treeView.SelectedNode.Parent.Tag;
                this.ctlCheckGrid.CheckGridSource = new CheckGridExchange(docExchange, docView, this.m_project);

                this.ctlInheritance.Visible = false;
                this.ctlCheckGrid.Visible = true;
                this.ctlExpressG.Visible = false;
                this.splitContainerConcept.Visible = false;
                this.ctlParameters.Visible = false;
            }
            else if (obj is DocConceptRoot)
            {
                DocConceptRoot docRoot = (DocConceptRoot)obj;
                DocModelView docView = null;
                foreach (DocModelView eachView in this.m_project.ModelViews)
                {
                    if (eachView.ConceptRoots.Contains(docRoot))
                    {
                        docView = eachView;
                        break;
                    }
                }

                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();
                BuildMaps(mapEntity, mapSchema);

                this.ctlConcept.Map = mapEntity;
                this.ctlConcept.Project = this.m_project;
                this.ctlConcept.Template = null;
                this.ctlConcept.ConceptRoot = docRoot;
                this.ctlInheritance.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.ctlExpressG.Visible = false;
                this.splitContainerConcept.Visible = true;
                this.splitContainerRules.Visible = true;
                this.ctlParameters.Visible = false;

#if false // requirements view -- move into separate view mode in future
                this.ctlCheckGrid.CheckGridSource = new CheckGridEntity(docRoot, docView, this.m_project, mapEntity);
                this.ctlCheckGrid.Visible = true;
                this.ctlExpressG.Visible = false;
                this.splitContainerConcept.Visible = false;
#endif
            }
            else if (obj is DocTemplateUsage)
            {
                DocTemplateUsage docUsage = (DocTemplateUsage)obj;
                DocConceptRoot docRoot = (DocConceptRoot)this.treeView.SelectedNode.Parent.Tag;
                DocModelView docView = null;
                foreach (DocModelView eachView in this.m_project.ModelViews)
                {
                    if (eachView.ConceptRoots.Contains(docRoot))
                    {
                        docView = eachView;
                        break;
                    }
                }

                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();
                BuildMaps(mapEntity, mapSchema);

                this.ctlConcept.Map = mapEntity;
                this.ctlConcept.Project = this.m_project;
                this.ctlConcept.Template = docUsage.Definition;
                this.ctlConcept.ConceptRoot = null;
                this.ctlInheritance.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.ctlExpressG.Visible = false;
                this.splitContainerConcept.Visible = true;
                this.splitContainerRules.Visible = false;
                this.ctlParameters.Visible = true;

                this.ctlOperators.Template = null;

                this.ctlParameters.Project = this.m_project;
                this.ctlParameters.ConceptRoot = docRoot;
                this.ctlParameters.ConceptLeaf = docUsage;


#if false // requirements view -- move into separate view mode in future
                this.ctlCheckGrid.CheckGridSource = new CheckGridConcept(docUsage.Definition, docView, this.m_project);
                this.ctlCheckGrid.Visible = true;
                this.ctlExpressG.Visible = false;
                this.splitContainerConcept.Visible = false;
#endif
            }
            else if (obj is DocSchema)
            {
                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();
                BuildMaps(mapEntity, mapSchema);

                this.ctlExpressG.Map = mapEntity;
                this.ctlExpressG.Schema = (DocSchema)obj;
                this.ctlExpressG.Selection = null;
                this.ctlExpressG.Visible = true;
                this.ctlInheritance.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.splitContainerConcept.Visible = false;
                this.ctlParameters.Visible = false;
            }
            else if(obj is DocDefinition)
            {
                // determine schema from parent node
                TreeNode tn = this.treeView.SelectedNode;
                while(!(tn.Tag is DocSchema))
                {
                    tn = tn.Parent;
                }

                DocSchema docSchema = (DocSchema)tn.Tag;

                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();
                BuildMaps(mapEntity, mapSchema);

                if (docSchema != null)
                {
                    this.ctlExpressG.Map = mapEntity;
                    this.ctlExpressG.Schema = docSchema;
                    this.ctlExpressG.Selection = (DocDefinition)obj;
                    this.ctlExpressG.Visible = true;
                }

                this.ctlInheritance.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.splitContainerConcept.Visible = false;
                this.ctlParameters.Visible = false;
            }
            else if (obj is DocAttribute || obj is DocWhereRule || obj is DocUniqueRule || obj is DocConstant || obj is DocSchemaRef || obj is DocSelectItem)
            {
                // determine schema from parent node
                TreeNode tn = this.treeView.SelectedNode;
                while (!(tn.Tag is DocSchema))
                {
                    tn = tn.Parent;
                }

                DocSchema docSchema = (DocSchema)tn.Tag;

                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();
                BuildMaps(mapEntity, mapSchema);

                if (docSchema != null)
                {
                    this.ctlExpressG.Map = mapEntity;
                    this.ctlExpressG.Schema = docSchema;
                    this.ctlExpressG.Selection = obj;
                    this.ctlExpressG.Visible = true;
                }

                this.ctlInheritance.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.splitContainerConcept.Visible = false;
                this.ctlParameters.Visible = false;
            }
            else if (obj == null && this.treeView.SelectedNode != null && this.treeView.SelectedNode.Parent.Tag is DocSchema)
            {
                // check if parent node is schema (intermediate node for organization)
                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();
                BuildMaps(mapEntity, mapSchema);

                this.ctlExpressG.Map = mapEntity;
                this.ctlExpressG.Schema = (DocSchema)this.treeView.SelectedNode.Parent.Tag;
                this.ctlExpressG.Selection = null;
                this.ctlExpressG.Visible = true;
                this.ctlInheritance.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.splitContainerConcept.Visible = false;
                this.ctlParameters.Visible = false;
            }
            else
            {
                this.ctlInheritance.Visible = false;
                this.ctlExpressG.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.splitContainerConcept.Visible = false;
                this.ctlParameters.Visible = false;
            }
        }

        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (this.webBrowser != sender)
                return;

            if (e.Url.OriginalString == "about:blank")
                return;

            // redirect according to documentation
            string[] parts = e.Url.ToString().Split('/');

            // last item is name of Identity or Type
            string topic = parts[parts.Length - 1];
            topic = topic.Split('.')[0]; // remove ".htm"

            // sync tree
            TreeNode tn = null;
            if (this.m_mapTree.TryGetValue(topic, out tn))
            {
                e.Cancel = true;
                this.treeView.SelectedNode = tn;
            }

        }

        private void TextBoxHTML_Validated(object sender, EventArgs e)
        {
            if (this.textBoxHTML.Text != null && this.textBoxHTML.Tag != null)
            {
                DocObject docobj = (DocObject)this.textBoxHTML.Tag;
                if (docobj.Documentation != this.textBoxHTML.Text)
                {
                    docobj.Documentation = this.textBoxHTML.Text;
                    this.m_modified = true;
                }
            }
        }

        #endregion

        private void toolStripMenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog(this);
        }

        private void toolStripMenuItemEditProperties_Click(object sender, EventArgs e)
        {
            DocObject docObject = this.treeView.SelectedNode.Tag as DocObject;
            if (docObject != null)
            {
                // build path
                List<DocObject> path = new List<DocObject>();
                TreeNode tn = this.treeView.SelectedNode;
                while (tn != null)
                {
                    if (tn.Tag is DocObject)
                    {
                        path.Insert(0, (DocObject)tn.Tag);
                    }
                    tn = tn.Parent;
                }

                using (FormProperties form = new FormProperties(path.ToArray(), this.m_project))
                {
                    form.Text = docObject.Name;
                    form.ShowDialog(this);

                    // update treenode name
                    if (docObject is DocConceptRoot)
                    {
                        // find model view name                        
                        foreach (DocModelView docView in this.m_project.ModelViews)
                        {
                            if (docView.ConceptRoots.Contains((DocConceptRoot)docObject))
                            {
                                this.treeView.SelectedNode.Text = docView.ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        this.treeView.SelectedNode.Text = docObject.ToString();// Name;
                    }

                    // update view
                    this.SetContent(docObject, docObject.Documentation);

                    this.m_modified = true;
                }
            }
        }

        private void toolStripMenuItemInsertTemplate_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeView.SelectedNode;

            DocTemplateDefinition doctemplate = new DocTemplateDefinition();
            
            if (tn != null && tn.Tag is DocTemplateDefinition)
            {
                // sub-template
                DocTemplateDefinition parent = (DocTemplateDefinition)tn.Tag;
                parent.Templates.Add(doctemplate);

                doctemplate.Type = parent.Type;

                // propagate rules
                if (parent.Rules != null)
                {
                    foreach (DocModelRule docRule in parent.Rules)
                    {
                        doctemplate.Rules.Add((DocModelRule)docRule.Clone());
                    }
                }

                tn = LoadNode(tn, doctemplate, doctemplate.Name, true);
                this.treeView.SelectedNode = tn;
            }
            else
            {
                // root template
                this.m_project.Templates.Add(doctemplate);

                doctemplate.Type = "IfcRoot";

                //tn = this.treeView.Nodes[3].Nodes[0]; // hard-coded
                tn = this.treeView.Nodes[3]; // hard-coded
                tn = LoadNode(tn, doctemplate, doctemplate.Name, true);
                this.treeView.SelectedNode = tn;
            }

            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertViewDefinition_Click(object sender, EventArgs e)
        {
            if (this.m_project.ModelViews == null)
            {
                // compat
                this.m_project.ModelViews = new List<DocModelView>();
            }

            DocModelView docView = new DocModelView();
            this.m_project.ModelViews.Add(docView);

            TreeNode tnParent = this.treeView.Nodes[0];
            this.treeView.SelectedNode = this.LoadNode(tnParent, docView, docView.ToString(), true);

            toolStripMenuItemEditProperties_Click(this, e);
        }

        private void toolStripMenuItemInsertExchange_Click(object sender, EventArgs e)
        {
            if (this.m_project.ModelViews == null)
            {
                // compat
                this.m_project.ModelViews = new List<DocModelView>();
            }

            // must select modelview

            DocModelView docView = this.treeView.SelectedNode.Tag as DocModelView;
            DocExchangeDefinition docExchange = new DocExchangeDefinition();
            docView.Exchanges.Add(docExchange);

            TreeNode tnParent = this.treeView.SelectedNode;
            this.treeView.SelectedNode = this.LoadNode(tnParent, docExchange, docExchange.ToString(), false);

            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertUseDefinition_Click(object sender, EventArgs e)
        {
            DocConceptRoot docConceptRoot = this.treeView.SelectedNode.Tag as DocConceptRoot;
            if (docConceptRoot == null)
                return;

            DocEntity docEntity = (DocEntity)this.treeView.SelectedNode.Parent.Tag as DocEntity;
            if (docEntity == null)
                return;

            // browse for template
            using (FormSelectTemplate form = new FormSelectTemplate(null, this.m_project, docEntity))
            {
                DialogResult res = form.ShowDialog(this);
                if (res == DialogResult.OK && form.SelectedTemplate != null)
                {
                    // create
                    DocTemplateUsage docUsage = new DocTemplateUsage();
                    docConceptRoot.Concepts.Add(docUsage);
                    docUsage.Definition = form.SelectedTemplate;
                    docUsage.Name = docUsage.Definition.Name;
                    this.treeView.SelectedNode = LoadNode(this.treeView.SelectedNode, docUsage, docUsage.Name, false);
                }
            }

        }

        /// <summary>
        /// Builds list of inherited direct attributes in order (excludes INVERSE attributes)
        /// </summary>
        /// <param name="list">list to populate</param>
        /// <param name="map">map to lookup for base types</param>
        /// <param name="docEntity">entity to traverse</param>
        private void BuildAttributeListDirect(List<DocAttribute> list, Dictionary<string, DocObject> map, DocEntity docEntity)
        {
            // recurse to base type first
            if (docEntity.BaseDefinition != null)
            {
                DocEntity docSuper = map[docEntity.BaseDefinition] as DocEntity;
                BuildAttributeListDirect(list, map, docSuper);
            }

            // then add direct attributes
            foreach (DocAttribute docAttribute in docEntity.Attributes)
            {
                if (docAttribute.Inverse == null && docAttribute.Derived == null)
                {
                    list.Add(docAttribute);
                }
            }
        }

        /// <summary>
        /// Indicates whether select includes another select, entity, or value type
        /// </summary>
        /// <param name="docSelect"></param>
        /// <param name="docDefinition"></param>        
        /// <returns></returns>
        private static bool SelectIncludes(DocSelect docSelect, string defname, Dictionary<string, DocObject> map)
        {
            foreach (DocSelectItem docSelectItem in docSelect.Selects)
            {
                if (docSelectItem.Name == defname)
                    return true;

                DocObject docObj = null;
                if (map.TryGetValue(docSelectItem.Name, out docObj))
                {
                    if (docObj is DocSelect)
                    {
                        bool result = SelectIncludes((DocSelect)docObj, defname, map);
                        if (result)
                            return true;
                    }
                    else if (docObj is DocEntity)
                    {
                        bool result = EntityIncludes((DocEntity)docObj, defname, map);
                        if (result)
                            return true;
                    }
                }
            }

            return false;
        }

        private static bool EntityIncludes(DocEntity docEntity, string defname, Dictionary<string, DocObject> map)
        {
            // traverse subtypes
            DocObject docTest = null;
            if (!map.TryGetValue(defname, out docTest))
                return false;

            if (!(docTest is DocEntity))
                return false;

            DocEntity docTestEntity = (DocEntity)docTest;
            if (docTestEntity.BaseDefinition == null)
                return false;

            if (docTestEntity.BaseDefinition == docEntity.Name)
                return true;

            // recurse upwards
            return EntityIncludes(docEntity, docTestEntity.BaseDefinition, map);
        }

        private void generateChangeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = this.openFileDialogChanges.ShowDialog(this);
            if (res != DialogResult.OK)
                return;

            this.m_loading = true;

            Dictionary<long, SEntity> instances = new Dictionary<long, SEntity>();
            using (FormatSPF format = new FormatSPF(this.openFileDialogChanges.FileName, SchemaDOC.Types, instances))
            {
                format.Load();
            }

            this.m_loading = false;

            // now import changes
            DocProject docProjectBase = null;
            foreach (SEntity o in instances.Values)
            {
                if (o is DocProject)
                {
                    docProjectBase = (DocProject)o;
                }
            }

            // build maps            
            Dictionary<string, DocObject> mapNew = new Dictionary<string, DocObject>();
            foreach (DocSection docSection in this.m_project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        mapNew.Add(docEntity.Name, docEntity);
                    }
                    foreach (DocType docType in docSchema.Types)
                    {
                        mapNew.Add(docType.Name, docType);
                    }
                }
            }
            Dictionary<string, DocObject> mapOld = new Dictionary<string, DocObject>();
            foreach (DocSection docSection in docProjectBase.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        mapOld.Add(docEntity.Name, docEntity);
                    }
                    foreach (DocType docType in docSchema.Types)
                    {
                        mapOld.Add(docType.Name, docType);
                    }
                }
            }

            DocChangeSet docChangeSet = new DocChangeSet();
            if (this.m_project.ChangeSets == null)
            {
                // compat
                this.m_project.ChangeSets = new List<DocChangeSet>();
            }
            this.m_project.ChangeSets.Add(docChangeSet);
            docChangeSet.Name = System.IO.Path.GetFileNameWithoutExtension(this.openFileDialogChanges.FileName);
            docChangeSet.VersionBaseline = System.IO.Path.GetFileNameWithoutExtension(this.openFileDialogChanges.FileName);

            // iterate through each schema (new and old)
            for (int iSection = 4; iSection < 8; iSection++)
            {
                DocSection docSection = this.m_project.Sections[iSection];
                DocSection docSectionBase = docProjectBase.Sections[iSection];

                DocChangeAction docChangeSection = new DocChangeAction();
                docChangeSet.ChangesEntities.Add(docChangeSection);
                docChangeSection.Name = docSection.Name;

                DocChangeAction docChangeSectionProperties = new DocChangeAction();
                docChangeSet.ChangesProperties.Add(docChangeSectionProperties);
                docChangeSectionProperties.Name = docSection.Name;

                DocChangeAction docChangeSectionQuantities = new DocChangeAction();
                docChangeSet.ChangesQuantities.Add(docChangeSectionQuantities);
                docChangeSectionQuantities.Name = docSection.Name;

                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    // find equivalent schema
                    DocSchema docSchemaBase = null;
                    foreach (DocSchema docSchemaEach in docSectionBase.Schemas)
                    {
                        if (docSchemaEach.Name.Equals(docSchema.Name))
                        {
                            docSchemaBase = docSchemaEach;
                            break;
                        }
                    }

                    DocChangeAction docChangeSchema = new DocChangeAction();
                    docChangeSection.Changes.Add(docChangeSchema);
                    docChangeSchema.Name = docSchema.Name;

                    DocChangeAction docChangeSchemaProperties = new DocChangeAction();
                    docChangeSectionProperties.Changes.Add(docChangeSchemaProperties);
                    docChangeSchemaProperties.Name = docSchema.Name;

                    DocChangeAction docChangeSchemaQuantities = new DocChangeAction();
                    docChangeSectionQuantities.Changes.Add(docChangeSchemaQuantities);
                    docChangeSchemaQuantities.Name = docSchema.Name;

                    if (docSchemaBase == null)
                    {
                        // new schema
                        docChangeSchema.Action = DocChangeActionEnum.ADDED;
                    }
                    else
                    {
                        // existing schema


                        // compare types
                        foreach (DocType docType in docSchema.Types)
                        {
                            DocChangeAction docChangeType = new DocChangeAction();
                            docChangeSchema.Changes.Add(docChangeType);
                            docChangeType.Name = docType.Name;

                            // find equivalent type
                            DocType docTypeBase = null;
                            foreach (DocType docTypeEach in docSchemaBase.Types)
                            {
                                if (docTypeEach.Name.Equals(docType.Name))
                                {
                                    docTypeBase = docTypeEach;
                                    break;
                                }
                            }

                            if (docTypeBase == null)
                            {
                                // new type
                                docChangeType.Action = DocChangeActionEnum.ADDED;

                                // check if it was moved from another schema                                
                                foreach (DocSection docOtherSection in docProjectBase.Sections)
                                {
                                    foreach (DocSchema docOtherSchema in docOtherSection.Schemas)
                                    {
                                        foreach (DocType docOtherType in docOtherSchema.Types)
                                        {
                                            if (docOtherType.Name.Equals(docType.Name))
                                            {
                                                docChangeType.Action = DocChangeActionEnum.MOVED;
                                                docChangeType.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.SCHEMA, docOtherSchema.Name.ToUpper(), docSchema.Name.ToUpper()));
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // existing type

                                // if enumeration, check enums
                                if (docType is DocEnumeration)
                                {
                                    DocEnumeration docEnumeration = (DocEnumeration)docType;
                                    DocEnumeration docEnumerationBase = (DocEnumeration)docTypeBase;

                                    // find constants added
                                    foreach (DocConstant docConstant in docEnumeration.Constants)
                                    {
                                        // find equivalent constant
                                        DocConstant docConstantBase = null;
                                        foreach (DocConstant docConstantEach in docEnumerationBase.Constants)
                                        {
                                            if (docConstantEach.Name.Equals(docConstant.Name))
                                            {
                                                docConstantBase = docConstantEach;
                                                break;
                                            }
                                        }

                                        // for constants, only generate additions or deletions for brevity
                                        if (docConstantBase == null)
                                        {
                                            // new entity
                                            DocChangeAction docChangeConstant = new DocChangeAction();
                                            docChangeType.Changes.Add(docChangeConstant);
                                            docChangeConstant.Name = docConstant.Name;
                                            docChangeConstant.Action = DocChangeActionEnum.ADDED;
                                        }
                                    }

                                    // find constants removed
                                    foreach (DocConstant docConstantBase in docEnumerationBase.Constants)
                                    {
                                        // find equivalent constant
                                        DocConstant docConstant = null;
                                        foreach (DocConstant docConstantEach in docEnumeration.Constants)
                                        {
                                            if (docConstantEach.Name.Equals(docConstantBase.Name))
                                            {
                                                docConstant = docConstantEach;
                                                break;
                                            }
                                        }

                                        // for constants, only generate additions or deletions for brevity
                                        if (docConstant == null)
                                        {
                                            // deleted
                                            DocChangeAction docChangeConstant = new DocChangeAction();
                                            docChangeType.Changes.Add(docChangeConstant);
                                            docChangeConstant.Name = docConstantBase.Name;
                                            docChangeConstant.Action = DocChangeActionEnum.DELETED;
                                            docChangeConstant.ImpactSPF = true;
                                            docChangeConstant.ImpactXML = true;
                                        }
                                    }

                                }
                                else if (docType is DocSelect)
                                {
                                    DocSelect docEnumeration = (DocSelect)docType;
                                    DocSelect docEnumerationBase = (DocSelect)docTypeBase;

                                    // find select items added
                                    foreach (DocSelectItem docConstant in docEnumeration.Selects)
                                    {
                                        // find equivalent constant
                                        DocSelectItem docConstantBase = null;
                                        foreach (DocSelectItem docConstantEach in docEnumerationBase.Selects)
                                        {
                                            if (docConstantEach.Name.Equals(docConstant.Name))
                                            {
                                                docConstantBase = docConstantEach;
                                                break;
                                            }
                                        }

                                        // for constants, only generate additions or deletions for brevity
                                        if (docConstantBase == null)
                                        {
                                            // new entity
                                            DocChangeAction docChangeConstant = new DocChangeAction();
                                            docChangeType.Changes.Add(docChangeConstant);
                                            docChangeConstant.Name = docConstant.Name;
                                            docChangeConstant.Action = DocChangeActionEnum.ADDED;
                                        }
                                    }

                                    // find select items removed
                                    foreach (DocSelectItem docConstantBase in docEnumerationBase.Selects)
                                    {
                                        // find equivalent constant
                                        DocSelectItem docConstant = null;
                                        foreach (DocSelectItem docConstantEach in docEnumeration.Selects)
                                        {
                                            if (docConstantEach.Name.Equals(docConstantBase.Name))
                                            {
                                                docConstant = docConstantEach;
                                                break;
                                            }
                                        }

                                        // for selects, only generate additions or deletions for brevity
                                        if (docConstant == null)
                                        {
                                            // deleted select
                                            DocChangeAction docChangeConstant = new DocChangeAction();
                                            docChangeType.Changes.Add(docChangeConstant);
                                            docChangeConstant.Name = docConstantBase.Name;
                                            docChangeConstant.Action = DocChangeActionEnum.DELETED;

                                            // if a supertype of the deleted select has been added, then it's compatible (e.g. IfcMetricValueSelect: +IfcValue, -IfcText)                                            
                                            if (!SelectIncludes(docEnumeration, docConstantBase.Name, mapNew))
                                            {
                                                docChangeConstant.ImpactSPF = true;
                                                docChangeConstant.ImpactXML = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        // compare entities
                        foreach (DocEntity docEntity in docSchema.Entities)
                        {
                            DocChangeAction docChangeEntity = new DocChangeAction();
                            docChangeSchema.Changes.Add(docChangeEntity);
                            docChangeEntity.Name = docEntity.Name;

                            // find equivalent entity
                            DocEntity docEntityBase = null;
                            foreach (DocEntity docEntityEach in docSchemaBase.Entities)
                            {
                                if (docEntityEach.Name.Equals(docEntity.Name))
                                {
                                    docEntityBase = docEntityEach;
                                    break;
                                }
                            }

                            if (docEntityBase == null)
                            {
                                // new entity
                                docChangeEntity.Action = DocChangeActionEnum.ADDED;

                                // check if it was moved from another schema                                
                                foreach (DocSection docOtherSection in docProjectBase.Sections)
                                {
                                    foreach (DocSchema docOtherSchema in docOtherSection.Schemas)
                                    {
                                        foreach (DocEntity docOtherEntity in docOtherSchema.Entities)
                                        {
                                            if (docOtherEntity.Name.Equals(docEntity.Name))
                                            {
                                                docEntityBase = docOtherEntity; // still compare attributes if moved (e.g. IfcRelSequence)

                                                docChangeEntity.Action = DocChangeActionEnum.MOVED;
                                                docChangeEntity.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.SCHEMA, docOtherSchema.Name.ToUpper(), docSchema.Name.ToUpper()));
                                            }
                                        }
                                    }
                                }

                            }

                            if (docEntityBase != null)
                            {
                                // existing entity

                                // compare abstract vs. non-abstract
                                if (docEntity.IsAbstract() != docEntityBase.IsAbstract())
                                {
                                    docChangeEntity.Action = DocChangeActionEnum.MODIFIED;

                                    if (docEntityBase.IsAbstract())
                                    {
                                        docChangeEntity.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.INSTANTIATION, "ABSTRACT", null));
                                    }
                                    else
                                    {
                                        docChangeEntity.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.INSTANTIATION, null, "ABSTRACT"));
                                    }
                                }

                                // compare attributes by index

                                // only report non-abstract entities; e.g. attributes may be demoted without file impact
                                if (!docEntity.IsAbstract())
                                {

                                    List<DocAttribute> listAttributeNew = new List<DocAttribute>();
                                    List<DocAttribute> listAttributeOld = new List<DocAttribute>();
                                    BuildAttributeListDirect(listAttributeNew, mapNew, docEntity);
                                    BuildAttributeListDirect(listAttributeOld, mapOld, docEntityBase);

                                    for (int iAttribute = 0; iAttribute < listAttributeNew.Count; iAttribute++)
                                    {
                                        DocAttribute docAttribute = listAttributeNew[iAttribute];

                                        // we only care about direct attributes
                                        DocChangeAction docChangeAttribute = new DocChangeAction();
                                        docChangeEntity.Changes.Add(docChangeAttribute);
                                        docChangeAttribute.Name = docAttribute.Name;

                                        if (iAttribute >= listAttributeOld.Count)
                                        {
                                            // new attribute added
                                            docChangeAttribute.Action = DocChangeActionEnum.ADDED;
                                        }
                                        else
                                        {
                                            DocAttribute docAttributeBase = listAttributeOld[iAttribute];

                                            // compare for changes
                                            if (!docAttribute.Name.Equals(docAttributeBase.Name))
                                            {
                                                docChangeAttribute.Action = DocChangeActionEnum.MODIFIED;
                                                docChangeAttribute.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.NAME, docAttributeBase.Name, docAttribute.Name));

                                                docChangeAttribute.ImpactXML = true; // no impact to SPF though
                                            }

                                            if (!docAttribute.DefinedType.Equals(docAttributeBase.DefinedType))
                                            {
                                                DocChangeAspect docAspect = new DocChangeAspect(DocChangeAspectEnum.TYPE, docAttributeBase.DefinedType, docAttribute.DefinedType);
                                                docChangeAttribute.Aspects.Add(docAspect);
                                                docChangeAttribute.Action = DocChangeActionEnum.MODIFIED;

                                                // check for compatibility
                                                // assume incompatible unless we can prove types are compatible
                                                bool impact = true;

                                                // ok if new type is a supertype of the old type
                                                DocObject docNew = null;
                                                if (mapNew.TryGetValue(docAspect.NewValue, out docNew))
                                                {
                                                    DocObject docOld = null;
                                                    if (mapOld.TryGetValue(docAspect.OldValue, out docOld))
                                                    {
                                                        if (docNew is DocEntity)
                                                        {
                                                            DocEntity docNewEnt = (DocEntity)docNew;

                                                            if (docOld is DocEntity)
                                                            {
                                                                DocEntity docOldEnt = (DocEntity)docOld;

                                                                while (docNewEnt != null)
                                                                {
                                                                    if (docNewEnt.Name.Equals(docOldEnt.Name))
                                                                    {
                                                                        impact = false; // subtype
                                                                    }

                                                                    if (docNewEnt.BaseDefinition != null)
                                                                    {
                                                                        docNewEnt = mapNew[docNewEnt.BaseDefinition] as DocEntity;
                                                                    }
                                                                    else
                                                                    {
                                                                        docNewEnt = null;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (docNew is DocSelect)
                                                        {
                                                            DocSelect docNewSelect = (DocSelect)docNew;
                                                            foreach (DocSelectItem docNewSelectItem in docNewSelect.Selects)
                                                            {
                                                                if (docNewSelectItem.Name.Equals(docOld.Name))
                                                                {
                                                                    impact = false; // included in select
                                                                }
                                                            }
                                                        }
                                                        else if (docNew is DocEnumeration)
                                                        {
                                                            // ok if new enumeration contains all of old enumerations (e.g. IfcInternalOrExternalEnum -> IfcSpaceTypeEnum)                                                            
                                                            DocEnumeration docNewEnum = (DocEnumeration)docNew;
                                                            if (docOld is DocEnumeration)
                                                            {
                                                                impact = false;

                                                                DocEnumeration docOldEnum = (DocEnumeration)docOld;
                                                                foreach (DocConstant docOldConstant in docOldEnum.Constants)
                                                                {
                                                                    bool match = false;
                                                                    foreach (DocConstant docNewConstant in docNewEnum.Constants)
                                                                    {
                                                                        if (docOldConstant.Name.Equals(docNewConstant.Name))
                                                                        {
                                                                            match = true;
                                                                            break;
                                                                        }
                                                                    }

                                                                    if (!match)
                                                                    {
                                                                        impact = true;
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (docNew is DocDefined)
                                                        {
                                                            DocDefined docNewDefined = (DocDefined)docNew;

                                                            // compare underlying types
                                                            if (docOld is DocDefined)
                                                            {
                                                                DocDefined docOldDefined = (DocDefined)docOld;

                                                                if (docNewDefined.DefinedType.Equals(docOldDefined.DefinedType))
                                                                {
                                                                    // e.g. IfcLabel -> IfcIdentifier
                                                                    impact = false;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                docChangeAttribute.ImpactSPF = impact;
                                                docChangeAttribute.ImpactXML = impact;
                                            }

                                            if (docAttribute.AttributeFlags != docAttributeBase.AttributeFlags)
                                            {
                                                docChangeAttribute.Action = DocChangeActionEnum.MODIFIED;

                                                if ((docAttributeBase.AttributeFlags & 1) != 0)
                                                {
                                                    docChangeAttribute.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.INSTANTIATION, "OPTIONAL", null));
                                                }
                                                else
                                                {
                                                    docChangeAttribute.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.INSTANTIATION, null, "OPTIONAL"));
                                                }
                                            }

                                            if (docAttribute.AggregationType != docAttributeBase.AggregationType)
                                            {
                                                docChangeAttribute.Action = DocChangeActionEnum.MODIFIED;
                                                docChangeAttribute.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.AGGREGATION, docAttributeBase.GetAggregation().ToString(), docAttribute.GetAggregation().ToString()));
                                            }
                                        }
                                    }

                                    // report deleted attributes
                                    for (int iAttribute = listAttributeNew.Count; iAttribute < listAttributeOld.Count; iAttribute++)
                                    {
                                        DocAttribute docAttributeBase = listAttributeOld[iAttribute];

                                        DocChangeAction docChangeAttribute = new DocChangeAction();
                                        docChangeEntity.Changes.Add(docChangeAttribute);
                                        docChangeAttribute.Name = docAttributeBase.Name;
                                        docChangeAttribute.Action = DocChangeActionEnum.DELETED;
                                        docChangeAttribute.ImpactSPF = true;

                                        // deleted attributes don't affect XML
                                    }
                                }
                            }
                        }

                        // now find deleted entities
                        foreach (DocEntity docEntityBase in docSchemaBase.Entities)
                        {
                            // find equivalent
                            DocEntity docEntity = null;
                            foreach (DocEntity docEntityEach in docSchema.Entities)
                            {
                                if (docEntityEach.Name.Equals(docEntityBase.Name))
                                {
                                    docEntity = docEntityEach;
                                    break;
                                }
                            }

                            if (docEntity == null)
                            {
                                // entity may have moved to other schema; check other schemas
                                DocSchema docThatSchema = null;
                                foreach (DocSection docOtherSection in this.m_project.Sections)
                                {
                                    foreach (DocSchema docOtherSchema in docOtherSection.Schemas)
                                    {
                                        foreach (DocEntity docOtherEntity in docOtherSchema.Entities)
                                        {
                                            if (docOtherEntity.Name.Equals(docEntityBase.Name))
                                            {
                                                docEntity = docOtherEntity;
                                                docThatSchema = docOtherSchema;
                                            }
                                        }
                                    }
                                }

                                DocChangeAction docChangeEntity = new DocChangeAction();
                                docChangeSchema.Changes.Add(docChangeEntity);
                                docChangeEntity.Name = docEntityBase.Name;

                                if (docEntity != null)
                                {
                                    // moved from another schema
                                    docChangeEntity.Action = DocChangeActionEnum.MOVED;
                                    docChangeEntity.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.SCHEMA, docSchema.Name.ToUpper(), docThatSchema.Name.ToUpper()));
                                }
                                else
                                {
                                    // otherwise, deleted
                                    docChangeEntity.Action = DocChangeActionEnum.DELETED;

                                    // if non-abstract, it impacts file
                                    if (!docEntityBase.IsAbstract())
                                    {
                                        docChangeEntity.ImpactSPF = true;
                                        docChangeEntity.ImpactXML = true;
                                    }
                                }
                            }
                        }

                        // property sets
                        foreach (DocPropertySet docPset in docSchema.PropertySets)
                        {
                            DocChangeAction docChangePset = new DocChangeAction();
                            docChangeSchemaProperties.Changes.Add(docChangePset);
                            docChangePset.Name = docPset.Name;

                            // find equivalent pset
                            DocPropertySet docPsetBase = null;
                            foreach (DocPropertySet docEntityEach in docSchemaBase.PropertySets)
                            {
                                if (docEntityEach.Name.Equals(docPset.Name))
                                {
                                    docPsetBase = docEntityEach;
                                    break;
                                }
                            }

                            if (docPsetBase == null)
                            {
                                // new entity
                                docChangePset.Action = DocChangeActionEnum.ADDED;

                                // check if it was moved from another schema                                
                                foreach (DocSection docOtherSection in docProjectBase.Sections)
                                {
                                    foreach (DocSchema docOtherSchema in docOtherSection.Schemas)
                                    {
                                        foreach (DocPropertySet docOtherPset in docOtherSchema.PropertySets)
                                        {
                                            if (docOtherPset.Name.Equals(docPset.Name))
                                            {
                                                docPsetBase = docOtherPset; // still compare attributes if moved (e.g. IfcRelSequence)

                                                docChangePset.Action = DocChangeActionEnum.MOVED;
                                                docChangePset.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.SCHEMA, docOtherSchema.Name.ToUpper(), docSchema.Name.ToUpper()));
                                            }
                                        }
                                    }
                                }

                            }

                            if (docPsetBase != null)
                            {
                                // existing entity

                                // compare abstract vs. non-abstract
                                if (docPset.ApplicableType != docPsetBase.ApplicableType)
                                {
                                    docChangePset.Action = DocChangeActionEnum.MODIFIED;
                                    docChangePset.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.INSTANTIATION, docPsetBase.ApplicableType, docPset.ApplicableType));
                                }

                                // compare attributes by index

                                // only report non-abstract entities; e.g. attributes may be demoted without file impact
                                

                                foreach (DocProperty docAttribute in docPset.Properties)
                                {
                                    // we only care about direct attributes
                                    DocChangeAction docChangeAttribute = new DocChangeAction();
                                    docChangePset.Changes.Add(docChangeAttribute);
                                    docChangeAttribute.Name = docAttribute.Name;

                                    DocProperty docAttributeBase = null;
                                    foreach (DocProperty docEachProperty in docPsetBase.Properties)
                                    {
                                        if (docEachProperty.Name.Equals(docAttribute.Name))
                                        {
                                            docAttributeBase = docEachProperty;
                                            break;
                                        }
                                    }

                                    if (docAttributeBase == null)
                                    {
                                        // new attribute added
                                        docChangeAttribute.Action = DocChangeActionEnum.ADDED;
                                    }
                                    else
                                    {
                                        // compare for changes
                                        if (!docAttribute.PropertyType.Equals(docAttributeBase.PropertyType))
                                        {
                                            DocChangeAspect docAspect = new DocChangeAspect(DocChangeAspectEnum.INSTANTIATION, docAttributeBase.PropertyType.ToString(), docAttribute.PropertyType.ToString());
                                            docChangeAttribute.Aspects.Add(docAspect);
                                            docChangeAttribute.Action = DocChangeActionEnum.MODIFIED;
                                        }

                                        if (!docAttribute.PrimaryDataType.Trim().Equals(docAttributeBase.PrimaryDataType.Trim()))
                                        {
                                            DocChangeAspect docAspect = new DocChangeAspect(DocChangeAspectEnum.TYPE, docAttributeBase.PrimaryDataType, docAttribute.PrimaryDataType);
                                            docChangeAttribute.Aspects.Add(docAspect);
                                            docChangeAttribute.Action = DocChangeActionEnum.MODIFIED;
                                        }
                                    }
                                }

                                // report deleted properties
                                foreach(DocProperty docAttributeBase in docPsetBase.Properties)
                                {
                                    DocProperty docAttribute = null;
                                    foreach (DocProperty docEachProperty in docPset.Properties)
                                    {
                                        if (docEachProperty.Name.Equals(docAttributeBase.Name))
                                        {
                                            docAttribute = docEachProperty;
                                            break;
                                        }
                                    }

                                    if(docAttribute == null)
                                    {
                                        DocChangeAction docChangeAttribute = new DocChangeAction();
                                        docChangePset.Changes.Add(docChangeAttribute);
                                        docChangeAttribute.Name = docAttributeBase.Name;
                                        docChangeAttribute.Action = DocChangeActionEnum.DELETED;
                                    }
                                }
                            }
                            
                        }                            
                        
                        // now find deleted psets
                        foreach (DocPropertySet docEntityBase in docSchemaBase.PropertySets)
                        {
                            // find equivalent
                            DocPropertySet docEntity = null;
                            foreach (DocPropertySet docEntityEach in docSchema.PropertySets)
                            {
                                if (docEntityEach.Name.Equals(docEntityBase.Name))
                                {
                                    docEntity = docEntityEach;
                                    break;
                                }
                            }

                            if (docEntity == null)
                            {
                                // entity may have moved to other schema; check other schemas
                                DocSchema docThatSchema = null;
                                foreach (DocSection docOtherSection in this.m_project.Sections)
                                {
                                    foreach (DocSchema docOtherSchema in docOtherSection.Schemas)
                                    {
                                        foreach (DocPropertySet docOtherEntity in docOtherSchema.PropertySets)
                                        {
                                            if (docOtherEntity.Name.Equals(docEntityBase.Name))
                                            {
                                                docEntity = docOtherEntity;
                                                docThatSchema = docOtherSchema;
                                            }
                                        }
                                    }
                                }

                                DocChangeAction docChangeEntity = new DocChangeAction();
                                docChangeSchemaProperties.Changes.Add(docChangeEntity);
                                docChangeEntity.Name = docEntityBase.Name;

                                if (docEntity != null)
                                {
                                    // moved from another schema
                                    docChangeEntity.Action = DocChangeActionEnum.MOVED;
                                    docChangeEntity.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.SCHEMA, docSchema.Name.ToUpper(), docThatSchema.Name.ToUpper()));
                                }
                                else
                                {
                                    // otherwise, deleted
                                    docChangeEntity.Action = DocChangeActionEnum.DELETED;
                                }
                            }
                        }
                        // end property sets


                        // quantity sets
                        foreach (DocQuantitySet docQset in docSchema.QuantitySets)
                        {
                            DocChangeAction docChangeQset = new DocChangeAction();
                            docChangeSchemaQuantities.Changes.Add(docChangeQset);
                            docChangeQset.Name = docQset.Name;

                            // find equivalent pset
                            DocQuantitySet docQsetBase = null;
                            foreach (DocQuantitySet docEntityEach in docSchemaBase.QuantitySets)
                            {
                                if (docEntityEach.Name.Equals(docQset.Name))
                                {
                                    docQsetBase = docEntityEach;
                                    break;
                                }
                            }

                            if (docQsetBase == null)
                            {
                                // new entity
                                docChangeQset.Action = DocChangeActionEnum.ADDED;

                                // check if it was moved from another schema                                
                                foreach (DocSection docOtherSection in docProjectBase.Sections)
                                {
                                    foreach (DocSchema docOtherSchema in docOtherSection.Schemas)
                                    {
                                        foreach (DocQuantitySet docOtherQset in docOtherSchema.QuantitySets)
                                        {
                                            if (docOtherQset.Name.Equals(docQset.Name))
                                            {
                                                docQsetBase = docOtherQset; // still compare attributes if moved (e.g. IfcRelSequence)

                                                docChangeQset.Action = DocChangeActionEnum.MOVED;
                                                docChangeQset.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.SCHEMA, docOtherSchema.Name.ToUpper(), docSchema.Name.ToUpper()));
                                            }
                                        }
                                    }
                                }

                            }

                            if (docQsetBase != null)
                            {
                                // existing entity

                                // compare abstract vs. non-abstract
                                if (docQset.ApplicableType != docQsetBase.ApplicableType)
                                {
                                    docChangeQset.Action = DocChangeActionEnum.MODIFIED;
                                    docChangeQset.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.INSTANTIATION, docQsetBase.ApplicableType, docQset.ApplicableType));
                                }

                                // compare attributes by index

                                // only report non-abstract entities; e.g. attributes may be demoted without file impact


                                foreach (DocQuantity docAttribute in docQset.Quantities)
                                {
                                    // we only care about direct attributes
                                    DocChangeAction docChangeAttribute = new DocChangeAction();
                                    docChangeQset.Changes.Add(docChangeAttribute);
                                    docChangeAttribute.Name = docAttribute.Name;

                                    DocQuantity docAttributeBase = null;
                                    foreach (DocQuantity docEachProperty in docQsetBase.Quantities)
                                    {
                                        if (docEachProperty.Name.Equals(docAttribute.Name))
                                        {
                                            docAttributeBase = docEachProperty;
                                            break;
                                        }
                                    }

                                    if (docAttributeBase == null)
                                    {
                                        // new attribute added
                                        docChangeAttribute.Action = DocChangeActionEnum.ADDED;
                                    }
                                    else
                                    {
                                        // compare for changes
                                        if (!docAttribute.QuantityType.Equals(docAttributeBase.QuantityType))
                                        {
                                            DocChangeAspect docAspect = new DocChangeAspect(DocChangeAspectEnum.INSTANTIATION, docAttributeBase.QuantityType.ToString(), docAttribute.QuantityType.ToString());
                                            docChangeAttribute.Aspects.Add(docAspect);
                                            docChangeAttribute.Action = DocChangeActionEnum.MODIFIED;
                                        }
                                    }
                                }

                                // report deleted quantities
                                foreach (DocQuantity docAttributeBase in docQsetBase.Quantities)
                                {
                                    DocQuantity docAttribute = null;
                                    foreach (DocQuantity docEachQuantity in docQset.Quantities)
                                    {
                                        if (docEachQuantity.Name.Equals(docAttributeBase.Name))
                                        {
                                            docAttribute = docEachQuantity;
                                            break;
                                        }
                                    }

                                    if (docAttribute == null)
                                    {
                                        DocChangeAction docChangeAttribute = new DocChangeAction();
                                        docChangeQset.Changes.Add(docChangeAttribute);
                                        docChangeAttribute.Name = docAttributeBase.Name;
                                        docChangeAttribute.Action = DocChangeActionEnum.DELETED;
                                    }
                                }
                            }

                        }

                        // now find deleted qsets
                        foreach (DocQuantitySet docEntityBase in docSchemaBase.QuantitySets)
                        {
                            // find equivalent
                            DocQuantitySet docEntity = null;
                            foreach (DocQuantitySet docEntityEach in docSchema.QuantitySets)
                            {
                                if (docEntityEach.Name.Equals(docEntityBase.Name))
                                {
                                    docEntity = docEntityEach;
                                    break;
                                }
                            }

                            if (docEntity == null)
                            {
                                // entity may have moved to other schema; check other schemas
                                DocSchema docThatSchema = null;
                                foreach (DocSection docOtherSection in this.m_project.Sections)
                                {
                                    foreach (DocSchema docOtherSchema in docOtherSection.Schemas)
                                    {
                                        foreach (DocQuantitySet docOtherEntity in docOtherSchema.QuantitySets)
                                        {
                                            if (docOtherEntity.Name.Equals(docEntityBase.Name))
                                            {
                                                docEntity = docOtherEntity;
                                                docThatSchema = docOtherSchema;
                                            }
                                        }
                                    }
                                }

                                DocChangeAction docChangeEntity = new DocChangeAction();
                                docChangeSchemaQuantities.Changes.Add(docChangeEntity);
                                docChangeEntity.Name = docEntityBase.Name;

                                if (docEntity != null)
                                {
                                    // moved from another schema
                                    docChangeEntity.Action = DocChangeActionEnum.MOVED;
                                    docChangeEntity.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.SCHEMA, docSchema.Name.ToUpper(), docThatSchema.Name.ToUpper()));
                                }
                                else
                                {
                                    // otherwise, deleted
                                    docChangeEntity.Action = DocChangeActionEnum.DELETED;
                                }
                            }
                        }
                        // end quantity sets

                    }
                }

                foreach (DocSchema docSchemaBase in docSectionBase.Schemas)
                {
                    // find equivalent schema
                    DocSchema docSchema = null;
                    foreach (DocSchema docSchemaEach in docSection.Schemas)
                    {
                        if (docSchemaEach.Name.Equals(docSchemaBase.Name))
                        {
                            docSchema = docSchemaEach;
                            break;
                        }
                    }

                    if (docSchema == null)
                    {
                        DocChangeAction docChangeSchema = new DocChangeAction();
                        docChangeSchema.Name = docSchemaBase.Name;
                        docChangeSchema.Action = DocChangeActionEnum.DELETED;
                        docChangeSection.Changes.Add(docChangeSchema);

                        // list all deleted types
                        foreach (DocType docTypeBase in docSchemaBase.Types)
                        {
                            DocChangeAction docChangeType = new DocChangeAction();
                            docChangeSchema.Changes.Add(docChangeType);
                            docChangeType.Name = docTypeBase.Name;

                            // each entity either moved or deleted

                            // entity may have moved to other schema; check other schemas
                            DocSchema docThatSchema = null;
                            foreach (DocSection docOtherSection in this.m_project.Sections)
                            {
                                foreach (DocSchema docOtherSchema in docOtherSection.Schemas)
                                {
                                    foreach (DocType docOtherType in docOtherSchema.Types)
                                    {
                                        if (docOtherType.Name.Equals(docTypeBase.Name))
                                        {
                                            docThatSchema = docOtherSchema;
                                        }
                                    }
                                }
                            }

                            if (docThatSchema != null)
                            {
                                docChangeType.Action = DocChangeActionEnum.MOVED;
                                docChangeType.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.SCHEMA, docSchemaBase.Name, docThatSchema.Name));
                            }
                            else
                            {
                                docChangeType.Action = DocChangeActionEnum.DELETED;

                                // deleting a type does not impact file
                            }
                        }


                        // list all deleted entities
                        foreach (DocEntity docEntityBase in docSchemaBase.Entities)
                        {
                            DocChangeAction docChangeEntity = new DocChangeAction();
                            docChangeSchema.Changes.Add(docChangeEntity);
                            docChangeEntity.Name = docEntityBase.Name;

                            // each entity either moved or deleted

                            // entity may have moved to other schema; check other schemas
                            DocSchema docThatSchema = null;
                            foreach (DocSection docOtherSection in this.m_project.Sections)
                            {
                                foreach (DocSchema docOtherSchema in docOtherSection.Schemas)
                                {
                                    foreach (DocEntity docOtherEntity in docOtherSchema.Entities)
                                    {
                                        if (docOtherEntity.Name.Equals(docEntityBase.Name))
                                        {
                                            docThatSchema = docOtherSchema;
                                        }
                                    }
                                }
                            }

                            if (docThatSchema != null)
                            {
                                docChangeEntity.Action = DocChangeActionEnum.MOVED;
                                docChangeEntity.Aspects.Add(new DocChangeAspect(DocChangeAspectEnum.SCHEMA, docSchemaBase.Name, docThatSchema.Name));
                            }
                            else
                            {
                                docChangeEntity.Action = DocChangeActionEnum.DELETED;
                                docChangeEntity.ImpactSPF = true;
                                docChangeEntity.ImpactXML = true;
                            }
                        }
                    }
                }

            }

            this.LoadTree();

        }

        private void MoveSelection(int direction)
        {
            TreeNode tn = this.treeView.SelectedNode;
            TreeNode tnParent = tn.Parent;
            int treeindex = tnParent.Nodes.IndexOf(tn);

            if (tn.Tag is DocTemplateUsage)
            {
                DocTemplateUsage docUsage = (DocTemplateUsage)tn.Tag;
                DocConceptRoot docRoot = (DocConceptRoot)tnParent.Tag;
                int index = docRoot.Concepts.IndexOf(docUsage);

                index += direction;
                treeindex += direction;

                docRoot.Concepts.Remove(docUsage);
                docRoot.Concepts.Insert(index, docUsage);

                tnParent.Nodes.Remove(tn);
                tnParent.Nodes.Insert(treeindex, tn);
            }
            else if (tn.Tag is DocTemplateDefinition)
            {
                DocTemplateDefinition docUsage = (DocTemplateDefinition)tn.Tag;
                if (tn.Parent.Tag is DocTemplateDefinition)
                {
                    DocTemplateDefinition docEntity = (DocTemplateDefinition)tnParent.Tag;
                    int index = docEntity.Templates.IndexOf(docUsage);

                    index += direction;
                    treeindex += direction;

                    docEntity.Templates.Remove(docUsage);
                    docEntity.Templates.Insert(index, docUsage);

                    tnParent.Nodes.Remove(tn);
                    tnParent.Nodes.Insert(treeindex, tn);
                }
                else
                {
                    // top-level
                    int index = this.m_project.Templates.IndexOf(docUsage);

                    index += direction;
                    treeindex += direction;

                    this.m_project.Templates.Remove(docUsage);
                    this.m_project.Templates.Insert(index, docUsage);

                    tnParent.Nodes.Remove(tn);
                    tnParent.Nodes.Insert(treeindex, tn);
                }
            }
            else if (tn.Tag is DocModelView)
            {
                DocModelView docUsage = (DocModelView)tn.Tag;
                int index = this.m_project.ModelViews.IndexOf(docUsage);

                index += direction;
                treeindex += direction;

                this.m_project.ModelViews.Remove(docUsage);
                this.m_project.ModelViews.Insert(index, docUsage);

                tnParent.Nodes.Remove(tn);
                tnParent.Nodes.Insert(treeindex, tn);
            }
            else if (tn.Tag is DocExchangeDefinition)
            {
                DocExchangeDefinition docUsage = (DocExchangeDefinition)tn.Tag;
                if (tn.Parent.Tag is DocModelView)
                {
                    DocModelView docEntity = (DocModelView)tnParent.Tag;
                    int index = docEntity.Exchanges.IndexOf(docUsage);

                    index += direction;
                    treeindex += direction;

                    docEntity.Exchanges.Remove(docUsage);
                    docEntity.Exchanges.Insert(index, docUsage);

                    tnParent.Nodes.Remove(tn);
                    tnParent.Nodes.Insert(treeindex, tn);
                }

            }
            else if (tn.Tag is DocPropertySet)
            {
                DocPropertySet docProp = (DocPropertySet)tn.Tag;
                if (tn.Parent.Parent.Tag is DocSchema)
                {
                    DocSchema docSchema = (DocSchema)tnParent.Parent.Tag;
                    int index = docSchema.PropertySets.IndexOf(docProp);

                    index += direction;
                    treeindex += direction;

                    docSchema.PropertySets.Remove(docProp);
                    docSchema.PropertySets.Insert(index, docProp);

                    tnParent.Nodes.Remove(tn);
                    tnParent.Nodes.Insert(treeindex, tn);
                }
            }
            else if (tn.Tag is DocProperty)
            {
                DocProperty docProp = (DocProperty)tn.Tag;
                if (tn.Parent.Tag is DocPropertySet)
                {
                    DocPropertySet docSchema = (DocPropertySet)tnParent.Tag;
                    int index = docSchema.Properties.IndexOf(docProp);

                    index += direction;
                    treeindex += direction;

                    docSchema.Properties.Remove(docProp);
                    docSchema.Properties.Insert(index, docProp);

                    tnParent.Nodes.Remove(tn);
                    tnParent.Nodes.Insert(treeindex, tn);
                }
            }
            else if (tn.Tag is DocQuantitySet)
            {
                DocQuantitySet docProp = (DocQuantitySet)tn.Tag;
                if (tn.Parent.Parent.Tag is DocSchema)
                {
                    DocSchema docSchema = (DocSchema)tnParent.Parent.Tag;
                    int index = docSchema.QuantitySets.IndexOf(docProp);

                    index += direction;
                    treeindex += direction;

                    docSchema.QuantitySets.Remove(docProp);
                    docSchema.QuantitySets.Insert(index, docProp);

                    tnParent.Nodes.Remove(tn);
                    tnParent.Nodes.Insert(treeindex, tn);
                }
            }
            else if(tn.Tag is DocConstant)
            {
                DocConstant docConst = (DocConstant)tn.Tag;
                DocEnumeration docEnum = (DocEnumeration)tnParent.Tag;
                int index = docEnum.Constants.IndexOf(docConst);
                index += direction;
                treeindex += direction;
                tnParent.Nodes.Remove(tn);
                tnParent.Nodes.Insert(treeindex, tn);
            }
            else if (tn.Tag is DocQuantity)
            {
                DocQuantity docProp = (DocQuantity)tn.Tag;
                if (tn.Parent.Tag is DocQuantitySet)
                {
                    DocQuantitySet docSchema = (DocQuantitySet)tnParent.Tag;
                    int index = docSchema.Quantities.IndexOf(docProp);

                    index += direction;
                    treeindex += direction;

                    docSchema.Quantities.Remove(docProp);
                    docSchema.Quantities.Insert(index, docProp);

                    tnParent.Nodes.Remove(tn);
                    tnParent.Nodes.Insert(treeindex, tn);
                }
            }
            else if (tn.Tag is DocExample)
            {
                DocExample docUsage = (DocExample)tn.Tag;
                if (tn.Parent.Tag is DocExample)
                {
                    DocExample docEntity = (DocExample)tnParent.Tag;
                    int index = docEntity.Examples.IndexOf(docUsage);

                    index += direction;
                    treeindex += direction;

                    docEntity.Examples.Remove(docUsage);
                    docEntity.Examples.Insert(index, docUsage);

                    tnParent.Nodes.Remove(tn);
                    tnParent.Nodes.Insert(treeindex, tn);
                }
                else
                {
                    // top-level
                    int index = this.m_project.Examples.IndexOf(docUsage);

                    index += direction;
                    treeindex += direction;

                    this.m_project.Examples.Remove(docUsage);
                    this.m_project.Examples.Insert(index, docUsage);

                    tnParent.Nodes.Remove(tn);
                    tnParent.Nodes.Insert(treeindex, tn);
                }
            }

            this.treeView.SelectedNode = tn;
        }

        private void ToolStripMenuItemEditCut_Click(object sender, EventArgs e)
        {
            if (this.treeView.Focused)
            {
                this.m_clipboard = this.treeView.SelectedNode.Tag as DocObject;
                this.toolStripMenuItemEditDelete_Click(sender, e);
            }
        }

        private void toolStripMenuItemEditCopy_Click(object sender, EventArgs e)
        {
            if (this.treeView.Focused)
            {
                this.m_clipboard = this.treeView.SelectedNode.Tag as DocObject;

                this.TreeView_AfterSelect(sender, new TreeViewEventArgs(this.treeView.SelectedNode, TreeViewAction.Unknown));
            }
        }

        private void toolStripMenuItemEditPaste_Click(object sender, EventArgs e)
        {
            if (this.treeView.Focused)
            {
                DocObject docSelect = this.treeView.SelectedNode.Tag as DocObject;
                if (docSelect is DocConceptRoot && this.m_clipboard is DocTemplateUsage)
                {
                    DocConceptRoot docRoot = (DocConceptRoot)docSelect;

                    DocTemplateUsage docSource = (DocTemplateUsage)this.m_clipboard;
                    DocTemplateUsage docTarget = new DocTemplateUsage();

                    docRoot.Concepts.Add(docTarget);
                    docTarget.Name = docSource.Name;
                    docTarget.Documentation = docSource.Documentation;
                    docTarget.Author = docSource.Author;
                    docTarget.Copyright = docSource.Copyright;
                    docTarget.Owner = docSource.Owner;
                    docTarget.Definition = docSource.Definition;

                    foreach (DocTemplateItem docSourceItem in docSource.Items)
                    {
                        DocTemplateItem docTargetItem = new DocTemplateItem();
                        docTarget.Items.Add(docTargetItem);

                        docTargetItem.Name = docSourceItem.Name;
                        docTargetItem.Documentation = docSourceItem.Documentation;
                        docTargetItem.RuleInstanceID = docSourceItem.RuleInstanceID;
                        docTargetItem.RuleParameters = docSourceItem.RuleParameters;
                    }

                    this.treeView.SelectedNode = LoadNode(this.treeView.SelectedNode, docTarget, docTarget.Name, false);
                }
                else if (docSelect is DocModelView && this.m_clipboard is DocExchangeDefinition)
                {
                    DocModelView docView = (DocModelView)docSelect;
                    DocExchangeDefinition docSource = (DocExchangeDefinition)this.m_clipboard;
                    DocExchangeDefinition docTarget = new DocExchangeDefinition();

                    docView.Exchanges.Add(docTarget);
                    docTarget.Name = docSource.Name;
                    docTarget.Documentation = docSource.Documentation;
                    docTarget.Author = docSource.Author;
                    docTarget.Copyright = docSource.Copyright;
                    docTarget.Owner = docSource.Owner;
                    docTarget.Icon = docSource.Icon;

                    // copy entity requirements if in same view
                    if (docView.Exchanges.Contains(docSource))
                    {
                        foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                        {
                            foreach (DocTemplateUsage docConcept in docRoot.Concepts)
                            {
                                List<DocExchangeItem> listNew = new List<DocExchangeItem>();

                                foreach (DocExchangeItem docSourceER in docConcept.Exchanges)
                                {
                                    if (docSourceER.Exchange == docSource)
                                    {
                                        DocExchangeItem docTargetER = new DocExchangeItem();
                                        docTargetER.Exchange = docTarget;
                                        docTargetER.Applicability = docSourceER.Applicability;
                                        docTargetER.Requirement = docSourceER.Requirement;

                                        listNew.Add(docTargetER);
                                    }
                                }

                                foreach (DocExchangeItem docTargetER in listNew)
                                {
                                    docConcept.Exchanges.Add(docTargetER);
                                }
                            }
                        }
                    }

                    this.treeView.SelectedNode = LoadNode(this.treeView.SelectedNode, docTarget, docTarget.Name, false);
                }
            }
        }

        private void ToolStripButtonEditCut_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemEditCut_Click(sender, e);
        }

        private void ToolStripButtonEditCopy_Click(object sender, EventArgs e)
        {
            toolStripMenuItemEditCopy_Click(sender, e);
        }

        private void ToolStripButtonEditPaste_Click(object sender, EventArgs e)
        {
            toolStripMenuItemEditPaste_Click(sender, e);
        }

        private void toolStripMenuItemInsertPropertyset_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeView.SelectedNode;
            if (tn.Parent.Tag is DocSchema)
            {
                tn = tn.Parent;
            }
            DocSchema docSchema = (DocSchema)tn.Tag;
            DocPropertySet docPset = new DocPropertySet();
            docSchema.PropertySets.Add(docPset);
            this.treeView.SelectedNode = this.LoadNode(tn.Nodes[4], docPset, docPset.Name, true);
            this.toolStripMenuItemEditRename_Click(sender, e);
        }

        private void toolStripMenuItemInsertProperty_Click(object sender, EventArgs e)
        {
            DocPropertySet docPset = (DocPropertySet)this.treeView.SelectedNode.Tag;
            DocProperty docProp = new DocProperty();
            docPset.Properties.Add(docProp);
            this.treeView.SelectedNode = this.LoadNode(this.treeView.SelectedNode, docProp, docProp.Name, false);
            this.toolStripMenuItemEditRename_Click(sender, e);
        }

        private void toolStripMenuItemInsertQuantityset_Click(object sender, EventArgs e)
        {
            DocSchema docSchema = (DocSchema)this.treeView.SelectedNode.Tag;
            DocQuantitySet docPset = new DocQuantitySet();
            docSchema.QuantitySets.Add(docPset);
            this.treeView.SelectedNode = this.LoadNode(this.treeView.SelectedNode.Nodes[5], docPset, docPset.Name, true);
            this.toolStripMenuItemEditRename_Click(sender, e);
        }

        private void toolStripMenuItemInsertQuantity_Click(object sender, EventArgs e)
        {
            DocQuantitySet docPset = (DocQuantitySet)this.treeView.SelectedNode.Tag;
            DocQuantity docProp = new DocQuantity();
            docPset.Quantities.Add(docProp);
            this.treeView.SelectedNode = this.LoadNode(this.treeView.SelectedNode, docProp, docProp.Name, false);
            this.toolStripMenuItemEditRename_Click(sender, e);
        }

        private void toolStripMenuItemInsertConceptRoot_Click(object sender, EventArgs e)
        {
            DocEntity docEntity = (DocEntity)this.treeView.SelectedNode.Tag;

            // pick the model view definition...
            using (FormSelectView form = new FormSelectView(this.m_project))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.Selection != null)
                {
                    DocConceptRoot docConceptRoot = new DocConceptRoot();
                    docConceptRoot.ApplicableEntity = docEntity;
                    form.Selection.ConceptRoots.Add(docConceptRoot);

                    // update tree
                    this.treeView.SelectedNode = this.LoadNode(this.treeView.SelectedNode, docConceptRoot, form.Selection.Name, false);
                }
            }

        }


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<long, SEntity> old = this.m_instances;
            long lid = this.m_lastid;

            try
            {
                // build dictionary to map IFC type name to entity and schema                
                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();

                // build dictionary to map IFC type name to schema
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();

                this.BuildMaps(mapEntity, mapSchema);

                string path = Properties.Settings.Default.OutputPath;

                // swap out instances such that constructors go to different cache
                this.m_instances = new Dictionary<long, SEntity>();
                this.m_lastid = 0;

                DocumentationISO.GenerateDocumentation(this.m_project, path, this.m_instances, mapEntity, mapSchema, this.m_filterviews, this.m_filterlocales, this.backgroundWorkerGenerate, this.m_formProgress);

                // launch the content
                System.Diagnostics.Process.Start(path + @"\index.htm");
            }
            catch (Exception ex)
            {
                this.m_exception = ex;
            }
            finally
            {
                this.m_instances = old;
                this.m_lastid = lid;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.m_formProgress.ReportProgress(e.ProgressPercentage, e.UserState);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_formProgress.Close();
        }

        private void toolStripMenuItemExportFolder_Click(object sender, EventArgs e)
        {
            DialogResult res = this.folderBrowserDialog.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                Dictionary<string, DocPropertyEnumeration> mapPropEnum = new Dictionary<string, DocPropertyEnumeration>();
                foreach (DocSection docSection in this.m_project.Sections)
                {
                    foreach (DocSchema docSchema in docSection.Schemas)
                    {
                        foreach (DocPropertyEnumeration docEnum in docSchema.PropertyEnums)
                        {
                            mapPropEnum.Add(docEnum.Name, docEnum);
                        }
                    }
                }

                try
                {
                    foreach (DocSection docSection in this.m_project.Sections)
                    {
                        foreach (DocSchema docSchema in docSection.Schemas)
                        {
                            foreach (DocPropertySet docPset in docSchema.PropertySets)
                            {
                                PropertySetDef psd = Program.ExportPsd(docPset, mapPropEnum);
                                string filename = System.IO.Path.Combine(this.folderBrowserDialog.SelectedPath, docPset.Name + ".xml");
                                using (FormatXML format = new FormatXML(filename, typeof(PropertySetDef)))//, PropertySetDef.DefaultNamespace))
                                {
                                    format.Instance = psd;
                                    format.Save();
                                }
                            }

                            foreach (DocQuantitySet docQset in docSchema.QuantitySets)
                            {
                                QtoSetDef qto = Program.ExportQto(docQset);
                                string filename = System.IO.Path.Combine(this.folderBrowserDialog.SelectedPath, docQset.Name + ".xml");
                                using (FormatXML format = new FormatXML(filename, typeof(QtoSetDef), QtoSetDef.DefaultNamespace))
                                {
                                    format.Instance = qto;
                                    format.Save();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error");
                }
            }
        }

        private void toolStripMenuItemInsertExample_Click(object sender, EventArgs e)
        {
            DocExample docExample = new DocExample();

            if (this.treeView.SelectedNode.Tag is DocExample)
            {
                DocExample docParent = (DocExample)this.treeView.SelectedNode.Tag;
                if (docParent.Examples == null)
                {
                    docParent.Examples = new List<DocExample>();
                }
                docParent.Examples.Add(docExample);

                TreeNode tn = LoadNode(this.treeView.SelectedNode, docExample, docExample.Name, true);
                this.treeView.SelectedNode = tn;
            }
            else
            {
                // top-level
                if (this.m_project.Examples == null)
                {
                    this.m_project.Examples = new List<DocExample>();
                }
                this.m_project.Examples.Add(docExample);

                TreeNode tn = LoadNode(this.treeView.Nodes[12], docExample, docExample.Name, true);
                this.treeView.SelectedNode = tn;
            }
            this.toolStripMenuItemEditRename_Click(sender, e);

            this.m_modified = true;
        }

        private void toolStripMenuItemEditMoveOut_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeView.SelectedNode;

            if (tn.Tag is DocTemplateDefinition)
            {
                DocTemplateDefinition docSource = (DocTemplateDefinition)tn.Tag;
                DocTemplateDefinition docTarget = (DocTemplateDefinition)tn.Parent.Tag;

                docTarget.Templates.Remove(docSource);

                if (tn.Parent.Parent.Tag is DocTemplateDefinition)
                {
                    // move to sub-level
                    DocTemplateDefinition docParent = (DocTemplateDefinition)tn.Parent.Parent.Tag;
                    int index = docParent.Templates.IndexOf(docTarget) + 1;
                    docParent.Templates.Insert(index, docSource);

                    TreeNode tnParent = tn.Parent;
                    tn.Remove();
                    tnParent.Parent.Nodes.Insert(index, tn);
                }
                else
                {
                    // move to top-level
                    int index = this.m_project.Templates.IndexOf(docTarget) + 1;
                    this.m_project.Templates.Insert(index, docSource);

                    TreeNode tnParent = tn.Parent;
                    TreeNode tnTarget = tn.Parent.Parent;

                    tn.Parent.Nodes.Remove(tn);
                    tnTarget.Nodes.Insert(index, tn);
                }
            }
            else if (tn.Tag is DocExample)
            {
                DocExample docSource = (DocExample)tn.Tag;
                DocExample docTarget = (DocExample)tn.Parent.Tag;

                docTarget.Examples.Remove(docSource);

                if (tn.Parent.Parent.Tag is DocExample)
                {
                    // move to sub-level
                    DocExample docParent = (DocExample)tn.Parent.Parent.Tag;
                    int index = docParent.Examples.IndexOf(docTarget) + 1;
                    docParent.Examples.Insert(index, docSource);

                    TreeNode tnParent = tn.Parent;
                    tn.Remove();
                    tnParent.Parent.Nodes.Insert(index, tn);
                }
                else
                {
                    // move to top-level
                    int index = this.m_project.Examples.IndexOf(docTarget) + 1;
                    this.m_project.Examples.Insert(index, docSource);

                    TreeNode tnParent = tn.Parent;
                    TreeNode tnTarget = tn.Parent.Parent;

                    tn.Parent.Nodes.Remove(tn);
                    tnTarget.Nodes.Insert(index, tn);
                }
            }

            this.treeView.SelectedNode = tn;
            this.m_modified = true;
        }

        private void toolStripMenuItemEditMoveIn_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeView.SelectedNode;
            TreeNode tnTarget = this.treeView.SelectedNode.Parent.Nodes[this.treeView.SelectedNode.Index - 1];

            if (tn.Tag is DocTemplateDefinition)
            {
                DocTemplateDefinition docSource = (DocTemplateDefinition)tn.Tag;
                DocTemplateDefinition docTarget = (DocTemplateDefinition)tn.Parent.Nodes[tn.Index - 1].Tag;

                // sub-template
                if (docSource.Rules != null && docSource.Rules.Count != 0)
                {
                    DialogResult res = MessageBox.Show(this, "Moving this template will reset any rules to match those of the new parent template. Are you sure you want to proceed?", "Move Template", MessageBoxButtons.OKCancel);
                    if (res != System.Windows.Forms.DialogResult.OK)
                        return;

                    docSource.Type = docTarget.Type;

                    // propagate rules
                    if (docSource.Rules == null)
                    {
                        docSource.Rules = new List<DocModelRule>();
                    }

                    docSource.Rules.Clear();
                    if (docTarget.Rules != null)
                    {
                        foreach (DocModelRule docRule in docTarget.Rules)
                        {
                            docSource.Rules.Add((DocModelRule)docRule.Clone());
                        }
                    }
                }


                if (tn.Parent.Tag is DocTemplateDefinition)
                {
                    // move from mid-level
                    DocTemplateDefinition docParent = (DocTemplateDefinition)tn.Parent.Tag;
                    docParent.Templates.Remove(docSource);
                    docTarget.Templates.Add(docSource);
                }
                else
                {
                    // move from top-level
                    this.m_project.Templates.Remove(docSource);
                    docTarget.Templates.Add(docSource);
                }
            }
            else if (tn.Tag is DocExample)
            {
                DocExample docSource = (DocExample)tn.Tag;
                DocExample docTarget = (DocExample)tn.Parent.Nodes[tn.Index - 1].Tag;

                if (tn.Parent.Tag is DocExample)
                {
                    // move from mid-level
                    DocExample docParent = (DocExample)tn.Parent.Tag;
                    docParent.Examples.Remove(docSource);
                    docTarget.Examples.Add(docSource);
                }
                else
                {
                    // move from top-level
                    this.m_project.Examples.Remove(docSource);
                    docTarget.Examples.Add(docSource);
                }
            }

            tn.Remove();
            tnTarget.Nodes.Add(tn);

            this.treeView.SelectedNode = tn;
            this.m_modified = true;
        }

        private void toolStripMenuItemEditMoveUp_Click(object sender, EventArgs e)
        {
            this.MoveSelection(-1);
        }

        private void toolStripMenuItemEditMoveDown_Click(object sender, EventArgs e)
        {
            this.MoveSelection(+1);
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = this.openFileDialogMerge.ShowDialog();
            if (res != DialogResult.OK)
                return;

            // load file into different context, compare
            this.m_loading = true;

            Dictionary<long, SEntity> instances = new Dictionary<long, SEntity>();
            using (FormatSPF format = new FormatSPF(this.openFileDialogMerge.FileName, SchemaDOC.Types, instances))
            {
                format.Load();
            }

            this.m_loading = false;

            // now import changes
            DocProject docProjectBase = null;
            foreach (SEntity o in instances.Values)
            {
                if (o is DocProject)
                {
                    docProjectBase = (DocProject)o;
                }
            }

            // create guid map for rapid lookup
            Dictionary<Guid, DocObject> mapGuid = new Dictionary<Guid, DocObject>();
            foreach (SEntity o in this.m_instances.Values)
            {
                if (o is DocObject)
                {
                    DocObject docObj = (DocObject)o;
                    try
                    {
                        mapGuid.Add(docObj.Uuid, docObj);
                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("Duplicate Guid: " + docObj.Uuid.ToString() + " - " + docObj.GetType().ToString() + " - " + docObj.Name);
                    }
                }
            }

            using (FormMerge formMerge = new FormMerge(mapGuid, docProjectBase))
            {
                formMerge.ShowDialog(this);
            }
        }

        private void treeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.treeView.SelectedNode = this.treeView.GetNodeAt(e.X, e.Y);
            }
        }

        private void toolStripMenuItemDownload_Click(object sender, EventArgs e)
        {
            using (FormDownload form = new FormDownload())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.LoadFile(form.LocalPath);
                    this.m_server = form.Url;
                    this.Text = this.m_server;
                }
            }
        }

        private void toolStripMenuItemPublish_Click(object sender, EventArgs e)
        {
            using (FormPublish form = new FormPublish())
            {
                form.LocalPath = this.m_file;
                if (this.m_server != null)
                {
                    form.Url = this.m_server;
                }

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.m_server = form.Url;
                    this.Text = this.m_server;
                }
            }
        }

        private void toolStripMenuItemToolsValidate_Click(object sender, EventArgs e)
        {
            DialogResult res = this.openFileDialogValidate.ShowDialog();
            if (res != DialogResult.OK)
                return;

            using (this.m_formProgress = new FormProgress())
            {
                this.m_formProgress.Text = "Validating File";
                this.m_formProgress.Description = "Validating file...";

                this.backgroundWorkerValidate.RunWorkerAsync();

                res = this.m_formProgress.ShowDialog();
                if (res != DialogResult.OK)
                {
                    this.backgroundWorkerValidate.CancelAsync();
                }
            }

            if (this.m_exception != null)
            {
                MessageBox.Show(this, this.m_exception.Message + "\r\n\r\n" + this.m_exception.StackTrace, "Error");
                this.m_exception = null;
            }

        }

        /// <summary>
        /// Appends result to string, returns boolean of pass or failure.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="pass"></param>
        /// <param name="count"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        private static bool AppendResult(StringBuilder sb, int pass, int count, DocExchangeRequirementEnum req)
        {
            switch (req)
            {
                case DocExchangeRequirementEnum.Mandatory:
                    if (pass == count)
                    {
                        sb.Append("+");
                        return true;
                    }
                    else
                    {
                        sb.Append("F");
                        return false;
                    }                    

                case DocExchangeRequirementEnum.Excluded:
                    if (pass != 0)
                    {
                        sb.Append("F");
                        return false;
                    }
                    else
                    {
                        sb.Append("+");
                        return true;
                    }                    

                case DocExchangeRequirementEnum.Optional:
                    if (pass == count)
                    {
                        sb.Append("+");
                    }
                    else
                    {
                        sb.Append("*");
                    }
                    return true;

                case DocExchangeRequirementEnum.NotRelevant:
                    sb.Append("-");
                    return true;
            }

            return false;
        }

        // checks template against older version (e.g. IFC2X3_FINAL) to see if it's supported
        // if it depends on any fields that didn't exist, then no.
        private bool IsConceptSupported(DocTemplateDefinition template, string schemaversion)
        {
            if (template.Rules == null)
                return true;

            // quick hack for now
            if (template.Name.Contains("Declaration") ||
                template.Name.Contains("Ports") ||
                template.Name.Contains("Classification") ||
                template.Name.Contains("Material Profile"))
            {
                return false;
            }

            /*
            foreach (DocModelRule rule in template.Rules)
            {
                if (rule is DocModelRuleAttribute)
                {

                }
            }*/

            return true;
        }

        private void backgroundWorkerValidate_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<DocObject, bool> included = null; //TODO: obtain from user selection

            // count active roots
            int progressTotal = 2;
            foreach (DocModelView docView in this.m_project.ModelViews)
            {
                if (included == null || included.ContainsKey(docView))
                {
                    progressTotal += docView.ConceptRoots.Count;
                }
            }
            this.m_formProgress.SetProgressTotal(progressTotal);
            int progress = 0;

            // build schema dynamically
            this.backgroundWorkerValidate.ReportProgress(++progress, "Compiling schema...");
            Dictionary<string, Type> typemap = new Dictionary<string, Type>();
            Type[] types = this.m_project.EmitTypes();
            foreach (Type t in types)
            {
                typemap.Add(t.Name.ToUpper(), t);
            }

            int grandtotallist = 0;
            int grandtotalpass = 0;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<table border=\"1\" >");
            sb.Append("<tr><th>Entity/Concept</th><th>Req</th><th>Errors</th><th>Count</th><th>Flag</th>");

            foreach (DocModelView docView in this.m_project.ModelViews)
            {
                if (included == null || included.ContainsKey(docView))
                {
                    for(int i = 0; i < docView.Exchanges.Count; i++)
                    {
                        DocExchangeDefinition docExchange = docView.Exchanges[i];
                        sb.Append("<th title=\"");
                        sb.Append(docExchange.Name);
                        sb.Append("\" >");
                        sb.Append(i+1);
                        sb.Append("</th>");
                    }
                }
            }

            sb.AppendLine("</tr>");

            // Example:
            // | IfcWall   | #2, #3 | PASS (30/30) |
            // | +Identity | #2     | FAIL (23/30) |

            Dictionary<DocExchangeDefinition, int> mapPass = new Dictionary<DocExchangeDefinition, int>(); // number of concepts passing
            Dictionary<DocExchangeDefinition, int> mapEach = new Dictionary<DocExchangeDefinition, int>(); // number of concepts checked

            Dictionary<DocExchangeDefinition, int> mapSkip = new Dictionary<DocExchangeDefinition, int>(); // number of concepts inapplicable with older schema (IFC2x3)

            try
            {
                m_loading = true;
                Dictionary<long, SEntity> instances = new Dictionary<long, SEntity>();
                this.backgroundWorkerValidate.ReportProgress(++progress, "Loading file...");
                using (FormatSPF format = new FormatSPF(this.openFileDialogValidate.FileName, typemap, instances))
                {
                    format.Load();

                    // now iterate through each concept root
                    foreach (DocModelView docView in this.m_project.ModelViews)
                    {
                        if (included == null || included.ContainsKey(docView))
                        {
                            foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                            {
                                if (this.backgroundWorkerValidate.CancellationPending)
                                    return;

                                this.backgroundWorkerValidate.ReportProgress(++progress, docRoot);

                                Type typeEntity = null;
                                if (typemap.TryGetValue(docRoot.ApplicableEntity.Name.ToUpper(), out typeEntity))
                                {
                                    // build list of instances
                                    List<SEntity> list = new List<SEntity>();
                                    foreach (SEntity instance in format.Instances.Values)
                                    {
                                        if (typeEntity.IsInstanceOfType(instance))
                                        {
                                            list.Add(instance);
                                        }
                                    }

                                    sb.Append("<tr valign=\"top\"><td><b>");
                                    sb.Append(docRoot.ApplicableEntity.Name);
                                    sb.Append("</b></td><td>&nbsp;</td><td>");

                                    sb.Append("&nbsp;</td><td>");
                                    sb.Append(list.Count);
                                    sb.Append("</td><td></td><td colspan=\"" + docView.Exchanges.Count + "\">&nbsp;</td>");

                                    sb.AppendLine("</tr>");

                                    foreach (DocTemplateUsage docUsage in docRoot.Concepts)
                                    {
                                        if (docUsage.Definition.Rules != null)
                                        {

                                            // check net requirement if mandatory for any exchange
                                            DocExchangeRequirementEnum req = DocExchangeRequirementEnum.NotRelevant;
                                            foreach (DocExchangeItem docExchangeItem in docUsage.Exchanges)
                                            {
                                                switch (docExchangeItem.Requirement)
                                                {
                                                    case DocExchangeRequirementEnum.Mandatory:
                                                        req = DocExchangeRequirementEnum.Mandatory;
                                                        break;

                                                    case DocExchangeRequirementEnum.Optional:
                                                        if (req == DocExchangeRequirementEnum.NotRelevant)
                                                        {
                                                            req = DocExchangeRequirementEnum.Optional;
                                                        }
                                                        break;

                                                    case DocExchangeRequirementEnum.Excluded:
                                                        if (req == DocExchangeRequirementEnum.NotRelevant)
                                                        {
                                                            req = DocExchangeRequirementEnum.Excluded;
                                                        }
                                                        break;
                                                }
                                            }

                                            sb.Append("<tr valign=\"top\"><td>&nbsp;&nbsp;");

                                            sb.Append(docUsage.Definition.Name);

                                            if (!IsConceptSupported(docUsage.Definition, "IFC2X3"))
                                            {
                                                sb.Append(" [IFC4]");
                                            }

                                            sb.Append("</td><td>");
                                            switch (req)
                                            {
                                                case DocExchangeRequirementEnum.Mandatory:
                                                    sb.Append("R");
                                                    break;

                                                case DocExchangeRequirementEnum.Optional:
                                                    sb.Append("O");
                                                    break;

                                                case DocExchangeRequirementEnum.Excluded:
                                                    sb.Append("X");
                                                    break;

                                                case DocExchangeRequirementEnum.NotRelevant:
                                                    sb.Append("-");
                                                    break;
                                            }

                                            bool eachresult = true; // assume passing unless something fails

                                            // if no template parameters defined, then evaluate generically
                                            if (docUsage.Items.Count == 0)
                                            {
                                                sb.Append("</td><td>");

                                                int fail = 0;
                                                int pass = 0;
                                                foreach (SEntity ent in list)
                                                {
                                                    if (this.backgroundWorkerValidate.CancellationPending)
                                                        return;

                                                    // check with parameters plugged in
                                                    bool? result = true;
                                                    foreach (DocModelRule rule in docUsage.Definition.Rules)
                                                    {
                                                        result = rule.Validate(ent, null, typemap);
                                                        if (result != null && !result.Value)
                                                            break;
                                                    }

                                                    if (result == null)
                                                    {
                                                        // no applicable rules, so passing
                                                        pass++;
                                                    }
                                                    else if (result != null && result.Value)
                                                    {
                                                        // all rules passed
                                                        pass++;
                                                    }
                                                    else
                                                    {
                                                        fail++;

                                                        // report first failure                                                        
                                                        if (fail == 1)
                                                        {
                                                            sb.Append("#");
                                                            sb.Append(ent.OID);
                                                            //sb.Append(", ");
                                                        }
                                                    }
                                                }

                                                sb.Append("&nbsp;</td><td>");
                                                sb.Append(pass);
                                                sb.Append("</td><td>");
                                                eachresult = AppendResult(sb, pass, list.Count, req);
                                                sb.Append("</td>");

                                                foreach (DocExchangeDefinition docExchangeDefinition in docView.Exchanges)
                                                {
                                                    DocExchangeRequirementEnum reqExchange = DocExchangeRequirementEnum.NotRelevant;
                                                    DocExchangeItem docExchangeItem = docUsage.GetExchange(docExchangeDefinition, DocExchangeApplicabilityEnum.Export);
                                                    if (docExchangeItem != null)
                                                    {
                                                        reqExchange = docExchangeItem.Requirement;
                                                    }

                                                    sb.Append("<td>");
                                                    AppendResult(sb, pass, list.Count, reqExchange);
                                                    sb.Append("</td>");

                                                    int iExchangePass = 0;
                                                    int iExchangeEach = 0;
                                                    int iExchangeSkip = 0;
                                                    if (!mapEach.TryGetValue(docExchangeDefinition, out iExchangeEach))
                                                    {
                                                        mapEach.Add(docExchangeDefinition, 1);//list.Count);
                                                    }
                                                    else
                                                    {
                                                        mapEach[docExchangeDefinition] += 1;// list.Count;
                                                    }

                                                    if (pass == list.Count || reqExchange == DocExchangeRequirementEnum.Optional || reqExchange == DocExchangeRequirementEnum.NotRelevant)
                                                    {
                                                        if (!mapPass.TryGetValue(docExchangeDefinition, out iExchangePass))
                                                        {
                                                            mapPass.Add(docExchangeDefinition, 1);//pass);
                                                        }
                                                        else
                                                        {
                                                            mapPass[docExchangeDefinition] += 1;//pass;
                                                        }
                                                    }
                                                    else if (!IsConceptSupported(docUsage.Definition, "IFC2X3"))
                                                    {
                                                        if (!mapSkip.TryGetValue(docExchangeDefinition, out iExchangeSkip))
                                                        {
                                                            mapSkip.Add(docExchangeDefinition, 1);//pass);
                                                        }
                                                        else
                                                        {
                                                            mapSkip[docExchangeDefinition] += 1;//pass;
                                                        }
                                                    }
                                                }

                                                sb.Append("</tr>");
                                            }
                                            else
                                            {
                                                sb.Append("</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>");

                                                for (int i = 0; i < docView.Exchanges.Count; i++)
                                                {
                                                    sb.Append("<td>&nbsp;</td>");
                                                }

                                                sb.Append("</tr>");
                                            }

                                            foreach (DocTemplateItem docItem in docUsage.Items)
                                            {
                                                if (this.backgroundWorkerValidate.CancellationPending)
                                                    return;

                                                sb.Append("<tr valign=\"top\"><td>&nbsp;&nbsp;&nbsp;&nbsp;");
                                                sb.Append(docItem.RuleParameters);
                                                sb.Append("</td><td>&nbsp;</td><td>");

                                                int pass = 0;
                                                int fail = 0;
                                                foreach (SEntity ent in list)
                                                {
                                                    if (this.backgroundWorkerValidate.CancellationPending)
                                                        return;

                                                    // check with parameters plugged in
                                                    bool? result = true;
                                                    foreach (DocModelRule rule in docUsage.Definition.Rules)
                                                    {
                                                        result = rule.Validate(ent, docItem, typemap);
                                                        if (result != null && !result.Value)
                                                            break;
                                                    }

                                                    if (result == null)
                                                    {
                                                        // inapplicable; passes
                                                        pass++;
                                                    }
                                                    else if (result != null && result.Value)
                                                    {
                                                        // applicable and valid; passes
                                                        pass++;
                                                    }
                                                    else
                                                    {
                                                        fail++;

                                                        // report first failure
                                                        if (fail == 1)
                                                        {
                                                            sb.Append("#");
                                                            sb.Append(ent.OID);
                                                            //sb.Append(", ");
                                                        }
                                                    }
                                                }
                                                sb.Append("&nbsp;</td><td>");
                                                sb.Append(pass);
                                                sb.Append("</td><td>");
                                                bool thisresult = AppendResult(sb, pass, list.Count, req);
                                                if (!thisresult)
                                                {
                                                    eachresult = false;
                                                }
                                                sb.Append("</td>");

                                                foreach (DocExchangeDefinition docExchangeDefinition in docView.Exchanges)
                                                {
                                                    DocExchangeRequirementEnum reqExchange = DocExchangeRequirementEnum.NotRelevant;
                                                    DocExchangeItem docExchangeItem = docUsage.GetExchange(docExchangeDefinition, DocExchangeApplicabilityEnum.Export);
                                                    if (docExchangeItem != null)
                                                    {
                                                        reqExchange = docExchangeItem.Requirement;
                                                    }

                                                    sb.Append("<td>");
                                                    AppendResult(sb, pass, list.Count, reqExchange);
                                                    sb.Append("</td>");

                                                    int iExchangePass = 0;
                                                    int iExchangeEach = 0;
                                                    int iExchangeSkip = 0;
                                                    if (!mapEach.TryGetValue(docExchangeDefinition, out iExchangeEach))
                                                    {
                                                        mapEach.Add(docExchangeDefinition, list.Count);
                                                    }
                                                    else
                                                    {
                                                        mapEach[docExchangeDefinition] += 1;//list.Count;
                                                    }

                                                    if (pass == list.Count || reqExchange == DocExchangeRequirementEnum.NotRelevant || reqExchange == DocExchangeRequirementEnum.Optional)
                                                    {
                                                        if (!mapPass.TryGetValue(docExchangeDefinition, out iExchangePass))
                                                        {
                                                            mapPass.Add(docExchangeDefinition, 1);//pass);
                                                        }
                                                        else
                                                        {
                                                            mapPass[docExchangeDefinition] += 1;//pass;
                                                        }
                                                    }
                                                    else if (!IsConceptSupported(docUsage.Definition, "IFC2X3"))
                                                    {
                                                        if (!mapSkip.TryGetValue(docExchangeDefinition, out iExchangeSkip))
                                                        {
                                                            mapSkip.Add(docExchangeDefinition, 1);//pass);
                                                        }
                                                        else
                                                        {
                                                            mapSkip[docExchangeDefinition] += 1;//pass;
                                                        }
                                                    }
                                                }

                                                sb.AppendLine("</tr>");
                                            }

                                            grandtotallist++;
                                            if (eachresult)
                                            {
                                                grandtotalpass++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // TOTALS
                    sb.Append("<tr><td>SUMMARY FOR IFC4</td><td></td><td></td><td></td><td>");

                    //int totalpercent = 100 * grandtotalpass / grandtotallist;
                    //sb.Append(totalpercent);
                    sb.Append("</td>");

                    foreach (DocModelView docView in m_project.ModelViews)
                    {
                        if (included == null || included.ContainsKey(docView))
                        {
                            foreach (DocExchangeDefinition docExchange in docView.Exchanges) 
                            {
                                sb.Append("<td>");

                                int exchangeeach = 0;
                                int exchangepass = 0;
                                if (mapEach.TryGetValue(docExchange, out exchangeeach) && mapPass.TryGetValue(docExchange, out exchangepass))
                                {
                                    int percent = 100;
                                    if (exchangeeach != 0)
                                    {
                                        percent = 100 * exchangepass / exchangeeach;
                                    }

                                    sb.Append(percent);
                                    sb.Append("%");
                                }

                                sb.Append("</td>");
                            }
                        }
                    }

                    // TOTALS
                    sb.Append("<tr><td>SUMMARY FOR IFC2X3</td><td></td><td></td><td></td><td>");
                    sb.Append("&nbsp;</td>");

                    foreach (DocModelView docView in m_project.ModelViews)
                    {
                        if (included == null || included.ContainsKey(docView))
                        {
                            foreach (DocExchangeDefinition docExchange in docView.Exchanges)
                            {
                                sb.Append("<td>");

                                int exchangeeach = 0;
                                int exchangepass = 0;
                                int exchangeskip = 0;
                                if (mapEach.TryGetValue(docExchange, out exchangeeach) && mapPass.TryGetValue(docExchange, out exchangepass))
                                {
                                    mapSkip.TryGetValue(docExchange, out exchangeskip);

                                    int percent = 100;
                                    if (exchangeeach != 0)
                                    {
                                        percent = 100 * (exchangepass + exchangeskip) / exchangeeach;
                                    }

                                    sb.Append(percent);
                                    sb.Append("%");
                                }

                                sb.Append("</td>");
                            }
                        }
                    }

                    sb.Append("</td></tr>");
                }
            }
            catch (Exception x)
            {
                this.m_exception = x;
            }
            finally
            {
                m_loading = false;
            }

            sb.AppendLine("</table>");

            // create html doc
            int grandtotalpercent = 100 * grandtotalpass / grandtotallist;

            string path = this.openFileDialogValidate.FileName + ".htm";
            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create))
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fs))
                {
                    writer.WriteLine("<html>");
                    writer.WriteLine("<body>");

                    writer.WriteLine(sb.ToString());

                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
                }
            }

            // launch
            System.Diagnostics.Process.Start(path);
        }

        private void backgroundWorkerValidate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.m_formProgress.ReportProgress(e.ProgressPercentage, e.UserState);
        }

        private void backgroundWorkerValidate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_formProgress.Close();
        }

        private void toolStripMenuItemToolsSourceCode_Click(object sender, EventArgs e)
        {
            using (FormCode form = new FormCode())
            {
                form.Path = Properties.Settings.Default.CodePath;
                form.Language = Properties.Settings.Default.CodeLanguage;

                DialogResult res = form.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    switch (form.Language)
                    {
                        case "C#":
                            FormatCSC.GenerateCode(this.m_project, form.Path);
                            break;

                        case "Java":
                            FormatJAV.GenerateCode(this.m_project, form.Path);
                            break;
                    }
                }
            }
        }

        private void ToolStripMenuItemGenerateBallotSubmission_Click(object sender, EventArgs e)
        {
            DialogResult res = this.folderBrowserDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                // build dictionary to map IFC type name to entity and schema                
                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();

                // build dictionary to map IFC type name to schema
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();

                this.BuildMaps(mapEntity, mapSchema);


                // swap out instances temporarily                    
                Dictionary<long, SEntity> old = this.m_instances;
                long lid = this.m_lastid;
                try
                {
                    this.m_instances = new Dictionary<long, SEntity>();
                    this.m_lastid = 0;

                    foreach (DocModelView docView in this.m_project.ModelViews)
                    {
                        NBIMS.Export(this.m_project, docView, this.folderBrowserDialog.SelectedPath, mapEntity, mapSchema);
                    }
                }
                finally
                {
                    this.m_instances = old;
                    this.m_lastid = lid;
                }
            }
        }

        private void toolStripMenuItemInsertNormative_Click(object sender, EventArgs e)
        {
            DocReference docNorm = new DocReference();

            if(this.m_project.NormativeReferences == null)
            {
                this.m_project.NormativeReferences = new List<DocReference>();
            }
            this.m_project.NormativeReferences.Add(docNorm);

            TreeNode tnParent = this.treeView.Nodes[1];
            this.treeView.SelectedNode = this.LoadNode(tnParent, docNorm, docNorm.ToString(), true);

            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertBibliography_Click(object sender, EventArgs e)
        {
            DocReference docNorm = new DocReference();
            if (this.m_project.InformativeReferences == null)
            {
                this.m_project.InformativeReferences = new List<DocReference>();
            }
            this.m_project.InformativeReferences.Add(docNorm);

            TreeNode tnParent = this.treeView.Nodes[14];
            this.treeView.SelectedNode = this.LoadNode(tnParent, docNorm, docNorm.ToString(), true);

            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertTerm_Click(object sender, EventArgs e)
        {
            DocTerm docNorm = new DocTerm();
            if (this.m_project.Terms == null)
            {
                this.m_project.Terms = new List<DocTerm>();
            }
            this.m_project.Terms.Add(docNorm);

            TreeNode tnParent = this.treeView.Nodes[2];
            this.treeView.SelectedNode = this.LoadNode(tnParent, docNorm, docNorm.ToString(), true);

            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertAbbreviatedTerm_Click(object sender, EventArgs e)
        {
            DocAbbreviation docNorm = new DocAbbreviation();
            if (this.m_project.Abbreviations == null)
            {
                this.m_project.Abbreviations = new List<DocAbbreviation>();
            }
            this.m_project.Abbreviations.Add(docNorm);

            TreeNode tnParent = this.treeView.Nodes[2];
            this.treeView.SelectedNode = this.LoadNode(tnParent, docNorm, docNorm.ToString(), true);

            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertSchema_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocSection docSection = (DocSection)tnParent.Tag;
            DocSchema docSchema = new DocSchema();
            docSection.Schemas.Add(docSchema);
            this.treeView.SelectedNode = this.LoadNode(tnParent, docSchema, null, true);
            LoadNodeSchema(this.treeView.SelectedNode, docSchema);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void InitDefinition(DocDefinition docEntity)
        {
            docEntity.DiagramRectangle = new DocRectangle();
            docEntity.DiagramRectangle.X = (this.ctlExpressG.Marker.X - this.ctlExpressG.AutoScrollPosition.X) / CtlExpressG.Factor;
            docEntity.DiagramRectangle.Y = (this.ctlExpressG.Marker.Y - this.ctlExpressG.AutoScrollPosition.Y) / CtlExpressG.Factor;
            docEntity.DiagramRectangle.Width = 400.0f;
            docEntity.DiagramRectangle.Height = 100.0f;

            int px = (int)(docEntity.DiagramRectangle.X / CtlExpressG.PageX);
            int py = (int)(docEntity.DiagramRectangle.Y / CtlExpressG.PageY);
            int page = 1 + py * this.ctlExpressG.Schema.DiagramPagesHorz + px;
            docEntity.DiagramNumber = page;
        }

        private void toolStripMenuItemInsertEntity_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocSchema docSchema = (DocSchema)tnParent.Tag;
            DocEntity docEntity = new DocEntity();
            InitDefinition(docEntity);
            docSchema.Entities.Add(docEntity);
            this.treeView.SelectedNode = this.LoadNode(tnParent.Nodes[1], docEntity, null, true);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertAttribute_Click(object sender, EventArgs e)
        {
            // prompt user to select type (or primitive)
            using(FormSelectEntity form = new FormSelectEntity(null, null, this.m_project))
            {
                if(form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    TreeNode tnParent = this.treeView.SelectedNode;
                    DocSchema docSchema = (DocSchema)tnParent.Parent.Parent.Tag;
                    DocEntity docEntity = (DocEntity)tnParent.Tag;
                    DocAttribute docAttr = new DocAttribute();
                    docAttr.Name = String.Empty;
                    docEntity.Attributes.Add(docAttr);

                    // is the selected type within the same schema?
                    if ((form.SelectedEntity is DocType && docSchema.Types.Contains((DocType)form.SelectedEntity)) ||
                        (form.SelectedEntity is DocEntity && docSchema.Entities.Contains((DocEntity)form.SelectedEntity)))
                    {
                        docAttr.Definition = form.SelectedEntity;
                        docAttr.DefinedType = form.SelectedEntity.Name;
                        docAttr.DiagramLine.Add(new DocPoint(docEntity.DiagramRectangle.X + docEntity.DiagramRectangle.Width, docEntity.DiagramRectangle.Y + (docEntity.Attributes.IndexOf(docAttr)+1) * 100.0));
                        docAttr.DiagramLine.Add(new DocPoint(form.SelectedEntity.DiagramRectangle.X, form.SelectedEntity.DiagramRectangle.Y + form.SelectedEntity.DiagramRectangle.Height / 2));

                        docAttr.DiagramLabel = new DocRectangle();
                        docAttr.DiagramLabel.X = docAttr.DiagramLine[0].X;
                        docAttr.DiagramLabel.Y = docAttr.DiagramLine[0].Y;
                        docAttr.DiagramLabel.Width = 400.0;
                        docAttr.DiagramLabel.Height = 100.0;
                    }
                    else
                    {
                        // must import reference or primitive
                        //...
                    }

                    this.treeView.SelectedNode = this.LoadNode(tnParent, docAttr, docAttr.ToString(), false);
                    toolStripMenuItemEditRename_Click(this, e);

                }
            }

        }

        private void toolStripMenuItemInsertEnumeration_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocSchema docSchema = (DocSchema)tnParent.Tag;
            DocType docType = new DocEnumeration();
            InitDefinition(docType);
            docSchema.Types.Add(docType);
            this.treeView.SelectedNode = this.LoadNode(tnParent.Nodes[0], docType, null, true);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertSelect_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocSchema docSchema = (DocSchema)tnParent.Tag;
            DocType docType = new DocSelect();
            InitDefinition(docType);
            docSchema.Types.Add(docType);
            this.treeView.SelectedNode = this.LoadNode(tnParent.Nodes[0], docType, null, true);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertDefined_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocSchema docSchema = (DocSchema)tnParent.Tag;
            DocType docType = new DocDefined();
            InitDefinition(docType);
            docSchema.Types.Add(docType);
            this.treeView.SelectedNode = this.LoadNode(tnParent.Nodes[0], docType, null, true);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertWhere_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocEntity docEntity = (DocEntity)tnParent.Tag;
            DocWhereRule docAttr = new DocWhereRule();
            docEntity.WhereRules.Add(docAttr);
            this.treeView.SelectedNode = this.LoadNode(tnParent, docAttr, docAttr.ToString(), false);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertUnique_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocEntity docEntity = (DocEntity)tnParent.Tag;
            DocUniqueRule docAttr = new DocUniqueRule();
            docEntity.UniqueRules.Add(docAttr);
            this.treeView.SelectedNode = this.LoadNode(tnParent, docAttr, docAttr.ToString(), false);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertGlobalRule_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocSchema docSchema = (DocSchema)tnParent.Tag;
            DocGlobalRule docType = new DocGlobalRule();
            docSchema.GlobalRules.Add(docType);
            this.treeView.SelectedNode = this.LoadNode(tnParent, docType, null, true);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertFunction_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocSchema docSchema = (DocSchema)tnParent.Tag;
            DocFunction docType = new DocFunction();
            docSchema.Functions.Add(docType);
            this.treeView.SelectedNode = this.LoadNode(tnParent, docType, null, true);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertPropertyEnumeration_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;

            if (tnParent.Tag is DocSchema)
            {
                DocSchema docSchema = (DocSchema)tnParent.Tag;
                DocPropertyEnumeration docType = new DocPropertyEnumeration();
                docSchema.PropertyEnums.Add(docType);
                this.treeView.SelectedNode = this.LoadNode(tnParent.Nodes[4], docType, null, true);
                toolStripMenuItemEditRename_Click(this, e);
            }
        }

        private void toolStripMenuItemInsertPropertyConstant_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocPropertyEnumeration docEnum = (DocPropertyEnumeration)tnParent.Tag;

            DocPropertyConstant docConst = new DocPropertyConstant();
            docEnum.Constants.Add(docConst);

            this.treeView.SelectedNode = this.LoadNode(tnParent, docConst, docConst.ToString(), false);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void ctlExpressG_LinkOperation(object sender, EventArgs e)
        {
            if (this.ctlExpressG.Highlight is DocDefinition)
            {
                DocDefinition docDefinition = (DocDefinition)this.ctlExpressG.Highlight;
                if(e == null && docDefinition is DocEntity)
                {
                    DocEntity docEntity = (DocEntity)docDefinition;

                    // link subtype (either from entity or entity reference)
                    docEntity.BaseDefinition = this.ctlExpressG.Selection.Name;

                    DocLine docLine = new DocLine();
                    docLine.DiagramLine.Add(new DocPoint());
                    docLine.DiagramLine.Add(new DocPoint());
                    docLine.DiagramLine.Add(new DocPoint());
                    docLine.Definition = docDefinition;

                    List<DocLine> tree = null;
                    if (this.ctlExpressG.Selection is DocEntity)
                    {
                        DocEntity docSuper = (DocEntity)this.ctlExpressG.Selection;
                        DocSubtype docSub = new DocSubtype();
                        docSub.DefinedType = docEntity.Name;
                        docSuper.Subtypes.Add(docSub);

                        tree = docSuper.Tree;
                    }
                    else if (this.ctlExpressG.Selection is DocDefinitionRef)
                    {
                        tree = ((DocDefinitionRef)this.ctlExpressG.Selection).Tree;
                    }

                    if(tree != null)
                    {
                        if (tree.Count > 0 && tree[0].Definition == null)
                        {
                            // existing tree structure
                            tree[0].Tree.Add(docLine);
                        }
                        else
                        {
                            // no tree structure
                            tree.Add(docLine);
                        }
                    }

                    this.ctlExpressG.LayoutDefinition((DocDefinition)this.ctlExpressG.Selection);
                    this.ctlExpressG.LayoutDefinition(docDefinition);
                    this.ctlExpressG.Redraw();
                }
                else if (this.ctlExpressG.Selection is DocEntity)
                {
                    // create an attribute

                    DocEntity docEntity = (DocEntity)this.ctlExpressG.Selection;

                    DocAttribute docAttr = new DocAttribute();
                    docAttr.Name = "Attribute";
                    docAttr.Definition = docDefinition;
                    docAttr.DefinedType = docAttr.Definition.Name;
                    CtlExpressG.LayoutLine(docEntity, docAttr.Definition, docAttr.DiagramLine);

                    docAttr.DiagramLabel = new DocRectangle();
                    docAttr.DiagramLabel.X = docAttr.DiagramLine[0].X;
                    docAttr.DiagramLabel.Y = docAttr.DiagramLine[0].Y;
                    docAttr.DiagramLabel.Width = 400.0;
                    docAttr.DiagramLabel.Height = 100.0;

                    docEntity.Attributes.Add(docAttr);

                    TreeNode tnParent = this.treeView.SelectedNode;
                    this.treeView.SelectedNode = this.LoadNode(tnParent, docAttr, docAttr.ToString(), false);
                    toolStripMenuItemEditRename_Click(this, e);
                }
                else if (this.ctlExpressG.Selection is DocSelect)
                {
                    // link select
                    DocSelect docSelect = (DocSelect)this.ctlExpressG.Selection;

                    // link definition
                    DocSelectItem docItem = new DocSelectItem();
                    //docItem.Definition = docDefinition;
                    docItem.Name = docDefinition.Name;
                    //CtlExpressG.LayoutLine(docSelect, docItem.Definition, docItem.DiagramLine);
                    docSelect.Selects.Add(docItem);

                    // link lines
                    DocLine docLine = new DocLine();
                    docLine.Definition = docDefinition;
                    CtlExpressG.LayoutLine(docSelect, docDefinition, docLine.DiagramLine);
                    docSelect.Tree.Add(docLine);

                    TreeNode tnParent = this.treeView.SelectedNode;
                    this.treeView.SelectedNode = this.LoadNode(tnParent, docItem, docItem.ToString(), false);
                }
                else if (this.ctlExpressG.Selection is DocDefined)
                {
                    // link defined
                    DocDefined docDefined = (DocDefined)this.ctlExpressG.Selection;
                    docDefined.Definition = docDefinition;
                    docDefined.DefinedType = docDefined.Definition.Name;
                    if (docDefined.DiagramLine == null)
                    {
                        docDefined.DiagramLine = new List<DocPoint>();
                    }
                    CtlExpressG.LayoutLine(docDefined, docDefined.Definition, docDefined.DiagramLine);
                }
            }
        }

        private void ctlExpressG_SelectionChanged(object sender, EventArgs e)
        {
            // update tree; optimize -- selection can only change to within current schema
            TreeNode node = this.treeView.SelectedNode;
            while(!(node.Tag is DocSchema))
            {
                node = node.Parent;
            }

            if (this.ctlExpressG.Selection == null)
            {
                // select schema
                this.treeView.SelectedNode = node;
                return;
            }

            if (this.ctlExpressG.Selection is DocObject)
            {
                UpdateTreeSelection(node, (DocObject)this.ctlExpressG.Selection);
            }

            bool multiselect = (this.ctlExpressG.Multiselection.Count > 1);
            this.toolStripMenuItemDiagramAlign.Enabled = multiselect;
            this.toolStripMenuItemDiagramSize.Enabled = multiselect;
            this.toolStripMenuItemDiagramSpaceHorz.Enabled = multiselect;
            this.toolStripMenuItemDiagramSpaceVert.Enabled = multiselect;
        }

        /// <summary>
        /// Recursively searches tree for item and selects it
        /// </summary>
        /// <param name="node"></param>
        /// <param name="selection"></param>
        private void UpdateTreeSelection(TreeNode node, DocObject selection)
        {
            if (node.Tag == selection)
            {
                this.treeView.SelectedNode = node;
                return;
            }

            foreach (TreeNode child in node.Nodes)
            {
                UpdateTreeSelection(child, selection);
            }
        }

        private void ctlExpressG_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.toolStripMenuItemEditProperties_Click(this, EventArgs.Empty);
        }

        private void toolStripMenuItemEditRename_Click(object sender, EventArgs e)
        {
            this.treeView.SelectedNode.BeginEdit();
        }

        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            object target = e.Node.Tag;

            if (target is DocObject)
            {
                DocObject docObj = (DocObject)target;
                if (e.Label == null)
                {
                    e.Node.Text = docObj.Name;
                    return;
                }

                // check for unique value
                TreeNode tnExist = null;
                if(e.Label == String.Empty)
                {
                    MessageBox.Show("This item requires a name.");

                    e.Node.BeginEdit();
                }
                else if (this.m_mapTree.TryGetValue(e.Label.ToLowerInvariant(), out tnExist) && tnExist != e.Node)
                {
                    // conflict -- prompt for a different value
                    MessageBox.Show("The specified name is already in use.");

                    // rename
                    e.Node.BeginEdit();
                }
                else
                {
                    // rename and replace link
                    if (docObj.Name != null)
                    {
                        string oldkey = docObj.Name.ToLowerInvariant();
                        if (this.m_mapTree.ContainsKey(oldkey))
                        {
                            this.m_mapTree.Remove(oldkey);
                        }
                    }
                    docObj.Name = e.Label;
                    e.Node.Text = e.Label;
                    this.m_mapTree.Add(docObj.Name.ToLowerInvariant(), e.Node);

                    //... update any named references from other schemas....

                    this.ctlExpressG.Redraw();
                }
            }
        }

        private void treeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            object target = e.Node.Tag;
            if(target is DocSection)
            {
                e.CancelEdit = true;
            }
            else if (target is DocObject)
            {
                e.CancelEdit = false;
            }
            else
            {
                e.CancelEdit = true;
            }
        }

        private void toolStripMenuItemInsertEnumerationConstant_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocEnumeration docEnum = (DocEnumeration)tnParent.Tag;
            DocConstant docConstant = new DocConstant();
            docEnum.Constants.Add(docConstant);
            this.treeView.SelectedNode = this.LoadNode(tnParent, docConstant, docConstant.ToString(), false);
            toolStripMenuItemEditRename_Click(this, e);
        }

        private void toolStripMenuItemInsertComment_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocSchema docSchema = (DocSchema)tnParent.Tag;
            DocComment docComment = new DocComment();
            InitDefinition(docComment);
            docComment.Name = null;
            docSchema.Comments.Add(docComment);
            this.treeView.SelectedNode = this.LoadNode(tnParent.Nodes[9], docComment, docComment.ToString(), false);
            toolStripMenuItemEditProperties_Click(this, e);
        }

        private void InsertPrimitive(string type)
        {
            TreeNode tnParent = this.treeView.SelectedNode;
            DocSchema docSchema = (DocSchema)tnParent.Tag;
            DocPrimitive docPrimitive = new DocPrimitive();
            InitDefinition(docPrimitive);
            docPrimitive.Name = type;
            docSchema.Primitives.Add(docPrimitive);
            this.treeView.SelectedNode = this.LoadNode(tnParent.Nodes[8], docPrimitive, docPrimitive.ToString(), false);
        }

        private void toolStripMenuItemInsertPrimitiveBoolean_Click(object sender, EventArgs e)
        {
            InsertPrimitive("BOOLEAN");
        }

        private void toolStripMenuItemInsertPrimitiveLogical_Click(object sender, EventArgs e)
        {
            InsertPrimitive("LOGICAL");
        }

        private void toolStripMenuItemInsertBooleanInteger_Click(object sender, EventArgs e)
        {
            InsertPrimitive("INTEGER");
        }

        private void toolStripMenuItemInsertBooleanReal_Click(object sender, EventArgs e)
        {
            InsertPrimitive("REAL");
        }

        private void toolStripMenuItemInsertBooleanNumber_Click(object sender, EventArgs e)
        {
            InsertPrimitive("NUMBER");
        }

        private void toolStripMenuItemInsertBooleanBinary_Click(object sender, EventArgs e)
        {
            InsertPrimitive("BINARY");
        }

        private void toolStripMenuItemInsertBooleanString_Click(object sender, EventArgs e)
        {
            InsertPrimitive("STRING");
        }

        private void SetView(int view)
        {
            this.toolStripMenuItemViewWeb.Checked = (view == 1);
            this.toolStripButtonViewWeb.Checked = (view == 1);
            this.webBrowser.Visible = (view == 1);

            this.toolStripMenuItemViewText.Checked = (view == 2);
            this.toolStripButtonViewText.Checked = (view == 2);
            this.textBoxHTML.Visible = (view == 2);

            this.toolStripMenuItemViewDiagram.Checked = (view == 3);
            this.toolStripButtonViewDiagram.Checked = (view == 3);
            this.panelDiagram.Visible = (view == 3);

            this.toolStripMenuItemModeSelect.Enabled = (view == 3);
            this.toolStripMenuItemModeMove.Enabled = (view == 3);
            this.toolStripMenuItemModeLink.Enabled = (view == 3);
            this.toolStripButtonModeSelect.Enabled = (view == 3);
            this.toolStripButtonModeMove.Enabled = (view == 3);
            this.toolStripButtonModeLink.Enabled = (view == 3);
        }

        private void toolStripMenuItemViewWeb_Click(object sender, EventArgs e)
        {
            SetView(1);
        }

        private void toolStripMenuItemViewText_Click(object sender, EventArgs e)
        {
            SetView(2);
        }

        private void toolStripMenuItemViewDiagram_Click(object sender, EventArgs e)
        {
            SetView(3);
        }

        private void SetMode(int mode)
        {
            DocObject docobj = this.treeView.SelectedNode.Tag as DocObject;

            this.toolStripMenuItemModeSelect.Checked = (mode == 0);
            this.toolStripMenuItemModeMove.Checked = (mode == 1);
            this.toolStripMenuItemModeLink.Checked = (mode == 2);
            this.toolStripButtonModeSelect.Checked = (mode == 0);
            this.toolStripButtonModeMove.Checked = (mode == 1);
            this.toolStripButtonModeLink.Checked = (mode == 2);

            switch (mode)
            {
                case 0:
                    this.ctlExpressG.Mode = ToolMode.Select;
                    this.ctlInheritance.Mode = ToolMode.Select;
                    this.splitContainerConcept.Panel2Collapsed = true;
                    break;

                case 1:
                    this.ctlExpressG.Mode = ToolMode.Move;
                    this.ctlInheritance.Mode = ToolMode.Move;
                    this.splitContainerConcept.Panel2Collapsed = false;
                    this.splitContainerRules.Panel1Collapsed = false;
                    this.splitContainerRules.Panel2Collapsed = true;
                    break;

                case 2:
                    this.ctlExpressG.Mode = ToolMode.Link;
                    this.ctlInheritance.Mode = ToolMode.Link;
                    this.splitContainerConcept.Panel2Collapsed = false;
                    this.splitContainerRules.Panel1Collapsed = true;
                    this.splitContainerRules.Panel2Collapsed = false;
                    break;
            }
        }

        private void toolStripMenuItemModeSelect_Click(object sender, EventArgs e)
        {
            SetMode(0);
        }

        private void toolStripMenuItemModeMove_Click(object sender, EventArgs e)
        {
            SetMode(1);
        }

        private void toolStripMenuItemModeLink_Click(object sender, EventArgs e)
        {
            SetMode(2);
        }

        private void toolStripMenuItemDiagramFormatTree_Click(object sender, EventArgs e)
        {
            IDocTreeHost docDefinition = (IDocTreeHost)this.treeView.SelectedNode.Tag;
            List<DocLine> list = docDefinition.Tree;

            // add/remove tree
            if (list != null)
            {
                if (list.Count > 0 && list[0].Definition == null)
                {
                    // remove tree(s)
                    for (int iTree = list.Count - 1; iTree >= 0; iTree--)
                    {
                        DocLine docTree = list[0];
                        for(int iNode = docTree.Tree.Count-1; iNode >= 0; iNode--)
                        {
                            DocLine docNode = docTree.Tree[iNode];
                            docTree.Tree.RemoveAt(iNode);
                            list.Add(docNode);
                        }

                        list.RemoveAt(iTree);
                        docTree.Delete();
                    }

                    this.ctlExpressG.LayoutDefinition((DocDefinition)docDefinition);
                }
                else if(list.Count > 0)
                {
                    // add tree -- make node half-way along first link

                    DocLine docNode = list[0];
                    DocPoint docPos = new DocPoint(
                        (docNode.DiagramLine[0].X + docNode.DiagramLine[docNode.DiagramLine.Count - 1].X) * 0.5,
                        (docNode.DiagramLine[0].Y + docNode.DiagramLine[docNode.DiagramLine.Count - 1].Y) * 0.5);

                    DocLine docTree = new DocLine();
                    docTree.DiagramLine.Add(new DocPoint()); // will get positioned upon layout
                    docTree.DiagramLine.Add(new DocPoint()); // will get positioned upon layout
                    docTree.DiagramLine.Add(docPos);
                    
                    for(int iNode = list.Count-1; iNode >= 0; iNode--)
                    {
                        docTree.Tree.Add(list[iNode]);
                        list.RemoveAt(iNode);
                    }

                    list.Add(docTree);

                    this.ctlExpressG.LayoutDefinition((DocDefinition)docDefinition);
                    foreach(DocLine docLine in docTree.Tree)
                    {
                        this.ctlExpressG.LayoutDefinition(docLine.Definition);
                    }
                }
            }

            this.ctlExpressG.Redraw();
        }

        private DocDefinition CreateLink(DocDefinition target, DocPoint docPoint)
        {
            if (target is DocPageTarget)
            {
                DocPageTarget docPageTarget = (DocPageTarget)target;
                DocPageSource docPageSource = new DocPageSource();
                docPageTarget.Sources.Add(docPageSource);

                docPageSource.Target = docPageTarget;
                docPageSource.DiagramRectangle = new DocRectangle();
                docPageSource.DiagramRectangle.X = docPoint.X + 400.0;
                docPageSource.DiagramRectangle.Y = docPoint.Y;
                docPageSource.DiagramRectangle.Width = 400.0;
                docPageSource.DiagramRectangle.Height = 100.0;

                int px = (int)(docPageSource.DiagramRectangle.X / CtlExpressG.PageX);
                int py = (int)(docPageSource.DiagramRectangle.Y / CtlExpressG.PageY);
                int page = 1 + py * this.ctlExpressG.Schema.DiagramPagesHorz + px;
                docPageSource.DiagramNumber = page;

                return docPageSource;
            }
            else
            {
                return target;
            }
        }

        /// <summary>
        /// Replaces links from one object to another, such as page references
        /// </summary>
        /// <param name="docSchema"></param>
        /// <param name="docOld"></param>
        /// <param name="docNew"></param>
        private void RedirectReference(DocSchema docSchema, DocDefinition docOld, DocDefinition docNew)
        {
            // find reference to each source and redirect to target definition
            foreach (DocEntity docEntity in docSchema.Entities)
            {
                foreach (DocAttribute docAttr in docEntity.Attributes)
                {
                    if (docAttr.Definition == docOld)
                    {
                        docAttr.Definition = CreateLink(docNew, docAttr.DiagramLine[0]);
                        this.ctlExpressG.LayoutDefinition(docEntity);
                    }
                }
            }
            foreach (DocType docType in docSchema.Types)
            {
                if (docType is DocDefined)
                {
                    DocDefined docDef = (DocDefined)docType;
                    if (docDef.Definition == docOld)
                    {
                        docDef.Definition = CreateLink(docNew, docDef.DiagramLine[0]);
                        this.ctlExpressG.LayoutDefinition(docDef);
                    }
                }
                else if (docType is DocSelect)
                {
                    DocSelect docSel = (DocSelect)docType;
                    foreach (DocLine docLine in docSel.Tree)
                    {
                        if (docLine.Definition == docOld)
                        {
                            docLine.Definition = CreateLink(docNew, docLine.DiagramLine[0]);
                            this.ctlExpressG.LayoutDefinition(docSel);
                        }
                        foreach (DocLine docNode in docLine.Tree)
                        {
                            if (docNode.Definition == docOld)
                            {
                                docNode.Definition = CreateLink(docNew, docLine.DiagramLine[0]);
                                this.ctlExpressG.LayoutDefinition(docSel);//?...
                            }
                        }
                    }
                }
            }
        }

        private void toolStripMenuItemDiagramFormatPageRef_Click(object sender, EventArgs e)
        {
            TreeNode tnSchema = this.treeView.SelectedNode;
            DocDefinition docDefinition = (DocDefinition)tnSchema.Tag;
            while (!(tnSchema.Tag is DocSchema) && tnSchema.Parent != null)
            {
                tnSchema = tnSchema.Parent;
            }
            if (tnSchema.Tag is DocSchema)
            {
                bool bCreate = true;
                DocSchema docSchema = (DocSchema)tnSchema.Tag;
                foreach (DocPageTarget docPageTarget in docSchema.PageTargets)
                {
                    if (docPageTarget.Definition == docDefinition)
                    {
                        // already exists - delete it
                        foreach (DocPageSource docPageSource in docPageTarget.Sources)
                        {
                            RedirectReference(docSchema, docPageSource, docDefinition);
                        }

                        // delete the page target
                        int index = docSchema.PageTargets.IndexOf(docPageTarget);
                        docSchema.PageTargets.RemoveAt(index);
                        docPageTarget.Delete();

                        // remove from tree
                        tnSchema.Nodes[7].Nodes[index].Remove();

                        bCreate = false;
                        break;
                    }
                }

                if (bCreate)
                {
                    // doesn't exist, so create one
                    DocPageTarget docTarget = new DocPageTarget();
                    docSchema.PageTargets.Add(docTarget);

                    docTarget.DiagramNumber = docDefinition.DiagramNumber;
                    docTarget.Definition = docDefinition;
                    docTarget.DiagramRectangle = new DocRectangle();
                    docTarget.DiagramRectangle.X = docDefinition.DiagramRectangle.X;
                    docTarget.DiagramRectangle.Y = docDefinition.DiagramRectangle.Y - 200.0;
                    docTarget.DiagramRectangle.Width = 400.0;
                    docTarget.DiagramRectangle.Height = 100.0;

                    docTarget.DiagramLine.Add(new DocPoint());
                    docTarget.DiagramLine.Add(new DocPoint());
                    docTarget.DiagramLine.Add(new DocPoint());

                    RedirectReference(docSchema, docDefinition, docTarget);

                    LoadNode(tnSchema.Nodes[7], docTarget, docTarget.Name, false);

                    this.ctlExpressG.LayoutDefinition(docDefinition);
                }

                // renumber page references
                Dictionary<int, int> counters = new Dictionary<int, int>();
                foreach (DocPageTarget docPageTarget in docSchema.PageTargets)
                {
                    SortedList<int, int> listPages = new SortedList<int, int>();

                    if(!counters.ContainsKey(docPageTarget.DiagramNumber))
                    {
                        counters.Add(docPageTarget.DiagramNumber, 0);
                    }
                    counters[docPageTarget.DiagramNumber]++;
                    docPageTarget.Name = docPageTarget.DiagramNumber + "," + counters[docPageTarget.DiagramNumber];

                    foreach(DocPageSource docPageSource in docPageTarget.Sources)
                    {
                        if(!listPages.ContainsKey(docPageSource.DiagramNumber))
                        {
                            listPages.Add(docPageSource.DiagramNumber, docPageSource.DiagramNumber);
                        }

                        docPageSource.Name = docPageTarget.Name + " " + docPageTarget.Definition.Name;
                    }

                    docPageTarget.Name += "(";
                    foreach(int i in listPages.Keys)
                    {
                        if(!docPageTarget.Name.EndsWith("("))
                        {
                            docPageTarget.Name += ",";
                        }
                        docPageTarget.Name += i.ToString();
                    }
                    docPageTarget.Name += ")";
                }

                this.ctlExpressG.Redraw();
            }
        }

        private void toolStripMenuItemInsertReference_Click(object sender, EventArgs e)
        {
            using(FormSelectEntity form = new FormSelectEntity(null, null, this.m_project))
            {
                if(form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && form.SelectedEntity != null)
                {
                    // determine the schema
                    DocSchema targetschema = null;
                    foreach(DocSection docSection in this.m_project.Sections)
                    {
                        foreach(DocSchema docSchema in docSection.Schemas)
                        {
                            if(form.SelectedEntity is DocEntity && docSchema.Entities.Contains((DocEntity)form.SelectedEntity) ||
                                form.SelectedEntity is DocType && docSchema.Types.Contains((DocType)form.SelectedEntity))
                            {
                                targetschema = docSchema;
                                break;
                            }
                        }
                    }

                    if (targetschema == null)
                    {
                        return;
                    }

                    DocSchema sourceschema = (DocSchema)this.treeView.SelectedNode.Tag;
                    if(sourceschema == targetschema)
                    {
                        MessageBox.Show(this, "The selected item is in the current schema; references may only be made to definitions from other schemas.", "Reference");
                        return;
                    }

                    // check for schema reference
                    DocSchemaRef targetschemaref = null;
                    TreeNode tnTargetSchema = null;
                    foreach (DocSchemaRef docSchemaRef in sourceschema.SchemaRefs)
                    {
                        if(docSchemaRef.Name != null && docSchemaRef.Name.Equals(targetschema.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            // found it
                            targetschemaref = docSchemaRef;

                            int index = sourceschema.SchemaRefs.IndexOf(docSchemaRef);
                            tnTargetSchema = this.treeView.SelectedNode.Nodes[6].Nodes[index];
                            break;
                        }
                    }

                    if(targetschemaref == null)
                    {
                        targetschemaref = new DocSchemaRef();
                        targetschemaref.Name = targetschema.Name.ToUpper();
                        sourceschema.SchemaRefs.Add(targetschemaref);
                        tnTargetSchema = LoadNode(this.treeView.SelectedNode.Nodes[6], targetschemaref, targetschemaref.Name, false);
                    }

                    // add definition reference
                    DocDefinitionRef targetdef = null;
                    foreach(DocDefinitionRef docDefRef in targetschemaref.Definitions)
                    {
                        if(docDefRef.Name.Equals(form.SelectedEntity.Name))
                        {
                            targetdef = docDefRef;
                            break;
                        }
                    }

                    if(targetdef != null)
                    {
                        // select it...
                        MessageBox.Show(this, "The selected item has already been referenced in this schema.");
                        return;
                    }

                    targetdef = new DocDefinitionRef();
                    targetdef.Name = form.SelectedEntity.Name;
                    InitDefinition(targetdef);
                    targetschemaref.Definitions.Add(targetdef);
                    TreeNode tnTargetDef = LoadNode(tnTargetSchema, targetdef, targetdef.Name, false);

                    this.treeView.SelectedNode = tnTargetDef;
                }
            }
        }

        private void toolStripMenuItemDiagramAlignLeft_Click(object sender, EventArgs e)
        {
            foreach(DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                docDef.DiagramRectangle.X = ((DocDefinition)this.ctlExpressG.Selection).DiagramRectangle.X;
                this.ctlExpressG.LayoutDefinition(docDef);
            }

            this.ctlExpressG.Redraw();
        }

        private void toolStripMenuItemDiagramAlignCenter_Click(object sender, EventArgs e)
        {
            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                DocDefinition docSel = ((DocDefinition)this.ctlExpressG.Selection);
                docDef.DiagramRectangle.X = docSel.DiagramRectangle.X + docSel.DiagramRectangle.Width * 0.5 - docDef.DiagramRectangle.Width * 0.5;
                this.ctlExpressG.LayoutDefinition(docDef);
            }

            this.ctlExpressG.Redraw();

        }

        private void toolStripMenuItemDiagramAlignRight_Click(object sender, EventArgs e)
        {
            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                DocDefinition docSel = ((DocDefinition)this.ctlExpressG.Selection);
                docDef.DiagramRectangle.X = docSel.DiagramRectangle.X + docSel.DiagramRectangle.Width - docDef.DiagramRectangle.Width;
                this.ctlExpressG.LayoutDefinition(docDef);
            }

            this.ctlExpressG.Redraw();
        }

        private void toolStripMenuItemDiagramAlignTop_Click(object sender, EventArgs e)
        {
            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                docDef.DiagramRectangle.Y = ((DocDefinition)this.ctlExpressG.Selection).DiagramRectangle.Y;
                this.ctlExpressG.LayoutDefinition(docDef);
            }

            this.ctlExpressG.Redraw();
        }

        private void toolStripMenuItemDiagramAlignMiddle_Click(object sender, EventArgs e)
        {
            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                DocDefinition docSel = ((DocDefinition)this.ctlExpressG.Selection);
                docDef.DiagramRectangle.Y = docSel.DiagramRectangle.Y + docSel.DiagramRectangle.Height * 0.5 - docDef.DiagramRectangle.Height * 0.5;
                this.ctlExpressG.LayoutDefinition(docDef);
            }
            this.ctlExpressG.Redraw();

        }

        private void toolStripMenuItemDiagramAlignBottom_Click(object sender, EventArgs e)
        {
            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                DocDefinition docSel = ((DocDefinition)this.ctlExpressG.Selection);
                docDef.DiagramRectangle.Y = docSel.DiagramRectangle.Y + docSel.DiagramRectangle.Height - docDef.DiagramRectangle.Height;
                this.ctlExpressG.LayoutDefinition(docDef);
            }
            this.ctlExpressG.Redraw();
        }

        private void toolStripMenuItemDiagramSizeWidth_Click(object sender, EventArgs e)
        {
            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                docDef.DiagramRectangle.Width = ((DocDefinition)this.ctlExpressG.Selection).DiagramRectangle.Width;
                this.ctlExpressG.LayoutDefinition(docDef);
            }

            this.ctlExpressG.Redraw();
        }

        private void toolStripMenuItemDiagramSizeHeight_Click(object sender, EventArgs e)
        {
            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                docDef.DiagramRectangle.Height = ((DocDefinition)this.ctlExpressG.Selection).DiagramRectangle.Height;
                this.ctlExpressG.LayoutDefinition(docDef);
            }

            this.ctlExpressG.Redraw();
        }

        private void toolStripMenuItemDiagramSizeBoth_Click(object sender, EventArgs e)
        {
            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                docDef.DiagramRectangle.Width = ((DocDefinition)this.ctlExpressG.Selection).DiagramRectangle.Width;
                docDef.DiagramRectangle.Height = ((DocDefinition)this.ctlExpressG.Selection).DiagramRectangle.Height;
                this.ctlExpressG.LayoutDefinition(docDef);
            }

            this.ctlExpressG.Redraw();
        }

        private void SpaceHorz(double offset, bool absolute)
        {
            if (!(this.ctlExpressG.Selection is DocDefinition))
                return;

            // find extents
            DocRectangle dc = ((DocDefinition)this.ctlExpressG.Selection).DiagramRectangle;
            double min = dc.X;
            double max = dc.X + dc.Width;
            double thick = 0.0;
            
            SortedList<double, DocDefinition> sortlist = new SortedList<double, DocDefinition>();

            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                DocRectangle rcEach = docDef.DiagramRectangle;

                if (min > rcEach.X)
                    min = rcEach.X;

                if (max < rcEach.X + rcEach.Width)
                    max = rcEach.X + rcEach.Width;

                thick += rcEach.Width;

                sortlist.Add(rcEach.X, docDef);
            }

            double spacing = (max - min - thick) / (this.ctlExpressG.Multiselection.Count - 1);

            if (absolute)
            {
                spacing = offset;
            }
            else
            {
                spacing += offset;
            }

            double pos = min;
            foreach (DocDefinition docDef in sortlist.Values)
            {
                if (pos != min) // skip the first one
                {
                    docDef.DiagramRectangle.X = pos;
                }
                pos += docDef.DiagramRectangle.Width + spacing;

                this.ctlExpressG.LayoutDefinition(docDef);
            }

            this.ctlExpressG.Redraw();
        }

        private void SpaceVert(double offset, bool absolute)
        {
            if (!(this.ctlExpressG.Selection is DocDefinition))
                return;

            // find extents
            DocRectangle dc = ((DocDefinition)this.ctlExpressG.Selection).DiagramRectangle;
            double min = dc.Y;
            double max = dc.Y + dc.Height;
            double thick = 0.0;

            SortedList<double, DocDefinition> sortlist = new SortedList<double, DocDefinition>();

            foreach (DocDefinition docDef in this.ctlExpressG.Multiselection)
            {
                DocRectangle rcEach = docDef.DiagramRectangle;

                if (min > rcEach.Y)
                    min = rcEach.Y;

                if (max < rcEach.Y + rcEach.Height)
                    max = rcEach.Y + rcEach.Height;

                thick += rcEach.Height;

                sortlist.Add(rcEach.Y, docDef);
            }

            double spacing = (max - min - thick) / (this.ctlExpressG.Multiselection.Count - 1);

            if (absolute)
            {
                spacing = offset;
            }
            else
            {
                spacing += offset;
            }

            double pos = min;
            foreach (DocDefinition docDef in sortlist.Values)
            {
                if (pos != min) // skip the first one
                {
                    docDef.DiagramRectangle.Y = pos;
                }
                pos += docDef.DiagramRectangle.Height + spacing;

                this.ctlExpressG.LayoutDefinition(docDef);
            }

            this.ctlExpressG.Redraw();
        }

        private void toolStripMenuItemDiagramSpaceHorzEqual_Click(object sender, EventArgs e)
        {
            SpaceHorz(0.0, false);
        }

        private void toolStripMenuItemDiagramSpaceHorzIncrease_Click(object sender, EventArgs e)
        {
            SpaceHorz(+1.0 / CtlExpressG.Factor, false);
        }

        private void toolStripMenuItemDiagramSpaceHorzDecrease_Click(object sender, EventArgs e)
        {
            SpaceHorz(-1.0 / CtlExpressG.Factor, false);
        }

        private void toolStripMenuItemDiagramSpaceHorzRemove_Click(object sender, EventArgs e)
        {
            SpaceHorz(0.0, true);
        }

        private void toolStripMenuItemDiagramSpaceVertEqual_Click(object sender, EventArgs e)
        {
            SpaceVert(0.0, false);
        }

        private void toolStripMenuItemDiagramSpaceVertIncrease_Click(object sender, EventArgs e)
        {
            SpaceVert(+1.0 / CtlExpressG.Factor, false);
        }

        private void toolStripMenuItemDiagramSpaceVertDecrease_Click(object sender, EventArgs e)
        {
            SpaceVert(-1.0 / CtlExpressG.Factor, false);
        }

        private void toolStripMenuItemDiagramSpaceVertRemove_Click(object sender, EventArgs e)
        {
            SpaceVert(0.0, true);
        }

        private void ctlConcept_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // if link mode, insert a rule
            if (this.ctlExpressG.Mode == ToolMode.Select)
            {
                using(FormRule form = new FormRule(this.ctlConcept.Selection))
                {
                    form.ShowDialog(this);
                }
            }
            else if(this.ctlExpressG.Mode == ToolMode.Move)
            {
                this.ctlRules.DoInsert();
            }
            else if (this.ctlExpressG.Mode == ToolMode.Link)
            {
                this.ctlOperators.DoInsert();
            }
        }

        private void ctlConcept_SelectionChanged(object sender, EventArgs e)
        {
            this.ctlRules.Selection = this.ctlConcept.Selection;
            this.ctlRules.Attribute = this.ctlConcept.CurrentAttribute;

            this.ctlOperators.Rule = this.ctlConcept.Selection;
        }

        private void ctlRules_ContentChanged(object sender, EventArgs e)
        {
            this.ctlConcept.Redraw();
        }

        private void ctlRules_SelectionChanged(object sender, EventArgs e)
        {
            this.ctlConcept.Selection = this.ctlRules.Selection;
        }

        private void ctlInheritance_SelectionChanged(object sender, EventArgs e)
        {
            // navigate
            if(this.ctlInheritance.Selection != null)
            {
                TreeNode tn = null;
                if (this.m_mapTree.TryGetValue(this.ctlInheritance.Selection.Name.ToLower(), out tn))
                {                
                    // if model view is selected, get the concept root
                    if(this.ctlInheritance.ModelView != null)
                    {
                        foreach(DocConceptRoot docRoot in this.ctlInheritance.ModelView.ConceptRoots)
                        {
                            if(docRoot.ApplicableEntity == this.ctlInheritance.Selection)
                            {
                                foreach(TreeNode tnConcept in tn.Nodes)
                                {
                                    if(tnConcept.Tag == docRoot)
                                    {
                                        this.treeView.SelectedNode = tnConcept;
                                        return;
                                    }
                                }

                            }
                        }
                    }

                    // otherwise go to entity
                    this.treeView.SelectedNode = tn;
                }
            }

        }

        private void ctlParameters_SelectedColumnChanged(object sender, EventArgs e)
        {
            this.ctlConcept.Selection = this.ctlParameters.SelectedColumn;
        }


    }
}

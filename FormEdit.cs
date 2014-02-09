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

        // view state
        bool m_suppressprompt; // if true, use workaround (hack) to suppress Internet Explorer dialog prompt

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
            this.m_suppressprompt = false;
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
                                format.InitHeaders(this.m_file, "IFCDOC_6_0");
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
                                string xmlns = mvdXML.DefaultNamespace;
                                while (xmlns != null)
                                {
                                    using (FormatXML format = new FormatXML(filename, typeof(mvdXML), xmlns))
                                    {
                                        try
                                        {
                                            this.m_loading = true; // prevent constructors from registering instances (xml serializer instantiates)
                                            format.Load();
                                            mvdXML mvd = (mvdXML)format.Instance;
                                            Program.ImportMvd(mvd, this.m_project);
                                            xmlns = null;
                                        }
                                        catch (InvalidOperationException)
                                        {
                                            if (xmlns == mvdXML.DefaultNamespace)
                                            {
                                                // try loading previous version
                                                xmlns = mvdXML.NamespaceV10;
                                            }
                                            else
                                            {
                                                xmlns = null;
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

        /// <summary>
        /// Exports file according to format.
        /// </summary>
        /// <param name="filepath">File path to export.</param>
        /// <param name="templates">Optional filter of templates to export.</param>
        /// <param name="views">Optional filter of views to export.</param>
        /// <param name="schemas">Optional filter of schemas to export.</param>
        /// <param name="locales">Optional filter of locales to export.</param>
        /// <param name="formatted">If true, appends .txt extension and generates formatted htm file for documentation purposes.</param>
        private void DoExport(string filepath, DocModelView[] views, bool formatted)
        {
            // swap out instances temporarily
            Dictionary<long, SEntity> old = this.m_instances;
            long lid = this.m_lastid;

            this.m_instances = new Dictionary<long, SEntity>();
            this.m_lastid = 0;

            string ext = System.IO.Path.GetExtension(filepath).ToLower();

            if (formatted)
            {
                filepath = filepath + ".txt";
            }

            try
            {

                switch (ext)
                {
                    case ".ifc":
                        using (FormatSPF format = new FormatSPF(filepath, Schema.IFC.SchemaIfc.Types, this.m_instances))
                        {
                            format.InitHeaders(filepath, "IFC4");
                            Schema.IFC.IfcProject ifcProject = new IfcDoc.Schema.IFC.IfcProject();
                            Program.ExportIfc(ifcProject, this.m_project);
                            format.Save();
                        }
                        break;

                    case ".ifcxml":
                        using (FormatXML format = new FormatXML(filepath, typeof(Schema.IFC.IfcProject), "http://www.buildingsmart-tech.org/ifcXML/IFC4"))
                        {
                            Schema.IFC.IfcProject ifcProject = new IfcDoc.Schema.IFC.IfcProject();
                            Program.ExportIfc(ifcProject, this.m_project);
                            format.Instance = ifcProject;
                            format.Save();
                        }
                        break;

                    case ".mvdxml":
                        if (views != null)
                        {
                            using (FormatXML format = new FormatXML(filepath, typeof(mvdXML), mvdXML.DefaultNamespace))
                            {
                                mvdXML mvd = new mvdXML();
                                Program.ExportMvd(mvd, this.m_project, null, views, null, null);
                                format.Instance = mvd;
                                format.Save();
                            }
                        }
                        else
                        {
                            // pick the model view
                            using (FormSelectView form = new FormSelectView(this.m_project))
                            {
                                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                                {
                                    using (FormatXML format = new FormatXML(filepath, typeof(mvdXML), mvdXML.DefaultNamespace))
                                    {
                                        mvdXML mvd = new mvdXML();
                                        Program.ExportMvd(mvd, this.m_project, null, new DocModelView[] { form.Selection }, null, null);
                                        format.Instance = mvd;
                                        format.Save();
                                    }
                                }
                            }
                        }
                        break;

                    case ".cs":
                        using (FormatCSC format = new FormatCSC(filepath))
                        {
                            format.Instance = this.m_project;
                            format.Save();
                        }
                        break;

                    case ".exp":
                        // use currently visible model view(s)
                        using (FormatEXP format = new FormatEXP(filepath))
                        {
                            format.Instance = this.m_project;
                            format.ModelViews = views;
                            format.Save();
                        }
                        break;

                    case ".xsd":
                        // use currently visible model view(s)
                        using (FormatXSD format = new FormatXSD(filepath))
                        {
                            format.Instance = this.m_project;
                            format.ModelViews = views;
                            format.Save();
                        }
                        break;

                    case ".txt":
                        // pick locale
                        using (FormSelectLocale form = new FormSelectLocale())
                        {
                            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                using (FormatCSV format = new FormatCSV(filepath))
                                {
                                    format.Instance = this.m_project;
                                    format.Locales = new string[] { form.SelectedLocale.ToString() };
                                    format.Save();
                                }
                            }
                        }
                        break;

                    case ".sch":
                        using (FormatXML format = new FormatXML(filepath, typeof(Schema.SCH.schema), "http://purl.oclc.org/dsdl/schematron"))
                        {
                            Schema.SCH.schema sch = new Schema.SCH.schema();
                            Program.ExportSch(sch, this.m_project);
                            format.Instance = sch;
                            format.Save();
                        }
                        break;
                }
            }
            catch (System.Exception xx)
            {
                MessageBox.Show(xx.Message, "Error exporting file");
            }

            this.m_instances = old;
            this.m_lastid = lid;
        }

        private void toolStripMenuItemFileExport_Click(object sender, EventArgs e)
        {
            using (FormFilter formFilter = new FormFilter(this.m_project))
            {
                DialogResult res = this.saveFileDialogExport.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    this.DoExport(this.saveFileDialogExport.FileName, null, false);
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

        private string FormatDiagram(DocObject def, DocModelView docView, ref int iFigure, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema)
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
                    using (Image image = IfcDoc.Format.PNG.FormatPNG.CreateTemplateDiagram((DocTemplateDefinition)def, mapEntity, layout, this.m_project))
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
                    using (Image image = IfcDoc.Format.PNG.FormatPNG.CreateEntityDiagram((DocEntity)def, docView, mapEntity, layout, this.m_project))
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

                    int indent = 8;
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

        private string FormatField(string content, string fieldname, string fieldtype, string fieldvalue)
        {
            if (content != null && content.Contains("COBie") && fieldtype != "IfcReference")
            {
                this.ToString();
            }

            // hyperlink to enumerators
            TreeNode tn = null;
            if (fieldtype != null && fieldtype.StartsWith("Ifc") && fieldtype.EndsWith("Enum") &&
                this.m_mapTree.TryGetValue(fieldtype.ToLower(), out tn))
            {
                // hyperlink to enumeration definition
                DocDefinition docDef = (DocDefinition)tn.Tag;

                // replace it with hyperlink
                DocSchema docSchema = (DocSchema)tn.Parent.Parent.Tag;
                string relative = @"../../";
                string hyperlink = relative + docSchema.Name.ToLower() + @"/lexical/" + docDef.Name.ToLower() + ".htm";
                string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";

                return content.Replace(fieldname, format);
            }
            else if (fieldvalue != null && fieldvalue.StartsWith("Ifc") && this.m_mapTree.TryGetValue(fieldvalue.ToLower(), out tn))
            {
                // hyperlink to IFC entity
                DocDefinition docDef = (DocDefinition)tn.Tag;

                // replace it with hyperlink
                DocSchema docSchema = (DocSchema)tn.Parent.Parent.Tag;
                string relative = @"../../";
                string hyperlink = relative + docSchema.Name.ToLower() + @"/lexical/" + docDef.Name.ToLower() + ".htm";
                string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";

                return content.Replace(fieldname, format);
            }
            else if (fieldvalue != null && fieldvalue.Contains("_") && /*fieldvalue.StartsWith("Pset_") && */this.m_mapTree.TryGetValue(fieldvalue.ToLower(), out tn) && tn.Parent != null && tn.Tag is DocPropertySet)
            {
                // hyperlink to property set definition
                DocPropertySet docDef = (DocPropertySet)tn.Tag;

                // replace it with hyperlink
                DocSchema docSchema = (DocSchema)tn.Parent.Parent.Tag;
                string relative = @"../../";
                string hyperlink = relative + docSchema.Name.ToLowerInvariant() + @"/pset/" + docDef.Name.ToLower() + ".htm"; // case-sensitive on linux -- need to make schema all lowercase
                string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";

                return content.Replace(fieldname, format);
            }
            else if (fieldvalue != null && fieldvalue.Contains("_") && this.m_mapTree.TryGetValue(fieldvalue.ToLower(), out tn) && tn.Tag is DocQuantitySet)
            {
                // hyperlink to property set definition
                DocQuantitySet docDef = (DocQuantitySet)tn.Tag;

                // replace it with hyperlink
                DocSchema docSchema = (DocSchema)tn.Parent.Parent.Tag;
                string relative = @"../../";
                string hyperlink = relative + docSchema.Name.ToLowerInvariant() + @"/qset" + docDef.Name.ToLower() + ".htm"; // case-sentive on linux -- need to make schema all lowercase
                string format = "<a href=\"" + hyperlink + "\">" + fieldvalue + "</a>";

                return content.Replace(fieldname, format);
            }
            else
            {
                // simple replace -- hyperlink may markup value later
                return content.Replace(fieldname, fieldvalue);
            }
        }

        /// <summary>
        /// Formats table for all exchanges within a view
        /// </summary>
        /// <param name="mvd"></param>
        /// <returns></returns>
        private string FormatTemplate(DocModelView docView)
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

#if false // prior to TC1
                foreach (DocTemplateUsage docUsage in docRoot.Concepts)
                {
                    foreach (DocExchangeItem docReq in docUsage.Exchanges)
                    {                            
                        if (docReq.Requirement != DocExchangeRequirementEnum.NotRelevant && !sortlist.ContainsKey(docRoot.ApplicableEntity.Name))
                        {
                            sortlist.Add(docRoot.ApplicableEntity.Name, docRoot);
                        }
                    }
                }
#endif
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
                sb.Append(docExchange.Name.ToLower().Replace(' ','-'));
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
                TreeNode tnEntity = this.m_mapTree[ent.ToLower()];
                string schema = tnEntity.Parent.Parent.Text;

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

                    first = true;

                    // build list of inherited items
                    DocTemplateItem[] items = this.FindTemplateItems(docRoot.ApplicableEntity, docConcept.Definition, docView);
                    foreach (DocTemplateItem docItem in items)
                    {
                        if (!first)
                        {
                            sb.Append("<br/>");
                        }
                        sb.Append(docItem.RuleParameters);
                        first = false;
                    }

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

        /// <summary>
        /// Formats table for single exchange
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        private string FormatTemplate(DocExchangeDefinition def)
        {
            // format content
            StringBuilder sb = new StringBuilder();

            // 1. manual content
            sb.Append(def.Documentation);

            // 2. map of entities and templates -- Identity | Template | Import | Export
            sb.AppendLine("<p></p>");//This exchange involves the following entities:</p>");

            SortedList<string, DocConceptRoot> sortlist = new SortedList<string, DocConceptRoot>();

            DocModelView docModelView = null;
            foreach (DocModelView docView in this.m_project.ModelViews)
            {
                if (docView.Exchanges.Contains(def))
                {
                    docModelView = docView;
                }

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
            }

            // new style - table
            sb.AppendLine("<table class=\"exchange\">");
            sb.AppendLine("<tr><th colspan=\"5\"><img src=\"../../../img/mvd-" + def.Name.ToLower().Replace(' ','-') + ".png\" />&nbsp; " + def.Name + "</th></tr>");
            sb.AppendLine("<tr><th>Entity/Concept</th><th>Attributes</th><th>Constraints</th><th>I</th><th>E</th></tr>");
            foreach (string ent in sortlist.Keys)
            {
                DocConceptRoot docRoot = sortlist[ent];

                sb.Append("<tr><td colspan=\"5\"><b><i>");
                sb.Append(docRoot.ApplicableEntity.Name);
                sb.AppendLine("</i></b></td></tr>");

                // determine schema
                TreeNode tnEntity = this.m_mapTree[ent.ToLower()];                
                string schema = tnEntity.Parent.Parent.Text;

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

                    first = true;

                    // build list of inherited items
                    DocTemplateItem[] items = this.FindTemplateItems(docRoot.ApplicableEntity, docConcept.Definition, docModelView);
                    foreach (DocTemplateItem docItem in items)
                    {
                        if (!first)
                        {
                            sb.Append("<br/>");
                        }
                        sb.Append(docItem.RuleParameters);
                        first = false;
                    }

                    sb.Append("</td><td>");
                    AppendRequirement(sb, reqImport, 3);
                    sb.Append("</td><td>");
                    AppendRequirement(sb, reqExport, 3);
                    sb.AppendLine("</td></tr>");
                }

            }
            sb.AppendLine("</table>");

            return sb.ToString();
        }

        private static void AppendRequirement(StringBuilder sb, DocExchangeRequirementEnum req, int level)
        {
#if false // old-style images
            sb.Append("<img src=\"");
            for(int i = 0; i < level; i++)
            {
                sb.Append("../");
            }
            sb.Append("img/attr-");
            sb.Append(req.ToString().ToLower());
            sb.Append(".png\" title=\"");
            sb.Append(req.ToString());
            sb.Append("\" />");
#endif

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

        /// <summary>
        /// Generates documentation for template and all sub-templates recursively.
        /// </summary>
        /// <param name="docTemplate"></param>
        /// <param name="indexpath"></param>
        /// <param name="iFigure"></param>
        /// <param name="iTable"></param>
        private void GenerateTemplate(DocTemplateDefinition docTemplate, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema, int[] indexpath, ref int iFigure, ref int iTable)
        {       
            string pathTemplate = Properties.Settings.Default.OutputPath + @"\schema\templates\" + MakeLinkName(docTemplate) + ".htm";
            using (FormatHTM htmTemplate = new FormatHTM(pathTemplate, mapEntity, mapSchema))
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

                string doc = FormatTemplate(docTemplate, ref iFigure, ref iTable, mapEntity, mapSchema);
                htmTemplate.WriteDocumentationForISO(doc, docTemplate, false);

                if (this.m_project.Examples != null)
                {
                    List<DocExample> listExample = new List<DocExample>();
                    foreach (DocExample docExample in this.m_project.Examples)
                    {
                        this.BuildExampleList(listExample, docExample, docTemplate);
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
                if (docSubTemplate.Visible)
                {
                    iTemplate++;
                    int[] subindexpath = new int[indexpath.Length + 1];
                    indexpath.CopyTo(subindexpath, 0);
                    subindexpath[subindexpath.Length-1] = iTemplate;
                    GenerateTemplate(docSubTemplate, mapEntity, mapSchema, subindexpath, ref iFigure, ref iTable);
                }
            }
        }

        private string FormatTemplate(DocTemplateDefinition def, ref int iFigure, ref int iTable, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema)
        {
            // format content
            StringBuilder sb = new StringBuilder();

            // 1. manual content
            sb.Append(def.Documentation);

            // 2. instance diagram
            if (Properties.Settings.Default.DiagramTemplate)
            {
                sb.Append(this.FormatDiagram(def, null, ref iFigure, mapEntity, mapSchema));
            }

            // 3. entity list                
            if (Properties.Settings.Default.Requirement)
            {
                foreach (DocModelView docView in this.m_project.ModelViews)
                {
                    if (docView.Visible && docView.Exchanges.Count > 0)
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

        private string FormatTemplate(DocEntity entity, ref int iFigure, ref int iTable)
        {
            DocTemplateDefinition dtd = null;

            StringBuilder sb = new StringBuilder();

            entity.Documentation = UpdateNumbering(entity.Documentation, ref iFigure, ref iTable);
            sb.Append(entity.Documentation);

            // find concepts for entity
            foreach (DocModelView docView in this.m_project.ModelViews)
            {
                if (docView.Visible)
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
                                TreeNode tnSuper = null;
                                if (docSuper.BaseDefinition != null && m_mapTree.TryGetValue(docSuper.BaseDefinition.ToLowerInvariant(), out tnSuper))
                                {
                                    docSuper = tnSuper.Tag as DocEntity;
                                }
                                else
                                {
                                    docSuper = null;
                                }
                            }

                            // now format inherited use definitions
                            if(listLines.Count > 0)
                            {
                                sb.AppendLine("<p>The following concepts are inherited at supertypes:</p>");
                                sb.AppendLine("<ul>");
                                for(int iLine = listLines.Count-1; iLine >= 0; iLine--)
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
                                if (eachusage.Definition.Visible)
                                {
                                    if (eachusage.Documentation != null)
                                    {
                                        eachusage.Documentation = UpdateNumbering(eachusage.Documentation, ref iFigure, ref iTable);
                                    }

                                    string eachtext = this.FormatTemplate(entity, docRoot, eachusage, ref iFigure, ref iTable);
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
            string fig = FormatFigure(entity, dtd, entity.Text, ref iFigure);
            if (fig != null)
            {
                sb.Append(fig);
            }

            sb = sb.Replace("<EPM-HTML>", "");
            sb = sb.Replace("</EPM-HTML>", "");

            return sb.ToString();
        }

        private string FormatRequirements(DocTemplateUsage eachusage, DocModelView docModel, bool showexchanges)
        {
            if (eachusage.Exchanges == null || eachusage.Exchanges.Count == 0 && (eachusage.Items.Count == 0 || eachusage.Definition.Type == ""))
                return null; // don't show if no rules or exchanges

            if (!Properties.Settings.Default.Requirement)
                return String.Empty;

            StringBuilder sb = new StringBuilder();

            if (showexchanges && docModel.Visible && docModel.Exchanges.Count > 0)
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

        /// <summary>
        /// Builds list of items in order, using inherited concepts.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="template"></param>
        /// <param name="view"></param>
        private DocTemplateItem[] FindTemplateItems(DocEntity entity, DocTemplateDefinition template, DocModelView view)
        {
            // inherited concepts first

            List<DocTemplateItem> listItems = new List<DocTemplateItem>();
            DocEntity basetype = entity;
            bool inherit = true;
            while (basetype != null)
            {
                // find templates for base
                foreach (DocModelView docView in this.m_project.ModelViews)
                {
                    if ((view == null && docView.Visible) || 
                        (view == docView || view.BaseView == docView.Name))
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
                                            for(int iparam = 0; iparam < parameters.Length; iparam++)
                                            {
                                                values[iparam] = eachitem.GetParameterValue(parameters[iparam]);
                                            }

                                            // new (IfcDoc 4.9d): only add if we don't override by parameters matching exactly
                                            bool include = true;
                                            foreach(DocTemplateItem existitem in listItems)
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
                    string key = basetype.BaseDefinition.ToLowerInvariant();
                    TreeNode tn = null;
                    if (this.m_mapTree.TryGetValue(key, out tn))
                    {
                        basetype = tn.Tag as DocEntity;
                    }
                    else
                    {
                        basetype = null;
                    }
                }
                else
                {
                    basetype = null;
                }
            }

            return listItems.ToArray();
        }

        /// <summary>
        /// Formats a template given an entity and optional template
        /// </summary>
        /// <param name="entity">The entity to format.</param>
        /// <param name="usage">Use definition to format, or null for all use definitions for entity.</param>
        /// <param name="iFigure">The last figure number used.</param>
        /// /// <param name="iFigure">The last table number used.</param>
        /// <returns></returns>
        private string FormatTemplate(DocEntity entity, DocConceptRoot root, DocTemplateUsage usage, ref int iFigure, ref int iTable)
        {
            if (usage.Definition == null)
                return String.Empty;

            // build maps 
            Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();
            Dictionary<string, string> mapSchema = new Dictionary<string, string>();
            BuildMaps(mapEntity, mapSchema);

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
                foreach (DocModelView docView in this.m_project.ModelViews)
                {
                    if(docView.ConceptRoots.Contains(root))
                    {
                        docModelView = docView;
                        break;
                    }
                }
            }

            // new (2.0): capture inherited properties too
            DocTemplateItem[] listItems = this.FindTemplateItems(entity, usage.Definition, docModelView);

            // add stock sentence

            // typical values: "Material Constituents", "Documents", "Aggregation", "Nesting", "Representations"
            // Usage of the <i>Material Constituents</i> concept is shown in Table XXXX.
            // Usage of the <i>Nesting</i> concept is shown in Table XXXX.
            // Usage of the <i>Aggregation</i> concept is shown in Table XXXX:

            // get link of usage
            string deflink = usage.Definition.Name.Replace(' ','-').ToLower() + ".htm";

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

                // new way with table
                string[] parameters = usage.Definition.GetParameterNames();
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

                    // formalized table
                    sb.AppendLine("<table>");
                    sb.AppendLine("<tr><td>");

                    //sb.AppendLine("<table width=\"100%\" border=\"1\" style=\"border-width=1;border-spacing=0;\">");
                    sb.AppendLine("<table class=\"gridtable\">");

                    // header
                    sb.Append("<tr>");
                    foreach (string parameter in parameters)
                    {
                        sb.Append("<th><b>");
                        sb.Append(parameter);
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
                        foreach (string parameter in parameters)
                        {
                            string value = item.GetParameterValue(parameter);
                            string schema = null;

                            sb.Append("<td>");
                            if (value != null)
                            {
                                DocDefinition docDef = GetTemplateParameterType(entity, usage.Definition, parameter, mapEntity);
                                if (docDef is DocEnumeration)
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
                                else if (docDef is DocEntity && mapSchema.TryGetValue(value, out schema))
                                {
                                    sb.Append("<a href=\"../../");
                                    sb.Append(schema.ToLower());
                                    sb.Append("/lexical/");
                                    sb.Append(value.ToLower());
                                    sb.Append(".htm\">");
                                    sb.Append(value);
                                    sb.Append("</a>");
                                }
                                else if (docDef != null)
                                {
                                    value = FormatField(value, value, docDef.Name, value);
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
                            else
                            {
                                sb.Append("&nbsp;");
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
            string fig = this.FormatFigure(entity, usage.Definition, entity.Text, ref iFigure);
            if (fig != null)
            {
                sb.Append(fig);
            }

            if (usage.Documentation != null)
            {
                sb.AppendLine(usage.Documentation); // special case if definition provides description, such as for classification
            }

            string req = this.FormatRequirements(usage, docModelView, true);
            if (req != null)
            {
                sb.AppendLine(req);
            }

            sb.AppendLine("<br/><br/>");

            return sb.ToString();
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
        private string FormatFigure(DocObject definition, DocTemplateDefinition dtd, string caption, ref int iFigure)
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

            TreeNode tnEntity = null;
            if (this.m_mapTree.TryGetValue(definition.Name.ToLower(), out tnEntity))
            {
                DocSchema docSchema = (DocSchema)tnEntity.Parent.Parent.Tag;

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
                DialogResult res = form.ShowDialog(this);
                if (res != DialogResult.OK)
                    return;
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

                if (tag is DocObject)
                {
                    DocObject obj = (DocObject)tag;
                    if (!obj.Visible)
                    {
                        tn.ForeColor = Color.Gray;
                    }
                }
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

                int iFigure = 1;
                int iTable = 1;
                DocConceptRoot root = (DocConceptRoot)e.Node.Parent.Tag;
                DocEntity ent = (DocEntity)e.Node.Parent.Parent.Tag;
                this.SetContent(obj, this.FormatTemplate(ent, root, obj, ref iFigure, ref iTable));

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
            // hack to prevent unwanted IE dialog prompt to save
            if (this.m_suppressprompt)
            {
                Control parent = this.webBrowser.Parent;
                parent.Controls.Remove(this.webBrowser);
                this.webBrowser.Dispose();
                this.webBrowser = new WebBrowser();
                this.webBrowser.Dock = DockStyle.Fill;
                this.webBrowser.Navigating += new WebBrowserNavigatingEventHandler(WebBrowser_Navigating);
                parent.Controls.Add(this.webBrowser);
            }


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

                this.ctlCheckGrid.Visible = false;
                this.ctlExpressG.Visible = false;
                this.ctlConcept.Visible = true;
            }
            else if (obj is DocExchangeDefinition)
            {
                DocExchangeDefinition docExchange = (DocExchangeDefinition)obj;
                DocModelView docView = (DocModelView)this.treeView.SelectedNode.Parent.Tag;
                this.ctlCheckGrid.CheckGridSource = new CheckGridExchange(docExchange, docView, this.m_project);
                this.ctlCheckGrid.Visible = true;
                this.ctlExpressG.Visible = false;
                this.ctlConcept.Visible = false;
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

                this.ctlCheckGrid.CheckGridSource = new CheckGridEntity(docRoot, docView, this.m_project, mapEntity);
                this.ctlCheckGrid.Visible = true;
                this.ctlExpressG.Visible = false;
                this.ctlConcept.Visible = false;
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

                this.ctlCheckGrid.CheckGridSource = new CheckGridConcept(docUsage.Definition, docView, this.m_project);
                this.ctlCheckGrid.Visible = true;
                this.ctlExpressG.Visible = false;
                this.ctlConcept.Visible = false;
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
                this.ctlCheckGrid.Visible = false;
                this.ctlConcept.Visible = false;
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

                this.ctlCheckGrid.Visible = false;
                this.ctlConcept.Visible = false;
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

                this.ctlCheckGrid.Visible = false;
                this.ctlConcept.Visible = false;
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
                this.ctlCheckGrid.Visible = false;
                this.ctlConcept.Visible = false;
            }
            else
            {
                this.ctlExpressG.Visible = false;
                this.ctlCheckGrid.Visible = false;
                this.ctlConcept.Visible = false;
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

        /// <summary>
        /// Updates content containing figure references
        /// </summary>
        /// <param name="html">Content to parse</param>
        /// <param name="figurenumber">Last figure number; returns updated last figure number</param>
        /// <param name="tablenumber">Last table number; returns updated last table number</param>
        /// <returns>Updated content</returns>
        private string UpdateNumbering(string html, ref int figurenumber, ref int tablenumber)
        {
            if (html == null)
                return null;

            html = UpdateNumbering(html, "Figure", "figure", ref figurenumber);
            html = UpdateNumbering(html, "Table", "table", ref tablenumber);
            return html;
        }

        private string UpdateNumbering(string html, string tag, string style, ref int itemnumber)
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

            toolStripMenuItemEditProperties_Click(this, e);
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

            toolStripMenuItemEditProperties_Click(this, e);
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



        /// <summary>
        /// Includes definition and all referenced definitions, traversing supertypes, attributes, selects.
        /// </summary>
        /// <param name="docDefinition"></param>
        private void FilterInclude(DocDefinition docDefinition)
        {
            // perf: return if already included
            if (docDefinition.Visible)
                return;

            // include entity
            docDefinition.Visible = true;

            if (docDefinition is DocEntity)
            {
                DocEntity docEntity = (DocEntity)docDefinition;

                // recurse to base type

                DocEntity docBase = (DocEntity)Lookup(docEntity.BaseDefinition);
                if (docBase != null)
                {
                    FilterInclude(docBase);
                }

                // traverse attributes
                foreach (DocAttribute docAttribute in docEntity.Attributes)
                {
                    DocDefinition docAttrType = (DocDefinition)Lookup(docAttribute.DefinedType);
                    if (docAttrType != null && !docAttribute.IsOptional() && docAttribute.Inverse == null) // new (4.0): only pull in mandatory attributes
                    {
                        docAttribute.Visible = true;
                        FilterInclude(docAttrType);
                    }
                }
            }
        }

        private void FilterInclude(DocModelRuleEntity docRule)
        {
            // resolve the type

            DocDefinition docDef = (DocDefinition)Lookup(docRule.Name);
            if (docDef != null)
            {
                FilterInclude(docDef);

                // recurse through nested rules
                foreach (DocModelRule docSub in docRule.Rules)
                {
                    if (docSub is DocModelRuleEntity)
                    {
                        FilterInclude((DocModelRuleEntity)docSub);
                    }
                    else if (docSub is DocModelRuleAttribute && docDef is DocEntity)
                    {
                        DocEntity docEntity = (DocEntity)docDef;
                        DocModelRuleAttribute docRuleAttr = (DocModelRuleAttribute)docSub;

                        // resolve the attribute
                        while (docEntity != null)
                        {
                            foreach (DocAttribute docAttr in docEntity.Attributes)
                            {
                                if (docAttr.Name != null && docAttr.Name.Equals(docRuleAttr.Name))
                                {
                                    docAttr.Visible = true;

                                    // found it                                    
                                    DocDefinition docAttrDef = (DocDefinition)Lookup(docAttr.DefinedType);
                                    if (docAttrDef != null)
                                    {
                                        FilterInclude(docAttrDef);
                                    }

                                    break;
                                }
                            }

                            if (docEntity.BaseDefinition == null)
                            {
                                docEntity = null;
                            }
                            else
                            {
                                docEntity = (DocEntity)Lookup(docEntity.BaseDefinition);
                            }
                        }

                        // recurse
                        if (docRuleAttr.Rules != null)
                        {
                            foreach (DocModelRule docNest in docRuleAttr.Rules)
                            {
                                if (docNest is DocModelRuleEntity)
                                {
                                    FilterInclude((DocModelRuleEntity)docNest);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void FilterInclude(DocTemplateDefinition docTemplate, bool include, Dictionary<string, DocObject> map)
        {
            if (include && docTemplate.Visible)
                return;

            docTemplate.Visible = include;

            DocEntity docEntity = Lookup(docTemplate.Type) as DocEntity;

            // traverse rules
            if (include && docTemplate.Rules != null && docEntity != null)
            {

                foreach (DocModelRule docRuleAttr in docTemplate.Rules)
                {
                    if (docRuleAttr is DocModelRuleAttribute)
                    {
                        DocAttribute docAttr = docEntity.ResolveAttribute(docRuleAttr.Name, map);
                        if (docAttr != null)
                        {
                            docAttr.Visible = true;
                        }

                        if (docRuleAttr.Rules != null)
                        {
                            foreach (DocModelRule docRuleEnt in docRuleAttr.Rules)
                            {
                                if (docRuleEnt is DocModelRuleEntity)
                                {
                                    FilterInclude((DocModelRuleEntity)docRuleEnt);
                                }
                            }
                        }
                    }
                }
            }

            // include children
            foreach (DocTemplateDefinition docSub in docTemplate.Templates)
            {
                FilterInclude(docSub, include, map);
            }

            // include parent templates, but not necessarily rules on parent templates
            if (include)
            {
                foreach (DocTemplateDefinition each1 in this.m_project.Templates)
                {
                    if (each1.Templates != null)
                    {
                        foreach (DocTemplateDefinition each2 in each1.Templates)
                        {
                            if (each2 == docTemplate)
                            {
                                each1.Visible = true;
                                return;
                            }

                            if (each2.Templates != null)
                            {
                                foreach (DocTemplateDefinition each3 in each2.Templates)
                                {
                                    if (each3 == docTemplate)
                                    {
                                        each2.Visible = true;
                                        each1.Visible = true;
                                        return;
                                    }

                                    if (each3.Templates != null)
                                    {
                                        foreach (DocTemplateDefinition each4 in each3.Templates)
                                        {
                                            if (each4 == docTemplate)
                                            {
                                                each3.Visible = true;
                                                each2.Visible = true;
                                                each1.Visible = true;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private DocObject Lookup(string name)
        {
            TreeNode tn = null;
            if (name == null)
                return null;

            if (!m_mapTree.TryGetValue(name.ToLowerInvariant(), out tn))
                return null;

            return tn.Tag as DocObject;
        }

        private void FilterApply(DocModelView view)
        {
            // clear entities and types, will be included later
            bool visibility = (view == null);


            foreach (DocSection docSection in this.m_project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    // schema is visible unless explicitly hidden or view filter is in place
                    docSchema.Visible = true;

                    if (!visibility)
                    {
                        docSchema.Visible = false;
                    }

                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        docEntity.Visible = visibility;
                        foreach (DocAttribute docAttr in docEntity.Attributes)
                        {
                            docAttr.Visible = visibility;
                        }
                    }

                    foreach (DocType docType in docSchema.Types)
                    {
                        docType.Visible = visibility;
                    }

                    foreach (DocPropertySet docPset in docSchema.PropertySets)
                    {
                        docPset.Visible = visibility;// was true for RC4
                    }

                    foreach (DocQuantitySet docQset in docSchema.QuantitySets)
                    {
                        docQset.Visible = visibility;// was true for RC4
                    }

                    // if view specified, then hide all functions
                    foreach (DocFunction docFunction in docSchema.Functions)
                    {
                        docFunction.Visible = visibility;
                    }
                }
            }

            // build map
            Dictionary<string, DocObject> map = new Dictionary<string,DocObject>();
            foreach (DocSection docSection in this.m_project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        map.Add(docEntity.Name, docEntity);
                    }

                    foreach (DocType docType in docSchema.Types)
                    {
                        map.Add(docType.Name, docType);
                    }
                }
            }                

            // filter definitions before usage
            foreach (DocTemplateDefinition docTemplate in this.m_project.Templates)
            {
                bool showtemplate = true;// Program.CheckFilter(form.FilterTemplate, docTemplate);
                FilterInclude(docTemplate, showtemplate && visibility, map);
            }

            foreach (DocExample docExample in this.m_project.Examples)
            {
                docExample.Visible = visibility;

                if (docExample.ModelView != null)
                {
                    docExample.Visible = docExample.ModelView.Visible;
                }
            }

            foreach (DocModelView docView in this.m_project.ModelViews)
            {
                docView.Visible = (view == docView || view == null);

                if (docView.Visible)
                {
                    foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                    {
                        FilterInclude(docRoot.ApplicableEntity);

                        foreach (DocTemplateUsage docUsage in docRoot.Concepts)
                        {
                            if (docUsage.Definition != null)
                            {
                                FilterInclude(docUsage.Definition, true, map);

                                if (docUsage.Definition.Rules != null)
                                {
                                    // include types referenced by rules at definition
                                    foreach (DocModelRuleAttribute docRuleAttr in docUsage.Definition.Rules)
                                    {
                                        // cardinality of 0:0 indicates excluded
                                        if (docRuleAttr.CardinalityMin == -1 && docRuleAttr.CardinalityMax == -1)
                                        {
                                            // excluded
                                        }
                                        else
                                        {
                                            // otherwise included
                                            foreach (DocModelRuleEntity docRuleEntity in docRuleAttr.Rules)
                                            {
                                                FilterInclude(docRuleEntity);
                                            }
                                        }
                                    }

                                    // include types referenced at concepts
                                    string[] parameters = docUsage.Definition.GetParameterNames();
                                    foreach (DocTemplateItem docItem in docUsage.Items)
                                    {
                                        foreach (string param in parameters)
                                        {
                                            string val = docItem.GetParameterValue(param);
                                            if (val != null)
                                            {                                    
                                                DocObject docRef = Lookup(val) as DocObject;
                                                if (docRef is DocDefinition)
                                                {
                                                    FilterInclude((DocDefinition)docRef);
                                                }
                                                else if (docRef != null)
                                                {
                                                    docRef.Visible = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }

            if (!visibility)
            {
                // now include any templates that have subtemplate included
                foreach (DocTemplateDefinition docTemplate in this.m_project.Templates)
                {
                    docTemplate.Visible = docTemplate.HasVisibleTemplates();
                }

                // now include any schemas that have entities or types included
                foreach (DocSection docSection in this.m_project.Sections)
                {
                    foreach (DocSchema docSchema in docSection.Schemas)
                    {
                        // schema is visible unless explicitly hidden or view filter is in place
                        //if (!docSchema.Visible)
                        {
                            foreach (DocEntity docEntity in docSchema.Entities)
                            {
                                if (docEntity.Visible)
                                {
                                    docSchema.Visible = true;
                                    break;
                                }
                            }

                            foreach (DocType docType in docSchema.Types)
                            {
                                if (docType.Visible)
                                {
                                    docSchema.Visible = true;
                                    break;
                                }
                            }

                            foreach (DocPropertySet docPset in docSchema.PropertySets)
                            {
                                if (docPset.Visible)
                                {
                                    docSchema.Visible = true;

                                    // include any types used for properties
                                    foreach (DocProperty docProp in docPset.Properties)
                                    {
                                        TreeNode tnProp = null;

                                        string propclass = "IfcPropertySingleValue";
                                        switch (docProp.PropertyType)
                                        {
                                            case DocPropertyTemplateTypeEnum.P_SINGLEVALUE:
                                                propclass = "IfcPropertySingleValue";
                                                break;

                                            case DocPropertyTemplateTypeEnum.P_BOUNDEDVALUE:
                                                propclass = "IfcPropertyBoundedValue";
                                                break;

                                            case DocPropertyTemplateTypeEnum.P_ENUMERATEDVALUE:
                                                propclass = "IfcPropertyEnumeratedValue";
                                                break;

                                            case DocPropertyTemplateTypeEnum.P_LISTVALUE:
                                                propclass = "IfcPropertyListValue";
                                                break;

                                            case DocPropertyTemplateTypeEnum.P_TABLEVALUE:
                                                propclass = "IfcPropertyTableValue";
                                                break;

                                            case DocPropertyTemplateTypeEnum.P_REFERENCEVALUE:
                                                propclass = "IfcPropertyReferenceValue";
                                                break;
                                        }
                                        if (this.m_mapTree.TryGetValue(propclass.ToLower(), out tnProp) && tnProp.Tag is DocDefinition)
                                        {
                                            DocDefinition dt = (DocDefinition)tnProp.Tag;
                                            FilterInclude(dt);
                                        }

                                        if (docProp.PrimaryDataType != null && this.m_mapTree.TryGetValue(docProp.PrimaryDataType.ToLower(), out tnProp) && tnProp.Tag is DocDefinition)
                                        {
                                            DocDefinition dt = (DocDefinition)tnProp.Tag;
                                            FilterInclude(dt);

                                            if (!String.IsNullOrEmpty(docProp.SecondaryDataType) && this.m_mapTree.TryGetValue(docProp.SecondaryDataType.ToLower(), out tnProp) && tnProp.Tag is DocDefinition)
                                            {
                                                DocDefinition dtSec = (DocDefinition)tnProp.Tag;
                                                FilterInclude(dtSec);
                                            }

                                        }
                                    }
                                }
                            }

                            foreach (DocQuantitySet docQset in docSchema.QuantitySets)
                            {
                                if (docQset.Visible)
                                {
                                    docSchema.Visible = true;

                                    // include any types used for quantities
                                    foreach (DocQuantity docProp in docQset.Quantities)
                                    {
                                        TreeNode tnProp = null;

                                        string propclass = "IfcQuantityCount";
                                        switch (docProp.QuantityType)
                                        {
                                            case DocQuantityTemplateTypeEnum.Q_AREA:
                                                propclass = "IfcQuantityArea";
                                                break;

                                            case DocQuantityTemplateTypeEnum.Q_COUNT:
                                                propclass = "IfcQuantityCount";
                                                break;

                                            case DocQuantityTemplateTypeEnum.Q_LENGTH:
                                                propclass = "IfcQuantityLength";
                                                break;

                                            case DocQuantityTemplateTypeEnum.Q_TIME:
                                                propclass = "IfcQuantityTime";
                                                break;

                                            case DocQuantityTemplateTypeEnum.Q_VOLUME:
                                                propclass = "IfcQuantityVolume";
                                                break;

                                            case DocQuantityTemplateTypeEnum.Q_WEIGHT:
                                                propclass = "IfcQuantityWeight";
                                                break;
                                        }

                                        if (this.m_mapTree.TryGetValue(propclass.ToLower(), out tnProp) && tnProp.Tag is DocObject)
                                        {
                                            DocObject dt = (DocObject)tnProp.Tag;
                                            dt.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        private void toolStripMenuItemFilter_Click(object sender, EventArgs e)
        {
            // new: if view is filtered, then templates are only included only if referenced within that view

            //using (FormFilter form = new FormFilter(this.m_project))
            using(FormSelectView form = new FormSelectView(this.m_project))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    DocModelView view = form.Selection;

                    // apply visible
                    FilterApply(view);

                    // reload tree to hide items that are out of scope
                    this.LoadTree();
                }
            }
        }

        /// <summary>
        /// Copies files and folders recursively, skipping those that already exist.
        /// </summary>
        /// <param name="sourcepath">Path of source directory</param>
        /// <param name="targetpath">Path of target directory</param>
        private void CopyFiles(string sourcepath, string targetpath)
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

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                string path = Properties.Settings.Default.OutputPath;

                // copy over static content * if it doesn't already exist *
                string pathContent = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                if (pathContent.EndsWith(@"bin\x86\Debug")) // debugging
                {
                    pathContent = System.IO.Path.GetDirectoryName(pathContent);
                    pathContent = System.IO.Path.GetDirectoryName(pathContent);
                    pathContent = System.IO.Path.GetDirectoryName(pathContent);
                }
                pathContent = System.IO.Path.Combine(pathContent, "content");
                CopyFiles(pathContent, path);

                int iFigure = 0;
                int iTable = 0;

                // build dictionary to map IFC type name to entity and schema                
                Dictionary<string, DocObject> mapEntity = new Dictionary<string, DocObject>();

                // build dictionary to map IFC type name to schema
                Dictionary<string, string> mapSchema = new Dictionary<string, string>();

                this.BuildMaps(mapEntity, mapSchema);

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

                Dictionary<DocObject, string> mapNumber = new Dictionary<DocObject, string>(); // map items to section (e.g. "1.1.1.1")

                string pathSchema = path + @"\schema";

                // count progress
                int progressTotal = this.m_project.Sections.Count + this.m_project.Annexes.Count + 2;
                this.m_formProgress.SetProgressTotal(progressTotal);

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

                // NEW: property set index -- build index
                SortedList<string, SortedList<string, DocPropertySet>> mapProperty = new SortedList<string, SortedList<string, DocPropertySet>>();
                foreach (DocSection docSection in this.m_project.Sections)
                {
                    foreach (DocSchema docSchema in docSection.Schemas)
                    {
                        foreach (DocPropertySet docPset in docSchema.PropertySets)
                        {
                            if (docPset.Visible)
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
                using (FormatHTM htmProp = new FormatHTM(pathProps, mapEntity, mapSchema))
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
                foreach (DocTemplateDefinition docTemplate in this.m_project.Templates)
                {
                    if (docTemplate.Visible)
                    {
                        iTemplate++;
                        int[] indexpath = new int[] { 4, iTemplate };
                        GenerateTemplate(docTemplate, mapEntity, mapSchema, indexpath, ref iFigure, ref iTable);
                    }
                }

                // NEW: model view definitions
                int iView = 0;
                if (Properties.Settings.Default.ConceptTables)
                {
                    foreach (DocModelView docTemplate in this.m_project.ModelViews)
                    {
                        if (docTemplate.Visible)
                        {
                            iView++;
                            string pathTemplate = pathSchema + @"\views\" + docTemplate.Name.Replace(' ', '-').ToLower() + "\\index.htm";
                            using (FormatHTM htmTemplate = new FormatHTM(pathTemplate, mapEntity, mapSchema))
                            {
                                htmTemplate.WriteHeader(docTemplate.Name, 1, iView, 0, Properties.Settings.Default.Header);
                                htmTemplate.WriteScript(1, iView, 0, 0);
                                {
                                    string indexer = "1." + iView.ToString();
                                    string tag = "h3";
                                    string id = docTemplate.Name.ToLower();
                                    htmTemplate.WriteLine("<" + tag + "><a id=\"" + id + "\" name=\"" + id + "\">" + indexer + " " + docTemplate.Name + "</a></" + tag + ">");

                                    // write table of status for MVD
                                    htmTemplate.WriteLine("<table class=\"gridtable\">");
                                    htmTemplate.WriteLine("<tr><th>Code</th><th>Version</th><th>Status</th><th>Author</th><th>Copyright</th></tr>");
                                    htmTemplate.WriteLine("<tr><td>" + docTemplate.Code + "</td><td>" + docTemplate.Version + "</td><td>" + docTemplate.Status + "</td><td>" + docTemplate.Author + "</td><td>" + docTemplate.Copyright + "</td></tr>");
                                    htmTemplate.WriteLine("</table>");

                                    string viewtable = FormatTemplate(docTemplate);
                                    htmTemplate.WriteDocumentationForISO(viewtable, docTemplate, false);
                                }

                                htmTemplate.WriteFooter(Properties.Settings.Default.Footer);
                            }
                            // each exchange... (or sub-page?)

                            for (int iExchange = 0; iExchange < docTemplate.Exchanges.Count; iExchange++)
                            {
                                DocExchangeDefinition docExchange = docTemplate.Exchanges[iExchange];

                                string pathExchange = pathSchema + @"\views\" + docTemplate.Name.Replace(' ', '-').ToLower() + "\\" + docExchange.Name.Replace(' ', '-').ToLower() + ".htm";
                                using (FormatHTM htmExchange = new FormatHTM(pathExchange, mapEntity, mapSchema))
                                {
                                    htmExchange.WriteHeader(docExchange.Name, 1, iView, 0, Properties.Settings.Default.Header);
                                    htmExchange.WriteScript(1, iView, iExchange + 1, 0);

                                    string indexer = "1." + iView.ToString() + "." + (iExchange + 1).ToString();
                                    string tag = "h4";
                                    string id = docExchange.Name.ToLower();

                                    htmExchange.WriteLine("<" + tag + "><a id=\"" + id + "\" name=\"" + id + "\">" + indexer + " " + docExchange.Name + "</a></" + tag + ">");
                                    htmExchange.WriteLine("<p class=\"std\">");

                                    string exchangedoc = FormatTemplate(docExchange);
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
                using (FormatHTM htmTOC = new FormatHTM(pathTOC, mapEntity, mapSchema))
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
                    foreach (DocSection section in this.m_project.Sections)
                    {
                        this.backgroundWorkerGenerate.ReportProgress(++progressCurrent, section);
                        if (this.backgroundWorkerGenerate.CancellationPending)
                            return;

                        iSection++;
                        using (FormatHTM htmSectionTOC = new FormatHTM(pathSchema + @"\toc-" + iSection.ToString() + ".htm", mapEntity, mapSchema))
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
                            using (FormatHTM htmSection = new FormatHTM(pathSchema + @"\chapter-" + iSection.ToString() + @".htm", mapEntity, mapSchema))
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
                                        foreach (DocModelView docModelView in this.m_project.ModelViews)
                                        {
                                            if (docModelView.Visible)
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
                                    if(this.m_project.NormativeReferences != null)
                                    {
                                        foreach(DocReference docRef in this.m_project.NormativeReferences)
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
                                    if (this.m_project.Terms != null)
                                    {
                                        SortedList<string, DocTerm> sl = new SortedList<string, DocTerm>();
                                        foreach (DocTerm docRef in this.m_project.Terms)
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
                                    if (this.m_project.Abbreviations != null)
                                    {
                                        SortedList<string, DocAbbreviation> sl = new SortedList<string, DocAbbreviation>();
                                        foreach (DocAbbreviation docRef in this.m_project.Abbreviations)
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
                                    FormatHTM.WriteTOCforTemplates(this.m_project.Templates, 1, iSection.ToString(), htmTOC, htmSectionTOC);
                                }

                                htmSection.WriteFooter(Properties.Settings.Default.Footer);
                            }

                            // each schema
                            int iSchema = 0;
                            foreach (DocSchema schema in section.Schemas)
                            {
                                if (this.backgroundWorkerGenerate.CancellationPending)
                                    return;

                                if (schema.Visible)
                                {
                                    iSchema++;

                                    // ensure directory exists
                                    System.IO.Directory.CreateDirectory(pathSchema + @"\" + schema.Name.ToLower() + @"\lexical\");

                                    // create schema document
                                    using (FormatHTM htmSchema = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + @"\content.htm", mapEntity, mapSchema))
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
                                                    if (this.backgroundWorkerGenerate.CancellationPending)
                                                        return;

                                                    if (type.Name.Equals("IfcNullStyle", StringComparison.OrdinalIgnoreCase) && schema.Name.Equals("IfcConstructionMgmtDomain", StringComparison.OrdinalIgnoreCase))
                                                    {
                                                        // bug -- exclude
                                                        this.ToString();
                                                    }
                                                    else if (type.Visible)
                                                    {
                                                        iType++;

                                                        string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iType.ToString();
                                                        mapNumber.Add(type, formatnum);

                                                        htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[type.Name].ToLower() + "/lexical/" + type.Name.ToLower() + ".htm\">" + formatnum.ToString() + " " + type.Name + "</a>");
                                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iType.ToString() + "</a> <a class=\"listing-link\" href=\"" + mapSchema[type.Name].ToLower() + "/lexical/" + type.Name.ToLower() + ".htm\" target=\"info\">" + type.Name + "</a><td></tr>\r\n");


                                                        using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + type.Name.ToLower() + ".htm", mapEntity, mapSchema))
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
                                                                /*
                                                                if (localid.Equals("en", StringComparison.InvariantCultureIgnoreCase) && localdesc == null)
                                                                {
                                                                    localdesc = type.Documentation;
                                                                }*/

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
                                                                    htmDef.WriteFormatted(FormatXSD.FormatSelect((DocSelect)type, mapEntity));
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
                                                    if (this.backgroundWorkerGenerate.CancellationPending)
                                                        return;

                                                    if (entity.Visible)
                                                    {
                                                        iEntity++;

                                                        string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString();
                                                        mapNumber.Add(entity, formatnum);

                                                        htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                        using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema))
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

                                                                /*
                                                                if (localid.Equals("en", StringComparison.InvariantCultureIgnoreCase) && localdesc == null)
                                                                {
                                                                    localdesc = entity.Documentation;
                                                                }*/

                                                                if (!String.IsNullOrEmpty(localdesc))
                                                                {
                                                                    localdesc = ": " + localdesc;
                                                                }

                                                                htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-" + localid + ".png\" /></td><td><b>" + localname + "</b>" + localdesc + "</td></tr>");
                                                            }
                                                            htmDef.WriteLine("</table>");


                                                            string documentation = FormatTemplate(entity, ref iFigure, ref iTable);

                                                            htmDef.WriteDocumentationForISO(documentation, entity, Properties.Settings.Default.NoHistory);

                                                            if (!Properties.Settings.Default.NoXsd)
                                                            {
                                                                htmDef.Write("<p class=\"spec-head\">XSD Specification:</p>");
                                                                htmDef.Write("<span class=\"xsd\">");
                                                                htmDef.WriteFormatted(FormatXSD.FormatEntity(entity, mapEntity));
                                                                htmDef.Write("</span>");
                                                            }

                                                            htmDef.WriteExpressEntityAndDocumentation(entity, Properties.Settings.Default.NoHistory, Properties.Settings.Default.ExpressComments);

                                                            if (this.m_project.Examples != null)
                                                            {
                                                                List<DocExample> listExample = new List<DocExample>();
                                                                foreach (DocExample docExample in this.m_project.Examples)
                                                                {
                                                                    this.BuildExampleList(listExample, docExample, entity);
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
                                                    if (entity.Visible)
                                                    {
                                                        iEntity++;

                                                        string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString();
                                                        mapNumber.Add(entity, formatnum);

                                                        htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iEntity.ToString() + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/lexical/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                        using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema))
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

                                                    using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\lexical\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema))
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
                                                    if (this.backgroundWorkerGenerate.CancellationPending)
                                                        return;

                                                    if (entity.Visible)
                                                    {
                                                        iPset++;

                                                        string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString();
                                                        mapNumber.Add(entity, formatnum);

                                                        htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + formatnum + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                        using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\pset\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema))
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
                                                            //htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-en.png\" /></td><td> " + entity.Documentation + "<br /></td></tr>");

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
                                                            htmDef.WriteLine(FormatFigure(entity, null, entity.Name, ref iFigure));
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
                                                    if (this.backgroundWorkerGenerate.CancellationPending)
                                                        return;

                                                    if (entity.Visible)
                                                    {
                                                        iPset++;

                                                        string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString();
                                                        mapNumber.Add(entity, formatnum);

                                                        htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + formatnum + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/pset/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                        using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\pset\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema))
                                                        {
                                                            htmDef.WriteHeader(entity.Name, iSection, iSchema, iPset, Properties.Settings.Default.Header);
                                                            htmDef.WriteScript(iSection, iSchema, iSubSection, iPset);
                                                            htmDef.WriteLine("<h4 class=\"std\">" + iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString() + " " + entity.Name + "</h4>");

                                                            // english by default
                                                            htmDef.WriteLine("<table>");
                                                            //htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-en.png\" /></td><td> " + entity.Documentation + "<br /></td></tr>");

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
                                                                //htmDef.WriteLine("<br/>");

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
                                                    if (this.backgroundWorkerGenerate.CancellationPending)
                                                        return;

                                                    if (entity.Visible)
                                                    {
                                                        iPset++;

                                                        string formatnum = iSection.ToString() + "." + iSchema.ToString() + "." + iSubSection.ToString() + "." + iPset.ToString();
                                                        mapNumber.Add(entity, formatnum);

                                                        htmTOC.WriteTOC(3, "<a class=\"listing-link\" href=\"schema/" + mapSchema[entity.Name].ToLower() + "/qset/" + entity.Name.ToLower() + ".htm\">" + formatnum + " " + entity.Name + "</a>");
                                                        htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\"><a name=\"" + formatnum + "\">" + formatnum + "</a> <a class=\"listing-link\" href=\"" + mapSchema[entity.Name].ToLower() + "/qset/" + entity.Name.ToLower() + ".htm\" target=\"info\">" + entity.Name + "</a></td></tr>\r\n");

                                                        using (FormatHTM htmDef = new FormatHTM(pathSchema + @"\" + schema.Name.ToLower() + "\\qset\\" + entity.Name.ToLower() + ".htm", mapEntity, mapSchema))
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
                                                            //htmDef.WriteLine("<tr valign=\"top\"><td><image src=\"../../../img/locale-en.png\" /></td><td> " + entity.Documentation + "<br /></td></tr>");
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
                                                                    //htmDef.WriteLine("<ul>");
                                                                    htmDef.WriteLine("<table>");

                                                                    // english by default
                                                                    //htmDef.WriteLine("<tr><td><image src=\"../../../img/locale-en.png\" /></td><td><b>" + docprop.Name + "</b>: " + docprop.Documentation + "</td></tr>");

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
                    foreach (DocAnnex docannex in this.m_project.Annexes)
                    {
                        this.backgroundWorkerGenerate.ReportProgress(++progressCurrent, docannex);

                        iAnnex--;
                        htmTOC.WriteTOC(0, "<a class=\"listing-link\" href=\"annex/annex-" + chAnnex.ToString().ToLower() + ".htm\">Annex " + chAnnex.ToString() + ". " + docannex.Name + "</a>");

                        // write the section page
                        using (FormatHTM htmSection = new FormatHTM(path + @"\annex\annex-" + chAnnex.ToString().ToLower() + @".htm", mapEntity, mapSchema))
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

                                this.DoExport(path + @"\annex\annex-a\default\ifc4.exp", null, true);
                                this.DoExport(path + @"\annex\annex-a\default\ifcXML4.xsd", null, true);
                                this.DoExport(path + @"\annex\annex-a\default\ifc4.ifc", null, true);
                                this.DoExport(path + @"\annex\annex-a\default\ifc4.ifcxml", null, true);

                                using (FormatHTM htmExpress = new FormatHTM(path + @"\annex\annex-a\default\ifc4.exp.htm", mapEntity, mapSchema))
                                {
                                    htmExpress.UseAnchors = true;
                                    htmExpress.WriteHeader("EXPRESS", 3);
                                    htmExpress.WriteExpressSchema(this.m_project);
                                    htmExpress.WriteFooter("");
                                }

                                using (FormatHTM htmXSD = new FormatHTM(path + @"\annex\annex-a\default\ifcXML4.xsd.htm", mapEntity, mapSchema))
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

                        using (FormatHTM htmSectionTOC = new FormatHTM(path + @"\annex\toc-" + chAnnex.ToString().ToLower() + ".htm", mapEntity, mapSchema))
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
                                        foreach (DocModelView docModelView in this.m_project.ModelViews)
                                        {
                                            if (docModelView.Visible && !String.IsNullOrEmpty(docModelView.Code))
                                            {
                                                iCodeView++;
                                                htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-a/" + MakeLinkName(docModelView) + "/index.htm\" >A." + iCodeView.ToString() + " " + docModelView.Name + "</a>");

                                                htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">A." + iCodeView.ToString() + " <a href=\"annex-a/" + MakeLinkName(docModelView) + "/index.htm\" target=\"info\" >" + docModelView.Name + "</a></td></tr>");

                                                // create page for model view
                                                string pathRoot = path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\index.htm";
                                                using (FormatHTM htmRoot = new FormatHTM(pathRoot, mapEntity, mapSchema))
                                                {
                                                    htmRoot.WriteComputerListing(docModelView.Name, docModelView.Code, iCodeView);
                                                }

                                                this.DoExport(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".mvdxml", new DocModelView[] { docModelView }, true);

                                                // show filtered schemas for model views only if exchanges defined
                                                if (Properties.Settings.Default.ConceptTables)
                                                {
                                                    this.DoExport(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".exp", new DocModelView[] { docModelView }, true);
                                                    this.DoExport(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".xsd", new DocModelView[] { docModelView }, true);
                                                    this.DoExport(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".ifc", new DocModelView[] { docModelView }, true);
                                                    this.DoExport(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".ifcxml", new DocModelView[] { docModelView }, true);

                                                    // TODO: filter according to model view
                                                    using (FormatHTM htmExpress = new FormatHTM(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".exp.htm", mapEntity, mapSchema))
                                                    {
                                                        htmExpress.UseAnchors = true;
                                                        htmExpress.WriteHeader("EXPRESS", 3);
                                                        htmExpress.WriteExpressSchema(this.m_project);
                                                        htmExpress.WriteFooter("");
                                                    }

                                                    // Future: write XSD with html markup...
                                                    using (FormatHTM htmXSD = new FormatHTM(path + @"\annex\annex-a\" + MakeLinkName(docModelView) + @"\" + docModelView.Code + ".xsd.htm", mapEntity, mapSchema))
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
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_definedtypes.htm", mapEntity, mapSchema))
                                    {
                                        htmAlpha1.WriteAlphabeticalListing<DocDefined>("Defined Types", Properties.Settings.Default.Footer);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_enumtypes.htm", mapEntity, mapSchema))
                                    {
                                        htmAlpha1.WriteAlphabeticalListing<DocEnumeration>("Enumeration Types", Properties.Settings.Default.Footer);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_selecttypes.htm", mapEntity, mapSchema))
                                    {
                                        htmAlpha1.WriteAlphabeticalListing<DocSelect>("Select Types", Properties.Settings.Default.Footer);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_entities.htm", mapEntity, mapSchema))
                                    {
                                        htmAlpha1.WriteAlphabeticalListing<DocEntity>("Entities", Properties.Settings.Default.Footer);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_functions.htm", mapEntity, mapSchema))
                                    {
                                        htmAlpha1.WriteAlphabeticalListing<DocFunction>("Functions", Properties.Settings.Default.Footer);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_rules.htm", mapEntity, mapSchema))
                                    {
                                        htmAlpha1.WriteAlphabeticalListing<DocGlobalRule>("Rules", Properties.Settings.Default.Footer);
                                    }
                                    // no translations currently -- enable in future
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_psets.htm", mapEntity, mapSchema))
                                    {
                                        htmAlpha1.WriteAlphabeticalListing<DocPropertySet>("Property Sets", Properties.Settings.Default.Footer);
                                    }
                                    using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/alphabeticalorder_qsets.htm", mapEntity, mapSchema))
                                    {
                                        htmAlpha1.WriteAlphabeticalListing<DocQuantitySet>("Quantity Sets", Properties.Settings.Default.Footer);
                                    }
                                    

                                    // generate localized listings
                                    foreach (string locale in listLocale.Keys)
                                    {
                                        string code = listLocale[locale]; // null for default

                                        using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_definedtypes.htm", mapEntity, mapSchema))
                                        {
                                            htmAlpha1.WriteLocalizedListing<DocDefined>("Defined Types", code);
                                        }
                                        using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_enumtypes.htm", mapEntity, mapSchema))
                                        {
                                            htmAlpha1.WriteLocalizedListing<DocEnumeration>("Enumeration Types", code);
                                        }
                                        using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_selecttypes.htm", mapEntity, mapSchema))
                                        {
                                            htmAlpha1.WriteLocalizedListing<DocSelect>("Select Types", code);
                                        }
                                        using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_entities.htm", mapEntity, mapSchema))
                                        {
                                            htmAlpha1.WriteLocalizedListing<DocEntity>("Entities", code);
                                        }
                                        using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_functions.htm", mapEntity, mapSchema))
                                        {
                                            htmAlpha1.WriteLocalizedListing<DocFunction>("Functions", code);
                                        }
                                        using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_rules.htm", mapEntity, mapSchema))
                                        {
                                            htmAlpha1.WriteLocalizedListing<DocGlobalRule>("Rules", code);
                                        }
                                        using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_psets.htm", mapEntity, mapSchema))
                                        {
                                            htmAlpha1.WriteLocalizedListing<DocPropertySet>("Property Sets", code);
                                        }
                                        using (FormatHTM htmAlpha1 = new FormatHTM(path + "/annex/annex-b/" + locale + "/alphabeticalorder_qsets.htm", mapEntity, mapSchema))
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
                                    using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/inheritance_tree_all.htm", mapEntity, mapSchema))
                                    {
                                        htmInheritAll.WriteInheritanceListing(null);
                                    }

                                    // specific inheritance
                                    htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/inheritance_tree_IfcRoot.htm\" >C.2 Rooted entities</a>");
                                    htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C.2 <a href=\"annex-c/inheritance_tree_IfcRoot.htm\" target=\"info\" >Rooted entities</a></td></tr>");
                                    using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/inheritance_tree_IfcRoot.htm", mapEntity, mapSchema))
                                    {
                                        htmInheritAll.WriteInheritanceListing("IfcRoot");
                                    }

                                    htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/inheritance_tree_IfcObject.htm\" >C.3 Object occurrence and type pairs</a>");
                                    htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C.3 <a href=\"annex-c/inheritance_tree_IfcObject.htm\" target=\"info\" >Object occurrence and type pairs</a></td></tr>");
                                    using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/inheritance_tree_IfcObject.htm", mapEntity, mapSchema))
                                    {
                                        htmInheritAll.WriteInheritanceListing("IfcObject");
                                    }

                                    htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-c/inheritance_tree_IfcElement.htm\" >C.4 Element occurrence and type pairs</a>");
                                    htmSectionTOC.WriteLine("<tr><td>&nbsp;</td></tr>");
                                    htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">C.4 <a href=\"annex-c/inheritance_tree_IfcElement.htm\" target=\"info\" >Element occurrence and type pairs</a></td></tr>");
                                    using (FormatHTM htmInheritAll = new FormatHTM(path + "/annex/annex-c/inheritance_tree_IfcElement.htm", mapEntity, mapSchema))
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
                                            DocSection docSection = this.m_project.Sections[iSchemaSection - 1];

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

                                                using (FormatHTM htmSchemaDiagram = new FormatHTM(path + "/annex/annex-d/" + MakeLinkName(docSchema) + "/index.htm", mapEntity, mapSchema))
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
                                                            int pagePixelCX = 600;
                                                            int pagePixelCY = 888;
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
                                                    using (FormatHTM htmSchema = new FormatHTM(path + "/annex/annex-d/" + MakeLinkName(docSchema) + "/diagram_" + formatnumber + ".htm", mapEntity, mapSchema))
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

                                    if (this.m_project.ModelViews != null)
                                    {
                                        iView = 0;
                                        foreach (DocModelView docView in this.m_project.ModelViews)
                                        {
                                            if (docView.Visible)
                                            {
                                                iView++;

                                                htmTOC.WriteTOC(2, "D.2." + iView.ToString() + " " + docView.Name);
                                                htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">D.2." + iView.ToString() + " " + docView.Name + "</td></tr>");

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
                                                    using (FormatHTM htmRoot = new FormatHTM(pathRoot, mapEntity, mapSchema))
                                                    {
                                                        htmRoot.WriteHeader(docRoot.ApplicableEntity.Name, iAnnex, 2, iView, Properties.Settings.Default.Header);
                                                        htmRoot.WriteScript(iAnnex, 2, iView, iRoot);
                                                        htmRoot.WriteLine("<h3 class=\"std\">D.2." + iView.ToString() + "." + iRoot.ToString() + " " + docRoot.ApplicableEntity.Name + "</h3>");

                                                        string diagram = FormatDiagram(docRoot.ApplicableEntity, docView, ref iFigure, mapEntity, mapSchema);
                                                        htmRoot.WriteLine(diagram);

                                                        htmRoot.WriteFooter(Properties.Settings.Default.Footer);
                                                    }

                                                }
                                            }
                                        }

                                    }
                                    break;

                                case 'E':
                                    if (this.m_project.Examples != null)
                                    {
                                        int iExampleNumber = 0;
                                        for (int iExample = 1; iExample <= this.m_project.Examples.Count; iExample++)
                                        {
                                            DocExample docExample = this.m_project.Examples[iExample - 1];

                                            if (docExample.Visible)
                                            {
                                                iExampleNumber++;

                                                string pathExample = path + @"\annex\annex-e\" + MakeLinkName(docExample) + ".htm";
                                                using (FormatHTM htmExample = new FormatHTM(pathExample, mapEntity, mapSchema))
                                                {
                                                    htmExample.WriteHeader(docExample.Name, 2);
                                                    htmExample.WriteScript(iAnnex, iExampleNumber, 0, 0);
                                                    htmExample.WriteLine("<h3 class=\"std\">E." + iExampleNumber.ToString() + " " + docExample.Name + "</h3>");
                                                    htmExample.WriteDocumentationForISO(docExample.Documentation, docExample, false);
                                                    htmExample.WriteLine("<p><a href=\"../../link/" + MakeLinkName(docExample) + ".htm\" target=\"_top\" ><img src=\"../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");
                                                    htmExample.WriteFooter(Properties.Settings.Default.Footer);
                                                }

                                                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docExample) + ".htm", mapEntity, mapSchema))
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

                                                        if (docSub.Visible)
                                                        {
                                                            iSubNumber++;
                                                            string pathSub = path + @"\annex\annex-e\" + MakeLinkName(docSub) + ".htm";
                                                            using (FormatHTM htmSub = new FormatHTM(pathSub, mapEntity, mapSchema))
                                                            {
                                                                htmSub.WriteHeader(docSub.Name, 2);
                                                                htmSub.WriteScript(iAnnex, iExampleNumber, iSubNumber, 0);
                                                                htmSub.WriteLine("<h4 class=\"std\">E." + iExampleNumber + "." + iSubNumber + " " + docSub.Name + "</h4>");
                                                                htmSub.WriteDocumentationForISO(docSub.Documentation, docSub, false);
                                                                htmSub.WriteLine("<p><a href=\"../../link/" + MakeLinkName(docSub) + ".htm\" target=\"_top\" ><img src=\"../../img/permlink.png\" style=\"border: 0px\" title=\"Link to this page\" alt=\"Link to this page\"/>&nbsp; Link to this page</a></p>");
                                                                htmSub.WriteFooter(Properties.Settings.Default.Footer);
                                                            }

                                                            using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(docSub) + ".htm", mapEntity, mapSchema))
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
                                    if (this.m_project.ChangeSets != null)
                                    {
                                        for (int iChangeset = 1; iChangeset <= this.m_project.ChangeSets.Count; iChangeset++)
                                        {
                                            DocChangeSet docChangeSet = this.m_project.ChangeSets[iChangeset - 1];

                                            // what's new page
                                            htmTOC.WriteTOC(1, "<a class=\"listing-link\" href=\"annex/annex-f/" + MakeLinkName(docChangeSet) + "/index.htm\" >F." + iChangeset + " " + docChangeSet.Name + "</a>");
                                            htmSectionTOC.WriteLine("<tr class=\"std\"><td class=\"menu\">F." + iChangeset + " <a href=\"annex-f/" + MakeLinkName(docChangeSet) + "/index.htm\" target=\"info\" >" + docChangeSet.Name + "</a></td></tr>");
                                            using (FormatHTM htmWhatsnew = new FormatHTM(path + @"\annex\annex-f\" + MakeLinkName(docChangeSet) + @"\index.htm", mapEntity, mapSchema))
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
                                            using (FormatHTM htmChange = new FormatHTM(pathChange, mapEntity, mapSchema))
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
                                            using (FormatHTM htmChange = new FormatHTM(pathChange, mapEntity, mapSchema))
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
                                            using (FormatHTM htmChange = new FormatHTM(pathChange, mapEntity, mapSchema))
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
                    foreach (DocSection section in this.m_project.Sections)
                    {
                        if (this.m_project.Sections.IndexOf(section) == 3)
                        {
                            int iFigureTemplate = 0;
                            foreach (DocTemplateDefinition docTemplate in this.m_project.Templates)
                            {
                                htmTOC.WriteFigureContentsForTemplate(docTemplate, ref iFigureTemplate);
                            }
                        }

                        foreach (DocSchema schema in section.Schemas)
                        {
                            if (schema.Visible)
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
                    foreach (DocSection section in this.m_project.Sections)
                    {
                        foreach (DocSchema schema in section.Schemas)
                        {
                            if (schema.Visible)
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

                this.backgroundWorkerGenerate.ReportProgress(++progressCurrent, "Index");
                if (this.backgroundWorkerGenerate.CancellationPending)
                    return;

                // generate index -- takes very long, so only run when changing
                SortedList<string, DocObject> listIndex = new SortedList<string, DocObject>();
                foreach (string key in mapEntity.Keys)
                {
                    listIndex.Add(key, mapEntity[key]);
                }

                using (FormatHTM htmIndex = new FormatHTM(path + "/doc_index.htm", mapEntity, mapSchema)) // file name "doc_index" required by ISO
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
                        if (obj.Visible)
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

                    this.backgroundWorkerGenerate.ReportProgress(++progressCurrent, "Links");
                    if (this.backgroundWorkerGenerate.CancellationPending)
                        return;

                    // new: incoming links
                    foreach (string key in listIndex.Keys)
                    {
                        DocObject obj = mapEntity[key];
                        if (obj.Visible)
                        {
                            string schemaname = null;
                            if (mapSchema.TryGetValue(obj.Name, out schemaname))
                            {
                                using (FormatHTM htmLink = new FormatHTM(path + "/link/" + MakeLinkName(obj) + ".htm", mapEntity, mapSchema))
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
                    foreach (DocTemplateDefinition docTemplate in this.m_project.Templates)
                    {
                        listLink.Add(docTemplate);
                        GenerateTemplateLink(listLink, mapEntity, mapSchema);
                        listLink.Clear();
                    }

                    // write links for each example recursively
                    List<DocExample> listLinkExample = new List<DocExample>();
                    if (this.m_project.Examples != null)
                    {
                        foreach (DocExample docTemplate in this.m_project.Examples)
                        {
                            listLinkExample.Add(docTemplate);
                            GenerateExampleLink(listLinkExample, mapEntity, mapSchema);
                            listLinkExample.Clear();
                        }
                    }

                    htmIndex.WriteLine("</p>");
                    htmIndex.WriteFooter(Properties.Settings.Default.Footer);
                }

                // launch the content
                System.Diagnostics.Process.Start(path + @"\index.htm");
            }
            catch (Exception ex)
            {
                this.m_exception = ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="docTemplate"></param>
        /// <param name="path">Path of templates</param>
        /// <param name="mapEntity"></param>
        /// <param name="mapSchema"></param>
        private void GenerateTemplateLink(List<DocTemplateDefinition> path, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema)
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

            using (FormatHTM htmLink = new FormatHTM(sbFile.ToString(), mapEntity, mapSchema))
            {
                htmLink.WriteLinkPage(sbLink.ToString());
            }

            if (docTemplateLast.Templates != null)
            {
                foreach (DocTemplateDefinition docSub in docTemplateLast.Templates)
                {
                    path.Add(docSub);
                    GenerateTemplateLink(path, mapEntity, mapSchema);
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
        private void GenerateExampleLink(List<DocExample> path, Dictionary<string, DocObject> mapEntity, Dictionary<string, string> mapSchema)
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

            using (FormatHTM htmLink = new FormatHTM(sbFile.ToString(), mapEntity, mapSchema))
            {
                htmLink.WriteLinkPage(sbLink.ToString());
            }

            if (docTemplateLast.Examples != null)
            {
                foreach (DocExample docSub in docTemplateLast.Examples)
                {
                    path.Add(docSub);
                    GenerateExampleLink(path, mapEntity, mapSchema);
                    path.RemoveAt(path.Count - 1);
                }
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

        internal void BuildExampleList(List<DocExample> listExample, DocExample docExample, DocObject docObject)
        {
            if (docExample.ModelView != null && !docExample.ModelView.Visible)
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
                BuildExampleList(listExample, docSub, docObject);
            }
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
            // count active roots
            int progressTotal = 2;
            foreach (DocModelView docView in this.m_project.ModelViews)
            {
                if (docView.Visible)
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
                if (docView.Visible)
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
                        if (docView.Visible)
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
                        if (docView.Visible)
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
                        if (docView.Visible)
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
                        FilterApply(docView);
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
            this.toolStripMenuItemModeSelect.Checked = (mode == 1);
            this.toolStripMenuItemModeMove.Checked = (mode == 2);
            this.toolStripMenuItemModeLink.Checked = (mode == 3);
            this.toolStripButtonModeSelect.Checked = (mode == 1);
            this.toolStripButtonModeMove.Checked = (mode == 2);
            this.toolStripButtonModeLink.Checked = (mode == 3);

            switch (mode)
            {
                case 1:
                    this.ctlExpressG.Mode = ToolMode.Select;
                    break;

                case 2:
                    this.ctlExpressG.Mode = ToolMode.Move;
                    break;

                case 3:
                    this.ctlExpressG.Mode = ToolMode.Link;
                    break;
            }
        }

        private void toolStripMenuItemModeSelect_Click(object sender, EventArgs e)
        {
            SetMode(1);
        }

        private void toolStripMenuItemModeMove_Click(object sender, EventArgs e)
        {
            SetMode(2);
        }

        private void toolStripMenuItemModeLink_Click(object sender, EventArgs e)
        {
            SetMode(3);
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
    }
}

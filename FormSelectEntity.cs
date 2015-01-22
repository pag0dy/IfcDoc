// Name:        FormSelectEntity.cs
// Description: Dialog for selecting an entity from inheritance chain
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2011 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public partial class FormSelectEntity : Form
    {
        DocDefinition m_basetype;
        DocDefinition m_selection;
        DocProject m_project;
        SelectDefinitionOptions m_options;

        public FormSelectEntity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basetype">DocEntity or DocSelect.</param>
        /// <param name="selection"></param>
        /// <param name="project"></param>
        /// <param name="predefined">Select predefined type.</param>
        public FormSelectEntity(
            DocDefinition basetype, 
            DocDefinition selection, 
            DocProject project,
            SelectDefinitionOptions options)
            : this()
        {
            this.m_basetype = basetype;
            this.m_selection = selection;
            this.m_project = project;
            this.m_options = options;

            // load subtypes, sort alphabetically
            if (this.m_basetype is DocEntity)
            {
                this.LoadEntity(null, (DocEntity)this.m_basetype);
            }
            else if (this.m_basetype is DocSelect)
            {
                this.LoadSelect(null, (DocSelect)this.m_basetype);
            }
            else if (this.m_basetype != null)
            {
                // add single node for type
                TreeNode tn = new TreeNode();
                tn.Tag = basetype;
                tn.Text = basetype.Name;
                this.treeView.Nodes.Add(tn);
            }
            else
            {
                // all entities
                SortedList<string, DocDefinition> sort = new SortedList<string, DocDefinition>();
                foreach (DocSection docSection in this.m_project.Sections)
                {
                    foreach (DocSchema docSchema in docSection.Schemas)
                    {
                        foreach (DocEntity docEntity in docSchema.Entities)
                        {
                            if (docEntity.BaseDefinition == null)
                            {
                                if(!sort.ContainsKey(docEntity.Name))
                                { 
                                    sort.Add(docEntity.Name, docEntity);
                                }
                            }
                        }

                        if ((options & SelectDefinitionOptions.Type) != 0)
                        {
                            // temp: all types too; todo: specify parameter
                            foreach (DocType docType in docSchema.Types)
                            {
                                sort.Add(docType.Name, docType);
                            }
                        }
                    }
                }

                foreach (DocDefinition docDef in sort.Values)
                {
                    if (docDef is DocEntity)
                    {
                        this.LoadEntity(null, (DocEntity)docDef);
                    }
                    else if (docDef is DocType)
                    {
                        this.LoadType(null, (DocType)docDef);
                    }
                }
            }

            if (this.treeView.SelectedNode == null && this.treeView.Nodes.Count > 0)
            {
                this.treeView.SelectedNode = this.treeView.Nodes[0];
            }

            this.treeView.ExpandAll();
            this.treeView.Focus();
        }

        private void LoadSelect(TreeNode tnParent, DocSelect select)
        {
            if (select == null)
                return; // no such entity

            // add entity
            TreeNode tn = new TreeNode();
            tn.Tag = select;
            tn.Text = select.Name;

            if (tnParent != null)
            {
                tnParent.Nodes.Add(tn);
            }
            else
            {
                this.treeView.Nodes.Add(tn);
            }

            // add subtypes
            SortedList<string, DocDefinition> list = new SortedList<string, DocDefinition>();
            foreach (DocSelectItem docItem in select.Selects)
            {
                // resolve to entity (inefficient, but short on time)

                foreach (DocSection docSection in this.m_project.Sections)
                {
                    foreach (DocSchema docSchema in docSection.Schemas)
                    {
                        foreach (DocEntity docEntity in docSchema.Entities)
                        {
                            if (docEntity.Name.Equals(docItem.Name))
                            {
                                list.Add(docEntity.Name, docEntity);
                            }
                        }

                        foreach (DocType docType in docSchema.Types)
                        {
                            if (docType.Name.Equals(docItem.Name))
                            {
                                list.Add(docType.Name, docType);
                            }
                        }
                    }
                }
            }

            foreach (DocDefinition ent in list.Values)
            {
                if (ent is DocEntity)
                {
                    LoadEntity(tn, (DocEntity)ent);
                }
                else if (ent is DocSelect)
                {
                    LoadSelect(tn, (DocSelect)ent);
                }
                else if (ent is DocType)
                {
                    LoadType(tn, (DocType)ent);
                }
            }
        }

        private void LoadType(TreeNode tnParent, DocType type)
        {
            // add entity
            TreeNode tn = new TreeNode();
            tn.Tag = type;
            tn.Text = type.Name;

            if (tnParent != null)
            {
                tnParent.Nodes.Add(tn);
            }
            else
            {
                this.treeView.Nodes.Add(tn);
            }

            if (this.m_selection == type)
            {
                this.treeView.SelectedNode = tn;
            }

            // special case if typed as aggregation to an entity, e.g. IfcPropertySetDefinitionSet
            if (type is DocDefined)
            {
                DocDefined docDef = (DocDefined)type;
                if (docDef.Aggregation != null)
                {
                    foreach (DocSection docSection in this.m_project.Sections)
                    {
                        foreach (DocSchema docSchema in docSection.Schemas)
                        {
                            foreach (DocEntity docEntity in docSchema.Entities)
                            {
                                if (docEntity.Name.Equals(docDef.DefinedType))
                                {
                                    LoadEntity(tn, docEntity);
                                }
                            }

                        }
                    }
                }
            }
        }

        private void LoadEntity(TreeNode tnParent, DocEntity entity)
        {
            if (entity == null)
                return; // no such entity

            // add entity
            TreeNode tn = new TreeNode();
            tn.Tag = entity;
            tn.Text = entity.Name;

            if (tnParent != null)
            {
                tnParent.Nodes.Add(tn);
            }
            else
            {
                this.treeView.Nodes.Add(tn);
            }

            if (this.m_selection == entity)
            {
                this.treeView.SelectedNode = tn;
            }

            this.LoadPredefined();

            // add subtypes
            SortedList<string, DocEntity> list = new SortedList<string, DocEntity>();
            foreach (DocSection docSection in this.m_project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        if (docEntity.BaseDefinition != null && docEntity.BaseDefinition.Equals(entity.Name))
                        {
                            list.Add(docEntity.Name, docEntity);
                        }
                    }
                }
            }

            foreach (DocEntity ent in list.Values)
            {
                LoadEntity(tn, ent);
            }
        }

        private void LoadPredefined()
        {
            if ((this.m_options & SelectDefinitionOptions.Predefined) == 0)
                return;

            this.labelPredefined.Enabled = false;
            this.comboBoxPredefined.Enabled = false;
            this.comboBoxPredefined.Items.Clear();
            this.comboBoxPredefined.SelectedIndex = -1;
            this.comboBoxPredefined.Text = String.Empty;

            if (this.treeView.SelectedNode == null)
                return;

            DocEntity entity = this.treeView.SelectedNode.Tag as DocEntity;
            if (entity == null)
                return;            

            foreach (DocAttribute docAttr in entity.Attributes)
            {
                if (docAttr.Name.Equals("PredefinedType"))
                {
                    // resolve the type

                    foreach (DocSection docSection in this.m_project.Sections)
                    {
                        foreach (DocSchema docSchema in docSection.Schemas)
                        {
                            foreach (DocType docType in docSchema.Types)
                            {
                                if (docType is DocEnumeration && docType.Name.Equals(docAttr.DefinedType))
                                {
                                    this.comboBoxPredefined.Items.Clear();

                                    // found it
                                    DocEnumeration docEnum = (DocEnumeration)docType;
                                    foreach (DocConstant docConst in docEnum.Constants)
                                    {
                                        // new: in combobox
                                        this.comboBoxPredefined.Items.Add(docConst);
                                    }

                                    this.labelPredefined.Enabled = true;
                                    this.comboBoxPredefined.Enabled = true;

                                    //return;
                                }
                            }
                        }
                    }
                }
            }
        }

        public DocDefinition SelectedEntity
        {
            get
            {
                if (this.treeView.SelectedNode == null)
                    return null;

                if (this.treeView.SelectedNode.Tag is DocDefinition)
                {
                    return this.treeView.SelectedNode.Tag as DocDefinition;
                }
                else if (this.treeView.SelectedNode.Tag is DocConstant)
                {
                    return this.treeView.SelectedNode.Parent.Tag as DocDefinition;
                }

                return null;
            }
        }

        /// <summary>
        /// For selecting predefined type, indicates the constant.
        /// </summary>
        public DocConstant SelectedConstant
        {
            get
            {
                return this.comboBoxPredefined.SelectedItem as DocConstant;
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.LoadPredefined();
        }
    }

    [Flags]
    public enum SelectDefinitionOptions
    {
        Entity = 1,
        Type = 2,
        Predefined = 4,
    }
}

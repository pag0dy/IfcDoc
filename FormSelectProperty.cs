using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public partial class FormSelectProperty : Form
    {
        DocEntity m_entity;
        DocProject m_project;
        string m_portname;

        public FormSelectProperty()
        {
            InitializeComponent();
        }

        public FormSelectProperty(DocEntity docEntity, DocProject docProject, bool multiselect) : this()
        {
            this.m_entity = docEntity;
            this.m_project = docProject;

            if (multiselect)
            {
                this.treeViewProperty.CheckBoxes = true;
                this.Text = "Include Property Sets";

                this.comboBoxPort.Enabled = false;
            }
            else
            {
                // find applicable ports
                this.comboBoxPort.Items.Add("(object)");
                this.comboBoxPort.SelectedIndex = 0;

                foreach (DocModelView docView in docProject.ModelViews)
                {
                    foreach (DocConceptRoot docRoot in docView.ConceptRoots)
                    {
                        if (docRoot.ApplicableEntity == docEntity)
                        {
                            foreach (DocTemplateUsage docConcept in docRoot.Concepts)
                            {
                                if (docConcept.Definition != null && docConcept.Definition.Uuid == DocTemplateDefinition.guidPortNesting)
                                {
                                    foreach (DocTemplateItem docItem in docConcept.Items)
                                    {
                                        string name = docItem.GetParameterValue("Name");
                                        if (name != null && !this.comboBoxPort.Items.Contains(name))
                                        {
                                            this.comboBoxPort.Items.Add(name);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            this.LoadPropertySets();
        }

        private void LoadPropertySets()
        {
            this.treeViewProperty.Nodes.Clear();

            DocEntity docEntity = this.m_entity;
            if (this.m_portname != null)
            {
                docEntity = this.m_project.GetDefinition("IfcDistributionPort") as DocEntity;
            }
            if (docEntity == null)
                return;

            foreach (DocSection docSection in this.m_project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocPropertySet docPset in docSchema.PropertySets)
                    {
                        bool include = false;
                        if (docPset.ApplicableType != null)
                        {
                            string[] parts = docPset.ApplicableType.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string part in parts)
                            {
                                DocEntity docBase = docEntity;
                                while (docBase != null)
                                {
                                    if (part.Contains(docBase.Name))
                                    {
                                        include = true;
                                        break;
                                    }

                                    docBase = this.m_project.GetDefinition(docBase.BaseDefinition) as DocEntity;
                                }
                            }
                        }

                        if (this.m_entity == null || include)
                        {
                            TreeNode tnPset = new TreeNode();
                            tnPset.Tag = docPset;
                            tnPset.Text = docPset.Name;
                            tnPset.ImageIndex = 0;
                            tnPset.SelectedImageIndex = 0;
                            this.treeViewProperty.Nodes.Add(tnPset);

                            if (!this.treeViewProperty.CheckBoxes)
                            {
                                foreach (DocProperty docProp in docPset.Properties)
                                {
                                    TreeNode tnProp = new TreeNode();
                                    tnProp.Tag = docProp;
                                    tnProp.Text = docProp.Name;
                                    tnProp.ImageIndex = 1;
                                    tnProp.SelectedImageIndex = 1;
                                    tnPset.Nodes.Add(tnProp);

                                    // also add min/max if bounded
                                    if (docProp.PropertyType == DocPropertyTemplateTypeEnum.P_BOUNDEDVALUE)
                                    {
                                        tnProp.Nodes.Add(new TreeNode("UpperBoundValue", 1, 1));
                                        tnProp.Nodes.Add(new TreeNode("LowerBoundValue", 1, 1));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            this.treeViewProperty.ExpandAll();

        }

        private void treeViewProperty_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DocObject docObj = this.treeViewProperty.SelectedNode.Tag as DocObject;
            if (docObj != null)
            {
                if(docObj is DocPropertySet)
                {
                    this.textBoxType.Text = ((DocPropertySet)docObj).PropertySetType;
                }
                else if(docObj is DocProperty)
                {
                    DocProperty docProp = (DocProperty)docObj;
                    this.textBoxType.Text = docProp.PropertyType + ": " + docProp.PrimaryDataType + " / " + docProp.SecondaryDataType; 
                }

                this.textBoxDescription.Text = docObj.Documentation;
            }
            else if(this.treeViewProperty.SelectedNode.Parent != null && this.treeViewProperty.SelectedNode.Parent.Tag is DocProperty)
            {
                DocProperty docProp = (DocProperty)this.treeViewProperty.SelectedNode.Parent.Tag;
                this.textBoxType.Text = docProp.PropertyType + ": " + docProp.PrimaryDataType + " / " + docProp.SecondaryDataType;
                this.textBoxDescription.Text = docProp.Documentation;
            }

            this.buttonOK.Enabled = (this.treeViewProperty.CheckBoxes || this.SelectedProperty != null);
        }

        /// <summary>
        /// Distribution port within object, or NULL if main object
        /// </summary>
        public string SelectedPort
        {
            get
            {
                return this.m_portname;
            }
        }

        /// <summary>
        /// For bounded values: UpperBoundValue, LowerBoundValue, or null.
        /// </summary>
        public string SelectedQualifier
        {
            get    
            {
                if (this.treeViewProperty.SelectedNode != null && this.treeViewProperty.SelectedNode.Tag == null)
                {
                    return this.treeViewProperty.SelectedNode.Text;
                }
                else
                {
                    return null;
                }
            }
        }

        public DocProperty SelectedProperty
        {
            get
            {
                if(this.treeViewProperty.SelectedNode != null && this.treeViewProperty.SelectedNode.Tag is DocProperty)
                {
                    return (DocProperty)this.treeViewProperty.SelectedNode.Tag;
                }
                else if (this.treeViewProperty.SelectedNode != null && this.treeViewProperty.SelectedNode.Parent != null && 
                    this.treeViewProperty.SelectedNode.Parent.Tag is DocProperty)
                {
                    return (DocProperty)this.treeViewProperty.SelectedNode.Parent.Tag;
                }


                return null;
            }
        }

        public DocPropertySet SelectedPropertySet
        {
            get
            {
                if(this.treeViewProperty.SelectedNode != null && this.treeViewProperty.SelectedNode.Tag is DocProperty)
                {
                    return (DocPropertySet)this.treeViewProperty.SelectedNode.Parent.Tag;
                }
                else if (this.treeViewProperty.SelectedNode != null && this.treeViewProperty.SelectedNode.Parent != null && this.treeViewProperty.SelectedNode.Parent.Tag is DocProperty)
                {
                    return (DocPropertySet)this.treeViewProperty.SelectedNode.Parent.Parent.Tag;
                }

                return null;
            }
        }

        public DocPropertySet[] IncludedPropertySets
        {
            get
            {
                List<DocPropertySet> list = new List<DocPropertySet>();
                foreach(TreeNode tn in this.treeViewProperty.Nodes)
                {
                    if(tn.Checked)
                    {
                        list.Add((DocPropertySet)tn.Tag);
                    }
                }

                return list.ToArray();
            }
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxPort.SelectedIndex == 0)
            {
                this.m_portname = null;
            }
            else
            {
                this.m_portname = this.comboBoxPort.SelectedItem as string;
            }
            this.LoadPropertySets();
        }
    }
}

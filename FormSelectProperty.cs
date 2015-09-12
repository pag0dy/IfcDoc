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
            }

            foreach(DocSection docSection in this.m_project.Sections)
            {
                foreach(DocSchema docSchema in docSection.Schemas)
                {
                    foreach(DocPropertySet docPset in docSchema.PropertySets)
                    {
                        bool include = false;
                        if (docPset.ApplicableType != null)
                        {
                            string[] parts = docPset.ApplicableType.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach(string part in parts)
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
                            this.treeViewProperty.Nodes.Add(tnPset);

                            if (!this.treeViewProperty.CheckBoxes)
                            {
                                foreach (DocProperty docProp in docPset.Properties)
                                {
                                    TreeNode tnProp = new TreeNode();
                                    tnProp.Tag = docProp;
                                    tnProp.Text = docProp.Name;
                                    tnPset.Nodes.Add(tnProp);
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
            this.buttonOK.Enabled = (this.treeViewProperty.CheckBoxes || (this.treeViewProperty.SelectedNode != null && this.treeViewProperty.SelectedNode.Tag is DocProperty));
        }

        public DocProperty SelectedProperty
        {
            get
            {
                if(this.treeViewProperty.SelectedNode != null && this.treeViewProperty.SelectedNode.Tag is DocProperty)
                {
                    return (DocProperty)this.treeViewProperty.SelectedNode.Tag;
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
    }
}

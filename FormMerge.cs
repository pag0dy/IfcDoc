// Name:        FormMerge.cs
// Description: Dialog box for merging files.
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2012 BuildingSmart International Ltd.
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
    public partial class FormMerge : Form
    {
        bool m_ignore;

        public FormMerge()
        {
            InitializeComponent();

            m_ignore = false;
        }

        public FormMerge(Dictionary<Guid, DocObject> mapOriginal, DocProject docChange) : this()
        {
            // add nodes for everything, then delete ones that haven't changed or don't have any children

            // iterate and find changes in documentation
            foreach (DocSection docChangeSection in docChange.Sections)
            {
                DocObject docOriginalSection = null;
                if(mapOriginal.TryGetValue(docChangeSection.Uuid, out docOriginalSection))
                {
                    foreach (DocSchema docChangeSchema in docChangeSection.Schemas)
                    {
                        DocObject docOriginalSchema;
                        if (mapOriginal.TryGetValue(docChangeSchema.Uuid, out docOriginalSchema))
                        {
                            // compare schemas

                            TreeNode tnSchema = this.AddNode(null, new ChangeInfo(docOriginalSchema.Name, docOriginalSchema, docChangeSchema));

                            foreach (DocType docChangeType in docChangeSchema.Types)
                            {
                                DocObject docOriginalType = null;
                                if (mapOriginal.TryGetValue(docChangeType.Uuid, out docOriginalType))
                                {
                                    if (!String.Equals(docOriginalType.Documentation, docChangeType.Documentation))
                                    {
                                        this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalType.Name, docOriginalType, docChangeType));
                                    }
                                }
                            }

                            foreach (DocEntity docChangeEntity in docChangeSchema.Entities)
                            {
                                DocObject docOriginalEntity = null;
                                if (mapOriginal.TryGetValue(docChangeEntity.Uuid, out docOriginalEntity))
                                {
                                    TreeNode tnEntity = null;
                                    if (!String.Equals(((DocEntity)docOriginalEntity).Documentation, docChangeEntity.Documentation)) // special case
                                    {
                                        tnEntity = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalEntity.Name, docOriginalEntity, docChangeEntity));
                                    }

                                    foreach (DocAttribute docChangeAttr in docChangeEntity.Attributes)
                                    {
                                        DocObject docOriginalAttr = null;
                                        if (mapOriginal.TryGetValue(docChangeAttr.Uuid, out docOriginalAttr))
                                        {
                                            if (!String.Equals(docOriginalAttr.Documentation, docChangeAttr.Documentation))
                                            {
                                                if (tnEntity == null)
                                                {
                                                    tnEntity = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalEntity.Name, docOriginalEntity, docChangeEntity));
                                                }

                                                this.AddNode(tnEntity, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalEntity.Name + "." + docOriginalAttr.Name, docOriginalAttr, docChangeAttr));
                                            }
                                        }
                                    }

                                    foreach (DocWhereRule docChangeAttr in docChangeEntity.WhereRules)
                                    {
                                        DocObject docOriginalAttr = null;
                                        if (mapOriginal.TryGetValue(docChangeAttr.Uuid, out docOriginalAttr))
                                        {
                                            if (!String.Equals(docOriginalAttr.Documentation, docChangeAttr.Documentation))
                                            {
                                                if (tnEntity == null)
                                                {
                                                    tnEntity = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalEntity.Name, docOriginalEntity, docChangeEntity));
                                                }

                                                this.AddNode(tnEntity, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalEntity.Name + "." + docOriginalAttr.Name, docOriginalAttr, docChangeAttr));
                                            }
                                        }
                                    }
                                }
                                
                            }

                            foreach (DocPropertySet docChangePset in docChangeSchema.PropertySets)
                            {
                                DocObject docOriginalPset = null;
                                if (mapOriginal.TryGetValue(docChangePset.Uuid, out docOriginalPset))
                                {
                                    TreeNode tnPset = null;
                                    if (!String.Equals(docOriginalPset.Documentation, docChangePset.Documentation))
                                    {
                                        tnPset = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name, docOriginalPset, docChangePset));
                                    }

                                    foreach (DocProperty docChangeProp in docChangePset.Properties)
                                    {
                                        DocObject docOriginalProp = ((DocPropertySet)docOriginalPset).GetProperty(docChangeProp.Name);
                                        if (docOriginalProp != null)
                                        {
                                            TreeNode tnProperty = null;
                                            if (!String.Equals(docOriginalProp.Documentation, docChangeProp.Documentation))
                                            {
                                                if (tnPset == null)
                                                {
                                                    tnPset = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name, docOriginalPset, docChangePset));
                                                }

                                                tnProperty = this.AddNode(tnPset, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name + "." + docOriginalProp.Name, docOriginalProp, docChangeProp));
                                            }

                                            // localization
                                            foreach (DocLocalization docChangeLocal in docChangeProp.Localization)
                                            {
                                                DocLocalization docOriginalLocal = docOriginalProp.GetLocalization(docChangeLocal.Locale);
                                                if (docOriginalLocal != null)
                                                {
                                                    if(!String.Equals(docOriginalLocal.Documentation, docChangeLocal.Documentation))
                                                    {
                                                        if (tnPset == null)
                                                        {
                                                            tnPset = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name, docOriginalPset, docChangePset));
                                                        }

                                                        if (tnProperty == null)
                                                        {
                                                            tnProperty = this.AddNode(tnPset, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name + "." + docOriginalProp.Name, docOriginalProp, docChangeProp));
                                                        }

                                                        this.AddNode(tnProperty, new ChangeInfo(docChangeLocal.Locale, docOriginalLocal, docChangeLocal));
                                                    }
                                                }
                                                else
                                                {
                                                    if (tnPset == null)
                                                    {
                                                        tnPset = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name, docOriginalPset, docChangePset));
                                                    }

                                                    if (tnProperty == null)
                                                    {
                                                        tnProperty = this.AddNode(tnPset, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name + "." + docOriginalProp.Name, docOriginalProp, docChangeProp));
                                                    }

                                                    // new localization
                                                    this.AddNode(tnProperty, new ChangeInfo(docChangeLocal.Locale, docOriginalLocal, docChangeLocal));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (tnPset == null)
                                            {
                                                tnPset = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name, docOriginalPset, docChangePset));
                                            }

                                            // NEW:
                                            this.AddNode(tnPset, new ChangeInfo(docChangeSchema.Name + "." + docChangePset.Name + "." + docChangeProp.Name, null, docChangeProp));
                                        }
                                    }
                                }
                                else
                                {
                                    // NEW:
                                    this.AddNode(tnSchema, new ChangeInfo(docChangeSchema.Name + "." + docChangePset.Name, null, docChangePset));
                                }

                            }

                            foreach (DocQuantitySet docChangePset in docChangeSchema.QuantitySets)
                            {
                                DocObject docOriginalPset = null;
                                if (mapOriginal.TryGetValue(docChangePset.Uuid, out docOriginalPset))
                                {
                                    TreeNode tnQset = null;
                                    if (!String.Equals(docOriginalPset.Documentation, docChangePset.Documentation))
                                    {
                                        tnQset = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name, docOriginalPset, docChangePset));
                                    }

                                    foreach (DocQuantity docChangeProp in docChangePset.Quantities)
                                    {
                                        DocObject docOriginalProp = ((DocQuantitySet)docOriginalPset).GetQuantity(docChangeProp.Name);
                                        if (docOriginalProp != null)
                                        {
                                            if (!String.Equals(docOriginalProp.Documentation, docChangeProp.Documentation))
                                            {
                                                if (tnQset == null)
                                                {
                                                    tnQset = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name, docOriginalPset, docChangePset));
                                                }
                                                this.AddNode(tnQset, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name + "." + docOriginalProp.Name, docOriginalProp, docChangeProp));
                                            }
                                        }
                                        else
                                        {
                                            if (tnQset == null)
                                            {
                                                tnQset = this.AddNode(tnSchema, new ChangeInfo(docOriginalSchema.Name + "." + docOriginalPset.Name, docOriginalPset, docChangePset));
                                            }

                                            // NEW:
                                            this.AddNode(tnQset, new ChangeInfo(docChangeSchema.Name + "." + docChangePset.Name + "." + docChangeProp.Name, null, docChangeProp));
                                        }
                                    }

                                }
                                else
                                {
                                    // NEW:
                                    this.AddNode(tnSchema, new ChangeInfo(docChangeSchema.Name + "." + docChangePset.Name, null, docChangePset));
                                }
                            }

                        }
                    }
                }
            }

            if (this.treeView.Nodes.Count > 0)
            {
                this.treeView.SelectedNode = this.treeView.Nodes[0];
            }
        }

        private void SaveNode(TreeNode tn)
        {
            ChangeInfo info = (ChangeInfo)tn.Tag;
            if (tn.Checked)
            {
                if (info.Original == null)
                {
                    // add new item
                    if (info.Change is DocLocalization)
                    {
                        DocLocalization localChange = (DocLocalization)info.Change;

                        ChangeInfo parentinfo = (ChangeInfo)tn.Parent.Tag;
                        DocObject docObj = (DocObject)parentinfo.Original;
                        docObj.RegisterLocalization(localChange.Locale, localChange.Name, localChange.Documentation);
                    }
                }
                else
                {
                    info.Original.Documentation = info.Change.Documentation;
                }
            }

            foreach (TreeNode tnSub in tn.Nodes)
            {
                SaveNode(tnSub);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                foreach (TreeNode tn in this.treeView.Nodes)
                {
                    SaveNode(tn);
                }
            }
        }

        private void radioButtonOriginal_Click(object sender, EventArgs e)
        {
            this.treeView.SelectedNode.Checked = true;
        }

        private void radioButtonChange_Click(object sender, EventArgs e)
        {
            this.treeView.SelectedNode.Checked = false;
        }

        private void UpdateNode(TreeNode tn)
        {
            ChangeInfo changeinfo = (ChangeInfo)tn.Tag;
            tn.Text = changeinfo.Change.Name;

            // back color indicates change type
            if (changeinfo.Original == null)
            {
                // addition
                tn.BackColor = Color.Lime;
            }
            else if (changeinfo.Change == null)
            {
                // deletion
                tn.BackColor = Color.Red;
            }
            else if (changeinfo.Original.Documentation != changeinfo.Change.Documentation || 
                (changeinfo.Original.Documentation != null && !changeinfo.Original.Documentation.Equals(changeinfo.Change.Documentation)))
            {
                // update
                tn.BackColor = Color.Yellow;
            }
            else
            {
                tn.BackColor = Color.Empty;
            }

            // checkbox indicates accept or reject
            //tn.Checked = changeinfo.Accept;
        }

        private TreeNode AddNode(TreeNode tnParent, ChangeInfo changeinfo)
        {
            TreeNode tn = new TreeNode();
            tn.Tag = changeinfo;
            UpdateNode(tn);

            if (tnParent != null)
            {
                tnParent.Nodes.Add(tn);
            }
            else
            {
                this.treeView.Nodes.Add(tn);
            }

            return tn;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ChangeInfo info = (ChangeInfo)this.treeView.SelectedNode.Tag;

            if (info.Original != null)
            {
                this.textBoxOriginal.Text = info.Original.Documentation;
            }
            else
            {
                this.textBoxOriginal.Text = String.Empty;
            }
            this.textBoxChange.Text = info.Change.Documentation;

            this.radioButtonOriginal.Checked = !this.treeView.SelectedNode.Checked;
            this.radioButtonChange.Checked = this.treeView.SelectedNode.Checked;
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (m_ignore)
                return;

            m_ignore = true;

            this.radioButtonOriginal.Checked = !this.treeView.SelectedNode.Checked;
            this.radioButtonChange.Checked = this.treeView.SelectedNode.Checked;

            CheckNode(e.Node, e.Node.Checked);

            m_ignore = false;
        }

        /// <summary>
        /// Recurses through all tree nodes setting check state
        /// </summary>
        /// <param name="tn"></param>
        private void CheckNode(TreeNode tn, bool state)
        {
            tn.Checked = state;
            foreach (TreeNode tnSub in tn.Nodes)
            {
                CheckNode(tnSub, state);
            }
        }
    }

    public class ChangeInfo
    {
        string m_caption;
        IDocumentation m_original;
        IDocumentation m_change;
        bool m_accept;

        public ChangeInfo(string caption, IDocumentation docOriginal, IDocumentation docChange)
        {
            m_caption = caption;
            m_original = docOriginal;
            m_change = docChange;
            m_accept = false;
        }

        public override string ToString()
        {
            string action = ": ";
            if (m_original == null)
            {
                action = "+ ";
            }
            else if (m_change == null)
            {
                action = "- ";
            }

            if (m_accept)
            {
                return action + m_caption + " [ACCEPT]";
            }
            else
            {
                return action + m_caption;
            }
        }

        public IDocumentation Original
        {
            get
            {
                return m_original;
            }
        }

        public IDocumentation Change
        {
            get
            {
                return m_change;
            }
        }

        /*
        public bool Accept
        {
            get
            {
                return this.m_accept;
            }
            set
            {
                this.m_accept = value;
            }
        }
         */
    }
}

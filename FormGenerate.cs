// Name:        FormGenerate.cs
// Description: Dialog box for generating documentation based on MVD schema
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2013 BuildingSmart International Ltd.
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
    public partial class FormGenerate : Form
    {
        DocProject m_project;

        public FormGenerate()
        {
            InitializeComponent();

            this.textBoxPath.Text = Properties.Settings.Default.OutputPath;
            this.textBoxHeader.Text = Properties.Settings.Default.Header;
            this.textBoxFooter.Text = Properties.Settings.Default.Footer;
            this.checkBoxHeader.Checked = !String.IsNullOrEmpty(this.textBoxHeader.Text);
            this.checkBoxFooter.Checked = !String.IsNullOrEmpty(this.textBoxFooter.Text);
            this.checkBoxSuppressHistory.Checked = Properties.Settings.Default.NoHistory;
            this.checkBoxSuppressXML.Checked = Properties.Settings.Default.NoXml;
            this.checkBoxExpressEnclosed.Checked = Properties.Settings.Default.ExpressComments;
            this.checkBoxSuppressXSD.Checked = Properties.Settings.Default.NoXsd;
            this.checkBoxDiagramTemplate.Checked = Properties.Settings.Default.DiagramTemplate;
            this.checkBoxDiagramConcept.Checked = Properties.Settings.Default.DiagramConcept;
            this.checkBoxRequirement.Checked = Properties.Settings.Default.Requirement;
            this.checkBoxExpressG.Checked = Properties.Settings.Default.ExpressG;
            this.checkBoxConceptTables.Checked = Properties.Settings.Default.ConceptTables;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (this.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.OutputPath = this.textBoxPath.Text;
                Properties.Settings.Default.Header = this.textBoxHeader.Text;
                Properties.Settings.Default.Footer = this.textBoxFooter.Text;
                Properties.Settings.Default.NoHistory = this.checkBoxSuppressHistory.Checked;
                Properties.Settings.Default.NoXml = this.checkBoxSuppressXML.Checked;
                Properties.Settings.Default.ExpressComments = this.checkBoxExpressEnclosed.Checked;
                Properties.Settings.Default.NoXsd = this.checkBoxSuppressXSD.Checked;
                Properties.Settings.Default.DiagramTemplate = this.checkBoxDiagramTemplate.Checked;
                Properties.Settings.Default.DiagramConcept = this.checkBoxDiagramConcept.Checked;
                Properties.Settings.Default.Requirement = this.checkBoxRequirement.Checked;
                Properties.Settings.Default.ExpressG = this.checkBoxExpressG.Checked;
                Properties.Settings.Default.ConceptTables = this.checkBoxConceptTables.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = this.textBoxPath.Text;
            DialogResult res = this.folderBrowserDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.textBoxPath.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        public DocProject Project
        {
            get
            {
                return this.m_project;
            }
            set
            {
                this.m_project = value;

                this.checkedListBoxViews.Items.Clear();
                foreach (DocModelView docView in this.m_project.ModelViews)
                {
                    this.checkedListBoxViews.Items.Add(docView);
                }
            }
        }

        public DocModelView[] Views
        {
            get
            {
                List<DocModelView> list = new List<DocModelView>();
                for(int i =0; i < checkedListBoxViews.Items.Count; i++)
                {
                    bool check = this.checkedListBoxViews.GetItemChecked(i);
                    if(check)
                    {
                        list.Add((DocModelView)this.checkedListBoxViews.Items[i]);
                    }
                }

                if(list.Count > 0)
                {
                    return list.ToArray();
                }

                return null;
            }
            set
            {
                if(value != null)
                {
                    foreach(DocModelView view in value)
                    {
                        int index = this.checkedListBoxViews.Items.IndexOf(view);
                        this.checkedListBoxViews.SetItemChecked(index, true);
                    }
                }
            }
        }

        public string[] Locales
        {
            get
            {
                return null;//...
            }
            set
            {
                //...
            }
        }

        public string SelectedPath
        {
            get
            {
                return this.textBoxPath.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                if (this.checkBoxHeader.Checked)
                {
                    return this.textBoxHeader.Text;
                }

                return null;
            }
        }

        public string PageFooter
        {
            get
            {
                if (this.checkBoxFooter.Checked)
                {
                    return this.textBoxFooter.Text;
                }

                return null;
            }
        }

        public bool SuppressHistory
        {
            get
            {
                return this.checkBoxSuppressHistory.Checked;
            }
        }

        public bool SuppressXML
        {
            get
            {
                return this.checkBoxSuppressXML.Checked;
            }
        }

        public bool ExpressEnclosed
        {
            get
            {
                return this.checkBoxExpressEnclosed.Checked;
            }
        }

        private void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxHeader.Checked)
                this.textBoxHeader.Text = "";
        }

        private void checkBoxFooter_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxFooter.Checked)
                this.textBoxFooter.Text = "";
        }

    }
}

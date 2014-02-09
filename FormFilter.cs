// Name:        FormFilter.cs
// Description: Dialog box for filtering items
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
    public partial class FormFilter : Form
    {
        DocProject m_project;

        public FormFilter()
        {
            InitializeComponent();
        }

        public FormFilter(DocProject project) : this()
        {
            this.m_project = project;
        }

        private void buttonTemplate_Click(object sender, EventArgs e)
        {
            using (FormSelectTemplate form = new FormSelectTemplate(null, this.m_project, null))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.SelectedTemplate != null)
                {
                    this.radioButtonTemplateAll.Checked = false;
                    this.radioButtonTemplateNone.Checked = false;
                    this.textBoxTemplate.Text = form.SelectedTemplate.Name;
                    this.textBoxTemplate.Tag = form.SelectedTemplate;
                }
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            using (FormSelectView form = new FormSelectView(this.m_project))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.Selection != null)
                {
                    this.radioButtonViewAll.Checked = false;
                    this.radioButtonViewNone.Checked = false;
                    this.textBoxView.Text = form.Selection.Name;
                    this.textBoxView.Tag = form.Selection;
                }
            }
        }

        private void buttonSchema_Click(object sender, EventArgs e)
        {
            using (FormSelectSchema form = new FormSelectSchema(this.m_project))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.Selection != null)
                {
                    this.radioButtonSchemaAll.Checked = false;
                    this.radioButtonSchemaNone.Checked = false;
                    this.textBoxSchema.Text = form.Selection.ToString();
                    this.textBoxSchema.Tag = form.Selection;
                }
            }
        }

        private void buttonLocale_Click(object sender, EventArgs e)
        {
            using (FormSelectLocale form = new FormSelectLocale())
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.SelectedLocale != null)
                {
                    this.radioButtonLocaleAll.Checked = false;
                    this.radioButtonLocaleNone.Checked = false;
                    this.textBoxLocale.Text = form.SelectedLocale.ToString();
                    this.textBoxLocale.Tag = form.SelectedLocale;
                }
            }
        }

        private void radioButtonTemplateAll_CheckedChanged(object sender, EventArgs e)
        {         
            this.textBoxTemplate.Text = String.Empty;
        }

        private void radioButtonTemplateNone_CheckedChanged(object sender, EventArgs e)
        {         
            this.textBoxTemplate.Text = String.Empty;
        }

        private void radioButtonViewAll_CheckedChanged(object sender, EventArgs e)
        {            
            this.textBoxView.Text = String.Empty;
        }

        private void radioButtonViewNone_CheckedChanged(object sender, EventArgs e)
        {         
            this.textBoxView.Text = String.Empty;
        }

        private void radioButtonSchemaAll_CheckedChanged(object sender, EventArgs e)
        {            
            this.textBoxSchema.Text = String.Empty;
        }

        private void radioButtonSchemaNone_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxSchema.Text = String.Empty;
        }

        private void radioButtonLocaleAll_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxLocale.Text = String.Empty;            
        }

        private void radioButtonLocaleNone_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxLocale.Text = String.Empty;            
        }

        public DocTemplateDefinition[] FilterTemplate
        {
            get
            {
                if (this.radioButtonTemplateNone.Checked)
                {
                    return new DocTemplateDefinition[0];
                }
                else if (this.textBoxTemplate.Tag is DocTemplateDefinition)
                {
                    return new DocTemplateDefinition[] { (DocTemplateDefinition)this.textBoxTemplate.Tag };
                }

                return null;
            }
        }

        public DocModelView[] FilterView
        {
            get
            {
                if (this.radioButtonViewNone.Checked)
                {
                    return new DocModelView[0];
                }
                else if (this.textBoxView.Tag is DocModelView)
                {
                    return new DocModelView[] { (DocModelView)this.textBoxView.Tag };
                }

                return null;
            }
        }

        public DocSchema[] FilterSchema
        {
            get
            {
                if (this.radioButtonSchemaNone.Checked)
                {
                    return new DocSchema[0];
                }
                else if (this.textBoxSchema.Tag is DocSchema)
                {
                    return new DocSchema[] { (DocSchema)this.textBoxSchema.Tag };
                }

                return null;
            }
        }

        public string[] FilterLocale
        {
            get
            {
                if (this.radioButtonLocaleNone.Checked)
                {
                    return new string[0];
                }
                else if (!String.IsNullOrEmpty(this.textBoxLocale.Text))
                {
                    return new string[] { this.textBoxLocale.Text };
                }

                return null;
            }
        }

        private void radioButtonTemplateAll_Click(object sender, EventArgs e)
        {
            this.radioButtonTemplateAll.Checked = true;
            this.radioButtonTemplateNone.Checked = false;
        }

        private void radioButtonTemplateNone_Click(object sender, EventArgs e)
        {
            this.radioButtonTemplateAll.Checked = false;
            this.radioButtonTemplateNone.Checked = true;
        }

        private void radioButtonViewAll_Click(object sender, EventArgs e)
        {
            this.radioButtonViewAll.Checked = true;
            this.radioButtonViewNone.Checked = false;
        }

        private void radioButtonViewNone_Click(object sender, EventArgs e)
        {
            this.radioButtonViewAll.Checked = false;
            this.radioButtonViewNone.Checked = true;
        }

        private void radioButtonSchemaAll_Click(object sender, EventArgs e)
        {
            this.radioButtonSchemaAll.Checked = true;
            this.radioButtonSchemaNone.Checked = false;
        }

        private void radioButtonSchemaNone_Click(object sender, EventArgs e)
        {
            this.radioButtonSchemaAll.Checked = false;
            this.radioButtonSchemaNone.Checked = true;
        }

        private void radioButtonLocaleAll_Click(object sender, EventArgs e)
        {
            this.radioButtonLocaleAll.Checked = true;
            this.radioButtonLocaleNone.Checked = false;
        }

        private void radioButtonLocaleNone_Click(object sender, EventArgs e)
        {
            this.radioButtonLocaleAll.Checked = false;
            this.radioButtonLocaleNone.Checked = true;
        }

    }
}

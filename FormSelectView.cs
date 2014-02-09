// Name:        FormSelectView.cs
// Description: Dialog box for selecting model view
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
    public partial class FormSelectView : Form
    {
        DocProject m_project;

        public FormSelectView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selection">Selected template.</param>
        /// <param name="project">Projet containing templates.</param>
        /// <param name="entity">The entity for which templates are filtered.</param>
        public FormSelectView(DocProject project)
            : this()
        {
            this.m_project = project;

            foreach (DocModelView docView in this.m_project.ModelViews)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = docView;
                lvi.Text = docView.Name;
                lvi.ImageIndex = 0;
                lvi.SubItems.Add(docView.Version);
                this.listView.Items.Add(lvi);
            }
        }

        public DocModelView Selection
        {
            get
            {
                if (this.listView.SelectedItems.Count == 1)
                {
                    return this.listView.SelectedItems[0].Tag as DocModelView;
                }

                return null;
            }
            set
            {
                this.listView.SelectedItems.Clear();

                foreach (ListViewItem lvi in this.listView.Items)
                {
                    if (lvi.Tag == value)
                    {
                        lvi.Selected = true;
                        return;
                    }
                }
            }
        }

        private void listView_ItemActivate(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

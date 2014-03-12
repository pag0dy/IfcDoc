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
        /// <param name="project">The project.</param>
        public FormSelectView(DocProject project, string description)
            : this()
        {
            this.m_project = project;

            if (description != null)
            {
                this.labelDescription.Text = description;
            }

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

        public DocModelView[] Selection
        {
            get
            {
                DocModelView[] sel = null;
                if (this.listView.SelectedItems.Count > 0)
                {
                    sel = new DocModelView [this.listView.SelectedItems.Count];
                    for(int i = 0; i < this.listView.SelectedItems.Count; i++)
                    {
                        sel[i] = this.listView.SelectedItems[i].Tag as DocModelView;
                    }
                }

                return sel;
            }
            set
            {
                this.listView.SelectedItems.Clear();
                if(value == null)
                    return;

                foreach (DocModelView view in value)
                {
                    foreach (ListViewItem lvi in this.listView.Items)
                    {
                        if (lvi.Tag == view)
                        {
                            lvi.Selected = true;
                            return;
                        }
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

// Name:        FormPublish.cs
// Description: Dialog box for uploading content to server
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2013 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public partial class FormPublish : Form
    {
        string m_localpath;
        DocProject m_project;
        List<DocModelView> m_views;
        Exception m_exception;
        int m_protocol;
        bool m_download;

        public FormPublish()
        {
            InitializeComponent();

            this.checkBoxRemember.Checked = !String.IsNullOrEmpty(Properties.Settings.Default.Username);
            this.textBoxUsername.Text = Properties.Settings.Default.Username;
            this.textBoxPassword.Text = Properties.Settings.Default.Password;

            this.m_views = new List<DocModelView>();
        }

        public bool Download
        {
            get
            {
                return this.m_download;
            }
            set
            {
                m_download = value;
                if (m_download)
                {
                    this.Text = "Download";
                    //this.treeViewContainer.Visible = true;
                    //this.listViewViews.Visible = false;
                }
                else
                {
                    this.Text = "Upload";
                    //this.treeViewContainer.Visible = false;
                    //this.listViewViews.Visible = true;
                }
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

                this.listViewViews.Items.Clear();

                if (!this.m_download)
                {
                    foreach (DocModelView docView in this.m_project.ModelViews)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Tag = docView;
                        lvi.Text = docView.Name;
                        this.listViewViews.Items.Add(lvi);
                    }
                }
            }
        }

        public string Url
        {
            get
            {
                return this.textBoxUrl.Text;
            }
            set
            {
                this.textBoxUrl.Text = value;
            }
        }

        public string LocalPath
        {
            get
            {
                return this.m_localpath;
            }
            set
            {
                this.m_localpath = value;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.textBoxUrl.Enabled = false;
            this.progressBar.Value = 0;
            this.buttonOK.Enabled = false;
            this.errorProvider.Clear();

            // register views locally
            this.m_views.Clear();

            if (this.m_download)
            {
                foreach(ListViewItem lvi in this.listViewViews.Items)
                {
                    if(lvi.Checked)
                    {
                        IfdContext ifdContext = (IfdContext)lvi.Tag;
                        Guid guidView = IfcDoc.Schema.SGuid.Parse(ifdContext.guid);

                        DocModelView docView = this.m_project.GetView(guidView);
                        if (docView == null)
                        {
                            docView = new DocModelView();
                            docView.Uuid = guidView;
                            docView.Name = lvi.Text;
                            docView.Status = ifdContext.status;
                            docView.Version = ifdContext.versionId;
                            docView.Copyright = ifdContext.versionDate;
                            // access rights not captured -- specific to user
                            this.m_project.ModelViews.Add(docView);
                        }

                        this.m_views.Add(docView);
                    }
                }
            }

            // start upload
            this.backgroundWorkerPublish.RunWorkerAsync();
        }

        private void backgroundWorkerPublish_DoWork(object sender, DoWorkEventArgs e)
        {
            // connect to server
            this.m_exception = null;
            try
            {
                if (this.m_download)
                {
                    switch (this.m_protocol)
                    {
                        case 0:
                            //...
                            break;

                        case 1:
                        case 2:
                            DataDictionary.Download(this.m_project, this.backgroundWorkerPublish, this.textBoxUrl.Text, this.textBoxUsername.Text, this.textBoxPassword.Text, this.m_views.ToArray());
                            break;
                    }
                }
                else
                {
                    switch (this.m_protocol)
                    {
                        case 0:
                            {
                                WebRequest request = HttpWebRequest.Create(this.textBoxUrl.Text);
                                request.Method = "POST";

                                using (FileStream streamFile = new FileStream(this.m_localpath, FileMode.Open))
                                {
                                    request.ContentLength = streamFile.Length;
                                    request.ContentType = "application/step";
                                    request.Headers[HttpRequestHeader.ContentLocation] = System.IO.Path.GetFileName(this.m_localpath);

                                    // for now, treat content type as opaque document attachment (don't set Content-Type to 'application/step')
                                    // future: treat as project file that be merged and compared

                                    using (Stream streamWeb = request.GetRequestStream())
                                    {
                                        {
                                            byte[] buffer = new byte[8192];
                                            int len = 0;
                                            do
                                            {
                                                len = streamFile.Read(buffer, 0, buffer.Length);
                                                if (len > 0)
                                                {
                                                    streamWeb.Write(buffer, 0, len);
                                                    this.backgroundWorkerPublish.ReportProgress((int)(100L * streamFile.Position / streamFile.Length));
                                                }
                                            } while (len > 0);
                                        }
                                    }
                                }
                            }
                            break;

                        case 1:
                        case 2:
                            //if (this.treeViewContainer.SelectedNode.Tag is IfdConcept)
                            {
                                //IfdConcept ifdConcept = (IfdConcept)this.treeViewContainer.SelectedNode.Tag;
                                DataDictionary.Upload(this.m_project, this.backgroundWorkerPublish, this.textBoxUrl.Text, this.textBoxUsername.Text, this.textBoxPassword.Text, String.Empty, this.m_views.ToArray());
                            }
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                this.m_exception = x;
            }
        }

        private void backgroundWorkerPublish_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerPublish_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (m_exception != null)
            {
                this.textBoxUrl.Enabled = true;
                this.buttonOK.Enabled = true;
                this.errorProvider.SetError(this.labelError, this.m_exception.Message);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void comboBoxProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.comboBoxProtocol.SelectedIndex)
            {
                case 0:
                    this.textBoxUrl.Text = "http://mvd.buildingsmart-tech.org/ifc4";
                    break;

                case 1:
                    this.textBoxUrl.Text = "http://test.bsdd.buildingsmart.org/";
                    break;

                case 2:
                    this.textBoxUrl.Text = "http://bsdd.buildingsmart.org/";
                    break;
            }

            this.m_protocol = this.comboBoxProtocol.SelectedIndex;
        }

        private void FormPublish_Load(object sender, EventArgs e)
        {
            this.comboBoxProtocol.SelectedIndex = 1;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.buttonLogin.Enabled = false;

            IfdConceptInRelationship ifdRoot = new IfdConceptInRelationship();
            ifdRoot.guid = "1aUB00FUqHuO00025QrE$V";
            TreeNode tnRoot = new TreeNode();
            tnRoot.Tag = ifdRoot;
            tnRoot.Text = "Data Dictionary";
            this.treeViewContainer.Nodes.Add(tnRoot);

            TreeNode tnSub = new TreeNode();
            tnSub.Text = "Loading...";
            tnRoot.Nodes.Add(tnSub);

            tnRoot.Expand(); // was trigger event notification to load

            //this.backgroundWorkerContexts.RunWorkerAsync();

            //this.backgroundWorkerConcepts.RunWorkerAsync(tnRoot);

            this.buttonOK.Enabled = true;
        }

        private void backgroundWorkerContexts_DoWork(object sender, DoWorkEventArgs e)
        {
            ResponseContext response = DataDictionary.GetContexts(this.m_project, this.backgroundWorkerContexts, this.textBoxUrl.Text, this.textBoxUsername.Text, this.textBoxPassword.Text);
            e.Result = response;
        }

        private void backgroundWorkerContexts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.buttonLogin.Enabled = true;
            this.listViewViews.Items.Clear();

            ResponseContext response = e.Result as ResponseContext;
            if (response == null)
                return;

            foreach (IfdContext ifdContext in response.IfdContext)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = ifdContext;
                if (ifdContext.fullNames != null && ifdContext.fullNames.Length > 0)
                {
                    string name = ifdContext.fullNames[0].name; // fallback on first name returned

                    // for now, hard-code to english ... todo: configure
                    foreach(IfdName ifdName in ifdContext.fullNames)
                    {
                        if (ifdName.language.languageCode == "en" && ifdName.nameType == "FULLNAME")
                        {
                            name = ifdName.name;
                        }
                    }

                    lvi.Text = name;

                    // version
                    lvi.SubItems.Add(ifdContext.versionId);

                    // version date
                    lvi.SubItems.Add(ifdContext.versionDate);

                    // version date
                    lvi.SubItems.Add(ifdContext.status);

                    string access = "";
                    if (ifdContext.restricted)
                    {
                        access = "Restricted";
                    }
                    else if(ifdContext.readOnly)
                    {
                        access = "Read-Only";
                    }
                    else
                    {
                        access = "Read/Write";
                    }
                    lvi.SubItems.Add(access);

                    this.listViewViews.Items.Add(lvi);
                }

                // how to deal with contexts without names? don't add them for now

            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (this.checkBoxRemember.Checked)
            {
                Properties.Settings.Default.Username = this.textBoxUsername.Text;
                Properties.Settings.Default.Password = this.textBoxPassword.Text;
            }
            else
            {
                Properties.Settings.Default.Username = String.Empty;
                Properties.Settings.Default.Password = String.Empty;
            }
            Properties.Settings.Default.Save();
        }

        private void listViewViews_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem lvi in this.listViewViews.Items)
            {
                if (lvi.Checked)
                {
                    this.buttonOK.Enabled = true;
                    return;
                }
            }

            this.buttonOK.Enabled = false;
        }

        private void treeViewContainer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            IfdConcept ifdConcept = e.Node.Tag as IfdConcept;
            if (ifdConcept != null && e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                // load child concepts
                try
                {
                    if (!this.backgroundWorkerConcepts.IsBusy)
                    {
                        this.backgroundWorkerConcepts.RunWorkerAsync(e.Node);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                catch
                {
                    e.Cancel = true;
                }
            }
        }

        private void backgroundWorkerConcepts_DoWork(object sender, DoWorkEventArgs e)
        {
            IfdConceptInRelationship ifdConcept = null;
            TreeNode tn = (TreeNode)e.Argument;
            ifdConcept = (IfdConceptInRelationship)tn.Tag;
            IList<IfdConceptInRelationship> listItem = DataDictionary.GetConcepts(this.m_project, this.backgroundWorkerConcepts, this.textBoxUrl.Text, this.textBoxUsername.Text, this.textBoxPassword.Text, ifdConcept, true);
            IList<IfdConceptInRelationship> listHost = DataDictionary.GetConcepts(this.m_project, this.backgroundWorkerConcepts, this.textBoxUrl.Text, this.textBoxUsername.Text, this.textBoxPassword.Text, ifdConcept, false);
            List<IfdConceptInRelationship> listComb = new List<IfdConceptInRelationship>();
            listComb.AddRange(listItem);
            listComb.AddRange(listHost);
            tn.Nodes[0].Tag = listComb;

            e.Result = tn;
        }

        private void backgroundWorkerConcepts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TreeNode tn = (TreeNode)e.Result;

            IList<IfdConceptInRelationship> list = (IList<IfdConceptInRelationship>)tn.Nodes[0].Tag;
            tn.Nodes.Clear();

            foreach (IfdConceptInRelationship conc in list)
            {
                TreeNode tnConc = new TreeNode();
                tnConc.Tag = conc;
                tnConc.Text = conc.ToString();

                IfdConceptTypeEnum ifdConceptType = IfdConceptTypeEnum.UNDEFINED;
                Enum.TryParse<IfdConceptTypeEnum>(conc.conceptType, out ifdConceptType);

                switch (ifdConceptType)
                {
                    case IfdConceptTypeEnum.BAG:
                        tnConc.ImageIndex = 24;
                        break;

                    case IfdConceptTypeEnum.NEST:
                        tnConc.ImageIndex = 10;
                        break;

                    case IfdConceptTypeEnum.PROPERTY:
                        tnConc.ImageIndex = 9;
                        break;

                    case IfdConceptTypeEnum.SUBJECT:
                        tnConc.ImageIndex = 5; // DocEntity
                        break;

                    case IfdConceptTypeEnum.MEASURE:
                        tnConc.ImageIndex = 4;
                        break;

                    case IfdConceptTypeEnum.ACTOR:
                        tnConc.ImageIndex = 8;
                        break;

                    case IfdConceptTypeEnum.DOCUMENT:
                        tnConc.ImageIndex = 20;
                        break;

                    case IfdConceptTypeEnum.CLASSIFICATION:
                        tnConc.ImageIndex = 1;
                        break;

                    default:
                        break;
                }
                tnConc.SelectedImageIndex = tnConc.ImageIndex;

                tn.Nodes.Add(tnConc);

                TreeNode tnSub = new TreeNode();
                tnSub.Text = "Loading...";
                tnConc.Nodes.Add(tnSub);
            }

            tn.Text += " (" + list.Count + ")";
        }
    }
}

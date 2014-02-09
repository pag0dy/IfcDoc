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

namespace IfcDoc
{
    public partial class FormPublish : Form
    {
        string m_localpath;
        Exception m_exception;

        public FormPublish()
        {
            InitializeComponent();
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

            // start upload
            this.backgroundWorkerPublish.RunWorkerAsync();
        }

        private void backgroundWorkerPublish_DoWork(object sender, DoWorkEventArgs e)
        {
            // connect to server
            this.m_exception = null;
            try
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
    }
}

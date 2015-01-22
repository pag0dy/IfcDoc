namespace IfcDoc
{
    partial class FormPublish
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPublish));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.labelSummary = new System.Windows.Forms.Label();
            this.backgroundWorkerPublish = new System.ComponentModel.BackgroundWorker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.errorProvider.SetError(this.progressBar, resources.GetString("progressBar.Error"));
            this.errorProvider.SetIconAlignment(this.progressBar, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("progressBar.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.progressBar, ((int)(resources.GetObject("progressBar.IconPadding"))));
            this.progressBar.Name = "progressBar";
            // 
            // textBoxUrl
            // 
            resources.ApplyResources(this.textBoxUrl, "textBoxUrl");
            this.errorProvider.SetError(this.textBoxUrl, resources.GetString("textBoxUrl.Error"));
            this.errorProvider.SetIconAlignment(this.textBoxUrl, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textBoxUrl.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.textBoxUrl, ((int)(resources.GetObject("textBoxUrl.IconPadding"))));
            this.textBoxUrl.Name = "textBoxUrl";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.buttonCancel, resources.GetString("buttonCancel.Error"));
            this.errorProvider.SetIconAlignment(this.buttonCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonCancel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.buttonCancel, ((int)(resources.GetObject("buttonCancel.IconPadding"))));
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.errorProvider.SetError(this.buttonOK, resources.GetString("buttonOK.Error"));
            this.errorProvider.SetIconAlignment(this.buttonOK, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonOK.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.buttonOK, ((int)(resources.GetObject("buttonOK.IconPadding"))));
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxComments
            // 
            resources.ApplyResources(this.textBoxComments, "textBoxComments");
            this.errorProvider.SetError(this.textBoxComments, resources.GetString("textBoxComments.Error"));
            this.errorProvider.SetIconAlignment(this.textBoxComments, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textBoxComments.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.textBoxComments, ((int)(resources.GetObject("textBoxComments.IconPadding"))));
            this.textBoxComments.Name = "textBoxComments";
            // 
            // labelSummary
            // 
            resources.ApplyResources(this.labelSummary, "labelSummary");
            this.errorProvider.SetError(this.labelSummary, resources.GetString("labelSummary.Error"));
            this.errorProvider.SetIconAlignment(this.labelSummary, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelSummary.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.labelSummary, ((int)(resources.GetObject("labelSummary.IconPadding"))));
            this.labelSummary.Name = "labelSummary";
            // 
            // backgroundWorkerPublish
            // 
            this.backgroundWorkerPublish.WorkerReportsProgress = true;
            this.backgroundWorkerPublish.WorkerSupportsCancellation = true;
            this.backgroundWorkerPublish.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPublish_DoWork);
            this.backgroundWorkerPublish.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerPublish_ProgressChanged);
            this.backgroundWorkerPublish.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPublish_RunWorkerCompleted);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // labelError
            // 
            resources.ApplyResources(this.labelError, "labelError");
            this.errorProvider.SetError(this.labelError, resources.GetString("labelError.Error"));
            this.errorProvider.SetIconAlignment(this.labelError, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelError.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.labelError, ((int)(resources.GetObject("labelError.IconPadding"))));
            this.labelError.Name = "labelError";
            // 
            // FormPublish
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.textBoxComments);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPublish";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label labelSummary;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPublish;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelError;
    }
}
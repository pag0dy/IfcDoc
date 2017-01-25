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
            this.comboBoxProtocol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // textBoxUrl
            // 
            resources.ApplyResources(this.textBoxUrl, "textBoxUrl");
            this.textBoxUrl.Name = "textBoxUrl";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxComments
            // 
            resources.ApplyResources(this.textBoxComments, "textBoxComments");
            this.textBoxComments.Name = "textBoxComments";
            // 
            // labelSummary
            // 
            resources.ApplyResources(this.labelSummary, "labelSummary");
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
            // 
            // labelError
            // 
            resources.ApplyResources(this.labelError, "labelError");
            this.labelError.Name = "labelError";
            // 
            // comboBoxProtocol
            // 
            this.comboBoxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProtocol.FormattingEnabled = true;
            this.comboBoxProtocol.Items.AddRange(new object[] {
            resources.GetString("comboBoxProtocol.Items"),
            resources.GetString("comboBoxProtocol.Items1"),
            resources.GetString("comboBoxProtocol.Items2")});
            resources.ApplyResources(this.comboBoxProtocol, "comboBoxProtocol");
            this.comboBoxProtocol.Name = "comboBoxProtocol";
            this.comboBoxProtocol.SelectedIndexChanged += new System.EventHandler(this.comboBoxProtocol_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // FormPublish
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxProtocol);
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
            this.Load += new System.EventHandler(this.FormPublish_Load);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxProtocol;
    }
}
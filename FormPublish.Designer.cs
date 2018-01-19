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
            this.labelSummary = new System.Windows.Forms.Label();
            this.backgroundWorkerPublish = new System.ComponentModel.BackgroundWorker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelError = new System.Windows.Forms.Label();
            this.comboBoxProtocol = new System.Windows.Forms.ComboBox();
            this.listViewViews = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAccess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorkerContexts = new System.ComponentModel.BackgroundWorker();
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            this.textBoxWarning = new System.Windows.Forms.TextBox();
            this.treeViewContainer = new System.Windows.Forms.TreeView();
            this.backgroundWorkerConcepts = new System.ComponentModel.BackgroundWorker();
            this.imageListIcon = new System.Windows.Forms.ImageList(this.components);
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
            this.textBoxUrl.ReadOnly = true;
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
            resources.ApplyResources(this.comboBoxProtocol, "comboBoxProtocol");
            this.comboBoxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProtocol.FormattingEnabled = true;
            this.comboBoxProtocol.Items.AddRange(new object[] {
            resources.GetString("comboBoxProtocol.Items"),
            resources.GetString("comboBoxProtocol.Items1"),
            resources.GetString("comboBoxProtocol.Items2")});
            this.comboBoxProtocol.Name = "comboBoxProtocol";
            this.comboBoxProtocol.SelectedIndexChanged += new System.EventHandler(this.comboBoxProtocol_SelectedIndexChanged);
            // 
            // listViewViews
            // 
            resources.ApplyResources(this.listViewViews, "listViewViews");
            this.listViewViews.CheckBoxes = true;
            this.listViewViews.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderVersion,
            this.columnHeaderDate,
            this.columnHeaderStatus,
            this.columnHeaderAccess});
            this.listViewViews.FullRowSelect = true;
            this.listViewViews.Name = "listViewViews";
            this.listViewViews.UseCompatibleStateImageBehavior = false;
            this.listViewViews.View = System.Windows.Forms.View.Details;
            this.listViewViews.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewViews_ItemChecked);
            // 
            // columnHeaderName
            // 
            resources.ApplyResources(this.columnHeaderName, "columnHeaderName");
            // 
            // columnHeaderVersion
            // 
            resources.ApplyResources(this.columnHeaderVersion, "columnHeaderVersion");
            // 
            // columnHeaderDate
            // 
            resources.ApplyResources(this.columnHeaderDate, "columnHeaderDate");
            // 
            // columnHeaderStatus
            // 
            resources.ApplyResources(this.columnHeaderStatus, "columnHeaderStatus");
            // 
            // columnHeaderAccess
            // 
            resources.ApplyResources(this.columnHeaderAccess, "columnHeaderAccess");
            // 
            // buttonLogin
            // 
            resources.ApplyResources(this.buttonLogin, "buttonLogin");
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBoxUsername
            // 
            resources.ApplyResources(this.textBoxUsername, "textBoxUsername");
            this.textBoxUsername.Name = "textBoxUsername";
            // 
            // textBoxPassword
            // 
            resources.ApplyResources(this.textBoxPassword, "textBoxPassword");
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // backgroundWorkerContexts
            // 
            this.backgroundWorkerContexts.WorkerReportsProgress = true;
            this.backgroundWorkerContexts.WorkerSupportsCancellation = true;
            this.backgroundWorkerContexts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerContexts_DoWork);
            this.backgroundWorkerContexts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerContexts_RunWorkerCompleted);
            // 
            // checkBoxRemember
            // 
            resources.ApplyResources(this.checkBoxRemember, "checkBoxRemember");
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.UseVisualStyleBackColor = true;
            // 
            // textBoxWarning
            // 
            this.textBoxWarning.BackColor = System.Drawing.Color.Red;
            this.textBoxWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxWarning, "textBoxWarning");
            this.textBoxWarning.ForeColor = System.Drawing.Color.White;
            this.textBoxWarning.Name = "textBoxWarning";
            this.textBoxWarning.ReadOnly = true;
            // 
            // treeViewContainer
            // 
            resources.ApplyResources(this.treeViewContainer, "treeViewContainer");
            this.treeViewContainer.ImageList = this.imageListIcon;
            this.treeViewContainer.Name = "treeViewContainer";
            this.treeViewContainer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewContainer_BeforeExpand);
            // 
            // backgroundWorkerConcepts
            // 
            this.backgroundWorkerConcepts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerConcepts_DoWork);
            this.backgroundWorkerConcepts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerConcepts_RunWorkerCompleted);
            // 
            // imageListIcon
            // 
            this.imageListIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcon.ImageStream")));
            this.imageListIcon.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageListIcon.Images.SetKeyName(0, "Folder.bmp");
            this.imageListIcon.Images.SetKeyName(1, "DocSection.bmp");
            this.imageListIcon.Images.SetKeyName(2, "DocAttribute.bmp");
            this.imageListIcon.Images.SetKeyName(3, "DocConstant.bmp");
            this.imageListIcon.Images.SetKeyName(4, "DocDefinedType.bmp");
            this.imageListIcon.Images.SetKeyName(5, "DocEntity.bmp");
            this.imageListIcon.Images.SetKeyName(6, "DocEnumeration.bmp");
            this.imageListIcon.Images.SetKeyName(7, "DocFunction.bmp");
            this.imageListIcon.Images.SetKeyName(8, "DocGlobalRule.bmp");
            this.imageListIcon.Images.SetKeyName(9, "DocProperty.bmp");
            this.imageListIcon.Images.SetKeyName(10, "DocPropertySet.bmp");
            this.imageListIcon.Images.SetKeyName(11, "DocQuantity.bmp");
            this.imageListIcon.Images.SetKeyName(12, "DocQuantitySet.bmp");
            this.imageListIcon.Images.SetKeyName(13, "DocSchema.bmp");
            this.imageListIcon.Images.SetKeyName(14, "DocSection.bmp");
            this.imageListIcon.Images.SetKeyName(15, "DocSelect.bmp");
            this.imageListIcon.Images.SetKeyName(16, "DocTemplateItem.bmp");
            this.imageListIcon.Images.SetKeyName(17, "DocConceptLeaf.png");
            this.imageListIcon.Images.SetKeyName(18, "DocUniqueRule.bmp");
            this.imageListIcon.Images.SetKeyName(19, "DocWhereRule.bmp");
            this.imageListIcon.Images.SetKeyName(20, "DocAnnex.bmp");
            this.imageListIcon.Images.SetKeyName(21, "DocEnumeration-Format.bmp");
            this.imageListIcon.Images.SetKeyName(22, "DocField-Inverse.bmp");
            this.imageListIcon.Images.SetKeyName(23, "DocTemplateDefinition.png");
            this.imageListIcon.Images.SetKeyName(24, "DocModelView.png");
            this.imageListIcon.Images.SetKeyName(25, "DocExchangeDefinition.png");
            this.imageListIcon.Images.SetKeyName(26, "DocExchangeItem.bmp");
            this.imageListIcon.Images.SetKeyName(27, "DocRuleAttribute.bmp");
            this.imageListIcon.Images.SetKeyName(28, "DocRuleEntity.bmp");
            this.imageListIcon.Images.SetKeyName(29, "DocChangeSet.bmp");
            this.imageListIcon.Images.SetKeyName(30, "DocConceptRoot.png");
            this.imageListIcon.Images.SetKeyName(31, "DocExample.png");
            this.imageListIcon.Images.SetKeyName(32, "DocEnumeration.bmp");
            this.imageListIcon.Images.SetKeyName(33, "DocConstant.bmp");
            this.imageListIcon.Images.SetKeyName(34, "Microsoft.VisualStudio.Blend.Html.Intrinsic.Mark.16x16.png");
            this.imageListIcon.Images.SetKeyName(35, "Microsoft.VisualStudio.Blend.Html.Intrinsic.Th.16x16.png");
            this.imageListIcon.Images.SetKeyName(36, "Microsoft.VisualStudio.Blend.Html.Intrinsic.Base.16x16.png");
            this.imageListIcon.Images.SetKeyName(37, "Microsoft.VisualStudio.Blend.Html.Intrinsic.Head.16x16.png");
            this.imageListIcon.Images.SetKeyName(38, "Microsoft.VS.Behavior.16x16.png");
            this.imageListIcon.Images.SetKeyName(39, "Microsoft.VS.Action.16x16.png");
            this.imageListIcon.Images.SetKeyName(40, "DocTerm.png");
            this.imageListIcon.Images.SetKeyName(41, "DocAbbreviation.png");
            this.imageListIcon.Images.SetKeyName(42, "Microsoft.VisualStudio.Blend.Html.Intrinsic.Div.Contenteditable.16x16.png");
            this.imageListIcon.Images.SetKeyName(43, "Microsoft.VisualStudio.Blend.Html.Intrinsic.Aside.16x16.png");
            this.imageListIcon.Images.SetKeyName(44, "ni0016-16.png");
            this.imageListIcon.Images.SetKeyName(45, "ni0017-16.png");
            this.imageListIcon.Images.SetKeyName(46, "ni0019-16.png");
            // 
            // FormPublish
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.treeViewContainer);
            this.Controls.Add(this.textBoxWarning);
            this.Controls.Add(this.checkBoxRemember);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.listViewViews);
            this.Controls.Add(this.comboBoxProtocol);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelSummary);
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
        private System.Windows.Forms.Label labelSummary;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPublish;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ComboBox comboBoxProtocol;
        private System.Windows.Forms.ListView listViewViews;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderAccess;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerContexts;
        private System.Windows.Forms.ColumnHeader columnHeaderVersion;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.CheckBox checkBoxRemember;
        private System.Windows.Forms.TextBox textBoxWarning;
        private System.Windows.Forms.TreeView treeViewContainer;
        private System.ComponentModel.BackgroundWorker backgroundWorkerConcepts;
        private System.Windows.Forms.ImageList imageListIcon;
    }
}
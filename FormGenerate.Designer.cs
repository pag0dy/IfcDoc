namespace IfcDoc
{
    partial class FormGenerate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerate));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonPath = new System.Windows.Forms.Button();
            this.textBoxHeader = new System.Windows.Forms.TextBox();
            this.textBoxFooter = new System.Windows.Forms.TextBox();
            this.checkBoxHeader = new System.Windows.Forms.CheckBox();
            this.checkBoxFooter = new System.Windows.Forms.CheckBox();
            this.checkBoxSuppressHistory = new System.Windows.Forms.CheckBox();
            this.checkBoxSuppressXML = new System.Windows.Forms.CheckBox();
            this.groupBoxLocation = new System.Windows.Forms.GroupBox();
            this.checkBoxSkip = new System.Windows.Forms.CheckBox();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.checkBoxSuppressXSD = new System.Windows.Forms.CheckBox();
            this.checkBoxExpressEnclosed = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxRequirement = new System.Windows.Forms.CheckBox();
            this.groupBoxModelView = new System.Windows.Forms.GroupBox();
            this.checkBoxExcludeWhereRules = new System.Windows.Forms.CheckBox();
            this.checkBoxConceptTables = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxViews = new System.Windows.Forms.GroupBox();
            this.checkedListBoxViews = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxExamples = new System.Windows.Forms.GroupBox();
            this.checkBoxExampleXML = new System.Windows.Forms.CheckBox();
            this.checkBoxExampleSPF = new System.Windows.Forms.CheckBox();
            this.groupBoxLocation.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.groupBoxModelView.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxViews.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxExamples.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBoxPath
            // 
            resources.ApplyResources(this.textBoxPath, "textBoxPath");
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            // 
            // buttonPath
            // 
            resources.ApplyResources(this.buttonPath, "buttonPath");
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // textBoxHeader
            // 
            resources.ApplyResources(this.textBoxHeader, "textBoxHeader");
            this.textBoxHeader.Name = "textBoxHeader";
            // 
            // textBoxFooter
            // 
            resources.ApplyResources(this.textBoxFooter, "textBoxFooter");
            this.textBoxFooter.Name = "textBoxFooter";
            // 
            // checkBoxHeader
            // 
            resources.ApplyResources(this.checkBoxHeader, "checkBoxHeader");
            this.checkBoxHeader.Name = "checkBoxHeader";
            this.checkBoxHeader.UseVisualStyleBackColor = true;
            this.checkBoxHeader.CheckedChanged += new System.EventHandler(this.checkBoxHeader_CheckedChanged);
            // 
            // checkBoxFooter
            // 
            resources.ApplyResources(this.checkBoxFooter, "checkBoxFooter");
            this.checkBoxFooter.Name = "checkBoxFooter";
            this.checkBoxFooter.UseVisualStyleBackColor = true;
            this.checkBoxFooter.CheckedChanged += new System.EventHandler(this.checkBoxFooter_CheckedChanged);
            // 
            // checkBoxSuppressHistory
            // 
            resources.ApplyResources(this.checkBoxSuppressHistory, "checkBoxSuppressHistory");
            this.checkBoxSuppressHistory.Name = "checkBoxSuppressHistory";
            this.checkBoxSuppressHistory.UseVisualStyleBackColor = true;
            // 
            // checkBoxSuppressXML
            // 
            resources.ApplyResources(this.checkBoxSuppressXML, "checkBoxSuppressXML");
            this.checkBoxSuppressXML.Name = "checkBoxSuppressXML";
            this.checkBoxSuppressXML.UseVisualStyleBackColor = true;
            // 
            // groupBoxLocation
            // 
            this.groupBoxLocation.Controls.Add(this.checkBoxSkip);
            this.groupBoxLocation.Controls.Add(this.buttonPath);
            this.groupBoxLocation.Controls.Add(this.label1);
            this.groupBoxLocation.Controls.Add(this.textBoxPath);
            resources.ApplyResources(this.groupBoxLocation, "groupBoxLocation");
            this.groupBoxLocation.Name = "groupBoxLocation";
            this.groupBoxLocation.TabStop = false;
            // 
            // checkBoxSkip
            // 
            resources.ApplyResources(this.checkBoxSkip, "checkBoxSkip");
            this.checkBoxSkip.Name = "checkBoxSkip";
            this.checkBoxSkip.UseVisualStyleBackColor = true;
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.checkBoxSuppressXSD);
            this.groupBoxDetails.Controls.Add(this.checkBoxExpressEnclosed);
            this.groupBoxDetails.Controls.Add(this.textBoxHeader);
            this.groupBoxDetails.Controls.Add(this.textBoxFooter);
            this.groupBoxDetails.Controls.Add(this.checkBoxHeader);
            this.groupBoxDetails.Controls.Add(this.checkBoxSuppressXML);
            this.groupBoxDetails.Controls.Add(this.checkBoxFooter);
            this.groupBoxDetails.Controls.Add(this.checkBoxSuppressHistory);
            resources.ApplyResources(this.groupBoxDetails, "groupBoxDetails");
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.TabStop = false;
            // 
            // checkBoxSuppressXSD
            // 
            resources.ApplyResources(this.checkBoxSuppressXSD, "checkBoxSuppressXSD");
            this.checkBoxSuppressXSD.Name = "checkBoxSuppressXSD";
            this.checkBoxSuppressXSD.UseVisualStyleBackColor = true;
            // 
            // checkBoxExpressEnclosed
            // 
            resources.ApplyResources(this.checkBoxExpressEnclosed, "checkBoxExpressEnclosed");
            this.checkBoxExpressEnclosed.Name = "checkBoxExpressEnclosed";
            this.checkBoxExpressEnclosed.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxRequirement
            // 
            resources.ApplyResources(this.checkBoxRequirement, "checkBoxRequirement");
            this.checkBoxRequirement.Name = "checkBoxRequirement";
            this.checkBoxRequirement.UseVisualStyleBackColor = true;
            // 
            // groupBoxModelView
            // 
            this.groupBoxModelView.Controls.Add(this.checkBoxExcludeWhereRules);
            this.groupBoxModelView.Controls.Add(this.checkBoxConceptTables);
            this.groupBoxModelView.Controls.Add(this.checkBoxRequirement);
            resources.ApplyResources(this.groupBoxModelView, "groupBoxModelView");
            this.groupBoxModelView.Name = "groupBoxModelView";
            this.groupBoxModelView.TabStop = false;
            // 
            // checkBoxExcludeWhereRules
            // 
            resources.ApplyResources(this.checkBoxExcludeWhereRules, "checkBoxExcludeWhereRules");
            this.checkBoxExcludeWhereRules.Name = "checkBoxExcludeWhereRules";
            this.checkBoxExcludeWhereRules.UseVisualStyleBackColor = true;
            // 
            // checkBoxConceptTables
            // 
            resources.ApplyResources(this.checkBoxConceptTables, "checkBoxConceptTables");
            this.checkBoxConceptTables.Name = "checkBoxConceptTables";
            this.checkBoxConceptTables.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxViews);
            this.tabPage1.Controls.Add(this.groupBoxLocation);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxViews
            // 
            resources.ApplyResources(this.groupBoxViews, "groupBoxViews");
            this.groupBoxViews.Controls.Add(this.checkedListBoxViews);
            this.groupBoxViews.Name = "groupBoxViews";
            this.groupBoxViews.TabStop = false;
            // 
            // checkedListBoxViews
            // 
            resources.ApplyResources(this.checkedListBoxViews, "checkedListBoxViews");
            this.checkedListBoxViews.FormattingEnabled = true;
            this.checkedListBoxViews.Name = "checkedListBoxViews";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxExamples);
            this.tabPage2.Controls.Add(this.groupBoxDetails);
            this.tabPage2.Controls.Add(this.groupBoxModelView);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxExamples
            // 
            resources.ApplyResources(this.groupBoxExamples, "groupBoxExamples");
            this.groupBoxExamples.Controls.Add(this.checkBoxExampleXML);
            this.groupBoxExamples.Controls.Add(this.checkBoxExampleSPF);
            this.groupBoxExamples.Name = "groupBoxExamples";
            this.groupBoxExamples.TabStop = false;
            // 
            // checkBoxExampleXML
            // 
            resources.ApplyResources(this.checkBoxExampleXML, "checkBoxExampleXML");
            this.checkBoxExampleXML.Name = "checkBoxExampleXML";
            this.checkBoxExampleXML.UseVisualStyleBackColor = true;
            // 
            // checkBoxExampleSPF
            // 
            resources.ApplyResources(this.checkBoxExampleSPF, "checkBoxExampleSPF");
            this.checkBoxExampleSPF.Name = "checkBoxExampleSPF";
            this.checkBoxExampleSPF.UseVisualStyleBackColor = true;
            // 
            // FormGenerate
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGenerate";
            this.ShowInTaskbar = false;
            this.groupBoxLocation.ResumeLayout(false);
            this.groupBoxLocation.PerformLayout();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBoxModelView.ResumeLayout(false);
            this.groupBoxModelView.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxViews.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBoxExamples.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.TextBox textBoxHeader;
        private System.Windows.Forms.TextBox textBoxFooter;
        private System.Windows.Forms.CheckBox checkBoxHeader;
        private System.Windows.Forms.CheckBox checkBoxFooter;
        private System.Windows.Forms.CheckBox checkBoxSuppressHistory;
        private System.Windows.Forms.CheckBox checkBoxSuppressXML;
        private System.Windows.Forms.GroupBox groupBoxLocation;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox checkBoxExpressEnclosed;
        private System.Windows.Forms.CheckBox checkBoxRequirement;
        private System.Windows.Forms.GroupBox groupBoxModelView;
        private System.Windows.Forms.CheckBox checkBoxSuppressXSD;
        private System.Windows.Forms.CheckBox checkBoxConceptTables;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxViews;
        private System.Windows.Forms.CheckedListBox checkedListBoxViews;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkBoxSkip;
        private System.Windows.Forms.CheckBox checkBoxExcludeWhereRules;
        private System.Windows.Forms.GroupBox groupBoxExamples;
        private System.Windows.Forms.CheckBox checkBoxExampleXML;
        private System.Windows.Forms.CheckBox checkBoxExampleSPF;
    }
}
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
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.checkBoxSuppressXSD = new System.Windows.Forms.CheckBox();
            this.checkBoxExpressG = new System.Windows.Forms.CheckBox();
            this.checkBoxExpressEnclosed = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxDiagramConcept = new System.Windows.Forms.CheckBox();
            this.checkBoxDiagramTemplate = new System.Windows.Forms.CheckBox();
            this.checkBoxRequirement = new System.Windows.Forms.CheckBox();
            this.groupBoxModelView = new System.Windows.Forms.GroupBox();
            this.checkBoxConceptTables = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxViews = new System.Windows.Forms.GroupBox();
            this.checkedListBoxViews = new System.Windows.Forms.CheckedListBox();
            this.groupBoxLocation.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.groupBoxModelView.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxViews.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Root folder path where to generate documentation:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(9, 38);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(484, 20);
            this.textBoxPath.TabIndex = 1;
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(499, 36);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(75, 23);
            this.buttonPath.TabIndex = 2;
            this.buttonPath.Text = "Browse...";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // textBoxHeader
            // 
            this.textBoxHeader.Location = new System.Drawing.Point(157, 15);
            this.textBoxHeader.Name = "textBoxHeader";
            this.textBoxHeader.Size = new System.Drawing.Size(417, 20);
            this.textBoxHeader.TabIndex = 1;
            // 
            // textBoxFooter
            // 
            this.textBoxFooter.Location = new System.Drawing.Point(157, 41);
            this.textBoxFooter.Name = "textBoxFooter";
            this.textBoxFooter.Size = new System.Drawing.Size(417, 20);
            this.textBoxFooter.TabIndex = 3;
            // 
            // checkBoxHeader
            // 
            this.checkBoxHeader.AutoSize = true;
            this.checkBoxHeader.Location = new System.Drawing.Point(9, 17);
            this.checkBoxHeader.Name = "checkBoxHeader";
            this.checkBoxHeader.Size = new System.Drawing.Size(133, 17);
            this.checkBoxHeader.TabIndex = 0;
            this.checkBoxHeader.Text = "Header on each page:";
            this.checkBoxHeader.UseVisualStyleBackColor = true;
            this.checkBoxHeader.CheckedChanged += new System.EventHandler(this.checkBoxHeader_CheckedChanged);
            // 
            // checkBoxFooter
            // 
            this.checkBoxFooter.AutoSize = true;
            this.checkBoxFooter.Location = new System.Drawing.Point(9, 43);
            this.checkBoxFooter.Name = "checkBoxFooter";
            this.checkBoxFooter.Size = new System.Drawing.Size(128, 17);
            this.checkBoxFooter.TabIndex = 2;
            this.checkBoxFooter.Text = "Footer on each page:";
            this.checkBoxFooter.UseVisualStyleBackColor = true;
            this.checkBoxFooter.CheckedChanged += new System.EventHandler(this.checkBoxFooter_CheckedChanged);
            // 
            // checkBoxSuppressHistory
            // 
            this.checkBoxSuppressHistory.AutoSize = true;
            this.checkBoxSuppressHistory.Location = new System.Drawing.Point(9, 69);
            this.checkBoxSuppressHistory.Name = "checkBoxSuppressHistory";
            this.checkBoxSuppressHistory.Size = new System.Drawing.Size(169, 17);
            this.checkBoxSuppressHistory.TabIndex = 4;
            this.checkBoxSuppressHistory.Text = "Suppress version history notes";
            this.checkBoxSuppressHistory.UseVisualStyleBackColor = true;
            // 
            // checkBoxSuppressXML
            // 
            this.checkBoxSuppressXML.AutoSize = true;
            this.checkBoxSuppressXML.Location = new System.Drawing.Point(9, 94);
            this.checkBoxSuppressXML.Name = "checkBoxSuppressXML";
            this.checkBoxSuppressXML.Size = new System.Drawing.Size(267, 17);
            this.checkBoxSuppressXML.TabIndex = 5;
            this.checkBoxSuppressXML.Text = "Suppress property set and quantity set links to XML";
            this.checkBoxSuppressXML.UseVisualStyleBackColor = true;
            // 
            // groupBoxLocation
            // 
            this.groupBoxLocation.Controls.Add(this.buttonPath);
            this.groupBoxLocation.Controls.Add(this.label1);
            this.groupBoxLocation.Controls.Add(this.textBoxPath);
            this.groupBoxLocation.Location = new System.Drawing.Point(6, 6);
            this.groupBoxLocation.Name = "groupBoxLocation";
            this.groupBoxLocation.Size = new System.Drawing.Size(580, 68);
            this.groupBoxLocation.TabIndex = 0;
            this.groupBoxLocation.TabStop = false;
            this.groupBoxLocation.Text = "Location";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.checkBoxSuppressXSD);
            this.groupBoxDetails.Controls.Add(this.checkBoxExpressG);
            this.groupBoxDetails.Controls.Add(this.checkBoxExpressEnclosed);
            this.groupBoxDetails.Controls.Add(this.textBoxHeader);
            this.groupBoxDetails.Controls.Add(this.textBoxFooter);
            this.groupBoxDetails.Controls.Add(this.checkBoxHeader);
            this.groupBoxDetails.Controls.Add(this.checkBoxSuppressXML);
            this.groupBoxDetails.Controls.Add(this.checkBoxFooter);
            this.groupBoxDetails.Controls.Add(this.checkBoxSuppressHistory);
            this.groupBoxDetails.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(580, 195);
            this.groupBoxDetails.TabIndex = 1;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "ISO Documentation Conformance";
            // 
            // checkBoxSuppressXSD
            // 
            this.checkBoxSuppressXSD.AutoSize = true;
            this.checkBoxSuppressXSD.Location = new System.Drawing.Point(9, 144);
            this.checkBoxSuppressXSD.Name = "checkBoxSuppressXSD";
            this.checkBoxSuppressXSD.Size = new System.Drawing.Size(145, 17);
            this.checkBoxSuppressXSD.TabIndex = 7;
            this.checkBoxSuppressXSD.Text = "Suppress XSD definitions";
            this.checkBoxSuppressXSD.UseVisualStyleBackColor = true;
            // 
            // checkBoxExpressG
            // 
            this.checkBoxExpressG.AutoSize = true;
            this.checkBoxExpressG.Location = new System.Drawing.Point(9, 169);
            this.checkBoxExpressG.Name = "checkBoxExpressG";
            this.checkBoxExpressG.Size = new System.Drawing.Size(134, 17);
            this.checkBoxExpressG.TabIndex = 8;
            this.checkBoxExpressG.Text = "EXPRESS-G Diagrams";
            this.checkBoxExpressG.UseVisualStyleBackColor = true;
            // 
            // checkBoxExpressEnclosed
            // 
            this.checkBoxExpressEnclosed.AutoSize = true;
            this.checkBoxExpressEnclosed.Location = new System.Drawing.Point(9, 119);
            this.checkBoxExpressEnclosed.Name = "checkBoxExpressEnclosed";
            this.checkBoxExpressEnclosed.Size = new System.Drawing.Size(258, 17);
            this.checkBoxExpressEnclosed.TabIndex = 6;
            this.checkBoxExpressEnclosed.Text = "Enclose EXPRESS definitions in comments *) .. (*";
            this.checkBoxExpressEnclosed.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(456, 407);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(537, 407);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxDiagramConcept
            // 
            this.checkBoxDiagramConcept.AutoSize = true;
            this.checkBoxDiagramConcept.Location = new System.Drawing.Point(8, 48);
            this.checkBoxDiagramConcept.Name = "checkBoxDiagramConcept";
            this.checkBoxDiagramConcept.Size = new System.Drawing.Size(132, 17);
            this.checkBoxDiagramConcept.TabIndex = 1;
            this.checkBoxDiagramConcept.Text = "Concept root diagrams";
            this.checkBoxDiagramConcept.UseVisualStyleBackColor = true;
            // 
            // checkBoxDiagramTemplate
            // 
            this.checkBoxDiagramTemplate.AutoSize = true;
            this.checkBoxDiagramTemplate.Location = new System.Drawing.Point(8, 23);
            this.checkBoxDiagramTemplate.Name = "checkBoxDiagramTemplate";
            this.checkBoxDiagramTemplate.Size = new System.Drawing.Size(154, 17);
            this.checkBoxDiagramTemplate.TabIndex = 0;
            this.checkBoxDiagramTemplate.Text = "Concept template diagrams";
            this.checkBoxDiagramTemplate.UseVisualStyleBackColor = true;
            // 
            // checkBoxRequirement
            // 
            this.checkBoxRequirement.AutoSize = true;
            this.checkBoxRequirement.Location = new System.Drawing.Point(8, 73);
            this.checkBoxRequirement.Name = "checkBoxRequirement";
            this.checkBoxRequirement.Size = new System.Drawing.Size(163, 17);
            this.checkBoxRequirement.TabIndex = 2;
            this.checkBoxRequirement.Text = "Exchange requirement tables";
            this.checkBoxRequirement.UseVisualStyleBackColor = true;
            // 
            // groupBoxModelView
            // 
            this.groupBoxModelView.Controls.Add(this.checkBoxConceptTables);
            this.groupBoxModelView.Controls.Add(this.checkBoxRequirement);
            this.groupBoxModelView.Controls.Add(this.checkBoxDiagramConcept);
            this.groupBoxModelView.Controls.Add(this.checkBoxDiagramTemplate);
            this.groupBoxModelView.Location = new System.Drawing.Point(7, 207);
            this.groupBoxModelView.Name = "groupBoxModelView";
            this.groupBoxModelView.Size = new System.Drawing.Size(579, 126);
            this.groupBoxModelView.TabIndex = 2;
            this.groupBoxModelView.TabStop = false;
            this.groupBoxModelView.Text = "MVD Documentation Conformance";
            // 
            // checkBoxConceptTables
            // 
            this.checkBoxConceptTables.AutoSize = true;
            this.checkBoxConceptTables.Location = new System.Drawing.Point(8, 96);
            this.checkBoxConceptTables.Name = "checkBoxConceptTables";
            this.checkBoxConceptTables.Size = new System.Drawing.Size(129, 17);
            this.checkBoxConceptTables.TabIndex = 3;
            this.checkBoxConceptTables.Text = "Rule parameter tables";
            this.checkBoxConceptTables.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(600, 389);
            this.tabControl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxViews);
            this.tabPage1.Controls.Add(this.groupBoxLocation);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Content";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxDetails);
            this.tabPage2.Controls.Add(this.groupBoxModelView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Format";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxViews
            // 
            this.groupBoxViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxViews.Controls.Add(this.checkedListBoxViews);
            this.groupBoxViews.Location = new System.Drawing.Point(6, 80);
            this.groupBoxViews.Name = "groupBoxViews";
            this.groupBoxViews.Size = new System.Drawing.Size(580, 261);
            this.groupBoxViews.TabIndex = 1;
            this.groupBoxViews.TabStop = false;
            this.groupBoxViews.Text = "Model Views";
            // 
            // checkedListBoxViews
            // 
            this.checkedListBoxViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxViews.FormattingEnabled = true;
            this.checkedListBoxViews.Location = new System.Drawing.Point(9, 20);
            this.checkedListBoxViews.Name = "checkedListBoxViews";
            this.checkedListBoxViews.Size = new System.Drawing.Size(565, 229);
            this.checkedListBoxViews.TabIndex = 0;
            // 
            // FormGenerate
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGenerate";
            this.ShowInTaskbar = false;
            this.Text = "Generate Documentation";
            this.groupBoxLocation.ResumeLayout(false);
            this.groupBoxLocation.PerformLayout();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBoxModelView.ResumeLayout(false);
            this.groupBoxModelView.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBoxViews.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox checkBoxDiagramConcept;
        private System.Windows.Forms.CheckBox checkBoxDiagramTemplate;
        private System.Windows.Forms.CheckBox checkBoxRequirement;
        private System.Windows.Forms.CheckBox checkBoxExpressG;
        private System.Windows.Forms.GroupBox groupBoxModelView;
        private System.Windows.Forms.CheckBox checkBoxSuppressXSD;
        private System.Windows.Forms.CheckBox checkBoxConceptTables;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxViews;
        private System.Windows.Forms.CheckedListBox checkedListBoxViews;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
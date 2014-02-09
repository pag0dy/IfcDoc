namespace IfcDoc
{
    partial class FormCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCode));
            this.groupBoxLocation = new System.Windows.Forms.GroupBox();
            this.buttonPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBoxFieldSerializationSaving = new System.Windows.Forms.CheckBox();
            this.checkBoxPropertyEpilogue = new System.Windows.Forms.CheckBox();
            this.checkBoxFieldSerializationLoading = new System.Windows.Forms.CheckBox();
            this.checkBoxConstructorEpilogue = new System.Windows.Forms.CheckBox();
            this.checkBoxFields = new System.Windows.Forms.CheckBox();
            this.checkBoxPropertyPrologue = new System.Windows.Forms.CheckBox();
            this.checkBoxProperties = new System.Windows.Forms.CheckBox();
            this.checkBoxConstructors = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxLocation.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLocation
            // 
            this.groupBoxLocation.Controls.Add(this.buttonPath);
            this.groupBoxLocation.Controls.Add(this.label2);
            this.groupBoxLocation.Controls.Add(this.textBoxPath);
            this.groupBoxLocation.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLocation.Name = "groupBoxLocation";
            this.groupBoxLocation.Size = new System.Drawing.Size(600, 68);
            this.groupBoxLocation.TabIndex = 2;
            this.groupBoxLocation.TabStop = false;
            this.groupBoxLocation.Text = "Location";
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(515, 36);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(75, 23);
            this.buttonPath.TabIndex = 2;
            this.buttonPath.Text = "Browse...";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Root folder path where to generate source code:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(9, 38);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(500, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.Text = "C:\\IFC_CODE";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.label1);
            this.groupBoxDetails.Controls.Add(this.comboBoxLanguage);
            this.groupBoxDetails.Location = new System.Drawing.Point(12, 84);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(600, 67);
            this.groupBoxDetails.TabIndex = 3;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Platform";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programming Language:";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "C#",
            "Java"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(9, 35);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(581, 21);
            this.comboBoxLanguage.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBoxFieldSerializationSaving);
            this.groupBox1.Controls.Add(this.checkBoxPropertyEpilogue);
            this.groupBox1.Controls.Add(this.checkBoxFieldSerializationLoading);
            this.groupBox1.Controls.Add(this.checkBoxConstructorEpilogue);
            this.groupBox1.Controls.Add(this.checkBoxFields);
            this.groupBox1.Controls.Add(this.checkBoxPropertyPrologue);
            this.groupBox1.Controls.Add(this.checkBoxProperties);
            this.groupBox1.Controls.Add(this.checkBoxConstructors);
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Code";
            this.groupBox1.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(181, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Constructor validation";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBoxFieldSerializationSaving
            // 
            this.checkBoxFieldSerializationSaving.AutoSize = true;
            this.checkBoxFieldSerializationSaving.Location = new System.Drawing.Point(347, 21);
            this.checkBoxFieldSerializationSaving.Name = "checkBoxFieldSerializationSaving";
            this.checkBoxFieldSerializationSaving.Size = new System.Drawing.Size(139, 17);
            this.checkBoxFieldSerializationSaving.TabIndex = 2;
            this.checkBoxFieldSerializationSaving.Text = "Field serialization saving";
            this.checkBoxFieldSerializationSaving.UseVisualStyleBackColor = true;
            // 
            // checkBoxPropertyEpilogue
            // 
            this.checkBoxPropertyEpilogue.AutoSize = true;
            this.checkBoxPropertyEpilogue.Location = new System.Drawing.Point(347, 47);
            this.checkBoxPropertyEpilogue.Name = "checkBoxPropertyEpilogue";
            this.checkBoxPropertyEpilogue.Size = new System.Drawing.Size(137, 17);
            this.checkBoxPropertyEpilogue.TabIndex = 4;
            this.checkBoxPropertyEpilogue.Text = "Property setter epilogue";
            this.checkBoxPropertyEpilogue.UseVisualStyleBackColor = true;
            // 
            // checkBoxFieldSerializationLoading
            // 
            this.checkBoxFieldSerializationLoading.AutoSize = true;
            this.checkBoxFieldSerializationLoading.Location = new System.Drawing.Point(181, 21);
            this.checkBoxFieldSerializationLoading.Name = "checkBoxFieldSerializationLoading";
            this.checkBoxFieldSerializationLoading.Size = new System.Drawing.Size(142, 17);
            this.checkBoxFieldSerializationLoading.TabIndex = 1;
            this.checkBoxFieldSerializationLoading.Text = "Field serialization loading";
            this.checkBoxFieldSerializationLoading.UseVisualStyleBackColor = true;
            // 
            // checkBoxConstructorEpilogue
            // 
            this.checkBoxConstructorEpilogue.AutoSize = true;
            this.checkBoxConstructorEpilogue.Location = new System.Drawing.Point(347, 73);
            this.checkBoxConstructorEpilogue.Name = "checkBoxConstructorEpilogue";
            this.checkBoxConstructorEpilogue.Size = new System.Drawing.Size(123, 17);
            this.checkBoxConstructorEpilogue.TabIndex = 7;
            this.checkBoxConstructorEpilogue.Text = "Constructor epilogue";
            this.checkBoxConstructorEpilogue.UseVisualStyleBackColor = true;
            // 
            // checkBoxFields
            // 
            this.checkBoxFields.AutoSize = true;
            this.checkBoxFields.Location = new System.Drawing.Point(9, 21);
            this.checkBoxFields.Name = "checkBoxFields";
            this.checkBoxFields.Size = new System.Drawing.Size(100, 17);
            this.checkBoxFields.TabIndex = 0;
            this.checkBoxFields.Text = "Generate Fields";
            this.checkBoxFields.UseVisualStyleBackColor = true;
            // 
            // checkBoxPropertyPrologue
            // 
            this.checkBoxPropertyPrologue.AutoSize = true;
            this.checkBoxPropertyPrologue.Location = new System.Drawing.Point(181, 47);
            this.checkBoxPropertyPrologue.Name = "checkBoxPropertyPrologue";
            this.checkBoxPropertyPrologue.Size = new System.Drawing.Size(138, 17);
            this.checkBoxPropertyPrologue.TabIndex = 4;
            this.checkBoxPropertyPrologue.Text = "Property setter prologue";
            this.checkBoxPropertyPrologue.UseVisualStyleBackColor = true;
            // 
            // checkBoxProperties
            // 
            this.checkBoxProperties.AutoSize = true;
            this.checkBoxProperties.Location = new System.Drawing.Point(9, 47);
            this.checkBoxProperties.Name = "checkBoxProperties";
            this.checkBoxProperties.Size = new System.Drawing.Size(120, 17);
            this.checkBoxProperties.TabIndex = 3;
            this.checkBoxProperties.Text = "Generate Properties";
            this.checkBoxProperties.UseVisualStyleBackColor = true;
            // 
            // checkBoxConstructors
            // 
            this.checkBoxConstructors.AutoSize = true;
            this.checkBoxConstructors.Location = new System.Drawing.Point(9, 73);
            this.checkBoxConstructors.Name = "checkBoxConstructors";
            this.checkBoxConstructors.Size = new System.Drawing.Size(132, 17);
            this.checkBoxConstructors.TabIndex = 5;
            this.checkBoxConstructors.Text = "Generate Constructors";
            this.checkBoxConstructors.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(537, 160);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(456, 160);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // FormCode
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(624, 195);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.groupBoxLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCode";
            this.Text = "Generate Source Code";
            this.Load += new System.EventHandler(this.FormCode_Load);
            this.groupBoxLocation.ResumeLayout(false);
            this.groupBoxLocation.PerformLayout();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLocation;
        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxFieldSerializationLoading;
        private System.Windows.Forms.CheckBox checkBoxConstructorEpilogue;
        private System.Windows.Forms.CheckBox checkBoxFields;
        private System.Windows.Forms.CheckBox checkBoxPropertyPrologue;
        private System.Windows.Forms.CheckBox checkBoxProperties;
        private System.Windows.Forms.CheckBox checkBoxConstructors;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBoxFieldSerializationSaving;
        private System.Windows.Forms.CheckBox checkBoxPropertyEpilogue;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
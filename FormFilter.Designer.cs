namespace IfcDoc
{
    partial class FormFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFilter));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonTemplateAll = new System.Windows.Forms.RadioButton();
            this.radioButtonTemplateNone = new System.Windows.Forms.RadioButton();
            this.textBoxTemplate = new System.Windows.Forms.TextBox();
            this.buttonTemplate = new System.Windows.Forms.Button();
            this.buttonView = new System.Windows.Forms.Button();
            this.textBoxView = new System.Windows.Forms.TextBox();
            this.radioButtonViewNone = new System.Windows.Forms.RadioButton();
            this.radioButtonViewAll = new System.Windows.Forms.RadioButton();
            this.buttonSchema = new System.Windows.Forms.Button();
            this.textBoxSchema = new System.Windows.Forms.TextBox();
            this.radioButtonSchemaNone = new System.Windows.Forms.RadioButton();
            this.radioButtonSchemaAll = new System.Windows.Forms.RadioButton();
            this.buttonLocale = new System.Windows.Forms.Button();
            this.textBoxLocale = new System.Windows.Forms.TextBox();
            this.radioButtonLocaleNone = new System.Windows.Forms.RadioButton();
            this.radioButtonLocaleAll = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(220, 189);
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
            this.buttonCancel.Location = new System.Drawing.Point(301, 189);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Choose whether to include all information or a specified subset.";
            // 
            // radioButtonTemplateAll
            // 
            this.radioButtonTemplateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonTemplateAll.AutoCheck = false;
            this.radioButtonTemplateAll.AutoSize = true;
            this.radioButtonTemplateAll.Checked = true;
            this.radioButtonTemplateAll.Location = new System.Drawing.Point(283, 52);
            this.radioButtonTemplateAll.Name = "radioButtonTemplateAll";
            this.radioButtonTemplateAll.Size = new System.Drawing.Size(36, 17);
            this.radioButtonTemplateAll.TabIndex = 5;
            this.radioButtonTemplateAll.Text = "All";
            this.radioButtonTemplateAll.UseVisualStyleBackColor = true;
            this.radioButtonTemplateAll.Click += new System.EventHandler(this.radioButtonTemplateAll_Click);
            this.radioButtonTemplateAll.CheckedChanged += new System.EventHandler(this.radioButtonTemplateAll_CheckedChanged);
            // 
            // radioButtonTemplateNone
            // 
            this.radioButtonTemplateNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonTemplateNone.AutoCheck = false;
            this.radioButtonTemplateNone.AutoSize = true;
            this.radioButtonTemplateNone.Location = new System.Drawing.Point(325, 52);
            this.radioButtonTemplateNone.Name = "radioButtonTemplateNone";
            this.radioButtonTemplateNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonTemplateNone.TabIndex = 6;
            this.radioButtonTemplateNone.Text = "None";
            this.radioButtonTemplateNone.UseVisualStyleBackColor = true;
            this.radioButtonTemplateNone.Click += new System.EventHandler(this.radioButtonTemplateNone_Click);
            this.radioButtonTemplateNone.CheckedChanged += new System.EventHandler(this.radioButtonTemplateNone_CheckedChanged);
            // 
            // textBoxTemplate
            // 
            this.textBoxTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTemplate.Location = new System.Drawing.Point(93, 51);
            this.textBoxTemplate.Name = "textBoxTemplate";
            this.textBoxTemplate.ReadOnly = true;
            this.textBoxTemplate.Size = new System.Drawing.Size(180, 20);
            this.textBoxTemplate.TabIndex = 4;
            // 
            // buttonTemplate
            // 
            this.buttonTemplate.Location = new System.Drawing.Point(12, 49);
            this.buttonTemplate.Name = "buttonTemplate";
            this.buttonTemplate.Size = new System.Drawing.Size(75, 23);
            this.buttonTemplate.TabIndex = 3;
            this.buttonTemplate.Text = "Template...";
            this.buttonTemplate.UseVisualStyleBackColor = true;
            this.buttonTemplate.Click += new System.EventHandler(this.buttonTemplate_Click);
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(12, 75);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(75, 23);
            this.buttonView.TabIndex = 7;
            this.buttonView.Text = "View...";
            this.buttonView.UseVisualStyleBackColor = true;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // textBoxView
            // 
            this.textBoxView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxView.Location = new System.Drawing.Point(93, 77);
            this.textBoxView.Name = "textBoxView";
            this.textBoxView.ReadOnly = true;
            this.textBoxView.Size = new System.Drawing.Size(180, 20);
            this.textBoxView.TabIndex = 8;
            // 
            // radioButtonViewNone
            // 
            this.radioButtonViewNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonViewNone.AutoCheck = false;
            this.radioButtonViewNone.AutoSize = true;
            this.radioButtonViewNone.Location = new System.Drawing.Point(325, 78);
            this.radioButtonViewNone.Name = "radioButtonViewNone";
            this.radioButtonViewNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonViewNone.TabIndex = 10;
            this.radioButtonViewNone.Text = "None";
            this.radioButtonViewNone.UseVisualStyleBackColor = true;
            this.radioButtonViewNone.Click += new System.EventHandler(this.radioButtonViewNone_Click);
            this.radioButtonViewNone.CheckedChanged += new System.EventHandler(this.radioButtonViewNone_CheckedChanged);
            // 
            // radioButtonViewAll
            // 
            this.radioButtonViewAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonViewAll.AutoCheck = false;
            this.radioButtonViewAll.AutoSize = true;
            this.radioButtonViewAll.Checked = true;
            this.radioButtonViewAll.Location = new System.Drawing.Point(283, 78);
            this.radioButtonViewAll.Name = "radioButtonViewAll";
            this.radioButtonViewAll.Size = new System.Drawing.Size(36, 17);
            this.radioButtonViewAll.TabIndex = 9;
            this.radioButtonViewAll.TabStop = true;
            this.radioButtonViewAll.Text = "All";
            this.radioButtonViewAll.UseVisualStyleBackColor = true;
            this.radioButtonViewAll.Click += new System.EventHandler(this.radioButtonViewAll_Click);
            this.radioButtonViewAll.CheckedChanged += new System.EventHandler(this.radioButtonViewAll_CheckedChanged);
            // 
            // buttonSchema
            // 
            this.buttonSchema.Location = new System.Drawing.Point(12, 101);
            this.buttonSchema.Name = "buttonSchema";
            this.buttonSchema.Size = new System.Drawing.Size(75, 23);
            this.buttonSchema.TabIndex = 11;
            this.buttonSchema.Text = "Schema...";
            this.buttonSchema.UseVisualStyleBackColor = true;
            this.buttonSchema.Click += new System.EventHandler(this.buttonSchema_Click);
            // 
            // textBoxSchema
            // 
            this.textBoxSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSchema.Location = new System.Drawing.Point(93, 103);
            this.textBoxSchema.Name = "textBoxSchema";
            this.textBoxSchema.ReadOnly = true;
            this.textBoxSchema.Size = new System.Drawing.Size(180, 20);
            this.textBoxSchema.TabIndex = 12;
            // 
            // radioButtonSchemaNone
            // 
            this.radioButtonSchemaNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSchemaNone.AutoCheck = false;
            this.radioButtonSchemaNone.AutoSize = true;
            this.radioButtonSchemaNone.Location = new System.Drawing.Point(325, 104);
            this.radioButtonSchemaNone.Name = "radioButtonSchemaNone";
            this.radioButtonSchemaNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonSchemaNone.TabIndex = 14;
            this.radioButtonSchemaNone.Text = "None";
            this.radioButtonSchemaNone.UseVisualStyleBackColor = true;
            this.radioButtonSchemaNone.Click += new System.EventHandler(this.radioButtonSchemaNone_Click);
            this.radioButtonSchemaNone.CheckedChanged += new System.EventHandler(this.radioButtonSchemaNone_CheckedChanged);
            // 
            // radioButtonSchemaAll
            // 
            this.radioButtonSchemaAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSchemaAll.AutoCheck = false;
            this.radioButtonSchemaAll.AutoSize = true;
            this.radioButtonSchemaAll.Checked = true;
            this.radioButtonSchemaAll.Location = new System.Drawing.Point(283, 104);
            this.radioButtonSchemaAll.Name = "radioButtonSchemaAll";
            this.radioButtonSchemaAll.Size = new System.Drawing.Size(36, 17);
            this.radioButtonSchemaAll.TabIndex = 13;
            this.radioButtonSchemaAll.Text = "All";
            this.radioButtonSchemaAll.UseVisualStyleBackColor = true;
            this.radioButtonSchemaAll.Click += new System.EventHandler(this.radioButtonSchemaAll_Click);
            this.radioButtonSchemaAll.CheckedChanged += new System.EventHandler(this.radioButtonSchemaAll_CheckedChanged);
            // 
            // buttonLocale
            // 
            this.buttonLocale.Location = new System.Drawing.Point(12, 127);
            this.buttonLocale.Name = "buttonLocale";
            this.buttonLocale.Size = new System.Drawing.Size(75, 23);
            this.buttonLocale.TabIndex = 15;
            this.buttonLocale.Text = "Locale...";
            this.buttonLocale.UseVisualStyleBackColor = true;
            this.buttonLocale.Click += new System.EventHandler(this.buttonLocale_Click);
            // 
            // textBoxLocale
            // 
            this.textBoxLocale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLocale.Location = new System.Drawing.Point(93, 129);
            this.textBoxLocale.Name = "textBoxLocale";
            this.textBoxLocale.ReadOnly = true;
            this.textBoxLocale.Size = new System.Drawing.Size(180, 20);
            this.textBoxLocale.TabIndex = 16;
            // 
            // radioButtonLocaleNone
            // 
            this.radioButtonLocaleNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonLocaleNone.AutoCheck = false;
            this.radioButtonLocaleNone.AutoSize = true;
            this.radioButtonLocaleNone.Location = new System.Drawing.Point(325, 130);
            this.radioButtonLocaleNone.Name = "radioButtonLocaleNone";
            this.radioButtonLocaleNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonLocaleNone.TabIndex = 18;
            this.radioButtonLocaleNone.Text = "None";
            this.radioButtonLocaleNone.UseVisualStyleBackColor = true;
            this.radioButtonLocaleNone.Click += new System.EventHandler(this.radioButtonLocaleNone_Click);
            this.radioButtonLocaleNone.CheckedChanged += new System.EventHandler(this.radioButtonLocaleNone_CheckedChanged);
            // 
            // radioButtonLocaleAll
            // 
            this.radioButtonLocaleAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonLocaleAll.AutoCheck = false;
            this.radioButtonLocaleAll.AutoSize = true;
            this.radioButtonLocaleAll.Checked = true;
            this.radioButtonLocaleAll.Location = new System.Drawing.Point(283, 130);
            this.radioButtonLocaleAll.Name = "radioButtonLocaleAll";
            this.radioButtonLocaleAll.Size = new System.Drawing.Size(36, 17);
            this.radioButtonLocaleAll.TabIndex = 17;
            this.radioButtonLocaleAll.Text = "All";
            this.radioButtonLocaleAll.UseVisualStyleBackColor = true;
            this.radioButtonLocaleAll.Click += new System.EventHandler(this.radioButtonLocaleAll_Click);
            this.radioButtonLocaleAll.CheckedChanged += new System.EventHandler(this.radioButtonLocaleAll_CheckedChanged);
            // 
            // FormFilter
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(384, 224);
            this.Controls.Add(this.buttonLocale);
            this.Controls.Add(this.textBoxLocale);
            this.Controls.Add(this.radioButtonLocaleNone);
            this.Controls.Add(this.radioButtonLocaleAll);
            this.Controls.Add(this.buttonSchema);
            this.Controls.Add(this.textBoxSchema);
            this.Controls.Add(this.radioButtonSchemaNone);
            this.Controls.Add(this.radioButtonSchemaAll);
            this.Controls.Add(this.buttonView);
            this.Controls.Add(this.textBoxView);
            this.Controls.Add(this.radioButtonViewNone);
            this.Controls.Add(this.radioButtonViewAll);
            this.Controls.Add(this.buttonTemplate);
            this.Controls.Add(this.textBoxTemplate);
            this.Controls.Add(this.radioButtonTemplateNone);
            this.Controls.Add(this.radioButtonTemplateAll);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 260);
            this.Name = "FormFilter";
            this.ShowInTaskbar = false;
            this.Text = "Apply Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonTemplateAll;
        private System.Windows.Forms.RadioButton radioButtonTemplateNone;
        private System.Windows.Forms.TextBox textBoxTemplate;
        private System.Windows.Forms.Button buttonTemplate;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.TextBox textBoxView;
        private System.Windows.Forms.RadioButton radioButtonViewNone;
        private System.Windows.Forms.RadioButton radioButtonViewAll;
        private System.Windows.Forms.Button buttonSchema;
        private System.Windows.Forms.TextBox textBoxSchema;
        private System.Windows.Forms.RadioButton radioButtonSchemaNone;
        private System.Windows.Forms.RadioButton radioButtonSchemaAll;
        private System.Windows.Forms.Button buttonLocale;
        private System.Windows.Forms.TextBox textBoxLocale;
        private System.Windows.Forms.RadioButton radioButtonLocaleNone;
        private System.Windows.Forms.RadioButton radioButtonLocaleAll;
    }
}
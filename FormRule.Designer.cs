namespace IfcDoc
{
    partial class FormRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRule));
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIdentifier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCardinality = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxUsage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBehavior = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Template Usage:";
            // 
            // textBoxIdentifier
            // 
            this.textBoxIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIdentifier.Location = new System.Drawing.Point(13, 71);
            this.textBoxIdentifier.Name = "textBoxIdentifier";
            this.textBoxIdentifier.Size = new System.Drawing.Size(359, 20);
            this.textBoxIdentifier.TabIndex = 3;
            this.textBoxIdentifier.TextChanged += new System.EventHandler(this.textBoxIdentifier_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cardinality:";
            // 
            // comboBoxCardinality
            // 
            this.comboBoxCardinality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCardinality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardinality.FormattingEnabled = true;
            this.comboBoxCardinality.Items.AddRange(new object[] {
            "(As Schema)",
            "Zero",
            "Zero-To-One",
            "One",
            "One-to-Many"});
            this.comboBoxCardinality.Location = new System.Drawing.Point(13, 117);
            this.comboBoxCardinality.Name = "comboBoxCardinality";
            this.comboBoxCardinality.Size = new System.Drawing.Size(359, 21);
            this.comboBoxCardinality.TabIndex = 5;
            this.comboBoxCardinality.SelectedIndexChanged += new System.EventHandler(this.comboBoxCardinality_SelectedIndexChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(298, 229);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(214, 229);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // comboBoxUsage
            // 
            this.comboBoxUsage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxUsage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsage.FormattingEnabled = true;
            this.comboBoxUsage.Items.AddRange(new object[] {
            "None",
            "Condition",
            "Constraint"});
            this.comboBoxUsage.Location = new System.Drawing.Point(13, 25);
            this.comboBoxUsage.Name = "comboBoxUsage";
            this.comboBoxUsage.Size = new System.Drawing.Size(359, 21);
            this.comboBoxUsage.TabIndex = 1;
            this.comboBoxUsage.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsage_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Parameter Name:";
            // 
            // textBoxBehavior
            // 
            this.textBoxBehavior.Location = new System.Drawing.Point(13, 164);
            this.textBoxBehavior.Multiline = true;
            this.textBoxBehavior.Name = "textBoxBehavior";
            this.textBoxBehavior.ReadOnly = true;
            this.textBoxBehavior.Size = new System.Drawing.Size(359, 59);
            this.textBoxBehavior.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Behavior:";
            // 
            // FormRule
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(384, 264);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBehavior);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxUsage);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCardinality);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxIdentifier);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FormRule";
            this.ShowInTaskbar = false;
            this.Text = "Rule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIdentifier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCardinality;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxUsage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxBehavior;
        private System.Windows.Forms.Label label1;
    }
}
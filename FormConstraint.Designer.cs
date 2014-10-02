namespace IfcDoc
{
    partial class FormConstraint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConstraint));
            this.comboBoxMetric = new System.Windows.Forms.ComboBox();
            this.comboBoxOperator = new System.Windows.Forms.ComboBox();
            this.textBoxBenchmark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxExpression = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxValue = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxMetric
            // 
            this.comboBoxMetric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMetric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMetric.FormattingEnabled = true;
            this.comboBoxMetric.Items.AddRange(new object[] {
            "Value",
            "Size",
            "Type",
            "Unique"});
            this.comboBoxMetric.Location = new System.Drawing.Point(13, 25);
            this.comboBoxMetric.Name = "comboBoxMetric";
            this.comboBoxMetric.Size = new System.Drawing.Size(359, 21);
            this.comboBoxMetric.TabIndex = 1;
            this.comboBoxMetric.SelectedIndexChanged += new System.EventHandler(this.comboBoxMetric_SelectedIndexChanged);
            // 
            // comboBoxOperator
            // 
            this.comboBoxOperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperator.FormattingEnabled = true;
            this.comboBoxOperator.Items.AddRange(new object[] {
            "Equal",
            "Not Equal",
            "Greater Than",
            "Greater Than Or Equal",
            "Less Than",
            "Less Than Or Equal",
            "Included In"});
            this.comboBoxOperator.Location = new System.Drawing.Point(13, 75);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new System.Drawing.Size(359, 21);
            this.comboBoxOperator.TabIndex = 3;
            this.comboBoxOperator.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperator_SelectedIndexChanged);
            // 
            // textBoxBenchmark
            // 
            this.textBoxBenchmark.AcceptsReturn = true;
            this.textBoxBenchmark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBenchmark.Enabled = false;
            this.textBoxBenchmark.Location = new System.Drawing.Point(13, 152);
            this.textBoxBenchmark.Multiline = true;
            this.textBoxBenchmark.Name = "textBoxBenchmark";
            this.textBoxBenchmark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBenchmark.Size = new System.Drawing.Size(359, 230);
            this.textBoxBenchmark.TabIndex = 5;
            this.textBoxBenchmark.TextChanged += new System.EventHandler(this.textBoxBenchmark_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Metric:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Operator:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Value:";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(213, 426);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(297, 426);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxExpression
            // 
            this.textBoxExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExpression.Location = new System.Drawing.Point(13, 428);
            this.textBoxExpression.Name = "textBoxExpression";
            this.textBoxExpression.ReadOnly = true;
            this.textBoxExpression.Size = new System.Drawing.Size(194, 20);
            this.textBoxExpression.TabIndex = 7;
            this.textBoxExpression.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Expression:";
            this.label4.Visible = false;
            // 
            // comboBoxValue
            // 
            this.comboBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValue.Enabled = false;
            this.comboBoxValue.FormattingEnabled = true;
            this.comboBoxValue.Location = new System.Drawing.Point(13, 125);
            this.comboBoxValue.Name = "comboBoxValue";
            this.comboBoxValue.Size = new System.Drawing.Size(359, 21);
            this.comboBoxValue.TabIndex = 10;
            this.comboBoxValue.Visible = false;
            this.comboBoxValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxValue_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(309, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "For multiple values, use commas and/or separate lines to delimit.";
            // 
            // FormConstraint
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxExpression);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBenchmark);
            this.Controls.Add(this.comboBoxOperator);
            this.Controls.Add(this.comboBoxMetric);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 274);
            this.Name = "FormConstraint";
            this.ShowInTaskbar = false;
            this.Text = "Constraint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMetric;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private System.Windows.Forms.TextBox textBoxBenchmark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxExpression;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxValue;
        private System.Windows.Forms.Label label5;
    }
}
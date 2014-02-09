namespace IfcDoc
{
    partial class FormMerge
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
            this.textBoxOriginal = new System.Windows.Forms.TextBox();
            this.textBoxChange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonOriginal = new System.Windows.Forms.RadioButton();
            this.radioButtonChange = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxOriginal
            // 
            this.textBoxOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOriginal.Location = new System.Drawing.Point(3, 26);
            this.textBoxOriginal.Multiline = true;
            this.textBoxOriginal.Name = "textBoxOriginal";
            this.textBoxOriginal.ReadOnly = true;
            this.textBoxOriginal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOriginal.Size = new System.Drawing.Size(239, 466);
            this.textBoxOriginal.TabIndex = 4;
            // 
            // textBoxChange
            // 
            this.textBoxChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxChange.Location = new System.Drawing.Point(248, 26);
            this.textBoxChange.Multiline = true;
            this.textBoxChange.Name = "textBoxChange";
            this.textBoxChange.ReadOnly = true;
            this.textBoxChange.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxChange.Size = new System.Drawing.Size(240, 466);
            this.textBoxChange.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Changed Items:";
            // 
            // radioButtonOriginal
            // 
            this.radioButtonOriginal.AutoSize = true;
            this.radioButtonOriginal.Location = new System.Drawing.Point(3, 3);
            this.radioButtonOriginal.Name = "radioButtonOriginal";
            this.radioButtonOriginal.Size = new System.Drawing.Size(92, 17);
            this.radioButtonOriginal.TabIndex = 2;
            this.radioButtonOriginal.TabStop = true;
            this.radioButtonOriginal.Text = "Keep Existing:";
            this.radioButtonOriginal.UseVisualStyleBackColor = true;
            this.radioButtonOriginal.Click += new System.EventHandler(this.radioButtonOriginal_Click);
            // 
            // radioButtonChange
            // 
            this.radioButtonChange.AutoSize = true;
            this.radioButtonChange.Location = new System.Drawing.Point(248, 3);
            this.radioButtonChange.Name = "radioButtonChange";
            this.radioButtonChange.Size = new System.Drawing.Size(102, 17);
            this.radioButtonChange.TabIndex = 3;
            this.radioButtonChange.TabStop = true;
            this.radioButtonChange.Text = "Accept Change:";
            this.radioButtonChange.UseVisualStyleBackColor = true;
            this.radioButtonChange.Click += new System.EventHandler(this.radioButtonChange_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(616, 529);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(697, 529);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxOriginal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxChange, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonChange, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonOriginal, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(281, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 495);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.CheckBoxes = true;
            this.treeView.Location = new System.Drawing.Point(12, 28);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(263, 495);
            this.treeView.TabIndex = 9;
            this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCheck);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // FormMerge
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(784, 564);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMerge";
            this.ShowInTaskbar = false;
            this.Text = "Merge";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOriginal;
        private System.Windows.Forms.TextBox textBoxChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonOriginal;
        private System.Windows.Forms.RadioButton radioButtonChange;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeView;
    }
}
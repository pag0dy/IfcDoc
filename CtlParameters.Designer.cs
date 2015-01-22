namespace IfcDoc
{
    partial class CtlParameters
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlParameters));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTemplateInsert = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTemplateRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMoveUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButtonInheritance = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemModeInherit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemModeOverride = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemModeSuppress = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonConceptTemplate = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewConceptRules = new System.Windows.Forms.DataGridView();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonItemOptional = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConceptRules)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTemplateInsert,
            this.toolStripButtonTemplateRemove,
            this.toolStripSeparator1,
            this.toolStripButtonMoveUp,
            this.toolStripButtonMoveDown,
            this.toolStripSplitButtonInheritance,
            this.toolStripButtonConceptTemplate,
            this.toolStripSeparator2,
            this.toolStripButtonItemOptional});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(400, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonTemplateInsert
            // 
            this.toolStripButtonTemplateInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTemplateInsert.Enabled = false;
            this.toolStripButtonTemplateInsert.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTemplateInsert.Image")));
            this.toolStripButtonTemplateInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTemplateInsert.Name = "toolStripButtonTemplateInsert";
            this.toolStripButtonTemplateInsert.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTemplateInsert.Text = "Insert";
            this.toolStripButtonTemplateInsert.ToolTipText = "Inserts a row";
            this.toolStripButtonTemplateInsert.Click += new System.EventHandler(this.toolStripButtonTemplateInsert_Click);
            // 
            // toolStripButtonTemplateRemove
            // 
            this.toolStripButtonTemplateRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTemplateRemove.Enabled = false;
            this.toolStripButtonTemplateRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTemplateRemove.Image")));
            this.toolStripButtonTemplateRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTemplateRemove.Name = "toolStripButtonTemplateRemove";
            this.toolStripButtonTemplateRemove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTemplateRemove.Text = "Remove";
            this.toolStripButtonTemplateRemove.ToolTipText = "Removes the selected row";
            this.toolStripButtonTemplateRemove.Click += new System.EventHandler(this.toolStripButtonTemplateRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonMoveUp
            // 
            this.toolStripButtonMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMoveUp.Enabled = false;
            this.toolStripButtonMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMoveUp.Image")));
            this.toolStripButtonMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveUp.Name = "toolStripButtonMoveUp";
            this.toolStripButtonMoveUp.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMoveUp.Text = "Move Up";
            this.toolStripButtonMoveUp.Click += new System.EventHandler(this.toolStripButtonMoveUp_Click);
            // 
            // toolStripButtonMoveDown
            // 
            this.toolStripButtonMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMoveDown.Enabled = false;
            this.toolStripButtonMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMoveDown.Image")));
            this.toolStripButtonMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMoveDown.Name = "toolStripButtonMoveDown";
            this.toolStripButtonMoveDown.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMoveDown.Text = "Move Down";
            this.toolStripButtonMoveDown.Click += new System.EventHandler(this.toolStripButtonMoveDown_Click);
            // 
            // toolStripSplitButtonInheritance
            // 
            this.toolStripSplitButtonInheritance.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButtonInheritance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButtonInheritance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemModeInherit,
            this.toolStripMenuItemModeOverride,
            this.toolStripMenuItemModeSuppress});
            this.toolStripSplitButtonInheritance.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonInheritance.Image")));
            this.toolStripSplitButtonInheritance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonInheritance.Name = "toolStripSplitButtonInheritance";
            this.toolStripSplitButtonInheritance.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButtonInheritance.Text = "toolStripSplitButton1";
            this.toolStripSplitButtonInheritance.ToolTipText = "Concept inheritance";
            // 
            // toolStripMenuItemModeInherit
            // 
            this.toolStripMenuItemModeInherit.Checked = true;
            this.toolStripMenuItemModeInherit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemModeInherit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemModeInherit.Image")));
            this.toolStripMenuItemModeInherit.Name = "toolStripMenuItemModeInherit";
            this.toolStripMenuItemModeInherit.Size = new System.Drawing.Size(167, 22);
            this.toolStripMenuItemModeInherit.Text = "Inherit concept";
            this.toolStripMenuItemModeInherit.Click += new System.EventHandler(this.toolStripMenuItemModeInherit_Click);
            // 
            // toolStripMenuItemModeOverride
            // 
            this.toolStripMenuItemModeOverride.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemModeOverride.Image")));
            this.toolStripMenuItemModeOverride.Name = "toolStripMenuItemModeOverride";
            this.toolStripMenuItemModeOverride.Size = new System.Drawing.Size(167, 22);
            this.toolStripMenuItemModeOverride.Text = "Override concept";
            this.toolStripMenuItemModeOverride.Click += new System.EventHandler(this.toolStripMenuItemModeOverride_Click);
            // 
            // toolStripMenuItemModeSuppress
            // 
            this.toolStripMenuItemModeSuppress.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemModeSuppress.Image")));
            this.toolStripMenuItemModeSuppress.Name = "toolStripMenuItemModeSuppress";
            this.toolStripMenuItemModeSuppress.Size = new System.Drawing.Size(167, 22);
            this.toolStripMenuItemModeSuppress.Text = "Suppress concept";
            this.toolStripMenuItemModeSuppress.Click += new System.EventHandler(this.toolStripMenuItemModeSuppress_Click);
            // 
            // toolStripButtonConceptTemplate
            // 
            this.toolStripButtonConceptTemplate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonConceptTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConceptTemplate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonConceptTemplate.Image")));
            this.toolStripButtonConceptTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConceptTemplate.Name = "toolStripButtonConceptTemplate";
            this.toolStripButtonConceptTemplate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonConceptTemplate.Text = "Change Template";
            this.toolStripButtonConceptTemplate.Click += new System.EventHandler(this.toolStripButtonConceptTemplate_Click);
            // 
            // dataGridViewConceptRules
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewConceptRules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewConceptRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewConceptRules.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewConceptRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewConceptRules.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewConceptRules.MultiSelect = false;
            this.dataGridViewConceptRules.Name = "dataGridViewConceptRules";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewConceptRules.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewConceptRules.Size = new System.Drawing.Size(400, 375);
            this.dataGridViewConceptRules.TabIndex = 5;
            this.dataGridViewConceptRules.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConceptRules_CellContentClick);
            this.dataGridViewConceptRules.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConceptRules_CellEnter);
            this.dataGridViewConceptRules.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConceptRules_CellValidated);
            this.dataGridViewConceptRules.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewConceptRules_DataError);
            this.dataGridViewConceptRules.SelectionChanged += new System.EventHandler(this.dataGridViewConceptRules_SelectionChanged);
            this.dataGridViewConceptRules.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewConceptRules_UserAddedRow);
            this.dataGridViewConceptRules.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewConceptRules_UserDeletedRow);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonItemOptional
            // 
            this.toolStripButtonItemOptional.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonItemOptional.Enabled = false;
            this.toolStripButtonItemOptional.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonItemOptional.Image")));
            this.toolStripButtonItemOptional.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonItemOptional.Name = "toolStripButtonItemOptional";
            this.toolStripButtonItemOptional.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonItemOptional.Text = "Optional";
            this.toolStripButtonItemOptional.Click += new System.EventHandler(this.toolStripButtonItemOptional_Click);
            // 
            // CtlParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewConceptRules);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CtlParameters";
            this.Size = new System.Drawing.Size(400, 400);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConceptRules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonTemplateInsert;
        private System.Windows.Forms.ToolStripButton toolStripButtonTemplateRemove;
        private System.Windows.Forms.DataGridView dataGridViewConceptRules;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveDown;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonInheritance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemModeInherit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemModeOverride;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemModeSuppress;
        private System.Windows.Forms.ToolStripButton toolStripButtonConceptTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonItemOptional;
    }
}

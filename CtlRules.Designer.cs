namespace IfcDoc
{
    partial class CtlRules
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlRules));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTemplateInsert = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTemplateRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTemplateUpdate = new System.Windows.Forms.ToolStripButton();
            this.treeViewTemplate = new System.Windows.Forms.TreeView();
            this.toolStripButtonMoveUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageListRules = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTemplateInsert,
            this.toolStripButtonTemplateRemove,
            this.toolStripButtonTemplateUpdate,
            this.toolStripSeparator1,
            this.toolStripButtonMoveUp,
            this.toolStripButtonMoveDown});
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
            this.toolStripButtonTemplateInsert.ToolTipText = "Inserts an entity reference or attribute reference.";
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
            this.toolStripButtonTemplateRemove.ToolTipText = "Removes the selected reference";
            this.toolStripButtonTemplateRemove.Click += new System.EventHandler(this.toolStripButtonTemplateRemove_Click);
            // 
            // toolStripButtonTemplateUpdate
            // 
            this.toolStripButtonTemplateUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTemplateUpdate.Enabled = false;
            this.toolStripButtonTemplateUpdate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTemplateUpdate.Image")));
            this.toolStripButtonTemplateUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTemplateUpdate.Name = "toolStripButtonTemplateUpdate";
            this.toolStripButtonTemplateUpdate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTemplateUpdate.Text = "Update";
            this.toolStripButtonTemplateUpdate.ToolTipText = "Edits the selected reference";
            this.toolStripButtonTemplateUpdate.Click += new System.EventHandler(this.toolStripButtonTemplateUpdate_Click);
            // 
            // treeViewTemplate
            // 
            this.treeViewTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTemplate.FullRowSelect = true;
            this.treeViewTemplate.HideSelection = false;
            this.treeViewTemplate.ImageIndex = 0;
            this.treeViewTemplate.ImageList = this.imageListRules;
            this.treeViewTemplate.Location = new System.Drawing.Point(0, 25);
            this.treeViewTemplate.Name = "treeViewTemplate";
            this.treeViewTemplate.SelectedImageIndex = 0;
            this.treeViewTemplate.Size = new System.Drawing.Size(400, 375);
            this.treeViewTemplate.TabIndex = 3;
            this.treeViewTemplate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTemplate_AfterSelect);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // imageListRules
            // 
            this.imageListRules.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListRules.ImageStream")));
            this.imageListRules.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageListRules.Images.SetKeyName(0, "DocEntity.bmp");
            this.imageListRules.Images.SetKeyName(1, "DocAttribute.bmp");
            this.imageListRules.Images.SetKeyName(2, "DocQuantity.bmp");
            this.imageListRules.Images.SetKeyName(3, "IfcAppliedValue.png");
            this.imageListRules.Images.SetKeyName(4, "IfcBooleanOperand.png");
            // 
            // CtlRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewTemplate);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CtlRules";
            this.Size = new System.Drawing.Size(400, 400);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonTemplateInsert;
        private System.Windows.Forms.ToolStripButton toolStripButtonTemplateRemove;
        private System.Windows.Forms.ToolStripButton toolStripButtonTemplateUpdate;
        private System.Windows.Forms.TreeView treeViewTemplate;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonMoveDown;
        private System.Windows.Forms.ImageList imageListRules;
    }
}

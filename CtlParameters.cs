using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public partial class CtlParameters : UserControl
    {
        DocProject m_project;
        DocConceptRoot m_conceptroot;
        DocTemplateUsage m_conceptleaf;
        DocModelRule m_selectedcolumn;
        Dictionary<string, DocObject> m_map;
        DocModelRule[] m_columns;
        bool m_editcon;
        SEntity m_instance;

        public CtlParameters()
        {
            InitializeComponent();
        }

        public DocProject Project
        {
            get
            {
                return this.m_project;
            }
            set
            {
                this.m_project = value;

                if (this.m_project != null)
                {
                    this.m_map = new Dictionary<string, DocObject>();
                    foreach (DocSection docSection in this.m_project.Sections)
                    {
                        foreach (DocSchema docSchema in docSection.Schemas)
                        {
                            foreach (DocEntity docEntity in docSchema.Entities)
                            {
                                this.m_map.Add(docEntity.Name, docEntity);
                            }

                            foreach (DocType docType in docSchema.Types)
                            {
                                this.m_map.Add(docType.Name, docType);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The concept root, for which any IfcReference parameter is made relative to.
        /// </summary>
        public DocConceptRoot ConceptRoot
        {
            get
            {
                return this.m_conceptroot;
            }
            set
            {
                this.m_conceptroot = value;
            }
        }

        /// <summary>
        /// The concept defining rows of items with parameters
        /// </summary>
        public DocTemplateUsage ConceptLeaf
        {
            get
            {
                return this.m_conceptleaf;
            }
            set
            {
                this.m_conceptleaf = value;
                LoadUsage();
            }
        }

        public DocModelRule SelectedColumn
        {
            get
            {
                return this.m_selectedcolumn;
            }
        }

        public SEntity CurrentInstance
        {
            get
            {
                return this.m_instance;
            }
            set
            {
                this.m_instance = value;

                DocTemplateUsage docUsage = (DocTemplateUsage)this.m_conceptleaf;
                foreach (DataGridViewRow row in this.dataGridViewConceptRules.Rows)
                {
                    if (row.Tag != null)
                    {
                        DocTemplateItem item = (DocTemplateItem)row.Tag;
                        bool result;
                        if (this.m_instance != null)
                        {
                            if (item.ValidationStructure.TryGetValue(this.m_instance, out result))
                            {
                                if (result)
                                {
                                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Lime;
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;// Yellow;
                            }
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
                        }
                    }
                }
            }
        }

        public event EventHandler SelectedColumnChanged;

        private void LoadInheritance()
        {
            this.toolStripMenuItemModeSuppress.Checked = false;
            this.toolStripMenuItemModeOverride.Checked = false;
            this.toolStripMenuItemModeInherit.Checked = false;
            if (this.m_conceptleaf.Suppress)
            {
                this.toolStripSplitButtonInheritance.Image = this.toolStripMenuItemModeSuppress.Image;
                this.toolStripMenuItemModeSuppress.Checked = true;
            }
            else if (this.m_conceptleaf.Override)
            {
                this.toolStripSplitButtonInheritance.Image = this.toolStripMenuItemModeOverride.Image;
                this.toolStripMenuItemModeOverride.Checked = true;
            }
            else
            {
                this.toolStripSplitButtonInheritance.Image = this.toolStripMenuItemModeInherit.Image;
                this.toolStripMenuItemModeInherit.Checked = true;
            }
        }

        private void LoadUsage()
        {
            m_editcon = true;
            this.dataGridViewConceptRules.Rows.Clear();
            this.dataGridViewConceptRules.Columns.Clear();

            if (this.m_conceptroot == null || this.m_conceptleaf == null)// || !this.m_conceptroot.Concepts.Contains(this.m_conceptleaf))
                return;

            LoadInheritance();

            DocTemplateUsage docUsage = (DocTemplateUsage)this.m_conceptleaf;
            if (docUsage.Definition != null)
            {
                this.m_columns = docUsage.Definition.GetParameterRules();
                foreach (DocModelRule rule in this.m_columns)
                {
                    DataGridViewColumn column = new DataGridViewColumn();
                    column.HeaderText = rule.Identification;
                    column.ValueType = typeof(string);//?
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    column.Width = 200;

                    // override cell template for special cases
                    DocConceptRoot docConceptRoot = (DocConceptRoot)this.m_conceptroot;
                    DocEntity docEntity = this.m_project.GetDefinition(docUsage.Definition.Type) as DocEntity;// docConceptRoot.ApplicableEntity;
                    foreach (DocModelRuleAttribute docRule in docUsage.Definition.Rules)
                    {
                        DocAttribute docAttribute = docEntity.ResolveParameterAttribute(docRule, rule.Identification, m_map);
                        if (docAttribute != null)
                        {
                            DocObject docDef = null;
                            if (this.m_map.TryGetValue(docAttribute.DefinedType, out docDef) && docDef is DocDefinition)
                            {
                                if (docDef is DocEnumeration)
                                {
                                    DocEnumeration docEnum = (DocEnumeration)docDef;
                                    DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                                    cell.MaxDropDownItems = 32;
                                    cell.DropDownWidth = 200;
                                    // add blank item
                                    cell.Items.Add(String.Empty);
                                    foreach (DocConstant docConst in docEnum.Constants)
                                    {
                                        cell.Items.Add(docConst.Name);
                                    }
                                    column.CellTemplate = cell;
                                }
                                else if (docDef is DocEntity || docDef is DocSelect)
                                {
                                    // button to launch dialog for picking entity
                                    DataGridViewButtonCell cell = new DataGridViewButtonCell();
                                    cell.Tag = docDef;
                                    column.CellTemplate = cell;
                                }
                            }
                            else if (docAttribute.DefinedType != null && (docAttribute.DefinedType.Equals("LOGICAL") || docAttribute.DefinedType.Equals("BOOLEAN")))
                            {
                                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                                cell.MaxDropDownItems = 4;
                                cell.DropDownWidth = 200;
                                // add blank item
                                cell.Items.Add(String.Empty);
                                cell.Items.Add(Boolean.FalseString);
                                cell.Items.Add(Boolean.TrueString);
                                column.CellTemplate = cell;
                            }
                        }
                    }

                    this.dataGridViewConceptRules.Columns.Add(column);
                }
            }

            // add description column
            DataGridViewColumn coldesc = new DataGridViewColumn();
            coldesc.HeaderText = "Description";
            coldesc.ValueType = typeof(string);//?
            coldesc.CellTemplate = new DataGridViewTextBoxCell();
            coldesc.Width = 400;
            this.dataGridViewConceptRules.Columns.Add(coldesc);

            foreach (DocTemplateItem item in docUsage.Items)
            {
                string[] values = new string[this.dataGridViewConceptRules.Columns.Count];

                if (this.m_columns != null)
                {
                    for (int i = 0; i < this.m_columns.Length; i++)
                    {
                        string parmname = this.m_columns[i].Identification;
                        string val = item.GetParameterValue(parmname);
                        if (val != null)
                        {
                            values[i] = val;
                        }
                    }
                }

                values[values.Length - 1] = item.Documentation;

                int row = this.dataGridViewConceptRules.Rows.Add(values);
                this.dataGridViewConceptRules.Rows[row].Tag = item;
            }

            if (this.dataGridViewConceptRules.SelectedCells.Count > 0)
            {
                this.dataGridViewConceptRules.SelectedCells[0].Selected = false;
            }

            m_editcon = false;
        }

        private void dataGridViewConceptRules_SelectionChanged(object sender, EventArgs e)
        {
            //toolStripButtonTemplateInsert
            this.toolStripButtonTemplateRemove.Enabled = (this.dataGridViewConceptRules.SelectedRows.Count == 1 && this.dataGridViewConceptRules.SelectedRows[0].Index < this.dataGridViewConceptRules.Rows.Count - 1);
            this.toolStripButtonMoveDown.Enabled = (this.dataGridViewConceptRules.SelectedRows.Count == 1 && this.dataGridViewConceptRules.SelectedRows[0].Index < this.dataGridViewConceptRules.Rows.Count - 2); // exclude New row
            this.toolStripButtonMoveUp.Enabled = (this.dataGridViewConceptRules.SelectedRows.Count == 1 && this.dataGridViewConceptRules.SelectedRows[0].Index > 0 && this.dataGridViewConceptRules.SelectedRows[0].Index < this.dataGridViewConceptRules.Rows.Count - 1);
        }

        private void dataGridViewConceptRules_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            DocTemplateItem dti = new DocTemplateItem();
            this.m_conceptleaf.Items.Add(dti);
            e.Row.Tag = dti;
        }

        private void dataGridViewConceptRules_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.m_conceptleaf.Items.Remove((DocTemplateItem)e.Row.Tag);
        }

        private void dataGridViewConceptRules_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // eat it
        }

        private void dataGridViewConceptRules_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (this.m_editcon)
                return;

            // format parameters

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.dataGridViewConceptRules.Columns.Count - 1; i++)
            {
                object val = this.dataGridViewConceptRules[i, e.RowIndex].Value;
                if (val != null)
                {
                    DataGridViewColumn col = this.dataGridViewConceptRules.Columns[i];
                    sb.Append(col.HeaderText);
                    sb.Append("=");
                    sb.Append(val as string);
                    sb.Append(";");
                }
            }

            DocTemplateUsage docUsage = (DocTemplateUsage)this.m_conceptleaf;
            if (docUsage.Items.Count > e.RowIndex)
            {
                DocTemplateItem docItem = docUsage.Items[e.RowIndex];
                docItem.RuleParameters = sb.ToString();
                object val = this.dataGridViewConceptRules[this.dataGridViewConceptRules.Columns.Count - 1, e.RowIndex].Value;
                docItem.Documentation = val as string;
            }
        }

        private void dataGridViewConceptRules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // for button types, launch dialog
            DataGridViewCell cell = this.dataGridViewConceptRules.Rows[e.RowIndex].Cells[e.ColumnIndex];
            DocDefinition docEntity = cell.Tag as DocDefinition;
            if (docEntity == null)
                return;

            DocDefinition docSelect = null;
            if (cell.Value != null && this.m_map.ContainsKey(cell.Value.ToString()))
            {
                docSelect = this.m_map[cell.Value.ToString()] as DocDefinition;
            }

            if (docEntity.Name != null && docEntity.Name.Equals("IfcReference"))
            {
                DocDefinition docDef = this.m_conceptroot.ApplicableEntity as DocDefinition;

                // special case for building reference paths
                using (FormReference form = new FormReference(this.m_project, docDef, this.m_map, cell.Value as string))
                {
                    DialogResult res = form.ShowDialog(this);
                    if (res == System.Windows.Forms.DialogResult.OK)
                    {
                        if (form.ValuePath != null && form.ValuePath.StartsWith("\\"))
                        {
                            cell.Value = form.ValuePath.Substring(1);
                        }
                        else if (form.ValuePath == "")
                        {
                            cell.Value = "\\";
                        }
                        dataGridViewConceptRules_CellValidated(this, e);
                        this.dataGridViewConceptRules.NotifyCurrentCellDirty(true);
                    }
                }
            }
            else
            {
                // new: if a referenced concept template applies, then edit that; otherwise, edit type
                
                // get the model view

                DocTemplateDefinition docTemplateInner = null;
                DocModelRule docRule = this.m_columns[e.ColumnIndex];
                if(docRule is DocModelRuleAttribute)
                {
                    DocModelRuleAttribute dma = (DocModelRuleAttribute)docRule;
                    if (dma.Rules.Count > 0 && dma.Rules[0] is DocModelRuleEntity)
                    {
                        DocModelRuleEntity dme = (DocModelRuleEntity)dma.Rules[0];
                        if(dme.References.Count == 1)
                        {
                            docTemplateInner = dme.References[0];

                            if(dma.Rules.Count > 1)
                            {
                                // prompt user to select which template...
                            }
                        }
                    }
                }

                if (docTemplateInner != null)
                {
                    DocTemplateItem docConceptItem = (DocTemplateItem)this.dataGridViewConceptRules.Rows[e.RowIndex].Tag;
                    if (docConceptItem != null)
                    {
                        DocTemplateUsage docConceptInner = docConceptItem.RegisterParameterConcept(docRule.Identification, docTemplateInner);

                        using (FormParameters form = new FormParameters())
                        {
                            form.Project = this.m_project;
                            form.ConceptRoot = this.m_conceptroot;
                            form.ConceptLeaf = docConceptInner;
                            form.CurrentInstance = this.m_instance;
                            form.ShowDialog(this);
                        }
                    }
                }
                else
                {
                    // set type of item
                    using (FormSelectEntity form = new FormSelectEntity(docEntity, docSelect, this.m_project, SelectDefinitionOptions.Entity | SelectDefinitionOptions.Type))
                    {
                        DialogResult res = form.ShowDialog(this);
                        if (res == DialogResult.OK && form.SelectedEntity != null)
                        {
                            cell.Value = form.SelectedEntity.Name;
                            this.dataGridViewConceptRules.NotifyCurrentCellDirty(true);
                        }
                    }
                }
            }
        }

        private void toolStripButtonTemplateInsert_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonTemplateRemove_Click(object sender, EventArgs e)
        {
            this.m_editcon = true;
            int index = this.dataGridViewConceptRules.SelectedRows[0].Index;
            DocTemplateUsage docUsage = (DocTemplateUsage)this.m_conceptleaf;
            docUsage.Items.RemoveAt(index);

            LoadUsage();

            if (this.dataGridViewConceptRules.Rows.Count > index)
            {
                this.dataGridViewConceptRules.Rows[index].Selected = true;
            }
            this.m_editcon = false;
        }

        private void toolStripButtonMoveUp_Click(object sender, EventArgs e)
        {
            this.m_editcon = true;
            int index = this.dataGridViewConceptRules.SelectedRows[0].Index;
            DocTemplateUsage docUsage = (DocTemplateUsage)this.m_conceptleaf;
            DocTemplateItem dti = docUsage.Items[index];
            docUsage.Items.Insert(index - 1, dti);
            docUsage.Items.RemoveAt(index + 1);

            LoadUsage();
            this.m_editcon = false;
        }

        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            this.m_editcon = true;
            int index = this.dataGridViewConceptRules.SelectedRows[0].Index;
            if (index < this.dataGridViewConceptRules.Rows.Count - 2)
            {
                DocTemplateUsage docUsage = (DocTemplateUsage)this.m_conceptleaf;
                DocTemplateItem dti = docUsage.Items[index];
                docUsage.Items.Insert(index + 2, dti);
                docUsage.Items.RemoveAt(index);

                LoadUsage();
                this.dataGridViewConceptRules.Rows[index + 1].Selected = true;
            }
            this.m_editcon = false;
        }

        private void dataGridViewConceptRules_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.m_columns == null)
                return;

            if (e.ColumnIndex >= 0 && e.ColumnIndex < this.m_columns.Length)
            {
                this.m_selectedcolumn = this.m_columns[e.ColumnIndex];
            }
            else
            {
                this.m_selectedcolumn = null;
            }

            if (this.SelectedColumnChanged != null)
            {
                this.SelectedColumnChanged(this, EventArgs.Empty);
            }
        }

        private void toolStripMenuItemModeInherit_Click(object sender, EventArgs e)
        {
            this.m_conceptleaf.Override = false;
            this.m_conceptleaf.Suppress = false;
            this.LoadInheritance();
        }

        private void toolStripMenuItemModeOverride_Click(object sender, EventArgs e)
        {
            this.m_conceptleaf.Override = true;
            this.m_conceptleaf.Suppress = false;
            this.LoadInheritance();
        }

        private void toolStripMenuItemModeSuppress_Click(object sender, EventArgs e)
        {
            this.m_conceptleaf.Override = true;
            this.m_conceptleaf.Suppress = true;
            this.LoadInheritance();
        }

        private void toolStripButtonConceptTemplate_Click(object sender, EventArgs e)
        {
            using (FormSelectTemplate form = new FormSelectTemplate(this.m_conceptleaf.Definition, this.m_project, this.m_conceptroot.ApplicableEntity))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.SelectedTemplate != null)
                {
                    this.m_conceptleaf.Definition = form.SelectedTemplate;
                    this.m_conceptleaf.Items.Clear();

                    //this.textBoxConceptTemplate.Text = this.m_conceptleaf.Definition.Name;
                }
            }
        }
    }
}

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
        DocObject m_conceptitem; // optional outer item
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
                                if(!this.m_map.ContainsKey(docEntity.Name))
                                {
                                    this.m_map.Add(docEntity.Name, docEntity);
                                }
                            }

                            foreach (DocType docType in docSchema.Types)
                            {
                                if(!this.m_map.ContainsKey(docType.Name))
                                {
                                    this.m_map.Add(docType.Name, docType);
                                }
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

        public DocObject ConceptItem
        {
            get
            {
                return this.m_conceptitem;
            }
            set
            {
                this.m_conceptitem = value;
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
                        if (this.m_instance != null)
                        {
                            bool? testresult = item.GetResultForObject(this.m_instance);
                            if(testresult == null)
                            {
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
                            }
                            else if(testresult.Value)
                            {
                                row.DefaultCellStyle.BackColor = System.Drawing.Color.Lime;
                            }
                            else
                            {
                                if (item.Optional)
                                {
                                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
                        }
                    }
                }

                this.listView1.Items.Clear();

                if (docUsage != null && this.CurrentInstance != null)
                {
                    List<SEntity> listMismatch = docUsage.GetValidationMismatches(this.CurrentInstance, this.ConceptItem);
                    foreach (SEntity o in listMismatch)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Tag = o;
                        lvi.Text = o.OID.ToString();

                        System.Reflection.FieldInfo field = o.GetType().GetField("Name");
                        if (field != null)
                        {
                            object oname = field.GetValue(o);
                            if (oname != null)
                            {
                                System.Reflection.FieldInfo fieldValue = oname.GetType().GetField("Value");
                                if (fieldValue != null)
                                {
                                    oname = fieldValue.GetValue(oname);
                                }

                                if(oname != null)
                                {
                                    lvi.SubItems.Add(oname.ToString());
                                }
                            }
                        }

                        this.listView1.Items.Add(lvi);
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
            if (this.m_conceptleaf != null)
            {
                this.toolStripSplitButtonInheritance.Visible = true;

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

                this.toolStripComboBoxOperator.SelectedIndex = (int)this.m_conceptleaf.Operator;
            }
            else
            {
                this.toolStripSplitButtonInheritance.Visible = false;
            }
        }

        private void LoadUsage()
        {
            m_editcon = true;
            this.dataGridViewConceptRules.Rows.Clear();
            this.dataGridViewConceptRules.Columns.Clear();

            if (this.m_conceptroot == null)
                return;

            LoadInheritance();

            List<DocTemplateItem> listItems = null;
            DocTemplateDefinition docTemplate = null;
            if (this.m_conceptleaf != null)
            {
                docTemplate = this.m_conceptleaf.Definition;
                listItems = this.m_conceptleaf.Items;
            }
            else
            {
                docTemplate = this.m_conceptroot.ApplicableTemplate;
                listItems = this.m_conceptroot.ApplicableItems;
            }

            if (docTemplate != null)
            {
                this.m_columns = docTemplate.GetParameterRules();
                foreach (DocModelRule rule in this.m_columns)
                {
                    DataGridViewColumn column = new DataGridViewColumn();
                    column.Tag = rule;
                    column.HeaderText = rule.Identification;
                    column.ValueType = typeof(string);//?
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    column.Width = 200;

                    if(rule.IsCondition())
                    {
                        column.HeaderText += "?";
                    }

                    // override cell template for special cases
                    DocConceptRoot docConceptRoot = (DocConceptRoot)this.m_conceptroot;
                    DocEntity docEntity = this.m_project.GetDefinition(docTemplate.Type) as DocEntity;// docConceptRoot.ApplicableEntity;
                    foreach (DocModelRuleAttribute docRule in docTemplate.Rules)
                    {
                        DocAttribute docAttribute = docEntity.ResolveParameterAttribute(docRule, rule.Identification, m_map);
                        if(docAttribute == null)
                        {
                            // try on type itself, e.g. PredefinedType
                            docAttribute = docConceptRoot.ApplicableEntity.ResolveParameterAttribute(docRule, rule.Identification, m_map);
                        }
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

            foreach (DocTemplateItem item in listItems)
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

                if(item.Optional)
                {
                    this.dataGridViewConceptRules.Rows[row].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }

            if (this.dataGridViewConceptRules.SelectedCells.Count > 0)
            {
                this.dataGridViewConceptRules.SelectedCells[0].Selected = false;
            }

            m_editcon = false;
        }

        private void dataGridViewConceptRules_SelectionChanged(object sender, EventArgs e)
        {
            if (this.m_editcon)
                return;

            //toolStripButtonTemplateInsert
            this.toolStripButtonTemplateRemove.Enabled = (this.dataGridViewConceptRules.SelectedRows.Count == 1 && this.dataGridViewConceptRules.SelectedRows[0].Index < this.dataGridViewConceptRules.Rows.Count - 1);
            this.toolStripButtonMoveDown.Enabled = (this.dataGridViewConceptRules.SelectedRows.Count == 1 && this.dataGridViewConceptRules.SelectedRows[0].Index < this.dataGridViewConceptRules.Rows.Count - 2); // exclude New row
            this.toolStripButtonMoveUp.Enabled = (this.dataGridViewConceptRules.SelectedRows.Count == 1 && this.dataGridViewConceptRules.SelectedRows[0].Index > 0 && this.dataGridViewConceptRules.SelectedRows[0].Index < this.dataGridViewConceptRules.Rows.Count - 1);
            this.toolStripButtonItemOptional.Enabled = (this.dataGridViewConceptRules.SelectedRows.Count == 1);
            if (this.dataGridViewConceptRules.SelectedRows.Count > 0 && this.dataGridViewConceptRules.SelectedRows[0].Tag is DocTemplateItem)
            {
                this.toolStripButtonItemOptional.Checked = ((DocTemplateItem)this.dataGridViewConceptRules.SelectedRows[0].Tag).Optional;
            }
            else
            {
                this.toolStripButtonItemOptional.Checked = false;
            }
        }

        private void dataGridViewConceptRules_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            DocTemplateItem dti = new DocTemplateItem();
            if (this.m_conceptleaf != null)
            {
                this.m_conceptleaf.Items.Add(dti);
            }
            else
            {
                this.m_conceptroot.ApplicableItems.Add(dti);
            }
            e.Row.Tag = dti;
        }

        private void dataGridViewConceptRules_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (this.m_conceptleaf != null)
            {
                this.m_conceptleaf.Items.Remove((DocTemplateItem)e.Row.Tag);
            }
            else
            {
                this.m_conceptroot.ApplicableItems.Remove((DocTemplateItem)e.Row.Tag);
            }
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
                    if (col.Tag is DocModelRule)
                    {
                        DocModelRule rule = (DocModelRule)col.Tag;

                        sb.Append(rule.Identification);
                        sb.Append("=");
                        sb.Append(val as string);
                        sb.Append(";");
                    }
                    else
                    {
                        this.ToString(); // description???
                    }
                }
            }

            List<DocTemplateItem> listItems = null;
            if(this.m_conceptleaf != null)
            {
                listItems = this.m_conceptleaf.Items;
            }
            else
            {
                listItems = this.m_conceptroot.ApplicableItems;
            }

            if (listItems.Count > e.RowIndex)
            {
                DocTemplateItem docItem = listItems[e.RowIndex];
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
                            cell.Value = String.Empty;// "\\";
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
                DocModelRuleAttribute dma = null;
                if(docRule is DocModelRuleAttribute)
                {
                    dma = (DocModelRuleAttribute)docRule;
                    if (dma.Rules.Count > 0 && dma.Rules[0] is DocModelRuleEntity)
                    {
                        DocModelRuleEntity dme = (DocModelRuleEntity)dma.Rules[0];
                        if (dme.References.Count == 1)
                        {
                            docTemplateInner = dme.References[0];

                            //if (dma.Rules.Count > 1)
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
                            form.ConceptItem = docConceptItem;
                            form.ConceptAttr = dma;

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
            if(this.m_conceptleaf != null)
            {
                this.m_conceptleaf.Items.RemoveAt(index);
            }
            else
            {
                this.m_conceptroot.ApplicableItems.RemoveAt(index);
            }
            this.m_editcon = false;

            LoadUsage();
        }

        private void toolStripButtonMoveUp_Click(object sender, EventArgs e)
        {
            this.m_editcon = true;
            int index = this.dataGridViewConceptRules.SelectedRows[0].Index;

            List<DocTemplateItem> listItems = null;
            if(this.m_conceptleaf != null)
            {
                listItems = this.m_conceptleaf.Items;
            }
            else
            {
                listItems = this.m_conceptroot.ApplicableItems;
            }
            DocTemplateItem dti = listItems[index];
            listItems.Insert(index - 1, dti);
            listItems.RemoveAt(index + 1);

            LoadUsage();
            this.m_editcon = false;
        }

        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            this.m_editcon = true;
            int index = this.dataGridViewConceptRules.SelectedRows[0].Index;
            if (index < this.dataGridViewConceptRules.Rows.Count - 2)
            {
                List<DocTemplateItem> listItems = null;
                if (this.m_conceptleaf != null)
                {
                    listItems = this.m_conceptleaf.Items;
                }
                else
                {
                    listItems = this.m_conceptroot.ApplicableItems;
                }

                DocTemplateItem dti = listItems[index];
                listItems.Insert(index + 2, dti);
                listItems.RemoveAt(index);

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

        private void UpdateInheritance()
        {
            // hacky, but not worth making a general-purpose update notification
            DocTemplateUsage docConcept = (DocTemplateUsage)this.m_conceptleaf;
            TreeNode tn = (TreeNode)docConcept.Tag;
            if (docConcept.Suppress)
            {
                tn.ImageIndex = 46;
                tn.SelectedImageIndex = 46;
            }
            else if (docConcept.Override)
            {
                tn.ImageIndex = 45;
                tn.SelectedImageIndex = 45;
            }
            else
            {
                tn.ImageIndex = 44;
                tn.SelectedImageIndex = 44;
            }

            this.LoadInheritance();
        }

        private void toolStripMenuItemModeInherit_Click(object sender, EventArgs e)
        {
            this.m_conceptleaf.Override = false;
            this.m_conceptleaf.Suppress = false;
            this.UpdateInheritance();
        }

        private void toolStripMenuItemModeOverride_Click(object sender, EventArgs e)
        {
            this.m_conceptleaf.Override = true;
            this.m_conceptleaf.Suppress = false;
            this.UpdateInheritance();
        }

        private void toolStripMenuItemModeSuppress_Click(object sender, EventArgs e)
        {
            this.m_conceptleaf.Override = true;
            this.m_conceptleaf.Suppress = true;
            this.UpdateInheritance();
        }

        private void toolStripButtonConceptTemplate_Click(object sender, EventArgs e)
        {
            DocTemplateDefinition docTemplate = null;
            if (this.m_conceptleaf != null)
            {
                docTemplate = this.m_conceptleaf.Definition;
            }
            else
            {
                docTemplate = this.m_conceptroot.ApplicableTemplate;
            }

            using (FormSelectTemplate form = new FormSelectTemplate(docTemplate, this.m_project, this.m_conceptroot.ApplicableEntity))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.SelectedTemplate != null)
                {
                    if (this.m_conceptleaf != null)
                    {
                        this.m_conceptleaf.Definition = form.SelectedTemplate;
                        this.m_conceptleaf.Items.Clear();
                    }
                    else
                    {
                        this.m_conceptroot.ApplicableTemplate = form.SelectedTemplate;
                        this.m_conceptroot.ApplicableItems.Clear();
                    }

                    this.LoadUsage();
                    this.LoadInheritance();
                }
            }
        }

        private void toolStripButtonItemOptional_Click(object sender, EventArgs e)
        {
            this.toolStripButtonItemOptional.Checked = !this.toolStripButtonItemOptional.Checked;

            DataGridViewRow band = this.dataGridViewConceptRules.SelectedRows[0];
            ((DocTemplateItem)band.Tag).Optional = this.toolStripButtonItemOptional.Checked;
            if (this.toolStripButtonItemOptional.Checked)
            {
                band.DefaultCellStyle.ForeColor = Color.Gray;
            }
            else
            {
                band.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void toolStripButtonShowFailures_Click(object sender, EventArgs e)
        {
            this.toolStripButtonShowFailures.Checked = !this.toolStripButtonShowFailures.Checked;
            this.splitContainer1.Panel2Collapsed = !this.toolStripButtonShowFailures.Checked;
        }

        private void toolStripComboBoxOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_conceptleaf.Operator = (DocTemplateOperator)this.toolStripComboBoxOperator.SelectedIndex;
        }
    }
}

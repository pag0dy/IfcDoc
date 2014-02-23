using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public partial class CtlParameters : UserControl
    {
        DocProject m_project;
        DocConceptRoot m_parent;
        DocTemplateUsage m_target;
        Dictionary<string, DocObject> m_map;
        bool m_editcon;

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

        public DocConceptRoot ConceptRoot
        {
            get
            {
                return this.m_parent;
            }
            set
            {
                this.m_parent = value;
            }
        }

        public DocTemplateUsage ConceptLeaf
        {
            get
            {
                return this.m_target;
            }
            set
            {
                this.m_target = value;
                LoadUsage();
            }
        }

        private void LoadUsage()
        {
            m_editcon = true;
            this.dataGridViewConceptRules.Rows.Clear();
            this.dataGridViewConceptRules.Columns.Clear();

            if (this.m_parent == null || this.m_target == null || !this.m_parent.Concepts.Contains(this.m_target))
                return;

            DocTemplateUsage docUsage = (DocTemplateUsage)this.m_target;
            string[] parmnames = docUsage.Definition.GetParameterNames();
            foreach (string parmname in parmnames)
            {
                DataGridViewColumn column = new DataGridViewColumn();
                column.HeaderText = parmname;
                column.ValueType = typeof(string);//?
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.Width = 200;

                // override cell template for special cases
                DocConceptRoot docConceptRoot = (DocConceptRoot)this.m_parent;
                DocEntity docEntity = docConceptRoot.ApplicableEntity;
                foreach (DocModelRuleAttribute docRule in docUsage.Definition.Rules)
                {
                    DocDefinition docDef = docEntity.ResolveParameterType(docRule, parmname, m_map);
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

                this.dataGridViewConceptRules.Columns.Add(column);
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

                for (int i = 0; i < parmnames.Length; i++)
                {
                    string parmname = parmnames[i];
                    string val = item.GetParameterValue(parmname);
                    if (val != null)
                    {
                        values[i] = val;
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
            this.m_target.Items.Add(new DocTemplateItem());
        }

        private void dataGridViewConceptRules_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.m_target.Items.Remove((DocTemplateItem)e.Row.Tag);
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

            DocTemplateUsage docUsage = (DocTemplateUsage)this.m_target;
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
                DocDefinition docDef = this.m_parent.ApplicableEntity as DocDefinition;

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
                        this.dataGridViewConceptRules.NotifyCurrentCellDirty(true);
                    }
                }
            }
            else
            {
                using (FormSelectEntity form = new FormSelectEntity(docEntity, docSelect, this.m_project))
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

        private void toolStripButtonTemplateInsert_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonTemplateRemove_Click(object sender, EventArgs e)
        {
            this.m_editcon = true;
            int index = this.dataGridViewConceptRules.SelectedRows[0].Index;
            DocTemplateUsage docUsage = (DocTemplateUsage)this.m_target;
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
            DocTemplateUsage docUsage = (DocTemplateUsage)this.m_target;
            DocTemplateItem dti = docUsage.Items[index];
            docUsage.Items.Insert(index - 1, dti);
            docUsage.Items.RemoveAt(index + 1);

            LoadUsage();
            this.dataGridViewConceptRules.Rows[index - 1].HeaderCell.Selected = true;
            //this.dataGridViewConceptRules.CurrentCell = this.dataGridViewConceptRules.Rows[index - 1].c;// Cells[0];// CurrentRow = 0;//.Rows[index - 1].Selected = true;
            this.m_editcon = false;
        }

        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            this.m_editcon = true;
            int index = this.dataGridViewConceptRules.SelectedRows[0].Index;
            if (index < this.dataGridViewConceptRules.Rows.Count - 2)
            {
                DocTemplateUsage docUsage = (DocTemplateUsage)this.m_target;
                DocTemplateItem dti = docUsage.Items[index];
                docUsage.Items.Insert(index + 2, dti);
                docUsage.Items.RemoveAt(index);

                LoadUsage();
                this.dataGridViewConceptRules.Rows[index + 1].Selected = true;
            }
            this.m_editcon = false;
        }
    }
}

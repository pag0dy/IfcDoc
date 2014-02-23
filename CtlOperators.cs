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
    public partial class CtlOperators : UserControl
    {
        private DocProject m_project;
        private DocTemplateDefinition m_template;
        private DocModelRule m_modelrule; // relative rule for which to add constraints

        public CtlOperators()
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
            }
        }

        public DocTemplateDefinition Template
        {
            get
            {
                return this.m_template;
            }
            set
            {
                this.m_template = value;

                this.LoadRules(null);
            }
        }

        public DocModelRule Rule
        {
            get
            {
                return this.m_modelrule;
            }
            set
            {
                this.m_modelrule = value;
            }
        }

        public void DoInsert()
        {
            if (this.Template == null)
                return;

            DocModelRule docModelRule = this.Rule;
            if (docModelRule == null)
                return;

            TreeNode tnSelect = this.treeViewRules.SelectedNode;

            DocOpReference opref = new DocOpReference();
            opref.Operation = DocOpCode.nop;
            opref.EntityRule = this.Rule as DocModelRuleEntity;

            DocOpLiteral oplit = new DocOpLiteral();
            oplit.Operation = DocOpCode.ldstr;
            oplit.Value = null;

            DocOpStatement op = new DocOpStatement();
            op.Operation = DocOpCode.ceq;
            op.Reference = opref;
            op.Value = oplit;

            if (tnSelect != null)
            {
                DocOpExpression opSelect = tnSelect.Tag as DocOpExpression;
                if (tnSelect.Tag is DocModelRuleConstraint)
                {
                    opSelect = ((DocModelRuleConstraint)tnSelect.Tag).Expression;

                }


                // convert existing node into new Logical operator

                DocOpLogical opLog = new DocOpLogical();
                opLog.Operation = DocOpCode.and;
                opLog.ExpressionA = opSelect;
                opLog.ExpressionB = op;

                if (tnSelect.Tag is DocModelRuleConstraint)
                {
                    DocModelRuleConstraint dmr = (DocModelRuleConstraint)tnSelect.Tag;
                    dmr.Expression = opLog;
                }
                else if (tnSelect.Parent != null)
                {
                    DocOpLogical opParent = tnSelect.Parent.Tag as DocOpLogical;
                    if (tnSelect.Parent.Tag is DocModelRuleConstraint)
                    {
                        opParent = ((DocModelRuleConstraint)tnSelect.Parent.Tag).Expression as DocOpLogical;
                    }

                    if (tnSelect.Parent.Nodes[0] == tnSelect)
                    {
                        opParent.ExpressionA = opLog;
                    }
                    else if (tnSelect.Parent.Nodes[1] == tnSelect)
                    {
                        opParent.ExpressionB = opLog;
                    }
                }
                else if (tnSelect.Parent != null && tnSelect.Parent.Nodes[1] == tnSelect)
                {
                    DocOpLogical opParent = (DocOpLogical)tnSelect.Parent.Tag;
                    opParent.ExpressionB = opLog;
                }

                this.LoadRules(op);
            }
            else
            {
                // create new constraint
                DocModelRuleConstraint docCon = new DocModelRuleConstraint();
                docCon.Expression = op;
                docModelRule.Rules.Add(docCon);

                TreeNode tnCon = new TreeNode();
                tnCon.Tag = docCon;
                tnCon.Text = op.ToString(this.Template);
                tnCon.ImageIndex = 3;
                tnCon.SelectedImageIndex = tnCon.ImageIndex;
                this.treeViewRules.Nodes.Add(tnCon);

                this.treeViewRules.SelectedNode = tnCon;
            }

        }

        private void LoadRules(DocOp selection)
        {
            this.treeViewRules.BeginUpdate();
            this.treeViewRules.Nodes.Clear();
            if (this.m_template != null)
            {
                this.LoadRules(this.Template.Rules, null);
                this.treeViewRules.ExpandAll();
                this.treeViewRules_AfterSelect(this.treeViewRules, new TreeViewEventArgs(null));

                foreach (TreeNode tn in this.treeViewRules.Nodes)
                {
                    SelectRule(tn, selection);
                }
            }
            this.treeViewRules.EndUpdate();
        }

        private void LoadRules(List<DocModelRule> list, DocModelRule parentrule)
        {
            if (list == null)
                return;

            foreach (DocModelRule docRule in list)
            {
                if (docRule is DocModelRuleConstraint)
                {
                    DocModelRuleConstraint rc = (DocModelRuleConstraint)docRule;
                    TreeNode tn = new TreeNode();
                    tn.Tag = docRule;
                    tn.Text = docRule.Description;
                    tn.ImageIndex = 4;
                    this.treeViewRules.Nodes.Add(tn);

                    // backward compatibility before V6.1 -- generate rule from syntax
                    if (rc.Expression == null && docRule.Description != null)
                    {
                        DocOpReference reference = new DocOpReference();
                        reference.EntityRule = parentrule as DocModelRuleEntity;

                        DocOpLiteral literal = new DocOpLiteral();

                        DocOpStatement statement = new DocOpStatement();
                        statement.Reference = reference;
                        statement.Value = literal;
                        rc.Expression = statement;

                        string value = docRule.Description;
                        int index = value.IndexOfAny(new char[] { '=', '!', '>', '<' });
                        if (index > 0)
                        {
                            string metric = value.Substring(0, index);
                            switch (metric)
                            {
                                case "Value":
                                    ///...
                                    break;

                                case "Length":
                                    ///...
                                    break;
                            }

                            string oper = value.Substring(index, 1);
                            string bench = value.Substring(index + 1);
                            if (value.Length > index + 1 && value[index + 1] == '=')
                            {
                                oper = value.Substring(index, 2);
                                bench = value.Substring(index + 2);
                            }

                            switch (oper)
                            {
                                case "=":
                                    statement.Operation = DocOpCode.ceq;
                                    break;

                                case "!=":
                                    statement.Operation = DocOpCode.cne;
                                    break;

                                case "<=":
                                    statement.Operation = DocOpCode.cle;
                                    break;

                                case "<":
                                    statement.Operation = DocOpCode.clt;
                                    break;

                                case ">=":
                                    statement.Operation = DocOpCode.cge;
                                    break;

                                case ">":
                                    statement.Operation = DocOpCode.cgt;
                                    break;
                            }

                            literal.Value = bench;
                        }
                    }

                    LoadOpExpression(tn, rc.Expression);
                }

                LoadRules(docRule.Rules, docRule);
            }
        }

        private void LoadOpExpression(TreeNode tn, DocOp op)
        {
            if (op == null)
                return;

            if (tn.Tag == null)
            {
                tn.Tag = op;
            }
            tn.Text = op.ToString(this.Template);
            tn.ImageIndex = 3;
            tn.SelectedImageIndex = tn.ImageIndex;

            if (op is DocOpLogical)
            {
                DocOpLogical oplog = (DocOpLogical)op;
                tn.ImageIndex = 4;
                tn.SelectedImageIndex = tn.ImageIndex;

                TreeNode tnA = new TreeNode();
                LoadOpExpression(tnA, oplog.ExpressionA);
                tn.Nodes.Add(tnA);

                TreeNode tnB = new TreeNode();
                LoadOpExpression(tnB, oplog.ExpressionB);
                tn.Nodes.Add(tnB);
            }
        }

        private void SelectRule(TreeNode tn, DocOp selection)
        {
            if (tn.Tag == selection)
            {
                this.treeViewRules.SelectedNode = tn;
                return;
            }
            else if (tn.Tag is DocModelRuleConstraint)
            {
                DocModelRuleConstraint dmc = (DocModelRuleConstraint)tn.Tag;
                if (dmc.Expression == selection)
                {
                    this.treeViewRules.SelectedNode = tn;
                }
            }

            foreach (TreeNode ts in tn.Nodes)
            {
                SelectRule(ts, selection);
            }
        }

        private void treeViewRules_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DocOp op = this.GetSelectedOp();

            if (this.Template == null)
            {
                foreach (ToolStripItem tsi in this.toolStripConceptRule.Items)
                {
                    tsi.Enabled = false;

                    if (tsi is ToolStripButton)
                    {
                        ((ToolStripButton)tsi).Checked = false;
                    }
                }
                return;
            }

            this.toolStripButtonRuleInsert.Enabled = (this.Rule != null);
            this.toolStripButtonRuleRemove.Enabled = (op != null);
            this.toolStripButtonRuleUpdate.Enabled = (op is DocOpStatement);
            this.toolStripButtonRuleRef.Enabled = (op is DocOpStatement && this.Rule != null);

            this.toolStripButtonRuleAnd.Enabled = (op is DocOpLogical);
            this.toolStripButtonRuleOr.Enabled = (op is DocOpLogical);
            this.toolStripButtonRuleXor.Enabled = (op is DocOpLogical);

            this.toolStripButtonRuleCeq.Enabled = (op is DocOpStatement);
            this.toolStripButtonRuleCne.Enabled = (op is DocOpStatement);
            this.toolStripButtonRuleCle.Enabled = (op is DocOpStatement);
            this.toolStripButtonRuleClt.Enabled = (op is DocOpStatement);
            this.toolStripButtonRuleCge.Enabled = (op is DocOpStatement);
            this.toolStripButtonRuleCgt.Enabled = (op is DocOpStatement);

            this.toolStripButtonRuleAnd.Checked = (op != null && op.Operation == DocOpCode.and);
            this.toolStripButtonRuleOr.Checked = (op != null && op.Operation == DocOpCode.or);
            this.toolStripButtonRuleXor.Checked = (op != null && op.Operation == DocOpCode.xor);

            this.toolStripButtonRuleCeq.Checked = (op != null && op.Operation == DocOpCode.ceq);
            this.toolStripButtonRuleCne.Checked = (op != null && op.Operation == DocOpCode.cne);
            this.toolStripButtonRuleCle.Checked = (op != null && op.Operation == DocOpCode.cle);
            this.toolStripButtonRuleClt.Checked = (op != null && op.Operation == DocOpCode.clt);
            this.toolStripButtonRuleCge.Checked = (op != null && op.Operation == DocOpCode.cge);
            this.toolStripButtonRuleCgt.Checked = (op != null && op.Operation == DocOpCode.cgt);
        }

        private void treeViewRules_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // launch literal editor
            toolStripButtonRuleUpdate_Click(null, EventArgs.Empty);
        }

        private void treeViewRules_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.treeViewRules.HitTest(e.Location).Node == null)
            {
                this.treeViewRules.SelectedNode = null;
                treeViewRules_AfterSelect(this.treeViewRules, new TreeViewEventArgs(null));
            }
        }

        private void toolStripButtonRuleInsert_Click(object sender, EventArgs e)
        {
            this.DoInsert();
        }

        private void toolStripButtonRuleRemove_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.treeViewRules.SelectedNode;

            if (tn.Tag is DocModelRuleConstraint)
            {
                DocModelRuleConstraint docConstraint = (DocModelRuleConstraint)tn.Tag;
                docConstraint.Delete();
                this.RemoveRuleConstraint(this.Template.Rules, docConstraint);
                this.LoadRules(null);
            }
            else if (tn.Tag is DocOp)
            {
                // dissolve parent Logical operator, move other statement into parent

                DocOp op = (DocOp)tn.Tag;

                TreeNode tnParent = tn.Parent;
                DocOpLogical oplog = tnParent.Tag as DocOpLogical;
                if (tnParent.Tag is DocModelRuleConstraint)
                {
                    DocModelRuleConstraint dmr = (DocModelRuleConstraint)tnParent.Tag;
                    oplog = dmr.Expression as DocOpLogical;
                }

                TreeNode tnGrand = tnParent.Parent;

                DocOpExpression opOther = null;
                if (oplog.ExpressionA == op)
                {
                    opOther = oplog.ExpressionB;
                    oplog.ExpressionB = null; // prevent deletion
                }
                else if (oplog.ExpressionB == op)
                {
                    opOther = oplog.ExpressionA;
                    oplog.ExpressionA = null; // prevent deletion
                }

                if (tnParent.Tag is DocModelRuleConstraint)
                {
                    DocModelRuleConstraint dmr = (DocModelRuleConstraint)tnParent.Tag;
                    dmr.Expression = opOther;
                }
                else if (tnGrand != null)
                {
                    DocOpLogical opGrand = tnGrand.Tag as DocOpLogical;
                    if (tnGrand.Tag is DocModelRuleConstraint)
                    {
                        DocModelRuleConstraint dmr = (DocModelRuleConstraint)tnGrand.Tag;
                        opGrand = dmr.Expression as DocOpLogical;
                    }

                    if (opGrand.ExpressionA == oplog)
                    {
                        opGrand.ExpressionA = opOther;
                    }
                    else if (opGrand.ExpressionB == oplog)
                    {
                        opGrand.ExpressionB = opOther;
                    }
                }

                oplog.Delete();
                op.Delete();
                this.LoadRules(opOther);
            }
        }

        private void RemoveRuleConstraint(List<DocModelRule> list, DocModelRuleConstraint ruleCon)
        {
            if (list.Contains(ruleCon))
            {
                list.Remove(ruleCon);
            }

            foreach (DocModelRule sub in list)
            {
                if (sub.Rules != null)
                {
                    RemoveRuleConstraint(sub.Rules, ruleCon);
                }
            }
        }

        private DocOp GetSelectedOp()
        {
            TreeNode tn = this.treeViewRules.SelectedNode;
            if (tn == null)
                return null;

            DocOp docop = tn.Tag as DocOp;
            if (tn.Tag is DocModelRuleConstraint)
            {
                DocModelRuleConstraint dmr = (DocModelRuleConstraint)tn.Tag;
                docop = dmr.Expression;
            }

            return docop;
        }


        private void toolStripButtonRuleUpdate_Click(object sender, EventArgs e)
        {
            DocOpStatement docop = GetSelectedOp() as DocOpStatement;

            // enumeration|boolean|logical: pick from list
            // string|integer|real: freeform editor

            using (FormConstraint form = new FormConstraint())
            {
                form.DataType = this.m_project.GetDefinition(docop.Reference.EntityRule.Name) as DocType;
                if (form.DataType != null)
                {
                    form.Metric = docop.Metric;
                    form.Operation = docop.Operation;

                    if (docop.Value is DocOpLiteral)
                    {
                        form.Literal = ((DocOpLiteral)docop.Value).Value;
                    }
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        docop.Operation = form.Operation;
                        docop.Metric = form.Metric;

                        if (!(docop.Value is DocOpLiteral))
                        {
                            docop.Value.Delete();
                            docop.Value = new DocOpLiteral();
                        }

                        ((DocOpLiteral)docop.Value).Value = form.Literal;

                        this.treeViewRules.SelectedNode.Text = docop.ToString(this.Template);
                    }
                }
            }
        }

        private void toolStripButtonRuleRef_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonRuleAnd_Click(object sender, EventArgs e)
        {
            SetSelectedRuleOperator(DocOpCode.and);
        }

        private void toolStripButtonRuleOr_Click(object sender, EventArgs e)
        {
            SetSelectedRuleOperator(DocOpCode.or);
        }

        private void toolStripButtonRuleXor_Click(object sender, EventArgs e)
        {
            SetSelectedRuleOperator(DocOpCode.xor);
        }

        private void toolStripButtonRuleCeq_Click(object sender, EventArgs e)
        {
            SetSelectedRuleOperator(DocOpCode.ceq);
        }

        private void toolStripButtonRuleCne_Click(object sender, EventArgs e)
        {
            SetSelectedRuleOperator(DocOpCode.cne);
        }

        private void toolStripButtonRuleCgt_Click(object sender, EventArgs e)
        {
            SetSelectedRuleOperator(DocOpCode.cgt);
        }

        private void toolStripButtonRuleCge_Click(object sender, EventArgs e)
        {
            SetSelectedRuleOperator(DocOpCode.cge);
        }

        private void toolStripButtonRuleClt_Click(object sender, EventArgs e)
        {
            SetSelectedRuleOperator(DocOpCode.clt);
        }

        private void toolStripButtonRuleCle_Click(object sender, EventArgs e)
        {
            SetSelectedRuleOperator(DocOpCode.cle);
        }

        private void SetSelectedRuleOperator(DocOpCode opcode)
        {
            TreeNode tn = this.treeViewRules.SelectedNode;
            DocOp docop = this.GetSelectedOp();

            docop.Operation = opcode;
            tn.Text = docop.ToString(this.Template);

            this.treeViewRules_AfterSelect(this.treeViewRules, new TreeViewEventArgs(this.treeViewRules.SelectedNode));
        }


    }
}

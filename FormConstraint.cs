// Name:        FormCode.cs
// Description: Dialog box for editing constraints on rules
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2013 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public partial class FormConstraint : Form
    {
        DocType m_datatype;

        static string[] s_operators = new string[6]
            {
                "=",
                "!=",
                ">",
                ">=",
                "<",
                "<=",
            };

        public FormConstraint()
        {
            InitializeComponent();

            this.comboBoxMetric.SelectedIndex = 0;
            this.comboBoxOperator.SelectedIndex = 0;
        }

        public DocType DataType
        {
            get
            {
                return this.m_datatype;
            }
            set 
            {
                this.m_datatype = value;

                this.comboBoxValue.Items.Clear();
                this.comboBoxValue.Visible = false;
                if (this.m_datatype is DocEnumeration)
                {
                    DocEnumeration docEnum = (DocEnumeration)this.m_datatype;
                    foreach (DocConstant docCon in docEnum.Constants)
                    {
                        this.comboBoxValue.Items.Add(docCon);
                    }
                    this.comboBoxValue.Visible = true;
                }
                else if(this.m_datatype is DocDefined)
                {
                    DocDefined docDef = (DocDefined)this.m_datatype;
                    if(docDef.DefinedType.Equals("BOOLEAN"))
                    {
                        this.comboBoxValue.Items.Add("FALSE");
                        this.comboBoxValue.Items.Add("TRUE");
                        this.comboBoxValue.Items.Add("NULL");
                        this.comboBoxValue.Visible = true;
                    }
                    else if(docDef.DefinedType.Equals("LOGICAL"))
                    {
                        this.comboBoxValue.Items.Add("FALSE");
                        this.comboBoxValue.Items.Add("TRUE");
                        this.comboBoxValue.Items.Add("UNKNOWN");
                        this.comboBoxValue.Items.Add("NULL");
                        this.comboBoxValue.Visible = true;
                    }
                }
            }
        }

        public DocOpCode Metric
        {
            get 
            {
                switch(this.comboBoxMetric.SelectedIndex)
                {
                    case 0:
                        return DocOpCode.nop;

                    case 1:
                        return DocOpCode.ldlen;

                    case 2:
                        return DocOpCode.isinst;

                    case 3:
                        return DocOpCode.call;
                }

                return DocOpCode.nop;
            }
            set
            {
                switch(value)
                {
                    case DocOpCode.nop:
                        this.comboBoxMetric.SelectedIndex = 0;
                        break;

                    case DocOpCode.ldlen:
                        this.comboBoxMetric.SelectedIndex = 1;
                        break;

                    case DocOpCode.isinst:
                        this.comboBoxMetric.SelectedIndex = 2;
                        break;

                    case DocOpCode.call:
                        this.comboBoxMetric.SelectedIndex = 3;
                        break;
                }
            }
        }

        public DocOpCode Operation
        {
            get
            {
                switch(this.comboBoxOperator.SelectedIndex)
                {
                    case 0:
                        return DocOpCode.ceq;

                    case 1:
                        return DocOpCode.cne;

                    case 2:
                        return DocOpCode.cgt;

                    case 3:
                        return DocOpCode.cge;

                    case 4:
                        return DocOpCode.clt;

                    case 5:
                        return DocOpCode.cle;
                }

                return DocOpCode.ceq;
            }
            set
            {
                switch(value)
                {
                    case DocOpCode.ceq:
                        this.comboBoxOperator.SelectedIndex = 0;
                        break;
                    case DocOpCode.cne:
                        this.comboBoxOperator.SelectedIndex = 1;
                        break;
                    case DocOpCode.cgt:
                        this.comboBoxOperator.SelectedIndex = 2;
                        break;
                    case DocOpCode.cge:
                        this.comboBoxOperator.SelectedIndex = 3;
                        break;
                    case DocOpCode.clt:
                        this.comboBoxOperator.SelectedIndex = 4;
                        break;
                    case DocOpCode.cle:
                        this.comboBoxOperator.SelectedIndex = 5;
                        break;
                }
            }
        }

        public string Literal
        {
            get
            {
                if (this.comboBoxValue.SelectedItem != null)
                {
                    return this.comboBoxValue.Text;
                }

                return this.textBoxBenchmark.Text;
            }
            set
            {
                this.textBoxBenchmark.Text = value;

                if(this.comboBoxValue.Visible)
                {
                    foreach(object o in this.comboBoxValue.Items)
                    {
                        if(o.ToString().Equals(value))
                        {
                            this.comboBoxValue.SelectedItem = o;
                            break;
                        }
                    }
                }
            }
        }

        public string Expression
        {
            get
            {
                return this.textBoxExpression.Text;
            }
            set
            {
                this.textBoxExpression.Text = value;

                // parse it out
                if (value != null)
                {
                    int index = value.IndexOfAny(new char[] { '=', '!', '>', '<' });
                    if (index > 0)
                    {
                        string metric = value.Substring(0, index);
                        switch (metric)
                        {
                            case "Value":
                                this.comboBoxMetric.SelectedIndex = 0;
                                break;

                            case "Length":
                                this.comboBoxMetric.SelectedIndex = 1;
                                break;
                        }

                        string oper = value.Substring(index, 1);
                        string bench = value.Substring(index + 1);
                        if (value.Length > index + 1 && value[index + 1] == '=')
                        {
                            oper = value.Substring(index, 2);
                            bench = value.Substring(index + 2);
                        }
                        for (int i = 0; i < s_operators.Length; i++)
                        {
                            if (s_operators[i] == oper)
                            {
                                this.comboBoxOperator.SelectedIndex = i;
                                break;
                            }
                        }

                        this.textBoxBenchmark.Text = bench;
                    }                    
                }
            }
        }

        private void comboBoxMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateExpression();
        }

        private void comboBoxOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateExpression();
        }

        private void textBoxBenchmark_TextChanged(object sender, EventArgs e)
        {
            UpdateExpression();
        }

        private void UpdateExpression()
        {
            if (this.comboBoxOperator.SelectedIndex == -1)
                return;

            string value = this.textBoxBenchmark.Text;
            if (this.comboBoxValue.Visible)
            {
                value = this.comboBoxValue.Text;
            }
            if(String.IsNullOrEmpty(value))
            {
                value = "NULL";
            }

            this.textBoxExpression.Text = this.comboBoxMetric.Text + s_operators[this.comboBoxOperator.SelectedIndex] + value;            
        }

        private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateExpression();
        }
    }
}

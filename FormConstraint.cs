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

namespace IfcDoc
{
    public partial class FormConstraint : Form
    {
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

            this.textBoxExpression.Text = this.comboBoxMetric.Text + s_operators[this.comboBoxOperator.SelectedIndex] + this.textBoxBenchmark.Text;            
        }
    }
}

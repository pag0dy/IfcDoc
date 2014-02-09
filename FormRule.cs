// Name:        FormRule.cs
// Description: Dialog box for editing rule
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2012 BuildingSmart International Ltd.
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
    public partial class FormRule : Form
    {
        DocModelRule m_rule;

        public FormRule()
        {
            InitializeComponent();
        }

        public FormRule(DocModelRule rule)
            : this()
        {
            this.m_rule = rule;

            this.Text = this.m_rule.Name;
            this.textBoxIdentifier.Text = this.m_rule.Identification;
            this.textBoxIdentifier.Enabled = !String.IsNullOrEmpty(this.m_rule.Identification);
            if (String.IsNullOrEmpty(this.m_rule.Identification))
            {
                this.comboBoxUsage.SelectedIndex = 0;
            }
            else if (this.m_rule.Description != null && this.m_rule.Description.Equals("*"))
            {
                // convention indicating filter
                this.comboBoxUsage.SelectedIndex = 1;
            }
            else
            {
                // indicates parameter constraint
                this.comboBoxUsage.SelectedIndex = 2;
            }

            if (this.m_rule.CardinalityMin == 0 && this.m_rule.CardinalityMax == 0)
            {
                this.comboBoxCardinality.SelectedIndex = 0;
            }
            else if (this.m_rule.CardinalityMin == -1 && this.m_rule.CardinalityMax == -1)
            {
                this.comboBoxCardinality.SelectedIndex = 1;
            }
            else if (this.m_rule.CardinalityMin == 0 && this.m_rule.CardinalityMax == 1)
            {
                this.comboBoxCardinality.SelectedIndex = 2;
            }
            else if (this.m_rule.CardinalityMin == 1 && this.m_rule.CardinalityMax == 1)
            {
                this.comboBoxCardinality.SelectedIndex = 3;
            }
            else if (this.m_rule.CardinalityMin == 1 && this.m_rule.CardinalityMax == -1)
            {
                this.comboBoxCardinality.SelectedIndex = 4;
            }

            this.UpdateBehavior();
        }

        private void textBoxIdentifier_TextChanged(object sender, EventArgs e)
        {
            this.m_rule.Identification = this.textBoxIdentifier.Text;
        }

        private void comboBoxCardinality_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxCardinality.SelectedIndex)
            {
                case 0:
                    this.m_rule.CardinalityMin = 0;
                    this.m_rule.CardinalityMax = 0; // same as unitialized file
                    break;

                case 1:
                    this.m_rule.CardinalityMin = -1; // means 0:0
                    this.m_rule.CardinalityMax = -1;
                    break;

                case 2:
                    this.m_rule.CardinalityMin = 0;
                    this.m_rule.CardinalityMax = 1;
                    break;

                case 3:
                    this.m_rule.CardinalityMin = 1;
                    this.m_rule.CardinalityMax = 1;
                    break;

                case 4:
                    this.m_rule.CardinalityMin = 1;
                    this.m_rule.CardinalityMax = -1;
                    break;
            }

            this.UpdateBehavior();
        }

        private void comboBoxUsage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxIdentifier.Enabled = (this.comboBoxUsage.SelectedIndex > 0);
            switch(this.comboBoxUsage.SelectedIndex)
            {
                case 0:
                    this.textBoxIdentifier.Text = "";
                    this.m_rule.Identification = null;
                    this.m_rule.Description = null;
                    break;

                case 1:
                    this.m_rule.Description = "*";
                    break;

                case 2:
                    this.m_rule.Description = null;
                    break;
            }

            this.UpdateBehavior();
        }

        private void UpdateBehavior()
        {
            switch (this.comboBoxUsage.SelectedIndex)
            {
                case 0:
                    this.textBoxBehavior.Text = "";
                    break;

                case 1:
                    this.textBoxBehavior.Text = "Rules only apply if attribute equals specified value.\r\n";
                    break;

                case 2:
                    this.textBoxBehavior.Text = "Attribute must equal specified value if rule applies.\r\n";
                    break;
            }

            switch (this.comboBoxCardinality.SelectedIndex)
            {
                case 0: // -
                    break;

                case 1: // [0]
                    this.textBoxBehavior.Text += "No applicable template items may satisfy all constraints.";
                    break;

                case 2: // [0:1]
                    this.textBoxBehavior.Text += "Zero or one template items must satisfy all constraints.";
                    break;

                case 3: // [1]
                    this.textBoxBehavior.Text += "Exactly one applicable template item must satisfy all constraints.";
                    break;

                case 4: // [1:?]
                    this.textBoxBehavior.Text += "Each applicable template item must satisfy all constraints.";
                    break;
            }
        }
    }
}

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
    public partial class FormParameters : Form
    {
        public FormParameters()
        {
            InitializeComponent();
        }

        public DocProject Project
        {
            get
            {
                return this.ctlParameters.Project;
            }
            set
            {
                this.ctlParameters.Project = value;
            }
        }

        public DocConceptRoot ConceptRoot
        {
            get
            {
                return this.ctlParameters.ConceptRoot;
            }
            set
            {
                this.ctlParameters.ConceptRoot = value;
            }
        }

        public DocTemplateUsage ConceptLeaf
        {
            get
            {
                return this.ctlParameters.ConceptLeaf;
            }
            set
            {
                this.ctlParameters.ConceptLeaf = value;
            }
        }
    }
}

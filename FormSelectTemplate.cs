// Name:        FormSelectTemplate.cs
// Description: Dialog box for selecting template
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2011 BuildingSmart International Ltd.
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
    public partial class FormSelectTemplate : Form
    {
        DocTemplateDefinition m_selection;
        DocProject m_project;

        public FormSelectTemplate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selection">Selected template.</param>
        /// <param name="project">Projet containing templates.</param>
        /// <param name="entity">The entity for which templates are filtered.</param>
        public FormSelectTemplate(DocTemplateDefinition selection, DocProject project, DocEntity entity)
            : this()
        {
            this.m_selection = selection;
            this.m_project = project;

            // build map
            Dictionary<string, DocObject> map = new Dictionary<string, DocObject>();
            foreach (DocSection docSection in this.m_project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        map.Add(docEntity.Name, docEntity);
                    }

                    foreach (DocType docType in docSchema.Types)
                    {
                        map.Add(docType.Name, docType);
                    }
                }
            }                

            foreach (DocTemplateDefinition docTemplate in project.Templates)
            {
                bool include = false;

                // check for inheritance                
                DocObject docApplicableEntity = null;
                if (entity == null)
                {
                    include = true;
                }
                else if (docTemplate.Type != null && map.TryGetValue(docTemplate.Type, out docApplicableEntity) && docApplicableEntity is DocEntity)
                {
                    // check for inheritance
                    DocEntity docBase = entity;
                    while (docBase != null)
                    {
                        if (docBase == docApplicableEntity)
                        {
                            include = true;
                            break;
                        }

                        if (docBase.BaseDefinition == null)
                            break;

                        DocObject docEach = null;
                        if (map.TryGetValue(docBase.BaseDefinition, out docEach))
                        {
                            docBase = (DocEntity)docEach;
                        }
                        else
                        {
                            docBase = null;
                        }
                    }
                }

                if (include)
                {
                    LoadTemplate(null, docTemplate);
                }
            }
        }

        private void LoadTemplate(TreeNode tnParent, DocTemplateDefinition template)
        {
            // add entity
            TreeNode tn = new TreeNode();
            tn.Tag = template;
            tn.Text = template.Name;

            if (tnParent != null)
            {
                tnParent.Nodes.Add(tn);
            }
            else
            {
                this.treeView.Nodes.Add(tn);
            }

            if (this.m_selection == template)
            {
                this.treeView.SelectedNode = tn;
            }

            foreach (DocTemplateDefinition sub in template.Templates)
            {
                LoadTemplate(tn, sub);
            }
        }

        public DocTemplateDefinition SelectedTemplate
        {
            get
            {
                if (this.treeView.SelectedNode == null)
                    return null;

                return this.treeView.SelectedNode.Tag as DocTemplateDefinition;
            }
        }
    }
}

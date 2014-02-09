// Name:        CtlConcept.cs
// Description: Concept diagram editor
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

using IfcDoc.Format.PNG;
using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public partial class CtlConcept : ScrollableControl
    {
        Image m_image;
        DocProject m_project;
        DocTemplateDefinition m_template;
        DocModelRule m_selection;
        DocModelRule m_highlight;
        Dictionary<string, DocObject> m_map;
        Dictionary<Rectangle, DocModelRule> m_hitmap;

        public event EventHandler SelectionChanged;

        public CtlConcept()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.AutoScroll = true;
        }

        public Dictionary<string, DocObject> Map
        {
            get
            {
                return this.m_map;
            }
            set
            {
                this.m_map = value;
            }
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
                if (this.m_template != null && this.m_project != null && this.m_map != null)
                {
                    this.m_hitmap = new Dictionary<Rectangle, DocModelRule>();
                    this.m_image = FormatPNG.CreateTemplateDiagram(this.m_template, this.m_map, this.m_hitmap, this.m_project);
                    if (this.m_image != null)
                    {
                        this.AutoScrollMinSize = new Size(this.m_image.Width, this.m_image.Height);
                    }
                }
                else
                {
                    this.m_image = null;
                }
                this.Invalidate();
            }
        }

        public DocModelRule Selection
        {
            get
            {
                return this.m_selection;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.m_image != null)
            {
                Graphics g = pe.Graphics;
                g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                g.DrawImage(this.m_image, Point.Empty);

                // selection, highlight...
            }
        }
    }
}

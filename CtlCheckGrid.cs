// Name:        CtlCheckGrid.cs
// Description: Checkbox grid
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
    public partial class CtlCheckGrid : ScrollableControl
    {
        ICheckGrid m_datasource;

        const int CX = 12;
        const int CY = 12;

        const int SX = 100;
        const int SY = 100;

        public CtlCheckGrid()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.AutoScroll = true;
        }

        public ICheckGrid CheckGridSource
        {
            get
            {
                return this.m_datasource;
            }
            set
            {
                this.m_datasource = value;
                if (this.m_datasource != null)
                {
                    this.AutoScrollMinSize = new Size(SX + CX * this.m_datasource.GetColumnCount(), SY + CY * this.m_datasource.GetRowCount());
                }
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (this.m_datasource == null)
                return;

            Graphics g = pe.Graphics;
            g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

            // draw column header
            for(int iCol = 0; iCol < this.m_datasource.GetColumnCount(); iCol++)
            {
                object col = this.m_datasource.GetColumn(iCol);
                g.DrawRectangle(Pens.Black, SX + iCol * CX, 0, CY, 2000);
                g.DrawString(col.ToString(), this.Font, Brushes.Black, SX + iCol * CX - 2, 0, new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical));
            }

            for(int iRow = 0; iRow < this.m_datasource.GetRowCount(); iRow++)
            {
                object row = this.m_datasource.GetRow(iRow);
                
                // draw row header
                g.DrawRectangle(Pens.Black, 0, SY + iRow * CY, 2000, CY);
                g.DrawString(row.ToString(), this.Font, Brushes.Black, 0, SY + iRow * CY);

                for (int iCol = 0; iCol < this.m_datasource.GetColumnCount(); iCol++)
                {
                    object col = this.m_datasource.GetColumn(iCol);

                    // draw cell
                    CellValue val = this.m_datasource.GetCell(iRow, iCol);
                    if (val == CellValue.Optional || val == CellValue.Required)
                    {
                        g.DrawLine(Pens.Black, SX + iCol * CX, SY + (iRow + 1) * CY, SX + (iCol + 1) * CX, SY + iRow * CY);
                    }
                    if (val == CellValue.Required)
                    {
                        g.DrawLine(Pens.Black, SX + iCol * CX, SY + iRow * CY, SX + (iCol + 1) * CX, SY + (iRow + 1) * CY);
                    }
                }
            }
        }

        private void CtlCheckGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.m_datasource == null)
                return;

            int iCol = (e.X - SX) / CX;
            int iRow = (e.Y - SY) / CY;

            if (iCol < 0 || iRow < 0)
                return;

            CellValue oldval = this.m_datasource.GetCell(iRow, iCol);
            if (oldval == CellValue.Unavailable)
                return;
            CellValue newval = oldval;
            switch(oldval)
            {
                    
                case CellValue.None:
                    newval = CellValue.Optional;
                    break;

                case CellValue.Optional:
                    newval = CellValue.Required;
                    break;

                case CellValue.Required:
                    newval = CellValue.None;
                    break;

                default:
                    newval = CellValue.Required;
                    break;
            }
            this.m_datasource.SetCell(iRow, iCol, newval);

            this.Invalidate(false);
        }
    }


    public interface ICheckGrid
    {
        /// <summary>
        /// Returns object for column, where ToString() is shown as text; NULL if no more columns.
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        object GetColumn(int col);

        /// <summary>
        /// Returns object for row, where ToString() is shown as text; NULL if no more rows.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        object GetRow(int row);

        /// <summary>
        /// Returns value for cell.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        CellValue GetCell(int row, int col);

        /// <summary>
        /// Sets value for cell.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="val"></param>
        void SetCell(int row, int col, CellValue val);

        int GetColumnCount();

        int GetRowCount();
    }

    public enum CellValue
    {
        /// <summary>
        /// Cannot be edited
        /// </summary>
        Unavailable = -1,

        /// <summary>
        /// Blank value
        /// </summary>
        None = 0,

        /// <summary>
        /// Half slash for optional
        /// </summary>
        Optional = 1,

        /// <summary>
        /// X for required
        /// </summary>
        Required = 2,
    }

    /// <summary>
    /// Shows entities for each row, exchanges for each column
    /// </summary>
    public class CheckGridConcept : ICheckGrid
    {
        DocTemplateDefinition m_template;
        DocModelView m_view;
        DocProject m_project;

        public CheckGridConcept(DocTemplateDefinition docTemplate, DocModelView docView, DocProject docProject)
        {
            this.m_template = docTemplate;
            this.m_view = docView;
            this.m_project = docProject;
        }

        public int GetColumnCount()
        {
            return this.m_view.Exchanges.Count;
        }

        public int GetRowCount()
        {
            return this.m_view.ConceptRoots.Count;
        }

        public object GetColumn(int col)
        {
            if (col >= 0 && col < this.m_view.Exchanges.Count)
            {
                return this.m_view.Exchanges[col];
            }

            return null;
        }

        public object GetRow(int row)
        {
            if (row >= 0 && row < this.m_view.ConceptRoots.Count)
            {
                return this.m_view.ConceptRoots[row];
            }

            return null;
        }

        public CellValue GetCell(int row, int col)
        {
            DocConceptRoot docRoot = this.m_view.ConceptRoots[row];
            DocExchangeDefinition docExchange = this.m_view.Exchanges[col];

            foreach (DocTemplateUsage docUsage in docRoot.Concepts)
            {
                if (docUsage.Definition == this.m_template)
                {
                    foreach (DocExchangeItem docEx in docUsage.Exchanges)
                    {
                        if (docEx.Exchange == docExchange && docEx.Applicability == DocExchangeApplicabilityEnum.Export)
                        {
                            switch (docEx.Requirement)
                            {
                                case DocExchangeRequirementEnum.Mandatory:
                                    return CellValue.Required;

                                case DocExchangeRequirementEnum.Optional:
                                    return CellValue.Optional;
                            }
                        }
                    }

                    return CellValue.None;
                }
            }

            return CellValue.None;
        }

        public void SetCell(int row, int col, CellValue val)
        {
            DocConceptRoot docRoot = this.m_view.ConceptRoots[row];
            DocExchangeDefinition docExchange = this.m_view.Exchanges[col];

            DocTemplateUsage docUsage = null;
            foreach (DocTemplateUsage eachUsage in docRoot.Concepts)
            {
                if (eachUsage.Definition == this.m_template)
                {
                    docUsage = eachUsage;
                    break;
                }
            }

            if (docUsage == null)
            {
                docUsage = new DocTemplateUsage();
                docRoot.Concepts.Add(docUsage);
                docUsage.Definition = this.m_template;
            }

            DocExchangeRequirementEnum req = DocExchangeRequirementEnum.NotRelevant;
            switch (val)
            {
                case CellValue.Required:
                    req = DocExchangeRequirementEnum.Mandatory;
                    break;

                case CellValue.Optional:
                    req = DocExchangeRequirementEnum.Optional;
                    break;
            }
            docUsage.RegisterExchange(docExchange, req);
        }

    }

    /// <summary>
    /// Shows concepts for each row, exchanges for each column
    /// </summary>
    public class CheckGridEntity : ICheckGrid
    {
        DocConceptRoot m_root;
        DocModelView m_view;
        DocProject m_project;
        List<DocTemplateDefinition> m_listTemplate;

        public CheckGridEntity(DocConceptRoot docRoot, DocModelView docView, DocProject docProject, Dictionary<string, DocObject> map)
        {
            this.m_root = docRoot;
            this.m_view = docView;
            this.m_project = docProject;
            this.m_listTemplate = new List<DocTemplateDefinition>();
            
            List<DocTemplateDefinition> listTemplate = docProject.GetTemplateList();

            //... filter out templates to only those that apply to entity...

            foreach (DocTemplateDefinition docTemplate in listTemplate)
            {
                if (docTemplate.Rules != null && docTemplate.Rules.Count > 0) // don't include abstract/organizational templates
                {
                    bool include = false;

                    // check for inheritance                
                    DocObject docApplicableEntity = null;
                    if (docTemplate.Type != null && map.TryGetValue(docTemplate.Type, out docApplicableEntity) && docApplicableEntity is DocEntity)
                    {
                        // check for inheritance
                        DocEntity docBase = docRoot.ApplicableEntity;
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
                        this.m_listTemplate.Add(docTemplate);
                    }
                }
            }

        }

        public int GetColumnCount()
        {
            return this.m_view.Exchanges.Count;
        }

        public int GetRowCount()
        {
            return this.m_listTemplate.Count;
        }

        public object GetColumn(int col)
        {
            if (col >= 0 && col < this.m_view.Exchanges.Count)
            {
                return this.m_view.Exchanges[col];
            }

            return null;
        }

        public object GetRow(int row)
        {
            if (row >= 0 && row < this.m_listTemplate.Count)
            {
                return this.m_listTemplate[row];
            }

            return null;
        }

        public CellValue GetCell(int row, int col)
        {
            if (row < 0 || row >= this.m_listTemplate.Count)
                return CellValue.Unavailable;

            if (col < 0 || col >= this.m_view.Exchanges.Count)
                return CellValue.Unavailable;

            DocTemplateDefinition docTemplate = this.m_listTemplate[row];
            DocExchangeDefinition docExchange = this.m_view.Exchanges[col];

            foreach (DocTemplateUsage docUsage in this.m_root.Concepts)
            {
                if (docUsage.Definition == docTemplate)
                {
                    foreach (DocExchangeItem docItem in docUsage.Exchanges)
                    {
                        if (docItem.Exchange == docExchange && docItem.Applicability == DocExchangeApplicabilityEnum.Export)
                        {
                            switch (docItem.Requirement)
                            {
                                case DocExchangeRequirementEnum.Mandatory:
                                    return CellValue.Required;

                                case DocExchangeRequirementEnum.Optional:
                                    return CellValue.Optional;

                                default:
                                    return CellValue.None;
                            }
                        }
                    }
                }
            }

            return CellValue.None;
        }

        public void SetCell(int row, int col, CellValue val)
        {
            DocTemplateDefinition docTemplate = this.m_listTemplate[row];
            DocExchangeDefinition docExchange = this.m_view.Exchanges[col];

            DocTemplateUsage docUsage = null;
            foreach (DocTemplateUsage eachUsage in this.m_root.Concepts)
            {
                if (eachUsage.Definition == docTemplate)
                {
                    docUsage = eachUsage;
                    break;
                }
            }

            if (docUsage == null)
            {
                docUsage = new DocTemplateUsage();
                this.m_root.Concepts.Add(docUsage);
                docUsage.Definition = docTemplate;
            }

            DocExchangeRequirementEnum req = DocExchangeRequirementEnum.NotRelevant;
            switch (val)
            {
                case CellValue.Required:
                    req = DocExchangeRequirementEnum.Mandatory;
                    break;

                case CellValue.Optional:
                    req = DocExchangeRequirementEnum.Optional;
                    break;
            }
            docUsage.RegisterExchange(docExchange, req);
        }
    }

    /// <summary>
    /// Shows entities for each row, concepts for each column
    /// </summary>
    public class CheckGridExchange : ICheckGrid
    {
        DocProject m_project;
        DocModelView m_view;
        DocExchangeDefinition m_exchange;

        List<DocTemplateDefinition> m_listTemplate;

        public CheckGridExchange(DocExchangeDefinition docExchange, DocModelView docView, DocProject docProject)
        {
            this.m_project = docProject;
            this.m_view = docView;
            this.m_exchange = docExchange;
            this.m_listTemplate = docProject.GetTemplateList();

            // filter out template list to only those that are currently used
            for (int i = this.m_listTemplate.Count - 1; i >= 0; i--)
            {
                bool used = false;
                foreach (DocConceptRoot docRoot in this.m_view.ConceptRoots)
                {
                    foreach (DocTemplateUsage docUsage in docRoot.Concepts)
                    {
                        if (docUsage.Definition == this.m_listTemplate[i])
                        {
                            used = true;
                            break;
                        }
                    }
                }

                if (!used)
                {
                    this.m_listTemplate.RemoveAt(i);
                }
            }
        }

        public int GetColumnCount()
        {
            return this.m_listTemplate.Count;
        }

        public int GetRowCount()
        {
            return this.m_view.ConceptRoots.Count;
        }

        public object GetColumn(int col)
        {
            if (col >= 0 && col < this.m_listTemplate.Count)
            {
                return this.m_listTemplate[col];
            }

            return null;
        }

        public object GetRow(int row)
        {
            if (row >= 0 && row < this.m_view.ConceptRoots.Count)
            {
                return this.m_view.ConceptRoots[row];
            }

            return null;
        }

        public CellValue GetCell(int row, int col)
        {
            if (col >= this.m_listTemplate.Count || row >= this.m_view.ConceptRoots.Count)
                return CellValue.Unavailable;

            DocTemplateDefinition docTemplate = this.m_listTemplate[col];
            DocConceptRoot docRoot = this.m_view.ConceptRoots[row];

            // return Unavailable if template is incompatible with root
            //...docRoot.ApplicableEntity.

            foreach (DocTemplateUsage docUsage in docRoot.Concepts)
            {
                if (docUsage.Definition == docTemplate)
                {
                    foreach (DocExchangeItem docExchangeItem in docUsage.Exchanges)
                    {
                        if (docExchangeItem.Exchange == this.m_exchange && docExchangeItem.Applicability == DocExchangeApplicabilityEnum.Export)
                        {
                            switch (docExchangeItem.Requirement)
                            {
                                case DocExchangeRequirementEnum.Mandatory:
                                    return CellValue.Required;

                                case DocExchangeRequirementEnum.Optional:
                                    return CellValue.Optional;
                            }
                        }
                    }
                }
            }

            return CellValue.None;
        }

        public void SetCell(int row, int col, CellValue val)
        {
            DocTemplateDefinition docTemplate = this.m_listTemplate[col];
            DocConceptRoot docRoot = this.m_view.ConceptRoots[row];

            DocTemplateUsage docConcept = null;
            foreach (DocTemplateUsage docUsage in docRoot.Concepts)
            {
                if (docUsage.Definition == docTemplate)
                {
                    docConcept = docUsage;
                    break;
                }
            }

            if (docConcept == null)
            {
                docConcept = new DocTemplateUsage();
                docRoot.Concepts.Add(docConcept);
                docConcept.Definition = docTemplate;
            }

            DocExchangeRequirementEnum req = DocExchangeRequirementEnum.NotRelevant;
            switch (val)
            {
                case CellValue.Required:
                    req = DocExchangeRequirementEnum.Mandatory;
                    break;

                case CellValue.Optional:
                    req = DocExchangeRequirementEnum.Optional;
                    break;
            }
            docConcept.RegisterExchange(this.m_exchange, req);
        }
    }
}

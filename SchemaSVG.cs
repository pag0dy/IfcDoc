// Name:        SchemaSVG.cs
// Description: Structured Vector Graphics (SVG) 1.1 schema (abbreviated)
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2017 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using IfcDoc.Schema.DOC;
using IfcDoc.Format.XML;

namespace IfcDoc.Schema.SVG
{
    // This is used to serialize schema diagrams
    // While UML-specific formats exist, they are not widely supported (i.e. only specialist tools, not mainstream tools)
    // SVG is chosen because it is supported by all major browsers (Chrome, iOS, Edge), is well structured for version comparison (e.g. Github), and simple to understand
    // Mappings to schema elements are based on groups (g) using ids for entity names and attribute names

    public class SchemaSVG : IDisposable
    {
        string m_filename;
        DocSchema m_schema;
        DocProject m_project;

        public SchemaSVG(string filename, DocSchema docSchema, DocProject docProject)
        {
            this.m_filename = filename;
            this.m_schema = docSchema;
            this.m_project = docProject;
        }

        private DocRectangle LoadRectangle(g group)
        {
            DocRectangle docRectangle = null;
            if (group.rect != null && group.rect.Count == 1)
            {
                rect r = group.rect[0];

                docRectangle = new DocRectangle();
                docRectangle.X = Double.Parse(r.x) / CtlExpressG.Factor;
                docRectangle.Y = Double.Parse(r.y) / CtlExpressG.Factor;
                docRectangle.Width = Double.Parse(r.width) / CtlExpressG.Factor;
                docRectangle.Height = Double.Parse(r.height) / CtlExpressG.Factor;
            }

            return docRectangle;
        }

        private void LoadLine(g group, List<DocPoint> listPoints)
        {
            if (group.polyline.Count == 1)
            {
                LoadPoints(group.polyline[0], listPoints);
            }
        }

        private void LoadPoints(polyline p, List<DocPoint> listPoints)
        {
            if (p.points == null)
                return;

            string[] points = p.points.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string point in points)
            {
                string[] coords = point.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                DocPoint docPoint = new DocPoint();
                docPoint.X = Double.Parse(coords[0]) / CtlExpressG.Factor;
                docPoint.Y = Double.Parse(coords[1]) / CtlExpressG.Factor;
                listPoints.Add(docPoint);
            }
        }

        private void LoadTree(g group, List<DocLine> listLines)
        {
            DocLine docLast = null;
            foreach (polyline p in group.polyline)
            {
                DocLine docLine = new DocLine();
                LoadPoints(p, docLine.DiagramLine);

                if (docLast != null && docLine.DiagramLine.Count > 1 && docLine.DiagramLine[0].Equals(docLast.DiagramLine[docLast.DiagramLine.Count - 1]))
                {
                    // hierarchy
                    docLast.Tree.Add(docLine);
                }
                else
                {
                    listLines.Add(docLine);
                }

                if(docLast == null && docLine.DiagramLine.Count > 1)
                {
                    docLast = docLine;
                }
            }
        }

        public void Load()
        {
            svg s = null;
            using (FormatXML format = new FormatXML(this.m_filename, typeof(svg), "http://www.w3.org/2000/svg"))
            {
                format.Load();
                s = format.Instance as svg;
            }

            if (s == null)
                return;

            // apply diagram to existing schema elements
            foreach(g group in s.g)
            {
                // primitive
                DocDefinition docDef = null;
                switch (group.id)
                {
                    case "INTEGER":
                    case "REAL":
                    case "BOOLEAN":
                    case "LOGICAL":
                    case "STRING":
                    case "BINARY":
                        docDef = new DocPrimitive();
                        docDef.Name = group.id;
                        m_schema.Primitives.Add((DocPrimitive)docDef);
                        break;

                    default:
                        docDef = this.m_schema.GetDefinition(group.id);
                        break;
                }
                
                if (docDef != null)
                {
                    docDef.DiagramRectangle = LoadRectangle(group);

                    // attributes, supertype...
                    if (docDef is DocEntity)
                    {
                        DocEntity docEnt = (DocEntity)docDef;
                        LoadTree(group, docEnt.Tree);

                        foreach (g subgroup in group.groups)
                        {
                            foreach(DocAttribute docAttr in docEnt.Attributes)
                            {
                                if(docAttr.Name.Equals(subgroup.id))
                                {
                                    LoadLine(subgroup, docAttr.DiagramLine);

                                    if (subgroup.text.Count == 1)
                                    {
                                        double ax = Double.Parse(subgroup.text[0].x) / CtlExpressG.Factor;
                                        double ay = Double.Parse(subgroup.text[0].y) / CtlExpressG.Factor;

                                        docAttr.DiagramLabel = new DocRectangle();
                                        docAttr.DiagramLabel.X = ax;
                                        docAttr.DiagramLabel.Y = ay;
                                    }

                                    break;
                                }
                            }
                        }

                        // base type???
                    }
                    else if(docDef is DocDefined)
                    {
                        DocDefined docDefined = (DocDefined)docDef;
                        LoadLine(group, docDefined.DiagramLine);
                    }
                    else if(docDef is DocSelect)
                    {
                        DocSelect docSelect = (DocSelect)docDef;
                        LoadTree(group, docSelect.Tree);
                    }
                }
                else
                {
                    // schema ref
                    DocSchema docTargetSchema = this.m_project.GetSchema(group.id);
                    if (docTargetSchema != null)
                    {
                        DocSchemaRef docSchemaRef = new DocSchemaRef();
                        docSchemaRef.Name = group.id;
                        this.m_schema.SchemaRefs.Add(docSchemaRef);

                        foreach (g subgroup in group.groups)
                        {
                            DocDefinition docTargetDef = docTargetSchema.GetDefinition(subgroup.id);
                            if(docTargetDef != null)
                            {
                                DocDefinitionRef docDefRef = new DocDefinitionRef();
                                docDefRef.Name = subgroup.id;
                                docSchemaRef.Definitions.Add(docDefRef);
                                docDefRef.DiagramRectangle = LoadRectangle(subgroup);

                                LoadTree(subgroup, docDefRef.Tree);
                            }
                        }
                    }
                    else
                    {
                        // primitive?
                                       
                        // page targets
                        DocPageTarget docPageTarget = new DocPageTarget();
                        docPageTarget.Name = group.id;
                        this.m_schema.PageTargets.Add(docPageTarget);
                        docPageTarget.DiagramRectangle = LoadRectangle(group);
                        //...docPageTarget.Definition =
                        LoadLine(group, docPageTarget.DiagramLine);

                        foreach (g subgroup in group.groups)
                        {
                            DocPageSource docPageSource = new DocPageSource();
                            docPageSource.Name = subgroup.id;
                            docPageTarget.Sources.Add(docPageSource);
                            docPageSource.DiagramRectangle = LoadRectangle(subgroup);

                        }
                    }
                }
            }
        }

        private g SaveDefinition(DocObject docObj, string displayname)
        {
            g group = new g();
            group.id = docObj.Name;

            DocDefinition docDef = docObj as DocDefinition;
            if (docDef == null || docDef.DiagramRectangle == null)
                return group;

            double x = docDef.DiagramRectangle.X * CtlExpressG.Factor;
            double y = docDef.DiagramRectangle.Y * CtlExpressG.Factor;
            double cx = docDef.DiagramRectangle.Width * CtlExpressG.Factor;
            double cy = docDef.DiagramRectangle.Height * CtlExpressG.Factor;
            
            rect r = new rect();
            r.x = x.ToString();
            r.y = y.ToString();
            r.width = cx.ToString();
            r.height = cy.ToString();
            r.stroke = "black";
            group.rect.Add(r);

            text t = new text();
            t.x = (x + cx * 0.5).ToString();
            t.y = (y + cy * 0.5).ToString();
            t.fill = "black";
            t.alignment_baseline = "middle";
            t.text_anchor = "middle";
            t.font_size = "10";
            t.font_family = "Arial, Helvetica, sans-serif";
            if (displayname != null)
            {
                t.value = displayname;
            }
            else
            {
                t.value = docDef.Name;
            }
            group.text.Add(t);

            if (docDef is DocEntity)
            {
                group.fill = "yellow";
            }
            else if (docDef is DocType)
            {
                group.fill = "green";
            }
            else if (docDef is DocPageTarget)
            {
                group.fill = "blue";
                r.rx = "10";
                r.ry = "10";
            }
            else if (docDef is DocPageSource)
            {
                group.fill = "silver";
                r.rx = "10";
                r.ry = "10";
            }
            else
            {
                group.fill = "grey";
            }

            return group;
        }

        private void SaveTree(g group, List<DocLine> tree, DocPoint prev, bool bold)
        {
            foreach(DocLine docLine in tree)
            {
                SaveLine(group, docLine.DiagramLine, prev, bold);

                DocPoint next = null;
                if (docLine.DiagramLine != null && docLine.DiagramLine.Count > 0)
                {
                    next = docLine.DiagramLine[docLine.DiagramLine.Count-1];
                }

                SaveTree(group, docLine.Tree, next, bold);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        /// <param name="line"></param>
        /// <param name="prev"></param>
        /// <param name="bold">True for bold; False for regular; null for dash</param>
        private void SaveLine(g group, List<DocPoint> line, DocPoint prev, bool? bold)
        {
            polyline p = new polyline();
            group.polyline.Add(p);

            StringBuilder sb = new StringBuilder();
            if(prev != null)
            {
                sb.Append(prev.X * CtlExpressG.Factor);
                sb.Append(",");
                sb.Append(prev.Y * CtlExpressG.Factor);
                sb.Append(" ");
            }

            foreach (DocPoint docLine in line)
            {
                sb.Append(docLine.X * CtlExpressG.Factor);
                sb.Append(",");
                sb.Append(docLine.Y * CtlExpressG.Factor);
                sb.Append(" ");
            }
            p.points = sb.ToString();
            p.stroke = "black";
            p.fill = "none";

            if (bold == true)
            {
                p.stroke_width = "3";
            }
            else if(bold == null)
            {
                p.stroke_dasharray = "1,1";
            }
        }

        public void Save()
        {
            svg s = new svg();            
            s.version = "1.1";
            s.width = (this.m_schema.DiagramPagesHorz * CtlExpressG.PageX).ToString();
            s.height = (this.m_schema.DiagramPagesVert * CtlExpressG.PageY).ToString();

            foreach (DocEntity docEnt in this.m_schema.Entities)
            {
                g group = SaveDefinition(docEnt, null);
                s.g.Add(group);
                if (group != null)
                {
                    SaveTree(group, docEnt.Tree, null, true);

                    foreach (DocAttribute docAttr in docEnt.Attributes)
                    {
                        if (docAttr.DiagramLine != null && docAttr.DiagramLine.Count >= 2)
                        {
                            g attr = new g();
                            group.groups.Add(attr);
                            attr.id = docAttr.Name;

                            bool? linestyle = false;
                            if(docAttr.IsOptional)
                            {
                                linestyle = null;
                            }
                            SaveLine(attr, docAttr.DiagramLine, null, linestyle);

                            // calculate midpoint of line
                            double mx = (docAttr.DiagramLine[0].X + docAttr.DiagramLine[docAttr.DiagramLine.Count - 1].X) * 0.5;
                            double my = (docAttr.DiagramLine[0].Y + docAttr.DiagramLine[docAttr.DiagramLine.Count - 1].Y) * 0.5;

                            // vex files define relative position
                            double rx = docAttr.DiagramLabel.X - docAttr.DiagramLine[0].X;
                            double ry = docAttr.DiagramLabel.Y - docAttr.DiagramLine[0].Y;

                            // calculate absolute position
                            double ax = mx + rx;
                            double ay = my + ry;

                            text t = new text();
                            attr.text.Add(t);
                            t.value = (docAttr.Name + " " + docAttr.GetAggregationExpression()).Trim();
                            t.fill = "black";
                            t.x = (ax * CtlExpressG.Factor).ToString();
                            t.y = (ay * CtlExpressG.Factor).ToString();
                            t.alignment_baseline = "middle";
                            t.text_anchor = "middle";
                            t.font_size = "10";
                            t.font_family = "Arial, Helvetica, sans-serif";
                        }
                    }
                }
            }

            foreach (DocType docEnt in this.m_schema.Types)
            {
                g group = SaveDefinition(docEnt, null);
                s.g.Add(group);
                if (docEnt is DocSelect)
                {
                    DocSelect docSelect = (DocSelect)docEnt;
                    SaveTree(group, docSelect.Tree, null, false);
                }
            }

            foreach (DocPrimitive docEnt in this.m_schema.Primitives)
            {
                g group = SaveDefinition(docEnt, null);
                s.g.Add(group);
            }

            foreach (DocSchemaRef docRef in this.m_schema.SchemaRefs)
            {
                g r = SaveDefinition(docRef, null);
                s.g.Add(r);
                foreach (DocDefinitionRef docDef in docRef.Definitions)
                {
                    g group = SaveDefinition(docDef, docRef.Name + "\r\n" + docDef.Name);
                    r.groups.Add(group);

                    SaveTree(group, docDef.Tree, null, true);
                }
            }

            foreach (DocPageTarget docTarget in this.m_schema.PageTargets)
            {
                g target = SaveDefinition(docTarget, null);
                s.g.Add(target);

                SaveLine(target, docTarget.DiagramLine, null, false);

                foreach (DocPageSource docSource in docTarget.Sources)
                {
                    g source = SaveDefinition(docSource, null);
                    target.groups.Add(source);
                }
            }

            g grid = new g();
            s.g.Add(grid);
            for (int iPageY = 0; iPageY < m_schema.DiagramPagesVert; iPageY++)
            {
                for (int iPageX = 0; iPageX < m_schema.DiagramPagesHorz; iPageX++)
                {
                    rect r = new rect();
                    r.x = (iPageX * CtlExpressG.PageX).ToString();
                    r.y = (iPageY * CtlExpressG.PageY).ToString();
                    r.width = CtlExpressG.PageX.ToString();
                    r.height = CtlExpressG.PageY.ToString();
                    r.fill = "none";
                    r.stroke = "lime";
                    grid.rect.Add(r);
                }
            }

            using (FormatXML format = new FormatXML(this.m_filename, typeof(svg), "http://www.w3.org/2000/svg"))
            {
                format.Instance = s;
                format.Save();
            }
        }

        public void Dispose()
        {         
        }
    }


    public class svg
    {
        [XmlAttribute]
        public string version;

        [XmlAttribute]
        public string width;
        
        [XmlAttribute]
        public string height;

        [XmlElement(typeof(g))]
        public List<g> g = new List<g>();
    }

    public class g
    {
        [XmlAttribute]
        public string id;

        [XmlAttribute]
        public string fill;

        [XmlElement(typeof(rect))]
        public List<rect> rect = new List<rect>();

        [XmlElement(typeof(polyline))]
        public List<polyline> polyline = new List<polyline>();

        [XmlElement(typeof(text))]
        public List<text> text = new List<text>();

        [XmlElement("g", typeof(g))]
        public List<g> groups = new List<g>();
    }

    public class rect
    {
        [XmlAttribute]
        public string x;
        
        [XmlAttribute]
        public string y;
        
        [XmlAttribute]
        public string width;
        
        [XmlAttribute]
        public string height;

        [XmlAttribute]
        public string rx;

        [XmlAttribute]
        public string ry;

        [XmlAttribute]
        public string fill;

        [XmlAttribute]
        public string stroke;
    }

    public class polyline
    {
        [XmlAttribute]
        public string points;

        [XmlAttribute]
        public string fill;

        [XmlAttribute]
        public string stroke;

        [XmlAttribute("stroke-width")]
        public string stroke_width;

        [XmlAttribute("stroke-dasharray")]
        public string stroke_dasharray;
    }

    public class text
    {
        [XmlAttribute]
        public string x;

        [XmlAttribute]
        public string y;

        [XmlAttribute]
        public string fill;

        [XmlAttribute("font-family")]
        public string font_family;

        [XmlAttribute("font-size")]
        public string font_size;

        [XmlAttribute("alignment-baseline")]
        public string alignment_baseline;

        [XmlAttribute("text-anchor")]
        public string text_anchor;

        [XmlText]
        public string value;
    }
}

// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	public partial class IfcEdgeCurve : IfcEdge,
		BuildingSmart.IFC.IfcGeometricConstraintResource.IfcCurveOrEdgeCurve
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The curve which defines the shape and spatial location of the edge. This curve may be unbounded and is implicitly trimmed by the vertices of the edge; this defines the edge domain. Multiple edges can reference the same curve.")]
		[Required()]
		public IfcCurve EdgeGeometry { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("This logical flag indicates whether (TRUE), or not (FALSE) the senses of the edge and the curve defining the edge geometry are the same. The sense of an edge is from the edge start vertex to the edge end vertex; the sense of a curve is in the direction of increasing parameter. ")]
		[Required()]
		public IfcBoolean SameSense { get; set; }
	
	
		public IfcEdgeCurve(IfcVertex __EdgeStart, IfcVertex __EdgeEnd, IfcCurve __EdgeGeometry, IfcBoolean __SameSense)
			: base(__EdgeStart, __EdgeEnd)
		{
			this.EdgeGeometry = __EdgeGeometry;
			this.SameSense = __SameSense;
		}
	
	
	}
	
}

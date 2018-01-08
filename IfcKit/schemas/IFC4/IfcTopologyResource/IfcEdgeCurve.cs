// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("86ef7edf-f099-47aa-977b-0bc982b8db88")]
	public partial class IfcEdgeCurve : IfcEdge,
		BuildingSmart.IFC.IfcGeometricConstraintResource.IfcCurveOrEdgeCurve
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcCurve")]
		[Required()]
		IfcCurve _EdgeGeometry;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _SameSense;
	
	
		[Description("The curve which defines the shape and spatial location of the edge. This curve ma" +
	    "y be unbounded and is implicitly trimmed by the vertices of the edge; this defin" +
	    "es the edge domain. Multiple edges can reference the same curve.")]
		public IfcCurve EdgeGeometry { get { return this._EdgeGeometry; } set { this._EdgeGeometry = value;} }
	
		[Description(@"This logical flag indicates whether (TRUE), or not (FALSE) the senses of the edge and the curve defining the edge geometry are the same. The sense of an edge is from the edge start vertex to the edge end vertex; the sense of a curve is in the direction of increasing parameter. ")]
		public IfcBoolean SameSense { get { return this._SameSense; } set { this._SameSense = value;} }
	
	
	}
	
}

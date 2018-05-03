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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcCompositeCurve : IfcBoundedCurve
	{
		[DataMember(Order = 0)] 
		[Description("The component bounded curves, their transitions and senses. The transition attribute for the last segment defines the transition between the end of the last segment and the start of the first; this transition attribute may take the value discontinuous, which indicates an open curve. ")]
		[Required()]
		[MinLength(1)]
		public IList<IfcCompositeCurveSegment> Segments { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Indication of whether the curve intersects itself or not; this is for information only.  ")]
		[Required()]
		public IfcLogical SelfIntersect { get; set; }
	
	
		public IfcCompositeCurve(IfcCompositeCurveSegment[] __Segments, IfcLogical __SelfIntersect)
		{
			this.Segments = new List<IfcCompositeCurveSegment>(__Segments);
			this.SelfIntersect = __SelfIntersect;
		}
	
		public new IfcInteger NSegments { get { return new IfcInteger(); } }
	
		public new IfcLogical ClosedCurve { get { return new IfcLogical(); } }
	
	
	}
	
}

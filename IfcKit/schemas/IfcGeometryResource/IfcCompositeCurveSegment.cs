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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcCompositeCurveSegment : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The state of transition (i.e., geometric continuity from the last point of this segment to the first point of the next segment) in a composite curve.")]
		[Required()]
		public IfcTransitionCode Transition { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("An indicator of whether or not the sense of the segment agrees with, or opposes, that of the parent curve. If <em>SameSense</em> is false, the point with highest parameter value is taken as the first point of the segment.  <blockquote class=\"note\">NOTE&nbsp; If the datatype of <em>ParentCurve</em> is <em>IfcTrimmedCurve</em>, the value of <em>SameSense</em> overrides the value of <em>IfcTrimmedCurve.SenseAgreement</em></blockquote>")]
		[Required()]
		public IfcBoolean SameSense { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("The bounded curve which defines the geometry of the segment.")]
		[Required()]
		public IfcCurve ParentCurve { get; set; }
	
		[InverseProperty("Segments")] 
		[Description("The set of composite curves which use this composite curve segment as a segment. This set shall not be empty. ")]
		[MinLength(1)]
		public ISet<IfcCompositeCurve> UsingCurves { get; protected set; }
	
	
		public IfcCompositeCurveSegment(IfcTransitionCode __Transition, IfcBoolean __SameSense, IfcCurve __ParentCurve)
		{
			this.Transition = __Transition;
			this.SameSense = __SameSense;
			this.ParentCurve = __ParentCurve;
			this.UsingCurves = new HashSet<IfcCompositeCurve>();
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}

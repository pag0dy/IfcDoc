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

using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("fd79e3b5-9d55-4a57-ba6b-1fca7392b523")]
	public partial class IfcCompositeCurveSegment : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTransitionCode _Transition;
	
		[DataMember(Order=1)] 
		[Required()]
		Boolean _SameSense;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcCurve _ParentCurve;
	
		[InverseProperty("Segments")] 
		[MinLength(1)]
		ISet<IfcCompositeCurve> _UsingCurves = new HashSet<IfcCompositeCurve>();
	
	
		public IfcCompositeCurveSegment()
		{
		}
	
		public IfcCompositeCurveSegment(IfcTransitionCode __Transition, Boolean __SameSense, IfcCurve __ParentCurve)
		{
			this._Transition = __Transition;
			this._SameSense = __SameSense;
			this._ParentCurve = __ParentCurve;
		}
	
		[Description("The state of transition (i.e., geometric continuity from the last point of this s" +
	    "egment to the first point of the next segment) in a composite curve.")]
		public IfcTransitionCode Transition { get { return this._Transition; } set { this._Transition = value;} }
	
		[Description("An indicator of whether or not the sense of the segment agrees with, or opposes, " +
	    "that of the parent curve. If SameSense is false, the point with highest paramete" +
	    "r value is taken as the first point of the segment.")]
		public Boolean SameSense { get { return this._SameSense; } set { this._SameSense = value;} }
	
		[Description("The bounded curve which defines the geometry of the segment.")]
		public IfcCurve ParentCurve { get { return this._ParentCurve; } set { this._ParentCurve = value;} }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
		[Description("The set of composite curves which use this composite curve segment as a segment. " +
	    "This set shall not be empty. ")]
		public ISet<IfcCompositeCurve> UsingCurves { get { return this._UsingCurves; } }
	
	
	}
	
}

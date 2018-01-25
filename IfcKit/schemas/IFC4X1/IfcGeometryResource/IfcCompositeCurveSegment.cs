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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("baf231ed-97be-4368-a9f9-10ae70bad78e")]
	public partial class IfcCompositeCurveSegment : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTransitionCode _Transition;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _SameSense;
	
		[DataMember(Order=2)] 
		[XmlElement]
		[Required()]
		IfcCurve _ParentCurve;
	
		[InverseProperty("Segments")] 
		ISet<IfcCompositeCurve> _UsingCurves = new HashSet<IfcCompositeCurve>();
	
	
		[Description("The state of transition (i.e., geometric continuity from the last point of this s" +
	    "egment to the first point of the next segment) in a composite curve.")]
		public IfcTransitionCode Transition { get { return this._Transition; } set { this._Transition = value;} }
	
		[Description(@"An indicator of whether or not the sense of the segment agrees with, or opposes, that of the parent curve. If <em>SameSense</em> is false, the point with highest parameter value is taken as the first point of the segment.
	<blockquote class=""note"">NOTE&nbsp; If the datatype of <em>ParentCurve</em> is <em>IfcTrimmedCurve</em>, the value of <em>SameSense</em> overrides the value of <em>IfcTrimmedCurve.SenseAgreement</em></blockquote>")]
		public IfcBoolean SameSense { get { return this._SameSense; } set { this._SameSense = value;} }
	
		[Description("The bounded curve which defines the geometry of the segment.")]
		public IfcCurve ParentCurve { get { return this._ParentCurve; } set { this._ParentCurve = value;} }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
		[Description("The set of composite curves which use this composite curve segment as a segment. " +
	    "This set shall not be empty. ")]
		public ISet<IfcCompositeCurve> UsingCurves { get { return this._UsingCurves; } }
	
	
	}
	
}

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
	[Guid("7477f705-8ade-4050-a55f-60869e05b1f6")]
	public partial class IfcCompositeCurve : IfcBoundedCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcCompositeCurveSegment> _Segments = new List<IfcCompositeCurveSegment>();
	
		[DataMember(Order=1)] 
		[Required()]
		Boolean? _SelfIntersect;
	
	
		[Description(@"The component bounded curves, their transitions and senses. The transition attribute for the last segment defines the transition between the end of the last segment and the start of the first; this transition attribute may take the value discontinuous, which indicates an open curve. ")]
		public IList<IfcCompositeCurveSegment> Segments { get { return this._Segments; } }
	
		[Description("Indication of whether the curve intersects itself or not; this is for information" +
	    " only.\r\n")]
		public Boolean? SelfIntersect { get { return this._SelfIntersect; } set { this._SelfIntersect = value;} }
	
		public new Int64 NSegments { get { return null; } }
	
		public new Boolean? ClosedCurve { get { return null; } }
	
	
	}
	
}

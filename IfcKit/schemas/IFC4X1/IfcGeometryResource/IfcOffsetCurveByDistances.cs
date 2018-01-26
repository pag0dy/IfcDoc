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

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("07856aa9-1860-435f-891b-597e053894a9")]
	public partial class IfcOffsetCurveByDistances : IfcOffsetCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcDistanceExpression> _OffsetValues = new List<IfcDistanceExpression>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Tag;
	
	
		public IfcOffsetCurveByDistances()
		{
		}
	
		public IfcOffsetCurveByDistances(IfcCurve __BasisCurve, IfcDistanceExpression[] __OffsetValues, IfcLabel? __Tag)
			: base(__BasisCurve)
		{
			this._OffsetValues = new List<IfcDistanceExpression>(__OffsetValues);
			this._Tag = __Tag;
		}
	
		[Description(@"List of sequential points described relative to the basis curve. If the offsets do not span the full extent of the basis curve (e.g. if the list contains only one item), then the lateral and vertical offsets implicitly continue with the same value towards the head and tail of the basis curve.")]
		public IList<IfcDistanceExpression> OffsetValues { get { return this._OffsetValues; } }
	
		[Description("Optional identifier of the curve, which may be used to correlate points from a va" +
	    "riable cross-section.")]
		public IfcLabel? Tag { get { return this._Tag; } set { this._Tag = value;} }
	
	
	}
	
}

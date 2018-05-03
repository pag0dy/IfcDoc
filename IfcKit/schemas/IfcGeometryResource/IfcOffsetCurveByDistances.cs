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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcOffsetCurveByDistances : IfcOffsetCurve
	{
		[DataMember(Order = 0)] 
		[Description("List of sequential points described relative to the basis curve. If the offsets do not span the full extent of the basis curve (e.g. if the list contains only one item), then the lateral and vertical offsets implicitly continue with the same value towards the head and tail of the basis curve.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcDistanceExpression> OffsetValues { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Optional identifier of the curve, which may be used to correlate points from a variable cross-section.")]
		public IfcLabel? Tag { get; set; }
	
	
		public IfcOffsetCurveByDistances(IfcCurve __BasisCurve, IfcDistanceExpression[] __OffsetValues, IfcLabel? __Tag)
			: base(__BasisCurve)
		{
			this.OffsetValues = new List<IfcDistanceExpression>(__OffsetValues);
			this.Tag = __Tag;
		}
	
	
	}
	
}

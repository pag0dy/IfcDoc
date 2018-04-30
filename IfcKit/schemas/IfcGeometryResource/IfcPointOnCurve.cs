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
	public partial class IfcPointOnCurve : IfcPoint
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The curve to which point parameter relates.")]
		[Required()]
		public IfcCurve BasisCurve { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The parameter value of the point location.")]
		[Required()]
		public IfcParameterValue PointParameter { get; set; }
	
	
		public IfcPointOnCurve(IfcCurve __BasisCurve, IfcParameterValue __PointParameter)
		{
			this.BasisCurve = __BasisCurve;
			this.PointParameter = __PointParameter;
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}

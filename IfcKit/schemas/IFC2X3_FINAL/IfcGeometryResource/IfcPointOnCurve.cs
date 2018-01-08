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
	[Guid("8c942909-8088-42fa-956a-46307b18a3c2")]
	public partial class IfcPointOnCurve : IfcPoint
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurve _BasisCurve;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcParameterValue _PointParameter;
	
	
		[Description("The curve to which point parameter relates.")]
		public IfcCurve BasisCurve { get { return this._BasisCurve; } set { this._BasisCurve = value;} }
	
		[Description("The parameter value of the point location.")]
		public IfcParameterValue PointParameter { get { return this._PointParameter; } set { this._PointParameter = value;} }
	
	
	}
	
}

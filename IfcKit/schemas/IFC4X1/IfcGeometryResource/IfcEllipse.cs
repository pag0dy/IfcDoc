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
	[Guid("9f128686-ff25-4c00-9bcc-4b9cc58c4598")]
	public partial class IfcEllipse : IfcConic
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _SemiAxis1;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _SemiAxis2;
	
	
		[Description("The first radius of the ellipse which shall be positive. Placement.Axes[1] gives " +
	    "the direction of the SemiAxis1.")]
		public IfcPositiveLengthMeasure SemiAxis1 { get { return this._SemiAxis1; } set { this._SemiAxis1 = value;} }
	
		[Description("The second radius of the ellipse which shall be positive.")]
		public IfcPositiveLengthMeasure SemiAxis2 { get { return this._SemiAxis2; } set { this._SemiAxis2 = value;} }
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcOrientationExpression : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("Direction of the lateral axis.")]
		[Required()]
		public IfcDirection LateralAxisDirection { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Direction of the vertical axis.")]
		[Required()]
		public IfcDirection VerticalAxisDirection { get; set; }
	
	
		public IfcOrientationExpression(IfcDirection __LateralAxisDirection, IfcDirection __VerticalAxisDirection)
		{
			this.LateralAxisDirection = __LateralAxisDirection;
			this.VerticalAxisDirection = __VerticalAxisDirection;
		}
	
	
	}
	
}

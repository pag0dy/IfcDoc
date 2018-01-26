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
	[Guid("53f5e420-381a-4ce4-9928-f7997e363b23")]
	public partial class IfcOrientationExpression : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDirection _LateralAxisDirection;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcDirection _VerticalAxisDirection;
	
	
		public IfcOrientationExpression()
		{
		}
	
		public IfcOrientationExpression(IfcDirection __LateralAxisDirection, IfcDirection __VerticalAxisDirection)
		{
			this._LateralAxisDirection = __LateralAxisDirection;
			this._VerticalAxisDirection = __VerticalAxisDirection;
		}
	
		[Description("Direction of the lateral axis.")]
		public IfcDirection LateralAxisDirection { get { return this._LateralAxisDirection; } set { this._LateralAxisDirection = value;} }
	
		[Description("Direction of the vertical axis.")]
		public IfcDirection VerticalAxisDirection { get { return this._VerticalAxisDirection; } set { this._VerticalAxisDirection = value;} }
	
	
	}
	
}

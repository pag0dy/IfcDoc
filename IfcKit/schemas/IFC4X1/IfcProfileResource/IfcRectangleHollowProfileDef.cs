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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("19db74b8-9bbd-4310-a2b8-d47984481a40")]
	public partial class IfcRectangleHollowProfileDef : IfcRectangleProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _WallThickness;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _InnerFilletRadius;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _OuterFilletRadius;
	
	
		public IfcRectangleHollowProfileDef()
		{
		}
	
		public IfcRectangleHollowProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __XDim, IfcPositiveLengthMeasure __YDim, IfcPositiveLengthMeasure __WallThickness, IfcNonNegativeLengthMeasure? __InnerFilletRadius, IfcNonNegativeLengthMeasure? __OuterFilletRadius)
			: base(__ProfileType, __ProfileName, __Position, __XDim, __YDim)
		{
			this._WallThickness = __WallThickness;
			this._InnerFilletRadius = __InnerFilletRadius;
			this._OuterFilletRadius = __OuterFilletRadius;
		}
	
		[Description("Thickness of the material.")]
		public IfcPositiveLengthMeasure WallThickness { get { return this._WallThickness; } set { this._WallThickness = value;} }
	
		[Description("Inner corner radius.")]
		public IfcNonNegativeLengthMeasure? InnerFilletRadius { get { return this._InnerFilletRadius; } set { this._InnerFilletRadius = value;} }
	
		[Description("Outer corner radius.")]
		public IfcNonNegativeLengthMeasure? OuterFilletRadius { get { return this._OuterFilletRadius; } set { this._OuterFilletRadius = value;} }
	
	
	}
	
}

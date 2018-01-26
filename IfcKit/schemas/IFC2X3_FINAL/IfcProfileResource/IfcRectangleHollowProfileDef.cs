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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("1db68cb4-51e9-4d7b-b43a-d738904596a5")]
	public partial class IfcRectangleHollowProfileDef : IfcRectangleProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _WallThickness;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _InnerFilletRadius;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _OuterFilletRadius;
	
	
		public IfcRectangleHollowProfileDef()
		{
		}
	
		public IfcRectangleHollowProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __XDim, IfcPositiveLengthMeasure __YDim, IfcPositiveLengthMeasure __WallThickness, IfcPositiveLengthMeasure? __InnerFilletRadius, IfcPositiveLengthMeasure? __OuterFilletRadius)
			: base(__ProfileType, __ProfileName, __Position, __XDim, __YDim)
		{
			this._WallThickness = __WallThickness;
			this._InnerFilletRadius = __InnerFilletRadius;
			this._OuterFilletRadius = __OuterFilletRadius;
		}
	
		[Description("Thickness of the material.")]
		public IfcPositiveLengthMeasure WallThickness { get { return this._WallThickness; } set { this._WallThickness = value;} }
	
		[Description("Radius of the circular arcs, by which all four corners of the outer contour of re" +
	    "ctangle are equally rounded. If not given, zero (= no rounding arcs) applies.")]
		public IfcPositiveLengthMeasure? InnerFilletRadius { get { return this._InnerFilletRadius; } set { this._InnerFilletRadius = value;} }
	
		[Description("Radius of the circular arcs, by which all four corners of the outer contour of re" +
	    "ctangle are equally rounded. If not given, zero (= no rounding arcs) applies.")]
		public IfcPositiveLengthMeasure? OuterFilletRadius { get { return this._OuterFilletRadius; } set { this._OuterFilletRadius = value;} }
	
	
	}
	
}

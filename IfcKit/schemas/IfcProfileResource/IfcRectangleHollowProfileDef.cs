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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	public partial class IfcRectangleHollowProfileDef : IfcRectangleProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Thickness of the material.")]
		[Required()]
		public IfcPositiveLengthMeasure WallThickness { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Inner corner radius.")]
		public IfcNonNegativeLengthMeasure? InnerFilletRadius { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Outer corner radius.")]
		public IfcNonNegativeLengthMeasure? OuterFilletRadius { get; set; }
	
	
		public IfcRectangleHollowProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __XDim, IfcPositiveLengthMeasure __YDim, IfcPositiveLengthMeasure __WallThickness, IfcNonNegativeLengthMeasure? __InnerFilletRadius, IfcNonNegativeLengthMeasure? __OuterFilletRadius)
			: base(__ProfileType, __ProfileName, __Position, __XDim, __YDim)
		{
			this.WallThickness = __WallThickness;
			this.InnerFilletRadius = __InnerFilletRadius;
			this.OuterFilletRadius = __OuterFilletRadius;
		}
	
	
	}
	
}

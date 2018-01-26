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
	[Guid("2d8e8f4a-8947-49ca-b146-77ad07842c99")]
	public partial class IfcCircleHollowProfileDef : IfcCircleProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _WallThickness;
	
	
		public IfcCircleHollowProfileDef()
		{
		}
	
		public IfcCircleHollowProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __Radius, IfcPositiveLengthMeasure __WallThickness)
			: base(__ProfileType, __ProfileName, __Position, __Radius)
		{
			this._WallThickness = __WallThickness;
		}
	
		[Description("Thickness of the material, it is the difference between the outer and inner radiu" +
	    "s.")]
		public IfcPositiveLengthMeasure WallThickness { get { return this._WallThickness; } set { this._WallThickness = value;} }
	
	
	}
	
}

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
	public partial class IfcCircleHollowProfileDef : IfcCircleProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Thickness of the material, it is the difference between the outer and inner radius.")]
		[Required()]
		public IfcPositiveLengthMeasure WallThickness { get; set; }
	
	
		public IfcCircleHollowProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __Radius, IfcPositiveLengthMeasure __WallThickness)
			: base(__ProfileType, __ProfileName, __Position, __Radius)
		{
			this.WallThickness = __WallThickness;
		}
	
	
	}
	
}

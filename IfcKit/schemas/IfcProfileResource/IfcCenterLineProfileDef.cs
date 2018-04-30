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
	public partial class IfcCenterLineProfileDef : IfcArbitraryOpenProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Constant thickness applied along the center line.")]
		[Required()]
		public IfcPositiveLengthMeasure Thickness { get; set; }
	
	
		public IfcCenterLineProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcBoundedCurve __Curve, IfcPositiveLengthMeasure __Thickness)
			: base(__ProfileType, __ProfileName, __Curve)
		{
			this.Thickness = __Thickness;
		}
	
	
	}
	
}

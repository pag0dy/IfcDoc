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
	public partial class IfcRoundedRectangleProfileDef : IfcRectangleProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Radius of the circular arcs by which all four corners of the rectangle are equally rounded.")]
		[Required()]
		public IfcPositiveLengthMeasure RoundingRadius { get; set; }
	
	
		public IfcRoundedRectangleProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __XDim, IfcPositiveLengthMeasure __YDim, IfcPositiveLengthMeasure __RoundingRadius)
			: base(__ProfileType, __ProfileName, __Position, __XDim, __YDim)
		{
			this.RoundingRadius = __RoundingRadius;
		}
	
	
	}
	
}

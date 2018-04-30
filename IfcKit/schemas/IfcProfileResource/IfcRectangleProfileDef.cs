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
	public partial class IfcRectangleProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The extent of the rectangle in the direction of the x-axis.")]
		[Required()]
		public IfcPositiveLengthMeasure XDim { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The extent of the rectangle in the direction of the y-axis.")]
		[Required()]
		public IfcPositiveLengthMeasure YDim { get; set; }
	
	
		public IfcRectangleProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __XDim, IfcPositiveLengthMeasure __YDim)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this.XDim = __XDim;
			this.YDim = __YDim;
		}
	
	
	}
	
}

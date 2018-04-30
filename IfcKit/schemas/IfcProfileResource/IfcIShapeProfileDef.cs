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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	public partial class IfcIShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Total extent of the width, defined parallel to the x axis of the position coordinate system.")]
		[Required()]
		public IfcPositiveLengthMeasure OverallWidth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Total extent of the depth, defined parallel to the y axis of the position coordinate system.")]
		[Required()]
		public IfcPositiveLengthMeasure OverallDepth { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Thickness of the web of the I-shape. The web is centred on the x-axis and the y-axis of the position coordinate system.")]
		[Required()]
		public IfcPositiveLengthMeasure WebThickness { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Flange thickness of the I-shape. Both, the upper and the lower flanges have the same thickness and they are centred on the y-axis of the position coordinate system.")]
		[Required()]
		public IfcPositiveLengthMeasure FlangeThickness { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The fillet between the web and the flange, if not given, zero is assumed.")]
		public IfcPositiveLengthMeasure? FilletRadius { get; set; }
	
	
		public IfcIShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __OverallWidth, IfcPositiveLengthMeasure __OverallDepth, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __FlangeThickness, IfcPositiveLengthMeasure? __FilletRadius)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this.OverallWidth = __OverallWidth;
			this.OverallDepth = __OverallDepth;
			this.WebThickness = __WebThickness;
			this.FlangeThickness = __FlangeThickness;
			this.FilletRadius = __FilletRadius;
		}
	
	
	}
	
}

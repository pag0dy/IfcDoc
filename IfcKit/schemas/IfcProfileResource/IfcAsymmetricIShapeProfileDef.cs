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
	public partial class IfcAsymmetricIShapeProfileDef : IfcIShapeProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Extent of the top flange, defined parallel to the x axis of the position coordinate system.")]
		[Required()]
		public IfcPositiveLengthMeasure TopFlangeWidth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Flange thickness of the top flange of the I-shape. If given, the upper and the lower flanges can have different thicknesses. If not given, the value of the inherited FlangeThickness attribute applies to both, the top and bottom flange thickness.")]
		public IfcPositiveLengthMeasure? TopFlangeThickness { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The fillet between the web and the top flange of the I-shape. If given, the fillet between upper and the lower flanges and the web can be different. If not given, the value of the inherited FilletRadius attribute applies to both, the top and bottom fillet. If the inherited FilletRadius is not given either, no filler is applied.")]
		public IfcPositiveLengthMeasure? TopFlangeFilletRadius { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("<EPM-HTML> Location of centre of gravity along the y axis measured from the center of the bounding box.     <blockquote> <small><font color=\"#ff0000\">  IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInY</i> has been made optional. Upward compatibility for file based exchange is guaranteed.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInY { get; set; }
	
	
		public IfcAsymmetricIShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __OverallWidth, IfcPositiveLengthMeasure __OverallDepth, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __FlangeThickness, IfcPositiveLengthMeasure? __FilletRadius, IfcPositiveLengthMeasure __TopFlangeWidth, IfcPositiveLengthMeasure? __TopFlangeThickness, IfcPositiveLengthMeasure? __TopFlangeFilletRadius, IfcPositiveLengthMeasure? __CentreOfGravityInY)
			: base(__ProfileType, __ProfileName, __Position, __OverallWidth, __OverallDepth, __WebThickness, __FlangeThickness, __FilletRadius)
		{
			this.TopFlangeWidth = __TopFlangeWidth;
			this.TopFlangeThickness = __TopFlangeThickness;
			this.TopFlangeFilletRadius = __TopFlangeFilletRadius;
			this.CentreOfGravityInY = __CentreOfGravityInY;
		}
	
	
	}
	
}

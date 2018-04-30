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
	public partial class IfcLShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Leg length, see illustration above (= h). ")]
		[Required()]
		public IfcPositiveLengthMeasure Depth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Leg length, see illustration above (= b). If not given, the value of the Depth attribute is applied to Width.")]
		public IfcPositiveLengthMeasure? Width { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Constant wall thickness of profile, see illustration above (= ts).")]
		[Required()]
		public IfcPositiveLengthMeasure Thickness { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Fillet radius according the above illustration (= r1). If it is not given, zero is assumed.")]
		public IfcPositiveLengthMeasure? FilletRadius { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Edge radius according the above illustration (= r2). If it is not given, zero is assumed. ")]
		public IfcPositiveLengthMeasure? EdgeRadius { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Slope of leg of the profile. If it is not given, zero is assumed. ")]
		public IfcPlaneAngleMeasure? LegSlope { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("<EPM-HTML> Location of centre of gravity along the x axis measured from the center of the bounding box.     <blockquote> <small><font color=\"#ff0000\">  IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInX</i> has been made optional. Upward compatibility for file based exchange is guaranteed.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInX { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("<EPM-HTML> Location of centre of gravity along the Y axis measured from the center of the bounding box.     <blockquote> <small><font color=\"#ff0000\">  IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInY</i> has been made optional. Upward compatibility for file based exchange is guaranteed.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInY { get; set; }
	
	
		public IfcLShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __Depth, IfcPositiveLengthMeasure? __Width, IfcPositiveLengthMeasure __Thickness, IfcPositiveLengthMeasure? __FilletRadius, IfcPositiveLengthMeasure? __EdgeRadius, IfcPlaneAngleMeasure? __LegSlope, IfcPositiveLengthMeasure? __CentreOfGravityInX, IfcPositiveLengthMeasure? __CentreOfGravityInY)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this.Depth = __Depth;
			this.Width = __Width;
			this.Thickness = __Thickness;
			this.FilletRadius = __FilletRadius;
			this.EdgeRadius = __EdgeRadius;
			this.LegSlope = __LegSlope;
			this.CentreOfGravityInX = __CentreOfGravityInX;
			this.CentreOfGravityInY = __CentreOfGravityInY;
		}
	
	
	}
	
}

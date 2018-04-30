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
	public partial class IfcCraneRailAShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Total extent of the height, defined parallel to the y axis of the position coordinate system. See illustration above (= h1).")]
		[Required()]
		public IfcPositiveLengthMeasure OverallHeight { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Total extent of the width of the base, defined parallel to the x axis of the position coordinate system. See illustration above (= b2).")]
		[Required()]
		public IfcPositiveLengthMeasure BaseWidth2 { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Edge radius according the above illustration (= r1).")]
		public IfcPositiveLengthMeasure? Radius { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Total extent of the width of the head, defined parallel to the x axis of the position coordinate system. See illustration above (= b1).")]
		[Required()]
		public IfcPositiveLengthMeasure HeadWidth { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Head depth of the A shape crane rail, see illustration above (= h2).")]
		[Required()]
		public IfcPositiveLengthMeasure HeadDepth2 { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Head depth of the A shape crane rail, see illustration above (= h3).")]
		[Required()]
		public IfcPositiveLengthMeasure HeadDepth3 { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Thickness of the web of the A shape crane rail. See illustration above (= b3).")]
		[Required()]
		public IfcPositiveLengthMeasure WebThickness { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Width of the base where thickness changes, defined parallel to the x axis of the position coordinate system. See illustration above (= b4).")]
		[Required()]
		public IfcPositiveLengthMeasure BaseWidth4 { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("Base depth of the A shape crane rail, see illustration above (= s1).")]
		[Required()]
		public IfcPositiveLengthMeasure BaseDepth1 { get; set; }
	
		[DataMember(Order = 9)] 
		[XmlAttribute]
		[Description("Base depth of the A shape crane rail, see illustration above (= s2).")]
		[Required()]
		public IfcPositiveLengthMeasure BaseDepth2 { get; set; }
	
		[DataMember(Order = 10)] 
		[XmlAttribute]
		[Description("Depth of the base where thickness changes, see illustration above (= s3).")]
		[Required()]
		public IfcPositiveLengthMeasure BaseDepth3 { get; set; }
	
		[DataMember(Order = 11)] 
		[XmlAttribute]
		[Description("<EPM-HTML> Location of centre of gravity along the y axis measured from the center of the bounding box.     <blockquote> <small><font color=\"#ff0000\">  IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInY</i> has been made optional. Upward compatibility for file based exchange is guaranteed.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInY { get; set; }
	
	
		public IfcCraneRailAShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __OverallHeight, IfcPositiveLengthMeasure __BaseWidth2, IfcPositiveLengthMeasure? __Radius, IfcPositiveLengthMeasure __HeadWidth, IfcPositiveLengthMeasure __HeadDepth2, IfcPositiveLengthMeasure __HeadDepth3, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __BaseWidth4, IfcPositiveLengthMeasure __BaseDepth1, IfcPositiveLengthMeasure __BaseDepth2, IfcPositiveLengthMeasure __BaseDepth3, IfcPositiveLengthMeasure? __CentreOfGravityInY)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this.OverallHeight = __OverallHeight;
			this.BaseWidth2 = __BaseWidth2;
			this.Radius = __Radius;
			this.HeadWidth = __HeadWidth;
			this.HeadDepth2 = __HeadDepth2;
			this.HeadDepth3 = __HeadDepth3;
			this.WebThickness = __WebThickness;
			this.BaseWidth4 = __BaseWidth4;
			this.BaseDepth1 = __BaseDepth1;
			this.BaseDepth2 = __BaseDepth2;
			this.BaseDepth3 = __BaseDepth3;
			this.CentreOfGravityInY = __CentreOfGravityInY;
		}
	
	
	}
	
}

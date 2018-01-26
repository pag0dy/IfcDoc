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
	[Guid("d0fe0049-2c41-4a52-a6b1-338e9ed9a0a8")]
	public partial class IfcCraneRailAShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _OverallHeight;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _BaseWidth2;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _Radius;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _HeadWidth;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _HeadDepth2;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _HeadDepth3;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _WebThickness;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _BaseWidth4;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _BaseDepth1;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _BaseDepth2;
	
		[DataMember(Order=10)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _BaseDepth3;
	
		[DataMember(Order=11)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _CentreOfGravityInY;
	
	
		public IfcCraneRailAShapeProfileDef()
		{
		}
	
		public IfcCraneRailAShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __OverallHeight, IfcPositiveLengthMeasure __BaseWidth2, IfcPositiveLengthMeasure? __Radius, IfcPositiveLengthMeasure __HeadWidth, IfcPositiveLengthMeasure __HeadDepth2, IfcPositiveLengthMeasure __HeadDepth3, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __BaseWidth4, IfcPositiveLengthMeasure __BaseDepth1, IfcPositiveLengthMeasure __BaseDepth2, IfcPositiveLengthMeasure __BaseDepth3, IfcPositiveLengthMeasure? __CentreOfGravityInY)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this._OverallHeight = __OverallHeight;
			this._BaseWidth2 = __BaseWidth2;
			this._Radius = __Radius;
			this._HeadWidth = __HeadWidth;
			this._HeadDepth2 = __HeadDepth2;
			this._HeadDepth3 = __HeadDepth3;
			this._WebThickness = __WebThickness;
			this._BaseWidth4 = __BaseWidth4;
			this._BaseDepth1 = __BaseDepth1;
			this._BaseDepth2 = __BaseDepth2;
			this._BaseDepth3 = __BaseDepth3;
			this._CentreOfGravityInY = __CentreOfGravityInY;
		}
	
		[Description("Total extent of the height, defined parallel to the y axis of the position coordi" +
	    "nate system. See illustration above (= h1).")]
		public IfcPositiveLengthMeasure OverallHeight { get { return this._OverallHeight; } set { this._OverallHeight = value;} }
	
		[Description("Total extent of the width of the base, defined parallel to the x axis of the posi" +
	    "tion coordinate system. See illustration above (= b2).")]
		public IfcPositiveLengthMeasure BaseWidth2 { get { return this._BaseWidth2; } set { this._BaseWidth2 = value;} }
	
		[Description("Edge radius according the above illustration (= r1).")]
		public IfcPositiveLengthMeasure? Radius { get { return this._Radius; } set { this._Radius = value;} }
	
		[Description("Total extent of the width of the head, defined parallel to the x axis of the posi" +
	    "tion coordinate system. See illustration above (= b1).")]
		public IfcPositiveLengthMeasure HeadWidth { get { return this._HeadWidth; } set { this._HeadWidth = value;} }
	
		[Description("Head depth of the A shape crane rail, see illustration above (= h2).")]
		public IfcPositiveLengthMeasure HeadDepth2 { get { return this._HeadDepth2; } set { this._HeadDepth2 = value;} }
	
		[Description("Head depth of the A shape crane rail, see illustration above (= h3).")]
		public IfcPositiveLengthMeasure HeadDepth3 { get { return this._HeadDepth3; } set { this._HeadDepth3 = value;} }
	
		[Description("Thickness of the web of the A shape crane rail. See illustration above (= b3).")]
		public IfcPositiveLengthMeasure WebThickness { get { return this._WebThickness; } set { this._WebThickness = value;} }
	
		[Description("Width of the base where thickness changes, defined parallel to the x axis of the " +
	    "position coordinate system. See illustration above (= b4).")]
		public IfcPositiveLengthMeasure BaseWidth4 { get { return this._BaseWidth4; } set { this._BaseWidth4 = value;} }
	
		[Description("Base depth of the A shape crane rail, see illustration above (= s1).")]
		public IfcPositiveLengthMeasure BaseDepth1 { get { return this._BaseDepth1; } set { this._BaseDepth1 = value;} }
	
		[Description("Base depth of the A shape crane rail, see illustration above (= s2).")]
		public IfcPositiveLengthMeasure BaseDepth2 { get { return this._BaseDepth2; } set { this._BaseDepth2 = value;} }
	
		[Description("Depth of the base where thickness changes, see illustration above (= s3).")]
		public IfcPositiveLengthMeasure BaseDepth3 { get { return this._BaseDepth3; } set { this._BaseDepth3 = value;} }
	
		[Description(@"<EPM-HTML> Location of centre of gravity along the y axis measured from the center of the bounding box. 
	  <blockquote> <small><font color=""#ff0000"">
	IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInY</i> has been made optional. Upward compatibility for file based exchange is guaranteed.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInY { get { return this._CentreOfGravityInY; } set { this._CentreOfGravityInY = value;} }
	
	
	}
	
}

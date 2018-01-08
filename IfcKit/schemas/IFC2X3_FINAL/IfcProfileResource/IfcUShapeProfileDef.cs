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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("7e817404-f732-4988-9b6c-cf64fff90f1f")]
	public partial class IfcUShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Depth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _FlangeWidth;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _WebThickness;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _FlangeThickness;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _FilletRadius;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _EdgeRadius;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _FlangeSlope;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _CentreOfGravityInX;
	
	
		[Description("Web lengths, see illustration above (= h). ")]
		public IfcPositiveLengthMeasure Depth { get { return this._Depth; } set { this._Depth = value;} }
	
		[Description("Flange lengths, see illustration above (= b). ")]
		public IfcPositiveLengthMeasure FlangeWidth { get { return this._FlangeWidth; } set { this._FlangeWidth = value;} }
	
		[Description("Constant wall thickness of web (= ts). ")]
		public IfcPositiveLengthMeasure WebThickness { get { return this._WebThickness; } set { this._WebThickness = value;} }
	
		[Description("Constant wall thickness of flange (= tg). ")]
		public IfcPositiveLengthMeasure FlangeThickness { get { return this._FlangeThickness; } set { this._FlangeThickness = value;} }
	
		[Description("Fillet radius according the above illustration (= r1). If it is not given, zero i" +
	    "s assumed. ")]
		public IfcPositiveLengthMeasure? FilletRadius { get { return this._FilletRadius; } set { this._FilletRadius = value;} }
	
		[Description("Edge radius according the above illustration (= r2). If it is not given, zero is " +
	    "assumed. ")]
		public IfcPositiveLengthMeasure? EdgeRadius { get { return this._EdgeRadius; } set { this._EdgeRadius = value;} }
	
		[Description("Slope of flange of the profile. If it is not given, zero is assumed.")]
		public IfcPlaneAngleMeasure? FlangeSlope { get { return this._FlangeSlope; } set { this._FlangeSlope = value;} }
	
		[Description(@"<EPM-HTML> Location of centre of gravity along the x axis measured from the center of the bounding box. 
	  <blockquote> <small><font color=""#ff0000"">
	IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInX</i> has been made optional. Upward compatibility for file based exchange is guaranteed.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInX { get { return this._CentreOfGravityInX; } set { this._CentreOfGravityInX = value;} }
	
	
	}
	
}

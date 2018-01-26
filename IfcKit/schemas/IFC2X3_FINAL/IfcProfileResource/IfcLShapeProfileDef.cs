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
	[Guid("a7f8d89b-9a5d-4857-9cfa-98f261296a6f")]
	public partial class IfcLShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Depth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _Width;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Thickness;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _FilletRadius;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _EdgeRadius;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _LegSlope;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _CentreOfGravityInX;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _CentreOfGravityInY;
	
	
		public IfcLShapeProfileDef()
		{
		}
	
		public IfcLShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __Depth, IfcPositiveLengthMeasure? __Width, IfcPositiveLengthMeasure __Thickness, IfcPositiveLengthMeasure? __FilletRadius, IfcPositiveLengthMeasure? __EdgeRadius, IfcPlaneAngleMeasure? __LegSlope, IfcPositiveLengthMeasure? __CentreOfGravityInX, IfcPositiveLengthMeasure? __CentreOfGravityInY)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this._Depth = __Depth;
			this._Width = __Width;
			this._Thickness = __Thickness;
			this._FilletRadius = __FilletRadius;
			this._EdgeRadius = __EdgeRadius;
			this._LegSlope = __LegSlope;
			this._CentreOfGravityInX = __CentreOfGravityInX;
			this._CentreOfGravityInY = __CentreOfGravityInY;
		}
	
		[Description("Leg length, see illustration above (= h). ")]
		public IfcPositiveLengthMeasure Depth { get { return this._Depth; } set { this._Depth = value;} }
	
		[Description("Leg length, see illustration above (= b). If not given, the value of the Depth at" +
	    "tribute is applied to Width.")]
		public IfcPositiveLengthMeasure? Width { get { return this._Width; } set { this._Width = value;} }
	
		[Description("Constant wall thickness of profile, see illustration above (= ts).")]
		public IfcPositiveLengthMeasure Thickness { get { return this._Thickness; } set { this._Thickness = value;} }
	
		[Description("Fillet radius according the above illustration (= r1). If it is not given, zero i" +
	    "s assumed.")]
		public IfcPositiveLengthMeasure? FilletRadius { get { return this._FilletRadius; } set { this._FilletRadius = value;} }
	
		[Description("Edge radius according the above illustration (= r2). If it is not given, zero is " +
	    "assumed. ")]
		public IfcPositiveLengthMeasure? EdgeRadius { get { return this._EdgeRadius; } set { this._EdgeRadius = value;} }
	
		[Description("Slope of leg of the profile. If it is not given, zero is assumed. ")]
		public IfcPlaneAngleMeasure? LegSlope { get { return this._LegSlope; } set { this._LegSlope = value;} }
	
		[Description(@"<EPM-HTML> Location of centre of gravity along the x axis measured from the center of the bounding box. 
	  <blockquote> <small><font color=""#ff0000"">
	IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInX</i> has been made optional. Upward compatibility for file based exchange is guaranteed.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInX { get { return this._CentreOfGravityInX; } set { this._CentreOfGravityInX = value;} }
	
		[Description(@"<EPM-HTML> Location of centre of gravity along the Y axis measured from the center of the bounding box. 
	  <blockquote> <small><font color=""#ff0000"">
	IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInY</i> has been made optional. Upward compatibility for file based exchange is guaranteed.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInY { get { return this._CentreOfGravityInY; } set { this._CentreOfGravityInY = value;} }
	
	
	}
	
}

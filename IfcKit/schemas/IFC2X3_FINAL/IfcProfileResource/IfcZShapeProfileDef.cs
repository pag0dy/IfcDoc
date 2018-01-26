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
	[Guid("d0f17bd3-c37e-46e7-b03e-b6c0ae3bff08")]
	public partial class IfcZShapeProfileDef : IfcParameterizedProfileDef
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
	
	
		public IfcZShapeProfileDef()
		{
		}
	
		public IfcZShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __Depth, IfcPositiveLengthMeasure __FlangeWidth, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __FlangeThickness, IfcPositiveLengthMeasure? __FilletRadius, IfcPositiveLengthMeasure? __EdgeRadius)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this._Depth = __Depth;
			this._FlangeWidth = __FlangeWidth;
			this._WebThickness = __WebThickness;
			this._FlangeThickness = __FlangeThickness;
			this._FilletRadius = __FilletRadius;
			this._EdgeRadius = __EdgeRadius;
		}
	
		[Description("Web length, see illustration above (= h). ")]
		public IfcPositiveLengthMeasure Depth { get { return this._Depth; } set { this._Depth = value;} }
	
		[Description("Flange length, see illustration above (= b). ")]
		public IfcPositiveLengthMeasure FlangeWidth { get { return this._FlangeWidth; } set { this._FlangeWidth = value;} }
	
		[Description("Constant wall thickness of web, see illustration above (= ts). ")]
		public IfcPositiveLengthMeasure WebThickness { get { return this._WebThickness; } set { this._WebThickness = value;} }
	
		[Description("Constant wall thickness of flange, see illustration above (= tg). ")]
		public IfcPositiveLengthMeasure FlangeThickness { get { return this._FlangeThickness; } set { this._FlangeThickness = value;} }
	
		[Description("Fillet radius according the above illustration (= r1). If it is not given, zero i" +
	    "s assumed. ")]
		public IfcPositiveLengthMeasure? FilletRadius { get { return this._FilletRadius; } set { this._FilletRadius = value;} }
	
		[Description("Edge radius according the above illustration (= r2). If it is not given, zero is " +
	    "assumed. ")]
		public IfcPositiveLengthMeasure? EdgeRadius { get { return this._EdgeRadius; } set { this._EdgeRadius = value;} }
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("c5e6f97d-9889-46a6-bcbb-63e9cbb0b1c4")]
	public partial class IfcTShapeProfileDef : IfcParameterizedProfileDef
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
		IfcNonNegativeLengthMeasure? _FilletRadius;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _FlangeEdgeRadius;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _WebEdgeRadius;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _WebSlope;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _FlangeSlope;
	
	
		[Description("Web lengths, see illustration above (= h).")]
		public IfcPositiveLengthMeasure Depth { get { return this._Depth; } set { this._Depth = value;} }
	
		[Description("Flange lengths, see illustration above (= b).")]
		public IfcPositiveLengthMeasure FlangeWidth { get { return this._FlangeWidth; } set { this._FlangeWidth = value;} }
	
		[Description("Constant wall thickness of web (= ts).")]
		public IfcPositiveLengthMeasure WebThickness { get { return this._WebThickness; } set { this._WebThickness = value;} }
	
		[Description("Constant wall thickness of flange (= tg).")]
		public IfcPositiveLengthMeasure FlangeThickness { get { return this._FlangeThickness; } set { this._FlangeThickness = value;} }
	
		[Description("Fillet radius according the above illustration (= r1).")]
		public IfcNonNegativeLengthMeasure? FilletRadius { get { return this._FilletRadius; } set { this._FilletRadius = value;} }
	
		[Description("Edge radius according the above illustration (= r2).")]
		public IfcNonNegativeLengthMeasure? FlangeEdgeRadius { get { return this._FlangeEdgeRadius; } set { this._FlangeEdgeRadius = value;} }
	
		[Description("Edge radius according the above illustration (= r3).")]
		public IfcNonNegativeLengthMeasure? WebEdgeRadius { get { return this._WebEdgeRadius; } set { this._WebEdgeRadius = value;} }
	
		[Description("Slope of flange of the profile.")]
		public IfcPlaneAngleMeasure? WebSlope { get { return this._WebSlope; } set { this._WebSlope = value;} }
	
		[Description("Slope of web of the profile.")]
		public IfcPlaneAngleMeasure? FlangeSlope { get { return this._FlangeSlope; } set { this._FlangeSlope = value;} }
	
	
	}
	
}

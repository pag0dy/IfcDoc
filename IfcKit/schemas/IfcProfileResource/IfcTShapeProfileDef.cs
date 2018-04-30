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
	public partial class IfcTShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Web lengths, see illustration above (= h).")]
		[Required()]
		public IfcPositiveLengthMeasure Depth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Flange lengths, see illustration above (= b).")]
		[Required()]
		public IfcPositiveLengthMeasure FlangeWidth { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Constant wall thickness of web (= ts).")]
		[Required()]
		public IfcPositiveLengthMeasure WebThickness { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Constant wall thickness of flange (= tg).")]
		[Required()]
		public IfcPositiveLengthMeasure FlangeThickness { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Fillet radius according the above illustration (= r1).")]
		public IfcNonNegativeLengthMeasure? FilletRadius { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Edge radius according the above illustration (= r2).")]
		public IfcNonNegativeLengthMeasure? FlangeEdgeRadius { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Edge radius according the above illustration (= r3).")]
		public IfcNonNegativeLengthMeasure? WebEdgeRadius { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Slope of flange of the profile.")]
		public IfcPlaneAngleMeasure? WebSlope { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("Slope of web of the profile.")]
		public IfcPlaneAngleMeasure? FlangeSlope { get; set; }
	
	
		public IfcTShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __Depth, IfcPositiveLengthMeasure __FlangeWidth, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __FlangeThickness, IfcNonNegativeLengthMeasure? __FilletRadius, IfcNonNegativeLengthMeasure? __FlangeEdgeRadius, IfcNonNegativeLengthMeasure? __WebEdgeRadius, IfcPlaneAngleMeasure? __WebSlope, IfcPlaneAngleMeasure? __FlangeSlope)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this.Depth = __Depth;
			this.FlangeWidth = __FlangeWidth;
			this.WebThickness = __WebThickness;
			this.FlangeThickness = __FlangeThickness;
			this.FilletRadius = __FilletRadius;
			this.FlangeEdgeRadius = __FlangeEdgeRadius;
			this.WebEdgeRadius = __WebEdgeRadius;
			this.WebSlope = __WebSlope;
			this.FlangeSlope = __FlangeSlope;
		}
	
	
	}
	
}

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
	public partial class IfcUShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Web lengths, see illustration above (= h). ")]
		[Required()]
		public IfcPositiveLengthMeasure Depth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Flange lengths, see illustration above (= b). ")]
		[Required()]
		public IfcPositiveLengthMeasure FlangeWidth { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Constant wall thickness of web (= ts). ")]
		[Required()]
		public IfcPositiveLengthMeasure WebThickness { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Constant wall thickness of flange (= tg). ")]
		[Required()]
		public IfcPositiveLengthMeasure FlangeThickness { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Fillet radius according the above illustration (= r1).")]
		public IfcNonNegativeLengthMeasure? FilletRadius { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Edge radius according the above illustration (= r2).")]
		public IfcNonNegativeLengthMeasure? EdgeRadius { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Slope of flange of the profile.")]
		public IfcPlaneAngleMeasure? FlangeSlope { get; set; }
	
	
		public IfcUShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __Depth, IfcPositiveLengthMeasure __FlangeWidth, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __FlangeThickness, IfcNonNegativeLengthMeasure? __FilletRadius, IfcNonNegativeLengthMeasure? __EdgeRadius, IfcPlaneAngleMeasure? __FlangeSlope)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this.Depth = __Depth;
			this.FlangeWidth = __FlangeWidth;
			this.WebThickness = __WebThickness;
			this.FlangeThickness = __FlangeThickness;
			this.FilletRadius = __FilletRadius;
			this.EdgeRadius = __EdgeRadius;
			this.FlangeSlope = __FlangeSlope;
		}
	
	
	}
	
}

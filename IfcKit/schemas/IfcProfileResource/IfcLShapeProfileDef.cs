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
	public partial class IfcLShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Leg length, see illustration above (= h). Same as the overall depth.")]
		[Required()]
		public IfcPositiveLengthMeasure Depth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Leg length, see illustration above (= b). Same as the overall width. This attribute is formally optional for historic reasons only. Whenever the width is known, it shall be provided by value.")]
		public IfcPositiveLengthMeasure? Width { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Constant wall thickness of profile, see illustration above (= ts).")]
		[Required()]
		public IfcPositiveLengthMeasure Thickness { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Fillet radius according the above illustration (= r1).")]
		public IfcNonNegativeLengthMeasure? FilletRadius { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Edge radius according the above illustration (= r2).")]
		public IfcNonNegativeLengthMeasure? EdgeRadius { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Slope of the inner face of each leg of the profile.")]
		public IfcPlaneAngleMeasure? LegSlope { get; set; }
	
	
		public IfcLShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __Depth, IfcPositiveLengthMeasure? __Width, IfcPositiveLengthMeasure __Thickness, IfcNonNegativeLengthMeasure? __FilletRadius, IfcNonNegativeLengthMeasure? __EdgeRadius, IfcPlaneAngleMeasure? __LegSlope)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this.Depth = __Depth;
			this.Width = __Width;
			this.Thickness = __Thickness;
			this.FilletRadius = __FilletRadius;
			this.EdgeRadius = __EdgeRadius;
			this.LegSlope = __LegSlope;
		}
	
	
	}
	
}

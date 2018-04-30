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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public partial class IfcWindowLiningProperties : IfcPropertySetDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Depth of the window lining (dimension measured perpendicular to window elevation plane).")]
		public IfcPositiveLengthMeasure? LiningDepth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Thickness of the window lining (measured parallel to the window elevation plane). ")]
		public IfcPositiveLengthMeasure? LiningThickness { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Thickness of the transom (horizontal separator of window panels within a window), measured parallel to the window elevation plane. The transom is part of the lining and the transom depth is assumed to be identical to the lining depth.")]
		public IfcPositiveLengthMeasure? TransomThickness { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Thickness of the mullion (vertical separator of window panels within a window), measured parallel to the window elevation plane. The mullion is part of the lining and the mullion depth is assumed to be identical to the lining depth.")]
		public IfcPositiveLengthMeasure? MullionThickness { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Offset of the transom centerline, measured along the z-axis of the window placement co-ordinate system. An offset value = 0.5 indicates that the transom is positioned in the middle of the window. ")]
		public IfcNormalisedRatioMeasure? FirstTransomOffset { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Offset of the transom centerline for the second transom, measured along the x-axis of the window placement co-ordinate system. An offset value = 0.666 indicates that the second transom is positioned at two/third of the window.")]
		public IfcNormalisedRatioMeasure? SecondTransomOffset { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Offset of the mullion centerline, measured along the x-axis of the window placement co-ordinate system. An offset value = 0.5 indicates that the mullion is positioned in the middle of the window. ")]
		public IfcNormalisedRatioMeasure? FirstMullionOffset { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Offset of the mullion centerline for the second mullion, measured along the x-axis of the window placement co-ordinate system. An offset value = 0.666 indicates that the second mullion is positioned at two/third of the window. ")]
		public IfcNormalisedRatioMeasure? SecondMullionOffset { get; set; }
	
		[DataMember(Order = 8)] 
		[Description("Optional link to a shape aspect definition, which points to the part of the geometric representation of the window style, which is used to represent the lining.")]
		public IfcShapeAspect ShapeAspectStyle { get; set; }
	
	
		public IfcWindowLiningProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPositiveLengthMeasure? __LiningDepth, IfcPositiveLengthMeasure? __LiningThickness, IfcPositiveLengthMeasure? __TransomThickness, IfcPositiveLengthMeasure? __MullionThickness, IfcNormalisedRatioMeasure? __FirstTransomOffset, IfcNormalisedRatioMeasure? __SecondTransomOffset, IfcNormalisedRatioMeasure? __FirstMullionOffset, IfcNormalisedRatioMeasure? __SecondMullionOffset, IfcShapeAspect __ShapeAspectStyle)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.LiningDepth = __LiningDepth;
			this.LiningThickness = __LiningThickness;
			this.TransomThickness = __TransomThickness;
			this.MullionThickness = __MullionThickness;
			this.FirstTransomOffset = __FirstTransomOffset;
			this.SecondTransomOffset = __SecondTransomOffset;
			this.FirstMullionOffset = __FirstMullionOffset;
			this.SecondMullionOffset = __SecondMullionOffset;
			this.ShapeAspectStyle = __ShapeAspectStyle;
		}
	
	
	}
	
}

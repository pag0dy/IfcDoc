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

namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	public partial class IfcDoorLiningProperties : IfcPreDefinedPropertySet
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Depth of the door lining, measured perpendicular to the plane of the door lining. If omitted (and with a given value to lining thickness) it indicates an adjustable depth (i.e. a depth that adjusts to the thickness of the wall into which the occurrence of this door style is inserted).")]
		public IfcPositiveLengthMeasure? LiningDepth { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Thickness of the door lining as explained in the figure above. If <em>LiningThickness</em> value is 0. (zero) it denotes a door without a lining (all other lining parameters shall be set to NIL in this case). If the <em>LiningThickness</em> is NIL it denotes that the value is not available.  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; Data type modified to be <em>IfcNonNegativeLengthMeasure</em>.  </blockquote>")]
		public IfcNonNegativeLengthMeasure? LiningThickness { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Depth (dimension in plane perpendicular to door leaf) of the door threshold. Only given if the door lining includes a threshold. If omitted (and with a given value to threshold thickness) it indicates an adjustable depth (i.e. a depth that adjusts to the thickness of the wall into which the occurrence of this door style is inserted).")]
		public IfcPositiveLengthMeasure? ThresholdDepth { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Thickness of the door threshold as explained in the figure above. If <em>ThresholdThickness</em> value is 0. (zero) it denotes a door without a threshold (<em>ThresholdDepth</em> shall be set to NIL in this case). If the <em>ThresholdThickness</em> is NIL it denotes that the information about a threshold is not available.  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; Data type modified to be <em>IfcNonNegativeLengthMeasure</em>.  </blockquote>")]
		public IfcNonNegativeLengthMeasure? ThresholdThickness { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Thickness (width in plane parallel to door leaf) of the transom (if provided - that is, if the <em>TransomOffset</em> attribute is set), which divides the door leaf from a glazing (or window) above.  If the <em>TransomThickness</em> is set to zero (and the <em>TransomOffset</em> set to a positive length), then the door is divided vertically into a leaf and transom window area without a physical frame.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Data type changed to <em>IfcNonNegativeLengthMeasure</em>.</blockquote>")]
		public IfcNonNegativeLengthMeasure? TransomThickness { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Offset of the transom (if given) which divides the door leaf from a glazing (or window) above. The offset is given from the bottom of the door opening.")]
		public IfcLengthMeasure? TransomOffset { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Offset (dimension in plane perpendicular to door leaf) of the door lining. The offset is given as distance to the x axis of the local placement. ")]
		public IfcLengthMeasure? LiningOffset { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Offset (dimension in plane perpendicular to door leaf) of the door threshold. The offset is given as distance to the x axis of the local placement. Only given if the door lining includes a threshold and the parameter is known.")]
		public IfcLengthMeasure? ThresholdOffset { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("Thickness of the casing (dimension in plane of the door leaf). If given it is applied equally to all four sides of the adjacent wall.")]
		public IfcPositiveLengthMeasure? CasingThickness { get; set; }
	
		[DataMember(Order = 9)] 
		[XmlAttribute]
		[Description("Depth of the casing (dimension in plane perpendicular to door leaf). If given it is applied equally to all four sides of the adjacent wall.")]
		public IfcPositiveLengthMeasure? CasingDepth { get; set; }
	
		[DataMember(Order = 10)] 
		[XmlElement]
		[Description("Pointer to the shape aspect, if given. The shape aspect reflects the part of the door shape, which represents the door lining.  <blockquote class=\"deprecated\">DEPRECATION&nbsp; The attribute is deprecated and shall no longer be used, i.e. the value shall be NIL ($).</blockquote>")]
		public IfcShapeAspect ShapeAspectStyle { get; set; }
	
		[DataMember(Order = 11)] 
		[XmlAttribute]
		[Description("Offset between the lining and the window panel measured along the x-axis of the local placement.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end of the entity definition.</blockquote>")]
		public IfcLengthMeasure? LiningToPanelOffsetX { get; set; }
	
		[DataMember(Order = 12)] 
		[XmlAttribute]
		[Description("Offset between the lining and the door panel measured along the y-axis of the local placement.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end of the entity definition.</blockquote>")]
		public IfcLengthMeasure? LiningToPanelOffsetY { get; set; }
	
	
		public IfcDoorLiningProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPositiveLengthMeasure? __LiningDepth, IfcNonNegativeLengthMeasure? __LiningThickness, IfcPositiveLengthMeasure? __ThresholdDepth, IfcNonNegativeLengthMeasure? __ThresholdThickness, IfcNonNegativeLengthMeasure? __TransomThickness, IfcLengthMeasure? __TransomOffset, IfcLengthMeasure? __LiningOffset, IfcLengthMeasure? __ThresholdOffset, IfcPositiveLengthMeasure? __CasingThickness, IfcPositiveLengthMeasure? __CasingDepth, IfcShapeAspect __ShapeAspectStyle, IfcLengthMeasure? __LiningToPanelOffsetX, IfcLengthMeasure? __LiningToPanelOffsetY)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.LiningDepth = __LiningDepth;
			this.LiningThickness = __LiningThickness;
			this.ThresholdDepth = __ThresholdDepth;
			this.ThresholdThickness = __ThresholdThickness;
			this.TransomThickness = __TransomThickness;
			this.TransomOffset = __TransomOffset;
			this.LiningOffset = __LiningOffset;
			this.ThresholdOffset = __ThresholdOffset;
			this.CasingThickness = __CasingThickness;
			this.CasingDepth = __CasingDepth;
			this.ShapeAspectStyle = __ShapeAspectStyle;
			this.LiningToPanelOffsetX = __LiningToPanelOffsetX;
			this.LiningToPanelOffsetY = __LiningToPanelOffsetY;
		}
	
	
	}
	
}

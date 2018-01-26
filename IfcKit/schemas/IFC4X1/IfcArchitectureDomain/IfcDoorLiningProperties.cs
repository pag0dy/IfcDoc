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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	[Guid("710a01e4-3b28-429a-8170-ab82c20ec8df")]
	public partial class IfcDoorLiningProperties : IfcPreDefinedPropertySet
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LiningDepth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _LiningThickness;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _ThresholdDepth;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _ThresholdThickness;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _TransomThickness;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcLengthMeasure? _TransomOffset;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcLengthMeasure? _LiningOffset;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcLengthMeasure? _ThresholdOffset;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _CasingThickness;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _CasingDepth;
	
		[DataMember(Order=10)] 
		[XmlElement]
		IfcShapeAspect _ShapeAspectStyle;
	
		[DataMember(Order=11)] 
		[XmlAttribute]
		IfcLengthMeasure? _LiningToPanelOffsetX;
	
		[DataMember(Order=12)] 
		[XmlAttribute]
		IfcLengthMeasure? _LiningToPanelOffsetY;
	
	
		public IfcDoorLiningProperties()
		{
		}
	
		public IfcDoorLiningProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPositiveLengthMeasure? __LiningDepth, IfcNonNegativeLengthMeasure? __LiningThickness, IfcPositiveLengthMeasure? __ThresholdDepth, IfcNonNegativeLengthMeasure? __ThresholdThickness, IfcNonNegativeLengthMeasure? __TransomThickness, IfcLengthMeasure? __TransomOffset, IfcLengthMeasure? __LiningOffset, IfcLengthMeasure? __ThresholdOffset, IfcPositiveLengthMeasure? __CasingThickness, IfcPositiveLengthMeasure? __CasingDepth, IfcShapeAspect __ShapeAspectStyle, IfcLengthMeasure? __LiningToPanelOffsetX, IfcLengthMeasure? __LiningToPanelOffsetY)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._LiningDepth = __LiningDepth;
			this._LiningThickness = __LiningThickness;
			this._ThresholdDepth = __ThresholdDepth;
			this._ThresholdThickness = __ThresholdThickness;
			this._TransomThickness = __TransomThickness;
			this._TransomOffset = __TransomOffset;
			this._LiningOffset = __LiningOffset;
			this._ThresholdOffset = __ThresholdOffset;
			this._CasingThickness = __CasingThickness;
			this._CasingDepth = __CasingDepth;
			this._ShapeAspectStyle = __ShapeAspectStyle;
			this._LiningToPanelOffsetX = __LiningToPanelOffsetX;
			this._LiningToPanelOffsetY = __LiningToPanelOffsetY;
		}
	
		[Description(@"Depth of the door lining, measured perpendicular to the plane of the door lining. If omitted (and with a given value to lining thickness) it indicates an adjustable depth (i.e. a depth that adjusts to the thickness of the wall into which the occurrence of this door style is inserted).")]
		public IfcPositiveLengthMeasure? LiningDepth { get { return this._LiningDepth; } set { this._LiningDepth = value;} }
	
		[Description(@"Thickness of the door lining as explained in the figure above. If <em>LiningThickness</em> value is 0. (zero) it denotes a door without a lining (all other lining parameters shall be set to NIL in this case). If the <em>LiningThickness</em> is NIL it denotes that the value is not available.
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; Data type modified to be <em>IfcNonNegativeLengthMeasure</em>.
	</blockquote>")]
		public IfcNonNegativeLengthMeasure? LiningThickness { get { return this._LiningThickness; } set { this._LiningThickness = value;} }
	
		[Description(@"Depth (dimension in plane perpendicular to door leaf) of the door threshold. Only given if the door lining includes a threshold. If omitted (and with a given value to threshold thickness) it indicates an adjustable depth (i.e. a depth that adjusts to the thickness of the wall into which the occurrence of this door style is inserted).")]
		public IfcPositiveLengthMeasure? ThresholdDepth { get { return this._ThresholdDepth; } set { this._ThresholdDepth = value;} }
	
		[Description(@"Thickness of the door threshold as explained in the figure above. If <em>ThresholdThickness</em> value is 0. (zero) it denotes a door without a threshold (<em>ThresholdDepth</em> shall be set to NIL in this case). If the <em>ThresholdThickness</em> is NIL it denotes that the information about a threshold is not available.
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; Data type modified to be <em>IfcNonNegativeLengthMeasure</em>.
	</blockquote>")]
		public IfcNonNegativeLengthMeasure? ThresholdThickness { get { return this._ThresholdThickness; } set { this._ThresholdThickness = value;} }
	
		[Description(@"Thickness (width in plane parallel to door leaf) of the transom (if provided - that is, if the <em>TransomOffset</em> attribute is set), which divides the door leaf from a glazing (or window) above.
	If the <em>TransomThickness</em> is set to zero (and the <em>TransomOffset</em> set to a positive length), then the door is divided vertically into a leaf and transom window area without a physical frame.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; Data type changed to <em>IfcNonNegativeLengthMeasure</em>.</blockquote>")]
		public IfcNonNegativeLengthMeasure? TransomThickness { get { return this._TransomThickness; } set { this._TransomThickness = value;} }
	
		[Description("Offset of the transom (if given) which divides the door leaf from a glazing (or w" +
	    "indow) above. The offset is given from the bottom of the door opening.")]
		public IfcLengthMeasure? TransomOffset { get { return this._TransomOffset; } set { this._TransomOffset = value;} }
	
		[Description("Offset (dimension in plane perpendicular to door leaf) of the door lining. The of" +
	    "fset is given as distance to the x axis of the local placement. ")]
		public IfcLengthMeasure? LiningOffset { get { return this._LiningOffset; } set { this._LiningOffset = value;} }
	
		[Description("Offset (dimension in plane perpendicular to door leaf) of the door threshold. The" +
	    " offset is given as distance to the x axis of the local placement. Only given if" +
	    " the door lining includes a threshold and the parameter is known.")]
		public IfcLengthMeasure? ThresholdOffset { get { return this._ThresholdOffset; } set { this._ThresholdOffset = value;} }
	
		[Description("Thickness of the casing (dimension in plane of the door leaf). If given it is app" +
	    "lied equally to all four sides of the adjacent wall.")]
		public IfcPositiveLengthMeasure? CasingThickness { get { return this._CasingThickness; } set { this._CasingThickness = value;} }
	
		[Description("Depth of the casing (dimension in plane perpendicular to door leaf). If given it " +
	    "is applied equally to all four sides of the adjacent wall.")]
		public IfcPositiveLengthMeasure? CasingDepth { get { return this._CasingDepth; } set { this._CasingDepth = value;} }
	
		[Description(@"Pointer to the shape aspect, if given. The shape aspect reflects the part of the door shape, which represents the door lining.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute is deprecated and shall no longer be used, i.e. the value shall be NIL ($).</blockquote>")]
		public IfcShapeAspect ShapeAspectStyle { get { return this._ShapeAspectStyle; } set { this._ShapeAspectStyle = value;} }
	
		[Description("Offset between the lining and the window panel measured along the x-axis of the l" +
	    "ocal placement.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribu" +
	    "te added at the end of the entity definition.</blockquote>")]
		public IfcLengthMeasure? LiningToPanelOffsetX { get { return this._LiningToPanelOffsetX; } set { this._LiningToPanelOffsetX = value;} }
	
		[Description("Offset between the lining and the door panel measured along the y-axis of the loc" +
	    "al placement.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute" +
	    " added at the end of the entity definition.</blockquote>")]
		public IfcLengthMeasure? LiningToPanelOffsetY { get { return this._LiningToPanelOffsetY; } set { this._LiningToPanelOffsetY = value;} }
	
	
	}
	
}

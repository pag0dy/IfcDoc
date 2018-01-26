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
	[Guid("cb0b2f54-1b67-43b1-bfc6-07a44a44a16e")]
	public partial class IfcWindowLiningProperties : IfcPreDefinedPropertySet
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LiningDepth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _LiningThickness;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _TransomThickness;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _MullionThickness;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _FirstTransomOffset;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _SecondTransomOffset;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _FirstMullionOffset;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _SecondMullionOffset;
	
		[DataMember(Order=8)] 
		[XmlElement]
		IfcShapeAspect _ShapeAspectStyle;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		IfcLengthMeasure? _LiningOffset;
	
		[DataMember(Order=10)] 
		[XmlAttribute]
		IfcLengthMeasure? _LiningToPanelOffsetX;
	
		[DataMember(Order=11)] 
		[XmlAttribute]
		IfcLengthMeasure? _LiningToPanelOffsetY;
	
	
		public IfcWindowLiningProperties()
		{
		}
	
		public IfcWindowLiningProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPositiveLengthMeasure? __LiningDepth, IfcNonNegativeLengthMeasure? __LiningThickness, IfcNonNegativeLengthMeasure? __TransomThickness, IfcNonNegativeLengthMeasure? __MullionThickness, IfcNormalisedRatioMeasure? __FirstTransomOffset, IfcNormalisedRatioMeasure? __SecondTransomOffset, IfcNormalisedRatioMeasure? __FirstMullionOffset, IfcNormalisedRatioMeasure? __SecondMullionOffset, IfcShapeAspect __ShapeAspectStyle, IfcLengthMeasure? __LiningOffset, IfcLengthMeasure? __LiningToPanelOffsetX, IfcLengthMeasure? __LiningToPanelOffsetY)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._LiningDepth = __LiningDepth;
			this._LiningThickness = __LiningThickness;
			this._TransomThickness = __TransomThickness;
			this._MullionThickness = __MullionThickness;
			this._FirstTransomOffset = __FirstTransomOffset;
			this._SecondTransomOffset = __SecondTransomOffset;
			this._FirstMullionOffset = __FirstMullionOffset;
			this._SecondMullionOffset = __SecondMullionOffset;
			this._ShapeAspectStyle = __ShapeAspectStyle;
			this._LiningOffset = __LiningOffset;
			this._LiningToPanelOffsetX = __LiningToPanelOffsetX;
			this._LiningToPanelOffsetY = __LiningToPanelOffsetY;
		}
	
		[Description("Depth of the window lining (dimension measured perpendicular to window elevation " +
	    "plane).")]
		public IfcPositiveLengthMeasure? LiningDepth { get { return this._LiningDepth; } set { this._LiningDepth = value;} }
	
		[Description(@"Thickness of the window lining as explained in the figure above. If <em>LiningThickness</em> value is 0. (zero) it denotes a window without a lining (all other lining parameters shall be set to NIL in this case). If the <em>LiningThickness</em> is NIL it denotes that the value is not available.
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; Data type modified to be <em>IfcNonNegativeLengthMeasure</em>.
	</blockquote>")]
		public IfcNonNegativeLengthMeasure? LiningThickness { get { return this._LiningThickness; } set { this._LiningThickness = value;} }
	
		[Description(@"Thickness of the transom (horizontal separator of window panels within a window), measured parallel to the window elevation plane. The transom is part of the lining and the transom depth is assumed to be identical to the lining depth.
	If the <em>TransomThickness</em> is set to zero (and the <em>TransomOffset</em> set to a positive length), then the window is divided vertically without a physical divider.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; Data type changed to <em>IfcNonNegativeLengthMeasure</em>.</blockquote>")]
		public IfcNonNegativeLengthMeasure? TransomThickness { get { return this._TransomThickness; } set { this._TransomThickness = value;} }
	
		[Description(@"Thickness of the mullion (vertical separator of window panels within a window), measured parallel to the window elevation plane. The mullion is part of the lining and the mullion depth is assumed to be identical to the lining depth. 
	If the <em>MullionThickness</em> is set to zero (and the <em>MullionOffset</em> set to a positive length), then the window is divided horizontally without a physical divider.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; Data type changed to <em>IfcNonNegativeLengthMeasure</em>.</blockquote>")]
		public IfcNonNegativeLengthMeasure? MullionThickness { get { return this._MullionThickness; } set { this._MullionThickness = value;} }
	
		[Description("Offset of the transom centerline, measured along the z-axis of the window placeme" +
	    "nt co-ordinate system. An offset value = 0.5 indicates that the transom is posit" +
	    "ioned in the middle of the window. ")]
		public IfcNormalisedRatioMeasure? FirstTransomOffset { get { return this._FirstTransomOffset; } set { this._FirstTransomOffset = value;} }
	
		[Description("Offset of the transom centerline for the second transom, measured along the x-axi" +
	    "s of the window placement co-ordinate system. An offset value = 0.666 indicates " +
	    "that the second transom is positioned at two/third of the window.")]
		public IfcNormalisedRatioMeasure? SecondTransomOffset { get { return this._SecondTransomOffset; } set { this._SecondTransomOffset = value;} }
	
		[Description("Offset of the mullion centerline, measured along the x-axis of the window placeme" +
	    "nt co-ordinate system. An offset value = 0.5 indicates that the mullion is posit" +
	    "ioned in the middle of the window. ")]
		public IfcNormalisedRatioMeasure? FirstMullionOffset { get { return this._FirstMullionOffset; } set { this._FirstMullionOffset = value;} }
	
		[Description("Offset of the mullion centerline for the second mullion, measured along the x-axi" +
	    "s of the window placement co-ordinate system. An offset value = 0.666 indicates " +
	    "that the second mullion is positioned at two/third of the window. ")]
		public IfcNormalisedRatioMeasure? SecondMullionOffset { get { return this._SecondMullionOffset; } set { this._SecondMullionOffset = value;} }
	
		[Description(@"Optional link to a shape aspect definition, which points to the part of the geometric representation of the window style, which is used to represent the lining.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE The attribute is deprecated and shall no longer be used, i.e. the value shall be NIL ($).</blockquote>")]
		public IfcShapeAspect ShapeAspectStyle { get { return this._ShapeAspectStyle; } set { this._ShapeAspectStyle = value;} }
	
		[Description(@"Offset of the window lining. The offset is given as distance along the y axis of the local placement (perpendicular to the window plane).
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute added at the end of the entity definition.</blockquote>")]
		public IfcLengthMeasure? LiningOffset { get { return this._LiningOffset; } set { this._LiningOffset = value;} }
	
		[Description(@"Offset between the lining and the window panel measured along the x-axis of the local placement. Should be smaller or equal to the <em>LiningThickness</em>.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute added at the end of the entity definition.</blockquote>")]
		public IfcLengthMeasure? LiningToPanelOffsetX { get { return this._LiningToPanelOffsetX; } set { this._LiningToPanelOffsetX = value;} }
	
		[Description(@"Offset between the lining and the window panel measured along the y-axis of the local placement. Should be smaller or equal to the <em>IfcWindowPanelProperties.PanelThickness</em>.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute added at the end of the entity definition.</blockquote>")]
		public IfcLengthMeasure? LiningToPanelOffsetY { get { return this._LiningToPanelOffsetY; } set { this._LiningToPanelOffsetY = value;} }
	
	
	}
	
}

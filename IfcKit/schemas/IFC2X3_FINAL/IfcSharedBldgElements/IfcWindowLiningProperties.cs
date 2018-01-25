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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("2b41b77c-1950-493a-9f10-2bc8ae0c643b")]
	public partial class IfcWindowLiningProperties : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LiningDepth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LiningThickness;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TransomThickness;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MullionThickness;
	
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
		IfcShapeAspect _ShapeAspectStyle;
	
	
		[Description("Depth of the window lining (dimension measured perpendicular to window elevation " +
	    "plane).")]
		public IfcPositiveLengthMeasure? LiningDepth { get { return this._LiningDepth; } set { this._LiningDepth = value;} }
	
		[Description("Thickness of the window lining (measured parallel to the window elevation plane)." +
	    " ")]
		public IfcPositiveLengthMeasure? LiningThickness { get { return this._LiningThickness; } set { this._LiningThickness = value;} }
	
		[Description("Thickness of the transom (horizontal separator of window panels within a window)," +
	    " measured parallel to the window elevation plane. The transom is part of the lin" +
	    "ing and the transom depth is assumed to be identical to the lining depth.")]
		public IfcPositiveLengthMeasure? TransomThickness { get { return this._TransomThickness; } set { this._TransomThickness = value;} }
	
		[Description("Thickness of the mullion (vertical separator of window panels within a window), m" +
	    "easured parallel to the window elevation plane. The mullion is part of the linin" +
	    "g and the mullion depth is assumed to be identical to the lining depth.")]
		public IfcPositiveLengthMeasure? MullionThickness { get { return this._MullionThickness; } set { this._MullionThickness = value;} }
	
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
	
		[Description("Optional link to a shape aspect definition, which points to the part of the geome" +
	    "tric representation of the window style, which is used to represent the lining.")]
		public IfcShapeAspect ShapeAspectStyle { get { return this._ShapeAspectStyle; } set { this._ShapeAspectStyle = value;} }
	
	
	}
	
}

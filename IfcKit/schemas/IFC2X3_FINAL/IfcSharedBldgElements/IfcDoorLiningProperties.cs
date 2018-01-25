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
	[Guid("f8b65977-9d30-4926-8cba-c173c2ef3216")]
	public partial class IfcDoorLiningProperties : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LiningDepth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LiningThickness;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _ThresholdDepth;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _ThresholdThickness;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TransomThickness;
	
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
		IfcShapeAspect _ShapeAspectStyle;
	
	
		[Description(@"Depth of the door lining, measured perpendicular to the plane of the door lining. If omitted (and with a given value to lining thickness) it indicates an adjustable depth (i.e. a depth that adjusts to the thickness of the wall into which the occurrence of this door style is inserted).")]
		public IfcPositiveLengthMeasure? LiningDepth { get { return this._LiningDepth; } set { this._LiningDepth = value;} }
	
		[Description("Thickness (width in plane parallel to door leaf) of the door lining.")]
		public IfcPositiveLengthMeasure? LiningThickness { get { return this._LiningThickness; } set { this._LiningThickness = value;} }
	
		[Description(@"Depth (dimension in plane perpendicular to door leaf) of the door threshold. Only given if the door lining includes a threshold. If omitted (and with a given value to threshold thickness) it indicates an adjustable depth (i.e. a depth that adjusts to the thickness of the wall into which the occurrence of this door style is inserted).")]
		public IfcPositiveLengthMeasure? ThresholdDepth { get { return this._ThresholdDepth; } set { this._ThresholdDepth = value;} }
	
		[Description("Thickness (width in plane parallel to door leaf) of the door threshold. Only give" +
	    "n if the door lining includes a threshold and the parameter is known.")]
		public IfcPositiveLengthMeasure? ThresholdThickness { get { return this._ThresholdThickness; } set { this._ThresholdThickness = value;} }
	
		[Description("Thickness (width in plane parallel to door leaf) of the transom (if given) which " +
	    "divides the door leaf from a glazing (or window) above.")]
		public IfcPositiveLengthMeasure? TransomThickness { get { return this._TransomThickness; } set { this._TransomThickness = value;} }
	
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
	
		[Description("Pointer to the shape aspect, if given. The shape aspect reflects the part of the " +
	    "door shape, which represents the door lining.")]
		public IfcShapeAspect ShapeAspectStyle { get { return this._ShapeAspectStyle; } set { this._ShapeAspectStyle = value;} }
	
	
	}
	
}

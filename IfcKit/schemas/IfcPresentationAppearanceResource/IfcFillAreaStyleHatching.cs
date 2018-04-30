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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcFillAreaStyleHatching : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcFillStyleSelect
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The curve style of the hatching lines. Any curve style pattern shall start at the origin of each hatch line. ")]
		[Required()]
		public IfcCurveStyle HatchLineAppearance { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A repetition factor that determines the distance between adjacent hatch lines. The factor can either be defined by a parallel offset, or by a repeat factor provided by <em>IfcVector</em>.    <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The attribute type of <em>StartOfNextHatchLine</em> has changed to a SELECT of <em>IfcPositiveLengthMeasure</em> (new) and <em>IfcOneDirectionRepeatFactor</em>.</blockquote>    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute type of <em>StartOfNextHatchLine</em> has changed to a SELECT of <em>IfcPositiveLengthMeasure</em> (new) and <em>IfcVector</em>.</blockquote>  ")]
		[Required()]
		public IfcHatchLineDistanceSelect StartOfNextHatchLine { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("A Cartesian point which defines the offset of the reference hatch line from the origin of the (virtual) hatching coordinate system. The origin is used for mapping the fill area style hatching onto an annotation fill area or surface. The reference hatch line would then appear with this offset from the fill style target point.<br>  If not given the reference hatch lines goes through the origin of the (virtual) hatching coordinate system.    <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The usage of the attribute <em>PointOfReferenceHatchLine</em> has changed to not provide the Cartesian point which is the origin for mapping, but to provide an offset to the origin for the mapping. The attribute has been made OPTIONAL.</blockquote> ")]
		public IfcCartesianPoint PointOfReferenceHatchLine { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlElement]
		[Description("A distance along the reference hatch line which is the start point for the curve style font pattern of the reference hatch line.<br>  If not given, the start point of the curve style font pattern is at the (virtual) hatching coordinate system.    <blockquote class=\"change-ifc2x2\">IFC2x2 Add2 CHANGE The attribute <em>PatternStart</em> has been made OPTIONAL.</blockquote>")]
		public IfcCartesianPoint PatternStart { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("A plane angle measure determining the direction of the parallel hatching lines.")]
		[Required()]
		public IfcPlaneAngleMeasure HatchLineAngle { get; set; }
	
	
		public IfcFillAreaStyleHatching(IfcCurveStyle __HatchLineAppearance, IfcHatchLineDistanceSelect __StartOfNextHatchLine, IfcCartesianPoint __PointOfReferenceHatchLine, IfcCartesianPoint __PatternStart, IfcPlaneAngleMeasure __HatchLineAngle)
		{
			this.HatchLineAppearance = __HatchLineAppearance;
			this.StartOfNextHatchLine = __StartOfNextHatchLine;
			this.PointOfReferenceHatchLine = __PointOfReferenceHatchLine;
			this.PatternStart = __PatternStart;
			this.HatchLineAngle = __HatchLineAngle;
		}
	
	
	}
	
}

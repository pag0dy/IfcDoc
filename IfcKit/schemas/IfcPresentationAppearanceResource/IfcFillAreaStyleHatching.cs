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
		[Description("The curve style of the hatching lines. Any curve style pattern shall start at the origin of each hatch line. ")]
		[Required()]
		public IfcCurveStyle HatchLineAppearance { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("<EPM-HTML>A repetition factor that determines the distance between adjacent hatch lines.    <blockquote><small><color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The attribute type of <i>StartOfNextHatchLine</i> has changed to a SELECT of <i>IfcPositiveLengthMeasure</i> (new) and <i>IfcOneDirectionRepeatFactor</i>.</font></small></blockquote>  </EPM-HTML>  ")]
		[Required()]
		public IfcHatchLineDistanceSelect StartOfNextHatchLine { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("<EPM-HTML>  A Cartesian point which defines the offset of the reference hatch line from the origin of the (virtual) hatching coordinate system. The origin is used for mapping the fill area style hatching onto an annotation fill area or surface. The reference hatch line would then appear with this offset from the fill style target point.<br>  If not given the reference hatch lines goes through the origin of the (virtual) hatching coordinate system.    <blockquote><small><font color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The usage of the attribute <i>PointOfReferenceHatchLine</i> has changed to not provide the Cartesian point which is the origin for mapping, but to provide an offset to the origin for the mapping. The attribute has been made OPTIONAL.    </font></small></blockquote>  </EPM-HTML> ")]
		public IfcCartesianPoint PointOfReferenceHatchLine { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("<EPM-HTML>  A distance along the reference hatch line which is the start point for the curve style font pattern of the reference hatch line.<br>  If not given, the start point of the curve style font pattern is at the (virtual) hatching coordinate system.    <blockquote><small><font color=\"#ff0000\">  IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>PatternStart</i> has been made OPTIONAL.</font></small></blockquote>  </EPM-HTML>")]
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

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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("f465f4fa-8a5f-4683-ad61-1fb517f09bc0")]
	public partial class IfcFillAreaStyleHatching : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcFillStyleSelect
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcCurveStyle _HatchLineAppearance;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcHatchLineDistanceSelect _StartOfNextHatchLine;
	
		[DataMember(Order=2)] 
		[XmlElement]
		IfcCartesianPoint _PointOfReferenceHatchLine;
	
		[DataMember(Order=3)] 
		[XmlElement]
		IfcCartesianPoint _PatternStart;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcPlaneAngleMeasure _HatchLineAngle;
	
	
		[Description("The curve style of the hatching lines. Any curve style pattern shall start at the" +
	    " origin of each hatch line. ")]
		public IfcCurveStyle HatchLineAppearance { get { return this._HatchLineAppearance; } set { this._HatchLineAppearance = value;} }
	
		[Description(@"A repetition factor that determines the distance between adjacent hatch lines. The factor can either be defined by a parallel offset, or by a repeat factor provided by <em>IfcVector</em>.
	  <blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The attribute type of <em>StartOfNextHatchLine</em> has changed to a SELECT of <em>IfcPositiveLengthMeasure</em> (new) and <em>IfcOneDirectionRepeatFactor</em>.</blockquote>
	  <blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute type of <em>StartOfNextHatchLine</em> has changed to a SELECT of <em>IfcPositiveLengthMeasure</em> (new) and <em>IfcVector</em>.</blockquote>
	")]
		public IfcHatchLineDistanceSelect StartOfNextHatchLine { get { return this._StartOfNextHatchLine; } set { this._StartOfNextHatchLine = value;} }
	
		[Description(@"A Cartesian point which defines the offset of the reference hatch line from the origin of the (virtual) hatching coordinate system. The origin is used for mapping the fill area style hatching onto an annotation fill area or surface. The reference hatch line would then appear with this offset from the fill style target point.<br>
	If not given the reference hatch lines goes through the origin of the (virtual) hatching coordinate system.
	  <blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The usage of the attribute <em>PointOfReferenceHatchLine</em> has changed to not provide the Cartesian point which is the origin for mapping, but to provide an offset to the origin for the mapping. The attribute has been made OPTIONAL.</blockquote> ")]
		public IfcCartesianPoint PointOfReferenceHatchLine { get { return this._PointOfReferenceHatchLine; } set { this._PointOfReferenceHatchLine = value;} }
	
		[Description(@"A distance along the reference hatch line which is the start point for the curve style font pattern of the reference hatch line.<br>
	If not given, the start point of the curve style font pattern is at the (virtual) hatching coordinate system.
	  <blockquote class=""change-ifc2x2"">IFC2x2 Add2 CHANGE The attribute <em>PatternStart</em> has been made OPTIONAL.</blockquote>")]
		public IfcCartesianPoint PatternStart { get { return this._PatternStart; } set { this._PatternStart = value;} }
	
		[Description("A plane angle measure determining the direction of the parallel hatching lines.")]
		public IfcPlaneAngleMeasure HatchLineAngle { get { return this._HatchLineAngle; } set { this._HatchLineAngle = value;} }
	
	
	}
	
}

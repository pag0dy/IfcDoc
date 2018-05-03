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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcAlignment2DVerSegParabolicArc : IfcAlignment2DVerticalSegment
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Parabola constant (determining the “steepness” of the parabola). The parabola constant is provided by the “minimum parabola radius”, the true radius of a parabola at its vertical axis (the zero-gradient point of the parabola). The minimum radius is twice the focal length of the parabola (the distance between the focal point and the vertex).")]
		[Required()]
		public IfcPositiveLengthMeasure ParabolaConstant { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Orientation of the parabolic arc, convex (Boolean=”true”) means decreasing gradient along the arc at the beginning such as at the crest of a hill, concave (Boolean=”false”) means increasing gradient along the arc at the beginning such as at the base of a valley.")]
		[Required()]
		public IfcBoolean IsConvex { get; set; }
	
	
		public IfcAlignment2DVerSegParabolicArc(IfcBoolean? __TangentialContinuity, IfcLabel? __StartTag, IfcLabel? __EndTag, IfcLengthMeasure __StartDistAlong, IfcPositiveLengthMeasure __HorizontalLength, IfcLengthMeasure __StartHeight, IfcRatioMeasure __StartGradient, IfcPositiveLengthMeasure __ParabolaConstant, IfcBoolean __IsConvex)
			: base(__TangentialContinuity, __StartTag, __EndTag, __StartDistAlong, __HorizontalLength, __StartHeight, __StartGradient)
		{
			this.ParabolaConstant = __ParabolaConstant;
			this.IsConvex = __IsConvex;
		}
	
	
	}
	
}

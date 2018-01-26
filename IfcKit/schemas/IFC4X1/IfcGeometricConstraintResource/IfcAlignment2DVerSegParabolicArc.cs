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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("59d16e41-5c1a-43d5-8705-044920cf9cbc")]
	public partial class IfcAlignment2DVerSegParabolicArc : IfcAlignment2DVerticalSegment
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _ParabolaConstant;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _IsConvex;
	
	
		public IfcAlignment2DVerSegParabolicArc()
		{
		}
	
		public IfcAlignment2DVerSegParabolicArc(IfcBoolean? __TangentialContinuity, IfcLabel? __StartTag, IfcLabel? __EndTag, IfcLengthMeasure __StartDistAlong, IfcPositiveLengthMeasure __HorizontalLength, IfcLengthMeasure __StartHeight, IfcRatioMeasure __StartGradient, IfcPositiveLengthMeasure __ParabolaConstant, IfcBoolean __IsConvex)
			: base(__TangentialContinuity, __StartTag, __EndTag, __StartDistAlong, __HorizontalLength, __StartHeight, __StartGradient)
		{
			this._ParabolaConstant = __ParabolaConstant;
			this._IsConvex = __IsConvex;
		}
	
		[Description(@"Parabola constant (determining the “steepness” of the parabola). The parabola constant is provided by the “minimum parabola radius”, the true radius of a parabola at its vertical axis (the zero-gradient point of the parabola). The minimum radius is twice the focal length of the parabola (the distance between the focal point and the vertex).")]
		public IfcPositiveLengthMeasure ParabolaConstant { get { return this._ParabolaConstant; } set { this._ParabolaConstant = value;} }
	
		[Description(@"Orientation of the parabolic arc, convex (Boolean=”true”) means decreasing gradient along the arc at the beginning such as at the crest of a hill, concave (Boolean=”false”) means increasing gradient along the arc at the beginning such as at the base of a valley.")]
		public IfcBoolean IsConvex { get { return this._IsConvex; } set { this._IsConvex = value;} }
	
	
	}
	
}

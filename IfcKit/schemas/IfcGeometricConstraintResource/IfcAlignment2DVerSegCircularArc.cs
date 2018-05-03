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
	public partial class IfcAlignment2DVerSegCircularArc : IfcAlignment2DVerticalSegment
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("radius of the circular arc")]
		[Required()]
		public IfcPositiveLengthMeasure Radius { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Orientation of the circular arc, convex (Boolean=”true”) means decreasing gradient along the arc at the beginning such as at the crest of a hill, concave (Boolean=”false”) means increasing gradient along the arc at the beginning such as at the base of a valley.")]
		[Required()]
		public IfcBoolean IsConvex { get; set; }
	
	
		public IfcAlignment2DVerSegCircularArc(IfcBoolean? __TangentialContinuity, IfcLabel? __StartTag, IfcLabel? __EndTag, IfcLengthMeasure __StartDistAlong, IfcPositiveLengthMeasure __HorizontalLength, IfcLengthMeasure __StartHeight, IfcRatioMeasure __StartGradient, IfcPositiveLengthMeasure __Radius, IfcBoolean __IsConvex)
			: base(__TangentialContinuity, __StartTag, __EndTag, __StartDistAlong, __HorizontalLength, __StartHeight, __StartGradient)
		{
			this.Radius = __Radius;
			this.IsConvex = __IsConvex;
		}
	
	
	}
	
}

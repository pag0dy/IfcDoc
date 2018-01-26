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
	[Guid("249794d3-80f8-4936-bf5a-d75d9b53868a")]
	public partial class IfcAlignment2DVerSegCircularArc : IfcAlignment2DVerticalSegment
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Radius;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _IsConvex;
	
	
		public IfcAlignment2DVerSegCircularArc()
		{
		}
	
		public IfcAlignment2DVerSegCircularArc(IfcBoolean? __TangentialContinuity, IfcLabel? __StartTag, IfcLabel? __EndTag, IfcLengthMeasure __StartDistAlong, IfcPositiveLengthMeasure __HorizontalLength, IfcLengthMeasure __StartHeight, IfcRatioMeasure __StartGradient, IfcPositiveLengthMeasure __Radius, IfcBoolean __IsConvex)
			: base(__TangentialContinuity, __StartTag, __EndTag, __StartDistAlong, __HorizontalLength, __StartHeight, __StartGradient)
		{
			this._Radius = __Radius;
			this._IsConvex = __IsConvex;
		}
	
		[Description("radius of the circular arc")]
		public IfcPositiveLengthMeasure Radius { get { return this._Radius; } set { this._Radius = value;} }
	
		[Description(@"Orientation of the circular arc, convex (Boolean=”true”) means decreasing gradient along the arc at the beginning such as at the crest of a hill, concave (Boolean=”false”) means increasing gradient along the arc at the beginning such as at the base of a valley.")]
		public IfcBoolean IsConvex { get { return this._IsConvex; } set { this._IsConvex = value;} }
	
	
	}
	
}

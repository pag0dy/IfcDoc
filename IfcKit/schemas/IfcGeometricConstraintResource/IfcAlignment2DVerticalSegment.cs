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
	public abstract partial class IfcAlignment2DVerticalSegment : IfcAlignment2DSegment
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Distance along the horizontal alignment, measured along the <i>IfcAlignment2DHorizontal</i> given in the length unit of the global <i>IfcUnitAssignment</i>.")]
		[Required()]
		public IfcLengthMeasure StartDistAlong { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Length measured as distance along the horizontal alignment of the segment.")]
		[Required()]
		public IfcPositiveLengthMeasure HorizontalLength { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Elevation in Z of the start point relative to the IfcAlignment coordinate system.  <blockquote class=\"note\">NOTE&nbsp; It is strongly advised to not offset the IfcAlignment coordinate system from the project engineering coordinate system.</blockquote>")]
		[Required()]
		public IfcLengthMeasure StartHeight { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Gradient of the tangent of the vertical segment at the start point. It is provided as a ratio measure. The ratio is percentage/100 (0.1 is equal to 10%). It has a theoretical range of -∞ < n < ∞ using a ratio measure. The equivalent range measured in degree is -90° < n < 90°.  <blockquote class=\"note\">NOTE&nbsp;  For practical application of start gradient, the range of the ratio measure should be within the limits of -1 ≤ n ≤ 1 (equivalent in degree -45° ≤ n ≤ 45°). However larger limits might apply for particular usages.</blockquote>  <p>Positive gradient means an increasing height at the start (or uphill), a negative gradient means decreasing height at the start (or downhill).</p>")]
		[Required()]
		public IfcRatioMeasure StartGradient { get; set; }
	
		[InverseProperty("Segments")] 
		[MinLength(1)]
		[MaxLength(1)]
		public ISet<IfcAlignment2DVertical> ToVertical { get; protected set; }
	
	
		protected IfcAlignment2DVerticalSegment(IfcBoolean? __TangentialContinuity, IfcLabel? __StartTag, IfcLabel? __EndTag, IfcLengthMeasure __StartDistAlong, IfcPositiveLengthMeasure __HorizontalLength, IfcLengthMeasure __StartHeight, IfcRatioMeasure __StartGradient)
			: base(__TangentialContinuity, __StartTag, __EndTag)
		{
			this.StartDistAlong = __StartDistAlong;
			this.HorizontalLength = __HorizontalLength;
			this.StartHeight = __StartHeight;
			this.StartGradient = __StartGradient;
			this.ToVertical = new HashSet<IfcAlignment2DVertical>();
		}
	
	
	}
	
}

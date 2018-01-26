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
	[Guid("d613fd75-12a2-490c-901a-ecaa23332f7f")]
	public abstract partial class IfcAlignment2DVerticalSegment : IfcAlignment2DSegment
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _StartDistAlong;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _HorizontalLength;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _StartHeight;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcRatioMeasure _StartGradient;
	
		[InverseProperty("Segments")] 
		[MinLength(1)]
		[MaxLength(1)]
		ISet<IfcAlignment2DVertical> _ToVertical = new HashSet<IfcAlignment2DVertical>();
	
	
		public IfcAlignment2DVerticalSegment()
		{
		}
	
		public IfcAlignment2DVerticalSegment(IfcBoolean? __TangentialContinuity, IfcLabel? __StartTag, IfcLabel? __EndTag, IfcLengthMeasure __StartDistAlong, IfcPositiveLengthMeasure __HorizontalLength, IfcLengthMeasure __StartHeight, IfcRatioMeasure __StartGradient)
			: base(__TangentialContinuity, __StartTag, __EndTag)
		{
			this._StartDistAlong = __StartDistAlong;
			this._HorizontalLength = __HorizontalLength;
			this._StartHeight = __StartHeight;
			this._StartGradient = __StartGradient;
		}
	
		[Description("Distance along the horizontal alignment, measured along the <i>IfcAlignment2DHori" +
	    "zontal</i> given in the length unit of the global <i>IfcUnitAssignment</i>.")]
		public IfcLengthMeasure StartDistAlong { get { return this._StartDistAlong; } set { this._StartDistAlong = value;} }
	
		[Description("Length measured as distance along the horizontal alignment of the segment.")]
		public IfcPositiveLengthMeasure HorizontalLength { get { return this._HorizontalLength; } set { this._HorizontalLength = value;} }
	
		[Description("Elevation in Z of the start point relative to the IfcAlignment coordinate system." +
	    "\r\n<blockquote class=\"note\">NOTE&nbsp; It is strongly advised to not offset the I" +
	    "fcAlignment coordinate system from the project engineering coordinate system.</b" +
	    "lockquote>")]
		public IfcLengthMeasure StartHeight { get { return this._StartHeight; } set { this._StartHeight = value;} }
	
		[Description(@"Gradient of the tangent of the vertical segment at the start point. It is provided as a ratio measure. The ratio is percentage/100 (0.1 is equal to 10%). It has a theoretical range of -∞ < n < ∞ using a ratio measure. The equivalent range measured in degree is -90° < n < 90°.
	<blockquote class=""note"">NOTE&nbsp;  For practical application of start gradient, the range of the ratio measure should be within the limits of -1 ≤ n ≤ 1 (equivalent in degree -45° ≤ n ≤ 45°). However larger limits might apply for particular usages.</blockquote>
	<p>Positive gradient means an increasing height at the start (or uphill), a negative gradient means decreasing height at the start (or downhill).</p>")]
		public IfcRatioMeasure StartGradient { get { return this._StartGradient; } set { this._StartGradient = value;} }
	
		public ISet<IfcAlignment2DVertical> ToVertical { get { return this._ToVertical; } }
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("caafbf47-1549-4ca7-8916-a46b572cebd2")]
	public partial class IfcDistanceExpression : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _DistanceAlong;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLengthMeasure? _OffsetLateral;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLengthMeasure? _OffsetVertical;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLengthMeasure? _OffsetLongitudinal;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcBoolean? _AlongHorizontal;
	
	
		public IfcDistanceExpression()
		{
		}
	
		public IfcDistanceExpression(IfcLengthMeasure __DistanceAlong, IfcLengthMeasure? __OffsetLateral, IfcLengthMeasure? __OffsetVertical, IfcLengthMeasure? __OffsetLongitudinal, IfcBoolean? __AlongHorizontal)
		{
			this._DistanceAlong = __DistanceAlong;
			this._OffsetLateral = __OffsetLateral;
			this._OffsetVertical = __OffsetVertical;
			this._OffsetLongitudinal = __OffsetLongitudinal;
			this._AlongHorizontal = __AlongHorizontal;
		}
	
		[Description(@"The distance along the basis curve, measured according to projection in the horizontal plane if AlongHorizontal is True, or according to 3D distance otherwise. If the basis curve refers to <i>IfcAlignmentCurve</i> and AlongHorizontal is True, then this measurement directly corresponds to <i>IfcAlignment2DHorizontal</i>.")]
		public IfcLengthMeasure DistanceAlong { get { return this._DistanceAlong; } set { this._DistanceAlong = value;} }
	
		[Description(@"Offset horizontally perpendicular to the basis curve, where positive values indicate to the left of the basis curve as facing in the direction of the basis curve, and negative values indicate to the right. If DistanceAlong coincides with a point of tangential discontinuity (within precision limits), then the tangent of the previous segment governs.")]
		public IfcLengthMeasure? OffsetLateral { get { return this._OffsetLateral; } set { this._OffsetLateral = value;} }
	
		[Description("Offset vertical to the basis curve where positive values indicate vertically upwa" +
	    "rds in global coordinates at DistanceAlong, regardless of the slope of the basis" +
	    " curve at such point.")]
		public IfcLengthMeasure? OffsetVertical { get { return this._OffsetVertical; } set { this._OffsetVertical = value;} }
	
		[Description("Offset parallel to the basis curve after applying DistanceAlong, OffsetLateral, a" +
	    "nd OffsetVertical to reach locations for the case of a tangentially discontinuou" +
	    "s basis curve.")]
		public IfcLengthMeasure? OffsetLongitudinal { get { return this._OffsetLongitudinal; } set { this._OffsetLongitudinal = value;} }
	
		[Description("Indicates whether DistanceAlong is measured according to horizontal projection of" +
	    " distance (if True), or 3D distance (if False or unset).")]
		public IfcBoolean? AlongHorizontal { get { return this._AlongHorizontal; } set { this._AlongHorizontal = value;} }
	
	
	}
	
}

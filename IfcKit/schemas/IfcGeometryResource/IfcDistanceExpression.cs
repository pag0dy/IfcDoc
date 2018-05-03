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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcDistanceExpression : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The distance along the basis curve, measured according to projection in the horizontal plane if AlongHorizontal is True, or according to 3D distance otherwise. If the basis curve refers to <i>IfcAlignmentCurve</i> and AlongHorizontal is True, then this measurement directly corresponds to <i>IfcAlignment2DHorizontal</i>.")]
		[Required()]
		public IfcLengthMeasure DistanceAlong { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Offset horizontally perpendicular to the basis curve, where positive values indicate to the left of the basis curve as facing in the direction of the basis curve, and negative values indicate to the right. If DistanceAlong coincides with a point of tangential discontinuity (within precision limits), then the tangent of the previous segment governs.")]
		public IfcLengthMeasure? OffsetLateral { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Offset vertical to the basis curve where positive values indicate vertically upwards in global coordinates at DistanceAlong, regardless of the slope of the basis curve at such point.")]
		public IfcLengthMeasure? OffsetVertical { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Offset parallel to the basis curve after applying DistanceAlong, OffsetLateral, and OffsetVertical to reach locations for the case of a tangentially discontinuous basis curve.")]
		public IfcLengthMeasure? OffsetLongitudinal { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Indicates whether DistanceAlong is measured according to horizontal projection of distance (if True), or 3D distance (if False or unset).")]
		public IfcBoolean? AlongHorizontal { get; set; }
	
	
		public IfcDistanceExpression(IfcLengthMeasure __DistanceAlong, IfcLengthMeasure? __OffsetLateral, IfcLengthMeasure? __OffsetVertical, IfcLengthMeasure? __OffsetLongitudinal, IfcBoolean? __AlongHorizontal)
		{
			this.DistanceAlong = __DistanceAlong;
			this.OffsetLateral = __OffsetLateral;
			this.OffsetVertical = __OffsetVertical;
			this.OffsetLongitudinal = __OffsetLongitudinal;
			this.AlongHorizontal = __AlongHorizontal;
		}
	
	
	}
	
}

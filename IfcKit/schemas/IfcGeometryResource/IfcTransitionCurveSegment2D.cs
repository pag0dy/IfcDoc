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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcTransitionCurveSegment2D : IfcCurveSegment2D
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The radius of the curve at the start point. If the radius is not provided by a value, i.e. being “NIL” it is interpreted as INFINITE – the <i>StartPoint</i> is at the point, where it does not have a curvature.")]
		public IfcPositiveLengthMeasure? StartRadius { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The radius of the curve at the end point. If the radius is not provided by a value, i.e. being “NIL” it is interpreted as INFINITE – the end point is at the point, where it does not have a curvature.")]
		public IfcPositiveLengthMeasure? EndRadius { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Indication of the curve starting counter-clockwise or clockwise. The orientation of the curve is IsCcw=”true”, if the spiral arc goes counter-clockwise as seen from the start point and start direction, or “to the left\", and with IsCcw=”false” if the spiral arc goes clockwise, or “to the right”. ")]
		[Required()]
		public IfcBoolean IsStartRadiusCCW { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Indication of the curve ending counter-clockwise or clockwise. The orientation of the clothoidal arc is IsCcw=”true”, if the spiral arc goes counter-clockwise as seen towards the end point and end direction, or “to the left\", and with IsCcw=”false” if the spiral arc goes clockwise, or “to the right”. ")]
		[Required()]
		public IfcBoolean IsEndRadiusCCW { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Indicates the specific type of transition curve.")]
		[Required()]
		public IfcTransitionCurveType TransitionCurveType { get; set; }
	
	
		public IfcTransitionCurveSegment2D(IfcCartesianPoint __StartPoint, IfcPlaneAngleMeasure __StartDirection, IfcPositiveLengthMeasure __SegmentLength, IfcPositiveLengthMeasure? __StartRadius, IfcPositiveLengthMeasure? __EndRadius, IfcBoolean __IsStartRadiusCCW, IfcBoolean __IsEndRadiusCCW, IfcTransitionCurveType __TransitionCurveType)
			: base(__StartPoint, __StartDirection, __SegmentLength)
		{
			this.StartRadius = __StartRadius;
			this.EndRadius = __EndRadius;
			this.IsStartRadiusCCW = __IsStartRadiusCCW;
			this.IsEndRadiusCCW = __IsEndRadiusCCW;
			this.TransitionCurveType = __TransitionCurveType;
		}
	
	
	}
	
}

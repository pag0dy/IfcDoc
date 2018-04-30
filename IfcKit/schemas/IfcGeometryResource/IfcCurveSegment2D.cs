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
	public abstract partial class IfcCurveSegment2D : IfcBoundedCurve
	{
		[DataMember(Order = 0)] 
		[Description("The start point of the 2D curve as x/y coordinates defined by a 2D Cartesian point.")]
		[Required()]
		public IfcCartesianPoint StartPoint { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The direction of the tangent at the start point. Direction value 0. indicates a curve with a start tangent along the positive x-axis. Values increases counter-clockwise, and decreases clockwise. Depending on the plane angle unit, either degree or radians, the sensible range is -360° ≤ n ≤ 360° (or -2π ≤ n ≤ 2π). Values larger then a full circle (>|360°| or >|2 π| shall not be used.")]
		[Required()]
		public IfcPlaneAngleMeasure StartDirection { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The length along the curve")]
		[Required()]
		public IfcPositiveLengthMeasure SegmentLength { get; set; }
	
	
		protected IfcCurveSegment2D(IfcCartesianPoint __StartPoint, IfcPlaneAngleMeasure __StartDirection, IfcPositiveLengthMeasure __SegmentLength)
		{
			this.StartPoint = __StartPoint;
			this.StartDirection = __StartDirection;
			this.SegmentLength = __SegmentLength;
		}
	
	
	}
	
}

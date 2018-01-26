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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("2cdcfc96-4005-494f-a43e-fde05a9d10e4")]
	public abstract partial class IfcCurveSegment2D : IfcBoundedCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCartesianPoint _StartPoint;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPlaneAngleMeasure _StartDirection;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _SegmentLength;
	
	
		public IfcCurveSegment2D()
		{
		}
	
		public IfcCurveSegment2D(IfcCartesianPoint __StartPoint, IfcPlaneAngleMeasure __StartDirection, IfcPositiveLengthMeasure __SegmentLength)
		{
			this._StartPoint = __StartPoint;
			this._StartDirection = __StartDirection;
			this._SegmentLength = __SegmentLength;
		}
	
		[Description("The start point of the 2D curve as x/y coordinates defined by a 2D Cartesian poin" +
	    "t.")]
		public IfcCartesianPoint StartPoint { get { return this._StartPoint; } set { this._StartPoint = value;} }
	
		[Description(@"The direction of the tangent at the start point. Direction value 0. indicates a curve with a start tangent along the positive x-axis. Values increases counter-clockwise, and decreases clockwise. Depending on the plane angle unit, either degree or radians, the sensible range is -360° ≤ n ≤ 360° (or -2π ≤ n ≤ 2π). Values larger then a full circle (>|360°| or >|2 π| shall not be used.")]
		public IfcPlaneAngleMeasure StartDirection { get { return this._StartDirection; } set { this._StartDirection = value;} }
	
		[Description("The length along the curve")]
		public IfcPositiveLengthMeasure SegmentLength { get { return this._SegmentLength; } set { this._SegmentLength = value;} }
	
	
	}
	
}

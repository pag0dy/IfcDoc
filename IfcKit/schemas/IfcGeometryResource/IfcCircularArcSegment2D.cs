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
	public partial class IfcCircularArcSegment2D : IfcCurveSegment2D
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The radius of the circular arc")]
		[Required()]
		public IfcPositiveLengthMeasure Radius { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("(counter-clockwise or clockwise) as the orientation of the circular arc with Boolean=”true” being counter-clockwise, or “to the left\", and Boolean=”false” being clockwise, or “to the right”.")]
		[Required()]
		public IfcBoolean IsCCW { get; set; }
	
	
		public IfcCircularArcSegment2D(IfcCartesianPoint __StartPoint, IfcPlaneAngleMeasure __StartDirection, IfcPositiveLengthMeasure __SegmentLength, IfcPositiveLengthMeasure __Radius, IfcBoolean __IsCCW)
			: base(__StartPoint, __StartDirection, __SegmentLength)
		{
			this.Radius = __Radius;
			this.IsCCW = __IsCCW;
		}
	
	
	}
	
}

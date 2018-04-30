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
	public partial class IfcIndexedPolyCurve : IfcBoundedCurve
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("A list of points, provided by a point list of either two, or three dimensions, that is used to define the poly curve. If the attribute <em>Segments</em> is not provided, the poly curve is generated as a poly line by connecting the points in the order of their appearance in the point list. If the attribute <em>Segments</em> is provided, the segments determine, how the points are to be used to create straigth and circular arc segments.")]
		[Required()]
		public IfcCartesianPointList Points { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("List of straight line and circular arc segments, each providing a list of indices into the Cartesian point list. Indices should preserve consecutive connectivity between the segments, the start index of the next segment shall be identical with the end index of the previous segment.")]
		[MinLength(1)]
		public IList<IfcSegmentIndexSelect> Segments { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Indication of whether the curve intersects itself or not; this is for information only.")]
		public IfcBoolean? SelfIntersect { get; set; }
	
	
		public IfcIndexedPolyCurve(IfcCartesianPointList __Points, IfcSegmentIndexSelect[] __Segments, IfcBoolean? __SelfIntersect)
		{
			this.Points = __Points;
			this.Segments = new List<IfcSegmentIndexSelect>(__Segments);
			this.SelfIntersect = __SelfIntersect;
		}
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("6a61359a-e664-4f61-bb8c-2591f63d0f6d")]
	public partial class IfcIndexedPolyCurve : IfcBoundedCurve
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcCartesianPointList")]
		[Required()]
		IfcCartesianPointList _Points;
	
		[DataMember(Order=1)] 
		IList<IfcSegmentIndexSelect> _Segments = new List<IfcSegmentIndexSelect>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcBoolean? _SelfIntersect;
	
	
		[Description(@"A list of points, provided by a point list of either two, or three dimensions, that is used to define the poly curve. If the attribute <em>Segments</em> is not provided, the poly curve is generated as a poly line by connecting the points in the order of their appearance in the point list. If the attribute <em>Segments</em> is provided, the segments determine, how the points are to be used to create straigth and circular arc segments.")]
		public IfcCartesianPointList Points { get { return this._Points; } set { this._Points = value;} }
	
		[Description(@"List of straight line and circular arc segments, each providing a list of indices into the Cartesian point list. Indices should preserve consecutive connectivity between the segments, the start index of the next segment shall be identical with the end index of the previous segment.")]
		public IList<IfcSegmentIndexSelect> Segments { get { return this._Segments; } }
	
		[Description("Indication of whether the curve intersects itself or not; this is for information" +
	    " only.")]
		public IfcBoolean? SelfIntersect { get { return this._SelfIntersect; } set { this._SelfIntersect = value;} }
	
	
	}
	
}

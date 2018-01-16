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
	[Guid("27c04622-ab3d-4d08-9084-d06304e17b81")]
	public partial class IfcPolyline : IfcBoundedCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcCartesianPoint> _Points = new List<IfcCartesianPoint>();
	
	
		[Description("The points defining the polyline.")]
		public IList<IfcCartesianPoint> Points { get { return this._Points; } }
	
	
	}
	
}

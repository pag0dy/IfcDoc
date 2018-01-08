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
	[Guid("fa4d0f85-ebcc-4a94-aa4d-e9876009463c")]
	public partial class IfcRationalBSplineSurfaceWithKnots : IfcBSplineSurfaceWithKnots
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IList<Double> _WeightsData = new List<Double>();
	
	
		[Description("<EPM-HTML>\r\nThe weights associated with the control points in the rational case.\r" +
	    "\n</EPM-HTML>")]
		public IList<Double> WeightsData { get { return this._WeightsData; } }
	
	
	}
	
}

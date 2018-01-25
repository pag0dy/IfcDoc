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
	[Guid("0aa93253-baf3-4248-a574-c13cf6601bb9")]
	public enum IfcPreferredSurfaceCurveRepresentation
	{
		[Description("The curve in three-dimensional space is preferred")]
		CURVE3D = 1,
	
		[Description("The first pcurve is preferred")]
		PCURVE_S1 = 2,
	
		[Description("The second pcurve is preferred")]
		PCURVE_S2 = 3,
	
	}
}

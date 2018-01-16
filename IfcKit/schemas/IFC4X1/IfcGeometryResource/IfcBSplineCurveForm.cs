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
	[Guid("d3bb1eed-bb7b-4d0f-835a-70ad22becf57")]
	public enum IfcBSplineCurveForm
	{
		[Description("A connected sequence of line segments represented by degree 1 B-spline basis func" +
	    "tions.")]
		POLYLINE_FORM = 1,
	
		[Description("An arc of a circle, or a complete circle represented by a B-spline curve.")]
		CIRCULAR_ARC = 2,
	
		[Description("An arc of an ellipse, or a complete ellipse, represented by a B-spline curve.")]
		ELLIPTIC_ARC = 3,
	
		[Description("An arc of finite length of a parabola represented by a B-spline curve.")]
		PARABOLIC_ARC = 4,
	
		[Description("An arc of finite length of one branch of a hyperbola represented by a B-spline cu" +
	    "rve.")]
		HYPERBOLIC_ARC = 5,
	
		[Description("A B-spline curve for which no particular form is specified.")]
		UNSPECIFIED = 6,
	
	}
}

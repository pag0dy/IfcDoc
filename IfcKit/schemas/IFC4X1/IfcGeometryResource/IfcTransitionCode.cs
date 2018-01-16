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
	[Guid("00458893-b54e-41dd-a1ba-6b05ae0b935f")]
	public enum IfcTransitionCode
	{
		[Description("The segments do not join. This is permitted only at the boundary of the curve or\r" +
	    "\nsurface to indicate that it is not closed.")]
		DISCONTINUOUS = 1,
	
		[Description("The segments join but no condition on their tangents is implied.")]
		CONTINUOUS = 2,
	
		[Description("The segments join and their tangent vectors or tangent planes are parallel and\r\nh" +
	    "ave the same direction at the joint: equality of derivatives is not required.")]
		CONTSAMEGRADIENT = 3,
	
		[Description(@"For a curve, the segments join, their tangent vectors are parallel and in the same direction and their curvatures are equal at the joint: equality of derivatives is not required. For a surface this implies that the principle curvatures are the same and the principle directions are coincident along the
	common boundary.")]
		CONTSAMEGRADIENTSAMECURVATURE = 4,
	
	}
}

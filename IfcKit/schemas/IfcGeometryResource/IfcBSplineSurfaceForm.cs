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


namespace BuildingSmart.IFC.IfcGeometryResource
{
	public enum IfcBSplineSurfaceForm
	{
		[Description("A bounded portion of a plane represented by a B-spline surface of degree 1 in eac" +
	    "h parameter.")]
		PLANE_SURF = 1,
	
		[Description("A bounded portion of a cylindrical surface.")]
		CYLINDRICAL_SURF = 2,
	
		[Description("A bounded portion of the surface of a right circular cone.")]
		CONICAL_SURF = 3,
	
		[Description("A bounded portion of a sphere, or a complete sphere, represented by a B-spline su" +
	    "rface.")]
		SPHERICAL_SURF = 4,
	
		[Description("A torus, or portion of a torus, represented by a B-spline surface.")]
		TOROIDAL_SURF = 5,
	
		[Description("A bounded portion of a surface of revolution.")]
		SURF_OF_REVOLUTION = 6,
	
		[Description("A surface constructed from two parametric curves by joining with straight lines\r\n" +
	    "corresponding points with the same parameter value on each of the curves.")]
		RULED_SURF = 7,
	
		[Description("A special case of a ruled surface in which the second curve degenerates to a\r\nsin" +
	    "gle point; when represented by a B-spline surface all the control points along o" +
	    "ne edge will be coincident.")]
		GENERALISED_CONE = 8,
	
		[Description("A bounded portion of one of the class of surfaces of degree 2 in the variables x," +
	    " y and z.")]
		QUADRIC_SURF = 9,
	
		[Description("A bounded portion of a surface of linear extrusion represented by a B-spline surf" +
	    "ace of degree 1 in one of the parameters.")]
		SURF_OF_LINEAR_EXTRUSION = 10,
	
		[Description("A surface for which no particular form is specified.")]
		UNSPECIFIED = 11,
	
	}
}

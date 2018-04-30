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
	public enum IfcKnotType
	{
		[Description("The form of knots appropriate for a uniform B-spline curve.")]
		UNIFORM_KNOTS = 1,
	
		[Description("The form of knots appropriate for a quasi-uniform B-spline curve.")]
		QUASI_UNIFORM_KNOTS = 2,
	
		[Description("The form of knots appropriate for a piecewise Bezier curve.")]
		PIECEWISE_BEZIER_KNOTS = 3,
	
		[Description("The type of knots is not specified. This includes the case of non uniform knots.")]
		UNSPECIFIED = 4,
	
	}
}

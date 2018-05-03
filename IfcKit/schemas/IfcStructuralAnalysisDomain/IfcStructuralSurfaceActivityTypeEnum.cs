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


namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public enum IfcStructuralSurfaceActivityTypeEnum
	{
		[Description("The load has a constant value over its entire extent.")]
		CONST = 1,
	
		[Description("The load value is bilinearly distributed over the load\'s extent.")]
		BILINEAR = 2,
	
		[Description("The load is specified as a series of discrete load points.")]
		DISCRETE = 3,
	
		[Description("The load is specified by a series of iso-curves (level sets), i.e. curves at whic" +
	    "h the load value is constant.  These curves run perpendicularly to the load grad" +
	    "ient.")]
		ISOCONTOUR = 4,
	
		[Description("The load distribution is user-defined.")]
		USERDEFINED = -1,
	
		[Description("The load distribution is undefined.")]
		NOTDEFINED = 0,
	
	}
}

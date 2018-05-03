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
	public enum IfcStructuralCurveActivityTypeEnum
	{
		[Description("The load has a constant value over its entire extent.")]
		CONST = 1,
	
		[Description("The load value is linearly distributed over the load\'s extent.")]
		LINEAR = 2,
	
		[Description("The load consists of several consecutive linear sections.")]
		POLYGONAL = 3,
	
		[Description(@"The load consists of n consecutive sections of same length and is specified by n+1 load samples.  The interpolation type over the segments is not defined by this distribution type but may be qualified in <em>IfcObject.ObjectType</em> based on additional agreements.")]
		EQUIDISTANT = 4,
	
		[Description("The load value is distributed as a sinus half wave.")]
		SINUS = 5,
	
		[Description("The load value is distributed as a half wave described by a symmetric quadratic p" +
	    "arabola.")]
		PARABOLA = 6,
	
		[Description("The load is specified as a series of discrete load points.")]
		DISCRETE = 7,
	
		[Description("The load distribution is user-defined.")]
		USERDEFINED = -1,
	
		[Description("The load distribution is undefined.")]
		NOTDEFINED = 0,
	
	}
}

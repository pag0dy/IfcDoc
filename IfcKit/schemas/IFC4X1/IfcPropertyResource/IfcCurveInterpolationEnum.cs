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


namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("82eff39a-1dbe-47cb-8a8e-e93780baede4")]
	public enum IfcCurveInterpolationEnum
	{
		[Description("Indicates that values between the defined values are to be found by linear interp" +
	    "olation.")]
		LINEAR = 1,
	
		[Description("Indicates that values between the defined values are to be found by linear interp" +
	    "olation of the natural logarithm (base e) of the values.")]
		LOG_LINEAR = 2,
	
		[Description("Indicates that values between the defined values are to be found by linear interp" +
	    "olation of the Briggs\' logarithm (base 10) of the values.")]
		LOG_LOG = 3,
	
		[Description("No interpolation information is provided")]
		NOTDEFINED = 0,
	
	}
}

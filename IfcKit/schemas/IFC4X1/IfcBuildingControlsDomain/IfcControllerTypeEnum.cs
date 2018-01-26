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


namespace BuildingSmart.IFC.IfcBuildingControlsDomain
{
	[Guid("d4f441f7-4968-44b1-a3ee-e6471db32b55")]
	public enum IfcControllerTypeEnum
	{
		[Description("Output increases or decreases at a constant or accelerating rate.")]
		FLOATING = 1,
	
		[Description("Output is programmable such as Discrete Digital Control (DDC).")]
		PROGRAMMABLE = 2,
	
		[Description("Output is proportional to the control error and optionally time integral and deri" +
	    "vative.")]
		PROPORTIONAL = 3,
	
		[Description("Output is discrete value, can be one of three or more values.")]
		MULTIPOSITION = 4,
	
		[Description("Output can be either on or off.")]
		TWOPOSITION = 5,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

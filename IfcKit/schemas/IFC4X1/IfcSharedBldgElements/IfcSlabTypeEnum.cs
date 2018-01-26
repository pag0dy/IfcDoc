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


namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("fdddf910-9941-481d-9dac-fce23d260ae1")]
	public enum IfcSlabTypeEnum
	{
		[Description("The slab is used to represent a floor slab.")]
		FLOOR = 1,
	
		[Description("The slab is used to represent a roof slab (either flat or sloped).")]
		ROOF = 2,
	
		[Description("The slab is used to represent a landing within a stair or ramp.")]
		LANDING = 3,
	
		[Description("The slab is used to represent a floor slab against the ground (and thereby being " +
	    "a part of the foundation). Another name is mat foundation.")]
		BASESLAB = 4,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

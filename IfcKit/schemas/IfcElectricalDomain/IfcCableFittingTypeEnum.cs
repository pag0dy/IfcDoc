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


namespace BuildingSmart.IFC.IfcElectricalDomain
{
	public enum IfcCableFittingTypeEnum
	{
		[Description("A fitting that joins two cable segments of the same connector type (though potent" +
	    "ially different gender).")]
		CONNECTOR = 1,
	
		[Description("A fitting that begins a cable segment at a non-electrical element such as a groun" +
	    "ding clamp attached to a pipe.")]
		ENTRY = 2,
	
		[Description("A fitting that ends a cable segment at a non-electrical element such as a groundi" +
	    "ng clamp attached to a pipe or to the ground.")]
		EXIT = 3,
	
		[Description("A fitting that joins three or more segments of arbitrary connector types for sign" +
	    "al splitting or multiplexing.")]
		JUNCTION = 4,
	
		[Description("A fitting that joins two cable segments of different connector types.")]
		TRANSITION = 5,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

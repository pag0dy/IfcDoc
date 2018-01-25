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

using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("f7d964ab-4f39-49b5-8e24-a0b2bf6967b3")]
	public enum IfcAirTerminalBoxTypeEnum
	{
		[Description("Terminal box does not include a means to reset the volume automatically to an out" +
	    "side signal such as thermostat.")]
		CONSTANTFLOW = 1,
	
		[Description("Terminal box includes a means to reset the volume automatically to a different co" +
	    "ntrol point in response to an outside signal such as thermostat: air-flow rate d" +
	    "epends on supply pressure.")]
		VARIABLEFLOWPRESSUREDEPENDANT = 2,
	
		[Description("Terminal box includes a means to reset the volume automatically to a different co" +
	    "ntrol point in response to an outside signal such as thermostat: air-flow rate i" +
	    "s independant of supply pressure.")]
		VARIABLEFLOWPRESSUREINDEPENDANT = 3,
	
		[Description("User-defined terminal box.")]
		USERDEFINED = -1,
	
		[Description("Undefined terminal box.")]
		NOTDEFINED = 0,
	
	}
}

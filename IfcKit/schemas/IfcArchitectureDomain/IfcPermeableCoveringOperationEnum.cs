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


namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	public enum IfcPermeableCoveringOperationEnum
	{
		[Description("Protective screen of metal bars or wires.")]
		GRILL = 1,
	
		[Description("Set of fixed or movable strips of wood, metal, etc. arranged to let air in while " +
	    "keeping light or rain out.")]
		LOUVER = 2,
	
		[Description("Upright, fixed or movable, sometimes folding framework used for protection agains" +
	    "t heat, light, access or similar.")]
		SCREEN = 3,
	
		[Description("User defined permeable covering type.")]
		USERDEFINED = -1,
	
		[Description("No information available.")]
		NOTDEFINED = 0,
	
	}
}

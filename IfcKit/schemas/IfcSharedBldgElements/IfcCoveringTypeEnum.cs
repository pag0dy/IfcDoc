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


namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public enum IfcCoveringTypeEnum
	{
		[Description("The covering is used torepresent a ceiling.")]
		CEILING = 1,
	
		[Description("The covering is used to represent a flooring.")]
		FLOORING = 2,
	
		[Description("The covering is used to represent a cladding.")]
		CLADDING = 3,
	
		[Description("The covering is used to represent a roof covering.")]
		ROOFING = 4,
	
		[Description("The covering is used to represent a molding being a strip of material to cover th" +
	    "e transition of surfaces (often between wall cladding and ceiling).")]
		MOLDING = 5,
	
		[Description("The covering is used to represent a skirting board being a strip of material to c" +
	    "over the transition between the wall cladding and the flooring.")]
		SKIRTINGBOARD = 6,
	
		[Description("The covering is used to insulate an element for thermal or acoustic purposes.")]
		INSULATION = 7,
	
		[Description("An impervious layer that could be used for e.g. roof covering (below tiling - tha" +
	    "t may be known as sarking etc.) or as a damp proof course membrane.")]
		MEMBRANE = 8,
	
		[Description("The covering is used to isolate a distribution element from a space in which it i" +
	    "s contained.")]
		SLEEVING = 9,
	
		[Description("The covering is used for wrapping particularly of distribution elements using tap" +
	    "e.")]
		WRAPPING = 10,
	
		[Description("User defined type of covering.")]
		USERDEFINED = -1,
	
		[Description("Undefined type of covering.")]
		NOTDEFINED = 0,
	
	}
}

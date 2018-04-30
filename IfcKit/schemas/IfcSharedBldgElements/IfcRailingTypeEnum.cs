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
	public enum IfcRailingTypeEnum
	{
		[Description("A type of railing designed to serve as an optional structural support for loads a" +
	    "pplied by human occupants (at hand height). Generally located adjacent to ramps " +
	    "and stairs. Generally floor or wall mounted.")]
		HANDRAIL = 1,
	
		[Description("A type of railing designed to guard human occupants from falling off a stair, ram" +
	    "p or landing where there is a vertical drop at the edge of such floors/landings." +
	    "")]
		GUARDRAIL = 2,
	
		[Description("Similar to the definitions of a guardrail except the location is at the edge of a" +
	    " floor, rather then a stair or ramp. Examples are balustrates at roof-tops or ba" +
	    "lconies.")]
		BALUSTRADE = 3,
	
		[Description("User-defined railing element, a term to identify the user type is given by the at" +
	    "tribute <em>IfcRailing.ObjectType.</em>")]
		USERDEFINED = -1,
	
		[Description("Undefined railing element, no type information available.")]
		NOTDEFINED = 0,
	
	}
}

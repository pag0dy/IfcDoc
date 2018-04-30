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


namespace BuildingSmart.IFC.IfcHvacDomain
{
	public enum IfcPumpTypeEnum
	{
		[Description("A Circulator pump is a generic low-pressure, low-capacity pump. It may have a wet" +
	    " rotor and may be driven by a flexible-coupled motor.")]
		CIRCULATOR = 1,
	
		[Description("An End Suction pump, when mounted horizontally, has a single horizontal inlet on " +
	    "the impeller suction side and a vertical discharge. It may have a direct or clos" +
	    "e-coupled motor.")]
		ENDSUCTION = 2,
	
		[Description("A Split Case pump, when mounted horizontally, has an inlet and outlet on each sid" +
	    "e of the impeller. The impeller can be easily accessed by removing the front of " +
	    "the impeller casing. It may have a direct or close-coupled motor.")]
		SPLITCASE = 3,
	
		[Description("A pump designed to be immersed in a fluid, typically a collection tank.")]
		SUBMERSIBLEPUMP = 4,
	
		[Description("A pump designed to sit above a collection tank with a suction inlet extending int" +
	    "o the tank.")]
		SUMPPUMP = 5,
	
		[Description("A Vertical Inline pump has the pump and motor close-coupled on the pump casing. T" +
	    "he pump depends on the connected, horizontal piping for support, with the suctio" +
	    "n and discharge along the piping axis.")]
		VERTICALINLINE = 6,
	
		[Description("A Vertical Turbine pump has a motor mounted vertically on the pump casing for eit" +
	    "her\r\n                wet-pit sump mounting or dry-well mounting.")]
		VERTICALTURBINE = 7,
	
		[Description("User-defined pump type.")]
		USERDEFINED = -1,
	
		[Description("Pump type has not been defined.")]
		NOTDEFINED = 0,
	
	}
}

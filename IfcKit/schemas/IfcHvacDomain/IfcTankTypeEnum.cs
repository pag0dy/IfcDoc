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
	public enum IfcTankTypeEnum
	{
		[Description("An arbitrary open tank type.")]
		BASIN = 1,
	
		[Description(@"An open container that breaks the hydraulic pressure in a distribution system, typically located between the fluid reservoir and the fluid supply points. A typical break pressure tank allows the flow to discharge into the atmosphere, thereby reducing its hydrostatic pressure to zero.")]
		BREAKPRESSURE = 2,
	
		[Description(@"A closed container used in a closed fluid distribution system to mitigate the effects of thermal expansion or water hammer. The tank is typically constructed with a diaphragm dividing the tank into two sections, with fluid on one side of the diaphragm and air on the other. One example application is when connected to the primary circuit of a hot water system to accommodate the increase in volume of the water when it is heated.")]
		EXPANSION = 3,
	
		[Description("An open tank that is used for both storage and thermal expansion. A typical examp" +
	    "le is a tank used to store make-up water at ambient pressure for supply to a hot" +
	    " water system, simultaneously accommodating increases in volume of the water whe" +
	    "n heated.")]
		FEEDANDEXPANSION = 4,
	
		[Description("A closed container used for storing fluids or gases at a pressure different from " +
	    "the ambient pressure. A pressure vessel is typically rated by an authority havin" +
	    "g jurisdiction for the operational pressure.")]
		PRESSUREVESSEL = 5,
	
		[Description("An open or closed containter used for storing a fluid at ambient pressure and fro" +
	    "m which it can be supplied to the fluid distribution system. There are many exam" +
	    "ples of storage tanks, such as potable water storage tanks, fuel storage tanks, " +
	    "etc.")]
		STORAGE = 6,
	
		[Description("An arbitrary closed tank type.")]
		VESSEL = 7,
	
		[Description("User-defined tank type.")]
		USERDEFINED = -1,
	
		[Description("Undefined tank type.")]
		NOTDEFINED = 0,
	
	}
}

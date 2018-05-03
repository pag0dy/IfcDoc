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


namespace BuildingSmart.IFC.IfcPlumbingFireProtectionDomain
{
	public enum IfcWasteTerminalTypeEnum
	{
		[Description("Pipe fitting, set into the floor, that retains liquid to prevent the passage of f" +
	    "oul air")]
		FLOORTRAP = 1,
	
		[Description("Pipe fitting, set into the floor, that collects waste water and discharges it to " +
	    "a separate trap.")]
		FLOORWASTE = 2,
	
		[Description("Pipe fitting or assembly of fittings to receive surface water or waste water, fit" +
	    "ted with a grating or sealed cover.")]
		GULLYSUMP = 3,
	
		[Description("Pipe fitting or assembly of fittings that receives surface water or waste water; " +
	    "fitted with a grating or sealed cover that discharges water through a trap.")]
		GULLYTRAP = 4,
	
		[Description("Pipe fitting, set into the roof, that collects rainwater for discharge into the r" +
	    "ainwater system.")]
		ROOFDRAIN = 5,
	
		[Description("Electrically operated device that reduces kitchen or other waste into fragments s" +
	    "mall enough to be flushed into a drainage system.")]
		WASTEDISPOSALUNIT = 6,
	
		[Description("Pipe fitting, set adjacent to a sanitary terminal, that retains liquid to prevent" +
	    " the passage of foul air.")]
		WASTETRAP = 7,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

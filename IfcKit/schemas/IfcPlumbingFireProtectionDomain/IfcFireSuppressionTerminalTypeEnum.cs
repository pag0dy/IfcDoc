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
	public enum IfcFireSuppressionTerminalTypeEnum
	{
		[Description("Symmetrical pipe fitting that unites two or more inlets into a single pipe. A bre" +
	    "eching inlet may be used on either a wet or dry riser. Used by fire services per" +
	    "sonnel for fast connection of fire appliance hose reels. May also be used for fo" +
	    "am.")]
		BREECHINGINLET = 1,
	
		[Description("Device, fitted to a pipe, through which a temporary supply of water may be provid" +
	    "ed.  May also be termed a stand pipe.")]
		FIREHYDRANT = 2,
	
		[Description("A supporting framework on which a hose may be wound.")]
		HOSEREEL = 3,
	
		[Description("Device for sprinkling water from a pipe under pressure over an area.")]
		SPRINKLER = 4,
	
		[Description("Device attached to a sprinkler to deflect the water flow into a spread pattern to" +
	    " cover the required area.")]
		SPRINKLERDEFLECTOR = 5,
	
		[Description("User-defined type")]
		USERDEFINED = -1,
	
		[Description("Underined type.")]
		NOTDEFINED = 0,
	
	}
}

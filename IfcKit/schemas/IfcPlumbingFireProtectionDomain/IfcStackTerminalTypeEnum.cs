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
	public enum IfcStackTerminalTypeEnum
	{
		[Description("Guard cage, typically wire mesh, at the top of the stack preventing access by bir" +
	    "ds.")]
		BIRDCAGE = 1,
	
		[Description("A cowling placed at the top of a stack to eliminate downdraft.")]
		COWL = 2,
	
		[Description("A box placed at the top of a rainwater downpipe to catch rainwater from guttering" +
	    ".")]
		RAINWATERHOPPER = 3,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

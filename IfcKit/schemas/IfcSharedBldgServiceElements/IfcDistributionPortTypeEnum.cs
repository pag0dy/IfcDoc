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


namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	public enum IfcDistributionPortTypeEnum
	{
		[Description("Connection to cable segment or fitting for distribution of electricity.")]
		CABLE = 1,
	
		[Description("Connection to cable carrier segment or fitting for enclosing cables.")]
		CABLECARRIER = 2,
	
		[Description("Connection to duct segment or fitting for distribution of air.")]
		DUCT = 3,
	
		[Description("Connection to pipe segment or fitting for distribution of solid, liquid, or gas.")]
		PIPE = 4,
	
		[Description("User-defined port type.")]
		USERDEFINED = -1,
	
		[Description("Undefined port type.")]
		NOTDEFINED = 0,
	
	}
}

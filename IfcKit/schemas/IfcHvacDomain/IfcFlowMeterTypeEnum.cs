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
	public enum IfcFlowMeterTypeEnum
	{
		[Description("An electric meter or energy meter is a device that measures the amount of electri" +
	    "cal energy supplied to or produced by a residence, business or machine.")]
		ENERGYMETER = 1,
	
		[Description("A device that measures the quantity of a gas or fuel.")]
		GASMETER = 2,
	
		[Description("A device that measures the quantity of oil.")]
		OILMETER = 3,
	
		[Description("A device that measures the quantity of water.")]
		WATERMETER = 4,
	
		[Description("User-defined meter type")]
		USERDEFINED = -1,
	
		[Description("Undefined meter type")]
		NOTDEFINED = 0,
	
	}
}

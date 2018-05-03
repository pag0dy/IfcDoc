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


namespace BuildingSmart.IFC.IfcElectricalDomain
{
	public enum IfcElectricFlowStorageDeviceTypeEnum
	{
		[Description("A device for storing energy in chemical form so that it can be released as electr" +
	    "ical energy.")]
		BATTERY = 1,
	
		[Description("A device that stores electrical energy when an external power supply is present u" +
	    "sing the electrical property of capacitance.")]
		CAPACITORBANK = 2,
	
		[Description("A device that constantly injects currents that precisely correspond to the harmon" +
	    "ic components drawn by the load.")]
		HARMONICFILTER = 3,
	
		INDUCTORBANK = 4,
	
		[Description("A device that provides a time limited alternative source of power supply in the e" +
	    "vent of failure of the main supply.")]
		UPS = 5,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

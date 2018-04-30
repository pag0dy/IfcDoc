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
	public enum IfcElectricTimeControlTypeEnum
	{
		[Description("A control that causes action to occur at set times.")]
		TIMECLOCK = 1,
	
		[Description("A control that causes action to occur following a set duration.")]
		TIMEDELAY = 2,
	
		[Description("Electromagnetically operated contactor for making or breaking a control circuit.")]
		RELAY = 3,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

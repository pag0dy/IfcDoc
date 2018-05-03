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
	public enum IfcSwitchingDeviceTypeEnum
	{
		[Description("An electrical device used to control the flow of power in a circuit on or off.")]
		CONTACTOR = 1,
	
		[Description("A dimmer switch has variable positions, and may adjust electrical power or other " +
	    "setting (according to the switched port type).")]
		DIMMERSWITCH = 2,
	
		[Description("An emergency stop device acts to remove as quickly as possible any danger that ma" +
	    "y have arisen unexpectedly.")]
		EMERGENCYSTOP = 3,
	
		[Description("A set of buttons or switches, each potentially applicable to a different device.")]
		KEYPAD = 4,
	
		[Description("A momentary switch has no position, and may trigger some action to occur.")]
		MOMENTARYSWITCH = 5,
	
		[Description("A selector switch has multiple positions, and may change the source or level of p" +
	    "ower or other setting (according to the switched port type).")]
		SELECTORSWITCH = 6,
	
		[Description("A starter is a switch which in the closed position controls the application of po" +
	    "wer to an electrical device.")]
		STARTER = 7,
	
		[Description("A switch disconnector is a switch which in the open position satisfies the isolat" +
	    "ing requirements specified for a disconnector.")]
		SWITCHDISCONNECTOR = 8,
	
		[Description("A toggle switch has two positions, and may enable or isolate electrical power or " +
	    "other setting (according to the switched port type).")]
		TOGGLESWITCH = 9,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

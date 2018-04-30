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


namespace BuildingSmart.IFC.IfcBuildingControlsDomain
{
	public enum IfcUnitaryControlElementTypeEnum
	{
		[Description("A control element at which alarms are annunciated.")]
		ALARMPANEL = 1,
	
		[Description("A control element at which devices that control or monitor the operation of a sit" +
	    "e, building or part of a building are located")]
		CONTROLPANEL = 2,
	
		[Description("A control element at which the detection of gas is annunciated.")]
		GASDETECTIONPANEL = 3,
	
		[Description("A control element at which equipment operational status, condition, safety state " +
	    "or other required parameters are indicated.")]
		INDICATORPANEL = 4,
	
		[Description("A control element at which information that is available elsewhere is repeated or" +
	    " \'mimicked\'.")]
		MIMICPANEL = 5,
	
		[Description("A control element that senses and regulates the humidity of a system or space so " +
	    "that the humidity is maintained near a desired setpoint.")]
		HUMIDISTAT = 6,
	
		[Description("A control element that senses and regulates the temperature of an element, system" +
	    " or space so that the temperature is maintained near a desired setpoint.")]
		THERMOSTAT = 7,
	
		[Description("A control element that senses multiple climate properties such as temperature, hu" +
	    "midity, pressure, wind, and rain.")]
		WEATHERSTATION = 8,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

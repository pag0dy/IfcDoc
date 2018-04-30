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
	public enum IfcTransformerTypeEnum
	{
		[Description("A transformer that changes the current between circuits.")]
		CURRENT = 1,
	
		[Description("A transformer that changes the frequency between circuits.")]
		FREQUENCY = 2,
	
		[Description("A transformer that converts from direct current (DC) to alternating current (AC)." +
	    "")]
		INVERTER = 3,
	
		[Description("A transformer that converts from alternating current (AC) to direct current (DC)." +
	    "")]
		RECTIFIER = 4,
	
		[Description("A transformer that changes the voltage between circuits.")]
		VOLTAGE = 5,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

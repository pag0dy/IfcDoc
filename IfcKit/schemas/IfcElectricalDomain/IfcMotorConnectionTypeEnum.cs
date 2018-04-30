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
	public enum IfcMotorConnectionTypeEnum
	{
		[Description("An indirect connection made through the medium of a shaped, flexible continuous l" +
	    "oop.")]
		BELTDRIVE = 1,
	
		[Description("An indirect connection made through the medium of the viscosity of a fluid.")]
		COUPLING = 2,
	
		[Description("A direct, physical connection made between the motor and the driven device.")]
		DIRECTDRIVE = 3,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

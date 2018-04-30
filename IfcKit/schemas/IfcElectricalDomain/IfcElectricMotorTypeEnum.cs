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
	public enum IfcElectricMotorTypeEnum
	{
		[Description("A motor using either generated or rectified Direct Current (DC) power.")]
		DC = 1,
	
		[Description(@"An alternating current motor in which the primary winding on one member (usually the stator) is connected to the power source and a secondary winding or a squirrel-cage secondary winding on the other member (usually the rotor) carries the induced current. There is no physical electrical connection to the secondary winding, its current is induced.")]
		INDUCTION = 2,
	
		[Description("A two or three-phase induction motor in which the windings, one for each phase, a" +
	    "re evenly divided by the same number of electrical degrees.")]
		POLYPHASE = 3,
	
		[Description("A synchronous motor with a special rotor design which directly lines the rotor up" +
	    " with the rotating magnetic field of the stator, allowing for no slip under load" +
	    ".")]
		RELUCTANCESYNCHRONOUS = 4,
	
		[Description("A motor that operates at a constant speed up to full load. The rotor speed is equ" +
	    "al to the speed of the rotating magnetic field of the stator; there is no slip.")]
		SYNCHRONOUS = 5,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

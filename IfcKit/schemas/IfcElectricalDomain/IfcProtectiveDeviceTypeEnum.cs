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
	public enum IfcProtectiveDeviceTypeEnum
	{
		[Description(@"A mechanical switching device capable of making, carrying, and breaking currents under normal circuit conditions and also making, carrying for a specified time and breaking, current under specified abnormal circuit conditions such as those of short circuit.")]
		CIRCUITBREAKER = 1,
	
		[Description("A device that opens, closes, or isolates a circuit and has short circuit protecti" +
	    "on but no overload protection.  It attempts to break the circuit when there is a" +
	    " leakage of current from phase to earth, by measuring voltage on the earth condu" +
	    "ctor.")]
		EARTHLEAKAGECIRCUITBREAKER = 2,
	
		[Description("A safety device used to open or close a circuit when there is no current. Used to" +
	    " isolate a part of a circuit, a machine, a part of an overhead line or an underg" +
	    "round line so that maintenance can be safely conducted.")]
		EARTHINGSWITCH = 3,
	
		[Description("A device that will electrically open the circuit after a period of prolonged, abn" +
	    "ormal current flow.")]
		FUSEDISCONNECTOR = 4,
	
		[Description(@"A device that opens, closes, or isolates a circuit and has short circuit and overload protection.  It attempts to break the circuit when there is a difference in current between any two phases.  May also be referred to as 'Ground Fault Interupter (GFI)' or 'Ground Fault Circuit Interuptor (GFCI)'")]
		RESIDUALCURRENTCIRCUITBREAKER = 5,
	
		[Description("A device that opens, closes or isolates a circuit and has no short circuit or ove" +
	    "rload protection.  May also be identified as a \'ground fault switch\'.")]
		RESIDUALCURRENTSWITCH = 6,
	
		[Description("A high voltage surge protection device.")]
		VARISTOR = 7,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

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
	public enum IfcAirToAirHeatRecoveryTypeEnum
	{
		[Description("Heat exchanger with moving parts and alternate layers of plates, separated and se" +
	    "aled from the exhaust and supply air stream passages with primary air entering a" +
	    "t secondary air outlet location and exiting at secondary air inlet location.")]
		FIXEDPLATECOUNTERFLOWEXCHANGER = 1,
	
		[Description("Heat exchanger with moving parts and alternate layers of plates, separated and se" +
	    "aled from the exhaust and supply air stream passages with secondary air flow in " +
	    "the direction perpendicular to primary air flow.")]
		FIXEDPLATECROSSFLOWEXCHANGER = 2,
	
		[Description("Heat exchanger with moving parts and alternate layers of plates, separated and se" +
	    "aled from the exhaust and supply air stream passages with primary air entering a" +
	    "t secondary air inlet location and exiting at secondary air outlet location.")]
		FIXEDPLATEPARALLELFLOWEXCHANGER = 3,
	
		[Description("A heat wheel with a revolving cylinder filled with an air-permeable medium having" +
	    " a large internal surface area.")]
		ROTARYWHEEL = 4,
	
		[Description("A typical coil energy recovery loop places extended surface, finned tube water co" +
	    "ils in the supply and exhaust airstreams of a building.")]
		RUNAROUNDCOILLOOP = 5,
	
		[Description("A passive energy recovery device with a heat pipe divided into evaporator and con" +
	    "denser sections.")]
		HEATPIPE = 6,
	
		[Description("An air-to-liquid, liquid-to-air enthalpy recovery system with a sorbent liquid ci" +
	    "rculates continuously between supply and exhaust airstreams, alternately contact" +
	    "ing both airstreams directly in contactor towers.")]
		TWINTOWERENTHALPYRECOVERYLOOPS = 7,
	
		[Description(@"Sealed systems that consist of an evaporator, a condenser, interconnecting piping, and an intermediate working fluid that is present in both liquid and vapor phases where the evaporator and the condenser are usually at opposite ends of a bundle of straight, individual thermosiphon tubes and the exhaust and supply ducts are adjacent to each other.")]
		THERMOSIPHONSEALEDTUBEHEATEXCHANGERS = 8,
	
		[Description(@"Sealed systems that consist of an evaporator, a condenser, interconnecting piping, and an intermediate working fluid that is present in both liquid and vapor phases where the evaporator and condensor coils are installed independently in the ducts and are interconnected by the working fluid piping.")]
		THERMOSIPHONCOILTYPEHEATEXCHANGERS = 9,
	
		[Description("User-defined air to air heat recovery type.")]
		USERDEFINED = -1,
	
		[Description("Undefined air to air heat recovery type.")]
		NOTDEFINED = 0,
	
	}
}

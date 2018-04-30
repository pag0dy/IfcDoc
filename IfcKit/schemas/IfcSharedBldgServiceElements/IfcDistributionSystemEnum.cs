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


namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	public enum IfcDistributionSystemEnum
	{
		[Description("Conditioned air distribution system for purposes of maintaining a temperature ran" +
	    "ge within one or more spaces.")]
		AIRCONDITIONING = 1,
	
		[Description("A transport of a single media source, having audio and/or video streams.")]
		AUDIOVISUAL = 2,
	
		[Description("Arbitrary chemical further qualified by property set, such as for medical or indu" +
	    "strial use.")]
		CHEMICAL = 3,
	
		[Description("Nonpotable chilled water, such as circulated through an evaporator.")]
		CHILLEDWATER = 4,
	
		COMMUNICATION = 5,
	
		[Description("Compressed air system.")]
		COMPRESSEDAIR = 6,
	
		[Description("Nonpotable water, such as circulated through a condenser.")]
		CONDENSERWATER = 7,
	
		[Description("A transport or network dedicated to control system usage.")]
		CONTROL = 8,
	
		[Description("Arbitrary supply of substances.")]
		CONVEYING = 9,
	
		[Description("A network having general-purpose usage.")]
		DATA = 10,
	
		[Description("Arbitrary disposal of substances.")]
		DISPOSAL = 11,
	
		[Description("Unheated potable water distribution system.")]
		DOMESTICCOLDWATER = 12,
	
		[Description("Heated potable water distribution system.")]
		DOMESTICHOTWATER = 13,
	
		[Description("Drainage collection system.")]
		DRAINAGE = 14,
	
		[Description("A path for equipotential bonding, conducting current to the ground.")]
		EARTHING = 15,
	
		[Description("A circuit for delivering electrical power.")]
		ELECTRICAL = 16,
	
		[Description("An amplified audio signal such as for loudspeakers.")]
		ELECTROACOUSTIC = 17,
	
		[Description("Exhaust air collection system for removing stale or noxious air from one or more " +
	    "spaces.")]
		EXHAUST = 18,
	
		[Description("Fire protection sprinkler system.")]
		FIREPROTECTION = 19,
	
		[Description("Arbitrary supply of fuel.")]
		FUEL = 20,
	
		[Description("Gas-phase materials such as methane or natural gas.")]
		GAS = 21,
	
		[Description("Hazardous material or fluid collection system.")]
		HAZARDOUS = 22,
	
		[Description("Water or steam heated from a boiler and circulated through radiators.")]
		HEATING = 23,
	
		[Description("A circuit dedicated for lighting, such as a fixture having sockets for lamps.")]
		LIGHTING = 24,
	
		[Description("A path for conducting lightning current to the ground.")]
		LIGHTNINGPROTECTION = 25,
	
		[Description("Items consumed and discarded, commonly known as trash or garbage.")]
		MUNICIPALSOLIDWASTE = 26,
	
		[Description("Oil distribution system.")]
		OIL = 27,
	
		[Description("Operating supplies system.")]
		OPERATIONAL = 28,
	
		[Description("A path for power generation.")]
		POWERGENERATION = 29,
	
		[Description("Rainwater resulting from precipitation which directly falls on a parcel.")]
		RAINWATER = 30,
	
		[Description("Refrigerant distribution system for purposes of fulfilling all or parts of a refr" +
	    "igeration cycle.")]
		REFRIGERATION = 31,
	
		[Description("A transport or network dedicated to security system usage.")]
		SECURITY = 32,
	
		[Description("Sewage collection system.")]
		SEWAGE = 33,
	
		[Description("A raw analog signal, such as modulated data or measurements from sensors.")]
		SIGNAL = 34,
	
		[Description("Stormwater resulting from precipitation which runs off or travels over the ground" +
	    " surface.")]
		STORMWATER = 35,
	
		[Description("A transport or network dedicated to telephone system usage.")]
		TELEPHONE = 36,
	
		[Description("A transport of multiple media sources such as analog cable TV, satellite TV, or o" +
	    "ver-the-air TV.")]
		TV = 37,
	
		[Description("Vacuum distribution system.")]
		VACUUM = 38,
	
		[Description("Vent system for wastewater piping systems.")]
		VENT = 39,
	
		[Description("Ventilation air distribution system involved in either the exchange of air to the" +
	    " outside as well as circulation of air within a building.")]
		VENTILATION = 40,
	
		[Description("Water adversely affected in quality by anthropogenic influence, possibly originat" +
	    "ing from sewage, drainage, or other source.")]
		WASTEWATER = 41,
	
		[Description("Arbitrary water supply.")]
		WATERSUPPLY = 42,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

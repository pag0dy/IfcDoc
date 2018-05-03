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
	public enum IfcHumidifierTypeEnum
	{
		[Description("Water vapor is added into the airstream through direct steam injection.")]
		STEAMINJECTION = 1,
	
		[Description("Water vapor is added into the airstream through adiabatic evaporation using an ai" +
	    "r washing element.")]
		ADIABATICAIRWASHER = 2,
	
		[Description("Water vapor is added into the airstream through adiabatic evaporation using a pan" +
	    ".")]
		ADIABATICPAN = 3,
	
		[Description("Water vapor is added into the airstream through adiabatic evaporation using a wet" +
	    "ted element.")]
		ADIABATICWETTEDELEMENT = 4,
	
		[Description("Water vapor is added into the airstream through adiabatic evaporation using an at" +
	    "omizing element.")]
		ADIABATICATOMIZING = 5,
	
		[Description("Water vapor is added into the airstream through adiabatic evaporation using an ul" +
	    "trasonic element.")]
		ADIABATICULTRASONIC = 6,
	
		[Description("Water vapor is added into the airstream through adiabatic evaporation using a rig" +
	    "id media.")]
		ADIABATICRIGIDMEDIA = 7,
	
		[Description("Water vapor is added into the airstream through adiabatic evaporation using a com" +
	    "pressed air nozzle.")]
		ADIABATICCOMPRESSEDAIRNOZZLE = 8,
	
		[Description("Water vapor is added into the airstream through water heated evaporation using an" +
	    " electric heater.")]
		ASSISTEDELECTRIC = 9,
	
		[Description("Water vapor is added into the airstream through water heated evaporation using a " +
	    "natural gas heater.")]
		ASSISTEDNATURALGAS = 10,
	
		[Description("Water vapor is added into the airstream through water heated evaporation using a " +
	    "propane heater.")]
		ASSISTEDPROPANE = 11,
	
		[Description("Water vapor is added into the airstream through water heated evaporation using a " +
	    "butane heater.")]
		ASSISTEDBUTANE = 12,
	
		[Description("Water vapor is added into the airstream through water heated evaporation using a " +
	    "steam heater.")]
		ASSISTEDSTEAM = 13,
	
		[Description("User-defined humidifier type.")]
		USERDEFINED = -1,
	
		[Description("Undefined humidifier type.")]
		NOTDEFINED = 0,
	
	}
}

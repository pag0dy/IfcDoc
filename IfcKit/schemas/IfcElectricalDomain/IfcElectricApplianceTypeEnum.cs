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
	public enum IfcElectricApplianceTypeEnum
	{
		[Description("An appliance that has the primary function of washing dishes.")]
		DISHWASHER = 1,
	
		[Description("An electrical appliance that has the primary function of cooking food (including " +
	    "oven, hob, grill).")]
		ELECTRICCOOKER = 2,
	
		[Description("An electrical appliance that is used occasionally to provide heat. A freestanding" +
	    " electric heater is a \'plugged\' appliance whose load may be removed from an elec" +
	    "tric circuit.")]
		FREESTANDINGELECTRICHEATER = 3,
	
		[Description("An electrical appliance that is used occasionally to provide ventilation. A frees" +
	    "tanding fan is a \'plugged\' appliance whose load may be removed from an electric " +
	    "circuit.")]
		FREESTANDINGFAN = 4,
	
		[Description("A small, local electrical appliance for heating water. A freestanding water heate" +
	    "r is a \'plugged\' appliance whose load may be removed from an electric circuit.")]
		FREESTANDINGWATERHEATER = 5,
	
		[Description("A small, local electrical appliance for cooling water. A freestanding water coole" +
	    "r is a \'plugged\' appliance whose load may be removed from an electric circuit.")]
		FREESTANDINGWATERCOOLER = 6,
	
		[Description("An electrical appliance that has the primary function of storing food at temperat" +
	    "ures below the freezing point of water.")]
		FREEZER = 7,
	
		[Description("An electrical appliance that combines the functions of a freezer and a refrigerat" +
	    "or through the provision of separate compartments.")]
		FRIDGE_FREEZER = 8,
	
		[Description("An electrical appliance that has the primary function of drying hands.")]
		HANDDRYER = 9,
	
		[Description("A specialized appliance used in commercial kitchens such as a mixer.")]
		KITCHENMACHINE = 10,
	
		[Description("An electrical appliance that has the primary function of cooking food using micro" +
	    "waves.")]
		MICROWAVE = 11,
	
		[Description("A machine that has the primary function of reproduction of printed matter.")]
		PHOTOCOPIER = 12,
	
		[Description("An electrical appliance that has the primary function of storing food at low temp" +
	    "erature but above the freezing point of water.")]
		REFRIGERATOR = 13,
	
		[Description("An electrical appliance that has the primary function of drying clothes.")]
		TUMBLEDRYER = 14,
	
		[Description("An appliance that stores and vends goods including food, drink and goods of vario" +
	    "us types.")]
		VENDINGMACHINE = 15,
	
		[Description("An appliance that has the primary function of washing clothes.")]
		WASHINGMACHINE = 16,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

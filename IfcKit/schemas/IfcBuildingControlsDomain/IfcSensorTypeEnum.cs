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
	public enum IfcSensorTypeEnum
	{
		[Description("A device that senses or detects carbon monoxide.")]
		COSENSOR = 1,
	
		[Description("A device that senses or detects carbon dioxide.")]
		CO2SENSOR = 2,
	
		[Description("A device that senses or detects electrical conductance.")]
		CONDUCTANCESENSOR = 3,
	
		[Description("A device that senses or detects contact, such as for detecting if a door is close" +
	    "d.")]
		CONTACTSENSOR = 4,
	
		[Description("A device that senses or detects fire")]
		FIRESENSOR = 5,
	
		[Description("A device that senses or detects flow in a fluid.")]
		FLOWSENSOR = 6,
	
		[Description("A device that senses or detects frost on a window.")]
		FROSTSENSOR = 7,
	
		[Description("A device that senses or detects gas concentration (other than CO2)")]
		GASSENSOR = 8,
	
		[Description("A device that senses or detects heat.")]
		HEATSENSOR = 9,
	
		[Description("A device that senses or detects humidity.")]
		HUMIDITYSENSOR = 10,
	
		[Description("A device that reads a tag, such as for gaining access to a door or elevator")]
		IDENTIFIERSENSOR = 11,
	
		[Description("A device that senses or detects ion concentration, such as for water hardness.")]
		IONCONCENTRATIONSENSOR = 12,
	
		[Description("A device that senses or detects fill level, such as for a tank.")]
		LEVELSENSOR = 13,
	
		[Description("A device that senses or detects light.")]
		LIGHTSENSOR = 14,
	
		[Description("A device that senses or detects moisture.")]
		MOISTURESENSOR = 15,
	
		[Description("A device that senses or detects movement.")]
		MOVEMENTSENSOR = 16,
	
		[Description("A device that senses or detects acidity.")]
		PHSENSOR = 17,
	
		[Description("A device that senses or detects pressure.")]
		PRESSURESENSOR = 18,
	
		[Description("A device that senses or detects radiation.")]
		RADIATIONSENSOR = 19,
	
		[Description("A device that senses or detects atomic decay.")]
		RADIOACTIVITYSENSOR = 20,
	
		[Description("A device that senses or detects smoke.")]
		SMOKESENSOR = 21,
	
		[Description("A device that senses or detects sound.")]
		SOUNDSENSOR = 22,
	
		[Description("A device that senses or detects temperature.")]
		TEMPERATURESENSOR = 23,
	
		[Description("A device that senses or detects airflow speed and direction.")]
		WINDSENSOR = 24,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

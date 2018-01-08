// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcBuildingControlsDomain
{
	[Guid("b9a69a8b-176b-4d10-897a-13281718f60f")]
	public enum IfcSensorTypeEnum
	{
		[Description("A device that senses or detects carbon dioxide.")]
		CO2SENSOR = 1,
	
		[Description("A device that senses or detects electrical conductance.")]
		CONDUCTANCESENSOR = 2,
	
		[Description("A device that senses or detects contact, such as for detecting if a door is close" +
	    "d.")]
		CONTACTSENSOR = 3,
	
		[Description("A device that senses or detects fire")]
		FIRESENSOR = 4,
	
		[Description("A device that senses or detects flow in a fluid.")]
		FLOWSENSOR = 5,
	
		[Description("A device that senses or detects frost on a window.")]
		FROSTSENSOR = 6,
	
		[Description("A device that senses or detects gas concentration (other than CO2)")]
		GASSENSOR = 7,
	
		[Description("A device that senses or detects heat.")]
		HEATSENSOR = 8,
	
		[Description("A device that senses or detects humidity.")]
		HUMIDITYSENSOR = 9,
	
		[Description("A device that reads a tag, such as for gaining access to a door or elevator")]
		IDENTIFIERSENSOR = 10,
	
		[Description("A device that senses or detects ion concentration, such as for water hardness.")]
		IONCONCENTRATIONSENSOR = 11,
	
		[Description("A device that senses or detects fill level, such as for a tank.")]
		LEVELSENSOR = 12,
	
		[Description("A device that senses or detects light.")]
		LIGHTSENSOR = 13,
	
		[Description("A device that senses or detects moisture.")]
		MOISTURESENSOR = 14,
	
		[Description("A device that senses or detects movement.")]
		MOVEMENTSENSOR = 15,
	
		[Description("A device that senses or detects acidity.")]
		PHSENSOR = 16,
	
		[Description("A device that senses or detects pressure.")]
		PRESSURESENSOR = 17,
	
		[Description("A device that senses or detects pressure.")]
		RADIATIONSENSOR = 18,
	
		[Description("A device that senses or detects atomic decay.")]
		RADIOACTIVITYSENSOR = 19,
	
		[Description("A device that senses or detects smoke.")]
		SMOKESENSOR = 20,
	
		[Description("A device that senses or detects sound.")]
		SOUNDSENSOR = 21,
	
		[Description("A device that senses or detects temperature.")]
		TEMPERATURESENSOR = 22,
	
		[Description("A device that senses or detects airflow speed and direction.")]
		WINDSENSOR = 23,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

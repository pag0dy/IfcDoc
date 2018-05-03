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


namespace BuildingSmart.IFC.IfcProductExtension
{
	public enum IfcSpatialZoneTypeEnum
	{
		[Description("The spatial zone is used to represent a construction zone for the production proc" +
	    "ess.")]
		CONSTRUCTION = 1,
	
		[Description("The spatial zone is used to represent a fire safety zone, or fire compartment.")]
		FIRESAFETY = 2,
	
		[Description("The spatial zone is used to represent a lighting zone; a daylight zone, or an art" +
	    "ificial lighting zone.")]
		LIGHTING = 3,
	
		[Description("The spatial zone is used to represent a zone of particular occupancy.")]
		OCCUPANCY = 4,
	
		[Description("The spatial zone is used to represent a zone for security planning and maintainan" +
	    "ce work.")]
		SECURITY = 5,
	
		[Description("The spatial zone is used to represent a thermal zone.")]
		THERMAL = 6,
	
		TRANSPORT = 7,
	
		[Description("The spatial zone is used to represent a ventilation zone.")]
		VENTILATION = 8,
	
		[Description("User defined type spatial zone.")]
		USERDEFINED = -1,
	
		[Description("Undefined type spatial zone.")]
		NOTDEFINED = 0,
	
	}
}

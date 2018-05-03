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
	public enum IfcLightFixtureTypeEnum
	{
		[Description("A light fixture that is considered to have negligible area and that emit light wi" +
	    "th approximately equal intensity in all directions.  A light fixture containing " +
	    "a tungsten, halogen or similar bulb is an example of a point source.")]
		POINTSOURCE = 1,
	
		[Description(" A light fixture that is considered to have a length or surface area from which i" +
	    "t emits light in a direction. A light fixture containing one or more fluorescent" +
	    " lamps is an example of a direction source.")]
		DIRECTIONSOURCE = 2,
	
		[Description("A light fixture having specific purpose of directing occupants in an emergency, s" +
	    "uch as an illuminated exit sign or emergency flood light.")]
		SECURITYLIGHTING = 3,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

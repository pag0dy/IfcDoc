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
	public enum IfcAlarmTypeEnum
	{
		[Description("An audible alarm.")]
		BELL = 1,
	
		[Description("An alarm activation mechanism in which a protective glass has to be broken to ena" +
	    "ble a button to be pressed.")]
		BREAKGLASSBUTTON = 2,
	
		[Description("A visual alarm.")]
		LIGHT = 3,
	
		[Description("An alarm activation mechanism in which activation is achieved by a pulling action" +
	    ".")]
		MANUALPULLBOX = 4,
	
		[Description("An audible alarm.")]
		SIREN = 5,
	
		[Description("An audible alarm.")]
		WHISTLE = 6,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

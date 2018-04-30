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
	public enum IfcCooledBeamTypeEnum
	{
		[Description("An active or ventilated cooled beam provides cooling (and heating) but can also f" +
	    "unction as an air terminal in a ventilation system.")]
		ACTIVE = 1,
	
		[Description("A passive or static cooled beam provides cooling (and heating) to a room or zone." +
	    "")]
		PASSIVE = 2,
	
		[Description("User-defined cooled beam type.")]
		USERDEFINED = -1,
	
		[Description("Undefined cooled beam type.")]
		NOTDEFINED = 0,
	
	}
}

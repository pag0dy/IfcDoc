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
	public enum IfcUnitaryEquipmentTypeEnum
	{
		[Description("A unitary air handling unit typically containing a fan, economizer, and coils.")]
		AIRHANDLER = 1,
	
		[Description("A unitary packaged air-conditioning unit typically used in residential or light c" +
	    "ommercial applications.")]
		AIRCONDITIONINGUNIT = 2,
	
		[Description("A unitary packaged dehumidification unit.  Note: units supporting multiple modes " +
	    "(dehumidification, cooling, and/or heating) should use AIRCONDITIONINGUNIT.")]
		DEHUMIDIFIER = 3,
	
		[Description("A system which separates the compressor from the evaporator, but acts as a unitar" +
	    "y component typically within residential or light commercial applications.")]
		SPLITSYSTEM = 4,
	
		[Description("A packaged assembly that is either field-erected or manufactured atop the roof of" +
	    " a large residential or commercial building and acts as a unitary component.")]
		ROOFTOPUNIT = 5,
	
		[Description("User-defined unitary equipment type.")]
		USERDEFINED = -1,
	
		[Description("Undefined unitary equipment type.")]
		NOTDEFINED = 0,
	
	}
}

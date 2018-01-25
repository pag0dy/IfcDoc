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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;

namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("fc36c935-aa49-4163-b3d7-a4b0b23f0b37")]
	public enum IfcUnitEnum
	{
		ABSORBEDDOSEUNIT = 1,
	
		AMOUNTOFSUBSTANCEUNIT = 2,
	
		AREAUNIT = 3,
	
		DOSEEQUIVALENTUNIT = 4,
	
		ELECTRICCAPACITANCEUNIT = 5,
	
		ELECTRICCHARGEUNIT = 6,
	
		ELECTRICCONDUCTANCEUNIT = 7,
	
		ELECTRICCURRENTUNIT = 8,
	
		ELECTRICRESISTANCEUNIT = 9,
	
		ELECTRICVOLTAGEUNIT = 10,
	
		ENERGYUNIT = 11,
	
		FORCEUNIT = 12,
	
		FREQUENCYUNIT = 13,
	
		ILLUMINANCEUNIT = 14,
	
		INDUCTANCEUNIT = 15,
	
		LENGTHUNIT = 16,
	
		LUMINOUSFLUXUNIT = 17,
	
		LUMINOUSINTENSITYUNIT = 18,
	
		MAGNETICFLUXDENSITYUNIT = 19,
	
		MAGNETICFLUXUNIT = 20,
	
		MASSUNIT = 21,
	
		PLANEANGLEUNIT = 22,
	
		POWERUNIT = 23,
	
		PRESSUREUNIT = 24,
	
		RADIOACTIVITYUNIT = 25,
	
		SOLIDANGLEUNIT = 26,
	
		THERMODYNAMICTEMPERATUREUNIT = 27,
	
		TIMEUNIT = 28,
	
		VOLUMEUNIT = 29,
	
		[Description("User defined unit type. The type of unit is only implied by its name or the usage" +
	    " context.")]
		USERDEFINED = -1,
	
	}
}

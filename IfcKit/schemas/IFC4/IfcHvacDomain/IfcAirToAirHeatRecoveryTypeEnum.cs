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
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("c1a0567f-f772-4d84-ac5a-4fd29e2e0b6e")]
	public enum IfcAirToAirHeatRecoveryTypeEnum
	{
		FIXEDPLATECOUNTERFLOWEXCHANGER = 1,
	
		FIXEDPLATECROSSFLOWEXCHANGER = 2,
	
		FIXEDPLATEPARALLELFLOWEXCHANGER = 3,
	
		ROTARYWHEEL = 4,
	
		RUNAROUNDCOILLOOP = 5,
	
		HEATPIPE = 6,
	
		TWINTOWERENTHALPYRECOVERYLOOPS = 7,
	
		THERMOSIPHONSEALEDTUBEHEATEXCHANGERS = 8,
	
		THERMOSIPHONCOILTYPEHEATEXCHANGERS = 9,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

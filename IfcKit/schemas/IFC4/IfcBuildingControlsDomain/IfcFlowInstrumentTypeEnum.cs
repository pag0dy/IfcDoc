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
	[Guid("f3b815e8-347a-412e-9786-5c5986236e01")]
	public enum IfcFlowInstrumentTypeEnum
	{
		PRESSUREGAUGE = 1,
	
		THERMOMETER = 2,
	
		AMMETER = 3,
	
		FREQUENCYMETER = 4,
	
		POWERFACTORMETER = 5,
	
		PHASEANGLEMETER = 6,
	
		VOLTMETER_PEAK = 7,
	
		VOLTMETER_RMS = 8,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

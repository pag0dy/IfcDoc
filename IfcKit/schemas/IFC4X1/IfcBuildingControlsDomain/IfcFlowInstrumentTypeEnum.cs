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


namespace BuildingSmart.IFC.IfcBuildingControlsDomain
{
	[Guid("f3b815e8-347a-412e-9786-5c5986236e01")]
	public enum IfcFlowInstrumentTypeEnum
	{
		[Description("A device that reads and displays a pressure value at a point or the pressure diff" +
	    "erence between two points.")]
		PRESSUREGAUGE = 1,
	
		[Description("A device that reads and displays a temperature value at a point.")]
		THERMOMETER = 2,
	
		[Description("A device that reads and displays the current flow in a circuit.")]
		AMMETER = 3,
	
		[Description("A device that reads and displays the electrical frequency of an alternating curre" +
	    "nt circuit.")]
		FREQUENCYMETER = 4,
	
		[Description("A device that reads and displays the power factor of an electrical circuit.")]
		POWERFACTORMETER = 5,
	
		[Description("A device that reads and displays the phase angle of a phase in a polyphase electr" +
	    "ical circuit.")]
		PHASEANGLEMETER = 6,
	
		[Description("A device that reads and displays the peak voltage in an electrical circuit.")]
		VOLTMETER_PEAK = 7,
	
		[Description("A device that reads and displays the RMS (mean) voltage in an electrical circuit." +
	    "")]
		VOLTMETER_RMS = 8,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

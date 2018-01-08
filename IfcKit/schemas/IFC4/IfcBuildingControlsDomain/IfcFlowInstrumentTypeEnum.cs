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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcBuildingControlsDomain
{
	[Guid("119d2f63-15fb-4e59-8d93-9bb1051a61f9")]
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

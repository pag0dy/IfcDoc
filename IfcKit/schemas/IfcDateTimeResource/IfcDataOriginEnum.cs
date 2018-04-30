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


namespace BuildingSmart.IFC.IfcDateTimeResource
{
	public enum IfcDataOriginEnum
	{
		[Description("The origin of the time data is a measurement device.")]
		MEASURED = 1,
	
		[Description("The time data are a prediction.")]
		PREDICTED = 2,
	
		[Description("The origin of the time data is a simulation.")]
		SIMULATED = 3,
	
		USERDEFINED = -1,
	
		[Description("The origin of the time data is undefined.")]
		NOTDEFINED = 0,
	
	}
}

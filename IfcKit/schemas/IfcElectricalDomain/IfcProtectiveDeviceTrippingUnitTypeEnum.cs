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
	public enum IfcProtectiveDeviceTrippingUnitTypeEnum
	{
		[Description("A tripping unit activated by electronic action.")]
		ELECTRONIC = 1,
	
		[Description("A tripping unit activated by electromagnetic action.")]
		ELECTROMAGNETIC = 2,
	
		[Description("A tripping unit activated by residual current detection.")]
		RESIDUALCURRENT = 3,
	
		[Description("A tripping unit activated by thermal action.")]
		THERMAL = 4,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

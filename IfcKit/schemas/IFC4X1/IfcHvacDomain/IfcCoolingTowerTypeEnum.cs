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


namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("2f3777b4-0298-4d01-acd3-5e9f2b259f2b")]
	public enum IfcCoolingTowerTypeEnum
	{
		[Description("Air flow is produced naturally.")]
		NATURALDRAFT = 1,
	
		[Description("Air flow is produced by a mechanical device, typically one or more fans, located " +
	    "on the air outlet side of the cooling tower.")]
		MECHANICALINDUCEDDRAFT = 2,
	
		[Description("Air flow is produced by a mechanical device, typically one or more fans, located " +
	    "on the inlet air side of the cooling tower.")]
		MECHANICALFORCEDDRAFT = 3,
	
		[Description("User-defined cooling tower type.")]
		USERDEFINED = -1,
	
		[Description("Undefined cooling tower type.")]
		NOTDEFINED = 0,
	
	}
}

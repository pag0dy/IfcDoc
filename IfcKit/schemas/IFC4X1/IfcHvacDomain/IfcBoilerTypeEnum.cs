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
	[Guid("bc84324d-b2cb-4871-bfc8-6deec07459e8")]
	public enum IfcBoilerTypeEnum
	{
		[Description("Water boiler.")]
		WATER = 1,
	
		[Description("Steam boiler.")]
		STEAM = 2,
	
		[Description("User-defined Boiler type.")]
		USERDEFINED = -1,
	
		[Description("Undefined Boiler type.")]
		NOTDEFINED = 0,
	
	}
}

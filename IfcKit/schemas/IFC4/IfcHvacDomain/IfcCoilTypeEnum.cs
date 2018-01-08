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
	[Guid("81999189-d657-4185-891f-44500625d310")]
	public enum IfcCoilTypeEnum
	{
		[Description("Cooling coil using a refrigerant to cool the air stream directly.")]
		DXCOOLINGCOIL = 1,
	
		[Description("Heating coil using electricity as a heating source.")]
		ELECTRICHEATINGCOIL = 2,
	
		[Description("Heating coil using gas as a heating source.")]
		GASHEATINGCOIL = 3,
	
		[Description("Cooling or Heating coil that uses a hydronic fluid as a cooling or heating source" +
	    ".")]
		HYDRONICCOIL = 4,
	
		[Description("Heating coil using steam as heating source.")]
		STEAMHEATINGCOIL = 5,
	
		[Description("Cooling coil using chilled water. HYDRONICCOIL supercedes this enumerator.")]
		WATERCOOLINGCOIL = 6,
	
		[Description("Heating coil using hot water as a heating source. HYDRONICCOIL supercedes this en" +
	    "umerator.")]
		WATERHEATINGCOIL = 7,
	
		[Description("User-defined coil type.")]
		USERDEFINED = -1,
	
		[Description("Undefined coil type.")]
		NOTDEFINED = 0,
	
	}
}

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
	[Guid("78a0b542-081d-4e7c-8545-5b4e05c1adb5")]
	public enum IfcEvaporatorTypeEnum
	{
		[Description("Direct-expansion evaporator.")]
		DIRECTEXPANSION = 1,
	
		[Description("Direct-expansion evaporator where a refrigerant evaporates inside a series of baf" +
	    "fles that channel the fluid throughout the shell side.")]
		DIRECTEXPANSIONSHELLANDTUBE = 2,
	
		[Description("Direct-expansion evaporator where a refrigerant evaporates inside one or more pai" +
	    "rs of coaxial tubes.")]
		DIRECTEXPANSIONTUBEINTUBE = 3,
	
		[Description("Direct-expansion evaporator where a refrigerant evaporates inside plates brazed o" +
	    "r welded together to make up an assembly of separate channels.")]
		DIRECTEXPANSIONBRAZEDPLATE = 4,
	
		[Description("Evaporator in which refrigerant evaporates outside tubes.")]
		FLOODEDSHELLANDTUBE = 5,
	
		[Description("Evaporator in which refrigerant evaporates inside a simple coiled tube immersed i" +
	    "n the fluid to be cooled.")]
		SHELLANDCOIL = 6,
	
		[Description("User-defined evaporator type.")]
		USERDEFINED = -1,
	
		[Description("Undefined evaporator type.")]
		NOTDEFINED = 0,
	
	}
}

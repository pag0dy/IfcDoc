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
		DIRECTEXPANSION = 1,
	
		DIRECTEXPANSIONSHELLANDTUBE = 2,
	
		DIRECTEXPANSIONTUBEINTUBE = 3,
	
		DIRECTEXPANSIONBRAZEDPLATE = 4,
	
		FLOODEDSHELLANDTUBE = 5,
	
		SHELLANDCOIL = 6,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

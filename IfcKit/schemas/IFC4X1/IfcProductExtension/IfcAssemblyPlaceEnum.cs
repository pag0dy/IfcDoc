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


namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("7c8250e0-2413-4beb-a000-a3832f4c8248")]
	public enum IfcAssemblyPlaceEnum
	{
		[Description("This assembly is assembled at site.")]
		SITE = 1,
	
		[Description("This assembly is assembled in a factory.")]
		FACTORY = 2,
	
		NOTDEFINED = 0,
	
	}
}

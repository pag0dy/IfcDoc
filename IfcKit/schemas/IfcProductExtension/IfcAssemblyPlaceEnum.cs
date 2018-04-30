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


namespace BuildingSmart.IFC.IfcProductExtension
{
	public enum IfcAssemblyPlaceEnum
	{
		[Description("This assembly is assembled at site.")]
		SITE = 1,
	
		[Description("This assembly is assembled in a factory.")]
		FACTORY = 2,
	
		NOTDEFINED = 0,
	
	}
}

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


namespace BuildingSmart.IFC.IfcHvacDomain
{
	public enum IfcTubeBundleTypeEnum
	{
		[Description("Finned tube bundle type.")]
		FINNED = 1,
	
		[Description("User-defined tube bundle type.")]
		USERDEFINED = -1,
	
		[Description("Undefined tube bundle type.")]
		NOTDEFINED = 0,
	
	}
}

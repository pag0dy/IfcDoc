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


namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	public enum IfcConstructionProductResourceTypeEnum
	{
		[Description("Construction of assemblies for use as input to the building model or other assemb" +
	    "lies.")]
		ASSEMBLY = 1,
	
		[Description("Construction or placement of forms for placing materials such as concrete.")]
		FORMWORK = 2,
	
		[Description("User-defined resource.")]
		USERDEFINED = -1,
	
		[Description("Undefined resource.")]
		NOTDEFINED = 0,
	
	}
}

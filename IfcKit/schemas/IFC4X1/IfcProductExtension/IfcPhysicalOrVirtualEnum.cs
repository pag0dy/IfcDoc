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
	[Guid("b5b9072a-0e79-47df-ae0e-9eee0c4dba38")]
	public enum IfcPhysicalOrVirtualEnum
	{
		[Description("The space boundary is provided physically (by a physical element).")]
		PHYSICAL = 1,
	
		[Description("The space boundary is provided virtually (by a logical divider that has no physic" +
	    "al manifestation).")]
		VIRTUAL = 2,
	
		[Description("No information available.")]
		NOTDEFINED = 0,
	
	}
}

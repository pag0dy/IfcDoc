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
	[Guid("0747735c-4c71-4aed-a14f-703dda0f2d89")]
	public enum IfcChillerTypeEnum
	{
		[Description("Air cooled chiller.")]
		AIRCOOLED = 1,
	
		[Description("Water cooled chiller.")]
		WATERCOOLED = 2,
	
		[Description("Heat recovery chiller.")]
		HEATRECOVERY = 3,
	
		[Description("User-defined chiller type.")]
		USERDEFINED = -1,
	
		[Description("Undefined chiller type.")]
		NOTDEFINED = 0,
	
	}
}

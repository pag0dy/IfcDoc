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
	[Guid("c7c48d26-0ead-43f8-ab77-83379d78d75c")]
	public enum IfcSpaceHeaterTypeEnum
	{
		[Description("A heat-distributing unit that operates with gravity-circulated air.")]
		CONVECTOR = 1,
	
		[Description("A heat-distributing unit that operates with thermal radiation.")]
		RADIATOR = 2,
	
		[Description("User-defined space heater type.")]
		USERDEFINED = -1,
	
		[Description("Undefined space heater type.")]
		NOTDEFINED = 0,
	
	}
}

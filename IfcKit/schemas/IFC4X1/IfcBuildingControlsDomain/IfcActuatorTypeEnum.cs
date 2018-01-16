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

namespace BuildingSmart.IFC.IfcBuildingControlsDomain
{
	[Guid("19ec410e-7dd0-43f5-9a7c-3ed6fcd7f858")]
	public enum IfcActuatorTypeEnum
	{
		[Description("A device that electrically actuates a control element.")]
		ELECTRICACTUATOR = 1,
	
		[Description("A device that manually actuates a control element.")]
		HANDOPERATEDACTUATOR = 2,
	
		[Description("A device that electrically actuates a control element.")]
		HYDRAULICACTUATOR = 3,
	
		[Description("A device that pneumatically actuates a control element.")]
		PNEUMATICACTUATOR = 4,
	
		[Description("A device that thermostatically actuates a control element.")]
		THERMOSTATICACTUATOR = 5,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

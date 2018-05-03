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
	public enum IfcConstructionEquipmentResourceTypeEnum
	{
		[Description("Removal or destruction of building elements.")]
		DEMOLISHING = 1,
	
		[Description("Excavating, filling, or contouring earth.")]
		EARTHMOVING = 2,
	
		[Description("Lifting, positioning, and placing elements.")]
		ERECTING = 3,
	
		[Description("Temporary heat to support construction.")]
		HEATING = 4,
	
		[Description("Temporary lighting to support construction.")]
		LIGHTING = 5,
	
		[Description("Roads or walkways such as asphalt or concrete.")]
		PAVING = 6,
	
		[Description("Installing materials through pumps.")]
		PUMPING = 7,
	
		[Description("Transporting products or materials.")]
		TRANSPORTING = 8,
	
		[Description("User-defined resource.")]
		USERDEFINED = -1,
	
		[Description("Undefined resource.")]
		NOTDEFINED = 0,
	
	}
}

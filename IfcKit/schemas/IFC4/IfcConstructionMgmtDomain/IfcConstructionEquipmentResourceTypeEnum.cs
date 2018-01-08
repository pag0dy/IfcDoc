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

using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	[Guid("d4f88d5d-627e-4f34-99fa-00dafdbebdb6")]
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

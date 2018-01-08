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
	[Guid("82f996fd-ed1f-4a14-8078-908d8fc3e27c")]
	public enum IfcCrewResourceTypeEnum
	{
		[Description("A composition of resources performing administration work in an office.")]
		OFFICE = 1,
	
		[Description("A composition of resources performing production work on a construction site.")]
		SITE = 2,
	
		[Description("User-defined resource.")]
		USERDEFINED = -1,
	
		[Description("Undefined resource.")]
		NOTDEFINED = 0,
	
	}
}

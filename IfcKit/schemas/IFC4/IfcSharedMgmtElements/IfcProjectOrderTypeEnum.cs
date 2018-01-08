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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	[Guid("46d32b30-b6d4-4c9b-ac6a-a9e54fc306a6")]
	public enum IfcProjectOrderTypeEnum
	{
		CHANGEORDER = 1,
	
		MAINTENANCEWORKORDER = 2,
	
		MOVEORDER = 3,
	
		PURCHASEORDER = 4,
	
		WORKORDER = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

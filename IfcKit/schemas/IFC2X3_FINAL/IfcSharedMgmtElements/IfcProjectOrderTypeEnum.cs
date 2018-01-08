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

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	[Guid("502bd445-1292-49e8-a30c-c39d6ab1fd53")]
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

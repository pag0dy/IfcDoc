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
	[Guid("2171e3cc-c450-4294-a332-ac6d4472e9aa")]
	public enum IfcProjectOrderRecordTypeEnum
	{
		CHANGE = 1,
	
		MAINTENANCE = 2,
	
		MOVE = 3,
	
		PURCHASE = 4,
	
		WORK = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

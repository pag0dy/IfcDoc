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
	[Guid("d6386726-999b-42e9-ae2c-8456d390163a")]
	public enum IfcActionRequestTypeEnum
	{
		EMAIL = 1,
	
		FAX = 2,
	
		PHONE = 3,
	
		POST = 4,
	
		VERBAL = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

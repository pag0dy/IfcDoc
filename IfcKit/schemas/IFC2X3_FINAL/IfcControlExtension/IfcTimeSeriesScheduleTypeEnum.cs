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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;

namespace BuildingSmart.IFC.IfcControlExtension
{
	[Guid("0f57d1bb-d407-4244-908d-aa3ccacdacda")]
	public enum IfcTimeSeriesScheduleTypeEnum
	{
		ANNUAL = 1,
	
		MONTHLY = 2,
	
		WEEKLY = 3,
	
		DAILY = 4,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcTimeSeriesResource
{
	[Guid("4715df7e-dafd-4c09-b3b8-f496565bf165")]
	public enum IfcTimeSeriesDataTypeEnum
	{
		CONTINUOUS = 1,
	
		DISCRETE = 2,
	
		DISCRETEBINARY = 3,
	
		PIECEWISEBINARY = 4,
	
		PIECEWISECONSTANT = 5,
	
		PIECEWISECONTINUOUS = 6,
	
		NOTDEFINED = 0,
	
	}
}

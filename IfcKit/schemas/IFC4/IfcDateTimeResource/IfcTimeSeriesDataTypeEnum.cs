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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("41d3bfdc-e5ba-454b-82b3-ec15b57c3007")]
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

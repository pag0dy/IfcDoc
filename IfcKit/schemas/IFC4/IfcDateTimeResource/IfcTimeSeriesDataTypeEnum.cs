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
		[Description("The time series data is continuous.")]
		CONTINUOUS = 1,
	
		[Description("The time series data is discrete.")]
		DISCRETE = 2,
	
		[Description("The time series data is discrete binary.")]
		DISCRETEBINARY = 3,
	
		[Description("The time series data is piecewise binary.")]
		PIECEWISEBINARY = 4,
	
		[Description("The time series data is piecewise constant.")]
		PIECEWISECONSTANT = 5,
	
		[Description("The time series data is piecewise continuous.")]
		PIECEWISECONTINUOUS = 6,
	
		[Description("The time series data is not defined.")]
		NOTDEFINED = 0,
	
	}
}

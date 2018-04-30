// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	public partial class IfcRegularTimeSeries : IfcTimeSeries
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A duration of time intervals between values.")]
		[Required()]
		public IfcTimeMeasure TimeStep { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The collection of time series values.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcTimeSeriesValue> Values { get; protected set; }
	
	
		public IfcRegularTimeSeries(IfcLabel __Name, IfcText? __Description, IfcDateTime __StartTime, IfcDateTime __EndTime, IfcTimeSeriesDataTypeEnum __TimeSeriesDataType, IfcDataOriginEnum __DataOrigin, IfcLabel? __UserDefinedDataOrigin, IfcUnit __Unit, IfcTimeMeasure __TimeStep, IfcTimeSeriesValue[] __Values)
			: base(__Name, __Description, __StartTime, __EndTime, __TimeSeriesDataType, __DataOrigin, __UserDefinedDataOrigin, __Unit)
		{
			this.TimeStep = __TimeStep;
			this.Values = new List<IfcTimeSeriesValue>(__Values);
		}
	
	
	}
	
}

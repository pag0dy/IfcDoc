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
	public partial class IfcIrregularTimeSeries : IfcTimeSeries
	{
		[DataMember(Order = 0)] 
		[Description("The collection of time series values.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcIrregularTimeSeriesValue> Values { get; protected set; }
	
	
		public IfcIrregularTimeSeries(IfcLabel __Name, IfcText? __Description, IfcDateTime __StartTime, IfcDateTime __EndTime, IfcTimeSeriesDataTypeEnum __TimeSeriesDataType, IfcDataOriginEnum __DataOrigin, IfcLabel? __UserDefinedDataOrigin, IfcUnit __Unit, IfcIrregularTimeSeriesValue[] __Values)
			: base(__Name, __Description, __StartTime, __EndTime, __TimeSeriesDataType, __DataOrigin, __UserDefinedDataOrigin, __Unit)
		{
			this.Values = new List<IfcIrregularTimeSeriesValue>(__Values);
		}
	
	
	}
	
}

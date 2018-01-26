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

using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcTimeSeriesResource
{
	[Guid("81b7ef9c-51e6-4318-9f1e-55983d7868e5")]
	public partial class IfcIrregularTimeSeries : IfcTimeSeries
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcIrregularTimeSeriesValue> _Values = new List<IfcIrregularTimeSeriesValue>();
	
	
		public IfcIrregularTimeSeries()
		{
		}
	
		public IfcIrregularTimeSeries(IfcLabel __Name, IfcText? __Description, IfcDateTimeSelect __StartTime, IfcDateTimeSelect __EndTime, IfcTimeSeriesDataTypeEnum __TimeSeriesDataType, IfcDataOriginEnum __DataOrigin, IfcLabel? __UserDefinedDataOrigin, IfcUnit __Unit, IfcIrregularTimeSeriesValue[] __Values)
			: base(__Name, __Description, __StartTime, __EndTime, __TimeSeriesDataType, __DataOrigin, __UserDefinedDataOrigin, __Unit)
		{
			this._Values = new List<IfcIrregularTimeSeriesValue>(__Values);
		}
	
		[Description("The collection of time series values.")]
		public IList<IfcIrregularTimeSeriesValue> Values { get { return this._Values; } }
	
	
	}
	
}

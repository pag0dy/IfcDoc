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
	[Guid("16385c7b-e0f0-4a6e-ac99-615c3bd64eb7")]
	public partial class IfcRegularTimeSeries : IfcTimeSeries
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTimeMeasure _TimeStep;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		IList<IfcTimeSeriesValue> _Values = new List<IfcTimeSeriesValue>();
	
	
		public IfcRegularTimeSeries()
		{
		}
	
		public IfcRegularTimeSeries(IfcLabel __Name, IfcText? __Description, IfcDateTimeSelect __StartTime, IfcDateTimeSelect __EndTime, IfcTimeSeriesDataTypeEnum __TimeSeriesDataType, IfcDataOriginEnum __DataOrigin, IfcLabel? __UserDefinedDataOrigin, IfcUnit __Unit, IfcTimeMeasure __TimeStep, IfcTimeSeriesValue[] __Values)
			: base(__Name, __Description, __StartTime, __EndTime, __TimeSeriesDataType, __DataOrigin, __UserDefinedDataOrigin, __Unit)
		{
			this._TimeStep = __TimeStep;
			this._Values = new List<IfcTimeSeriesValue>(__Values);
		}
	
		[Description("A duration of time intervals between values.")]
		public IfcTimeMeasure TimeStep { get { return this._TimeStep; } set { this._TimeStep = value;} }
	
		[Description("The collection of time series values.")]
		public IList<IfcTimeSeriesValue> Values { get { return this._Values; } }
	
	
	}
	
}

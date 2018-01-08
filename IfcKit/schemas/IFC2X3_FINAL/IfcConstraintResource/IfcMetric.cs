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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	[Guid("f27d8f9b-d773-45c4-b8cf-20a75a7c28c4")]
	public partial class IfcMetric : IfcConstraint
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcBenchmarkEnum _Benchmark;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _ValueSource;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcMetricValueSelect _DataValue;
	
	
		[Description("Enumeration that identifies the type of benchmark data.\r\n")]
		public IfcBenchmarkEnum Benchmark { get { return this._Benchmark; } set { this._Benchmark = value;} }
	
		[Description("Reference source for data values.\r\n")]
		public IfcLabel? ValueSource { get { return this._ValueSource; } set { this._ValueSource = value;} }
	
		[Description("Value with data type defined by the DataType enumeration.\r\n")]
		public IfcMetricValueSelect DataValue { get { return this._DataValue; } set { this._DataValue = value;} }
	
	
	}
	
}

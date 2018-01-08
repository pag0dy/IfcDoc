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
	[Guid("16385c7b-e0f0-4a6e-ac99-615c3bd64eb7")]
	public partial class IfcRegularTimeSeries : IfcTimeSeries
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTimeMeasure _TimeStep;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcTimeSeriesValue> _Values = new List<IfcTimeSeriesValue>();
	
	
		[Description("A duration of time intervals between values.")]
		public IfcTimeMeasure TimeStep { get { return this._TimeStep; } set { this._TimeStep = value;} }
	
		[Description("The collection of time series values.")]
		public IList<IfcTimeSeriesValue> Values { get { return this._Values; } }
	
	
	}
	
}

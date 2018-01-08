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
	[Guid("70d36884-89fe-4808-9584-00b43dbc8c2e")]
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

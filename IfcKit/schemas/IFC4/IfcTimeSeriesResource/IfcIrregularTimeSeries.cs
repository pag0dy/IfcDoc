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
	[Guid("81b7ef9c-51e6-4318-9f1e-55983d7868e5")]
	public partial class IfcIrregularTimeSeries : IfcTimeSeries
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcIrregularTimeSeriesValue> _Values = new List<IfcIrregularTimeSeriesValue>();
	
	
		[Description("The collection of time series values.")]
		public IList<IfcIrregularTimeSeriesValue> Values { get { return this._Values; } }
	
	
	}
	
}

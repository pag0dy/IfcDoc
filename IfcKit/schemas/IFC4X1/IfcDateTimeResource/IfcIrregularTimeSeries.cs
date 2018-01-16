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
	[Guid("6b83f3bc-08a2-4147-aa9d-353fb6ea8b10")]
	public partial class IfcIrregularTimeSeries : IfcTimeSeries
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcIrregularTimeSeriesValue> _Values = new List<IfcIrregularTimeSeriesValue>();
	
	
		[Description("The collection of time series values.")]
		public IList<IfcIrregularTimeSeriesValue> Values { get { return this._Values; } }
	
	
	}
	
}

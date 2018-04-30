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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcTimeSeriesResource
{
	public partial class IfcIrregularTimeSeriesValue
	{
		[DataMember(Order = 0)] 
		[Description("The specification of the time point.")]
		[Required()]
		public IfcDateTimeSelect TimeStamp { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A list of time-series values. At least one value is required.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcValue> ListValues { get; protected set; }
	
	
		public IfcIrregularTimeSeriesValue(IfcDateTimeSelect __TimeStamp, IfcValue[] __ListValues)
		{
			this.TimeStamp = __TimeStamp;
			this.ListValues = new List<IfcValue>(__ListValues);
		}
	
	
	}
	
}

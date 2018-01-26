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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("d5d6da22-1509-418b-8dea-278c3dc7e2d8")]
	public partial class IfcIrregularTimeSeriesValue
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcDateTime _TimeStamp;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		IList<IfcValue> _ListValues = new List<IfcValue>();
	
	
		public IfcIrregularTimeSeriesValue()
		{
		}
	
		public IfcIrregularTimeSeriesValue(IfcDateTime __TimeStamp, IfcValue[] __ListValues)
		{
			this._TimeStamp = __TimeStamp;
			this._ListValues = new List<IfcValue>(__ListValues);
		}
	
		[Description("The specification of the time point.")]
		public IfcDateTime TimeStamp { get { return this._TimeStamp; } set { this._TimeStamp = value;} }
	
		[Description("A list of time-series values. At least one value is required.")]
		public IList<IfcValue> ListValues { get { return this._ListValues; } }
	
	
	}
	
}

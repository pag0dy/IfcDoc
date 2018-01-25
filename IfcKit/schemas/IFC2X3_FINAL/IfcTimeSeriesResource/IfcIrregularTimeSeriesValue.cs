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
	[Guid("bad154f4-5793-42e4-b441-f9d3e72c661c")]
	public partial class IfcIrregularTimeSeriesValue
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDateTimeSelect _TimeStamp;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcValue> _ListValues = new List<IfcValue>();
	
	
		[Description("The specification of the time point.")]
		public IfcDateTimeSelect TimeStamp { get { return this._TimeStamp; } set { this._TimeStamp = value;} }
	
		[Description("A list of time-series values. At least one value is required.")]
		public IList<IfcValue> ListValues { get { return this._ListValues; } }
	
	
	}
	
}

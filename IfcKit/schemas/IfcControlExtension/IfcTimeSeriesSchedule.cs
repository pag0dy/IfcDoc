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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcControlExtension
{
	public partial class IfcTimeSeriesSchedule : IfcControl
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>Defines an ordered list of the dates for which the time-series data are applicable. For example, the definition of all public holiday dates for a given year allows the formulation of a \"holiday\" occupancy schedule from overall occupancy data. Local time can be used if the dates are not bound to a particular year.    <BLOCKQUOTE> <FONT COLOR=\"#FF0000\" SIZE=\"-1\">IFC2x2 Addendum 1 change: The attribute has been changed to be optional </FONT></BLOCKQUOTE>    </EPM-HTML>  ")]
		[MinLength(1)]
		public IList<IfcDateTimeSelect> ApplicableDates { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Defines the type of schedule, such as daily, weekly, monthly or annually.")]
		[Required()]
		public IfcTimeSeriesScheduleTypeEnum TimeSeriesScheduleType { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The time series is used to represent the values at discrete points in time that define the schedule. For example, a 24-hour occupancy schedule would be a regular time series with a start time at midnight, end time at (the following) midnight, and with 24 values indicating the occupancy load for each hour of the 24-hour period.")]
		[Required()]
		public IfcTimeSeries TimeSeries { get; set; }
	
	
		public IfcTimeSeriesSchedule(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcDateTimeSelect[] __ApplicableDates, IfcTimeSeriesScheduleTypeEnum __TimeSeriesScheduleType, IfcTimeSeries __TimeSeries)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.ApplicableDates = new List<IfcDateTimeSelect>(__ApplicableDates);
			this.TimeSeriesScheduleType = __TimeSeriesScheduleType;
			this.TimeSeries = __TimeSeries;
		}
	
	
	}
	
}

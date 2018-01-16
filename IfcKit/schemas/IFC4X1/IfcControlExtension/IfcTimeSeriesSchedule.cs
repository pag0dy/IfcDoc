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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;

namespace BuildingSmart.IFC.IfcControlExtension
{
	[Guid("f6bcaacb-4e24-4544-b390-90d1f2c93cbf")]
	public partial class IfcTimeSeriesSchedule : IfcControl
	{
		[DataMember(Order=0)] 
		IList<IfcDateTimeSelect> _ApplicableDates = new List<IfcDateTimeSelect>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcTimeSeriesScheduleTypeEnum _TimeSeriesScheduleType;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcTimeSeries _TimeSeries;
	
	
		[Description(@"<EPM-HTML>Defines an ordered list of the dates for which the time-series data are applicable. For example, the definition of all public holiday dates for a given year allows the formulation of a ""holiday"" occupancy schedule from overall occupancy data. Local time can be used if the dates are not bound to a particular year.
	
	<BLOCKQUOTE> <FONT COLOR=""#FF0000"" SIZE=""-1"">IFC2x2 Addendum 1 change: The attribute has been changed to be optional </FONT></BLOCKQUOTE>
	
	</EPM-HTML>
	")]
		public IList<IfcDateTimeSelect> ApplicableDates { get { return this._ApplicableDates; } }
	
		[Description("Defines the type of schedule, such as daily, weekly, monthly or annually.")]
		public IfcTimeSeriesScheduleTypeEnum TimeSeriesScheduleType { get { return this._TimeSeriesScheduleType; } set { this._TimeSeriesScheduleType = value;} }
	
		[Description(@"The time series is used to represent the values at discrete points in time that define the schedule. For example, a 24-hour occupancy schedule would be a regular time series with a start time at midnight, end time at (the following) midnight, and with 24 values indicating the occupancy load for each hour of the 24-hour period.")]
		public IfcTimeSeries TimeSeries { get { return this._TimeSeries; } set { this._TimeSeries = value;} }
	
	
	}
	
}

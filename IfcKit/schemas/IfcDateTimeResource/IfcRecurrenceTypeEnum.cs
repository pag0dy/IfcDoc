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


namespace BuildingSmart.IFC.IfcDateTimeResource
{
	public enum IfcRecurrenceTypeEnum
	{
		[Description("Interval, Occurrences")]
		DAILY = 1,
	
		[Description("WeekdayComponent, Interval, Occurrences")]
		WEEKLY = 2,
	
		[Description("DayComponent, Interval, Occurrences")]
		MONTHLY_BY_DAY_OF_MONTH = 3,
	
		[Description("WeekdayComponent, Position, Interval, Occurrences")]
		MONTHLY_BY_POSITION = 4,
	
		[Description("nterval, Occurrences")]
		BY_DAY_COUNT = 5,
	
		[Description("WeekdayComponent, Interval, Occurrences")]
		BY_WEEKDAY_COUNT = 6,
	
		[Description("DayComponent, MonthComponent, Interval, Occurrences")]
		YEARLY_BY_DAY_OF_MONTH = 7,
	
		[Description("WeekdayComponent, MonthComponent, Position, Interval, Occurrences")]
		YEARLY_BY_POSITION = 8,
	
	}
}

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
	[Guid("258a0af9-321d-4e24-a6cc-be10c825e9f7")]
	public partial class IfcRecurrencePattern
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcRecurrenceTypeEnum _RecurrenceType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		ISet<IfcDayInMonthNumber> _DayComponent = new HashSet<IfcDayInMonthNumber>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		ISet<IfcDayInWeekNumber> _WeekdayComponent = new HashSet<IfcDayInWeekNumber>();
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		ISet<IfcMonthInYearNumber> _MonthComponent = new HashSet<IfcMonthInYearNumber>();
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcInteger? _Position;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcInteger? _Interval;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcInteger? _Occurrences;
	
		[DataMember(Order=7)] 
		IList<IfcTimePeriod> _TimePeriods = new List<IfcTimePeriod>();
	
	
		[Description("<EPM-HTML>\r\n    Defines the recurrence type that gives meaning to the used\r\n    a" +
	    "ttributes and decides about possible attribute\r\n    combinations, i.e. what attr" +
	    "ibutes are needed to fully\r\n    describe the pattern type.\r\n</EPM-HTML>")]
		public IfcRecurrenceTypeEnum RecurrenceType { get { return this._RecurrenceType; } set { this._RecurrenceType = value;} }
	
		[Description("<EPM-HTML>\r\n    The position of the specified day in a month.\r\n</EPM-HTML>\r\n")]
		public ISet<IfcDayInMonthNumber> DayComponent { get { return this._DayComponent; } }
	
		[Description("<EPM-HTML>\r\n    The weekday name of the specified day in a week.\r\n</EPM-HTML>")]
		public ISet<IfcDayInWeekNumber> WeekdayComponent { get { return this._WeekdayComponent; } }
	
		[Description("<EPM-HTML>\r\n    The position of the specified month in a year.\r\n</EPM-HTML>\r\n")]
		public ISet<IfcMonthInYearNumber> MonthComponent { get { return this._MonthComponent; } }
	
		[Description(@"<EPM-HTML>
	    The position of the specified component, e.g. the 3rd
	    (position=3) Tuesday (weekday component) in a month. A
	    negative position value is used to define the last position 
	    of the component (-1), the next to last position (-2) etc.
	</EPM-HTML>
	")]
		public IfcInteger? Position { get { return this._Position; } set { this._Position = value;} }
	
		[Description(@"<EPM-HTML>
	    An interval can be given according to the pattern type. An
	    interval value of 2 can for instance every two days, weeks,
	    months, years. An empty interval value is regarded as 1. The
	    used interval values should be in a reasonable range, e.g.
	    not 0 or &lt;0.
	</EPM-HTML>")]
		public IfcInteger? Interval { get { return this._Interval; } set { this._Interval = value;} }
	
		[Description("<EPM-HTML>\r\n    Defines the number of occurrences of this pattern, e.g. a weekly " +
	    "\r\n    event might be defined to occur 5 times before it stops.\r\n</EPM-HTML>")]
		public IfcInteger? Occurrences { get { return this._Occurrences; } set { this._Occurrences = value;} }
	
		[Description("<EPM-HTML>\r\n    List of time periods that are defined by a start and end time\r\n  " +
	    "  of the recurring element (day). The order of the list should\r\n    reflect the " +
	    "sequence of the time periods.\r\n</EPM-HTML>")]
		public IList<IfcTimePeriod> TimePeriods { get { return this._TimePeriods; } }
	
	
	}
	
}

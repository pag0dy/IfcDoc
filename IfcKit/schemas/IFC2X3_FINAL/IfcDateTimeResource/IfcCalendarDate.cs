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

using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("a637fcb3-231c-4535-9c34-3132dca4772c")]
	public partial class IfcCalendarDate :
		BuildingSmart.IFC.IfcDateTimeResource.IfcDateTimeSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcDayInMonthNumber _DayComponent;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcMonthInYearNumber _MonthComponent;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcYearNumber _YearComponent;
	
	
		public IfcCalendarDate()
		{
		}
	
		public IfcCalendarDate(IfcDayInMonthNumber __DayComponent, IfcMonthInYearNumber __MonthComponent, IfcYearNumber __YearComponent)
		{
			this._DayComponent = __DayComponent;
			this._MonthComponent = __MonthComponent;
			this._YearComponent = __YearComponent;
		}
	
		[Description("The day element of the calendar date.")]
		public IfcDayInMonthNumber DayComponent { get { return this._DayComponent; } set { this._DayComponent = value;} }
	
		[Description("The month element of the calendar date.")]
		public IfcMonthInYearNumber MonthComponent { get { return this._MonthComponent; } set { this._MonthComponent = value;} }
	
		[Description("The year element of the calendar date.")]
		public IfcYearNumber YearComponent { get { return this._YearComponent; } set { this._YearComponent = value;} }
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	public partial class IfcCalendarDate :
		BuildingSmart.IFC.IfcDateTimeResource.IfcDateTimeSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The day element of the calendar date.")]
		[Required()]
		public IfcDayInMonthNumber DayComponent { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The month element of the calendar date.")]
		[Required()]
		public IfcMonthInYearNumber MonthComponent { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The year element of the calendar date.")]
		[Required()]
		public IfcYearNumber YearComponent { get; set; }
	
	
		public IfcCalendarDate(IfcDayInMonthNumber __DayComponent, IfcMonthInYearNumber __MonthComponent, IfcYearNumber __YearComponent)
		{
			this.DayComponent = __DayComponent;
			this.MonthComponent = __MonthComponent;
			this.YearComponent = __YearComponent;
		}
	
	
	}
	
}

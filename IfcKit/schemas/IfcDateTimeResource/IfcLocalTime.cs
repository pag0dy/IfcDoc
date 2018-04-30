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
	public partial class IfcLocalTime :
		BuildingSmart.IFC.IfcDateTimeResource.IfcDateTimeSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The number of hours of the local time.")]
		[Required()]
		public IfcHourInDay HourComponent { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The number of minutes of the local time.")]
		public IfcMinuteInHour? MinuteComponent { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The number of seconds of the local time.")]
		public IfcSecondInMinute? SecondComponent { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The relationship of the local time to coordinated universal time.")]
		public IfcCoordinatedUniversalTimeOffset Zone { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The offset of daylight saving time from basis time.")]
		public IfcDaylightSavingHour? DaylightSavingOffset { get; set; }
	
	
		public IfcLocalTime(IfcHourInDay __HourComponent, IfcMinuteInHour? __MinuteComponent, IfcSecondInMinute? __SecondComponent, IfcCoordinatedUniversalTimeOffset __Zone, IfcDaylightSavingHour? __DaylightSavingOffset)
		{
			this.HourComponent = __HourComponent;
			this.MinuteComponent = __MinuteComponent;
			this.SecondComponent = __SecondComponent;
			this.Zone = __Zone;
			this.DaylightSavingOffset = __DaylightSavingOffset;
		}
	
	
	}
	
}

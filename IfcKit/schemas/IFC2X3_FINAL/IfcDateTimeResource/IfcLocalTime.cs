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
	[Guid("6ed125c9-f664-4acc-a237-e9b0a0bc4713")]
	public partial class IfcLocalTime :
		BuildingSmart.IFC.IfcDateTimeResource.IfcDateTimeSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcHourInDay _HourComponent;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcMinuteInHour? _MinuteComponent;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcSecondInMinute? _SecondComponent;
	
		[DataMember(Order=3)] 
		IfcCoordinatedUniversalTimeOffset _Zone;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcDaylightSavingHour? _DaylightSavingOffset;
	
	
		public IfcLocalTime()
		{
		}
	
		public IfcLocalTime(IfcHourInDay __HourComponent, IfcMinuteInHour? __MinuteComponent, IfcSecondInMinute? __SecondComponent, IfcCoordinatedUniversalTimeOffset __Zone, IfcDaylightSavingHour? __DaylightSavingOffset)
		{
			this._HourComponent = __HourComponent;
			this._MinuteComponent = __MinuteComponent;
			this._SecondComponent = __SecondComponent;
			this._Zone = __Zone;
			this._DaylightSavingOffset = __DaylightSavingOffset;
		}
	
		[Description("The number of hours of the local time.")]
		public IfcHourInDay HourComponent { get { return this._HourComponent; } set { this._HourComponent = value;} }
	
		[Description("The number of minutes of the local time.")]
		public IfcMinuteInHour? MinuteComponent { get { return this._MinuteComponent; } set { this._MinuteComponent = value;} }
	
		[Description("The number of seconds of the local time.")]
		public IfcSecondInMinute? SecondComponent { get { return this._SecondComponent; } set { this._SecondComponent = value;} }
	
		[Description("The relationship of the local time to coordinated universal time.")]
		public IfcCoordinatedUniversalTimeOffset Zone { get { return this._Zone; } set { this._Zone = value;} }
	
		[Description("The offset of daylight saving time from basis time.")]
		public IfcDaylightSavingHour? DaylightSavingOffset { get { return this._DaylightSavingOffset; } set { this._DaylightSavingOffset = value;} }
	
	
	}
	
}

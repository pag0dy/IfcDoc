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
	[Guid("cb173376-bb9c-47f5-99f1-2fd84e691ccc")]
	public partial class IfcWorkTime : IfcSchedulingTime
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcRecurrencePattern")]
		IfcRecurrencePattern _RecurrencePattern;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcDate? _Start;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcDate? _Finish;
	
	
		[Description("    Recurrence pattern that defines a time period, which, if given, is\r\n    valid" +
	    " within the time period defined by\r\n    <em>IfcWorkTime.Start</em> and <em>IfcWo" +
	    "rkTime.Finish</em>.")]
		public IfcRecurrencePattern RecurrencePattern { get { return this._RecurrencePattern; } set { this._RecurrencePattern = value;} }
	
		[Description("    Start date of the work time (0:00), that might be further\r\n    restricted by " +
	    "a recurrence pattern.")]
		public IfcDate? Start { get { return this._Start; } set { this._Start = value;} }
	
		[Description("    End date of the work time (24:00), that might be further\r\n    restricted by a" +
	    " recurrence pattern.")]
		public IfcDate? Finish { get { return this._Finish; } set { this._Finish = value;} }
	
	
	}
	
}

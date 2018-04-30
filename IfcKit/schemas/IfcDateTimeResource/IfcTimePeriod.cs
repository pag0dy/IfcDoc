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
	public partial class IfcTimePeriod
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("    Start time of the time period.")]
		[Required()]
		public IfcTime StartTime { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("    End time of the time period.")]
		[Required()]
		public IfcTime EndTime { get; set; }
	
	
		public IfcTimePeriod(IfcTime __StartTime, IfcTime __EndTime)
		{
			this.StartTime = __StartTime;
			this.EndTime = __EndTime;
		}
	
	
	}
	
}

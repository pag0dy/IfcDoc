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


namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("c4917737-5540-46fc-96d6-2876bd937053")]
	public partial class IfcTimePeriod
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTime _StartTime;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcTime _EndTime;
	
	
		public IfcTimePeriod()
		{
		}
	
		public IfcTimePeriod(IfcTime __StartTime, IfcTime __EndTime)
		{
			this._StartTime = __StartTime;
			this._EndTime = __EndTime;
		}
	
		[Description("    Start time of the time period.")]
		public IfcTime StartTime { get { return this._StartTime; } set { this._StartTime = value;} }
	
		[Description("    End time of the time period.")]
		public IfcTime EndTime { get { return this._EndTime; } set { this._EndTime = value;} }
	
	
	}
	
}

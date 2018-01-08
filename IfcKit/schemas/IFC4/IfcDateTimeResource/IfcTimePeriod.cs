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
	
	
		[Description("<EPM-HTML>\r\n    Start time of the time period.\r\n</EPM-HTML>")]
		public IfcTime StartTime { get { return this._StartTime; } set { this._StartTime = value;} }
	
		[Description("<EPM-HTML>\r\n    End time of the time period.\r\n</EPM-HTML>")]
		public IfcTime EndTime { get { return this._EndTime; } set { this._EndTime = value;} }
	
	
	}
	
}

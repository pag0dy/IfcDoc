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
	[Guid("ebde4676-fd2c-4f52-8985-79f623317d88")]
	public partial class IfcLagTime : IfcSchedulingTime
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcTimeOrRatioSelect _LagValue;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcTaskDurationEnum _DurationType;
	
	
		[Description("<EPM-HTML>\r\n    Value of the time lag selected as being either a ratio or a\r\n    " +
	    "time measure.\r\n</EPM-HTML>")]
		public IfcTimeOrRatioSelect LagValue { get { return this._LagValue; } set { this._LagValue = value;} }
	
		[Description("<EPM-HTML>\r\n    The allowed types of task duration that specify the lag time\r\n   " +
	    " measurement (work time or elapsed time).\r\n</EPM-HTML>")]
		public IfcTaskDurationEnum DurationType { get { return this._DurationType; } set { this._DurationType = value;} }
	
	
	}
	
}

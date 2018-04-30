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
	public partial class IfcCoordinatedUniversalTimeOffset
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The number of hours by which local time is offset from coordinated universal time.")]
		[Required()]
		public IfcHourInDay HourOffset { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The number of minutes by which local time is offset from coordinated universal time.")]
		public IfcMinuteInHour? MinuteOffset { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("<EPM-HTML>    The direction of the offset.     <BLOCKQUOTE><FONT SIZE=\"-1\">Note: The data type of the Sense is an enumeration - AHEAD means positive offset;   BEHIND means negative offset.    </FONT></BLOCKQUOTE>  </EPM-HTML>")]
		[Required()]
		public IfcAheadOrBehind Sense { get; set; }
	
	
		public IfcCoordinatedUniversalTimeOffset(IfcHourInDay __HourOffset, IfcMinuteInHour? __MinuteOffset, IfcAheadOrBehind __Sense)
		{
			this.HourOffset = __HourOffset;
			this.MinuteOffset = __MinuteOffset;
			this.Sense = __Sense;
		}
	
	
	}
	
}

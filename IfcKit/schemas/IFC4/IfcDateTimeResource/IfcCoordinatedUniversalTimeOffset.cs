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
	[Guid("204ad588-2d98-416c-a863-23bee97f3e28")]
	public partial class IfcCoordinatedUniversalTimeOffset
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcHourInDay _HourOffset;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcMinuteInHour? _MinuteOffset;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcAheadOrBehind _Sense;
	
	
		[Description("The number of hours by which local time is offset from coordinated universal time" +
	    ".")]
		public IfcHourInDay HourOffset { get { return this._HourOffset; } set { this._HourOffset = value;} }
	
		[Description("The number of minutes by which local time is offset from coordinated universal ti" +
	    "me.")]
		public IfcMinuteInHour? MinuteOffset { get { return this._MinuteOffset; } set { this._MinuteOffset = value;} }
	
		[Description("<EPM-HTML>\r\n\r\nThe direction of the offset. \r\n\r\n<BLOCKQUOTE><FONT SIZE=\"-1\">Note: " +
	    "The data type of the Sense is an enumeration - AHEAD means positive offset; \r\nBE" +
	    "HIND means negative offset.\r\n\r\n</FONT></BLOCKQUOTE>\r\n</EPM-HTML>")]
		public IfcAheadOrBehind Sense { get { return this._Sense; } set { this._Sense = value;} }
	
	
	}
	
}

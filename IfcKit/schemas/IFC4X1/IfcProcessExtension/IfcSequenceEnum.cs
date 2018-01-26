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


namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("5a70a8e7-c2dd-4375-9afe-3b5280d28811")]
	public enum IfcSequenceEnum
	{
		[Description("The predecessor task must start before the successor task may start.")]
		START_START = 1,
	
		[Description("The predecessor task must start before the successor task may finish.")]
		START_FINISH = 2,
	
		[Description("The predecessor task must finish before the successor task may start.")]
		FINISH_START = 3,
	
		[Description("The predecessor task must finish before the successor task may finish.")]
		FINISH_FINISH = 4,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

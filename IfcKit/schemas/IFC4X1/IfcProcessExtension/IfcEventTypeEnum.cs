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
	[Guid("409fe4c3-0850-4659-a3ff-dd6c71e4b917")]
	public enum IfcEventTypeEnum
	{
		[Description("An initiating event of a process.")]
		STARTEVENT = 1,
	
		[Description("A terminating event of a process.")]
		ENDEVENT = 2,
	
		[Description("An event that occurs at an intermediate stage of a process.")]
		INTERMEDIATEEVENT = 3,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

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


namespace BuildingSmart.IFC.IfcProcessExtension
{
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

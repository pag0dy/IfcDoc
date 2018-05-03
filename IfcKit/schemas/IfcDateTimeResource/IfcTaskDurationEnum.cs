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
	public enum IfcTaskDurationEnum
	{
		[Description("The time duration is based on elapsed time (24 hours per day, independent of cale" +
	    "ndar).")]
		ELAPSEDTIME = 1,
	
		[Description("The time duration is based on work time (calendar-dependent).")]
		WORKTIME = 2,
	
		[Description("The time duration is undefined.")]
		NOTDEFINED = 0,
	
	}
}

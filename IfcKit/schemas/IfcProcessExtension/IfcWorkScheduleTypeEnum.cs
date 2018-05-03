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
	public enum IfcWorkScheduleTypeEnum
	{
		[Description("A control in which actual items undertaken are indicated.")]
		ACTUAL = 1,
	
		[Description("A control that is a baseline from which changes that are made later can be recogn" +
	    "ized.")]
		BASELINE = 2,
	
		[Description("A control showing planned items.")]
		PLANNED = 3,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

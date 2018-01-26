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
	[Guid("b8fb0a11-614e-4420-af35-f07293ce7087")]
	public enum IfcWorkPlanTypeEnum
	{
		[Description("A control in which actual items undertaken are indicated.")]
		ACTUAL = 1,
	
		[Description("A control that is a baseline from which changes that are made later can be recogn" +
	    "ized.")]
		BASELINE = 2,
	
		PLANNED = 3,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

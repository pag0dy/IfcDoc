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


namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public enum IfcConnectionTypeEnum
	{
		[Description("Connection along the path of the connected element.")]
		ATPATH = 1,
	
		[Description("Connection at the start of the connected element.")]
		ATSTART = 2,
	
		[Description("Connection at the end of the connected element.")]
		ATEND = 3,
	
		NOTDEFINED = 0,
	
	}
}

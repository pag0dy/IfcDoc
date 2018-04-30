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
	public enum IfcPlateTypeEnum
	{
		[Description("A planar element within a curtain wall, often consisting of a frame with fixed gl" +
	    "azing.")]
		CURTAIN_PANEL = 1,
	
		[Description("A planar, flat and thin element, comes usually as metal sheet, and is often used " +
	    "as an additonal part within an assembly.")]
		SHEET = 2,
	
		[Description("User-defined linear element.")]
		USERDEFINED = -1,
	
		[Description("Undefined linear element.")]
		NOTDEFINED = 0,
	
	}
}

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


namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	public enum IfcFastenerTypeEnum
	{
		[Description("A fastening connection where glue is used to join together elements.")]
		GLUE = 1,
	
		[Description("A composition of mineralic or other materials used to fill jointing gaps and poss" +
	    "ibly fulfilling a load carrying role.")]
		MORTAR = 2,
	
		[Description("A weld seam between parts of metallic material or other suitable materials.")]
		WELD = 3,
	
		[Description("User-defined fastener.")]
		USERDEFINED = -1,
	
		[Description("Undefined fastener.")]
		NOTDEFINED = 0,
	
	}
}

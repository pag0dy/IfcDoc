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


namespace BuildingSmart.IFC.IfcElectricalDomain
{
	[Guid("cd1735bb-0caa-46b3-8243-be9ba262cbdd")]
	public enum IfcJunctionBoxTypeEnum
	{
		[Description("Contains cables, outlets, and/or switches for communications use.")]
		DATA = 1,
	
		[Description("Contains cables, outlets, and/or switches for electrical power.")]
		POWER = 2,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

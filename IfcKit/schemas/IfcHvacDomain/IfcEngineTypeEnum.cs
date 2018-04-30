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


namespace BuildingSmart.IFC.IfcHvacDomain
{
	public enum IfcEngineTypeEnum
	{
		[Description("Combustion is external.")]
		EXTERNALCOMBUSTION = 1,
	
		[Description("Combustion is internal.")]
		INTERNALCOMBUSTION = 2,
	
		[Description("User-defined engine type.")]
		USERDEFINED = -1,
	
		[Description("Undefined engine type.")]
		NOTDEFINED = 0,
	
	}
}

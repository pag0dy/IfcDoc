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


namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("4fc89d41-9c93-4113-bbab-dc8fa2378347")]
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

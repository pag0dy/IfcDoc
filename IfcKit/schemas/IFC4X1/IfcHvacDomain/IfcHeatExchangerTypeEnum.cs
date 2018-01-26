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
	[Guid("8e6b0cf3-8eca-4dca-a47d-a35ca7b2eac1")]
	public enum IfcHeatExchangerTypeEnum
	{
		[Description("Plate heat exchanger.")]
		PLATE = 1,
	
		[Description("Shell and Tube heat exchanger.")]
		SHELLANDTUBE = 2,
	
		[Description("User-defined heat exchanger type.")]
		USERDEFINED = -1,
	
		[Description("Undefined heat exchanger type.")]
		NOTDEFINED = 0,
	
	}
}

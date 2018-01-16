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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("a2a1bae2-820c-42dc-87ce-63af87f8b6a0")]
	public enum IfcTendonTypeEnum
	{
		[Description("The tendon is configured as a bar.")]
		BAR = 1,
	
		[Description("The tendon is coated.")]
		COATED = 2,
	
		[Description("The tendon is a strand.")]
		STRAND = 3,
	
		[Description("The tendon is a wire.")]
		WIRE = 4,
	
		[Description("The type of tendon is user defined.")]
		USERDEFINED = -1,
	
		[Description("The type of tendon is not defined.")]
		NOTDEFINED = 0,
	
	}
}

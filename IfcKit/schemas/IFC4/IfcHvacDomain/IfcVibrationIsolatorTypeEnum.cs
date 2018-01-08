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

using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("557f51df-66ec-4809-83a0-a4e67ea8beac")]
	public enum IfcVibrationIsolatorTypeEnum
	{
		[Description("Compression type vibration isolator.")]
		COMPRESSION = 1,
	
		[Description("Spring type vibration isolator.")]
		SPRING = 2,
	
		[Description("User-defined vibration isolator type.")]
		USERDEFINED = -1,
	
		[Description("Undefined vibration isolator type.")]
		NOTDEFINED = 0,
	
	}
}

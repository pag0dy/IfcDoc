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
	[Guid("94b83462-b388-4566-9a73-9b62b61dc9c9")]
	public enum IfcDuctSegmentTypeEnum
	{
		[Description("A rigid segment is a continuous linear segment of duct that cannot be deformed.")]
		RIGIDSEGMENT = 1,
	
		[Description("A flexible segment is a continuous non-linear segment of duct that can be deforme" +
	    "d and change the direction of flow.")]
		FLEXIBLESEGMENT = 2,
	
		[Description("User-defined segment.")]
		USERDEFINED = -1,
	
		[Description("Undefined segment.")]
		NOTDEFINED = 0,
	
	}
}

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
	[Guid("567ba75a-1a55-4a9b-bc3d-5f6b6542d9d8")]
	public enum IfcPipeSegmentTypeEnum
	{
		[Description("A covered channel or large pipe that forms a watercourse below ground level, usua" +
	    "lly under a road or railway.")]
		CULVERT = 1,
	
		[Description("A flexible segment is a continuous non-linear segment of pipe that can be deforme" +
	    "d and change the direction of flow.")]
		FLEXIBLESEGMENT = 2,
	
		[Description("A rigid segment is continuous linear segment of pipe that cannot be deformed.")]
		RIGIDSEGMENT = 3,
	
		[Description("A gutter segment is a continuous open-channel segment of pipe.")]
		GUTTER = 4,
	
		[Description("A type of rigid segment that is typically shorter and used for providing connecti" +
	    "vity within a piping network.")]
		SPOOL = 5,
	
		[Description("User-defined segment.")]
		USERDEFINED = -1,
	
		[Description("Undefined segment.")]
		NOTDEFINED = 0,
	
	}
}

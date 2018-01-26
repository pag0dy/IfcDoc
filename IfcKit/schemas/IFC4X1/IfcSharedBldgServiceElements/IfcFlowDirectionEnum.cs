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


namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("042c8e67-4a73-45dd-ab61-63babc988fcf")]
	public enum IfcFlowDirectionEnum
	{
		[Description("A flow source, where a substance flows out of the connection.")]
		SOURCE = 1,
	
		[Description("A flow sink, where a substance flows into the connection.")]
		SINK = 2,
	
		[Description("Both a source and sink, where a substance flows both into and out of the connecti" +
	    "on simultaneously.")]
		SOURCEANDSINK = 3,
	
		[Description("Undefined flow direction.")]
		NOTDEFINED = 0,
	
	}
}

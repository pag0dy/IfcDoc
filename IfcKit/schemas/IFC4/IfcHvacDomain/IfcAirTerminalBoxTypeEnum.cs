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
	[Guid("f7d964ab-4f39-49b5-8e24-a0b2bf6967b3")]
	public enum IfcAirTerminalBoxTypeEnum
	{
		CONSTANTFLOW = 1,
	
		VARIABLEFLOWPRESSUREDEPENDANT = 2,
	
		VARIABLEFLOWPRESSUREINDEPENDANT = 3,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

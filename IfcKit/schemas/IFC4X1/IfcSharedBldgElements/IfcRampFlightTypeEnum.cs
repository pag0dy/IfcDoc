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


namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("83bbf4e9-9816-44a7-9c38-170bf6dfb630")]
	public enum IfcRampFlightTypeEnum
	{
		[Description("A ramp flight with a straight walking line.")]
		STRAIGHT = 1,
	
		[Description("A ramp flight with a circular or elliptic walking line.")]
		SPIRAL = 2,
	
		[Description("User-defined ramp flight.")]
		USERDEFINED = -1,
	
		[Description("Undefined ramp flight.")]
		NOTDEFINED = 0,
	
	}
}

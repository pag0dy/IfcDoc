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


namespace BuildingSmart.IFC.IfcSharedBldgElements
{
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

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
	public enum IfcStairFlightTypeEnum
	{
		[Description("A stair flight with a straight walking line.")]
		STRAIGHT = 1,
	
		[Description("A stair flight with a walking line including straight and curved sections.")]
		WINDER = 2,
	
		[Description("A stair flight with a circular or elliptic walking line.")]
		SPIRAL = 3,
	
		[Description("A stair flight with a curved walking line.")]
		CURVED = 4,
	
		[Description("A stair flight with a free form walking line (and outer boundaries).")]
		FREEFORM = 5,
	
		[Description("User-defined stair flight.")]
		USERDEFINED = -1,
	
		[Description("Undefined stair flight.")]
		NOTDEFINED = 0,
	
	}
}

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
	public enum IfcWindowTypeEnum
	{
		[Description("A standard window usually within a wall opening, as a window panel in a curtain w" +
	    "all, or as a \"free standing\" window.")]
		WINDOW = 1,
	
		[Description("A window within a sloped building element, usually a roof slab.")]
		SKYLIGHT = 2,
	
		[Description("A special window that lies horizonally in a roof slab opening.")]
		LIGHTDOME = 3,
	
		[Description("User-defined window element.")]
		USERDEFINED = -1,
	
		[Description("Undefined window element.")]
		NOTDEFINED = 0,
	
	}
}

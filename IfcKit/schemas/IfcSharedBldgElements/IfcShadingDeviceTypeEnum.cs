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
	public enum IfcShadingDeviceTypeEnum
	{
		[Description("A blind with adjustable horizontal slats for admitting light and air while exclud" +
	    "ing direct sun and rain.")]
		JALOUSIE = 1,
	
		[Description("A mechanical devices that limits the passage of light. Often used as a a solid or" +
	    " louvered movable cover for a window.")]
		SHUTTER = 2,
	
		[Description("A rooflike shelter of canvas or other material extending over a doorway, from the" +
	    " top of a window, over a deck, or similar, in order to provide protection, as fr" +
	    "om the sun.")]
		AWNING = 3,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

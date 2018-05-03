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


namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	public enum IfcDiscreteAccessoryTypeEnum
	{
		[Description("An accessory consisting of a steel plate, shear stud connectors or welded-on reba" +
	    "r which is embedded into the surface of a concrete element so that other element" +
	    "s can be welded or bolted onto it later.")]
		ANCHORPLATE = 1,
	
		[Description("An L-shaped or similarly shaped accessory attached in a corner between elements t" +
	    "o hold them together or to carry a secondary element.")]
		BRACKET = 2,
	
		[Description("A column shoe or a beam shoe (beam hanger) used to support or secure an element.")]
		SHOE = 3,
	
		[Description("User-defined accessory.")]
		USERDEFINED = -1,
	
		[Description("Undefined accessory.")]
		NOTDEFINED = 0,
	
	}
}

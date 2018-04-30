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
	public enum IfcBeamTypeEnum
	{
		[Description("A standard beam usually used horizontally.")]
		BEAM = 1,
	
		[Description("A beam used to support a floor or ceiling.")]
		JOIST = 2,
	
		[Description("A wide often prestressed beam with a hollow-core profile that usually serves as a" +
	    " slab component.")]
		HOLLOWCORE = 3,
	
		[Description("A beam or horizontal piece of material over an opening (e.g. door, window).")]
		LINTEL = 4,
	
		[Description("A tall beam placed on the facade of a building. One tall side is usually finished" +
	    " to provide the exterior of the building. Can be used to support joists or slab " +
	    "elements on its interior side.")]
		SPANDREL = 5,
	
		[Description("A beam that forms part of a slab construction and acts together with the slab whi" +
	    "ch its carries. Such beams are often of T-shape (therefore the English name), bu" +
	    "t may have other shapes as well, e.g. an L-Shape or an Inverted-T-Shape.")]
		T_BEAM = 6,
	
		[Description("User-defined linear beam element.")]
		USERDEFINED = -1,
	
		[Description("Undefined linear beam element.")]
		NOTDEFINED = 0,
	
	}
}

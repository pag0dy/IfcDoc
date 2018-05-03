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


namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public enum IfcSurfaceSide
	{
		[Description("The side of a surface which is in the same direction as the surface normal derive" +
	    "d from the mathematical definition.")]
		POSITIVE = 1,
	
		[Description("The side of a surface which is in the opposite direction than the surface normal " +
	    "derived from the mathematical definition.")]
		NEGATIVE = 2,
	
		[Description("Both, positive and negative side.")]
		BOTH = 3,
	
	}
}

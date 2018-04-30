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


namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	public enum IfcPileConstructionEnum
	{
		[Description("Piles and piers that are excavated and poured in place.")]
		CAST_IN_PLACE = 1,
	
		[Description("iles that are a mix of components, such as a steel outer casing which is driven i" +
	    "nto the ground with a cast-in-place concrete core.")]
		COMPOSITE = 2,
	
		[Description("Piles that are entirely of precast concrete (possibly with some steel or other fi" +
	    "xtures).")]
		PRECAST_CONCRETE = 3,
	
		[Description("Prefabricated piles made entirely out of steel. It will also include steel sheet " +
	    "piles where these are not part of another construction element.")]
		PREFAB_STEEL = 4,
	
		[Description("Special types of pile construction which meet specific local requirements.")]
		USERDEFINED = -1,
	
		[Description("The type of pile construction is not defined.")]
		NOTDEFINED = 0,
	
	}
}

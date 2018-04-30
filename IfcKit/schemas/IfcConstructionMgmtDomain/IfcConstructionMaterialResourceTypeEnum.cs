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


namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	public enum IfcConstructionMaterialResourceTypeEnum
	{
		[Description("Construction aggregate including sand, gravel, and crushed stone.")]
		AGGREGATES = 1,
	
		[Description("Cast-in-place concrete.")]
		CONCRETE = 2,
	
		[Description("Wall board, including gypsum board.")]
		DRYWALL = 3,
	
		[Description("Fuel for running equipment.")]
		FUEL = 4,
	
		[Description("Any gypsum material.")]
		GYPSUM = 5,
	
		[Description("Masonry including brick, stone, concrete block, glass block, and tile.")]
		MASONRY = 6,
	
		[Description("Any metallic material.")]
		METAL = 7,
	
		[Description("Any plastic material.")]
		PLASTIC = 8,
	
		[Description("Any wood material.")]
		WOOD = 9,
	
		[Description("Undefined resource.")]
		NOTDEFINED = 0,
	
		[Description("User-defined resource.")]
		USERDEFINED = -1,
	
	}
}

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
	public enum IfcLaborResourceTypeEnum
	{
		[Description("Coordination of work.")]
		ADMINISTRATION = 1,
	
		[Description("Rough carpentry including framing.")]
		CARPENTRY = 2,
	
		[Description("Removal of dust and debris.")]
		CLEANING = 3,
	
		CONCRETE = 4,
	
		[Description("Gypsum wallboard placement and taping.")]
		DRYWALL = 5,
	
		[Description("Electrical fixtures, equipment, and cables.")]
		ELECTRIC = 6,
	
		[Description("Finish carpentry including custom cabinetry.")]
		FINISHING = 7,
	
		FLOORING = 8,
	
		[Description("General labour not requiring specific skill.")]
		GENERAL = 9,
	
		[Description("Heating and ventilation fixtures, equipment, and ducts.")]
		HVAC = 10,
	
		[Description("Grass, plants, trees, or irrigation.")]
		LANDSCAPING = 11,
	
		[Description("Laying bricks or blocks with mortar.")]
		MASONRY = 12,
	
		[Description("Applying decorative coatings or coverings.")]
		PAINTING = 13,
	
		[Description("Asphalt or concrete roads and walkways.")]
		PAVING = 14,
	
		[Description("Plumbing fixtures, equipment, and pipes.")]
		PLUMBING = 15,
	
		[Description("Membranes, shingles, tile, or other roofing.")]
		ROOFING = 16,
	
		[Description("Excavating, filling, or contouring earth.")]
		SITEGRADING = 17,
	
		[Description("Erecting and attaching steel elements.")]
		STEELWORK = 18,
	
		[Description("Determining positions, distances, and angles.")]
		SURVEYING = 19,
	
		[Description("User-defined resource.")]
		USERDEFINED = -1,
	
		[Description("Undefined resource.")]
		NOTDEFINED = 0,
	
	}
}

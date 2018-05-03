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


namespace BuildingSmart.IFC.IfcProductExtension
{
	public enum IfcElementAssemblyTypeEnum
	{
		[Description("Assembled accessories or components.")]
		ACCESSORY_ASSEMBLY = 1,
	
		[Description("A curved structure.")]
		ARCH = 2,
	
		[Description("Interconnected beams, located in one (typically horizontal) plane.")]
		BEAM_GRID = 3,
	
		[Description("A rigid frame with additional bracing members.")]
		BRACED_FRAME = 4,
	
		[Description("A beam-like superstructure.")]
		GIRDER = 5,
	
		[Description("Assembled reinforcement elements.")]
		REINFORCEMENT_UNIT = 6,
	
		[Description("A structure built up of beams, columns, etc. with moment-resisting joints.")]
		RIGID_FRAME = 7,
	
		[Description("Slabs, laid out in one plane.")]
		SLAB_FIELD = 8,
	
		[Description("A structure built up of members with (quasi) pinned joint.")]
		TRUSS = 9,
	
		[Description("User-defined element assembly.")]
		USERDEFINED = -1,
	
		[Description("Undefined element assembly.")]
		NOTDEFINED = 0,
	
	}
}

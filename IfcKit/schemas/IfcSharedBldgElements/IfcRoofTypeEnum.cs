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
	public enum IfcRoofTypeEnum
	{
		[Description("A roof having no slope, or one with only a slight pitch so as to drain\r\nrainwater" +
	    ".")]
		FLAT_ROOF = 1,
	
		[Description("A roof having a single slope.")]
		SHED_ROOF = 2,
	
		[Description("A roof sloping downward in two parts from a central ridge, so as to form a\r\ngable" +
	    " at each end.")]
		GABLE_ROOF = 3,
	
		[Description("A roof having sloping ends and sides meeting at an inclined projecting\r\nangle.")]
		HIP_ROOF = 4,
	
		[Description("A roof having a hipped end truncating a gable.")]
		HIPPED_GABLE_ROOF = 5,
	
		[Description("A ridged roof divided on each side into a shallower slope above a steeper one.")]
		GAMBREL_ROOF = 6,
	
		[Description("A roof having on each side a steeper lower part and a shallower upper\r\npart.")]
		MANSARD_ROOF = 7,
	
		[Description("A roof or ceiling having a semicylindrical form.")]
		BARREL_ROOF = 8,
	
		[Description("A gable roof in the form of a broad Gothic arch, with gently sloping convex\r\nsurf" +
	    "aces.")]
		RAINBOW_ROOF = 9,
	
		[Description("A roof having two slopes, each descending inward from the eaves.")]
		BUTTERFLY_ROOF = 10,
	
		[Description("A pyramidal hip roof.")]
		PAVILION_ROOF = 11,
	
		[Description("A hemispherical hip roof.")]
		DOME_ROOF = 12,
	
		[Description("Free form roof.")]
		FREEFORM = 13,
	
		[Description("No specification given.")]
		USERDEFINED = -1,
	
		[Description("No specification given.")]
		NOTDEFINED = 0,
	
	}
}

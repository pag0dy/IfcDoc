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
	public enum IfcWallTypeEnum
	{
		[Description("A movable wall that is either movable, such as folding wall or a sliding wall, or" +
	    " can be easily removed as a removable partitioning or mounting wall. Movable wal" +
	    "ls do normally not define space boundaries and often belong to the furnishing sy" +
	    "stem.")]
		MOVABLE = 1,
	
		[Description("A wall-like barrier to protect human occupants from falling, or to prevent the sp" +
	    "read of fires. Often designed at the edge of balconies, terraces or roofs.")]
		PARAPET = 2,
	
		[Description("A wall designed to partition spaces that often has a light-weight, sandwich-like " +
	    "construction (e.g. using gypsum board). Partitioning walls are normally non load" +
	    " bearing.")]
		PARTITIONING = 3,
	
		[Description("A pier, or enclosure, or encasement, normally used to enclose plumbing in sanitar" +
	    "y rooms. Such walls often do not extent to the ceiling.")]
		PLUMBINGWALL = 4,
	
		[Description("A wall designed to withstand shear loads. Such shear walls are often designed hav" +
	    "ing a non-rectangular cross section along the wall path. Also called retaining w" +
	    "alls or supporting walls they are used to protect against soil layers behind.")]
		SHEAR = 5,
	
		[Description("A massive wall construction for the wall core being the single layer or having mu" +
	    "ltiple layers attached. Such walls are often masonry or concrete walls (both cas" +
	    "t in-situ or precast) that are load bearing and fire protecting.")]
		SOLIDWALL = 6,
	
		[Description("A standard wall, extruded vertically with a constant thickness along the wall pat" +
	    "h.")]
		STANDARD = 7,
	
		[Description("A polygonal wall, extruded vertically, where the wall thickness varies along the " +
	    "wall path.\r\n<blockquote class=\"deprecated\">IFC4 DEPRECATION&nbsp; The enumerator" +
	    " POLYGONAL is deprecated and shall no longer be used.</blockquote>")]
		POLYGONAL = 8,
	
		[Description("A stud wall framed with studs and faced with sheetings, sidings, wallboard, or pl" +
	    "asterwork.")]
		ELEMENTEDWALL = 9,
	
		[Description("User-defined wall element.")]
		USERDEFINED = -1,
	
		[Description("Undefined wall element.")]
		NOTDEFINED = 0,
	
	}
}

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


namespace BuildingSmart.IFC.IfcRepresentationResource
{
	public enum IfcGeometricProjectionEnum
	{
		[Description("Geometric display representation that shows an abstract, often 1D element represe" +
	    "ntation, e.g. representing a wall by its axis line.")]
		GRAPH_VIEW = 1,
	
		[Description("Geometric display representation that shows an abstract, often 2D element represe" +
	    "ntation, e.g. representing a wall by its two foot print edges, surpressing any i" +
	    "nner layer representation.")]
		SKETCH_VIEW = 2,
	
		[Description("Geometric display representation that shows a full 3D element representation, e.g" +
	    ". representing a wall by its volumetric body.")]
		MODEL_VIEW = 3,
	
		[Description(@"Geometric display representation that shows a full 2D element representation, the level of detail often depends on the target scale, e.g. representing a wall by its two foot print edges and the edges of all inner layers. The projection is shown in ground view as seen from above.")]
		PLAN_VIEW = 4,
	
		[Description(@"Geometric display representation that shows a full 2D element representation, the level of detail often depends on the target scale, e.g. representing a wall by its two foot print edges and the edges of all inner layers. The projection is shown in ground view as seen from below.")]
		REFLECTED_PLAN_VIEW = 5,
	
		[Description(@"Geometric display representation that shows a full 2D element representation, the level of detail often depends on the target scale, e.g. representing a wall by its two inner/outer edges and the edges of all inner layers, if the element is cut by the section line.")]
		SECTION_VIEW = 6,
	
		[Description("Geometric display representation that shows a full 2D element representation, the" +
	    " level of detail often depends on the target scale, e.g. representing a wall by " +
	    "its bounding edges if the element is within an elevation view.")]
		ELEVATION_VIEW = 7,
	
		[Description("A user defined specification is given by the value of the <em>UserDefinedTargetVi" +
	    "ew</em> attribute.")]
		USERDEFINED = -1,
	
		[Description("No specification given.")]
		NOTDEFINED = 0,
	
	}
}

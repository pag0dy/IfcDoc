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
	public enum IfcVoidingFeatureTypeEnum
	{
		[Description("An internal cutout (creating an opening) or external cutout (creating a recess) o" +
	    "f arbitrary shape.  The edges between cutting planes may be overcut or undercut," +
	    " i.e. rounded.")]
		CUTOUT = 1,
	
		[Description("An external cutout of with a mostly rectangular cutting profile.  The edges betwe" +
	    "en cutting planes may be overcut or undercut, i.e. rounded.")]
		NOTCH = 2,
	
		[Description("A circular or slotted or threaded hole, typically but not necessarily of smaller " +
	    "dimension than what would be considered a cutout.")]
		HOLE = 3,
	
		[Description("A skewed plane end cut, removing material across the entire profile of the voided" +
	    " element.")]
		MITER = 4,
	
		[Description("A skewed plane end cut, removing material only across a part of the profile of th" +
	    "e voided element.")]
		CHAMFER = 5,
	
		[Description(@"A shape modification along an edge of the element with the edge length as the predominant dimension of the feature, and feature profile dimensions which are typically much smaller than the edge length.  Can for example be a chamfer edge (differentiated from a chamfer by its ratio of dimensions and thus usually manufactured differently), rounded edge (a convex edge feature), or fillet edge (a concave edge feature).")]
		EDGE = 6,
	
		[Description("A user-defined type of voiding feature.")]
		USERDEFINED = -1,
	
		[Description("An undefined type of voiding feature.")]
		NOTDEFINED = 0,
	
	}
}

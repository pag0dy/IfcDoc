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
	public enum IfcMemberTypeEnum
	{
		[Description("A linear element (usually sloped) often used for bracing of a girder or truss.")]
		BRACE = 1,
	
		[Description("Upper or lower longitudinal member of a truss, used horizontally or sloped.")]
		CHORD = 2,
	
		[Description("A linear element (usually used horizontally) within a roof structure to connect r" +
	    "afters and posts.")]
		COLLAR = 3,
	
		[Description("A linear element within a girder or truss with no further meaning.")]
		MEMBER = 4,
	
		[Description("A linear element within a curtain wall system to connect two (or more) panels.")]
		MULLION = 5,
	
		[Description("A&nbsp;linear continuous horizontal element in wall framing, such as a head piece" +
	    " or a sole plate.")]
		PLATE = 6,
	
		[Description("A linear member (usually used vertically) within a roof structure to support purl" +
	    "ins.")]
		POST = 7,
	
		[Description("A linear element (usually used horizontally) within a roof structure to support r" +
	    "afters.")]
		PURLIN = 8,
	
		[Description("A linear elements used to support roof slabs or roof covering, usually used with " +
	    "slope.")]
		RAFTER = 9,
	
		[Description("A linear element used to support stair or ramp flights, usually used with slope.")]
		STRINGER = 10,
	
		[Description("A linear element often used within a girder or truss.")]
		STRUT = 11,
	
		[Description("Vertical element in wall framing.")]
		STUD = 12,
	
		[Description("User-defined linear element.")]
		USERDEFINED = -1,
	
		[Description("Undefined linear element.")]
		NOTDEFINED = 0,
	
	}
}

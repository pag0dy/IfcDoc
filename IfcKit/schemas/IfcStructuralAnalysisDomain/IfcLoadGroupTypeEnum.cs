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


namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public enum IfcLoadGroupTypeEnum
	{
		[Description("Groups instances of subtypes of <em>IfcStructuralAction</em>.  It shall be used a" +
	    "s a container for loads grouped together for specific purposes, such as loads wh" +
	    "ich are part of a special load pattern.")]
		LOAD_GROUP = 1,
	
		[Description("Groups LOAD_GROUPs and instances of subtypes of <em>IfcStructuralAction</em>.\r\n  " +
	    "    It should be used as a container for loads with the same origin.")]
		LOAD_CASE = 2,
	
		[Description(@"An intermediate level between LOAD_CASE and LOAD_COMBINATION.  This level is obsolete and deprecated.  Before the introduction of <em>IfcRelAssignsToGroupByFactor</em>, the purpose of this level was to provide a factor with which one or more LOAD_CASEs occur in a LOAD_COMBINATION.")]
		LOAD_COMBINATION = 3,
	
		[Description("A grouping level which does not follow the standard hierarchy of load group types" +
	    ".")]
		USERDEFINED = -1,
	
		[Description("The grouping level is not yet known.")]
		NOTDEFINED = 0,
	
	}
}

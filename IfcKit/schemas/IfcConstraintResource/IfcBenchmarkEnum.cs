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


namespace BuildingSmart.IFC.IfcConstraintResource
{
	public enum IfcBenchmarkEnum
	{
		[Description("Identifies that a value must be greater than that set by the constraint.")]
		GREATERTHAN = 1,
	
		[Description("Identifies that a value must be either greater than or equal to that set by the c" +
	    "onstraint.")]
		GREATERTHANOREQUALTO = 2,
	
		[Description("Identifies that a value must be less than that set by the constraint.")]
		LESSTHAN = 3,
	
		[Description("Identifies that a value must be either less than or equal to that set by the cons" +
	    "traint.")]
		LESSTHANOREQUALTO = 4,
	
		[Description("Identifies that a value must be equal to that set by the constraint.")]
		EQUALTO = 5,
	
		[Description("Identifies that a value must be not equal to that set by the constraint.")]
		NOTEQUALTO = 6,
	
		[Description("Identifies that an aggregation (set, list or table) must include the value (indiv" +
	    "idual item) set by the constraint.")]
		INCLUDES = 7,
	
		[Description("Identifies that an aggregation (set, list or table) must not include the value (i" +
	    "ndividual item) set by the constraint.")]
		NOTINCLUDES = 8,
	
		[Description("Identifies that a value (individual item) must be included in the aggregation (se" +
	    "t, list or table) set by the constraint.")]
		INCLUDEDIN = 9,
	
		[Description("Identifies that a value (individual item) must not be included in the aggregation" +
	    " (set, list or table) set by the constraint.")]
		NOTINCLUDEDIN = 10,
	
	}
}

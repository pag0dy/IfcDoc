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
	public enum IfcObjectiveEnum
	{
		[Description("A constraint whose objective is to ensure satisfaction of a code compliance provi" +
	    "sion.")]
		CODECOMPLIANCE = 1,
	
		[Description("A constraint whose objective is to identify an agreement that code compliance req" +
	    "uirements (the waiver) will not be enforced.")]
		CODEWAIVER = 2,
	
		[Description("A constraint whose objective is to ensure satisfaction of a design intent provisi" +
	    "on.")]
		DESIGNINTENT = 3,
	
		[Description("A constraint whose objective is to synchronize data with an external source such " +
	    "as a file")]
		EXTERNAL = 4,
	
		[Description("A constraint whose objective is to ensure satisfaction of a health and safety pro" +
	    "vision.")]
		HEALTHANDSAFETY = 5,
	
		[Description("A constraint whose objective is to resolve a conflict such as merging data from m" +
	    "ultiple sources.")]
		MERGECONFLICT = 6,
	
		[Description("A constraint whose objective is to ensure data conforms to a model view definitio" +
	    "n.")]
		MODELVIEW = 7,
	
		[Description("A constraint whose objective is to calculate a value based on other referenced va" +
	    "lues.")]
		PARAMETER = 8,
	
		[Description("A constraint whose objective is to ensure satisfaction of a project requirement p" +
	    "rovision.")]
		REQUIREMENT = 9,
	
		[Description("A constraint whose objective is to ensure satisfaction of a specification provisi" +
	    "on.")]
		SPECIFICATION = 10,
	
		[Description("A constraint whose objective is to indicate a limiting value beyond which the con" +
	    "dition of an object requires a particular form of attention.")]
		TRIGGERCONDITION = 11,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

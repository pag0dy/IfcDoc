// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
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
	[Guid("2748cd36-46fe-4341-ae53-402b2961c867")]
	public enum IfcConstraintEnum
	{
		[Description("Qualifies a constraint such that it must be followed rigidly within or at the val" +
	    "ues set.")]
		HARD = 1,
	
		[Description("Qualifies a constraint such that it should be followed within or at the values se" +
	    "t.")]
		SOFT = 2,
	
		[Description("Qualifies a constraint such that it is advised that it is followed within or at t" +
	    "he values set.")]
		ADVISORY = 3,
	
		[Description("A user-defined grade indicated by a separate attribute at the referencing entity." +
	    "")]
		USERDEFINED = -1,
	
		[Description("Grade has not been specified.")]
		NOTDEFINED = 0,
	
	}
}

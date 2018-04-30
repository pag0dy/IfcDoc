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
	public enum IfcStructuralSurfaceMemberTypeEnum
	{
		[Description("A member with capacity to carry out-of-plane loads, i.e. a plate.")]
		BENDING_ELEMENT = 1,
	
		[Description("A member with capacity to carry in-plane loads, for example a shear wall.")]
		MEMBRANE_ELEMENT = 2,
	
		[Description("A member with capacity to carry in-plane and out-of-plane loads, i.e. a combinati" +
	    "on of bending element and membrane element.")]
		SHELL = 3,
	
		[Description("A specially defined member.")]
		USERDEFINED = -1,
	
		[Description("A member without further categorization.")]
		NOTDEFINED = 0,
	
	}
}

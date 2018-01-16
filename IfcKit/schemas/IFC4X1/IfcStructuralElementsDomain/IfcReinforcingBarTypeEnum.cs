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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("1656cf81-cd34-42bf-86b0-74dffe040064")]
	public enum IfcReinforcingBarTypeEnum
	{
		[Description("Anchoring reinforcement.")]
		ANCHORING = 1,
	
		[Description("Edge reinforcement.")]
		EDGE = 2,
	
		[Description("The reinforcing bar is a ligature (link, stirrup).")]
		LIGATURE = 3,
	
		[Description("The reinforcing bar is a main bar.")]
		MAIN = 4,
	
		[Description("Punching reinforcement.")]
		PUNCHING = 5,
	
		[Description("Ring reinforcement.")]
		RING = 6,
	
		[Description("The reinforcing bar is a shear bar.")]
		SHEAR = 7,
	
		[Description("The reinforcing bar is a stud.")]
		STUD = 8,
	
		[Description("The type of reinforcement is user defined.")]
		USERDEFINED = -1,
	
		[Description("The type of reinforcement is not defined.")]
		NOTDEFINED = 0,
	
	}
}

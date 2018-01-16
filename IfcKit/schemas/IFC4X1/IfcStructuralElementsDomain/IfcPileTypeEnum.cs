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
	[Guid("7cb56ae1-a2b6-4aab-9ea7-f330ae1f6145")]
	public enum IfcPileTypeEnum
	{
		[Description("A bore pile.")]
		BORED = 1,
	
		[Description("A rammed, vibrated, or otherwise driven pile.")]
		DRIVEN = 2,
	
		[Description("An injected pile-like construction.")]
		JETGROUTING = 3,
	
		[Description("A cohesion pile.")]
		COHESION = 4,
	
		[Description("A friction pile.")]
		FRICTION = 5,
	
		[Description("A support pile.")]
		SUPPORT = 6,
	
		[Description("The type of pile function is user defined.")]
		USERDEFINED = -1,
	
		[Description("The type of pile function is not defined.")]
		NOTDEFINED = 0,
	
	}
}

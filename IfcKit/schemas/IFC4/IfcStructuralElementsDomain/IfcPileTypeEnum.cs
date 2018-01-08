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
		BORED = 1,
	
		DRIVEN = 2,
	
		JETGROUTING = 3,
	
		COHESION = 4,
	
		FRICTION = 5,
	
		SUPPORT = 6,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

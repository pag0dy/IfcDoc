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
		ANCHORING = 1,
	
		EDGE = 2,
	
		LIGATURE = 3,
	
		MAIN = 4,
	
		PUNCHING = 5,
	
		RING = 6,
	
		SHEAR = 7,
	
		STUD = 8,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

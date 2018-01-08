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
	[Guid("52c14141-4c0d-4b48-bcad-73ef235b58b9")]
	public enum IfcPileConstructionEnum
	{
		CAST_IN_PLACE = 1,
	
		COMPOSITE = 2,
	
		PRECAST_CONCRETE = 3,
	
		PREFAB_STEEL = 4,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

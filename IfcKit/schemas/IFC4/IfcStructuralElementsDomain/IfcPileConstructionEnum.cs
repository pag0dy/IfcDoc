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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("93418a1d-57d9-4625-9a3a-a84fa42e9770")]
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

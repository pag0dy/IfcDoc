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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("ff0e20e2-fa00-4223-b337-b4bff645a7cd")]
	public enum IfcEvaporatorTypeEnum
	{
		DIRECTEXPANSIONSHELLANDTUBE = 1,
	
		DIRECTEXPANSIONTUBEINTUBE = 2,
	
		DIRECTEXPANSIONBRAZEDPLATE = 3,
	
		FLOODEDSHELLANDTUBE = 4,
	
		SHELLANDCOIL = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

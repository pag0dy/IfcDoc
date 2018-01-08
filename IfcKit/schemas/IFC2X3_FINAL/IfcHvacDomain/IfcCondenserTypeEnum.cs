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
	[Guid("570846fb-0d79-4289-a95b-dd7e45a802d9")]
	public enum IfcCondenserTypeEnum
	{
		WATERCOOLEDSHELLTUBE = 1,
	
		WATERCOOLEDSHELLCOIL = 2,
	
		WATERCOOLEDTUBEINTUBE = 3,
	
		WATERCOOLEDBRAZEDPLATE = 4,
	
		AIRCOOLED = 5,
	
		EVAPORATIVECOOLED = 6,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

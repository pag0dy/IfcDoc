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
	[Guid("26fef7e6-1be3-450b-ad35-24e5e2077f41")]
	public enum IfcFanTypeEnum
	{
		CENTRIFUGALFORWARDCURVED = 1,
	
		CENTRIFUGALRADIAL = 2,
	
		CENTRIFUGALBACKWARDINCLINEDCURVED = 3,
	
		CENTRIFUGALAIRFOIL = 4,
	
		TUBEAXIAL = 5,
	
		VANEAXIAL = 6,
	
		PROPELLORAXIAL = 7,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

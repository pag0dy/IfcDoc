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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("fc0dac05-25d9-47f7-b430-9ed240490643")]
	public enum IfcSpatialZoneTypeEnum
	{
		[Description("The spatial zone is used to represent a construction zone for the production proc" +
	    "ess.")]
		CONSTRUCTION = 1,
	
		[Description("The spatial zone is used to represent a fire safety zone, or fire compartment.")]
		FIRESAFETY = 2,
	
		[Description("The spatial zone is used to represent a lighting zone; a daylight zone, or an art" +
	    "ificial lighting zone.")]
		LIGHTING = 3,
	
		[Description("The spatial zone is used to represent a zone of particular occupancy.")]
		OCCUPANCY = 4,
	
		[Description("The spatial zone is used to represent a zone for security planning and maintainan" +
	    "ce work.")]
		SECURITY = 5,
	
		[Description("The spatial zone is used to represent a thermal zone.")]
		THERMAL = 6,
	
		TRANSPORT = 7,
	
		[Description("The spatial zone is used to represent a ventilation zone.")]
		VENTILATION = 8,
	
		[Description("User defined type spatial zone.")]
		USERDEFINED = -1,
	
		[Description("Undefined type spatial zone.")]
		NOTDEFINED = 0,
	
	}
}

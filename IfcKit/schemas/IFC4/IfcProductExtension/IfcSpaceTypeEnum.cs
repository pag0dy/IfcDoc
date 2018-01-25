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
	[Guid("258540e7-efd8-4560-9430-d5d91dccadab")]
	public enum IfcSpaceTypeEnum
	{
		[Description("Any space not falling into another category.")]
		SPACE = 1,
	
		[Description("A space dedication for use as a parking spot for vehicles, including access, such" +
	    " as a parking aisle.")]
		PARKING = 2,
	
		[Description("Gross Floor Area - a specific kind of space for each building story that includes" +
	    " all net area and construction area (also the external envelop). Provision of su" +
	    "ch a specific space is often required by regulations.")]
		GFA = 3,
	
		INTERNAL = 4,
	
		EXTERNAL = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

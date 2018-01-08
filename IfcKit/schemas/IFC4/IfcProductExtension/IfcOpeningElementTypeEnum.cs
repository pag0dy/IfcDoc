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
	[Guid("22c93b58-3ef6-4331-b7b0-7206d49176a7")]
	public enum IfcOpeningElementTypeEnum
	{
		[Description(@"An opening as subtraction feature that cuts through the element it voids. It thereby creates a hole. An opening in addiion have a particular meaning for either providing a void for doors or windows, or an opening to permit flow of air and passing of light.")]
		OPENING = 1,
	
		[Description("An opening as subtraction feature that does not cut through the element it voids." +
	    " It creates a niche or similar voiding pattern.")]
		RECESS = 2,
	
		[Description("User-defined opening element.")]
		USERDEFINED = -1,
	
		[Description("Undefined opening element.")]
		NOTDEFINED = 0,
	
	}
}

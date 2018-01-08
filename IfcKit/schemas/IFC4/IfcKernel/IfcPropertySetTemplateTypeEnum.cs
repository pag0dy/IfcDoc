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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("5b947aef-6aa0-4445-9aa5-684518845381")]
	public enum IfcPropertySetTemplateTypeEnum
	{
		PSET_TYPEDRIVENONLY = 1,
	
		PSET_TYPEDRIVENOVERRIDE = 2,
	
		PSET_OCCURRENCEDRIVEN = 3,
	
		PSET_PERFORMANCEDRIVEN = 4,
	
		QTO_TYPEDRIVENONLY = 5,
	
		QTO_TYPEDRIVENOVERRIDE = 6,
	
		QTO_OCCURRENCEDRIVEN = 7,
	
		NOTDEFINED = 0,
	
	}
}

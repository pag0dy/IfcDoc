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
		[Description("The property sets defined by this <em>IfcPropertySetTemplate</em> can only be ass" +
	    "igned to subtypes of <em>IfcTypeObject</em>.")]
		PSET_TYPEDRIVENONLY = 1,
	
		[Description("The property sets defined by this <em>IfcPropertySetTemplate</em> can be assigned" +
	    "\r\nto subtypes of <em>IfcTypeObject</em> and can be overridden by a\r\nproperty set" +
	    " with same name at subtypes of <em>IfcObject</em>.")]
		PSET_TYPEDRIVENOVERRIDE = 2,
	
		[Description("The property sets defined by this <em>IfcPropertySetTemplate</em> can only be ass" +
	    "igned to subtypes of <em>IfcObject</em>.")]
		PSET_OCCURRENCEDRIVEN = 3,
	
		[Description("The property sets defined by this <em>IfcPropertySetTemplate</em> can only be ass" +
	    "igned to <em>IfcPerformanceHistory</em>.")]
		PSET_PERFORMANCEDRIVEN = 4,
	
		[Description("The element quantity defined by this <em>IfcPropertySetTemplate</em> can only be " +
	    "assigned to subtypes of <em>IfcTypeObject</em>.")]
		QTO_TYPEDRIVENONLY = 5,
	
		[Description("The element quantity defined by this <em>IfcPropertySetTemplate</em> can be\r\nassi" +
	    "gned to subtypes of <em>IfcTypeObject</em> and can be overridden\r\nby an element " +
	    "quantity with same name at subtypes of <em>IfcObject</em>.")]
		QTO_TYPEDRIVENOVERRIDE = 6,
	
		[Description("The element quantity defined by this <em>IfcPropertySetTemplate</em> can only be\r" +
	    "\nassigned to subtypes of <em>IfcObject</em>.")]
		QTO_OCCURRENCEDRIVEN = 7,
	
		[Description("No restriction provided, the property sets defined by this <em>IfcPropertySetTemp" +
	    "late</em> can be assigned to any entity, if not\r\notherwise restricted by the <em" +
	    ">ApplicableEntity</em> attribute.")]
		NOTDEFINED = 0,
	
	}
}

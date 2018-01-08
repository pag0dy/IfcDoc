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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("06a1121d-2dcf-4d2c-bb52-4a6efb451358")]
	public enum IfcDoorTypeEnum
	{
		[Description("A standard door usually within a wall opening, as a door panel in a curtain wall," +
	    " or as a \"free standing\" door.")]
		DOOR = 1,
	
		[Description("A gate is a point of entry to a property usually within an opening in a fence. Or" +
	    " as a \"free standing\" gate.")]
		GATE = 2,
	
		[Description("A special door that lies horizonally in a slab opening. Often used for accessing " +
	    "cellar or attic.")]
		TRAPDOOR = 3,
	
		[Description("User-defined linear beam element.")]
		USERDEFINED = -1,
	
		[Description("Undefined linear beam element.")]
		NOTDEFINED = 0,
	
	}
}

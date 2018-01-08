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
using BuildingSmart.IFC.IfcSharedBldgElements;

namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	[Guid("9ba90fa0-a44e-4cad-aa35-3e34cd35f1da")]
	public enum IfcPermeableCoveringOperationEnum
	{
		[Description("Protective screen of metal bars or wires.")]
		GRILL = 1,
	
		[Description("Set of fixed or movable strips of wood, metal, etc. arranged to let air in while " +
	    "keeping light or rain out.")]
		LOUVER = 2,
	
		[Description("Upright, fixed or movable, sometimes folding framework used for protection agains" +
	    "t heat, light, access or similar.")]
		SCREEN = 3,
	
		[Description("User defined permeable covering type.")]
		USERDEFINED = -1,
	
		[Description("No information available.")]
		NOTDEFINED = 0,
	
	}
}

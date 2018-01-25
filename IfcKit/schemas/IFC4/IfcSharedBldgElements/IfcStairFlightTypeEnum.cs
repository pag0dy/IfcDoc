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
	[Guid("e7f6683a-cc31-4b75-a0af-20d4b19bf25f")]
	public enum IfcStairFlightTypeEnum
	{
		[Description("A stair flight with a straight walking line.")]
		STRAIGHT = 1,
	
		[Description("A stair flight with a walking line including straight and curved sections.")]
		WINDER = 2,
	
		[Description("A stair flight with a circular or elliptic walking line.")]
		SPIRAL = 3,
	
		[Description("A stair flight with a curved walking line.")]
		CURVED = 4,
	
		[Description("A stair flight with a free form walking line (and outer boundaries).")]
		FREEFORM = 5,
	
		[Description("User-defined stair flight.")]
		USERDEFINED = -1,
	
		[Description("Undefined stair flight.")]
		NOTDEFINED = 0,
	
	}
}

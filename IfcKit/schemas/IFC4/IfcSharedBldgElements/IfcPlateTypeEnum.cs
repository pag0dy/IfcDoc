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
	[Guid("3b149038-4987-4e19-83ac-2260d7373f6c")]
	public enum IfcPlateTypeEnum
	{
		[Description("A planar element within a curtain wall, often consisting of a frame with fixed gl" +
	    "azing.")]
		CURTAIN_PANEL = 1,
	
		[Description("A planar, flat and thin element, comes usually as metal sheet, and is often used " +
	    "as an additonal part within an assembly.")]
		SHEET = 2,
	
		[Description("User-defined linear element.")]
		USERDEFINED = -1,
	
		[Description("Undefined linear element.")]
		NOTDEFINED = 0,
	
	}
}

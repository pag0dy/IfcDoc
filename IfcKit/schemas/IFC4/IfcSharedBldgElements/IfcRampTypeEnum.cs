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
	[Guid("4b5ed5c2-face-4475-8fa7-a0c300d57c37")]
	public enum IfcRampTypeEnum
	{
		STRAIGHT_RUN_RAMP = 1,
	
		TWO_STRAIGHT_RUN_RAMP = 2,
	
		QUARTER_TURN_RAMP = 3,
	
		TWO_QUARTER_TURN_RAMP = 4,
	
		HALF_TURN_RAMP = 5,
	
		SPIRAL_RAMP = 6,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

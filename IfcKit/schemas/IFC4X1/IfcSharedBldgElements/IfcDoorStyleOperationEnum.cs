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
	[Guid("6ae37da6-cb93-4da3-931f-4c841be025e8")]
	public enum IfcDoorStyleOperationEnum
	{
		SINGLE_SWING_LEFT = 1,
	
		SINGLE_SWING_RIGHT = 2,
	
		DOUBLE_DOOR_SINGLE_SWING = 3,
	
		DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT = 4,
	
		DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT = 5,
	
		DOUBLE_SWING_LEFT = 6,
	
		DOUBLE_SWING_RIGHT = 7,
	
		DOUBLE_DOOR_DOUBLE_SWING = 8,
	
		SLIDING_TO_LEFT = 9,
	
		SLIDING_TO_RIGHT = 10,
	
		DOUBLE_DOOR_SLIDING = 11,
	
		FOLDING_TO_LEFT = 12,
	
		FOLDING_TO_RIGHT = 13,
	
		DOUBLE_DOOR_FOLDING = 14,
	
		REVOLVING = 15,
	
		ROLLINGUP = 16,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

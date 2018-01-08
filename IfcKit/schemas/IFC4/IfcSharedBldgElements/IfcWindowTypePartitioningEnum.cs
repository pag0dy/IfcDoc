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
	[Guid("b6cac0a6-762e-4fab-8754-0e2d41c57ca8")]
	public enum IfcWindowTypePartitioningEnum
	{
		SINGLE_PANEL = 1,
	
		DOUBLE_PANEL_VERTICAL = 2,
	
		DOUBLE_PANEL_HORIZONTAL = 3,
	
		TRIPLE_PANEL_VERTICAL = 4,
	
		TRIPLE_PANEL_BOTTOM = 5,
	
		TRIPLE_PANEL_TOP = 6,
	
		TRIPLE_PANEL_LEFT = 7,
	
		TRIPLE_PANEL_RIGHT = 8,
	
		TRIPLE_PANEL_HORIZONTAL = 9,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

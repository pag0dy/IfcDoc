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
	[Guid("a1d59ae5-c0a1-41f8-bba7-1fc78ba81d82")]
	public enum IfcWindowStyleOperationEnum
	{
		[Description("Window with one panel.")]
		SINGLE_PANEL = 1,
	
		[Description("Window with two panels. The configuration of the panels is vertically.")]
		DOUBLE_PANEL_VERTICAL = 2,
	
		[Description("Window with two panels. The configuration of the panels is\r\nhorizontally.")]
		DOUBLE_PANEL_HORIZONTAL = 3,
	
		[Description("Window with three panels. The configuration of the panels is\r\nvertically.")]
		TRIPLE_PANEL_VERTICAL = 4,
	
		[Description("Window with three panels. The configuration of two panels is vertically and\r\nthe " +
	    "third one is horizontally at the bottom.")]
		TRIPLE_PANEL_BOTTOM = 5,
	
		[Description("Window with three panels. The configuration of two panels is vertically and\r\nthe " +
	    "third one is horizontally at the top.")]
		TRIPLE_PANEL_TOP = 6,
	
		[Description("Window with three panels. The configuration of two panels is horizontally and\r\nth" +
	    "e third one is vertically at the left hand side.")]
		TRIPLE_PANEL_LEFT = 7,
	
		[Description("Window with three panels. The configuration of two panels is horizontally and\r\nth" +
	    "e third one is vertically at the right hand side.")]
		TRIPLE_PANEL_RIGHT = 8,
	
		[Description("Window with three panels. The configuration of the panels is horizontally.")]
		TRIPLE_PANEL_HORIZONTAL = 9,
	
		[Description("user defined operation type")]
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

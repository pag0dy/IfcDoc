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
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("05c133a9-fc17-4922-9dc6-eb3432919416")]
	public enum IfcWorkScheduleTypeEnum
	{
		[Description("A control in which actual items undertaken are indicated.")]
		ACTUAL = 1,
	
		[Description("A control that is a baseline from which changes that are made later can be recogn" +
	    "ized.")]
		BASELINE = 2,
	
		[Description("A control showing planned items.")]
		PLANNED = 3,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

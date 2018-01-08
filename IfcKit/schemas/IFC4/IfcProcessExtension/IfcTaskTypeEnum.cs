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
	[Guid("8747d965-7b28-49e9-828a-dd743865fe45")]
	public enum IfcTaskTypeEnum
	{
		ATTENDANCE = 1,
	
		CONSTRUCTION = 2,
	
		DEMOLITION = 3,
	
		DISMANTLE = 4,
	
		DISPOSAL = 5,
	
		INSTALLATION = 6,
	
		LOGISTIC = 7,
	
		MAINTENANCE = 8,
	
		MOVE = 9,
	
		OPERATION = 10,
	
		REMOVAL = 11,
	
		RENOVATION = 12,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

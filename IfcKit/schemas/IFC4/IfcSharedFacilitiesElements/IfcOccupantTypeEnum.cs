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
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	[Guid("5f4a5ce1-1ce4-4576-b7e3-325a91036fc6")]
	public enum IfcOccupantTypeEnum
	{
		ASSIGNEE = 1,
	
		ASSIGNOR = 2,
	
		LESSEE = 3,
	
		LESSOR = 4,
	
		LETTINGAGENT = 5,
	
		OWNER = 6,
	
		TENANT = 7,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

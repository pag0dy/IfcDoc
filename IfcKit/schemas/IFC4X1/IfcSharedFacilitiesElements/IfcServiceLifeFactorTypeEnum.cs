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
	[Guid("0cf8cfc3-7340-4d7e-91a8-4e6121e749fb")]
	public enum IfcServiceLifeFactorTypeEnum
	{
		A_QUALITYOFCOMPONENTS = 1,
	
		B_DESIGNLEVEL = 2,
	
		C_WORKEXECUTIONLEVEL = 3,
	
		D_INDOORENVIRONMENT = 4,
	
		E_OUTDOORENVIRONMENT = 5,
	
		F_INUSECONDITIONS = 6,
	
		G_MAINTENANCELEVEL = 7,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

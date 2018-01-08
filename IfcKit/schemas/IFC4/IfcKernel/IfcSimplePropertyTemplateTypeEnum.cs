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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("b2a7549b-6fd9-4702-97c1-6ea8757cd5f8")]
	public enum IfcSimplePropertyTemplateTypeEnum
	{
		P_SINGLEVALUE = 1,
	
		P_ENUMERATEDVALUE = 2,
	
		P_BOUNDEDVALUE = 3,
	
		P_LISTVALUE = 4,
	
		P_TABLEVALUE = 5,
	
		P_REFERENCEVALUE = 6,
	
		Q_LENGTH = 7,
	
		Q_AREA = 8,
	
		Q_VOLUME = 9,
	
		Q_COUNT = 10,
	
		Q_WEIGHT = 11,
	
		Q_TIME = 12,
	
	}
}

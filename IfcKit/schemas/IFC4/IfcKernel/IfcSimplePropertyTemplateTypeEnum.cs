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
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertySingleValue</em>.")]
		P_SINGLEVALUE = 1,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyEnumeratedValue</em>.")]
		P_ENUMERATEDVALUE = 2,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyBoundedValue</em>.")]
		P_BOUNDEDVALUE = 3,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyListValue</em>.")]
		P_LISTVALUE = 4,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyTableValue</em>.")]
		P_TABLEVALUE = 5,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyReferenceValue</em>.")]
		P_REFERENCEVALUE = 6,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityLength</em>.")]
		Q_LENGTH = 7,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityArea</em>.")]
		Q_AREA = 8,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityVolume</em>.")]
		Q_VOLUME = 9,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityCount</em>.")]
		Q_COUNT = 10,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityWeight</em>.")]
		Q_WEIGHT = 11,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityTime</em>.")]
		Q_TIME = 12,
	
	}
}

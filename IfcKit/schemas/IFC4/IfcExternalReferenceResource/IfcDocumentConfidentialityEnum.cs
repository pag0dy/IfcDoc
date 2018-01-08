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
using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("f90953b1-d6ec-4f78-8d2e-37fd79e54923")]
	public enum IfcDocumentConfidentialityEnum
	{
		[Description("Document is publicly available.")]
		PUBLIC = 1,
	
		[Description("Document availability is restricted.")]
		RESTRICTED = 2,
	
		[Description("Document is confidential and its contents should not be revealed without permissi" +
	    "on.")]
		CONFIDENTIAL = 3,
	
		[Description("Document is personal to the author.")]
		PERSONAL = 4,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

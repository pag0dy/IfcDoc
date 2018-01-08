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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	[Guid("20072f21-253d-40a9-9284-990b84bbbf78")]
	public enum IfcObjectiveEnum
	{
		CODECOMPLIANCE = 1,
	
		CODEWAIVER = 2,
	
		DESIGNINTENT = 3,
	
		EXTERNAL = 4,
	
		HEALTHANDSAFETY = 5,
	
		MERGECONFLICT = 6,
	
		MODELVIEW = 7,
	
		PARAMETER = 8,
	
		REQUIREMENT = 9,
	
		SPECIFICATION = 10,
	
		TRIGGERCONDITION = 11,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}

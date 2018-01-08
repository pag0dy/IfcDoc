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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcUtilityResource
{
	[Guid("5d948a69-63db-4931-ad1a-2ba2aa984abf")]
	public enum IfcStateEnum
	{
		READWRITE = 1,
	
		READONLY = 2,
	
		LOCKED = 3,
	
		READWRITELOCKED = 4,
	
		READONLYLOCKED = 5,
	
	}
}

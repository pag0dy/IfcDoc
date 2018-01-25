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
	[Guid("1afa18fb-05b5-4f13-9da6-ba569b706c6b")]
	public enum IfcChangeActionEnum
	{
		[Description("Object has not been modified.")]
		NOCHANGE = 1,
	
		[Description("A modification to the object has been made by the user and application defined by" +
	    " the LastModifyingUser and LastModifyingApplication respectively.")]
		MODIFIED = 2,
	
		[Description("The object has been created by the user and application defined by the OwningUser" +
	    " and OwningApplication respectively.")]
		ADDED = 3,
	
		[Description("The object has been deleted by the user and application defined by the LastModify" +
	    "ingUser and LastModifyingApplication respectively.")]
		DELETED = 4,
	
		[Description("The change action is not known or has not been defined.")]
		NOTDEFINED = 0,
	
	}
}

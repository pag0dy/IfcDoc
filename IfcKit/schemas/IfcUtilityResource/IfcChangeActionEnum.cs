// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace BuildingSmart.IFC.IfcUtilityResource
{
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

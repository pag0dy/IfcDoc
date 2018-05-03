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


namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	public enum IfcActionRequestTypeEnum
	{
		[Description("Request was made through email.")]
		EMAIL = 1,
	
		[Description("Request was made through facsimile.")]
		FAX = 2,
	
		[Description("Request was made verbally over a telephone.")]
		PHONE = 3,
	
		[Description("Request was made through postal mail.")]
		POST = 4,
	
		[Description("Request was made verbally in person.")]
		VERBAL = 5,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

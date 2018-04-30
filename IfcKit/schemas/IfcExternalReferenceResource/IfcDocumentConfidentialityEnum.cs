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


namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
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

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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcActorResource
{
	[Guid("bcc21d65-0771-441d-9a6c-1d8a7e5f4be4")]
	public enum IfcAddressTypeEnum
	{
		[Description("An office address.")]
		OFFICE = 1,
	
		[Description("A site address.")]
		SITE = 2,
	
		[Description("A home address.")]
		HOME = 3,
	
		[Description("A postal distribution point address.")]
		DISTRIBUTIONPOINT = 4,
	
		[Description("A user defined address type to be provided.")]
		USERDEFINED = -1,
	
	}
}

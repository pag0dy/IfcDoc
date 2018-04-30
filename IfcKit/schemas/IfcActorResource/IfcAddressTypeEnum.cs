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


namespace BuildingSmart.IFC.IfcActorResource
{
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

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


namespace BuildingSmart.IFC.IfcElectricalDomain
{
	[Guid("bf4b64a6-702c-46cb-838a-31e1e04efb1a")]
	public enum IfcCableCarrierFittingTypeEnum
	{
		[Description("A fitting that changes the route of the cable carrier.")]
		BEND = 1,
	
		[Description("A fitting at which two branches are taken from the main route of the cable carrie" +
	    "r simultaneously.")]
		CROSS = 2,
	
		[Description("A fitting that changes the physical size of the main route of the cable carrier.")]
		REDUCER = 3,
	
		[Description("A fitting at which a branch is taken from the main route of the cable carrier.")]
		TEE = 4,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}

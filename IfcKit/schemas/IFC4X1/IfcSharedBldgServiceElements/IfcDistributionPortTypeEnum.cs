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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("7946d16d-2b14-4eac-b58e-3334970d8dfc")]
	public enum IfcDistributionPortTypeEnum
	{
		[Description("Connection to cable segment or fitting for distribution of electricity.")]
		CABLE = 1,
	
		[Description("Connection to cable carrier segment or fitting for enclosing cables.")]
		CABLECARRIER = 2,
	
		[Description("Connection to duct segment or fitting for distribution of air.")]
		DUCT = 3,
	
		[Description("Connection to pipe segment or fitting for distribution of solid, liquid, or gas.")]
		PIPE = 4,
	
		[Description("User-defined port type.")]
		USERDEFINED = -1,
	
		[Description("Undefined port type.")]
		NOTDEFINED = 0,
	
	}
}

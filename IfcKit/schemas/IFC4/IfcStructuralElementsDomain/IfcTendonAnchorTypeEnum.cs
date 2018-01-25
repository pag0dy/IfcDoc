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
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("fcdc099e-17dd-4a15-aa70-6c6f0cc7831e")]
	public enum IfcTendonAnchorTypeEnum
	{
		[Description("The anchor is an intermediate device which connects two tendons.")]
		COUPLER = 1,
	
		[Description("The anchor fixes the end of a tendon.")]
		FIXED_END = 2,
	
		[Description("The anchor is used or can be used to prestress the tendon.")]
		TENSIONING_END = 3,
	
		[Description("The type of tendon anchor is user defined.")]
		USERDEFINED = -1,
	
		[Description("The type of tendon anchor is not defined.")]
		NOTDEFINED = 0,
	
	}
}

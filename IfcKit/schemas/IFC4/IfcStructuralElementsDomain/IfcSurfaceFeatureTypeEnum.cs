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
	[Guid("23c5290c-a335-4266-9cd5-def5b8c3f893")]
	public enum IfcSurfaceFeatureTypeEnum
	{
		[Description("A point, line, cross, or other mark, applied for example for easier adjustment of" +
	    " elements during assembly.")]
		MARK = 1,
	
		[Description("A name tag, which allows to identify an element during production, delivery and a" +
	    "ssembly.  May be manufactured in different ways, e.g. by printing or punching th" +
	    "e tracking code onto the element or by attaching an actual tag.")]
		TAG = 2,
	
		[Description("A subtractive surface feature, e.g. grinding, or an additive surface feature, e.g" +
	    ". coating, or an impregnating treatment, or a series of any of these kinds of tr" +
	    "eatments.")]
		TREATMENT = 3,
	
		[Description("A user-defined type of surface feature.")]
		USERDEFINED = -1,
	
		[Description("An undefined type of surface feature.")]
		NOTDEFINED = 0,
	
	}
}

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


namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
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

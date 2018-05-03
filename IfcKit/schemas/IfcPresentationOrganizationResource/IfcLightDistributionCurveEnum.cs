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


namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	public enum IfcLightDistributionCurveEnum
	{
		[Description("Type A is basically not used. For completeness the Type A Photometry equals the T" +
	    "ype B rotated 90&deg; around the Z-Axis counter clockwise.")]
		TYPE_A = 1,
	
		[Description("Type B is sometimes used for floodlights. The B-Plane System has a horizontal axi" +
	    "s. B-Angles are valid from -180&deg; to +180&deg; with B 0&deg; at the bottom an" +
	    "d B180&deg;/B-180&deg; at the top, &#946;-Angles are valid from -90&deg; to +90&" +
	    "deg;.")]
		TYPE_B = 2,
	
		[Description("Type C is the recommended standard system. The C-Plane system equals a globe with" +
	    " a vertical axis. C-Angles are valid from 0&deg; to 360&deg;, &#947;-Angles are " +
	    "valid from 0&deg; (south pole) to 180&deg; (north pole).")]
		TYPE_C = 3,
	
		NOTDEFINED = 0,
	
	}
}

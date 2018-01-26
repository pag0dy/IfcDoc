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


namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("f56cf58e-094b-41bd-983e-3a67294a8c4e")]
	public enum IfcReflectanceMethodEnum
	{
		[Description("A reflectance model providing a smooth, slightly shiny appearance.")]
		BLINN = 1,
	
		[Description("A reflectance model providing a constant colour. This model ignores the effect of" +
	    " all light sources.")]
		FLAT = 2,
	
		[Description("A reflectance model that supports an approximation of glass-like materials that h" +
	    "ave both reflective and transmissive properties.")]
		GLASS = 3,
	
		[Description("A reflectance model providing a dull matte appearance.")]
		MATT = 4,
	
		[Description("A reflectance model providing a specular metallic appearance.")]
		METAL = 5,
	
		[Description("A reflectance model that supports secondary mirrored views through ray tracing.")]
		MIRROR = 6,
	
		[Description("A reflectance model conforming with the Phong model in which reflections are grea" +
	    "test in the `mirror\' direction of a surface opposite the viewing direction with " +
	    "respect to the surface normal.")]
		PHONG = 7,
	
		[Description("A reflectance model providing a specular effect which is similar to the Phong mod" +
	    "el.")]
		PLASTIC = 8,
	
		[Description("A reflectance model for metallic and non-metallic appearance based on a limited s" +
	    "et of control parameter.")]
		STRAUSS = 9,
	
		NOTDEFINED = 0,
	
	}
}

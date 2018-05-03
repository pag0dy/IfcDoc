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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcSurfaceStyleRendering : IfcSurfaceStyleShading
	{
		[DataMember(Order = 0)] 
		[Description("The diffuse part of the reflectance equation can be given as either a colour or a scalar factor.  The diffuse colour field reflects all light sources depending on the angle of the surface with respect to the light source. The more directly the surface faces the light, the more diffuse light reflects.  The diffuse factor field specifies how much diffuse light from light sources this surface shall reflect. Diffuse light depends on the angle of the surface with respect to the light source. The more directly the surface faces the light, the more diffuse light reflects. The diffuse colour is then defined by surface colour * diffuse factor.  ")]
		public IfcColourOrFactor DiffuseColour { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The transmissive part of the reflectance equation can be given as either a colour or a scalar factor. It only applies to materials which Transparency field is greater than zero.  The transmissive colour field specifies the colour that passes through a transparant material (like the colour that shines through a glass).  The transmissive factor defines the transmissive part, the transmissive colour is then defined by surface colour * transmissive factor.  ")]
		public IfcColourOrFactor TransmissionColour { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The diffuse transmission part of the reflectance equation can be given as either a colour or a scalar factor. It only applies to materials whose Transparency field is greater than zero.  The diffuse transmission colour specifies how much diffuse light is reflected at the opposite side of the material surface.  The diffuse transmission factor field specifies how much diffuse light from light sources this surface shall reflect on the opposite side of the material surface. The diffuse transmissive colour is then defined by surface colour * diffuse transmissive factor.  ")]
		public IfcColourOrFactor DiffuseTransmissionColour { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The reflection (or mirror) part of the reflectance equation can be given as either a colour or a scalar factor. Applies to \"glass\" and \"mirror\" reflection models.  The reflection colour specifies the contribution made by light from the mirror direction, i.e. light being reflected from the surface.  The reflection factor specifies the amount of contribution made by light from the mirror direction. The reflection colour is then defined by surface colour * reflection factor.  ")]
		public IfcColourOrFactor ReflectionColour { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The specular part of the reflectance equation can be given as either a colour or a scalar factor.  The specular colour determine the specular highlights (e.g., the shiny spots on an apple). When the angle from the light to the surface is close to the angle from the surface to the viewer, the specular colour is added to the diffuse and ambient colour calculations.  The specular factor defines the specular part, the specular colour is then defined by surface colour * specular factor.    ")]
		public IfcColourOrFactor SpecularColour { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("The exponent or roughness part of the specular reflectance.  ")]
		public IfcSpecularHighlightSelect SpecularHighlight { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Identifies the predefined types of reflectance method from which the method required may be set.  ")]
		[Required()]
		public IfcReflectanceMethodEnum ReflectanceMethod { get; set; }
	
	
		public IfcSurfaceStyleRendering(IfcColourRgb __SurfaceColour, IfcNormalisedRatioMeasure? __Transparency, IfcColourOrFactor __DiffuseColour, IfcColourOrFactor __TransmissionColour, IfcColourOrFactor __DiffuseTransmissionColour, IfcColourOrFactor __ReflectionColour, IfcColourOrFactor __SpecularColour, IfcSpecularHighlightSelect __SpecularHighlight, IfcReflectanceMethodEnum __ReflectanceMethod)
			: base(__SurfaceColour, __Transparency)
		{
			this.DiffuseColour = __DiffuseColour;
			this.TransmissionColour = __TransmissionColour;
			this.DiffuseTransmissionColour = __DiffuseTransmissionColour;
			this.ReflectionColour = __ReflectionColour;
			this.SpecularColour = __SpecularColour;
			this.SpecularHighlight = __SpecularHighlight;
			this.ReflectanceMethod = __ReflectanceMethod;
		}
	
	
	}
	
}

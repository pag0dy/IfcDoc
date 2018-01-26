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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("05b583b4-2801-4362-b5c7-5fbc396b6836")]
	public partial class IfcSurfaceStyleRendering : IfcSurfaceStyleShading
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _Transparency;
	
		[DataMember(Order=1)] 
		IfcColourOrFactor _DiffuseColour;
	
		[DataMember(Order=2)] 
		IfcColourOrFactor _TransmissionColour;
	
		[DataMember(Order=3)] 
		IfcColourOrFactor _DiffuseTransmissionColour;
	
		[DataMember(Order=4)] 
		IfcColourOrFactor _ReflectionColour;
	
		[DataMember(Order=5)] 
		IfcColourOrFactor _SpecularColour;
	
		[DataMember(Order=6)] 
		IfcSpecularHighlightSelect _SpecularHighlight;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		[Required()]
		IfcReflectanceMethodEnum _ReflectanceMethod;
	
	
		public IfcSurfaceStyleRendering()
		{
		}
	
		public IfcSurfaceStyleRendering(IfcColourRgb __SurfaceColour, IfcNormalisedRatioMeasure? __Transparency, IfcColourOrFactor __DiffuseColour, IfcColourOrFactor __TransmissionColour, IfcColourOrFactor __DiffuseTransmissionColour, IfcColourOrFactor __ReflectionColour, IfcColourOrFactor __SpecularColour, IfcSpecularHighlightSelect __SpecularHighlight, IfcReflectanceMethodEnum __ReflectanceMethod)
			: base(__SurfaceColour)
		{
			this._Transparency = __Transparency;
			this._DiffuseColour = __DiffuseColour;
			this._TransmissionColour = __TransmissionColour;
			this._DiffuseTransmissionColour = __DiffuseTransmissionColour;
			this._ReflectionColour = __ReflectionColour;
			this._SpecularColour = __SpecularColour;
			this._SpecularHighlight = __SpecularHighlight;
			this._ReflectanceMethod = __ReflectanceMethod;
		}
	
		[Description(@"Definition from ISO/CD 10303-46: The degree of transparency is indicated by the percentage of light traversing the surface.
	Definition from VRML97 - ISO/IEC 14772-1:1997: The transparency field specifies how ""clear"" an object is, with 1.0 being completely transparent, and 0.0 completely opaque. If not given, the value 0.0 (opaque) is assumed.
	")]
		public IfcNormalisedRatioMeasure? Transparency { get { return this._Transparency; } set { this._Transparency = value;} }
	
		[Description(@"The diffuse part of the reflectance equation can be given as either a colour or a scalar factor.
	The diffuse colour field reflects all light sources depending on the angle of the surface with respect to the light source. The more directly the surface faces the light, the more diffuse light reflects.
	The diffuse factor field specifies how much diffuse light from light sources this surface shall reflect. Diffuse light depends on the angle of the surface with respect to the light source. The more directly the surface faces the light, the more diffuse light reflects. The diffuse colour is then defined by surface colour * diffuse factor.
	")]
		public IfcColourOrFactor DiffuseColour { get { return this._DiffuseColour; } set { this._DiffuseColour = value;} }
	
		[Description(@"The transmissive part of the reflectance equation can be given as either a colour or a scalar factor. It only applies to materials which Transparency field is greater than zero.
	The transmissive colour field specifies the colour that passes through a transparant material (like the colour that shines through a glass).
	The transmissive factor defines the transmissive part, the transmissive colour is then defined by surface colour * transmissive factor.
	")]
		public IfcColourOrFactor TransmissionColour { get { return this._TransmissionColour; } set { this._TransmissionColour = value;} }
	
		[Description(@"The diffuse transmission part of the reflectance equation can be given as either a colour or a scalar factor. It only applies to materials whose Transparency field is greater than zero.
	The diffuse transmission colour specifies how much diffuse light is reflected at the opposite side of the material surface.
	The diffuse transmission factor field specifies how much diffuse light from light sources this surface shall reflect on the opposite side of the material surface. The diffuse transmissive colour is then defined by surface colour * diffuse transmissive factor.
	")]
		public IfcColourOrFactor DiffuseTransmissionColour { get { return this._DiffuseTransmissionColour; } set { this._DiffuseTransmissionColour = value;} }
	
		[Description(@"The reflection (or mirror) part of the reflectance equation can be given as either a colour or a scalar factor. Applies to ""glass"" and ""mirror"" reflection models.
	The reflection colour specifies the contribution made by light from the mirror direction, i.e. light being reflected from the surface.
	The reflection factor specifies the amount of contribution made by light from the mirror direction. The reflection colour is then defined by surface colour * reflection factor.
	")]
		public IfcColourOrFactor ReflectionColour { get { return this._ReflectionColour; } set { this._ReflectionColour = value;} }
	
		[Description(@"The specular part of the reflectance equation can be given as either a colour or a scalar factor.
	The specular colour determine the specular highlights (e.g., the shiny spots on an apple). When the angle from the light to the surface is close to the angle from the surface to the viewer, the specular colour is added to the diffuse and ambient colour calculations.
	The specular factor defines the specular part, the specular colour is then defined by surface colour * specular factor.
	
	")]
		public IfcColourOrFactor SpecularColour { get { return this._SpecularColour; } set { this._SpecularColour = value;} }
	
		[Description("The exponent or roughness part of the specular reflectance.\r\n")]
		public IfcSpecularHighlightSelect SpecularHighlight { get { return this._SpecularHighlight; } set { this._SpecularHighlight = value;} }
	
		[Description("Identifies the predefined types of reflectance method from which the method requi" +
	    "red may be set.\r\n")]
		public IfcReflectanceMethodEnum ReflectanceMethod { get { return this._ReflectanceMethod; } set { this._ReflectanceMethod = value;} }
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcSurfaceStyleLighting :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  The degree of diffusion of the transmitted light. In the case of completely transparent materials there is no diffusion. The greater the diffusing power, the smaller the direct component of the transmitted light, up to the point where only diffuse light is produced.A value of 1 means totally diffuse for that colour part of the light.  <blockquote><small>The factor can be measured physically and has three ratios for the red, green and blue part of the light.  </small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcColourRgb DiffuseTransmissionColour { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("<EPM-HTML>  The degree of diffusion of the reflected light. In the case of specular surfaces there is no diffusion. The greater the diffusing power of the reflecting surface, the smaller the specular component of the reflected light, up to the point where only diffuse light is produced. A value of 1 means totally diffuse for that colour part of the light.   <blockquote><small>The factor can be measured physically and has three ratios for the red, green and blue part of the light.  </small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcColourRgb DiffuseReflectionColour { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("<EPM-HTML>  Describes how the light falling on a body is totally or partially transmitted.   <blockquote><small>The factor can be measured physically and has three ratios for the red, green and blue part of the light.  </small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcColourRgb TransmissionColour { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("<EPM-HTML>  A coefficient that determines the extent that the light falling onto a surface is fully or partially reflected.   <blockquote><small>The factor can be measured physically and has three ratios for the red, green and blue part of the light.  </small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcColourRgb ReflectanceColour { get; set; }
	
	
		public IfcSurfaceStyleLighting(IfcColourRgb __DiffuseTransmissionColour, IfcColourRgb __DiffuseReflectionColour, IfcColourRgb __TransmissionColour, IfcColourRgb __ReflectanceColour)
		{
			this.DiffuseTransmissionColour = __DiffuseTransmissionColour;
			this.DiffuseReflectionColour = __DiffuseReflectionColour;
			this.TransmissionColour = __TransmissionColour;
			this.ReflectanceColour = __ReflectanceColour;
		}
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("5c51bae3-8ace-443a-9e9b-d416bb389d95")]
	public partial class IfcSurfaceStyleLighting : IfcPresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcColourRgb")]
		[Required()]
		IfcColourRgb _DiffuseTransmissionColour;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcColourRgb")]
		[Required()]
		IfcColourRgb _DiffuseReflectionColour;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcColourRgb")]
		[Required()]
		IfcColourRgb _TransmissionColour;
	
		[DataMember(Order=3)] 
		[XmlElement("IfcColourRgb")]
		[Required()]
		IfcColourRgb _ReflectanceColour;
	
	
		[Description(@"<EPM-HTML>
	The degree of diffusion of the transmitted light. In the case of completely transparent materials there is no diffusion. The greater the diffusing power, the smaller the direct component of the transmitted light, up to the point where only diffuse light is produced. A value of 1 means totally diffuse for that colour part of the light.
	<blockquote class=""note"">NOTE&nbsp; The factor can be measured physically and has three ratios for the red, green and blue part of the light.</blockquote>
	</EPM-HTML>")]
		public IfcColourRgb DiffuseTransmissionColour { get { return this._DiffuseTransmissionColour; } set { this._DiffuseTransmissionColour = value;} }
	
		[Description(@"<EPM-HTML>
	The degree of diffusion of the reflected light. In the case of specular surfaces there is no diffusion. The greater the diffusing power of the reflecting surface, the smaller the specular component of the reflected light, up to the point where only diffuse light is produced. A value of 1 means totally diffuse for that colour part of the light. 
	<blockquote class=""note"">NOTE&nbsp; The factor can be measured physically and has three ratios for the red, green and blue part of the light.</blockquote>
	</EPM-HTML>")]
		public IfcColourRgb DiffuseReflectionColour { get { return this._DiffuseReflectionColour; } set { this._DiffuseReflectionColour = value;} }
	
		[Description("<EPM-HTML>\r\nDescribes how the light falling on a body is totally or partially tra" +
	    "nsmitted. \r\n<blockquote class=\"note\">The factor can be measured physically and h" +
	    "as three ratios for the red, green and blue part of the light.</blockquote>\r\n</E" +
	    "PM-HTML>")]
		public IfcColourRgb TransmissionColour { get { return this._TransmissionColour; } set { this._TransmissionColour = value;} }
	
		[Description(@"<EPM-HTML>
	A coefficient that determines the extent that the light falling onto a surface is fully or partially reflected. 
	<blockquote class=""note"">NOTE&nbsp; The factor can be measured physically and has three ratios for the red, green and blue part of the light.</blockquote>
	</EPM-HTML>")]
		public IfcColourRgb ReflectanceColour { get { return this._ReflectanceColour; } set { this._ReflectanceColour = value;} }
	
	
	}
	
}

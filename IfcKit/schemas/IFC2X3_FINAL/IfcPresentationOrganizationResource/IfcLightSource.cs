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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	[Guid("3b705245-20db-4ec6-9d25-c59a79898392")]
	public abstract partial class IfcLightSource : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcColourRgb _LightColour;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _AmbientIntensity;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _Intensity;
	
	
		public IfcLightSource()
		{
		}
	
		public IfcLightSource(IfcLabel? __Name, IfcColourRgb __LightColour, IfcNormalisedRatioMeasure? __AmbientIntensity, IfcNormalisedRatioMeasure? __Intensity)
		{
			this._Name = __Name;
			this._LightColour = __LightColour;
			this._AmbientIntensity = __AmbientIntensity;
			this._Intensity = __Intensity;
		}
	
		[Description("The name given to the light source in presentation.\r\n")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description(@"Definition from ISO/CD 10303-46:1992: Based on the current lighting model, the colour of the light to be used for shading.
	Definition from VRML97 - ISO/IEC 14772-1:1997: The color field specifies the spectral color properties of both the direct and ambient light emission as an RGB value.
	")]
		public IfcColourRgb LightColour { get { return this._LightColour; } set { this._LightColour = value;} }
	
		[Description("Definition from VRML97 - ISO/IEC 14772-1:1997: The ambientIntensity specifies the" +
	    " intensity of the ambient emission from the light. Light intensity may range fro" +
	    "m 0.0 (no light emission) to 1.0 (full intensity). \r\n")]
		public IfcNormalisedRatioMeasure? AmbientIntensity { get { return this._AmbientIntensity; } set { this._AmbientIntensity = value;} }
	
		[Description("Definition from VRML97 - ISO/IEC 14772-1:1997: The intensity field specifies the " +
	    "brightness of the direct emission from the ligth. Light intensity may range from" +
	    " 0.0 (no light emission) to 1.0 (full intensity).\r\n")]
		public IfcNormalisedRatioMeasure? Intensity { get { return this._Intensity; } set { this._Intensity = value;} }
	
	
	}
	
}

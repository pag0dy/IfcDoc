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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	public partial class IfcLightSourceDirectional : IfcLightSource
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Definition from ISO/CD 10303-46:1992: This direction is the direction of the light source.  Definition from VRML97 - ISO/IEC 14772-1:1997: The direction field specifies the direction vector of the illumination emanating from the light source in the local coordinate system. Light is emitted along parallel rays from an infinite distance away.   ")]
		[Required()]
		public IfcDirection Orientation { get; set; }
	
	
		public IfcLightSourceDirectional(IfcLabel? __Name, IfcColourRgb __LightColour, IfcNormalisedRatioMeasure? __AmbientIntensity, IfcNormalisedRatioMeasure? __Intensity, IfcDirection __Orientation)
			: base(__Name, __LightColour, __AmbientIntensity, __Intensity)
		{
			this.Orientation = __Orientation;
		}
	
	
	}
	
}

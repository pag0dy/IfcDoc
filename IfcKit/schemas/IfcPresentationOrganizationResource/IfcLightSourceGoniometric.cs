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
	public partial class IfcLightSourceGoniometric : IfcLightSource
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The position of the light source. It is used to orientate the light distribution curves.  ")]
		[Required()]
		public IfcAxis2Placement3D Position { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Artificial light sources are classified in terms of their color appearance. To the human eye they all appear to be white; the difference can only be detected by direct comparison. Visual performance is not directly affected by differences in color appearance.  ")]
		public IfcColourRgb ColourAppearance { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The color temperature of any source of radiation is defined as the temperature (in Kelvin) of a black-body or Planckian radiator whose radiation has the same chromaticity as the source of radiation. Often the values are only approximate color temperatures as the black-body radiator cannot emit radiation of every chromaticity value. The color temperatures of the commonest artificial light sources range from less than 3000K (warm white) to 4000K (intermediate) and over 5000K (daylight).  ")]
		[Required()]
		public IfcThermodynamicTemperatureMeasure ColourTemperature { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Luminous flux is a photometric measure of radiant flux, i.e. the volume of light emitted from a light source. Luminous flux is measured either for the interior as a whole or for a part of the interior (partial luminous flux for a solid angle). All other photometric parameters are derivatives of luminous flux. Luminous flux is measured in lumens (lm). The luminous flux is given as a nominal value for each lamp.  ")]
		[Required()]
		public IfcLuminousFluxMeasure LuminousFlux { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Identifies the types of light emitter from which the type required may be set.  ")]
		[Required()]
		public IfcLightEmissionSourceEnum LightEmissionSource { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("The data source from which light distribution data is obtained.  ")]
		[Required()]
		public IfcLightDistributionDataSourceSelect LightDistributionDataSource { get; set; }
	
	
		public IfcLightSourceGoniometric(IfcLabel? __Name, IfcColourRgb __LightColour, IfcNormalisedRatioMeasure? __AmbientIntensity, IfcNormalisedRatioMeasure? __Intensity, IfcAxis2Placement3D __Position, IfcColourRgb __ColourAppearance, IfcThermodynamicTemperatureMeasure __ColourTemperature, IfcLuminousFluxMeasure __LuminousFlux, IfcLightEmissionSourceEnum __LightEmissionSource, IfcLightDistributionDataSourceSelect __LightDistributionDataSource)
			: base(__Name, __LightColour, __AmbientIntensity, __Intensity)
		{
			this.Position = __Position;
			this.ColourAppearance = __ColourAppearance;
			this.ColourTemperature = __ColourTemperature;
			this.LuminousFlux = __LuminousFlux;
			this.LightEmissionSource = __LightEmissionSource;
			this.LightDistributionDataSource = __LightDistributionDataSource;
		}
	
	
	}
	
}

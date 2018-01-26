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

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	[Guid("50d32070-67dc-40a9-8ba3-9cf188f08490")]
	public partial class IfcLightSourceGoniometric : IfcLightSource
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcAxis2Placement3D _Position;
	
		[DataMember(Order=1)] 
		[XmlElement]
		IfcColourRgb _ColourAppearance;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcThermodynamicTemperatureMeasure _ColourTemperature;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcLuminousFluxMeasure _LuminousFlux;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcLightEmissionSourceEnum _LightEmissionSource;
	
		[DataMember(Order=5)] 
		[Required()]
		IfcLightDistributionDataSourceSelect _LightDistributionDataSource;
	
	
		public IfcLightSourceGoniometric()
		{
		}
	
		public IfcLightSourceGoniometric(IfcLabel? __Name, IfcColourRgb __LightColour, IfcNormalisedRatioMeasure? __AmbientIntensity, IfcNormalisedRatioMeasure? __Intensity, IfcAxis2Placement3D __Position, IfcColourRgb __ColourAppearance, IfcThermodynamicTemperatureMeasure __ColourTemperature, IfcLuminousFluxMeasure __LuminousFlux, IfcLightEmissionSourceEnum __LightEmissionSource, IfcLightDistributionDataSourceSelect __LightDistributionDataSource)
			: base(__Name, __LightColour, __AmbientIntensity, __Intensity)
		{
			this._Position = __Position;
			this._ColourAppearance = __ColourAppearance;
			this._ColourTemperature = __ColourTemperature;
			this._LuminousFlux = __LuminousFlux;
			this._LightEmissionSource = __LightEmissionSource;
			this._LightDistributionDataSource = __LightDistributionDataSource;
		}
	
		[Description("The position of the light source. It is used to orientate the light distribution " +
	    "curves.\r\n")]
		public IfcAxis2Placement3D Position { get { return this._Position; } set { this._Position = value;} }
	
		[Description(@"Artificial light sources are classified in terms of their color appearance. To the human eye they all appear to be white; the difference can only be detected by direct comparison. Visual performance is not directly affected by differences in color appearance.
	")]
		public IfcColourRgb ColourAppearance { get { return this._ColourAppearance; } set { this._ColourAppearance = value;} }
	
		[Description(@"The color temperature of any source of radiation is defined as the temperature (in Kelvin) of a black-body or Planckian radiator whose radiation has the same chromaticity as the source of radiation. Often the values are only approximate color temperatures as the black-body radiator cannot emit radiation of every chromaticity value. The color temperatures of the commonest artificial light sources range from less than 3000K (warm white) to 4000K (intermediate) and over 5000K (daylight).
	")]
		public IfcThermodynamicTemperatureMeasure ColourTemperature { get { return this._ColourTemperature; } set { this._ColourTemperature = value;} }
	
		[Description(@"Luminous flux is a photometric measure of radiant flux, i.e. the volume of light emitted from a light source. Luminous flux is measured either for the interior as a whole or for a part of the interior (partial luminous flux for a solid angle). All other photometric parameters are derivatives of luminous flux. Luminous flux is measured in lumens (lm). The luminous flux is given as a nominal value for each lamp.
	")]
		public IfcLuminousFluxMeasure LuminousFlux { get { return this._LuminousFlux; } set { this._LuminousFlux = value;} }
	
		[Description("Identifies the types of light emitter from which the type required may be set.\r\n")]
		public IfcLightEmissionSourceEnum LightEmissionSource { get { return this._LightEmissionSource; } set { this._LightEmissionSource = value;} }
	
		[Description("The data source from which light distribution data is obtained.\r\n")]
		public IfcLightDistributionDataSourceSelect LightDistributionDataSource { get { return this._LightDistributionDataSource; } set { this._LightDistributionDataSource = value;} }
	
	
	}
	
}

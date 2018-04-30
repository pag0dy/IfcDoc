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

using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	public partial class IfcOpticalMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Transmittance at normal incidence (visible). Defines the fraction of the visible spectrum of solar radiation that passes through per unit area, perpendicular to the surface.")]
		public IfcPositiveRatioMeasure? VisibleTransmittance { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Transmittance at normal incidence (solar). Defines the fraction of solar radiation that passes through per unit area, perpendicular to the surface.")]
		public IfcPositiveRatioMeasure? SolarTransmittance { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Thermal IR transmittance at normal incidence. Defines the fraction of thermal energy that passes through per unit area, perpendicular to the surface.")]
		public IfcPositiveRatioMeasure? ThermalIrTransmittance { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Thermal IR emissivity: back side. Defines the fraction of thermal energy emitted per unit area to \"blackbody\" at the same temperature, through the \"back\" side of the material.")]
		public IfcPositiveRatioMeasure? ThermalIrEmissivityBack { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Thermal IR emissivity: front side. Defines the fraction of thermal energy emitted per unit area to \"blackbody\" at the same temperature, through the \"front\" side of the material.")]
		public IfcPositiveRatioMeasure? ThermalIrEmissivityFront { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Reflectance at normal incidence (visible): back side. Defines the fraction of the solar ray in the visible spectrum that is reflected and not transmitted when the ray passes from one medium  into another, at the \"back\" side of the other material, perpendicular to the surface. Dependent on material and surface characteristics.")]
		public IfcPositiveRatioMeasure? VisibleReflectanceBack { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Reflectance at normal incidence (visible): front side. Defines the fraction of the solar ray in the visible spectrum that is reflected and not transmitted when the ray passes from one medium  into another, at the \"front\" side of the other material, perpendicular to the surface. Dependent on material and surface characteristics.")]
		public IfcPositiveRatioMeasure? VisibleReflectanceFront { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Reflectance at normal incidence (solar): front side. Defines the fraction of the solar ray that is reflected and not transmitted when the ray passes from one medium into another, at the \"front\" side of the other material, perpendicular to the surface. Dependent on material and surface characteristics.")]
		public IfcPositiveRatioMeasure? SolarReflectanceFront { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("Reflectance at normal incidence (solar): back side. Defines the fraction of the solar ray that is reflected and not transmitted when the ray passes from one medium into another, at the \"back\" side of the other material, perpendicular to the surface. Dependent on material and surface characteristics.")]
		public IfcPositiveRatioMeasure? SolarReflectanceBack { get; set; }
	
	
		public IfcOpticalMaterialProperties(IfcMaterial __Material, IfcPositiveRatioMeasure? __VisibleTransmittance, IfcPositiveRatioMeasure? __SolarTransmittance, IfcPositiveRatioMeasure? __ThermalIrTransmittance, IfcPositiveRatioMeasure? __ThermalIrEmissivityBack, IfcPositiveRatioMeasure? __ThermalIrEmissivityFront, IfcPositiveRatioMeasure? __VisibleReflectanceBack, IfcPositiveRatioMeasure? __VisibleReflectanceFront, IfcPositiveRatioMeasure? __SolarReflectanceFront, IfcPositiveRatioMeasure? __SolarReflectanceBack)
			: base(__Material)
		{
			this.VisibleTransmittance = __VisibleTransmittance;
			this.SolarTransmittance = __SolarTransmittance;
			this.ThermalIrTransmittance = __ThermalIrTransmittance;
			this.ThermalIrEmissivityBack = __ThermalIrEmissivityBack;
			this.ThermalIrEmissivityFront = __ThermalIrEmissivityFront;
			this.VisibleReflectanceBack = __VisibleReflectanceBack;
			this.VisibleReflectanceFront = __VisibleReflectanceFront;
			this.SolarReflectanceFront = __SolarReflectanceFront;
			this.SolarReflectanceBack = __SolarReflectanceBack;
		}
	
	
	}
	
}

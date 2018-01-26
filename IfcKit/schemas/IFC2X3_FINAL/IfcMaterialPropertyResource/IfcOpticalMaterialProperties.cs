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

using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	[Guid("a7093b91-9e9f-4ce4-a416-a1bc65e89cdd")]
	public partial class IfcOpticalMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _VisibleTransmittance;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _SolarTransmittance;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _ThermalIrTransmittance;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _ThermalIrEmissivityBack;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _ThermalIrEmissivityFront;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _VisibleReflectanceBack;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _VisibleReflectanceFront;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _SolarReflectanceFront;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _SolarReflectanceBack;
	
	
		public IfcOpticalMaterialProperties()
		{
		}
	
		public IfcOpticalMaterialProperties(IfcMaterial __Material, IfcPositiveRatioMeasure? __VisibleTransmittance, IfcPositiveRatioMeasure? __SolarTransmittance, IfcPositiveRatioMeasure? __ThermalIrTransmittance, IfcPositiveRatioMeasure? __ThermalIrEmissivityBack, IfcPositiveRatioMeasure? __ThermalIrEmissivityFront, IfcPositiveRatioMeasure? __VisibleReflectanceBack, IfcPositiveRatioMeasure? __VisibleReflectanceFront, IfcPositiveRatioMeasure? __SolarReflectanceFront, IfcPositiveRatioMeasure? __SolarReflectanceBack)
			: base(__Material)
		{
			this._VisibleTransmittance = __VisibleTransmittance;
			this._SolarTransmittance = __SolarTransmittance;
			this._ThermalIrTransmittance = __ThermalIrTransmittance;
			this._ThermalIrEmissivityBack = __ThermalIrEmissivityBack;
			this._ThermalIrEmissivityFront = __ThermalIrEmissivityFront;
			this._VisibleReflectanceBack = __VisibleReflectanceBack;
			this._VisibleReflectanceFront = __VisibleReflectanceFront;
			this._SolarReflectanceFront = __SolarReflectanceFront;
			this._SolarReflectanceBack = __SolarReflectanceBack;
		}
	
		[Description("Transmittance at normal incidence (visible). Defines the fraction of the visible " +
	    "spectrum of solar radiation that passes through per unit area, perpendicular to " +
	    "the surface.")]
		public IfcPositiveRatioMeasure? VisibleTransmittance { get { return this._VisibleTransmittance; } set { this._VisibleTransmittance = value;} }
	
		[Description("Transmittance at normal incidence (solar). Defines the fraction of solar radiatio" +
	    "n that passes through per unit area, perpendicular to the surface.")]
		public IfcPositiveRatioMeasure? SolarTransmittance { get { return this._SolarTransmittance; } set { this._SolarTransmittance = value;} }
	
		[Description("Thermal IR transmittance at normal incidence. Defines the fraction of thermal ene" +
	    "rgy that passes through per unit area, perpendicular to the surface.")]
		public IfcPositiveRatioMeasure? ThermalIrTransmittance { get { return this._ThermalIrTransmittance; } set { this._ThermalIrTransmittance = value;} }
	
		[Description("Thermal IR emissivity: back side. Defines the fraction of thermal energy emitted " +
	    "per unit area to \"blackbody\" at the same temperature, through the \"back\" side of" +
	    " the material.")]
		public IfcPositiveRatioMeasure? ThermalIrEmissivityBack { get { return this._ThermalIrEmissivityBack; } set { this._ThermalIrEmissivityBack = value;} }
	
		[Description("Thermal IR emissivity: front side. Defines the fraction of thermal energy emitted" +
	    " per unit area to \"blackbody\" at the same temperature, through the \"front\" side " +
	    "of the material.")]
		public IfcPositiveRatioMeasure? ThermalIrEmissivityFront { get { return this._ThermalIrEmissivityFront; } set { this._ThermalIrEmissivityFront = value;} }
	
		[Description(@"Reflectance at normal incidence (visible): back side. Defines the fraction of the solar ray in the visible spectrum that is reflected and not transmitted when the ray passes from one medium
	into another, at the ""back"" side of the other material, perpendicular to the surface. Dependent on material and surface characteristics.")]
		public IfcPositiveRatioMeasure? VisibleReflectanceBack { get { return this._VisibleReflectanceBack; } set { this._VisibleReflectanceBack = value;} }
	
		[Description(@"Reflectance at normal incidence (visible): front side. Defines the fraction of the solar ray in the visible spectrum that is reflected and not transmitted when the ray passes from one medium
	into another, at the ""front"" side of the other material, perpendicular to the surface. Dependent on material and surface characteristics.")]
		public IfcPositiveRatioMeasure? VisibleReflectanceFront { get { return this._VisibleReflectanceFront; } set { this._VisibleReflectanceFront = value;} }
	
		[Description(@"Reflectance at normal incidence (solar): front side. Defines the fraction of the solar ray that is reflected and not transmitted when the ray passes from one medium into another, at the ""front"" side of the other material, perpendicular to the surface. Dependent on material and surface characteristics.")]
		public IfcPositiveRatioMeasure? SolarReflectanceFront { get { return this._SolarReflectanceFront; } set { this._SolarReflectanceFront = value;} }
	
		[Description(@"Reflectance at normal incidence (solar): back side. Defines the fraction of the solar ray that is reflected and not transmitted when the ray passes from one medium into another, at the ""back"" side of the other material, perpendicular to the surface. Dependent on material and surface characteristics.")]
		public IfcPositiveRatioMeasure? SolarReflectanceBack { get { return this._SolarReflectanceBack; } set { this._SolarReflectanceBack = value;} }
	
	
	}
	
}

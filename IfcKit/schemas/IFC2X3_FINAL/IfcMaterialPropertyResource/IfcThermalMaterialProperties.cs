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
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	[Guid("82ee30bf-1000-431a-ab5c-326d65e8e250")]
	public partial class IfcThermalMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcSpecificHeatCapacityMeasure? _SpecificHeatCapacity;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _BoilingPoint;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _FreezingPoint;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcThermalConductivityMeasure? _ThermalConductivity;
	
	
		[Description("Defines the specific heat of the material: heat energy absorbed per\r\ntemperature " +
	    "unit. Usually measured in [J/kg K].")]
		public IfcSpecificHeatCapacityMeasure? SpecificHeatCapacity { get { return this._SpecificHeatCapacity; } set { this._SpecificHeatCapacity = value;} }
	
		[Description("The boiling point of the material (fluid). Usually measured in Kelvin.")]
		public IfcThermodynamicTemperatureMeasure? BoilingPoint { get { return this._BoilingPoint; } set { this._BoilingPoint = value;} }
	
		[Description("The freezing point of the material (fluid). Usually measured in Kelvin.")]
		public IfcThermodynamicTemperatureMeasure? FreezingPoint { get { return this._FreezingPoint; } set { this._FreezingPoint = value;} }
	
		[Description("The rate at which thermal energy is transmitted through the material.Usually in [" +
	    "W/m K].")]
		public IfcThermalConductivityMeasure? ThermalConductivity { get { return this._ThermalConductivity; } set { this._ThermalConductivity = value;} }
	
	
	}
	
}

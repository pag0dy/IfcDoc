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
	public partial class IfcProductsOfCombustionProperties : IfcMaterialProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Specific heat of the products of combustion: heat energy absorbed per  temperature unit. Usually measured in [J/kg K].")]
		public IfcSpecificHeatCapacityMeasure? SpecificHeatCapacity { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  Nitrous Oxide (N<sub>2</sub>O) content of the products of combustion. This is measured in weight of N<sub>2</sub>O per unit weight and is therefore unitless.  </EPM-HTML>")]
		public IfcPositiveRatioMeasure? N20Content { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Carbon monoxide (CO) content of the products of combustion.This is measured in weight of CO per unit weight and is therefore unitless. ")]
		public IfcPositiveRatioMeasure? COContent { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  Carbon Dioxide (CO<sub>2</sub>) content of the products of combustion. This is measured in weight of CO<sub>2</sub> per unit weight and is therefore unitless.  </EPM-HTML>")]
		public IfcPositiveRatioMeasure? CO2Content { get; set; }
	
	
		public IfcProductsOfCombustionProperties(IfcMaterial __Material, IfcSpecificHeatCapacityMeasure? __SpecificHeatCapacity, IfcPositiveRatioMeasure? __N20Content, IfcPositiveRatioMeasure? __COContent, IfcPositiveRatioMeasure? __CO2Content)
			: base(__Material)
		{
			this.SpecificHeatCapacity = __SpecificHeatCapacity;
			this.N20Content = __N20Content;
			this.COContent = __COContent;
			this.CO2Content = __CO2Content;
		}
	
	
	}
	
}

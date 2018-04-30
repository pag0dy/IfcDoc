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
	public partial class IfcFuelProperties : IfcMaterialProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Combustion temperature of the material when air is at 298 K and 100 kPa. ")]
		public IfcThermodynamicTemperatureMeasure? CombustionTemperature { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The carbon content in the fuel. This is measured in weight of carbon per unit weight of fuel and is therefore unitless.")]
		public IfcPositiveRatioMeasure? CarbonContent { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Lower Heating Value is defined as the amount of energy released (MJ/kg) when a fuel is burned completely, and H2O is in vapor form  in the combustion products.")]
		public IfcHeatingValueMeasure? LowerHeatingValue { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Higher Heating Value is defined as the amount of energy released (MJ/kg) when a fuel is burned completely, and H2O is in liquid form  in the combustion products.")]
		public IfcHeatingValueMeasure? HigherHeatingValue { get; set; }
	
	
		public IfcFuelProperties(IfcMaterial __Material, IfcThermodynamicTemperatureMeasure? __CombustionTemperature, IfcPositiveRatioMeasure? __CarbonContent, IfcHeatingValueMeasure? __LowerHeatingValue, IfcHeatingValueMeasure? __HigherHeatingValue)
			: base(__Material)
		{
			this.CombustionTemperature = __CombustionTemperature;
			this.CarbonContent = __CarbonContent;
			this.LowerHeatingValue = __LowerHeatingValue;
			this.HigherHeatingValue = __HigherHeatingValue;
		}
	
	
	}
	
}

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
	[Guid("d6bd9c7f-e37b-4621-8520-5ecc329266f1")]
	public partial class IfcFuelProperties : IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _CombustionTemperature;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _CarbonContent;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcHeatingValueMeasure? _LowerHeatingValue;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcHeatingValueMeasure? _HigherHeatingValue;
	
	
		public IfcFuelProperties()
		{
		}
	
		public IfcFuelProperties(IfcMaterial __Material, IfcThermodynamicTemperatureMeasure? __CombustionTemperature, IfcPositiveRatioMeasure? __CarbonContent, IfcHeatingValueMeasure? __LowerHeatingValue, IfcHeatingValueMeasure? __HigherHeatingValue)
			: base(__Material)
		{
			this._CombustionTemperature = __CombustionTemperature;
			this._CarbonContent = __CarbonContent;
			this._LowerHeatingValue = __LowerHeatingValue;
			this._HigherHeatingValue = __HigherHeatingValue;
		}
	
		[Description("Combustion temperature of the material when air is at 298 K and 100 kPa. ")]
		public IfcThermodynamicTemperatureMeasure? CombustionTemperature { get { return this._CombustionTemperature; } set { this._CombustionTemperature = value;} }
	
		[Description("The carbon content in the fuel. This is measured in weight of carbon per unit wei" +
	    "ght of fuel and is therefore unitless.")]
		public IfcPositiveRatioMeasure? CarbonContent { get { return this._CarbonContent; } set { this._CarbonContent = value;} }
	
		[Description("Lower Heating Value is defined as the amount of energy released (MJ/kg) when a fu" +
	    "el is burned completely, and H2O is in vapor form  in the combustion products.")]
		public IfcHeatingValueMeasure? LowerHeatingValue { get { return this._LowerHeatingValue; } set { this._LowerHeatingValue = value;} }
	
		[Description("Higher Heating Value is defined as the amount of energy released (MJ/kg) when a f" +
	    "uel is burned completely, and H2O is in liquid form  in the combustion products." +
	    "")]
		public IfcHeatingValueMeasure? HigherHeatingValue { get { return this._HigherHeatingValue; } set { this._HigherHeatingValue = value;} }
	
	
	}
	
}

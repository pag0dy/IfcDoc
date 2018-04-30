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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	public partial class IfcFluidFlowProperties : IfcPropertySetDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The source of the fluid flow properties (e.g., are these design values, measured values, etc.).")]
		[Required()]
		public IfcPropertySourceEnum PropertySource { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A times series defining the flow condition as a percentage of the cross-sectional area.")]
		public IfcTimeSeries FlowConditionTimeSeries { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("A time series of velocity values of the fluid.")]
		public IfcTimeSeries VelocityTimeSeries { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("A time series of flow rate values. Note that either volumetric or mass flow rate values should be specified.  ")]
		public IfcTimeSeries FlowrateTimeSeries { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The properties of the fluid.")]
		[Required()]
		public IfcMaterial Fluid { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("A time series of pressure values of the fluid.   ")]
		public IfcTimeSeries PressureTimeSeries { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("This attribute must be defined if the PropertySource is USERDEFINED. ")]
		public IfcLabel? UserDefinedPropertySource { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Temperature of the fluid. For air this value represents the dry bulb temperature.  ")]
		public IfcThermodynamicTemperatureMeasure? TemperatureSingleValue { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("Wet bulb temperature of the fluid; only applicable if the fluid is air.  ")]
		public IfcThermodynamicTemperatureMeasure? WetBulbTemperatureSingleValue { get; set; }
	
		[DataMember(Order = 9)] 
		[Description("Time series of fluid wet bulb temperature values. These values are only applicable if the fluid is air.")]
		public IfcTimeSeries WetBulbTemperatureTimeSeries { get; set; }
	
		[DataMember(Order = 10)] 
		[Description("Time series of fluid temperature values. For air, these values represent the dry bulb temperature.  ")]
		public IfcTimeSeries TemperatureTimeSeries { get; set; }
	
		[DataMember(Order = 11)] 
		[Description("The flow rate of the fluid. Either a mass or volumetric flow rate shall be defined.  ")]
		public IfcDerivedMeasureValue FlowrateSingleValue { get; set; }
	
		[DataMember(Order = 12)] 
		[XmlAttribute]
		[Description("Defines the flow condition as a percentage of the cross-sectional area.")]
		public IfcPositiveRatioMeasure? FlowConditionSingleValue { get; set; }
	
		[DataMember(Order = 13)] 
		[XmlAttribute]
		[Description("The velocity of the fluid.")]
		public IfcLinearVelocityMeasure? VelocitySingleValue { get; set; }
	
		[DataMember(Order = 14)] 
		[XmlAttribute]
		[Description("The pressure of the fluid.   ")]
		public IfcPressureMeasure? PressureSingleValue { get; set; }
	
	
		public IfcFluidFlowProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPropertySourceEnum __PropertySource, IfcTimeSeries __FlowConditionTimeSeries, IfcTimeSeries __VelocityTimeSeries, IfcTimeSeries __FlowrateTimeSeries, IfcMaterial __Fluid, IfcTimeSeries __PressureTimeSeries, IfcLabel? __UserDefinedPropertySource, IfcThermodynamicTemperatureMeasure? __TemperatureSingleValue, IfcThermodynamicTemperatureMeasure? __WetBulbTemperatureSingleValue, IfcTimeSeries __WetBulbTemperatureTimeSeries, IfcTimeSeries __TemperatureTimeSeries, IfcDerivedMeasureValue __FlowrateSingleValue, IfcPositiveRatioMeasure? __FlowConditionSingleValue, IfcLinearVelocityMeasure? __VelocitySingleValue, IfcPressureMeasure? __PressureSingleValue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.PropertySource = __PropertySource;
			this.FlowConditionTimeSeries = __FlowConditionTimeSeries;
			this.VelocityTimeSeries = __VelocityTimeSeries;
			this.FlowrateTimeSeries = __FlowrateTimeSeries;
			this.Fluid = __Fluid;
			this.PressureTimeSeries = __PressureTimeSeries;
			this.UserDefinedPropertySource = __UserDefinedPropertySource;
			this.TemperatureSingleValue = __TemperatureSingleValue;
			this.WetBulbTemperatureSingleValue = __WetBulbTemperatureSingleValue;
			this.WetBulbTemperatureTimeSeries = __WetBulbTemperatureTimeSeries;
			this.TemperatureTimeSeries = __TemperatureTimeSeries;
			this.FlowrateSingleValue = __FlowrateSingleValue;
			this.FlowConditionSingleValue = __FlowConditionSingleValue;
			this.VelocitySingleValue = __VelocitySingleValue;
			this.PressureSingleValue = __PressureSingleValue;
		}
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("c3f523ec-a7ff-497a-8847-6afccef25ebb")]
	public partial class IfcFluidFlowProperties : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPropertySourceEnum _PropertySource;
	
		[DataMember(Order=1)] 
		IfcTimeSeries _FlowConditionTimeSeries;
	
		[DataMember(Order=2)] 
		IfcTimeSeries _VelocityTimeSeries;
	
		[DataMember(Order=3)] 
		IfcTimeSeries _FlowrateTimeSeries;
	
		[DataMember(Order=4)] 
		[Required()]
		IfcMaterial _Fluid;
	
		[DataMember(Order=5)] 
		IfcTimeSeries _PressureTimeSeries;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedPropertySource;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _TemperatureSingleValue;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcThermodynamicTemperatureMeasure? _WetBulbTemperatureSingleValue;
	
		[DataMember(Order=9)] 
		IfcTimeSeries _WetBulbTemperatureTimeSeries;
	
		[DataMember(Order=10)] 
		IfcTimeSeries _TemperatureTimeSeries;
	
		[DataMember(Order=11)] 
		IfcDerivedMeasureValue _FlowrateSingleValue;
	
		[DataMember(Order=12)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _FlowConditionSingleValue;
	
		[DataMember(Order=13)] 
		[XmlAttribute]
		IfcLinearVelocityMeasure? _VelocitySingleValue;
	
		[DataMember(Order=14)] 
		[XmlAttribute]
		IfcPressureMeasure? _PressureSingleValue;
	
	
		public IfcFluidFlowProperties()
		{
		}
	
		public IfcFluidFlowProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPropertySourceEnum __PropertySource, IfcTimeSeries __FlowConditionTimeSeries, IfcTimeSeries __VelocityTimeSeries, IfcTimeSeries __FlowrateTimeSeries, IfcMaterial __Fluid, IfcTimeSeries __PressureTimeSeries, IfcLabel? __UserDefinedPropertySource, IfcThermodynamicTemperatureMeasure? __TemperatureSingleValue, IfcThermodynamicTemperatureMeasure? __WetBulbTemperatureSingleValue, IfcTimeSeries __WetBulbTemperatureTimeSeries, IfcTimeSeries __TemperatureTimeSeries, IfcDerivedMeasureValue __FlowrateSingleValue, IfcPositiveRatioMeasure? __FlowConditionSingleValue, IfcLinearVelocityMeasure? __VelocitySingleValue, IfcPressureMeasure? __PressureSingleValue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._PropertySource = __PropertySource;
			this._FlowConditionTimeSeries = __FlowConditionTimeSeries;
			this._VelocityTimeSeries = __VelocityTimeSeries;
			this._FlowrateTimeSeries = __FlowrateTimeSeries;
			this._Fluid = __Fluid;
			this._PressureTimeSeries = __PressureTimeSeries;
			this._UserDefinedPropertySource = __UserDefinedPropertySource;
			this._TemperatureSingleValue = __TemperatureSingleValue;
			this._WetBulbTemperatureSingleValue = __WetBulbTemperatureSingleValue;
			this._WetBulbTemperatureTimeSeries = __WetBulbTemperatureTimeSeries;
			this._TemperatureTimeSeries = __TemperatureTimeSeries;
			this._FlowrateSingleValue = __FlowrateSingleValue;
			this._FlowConditionSingleValue = __FlowConditionSingleValue;
			this._VelocitySingleValue = __VelocitySingleValue;
			this._PressureSingleValue = __PressureSingleValue;
		}
	
		[Description("The source of the fluid flow properties (e.g., are these design values, measured " +
	    "values, etc.).")]
		public IfcPropertySourceEnum PropertySource { get { return this._PropertySource; } set { this._PropertySource = value;} }
	
		[Description("A times series defining the flow condition as a percentage of the cross-sectional" +
	    " area.")]
		public IfcTimeSeries FlowConditionTimeSeries { get { return this._FlowConditionTimeSeries; } set { this._FlowConditionTimeSeries = value;} }
	
		[Description("A time series of velocity values of the fluid.")]
		public IfcTimeSeries VelocityTimeSeries { get { return this._VelocityTimeSeries; } set { this._VelocityTimeSeries = value;} }
	
		[Description("A time series of flow rate values. Note that either volumetric or mass flow rate " +
	    "values should be specified.\r\n")]
		public IfcTimeSeries FlowrateTimeSeries { get { return this._FlowrateTimeSeries; } set { this._FlowrateTimeSeries = value;} }
	
		[Description("The properties of the fluid.")]
		public IfcMaterial Fluid { get { return this._Fluid; } set { this._Fluid = value;} }
	
		[Description("A time series of pressure values of the fluid. \r\n")]
		public IfcTimeSeries PressureTimeSeries { get { return this._PressureTimeSeries; } set { this._PressureTimeSeries = value;} }
	
		[Description("This attribute must be defined if the PropertySource is USERDEFINED. ")]
		public IfcLabel? UserDefinedPropertySource { get { return this._UserDefinedPropertySource; } set { this._UserDefinedPropertySource = value;} }
	
		[Description("Temperature of the fluid. For air this value represents the dry bulb temperature." +
	    "\r\n")]
		public IfcThermodynamicTemperatureMeasure? TemperatureSingleValue { get { return this._TemperatureSingleValue; } set { this._TemperatureSingleValue = value;} }
	
		[Description("Wet bulb temperature of the fluid; only applicable if the fluid is air.\r\n")]
		public IfcThermodynamicTemperatureMeasure? WetBulbTemperatureSingleValue { get { return this._WetBulbTemperatureSingleValue; } set { this._WetBulbTemperatureSingleValue = value;} }
	
		[Description("Time series of fluid wet bulb temperature values. These values are only applicabl" +
	    "e if the fluid is air.")]
		public IfcTimeSeries WetBulbTemperatureTimeSeries { get { return this._WetBulbTemperatureTimeSeries; } set { this._WetBulbTemperatureTimeSeries = value;} }
	
		[Description("Time series of fluid temperature values. For air, these values represent the dry " +
	    "bulb temperature.\r\n")]
		public IfcTimeSeries TemperatureTimeSeries { get { return this._TemperatureTimeSeries; } set { this._TemperatureTimeSeries = value;} }
	
		[Description("The flow rate of the fluid. Either a mass or volumetric flow rate shall be define" +
	    "d.\r\n")]
		public IfcDerivedMeasureValue FlowrateSingleValue { get { return this._FlowrateSingleValue; } set { this._FlowrateSingleValue = value;} }
	
		[Description("Defines the flow condition as a percentage of the cross-sectional area.")]
		public IfcPositiveRatioMeasure? FlowConditionSingleValue { get { return this._FlowConditionSingleValue; } set { this._FlowConditionSingleValue = value;} }
	
		[Description("The velocity of the fluid.")]
		public IfcLinearVelocityMeasure? VelocitySingleValue { get { return this._VelocitySingleValue; } set { this._VelocitySingleValue = value;} }
	
		[Description("The pressure of the fluid. \r\n")]
		public IfcPressureMeasure? PressureSingleValue { get { return this._PressureSingleValue; } set { this._PressureSingleValue = value;} }
	
	
	}
	
}

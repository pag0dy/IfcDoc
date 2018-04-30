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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	public partial class IfcSpaceThermalLoadProperties : IfcPropertySetDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Percentage of use requirement or criteria applicable to the space, interpretation depends on the source type.  ")]
		public IfcPositiveRatioMeasure? ApplicableValueRatio { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Source of the thermal loss or gain. Depending on the source, the maximum and minimum values have to be interpreted. Refer to the space usage in Pset_SpaceProgramCommon to determine thermal loads associated with the activity levels of people.")]
		[Required()]
		public IfcThermalLoadSourceEnum ThermalLoadSource { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The source of the space thermal load properties (e.g., are these design values, measured values, etc.).")]
		[Required()]
		public IfcPropertySourceEnum PropertySource { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Further specification for the source, which might be specific for a region or project. E.g. whether the heat gain from Person is caused by specific activities.  ")]
		public IfcText? SourceDescription { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The maximum thermal load value. If this value is less than zero (negative), then the thermal load is lost from the space. If the value is greater than zero (positive), then the thermal load is a gain to the space. If the minimum value is not specified, then this value is the actual value. At least one of the maximum, minimum, or time series values must be specified.")]
		[Required()]
		public IfcPowerMeasure MaximumValue { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("The minimum thermal load value. If this value is less than zero (negative), then the thermal load is lost from the space. If the value is greater than zero (positive), then the thermal load is a gain to the space. The requirement for the inclusion of this attribute is dependent on the load source. At least one of the maximum, minimum, or time series values must be specified.")]
		public IfcPowerMeasure? MinimumValue { get; set; }
	
		[DataMember(Order = 6)] 
		[Description("A time series of the thermal load values. If a value is less than zero (negative), then the thermal load is lost from the space. If the value is greater than zero (positive), then the thermal load is a gain to the space. These values are contributed from the specified thermal load source. At least one of the maximum, minimum, or time series values must be specified.")]
		public IfcTimeSeries ThermalLoadTimeSeriesValues { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("This attribute must be defined if the ThermalLoadSource is USERDEFINED. ")]
		public IfcLabel? UserDefinedThermalLoadSource { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("This attribute must be defined if the PropertySource is USERDEFINED. ")]
		public IfcLabel? UserDefinedPropertySource { get; set; }
	
		[DataMember(Order = 9)] 
		[XmlAttribute]
		[Description("Defines the type of thermal load (e.g., sensible, latent, radiant, etc.).")]
		[Required()]
		public IfcThermalLoadTypeEnum ThermalLoadType { get; set; }
	
	
		public IfcSpaceThermalLoadProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPositiveRatioMeasure? __ApplicableValueRatio, IfcThermalLoadSourceEnum __ThermalLoadSource, IfcPropertySourceEnum __PropertySource, IfcText? __SourceDescription, IfcPowerMeasure __MaximumValue, IfcPowerMeasure? __MinimumValue, IfcTimeSeries __ThermalLoadTimeSeriesValues, IfcLabel? __UserDefinedThermalLoadSource, IfcLabel? __UserDefinedPropertySource, IfcThermalLoadTypeEnum __ThermalLoadType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.ApplicableValueRatio = __ApplicableValueRatio;
			this.ThermalLoadSource = __ThermalLoadSource;
			this.PropertySource = __PropertySource;
			this.SourceDescription = __SourceDescription;
			this.MaximumValue = __MaximumValue;
			this.MinimumValue = __MinimumValue;
			this.ThermalLoadTimeSeriesValues = __ThermalLoadTimeSeriesValues;
			this.UserDefinedThermalLoadSource = __UserDefinedThermalLoadSource;
			this.UserDefinedPropertySource = __UserDefinedPropertySource;
			this.ThermalLoadType = __ThermalLoadType;
		}
	
	
	}
	
}

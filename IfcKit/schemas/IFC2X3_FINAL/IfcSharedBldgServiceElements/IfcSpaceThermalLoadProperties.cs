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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("6c45e59e-abf5-4980-8b22-a372d154923c")]
	public partial class IfcSpaceThermalLoadProperties : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _ApplicableValueRatio;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcThermalLoadSourceEnum _ThermalLoadSource;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPropertySourceEnum _PropertySource;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcText? _SourceDescription;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcPowerMeasure _MaximumValue;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcPowerMeasure? _MinimumValue;
	
		[DataMember(Order=6)] 
		IfcTimeSeries _ThermalLoadTimeSeriesValues;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedThermalLoadSource;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedPropertySource;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		[Required()]
		IfcThermalLoadTypeEnum _ThermalLoadType;
	
	
		public IfcSpaceThermalLoadProperties()
		{
		}
	
		public IfcSpaceThermalLoadProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPositiveRatioMeasure? __ApplicableValueRatio, IfcThermalLoadSourceEnum __ThermalLoadSource, IfcPropertySourceEnum __PropertySource, IfcText? __SourceDescription, IfcPowerMeasure __MaximumValue, IfcPowerMeasure? __MinimumValue, IfcTimeSeries __ThermalLoadTimeSeriesValues, IfcLabel? __UserDefinedThermalLoadSource, IfcLabel? __UserDefinedPropertySource, IfcThermalLoadTypeEnum __ThermalLoadType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._ApplicableValueRatio = __ApplicableValueRatio;
			this._ThermalLoadSource = __ThermalLoadSource;
			this._PropertySource = __PropertySource;
			this._SourceDescription = __SourceDescription;
			this._MaximumValue = __MaximumValue;
			this._MinimumValue = __MinimumValue;
			this._ThermalLoadTimeSeriesValues = __ThermalLoadTimeSeriesValues;
			this._UserDefinedThermalLoadSource = __UserDefinedThermalLoadSource;
			this._UserDefinedPropertySource = __UserDefinedPropertySource;
			this._ThermalLoadType = __ThermalLoadType;
		}
	
		[Description("Percentage of use requirement or criteria applicable to the space, interpretation" +
	    " depends on the source type.\r\n")]
		public IfcPositiveRatioMeasure? ApplicableValueRatio { get { return this._ApplicableValueRatio; } set { this._ApplicableValueRatio = value;} }
	
		[Description("Source of the thermal loss or gain. Depending on the source, the maximum and mini" +
	    "mum values have to be interpreted. Refer to the space usage in Pset_SpaceProgram" +
	    "Common to determine thermal loads associated with the activity levels of people." +
	    "")]
		public IfcThermalLoadSourceEnum ThermalLoadSource { get { return this._ThermalLoadSource; } set { this._ThermalLoadSource = value;} }
	
		[Description("The source of the space thermal load properties (e.g., are these design values, m" +
	    "easured values, etc.).")]
		public IfcPropertySourceEnum PropertySource { get { return this._PropertySource; } set { this._PropertySource = value;} }
	
		[Description("Further specification for the source, which might be specific for a region or pro" +
	    "ject. E.g. whether the heat gain from Person is caused by specific activities.\r\n" +
	    "")]
		public IfcText? SourceDescription { get { return this._SourceDescription; } set { this._SourceDescription = value;} }
	
		[Description(@"The maximum thermal load value. If this value is less than zero (negative), then the thermal load is lost from the space. If the value is greater than zero (positive), then the thermal load is a gain to the space. If the minimum value is not specified, then this value is the actual value. At least one of the maximum, minimum, or time series values must be specified.")]
		public IfcPowerMeasure MaximumValue { get { return this._MaximumValue; } set { this._MaximumValue = value;} }
	
		[Description(@"The minimum thermal load value. If this value is less than zero (negative), then the thermal load is lost from the space. If the value is greater than zero (positive), then the thermal load is a gain to the space. The requirement for the inclusion of this attribute is dependent on the load source. At least one of the maximum, minimum, or time series values must be specified.")]
		public IfcPowerMeasure? MinimumValue { get { return this._MinimumValue; } set { this._MinimumValue = value;} }
	
		[Description(@"A time series of the thermal load values. If a value is less than zero (negative), then the thermal load is lost from the space. If the value is greater than zero (positive), then the thermal load is a gain to the space. These values are contributed from the specified thermal load source. At least one of the maximum, minimum, or time series values must be specified.")]
		public IfcTimeSeries ThermalLoadTimeSeriesValues { get { return this._ThermalLoadTimeSeriesValues; } set { this._ThermalLoadTimeSeriesValues = value;} }
	
		[Description("This attribute must be defined if the ThermalLoadSource is USERDEFINED. ")]
		public IfcLabel? UserDefinedThermalLoadSource { get { return this._UserDefinedThermalLoadSource; } set { this._UserDefinedThermalLoadSource = value;} }
	
		[Description("This attribute must be defined if the PropertySource is USERDEFINED. ")]
		public IfcLabel? UserDefinedPropertySource { get { return this._UserDefinedPropertySource; } set { this._UserDefinedPropertySource = value;} }
	
		[Description("Defines the type of thermal load (e.g., sensible, latent, radiant, etc.).")]
		public IfcThermalLoadTypeEnum ThermalLoadType { get { return this._ThermalLoadType; } set { this._ThermalLoadType = value;} }
	
	
	}
	
}

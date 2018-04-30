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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	public partial class IfcElectricalBaseProperties : IfcEnergyProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Type of electrical current applied")]
		public IfcElectricCurrentEnum? ElectricCurrentType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Input electrical potential")]
		[Required()]
		public IfcElectricVoltageMeasure InputVoltage { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Nominal frequency of input voltage wave form. ")]
		[Required()]
		public IfcFrequencyMeasure InputFrequency { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Full load electrical current requirements.")]
		public IfcElectricCurrentMeasure? FullLoadCurrent { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Minimum current carrying capacity of the electrical circuit.")]
		public IfcElectricCurrentMeasure? MinimumCircuitCurrent { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Maximum power input of the electrical device")]
		public IfcPowerMeasure? MaximumPowerInput { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Actual electrical input power of the electrical device at its rated capacity")]
		public IfcPowerMeasure? RatedPowerInput { get; set; }
	
		[DataMember(Order = 7)] 
		[Description("Relative phase of input conductors")]
		[Required()]
		public Int64 InputPhase { get; set; }
	
	
		public IfcElectricalBaseProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcEnergySequenceEnum? __EnergySequence, IfcLabel? __UserDefinedEnergySequence, IfcElectricCurrentEnum? __ElectricCurrentType, IfcElectricVoltageMeasure __InputVoltage, IfcFrequencyMeasure __InputFrequency, IfcElectricCurrentMeasure? __FullLoadCurrent, IfcElectricCurrentMeasure? __MinimumCircuitCurrent, IfcPowerMeasure? __MaximumPowerInput, IfcPowerMeasure? __RatedPowerInput, Int64 __InputPhase)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __EnergySequence, __UserDefinedEnergySequence)
		{
			this.ElectricCurrentType = __ElectricCurrentType;
			this.InputVoltage = __InputVoltage;
			this.InputFrequency = __InputFrequency;
			this.FullLoadCurrent = __FullLoadCurrent;
			this.MinimumCircuitCurrent = __MinimumCircuitCurrent;
			this.MaximumPowerInput = __MaximumPowerInput;
			this.RatedPowerInput = __RatedPowerInput;
			this.InputPhase = __InputPhase;
		}
	
	
	}
	
}

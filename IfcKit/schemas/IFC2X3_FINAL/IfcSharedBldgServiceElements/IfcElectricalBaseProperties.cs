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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("eac2a4f1-5752-4826-871f-79625f224283")]
	public partial class IfcElectricalBaseProperties : IfcEnergyProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcElectricCurrentEnum? _ElectricCurrentType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcElectricVoltageMeasure _InputVoltage;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcFrequencyMeasure _InputFrequency;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcElectricCurrentMeasure? _FullLoadCurrent;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcElectricCurrentMeasure? _MinimumCircuitCurrent;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcPowerMeasure? _MaximumPowerInput;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcPowerMeasure? _RatedPowerInput;
	
		[DataMember(Order=7)] 
		[Required()]
		Int64 _InputPhase;
	
	
		public IfcElectricalBaseProperties()
		{
		}
	
		public IfcElectricalBaseProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcEnergySequenceEnum? __EnergySequence, IfcLabel? __UserDefinedEnergySequence, IfcElectricCurrentEnum? __ElectricCurrentType, IfcElectricVoltageMeasure __InputVoltage, IfcFrequencyMeasure __InputFrequency, IfcElectricCurrentMeasure? __FullLoadCurrent, IfcElectricCurrentMeasure? __MinimumCircuitCurrent, IfcPowerMeasure? __MaximumPowerInput, IfcPowerMeasure? __RatedPowerInput, Int64 __InputPhase)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __EnergySequence, __UserDefinedEnergySequence)
		{
			this._ElectricCurrentType = __ElectricCurrentType;
			this._InputVoltage = __InputVoltage;
			this._InputFrequency = __InputFrequency;
			this._FullLoadCurrent = __FullLoadCurrent;
			this._MinimumCircuitCurrent = __MinimumCircuitCurrent;
			this._MaximumPowerInput = __MaximumPowerInput;
			this._RatedPowerInput = __RatedPowerInput;
			this._InputPhase = __InputPhase;
		}
	
		[Description("Type of electrical current applied")]
		public IfcElectricCurrentEnum? ElectricCurrentType { get { return this._ElectricCurrentType; } set { this._ElectricCurrentType = value;} }
	
		[Description("Input electrical potential")]
		public IfcElectricVoltageMeasure InputVoltage { get { return this._InputVoltage; } set { this._InputVoltage = value;} }
	
		[Description("Nominal frequency of input voltage wave form. ")]
		public IfcFrequencyMeasure InputFrequency { get { return this._InputFrequency; } set { this._InputFrequency = value;} }
	
		[Description("Full load electrical current requirements.")]
		public IfcElectricCurrentMeasure? FullLoadCurrent { get { return this._FullLoadCurrent; } set { this._FullLoadCurrent = value;} }
	
		[Description("Minimum current carrying capacity of the electrical circuit.")]
		public IfcElectricCurrentMeasure? MinimumCircuitCurrent { get { return this._MinimumCircuitCurrent; } set { this._MinimumCircuitCurrent = value;} }
	
		[Description("Maximum power input of the electrical device")]
		public IfcPowerMeasure? MaximumPowerInput { get { return this._MaximumPowerInput; } set { this._MaximumPowerInput = value;} }
	
		[Description("Actual electrical input power of the electrical device at its rated capacity")]
		public IfcPowerMeasure? RatedPowerInput { get { return this._RatedPowerInput; } set { this._RatedPowerInput = value;} }
	
		[Description("Relative phase of input conductors")]
		public Int64 InputPhase { get { return this._InputPhase; } set { this._InputPhase = value;} }
	
	
	}
	
}

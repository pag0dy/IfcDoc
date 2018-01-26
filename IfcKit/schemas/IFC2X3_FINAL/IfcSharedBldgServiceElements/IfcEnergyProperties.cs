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
	[Guid("394bd3c4-2aed-40d7-b419-a40224b9729a")]
	public partial class IfcEnergyProperties : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcEnergySequenceEnum? _EnergySequence;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedEnergySequence;
	
	
		public IfcEnergyProperties()
		{
		}
	
		public IfcEnergyProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcEnergySequenceEnum? __EnergySequence, IfcLabel? __UserDefinedEnergySequence)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._EnergySequence = __EnergySequence;
			this._UserDefinedEnergySequence = __UserDefinedEnergySequence;
		}
	
		public IfcEnergySequenceEnum? EnergySequence { get { return this._EnergySequence; } set { this._EnergySequence = value;} }
	
		[Description("This attribute must be defined if the EnergySequence is USERDEFINED. ")]
		public IfcLabel? UserDefinedEnergySequence { get { return this._UserDefinedEnergySequence; } set { this._UserDefinedEnergySequence = value;} }
	
	
	}
	
}

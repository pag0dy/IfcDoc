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
	public partial class IfcEnergyProperties : IfcPropertySetDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		public IfcEnergySequenceEnum? EnergySequence { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("This attribute must be defined if the EnergySequence is USERDEFINED. ")]
		public IfcLabel? UserDefinedEnergySequence { get; set; }
	
	
		public IfcEnergyProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcEnergySequenceEnum? __EnergySequence, IfcLabel? __UserDefinedEnergySequence)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.EnergySequence = __EnergySequence;
			this.UserDefinedEnergySequence = __UserDefinedEnergySequence;
		}
	
	
	}
	
}

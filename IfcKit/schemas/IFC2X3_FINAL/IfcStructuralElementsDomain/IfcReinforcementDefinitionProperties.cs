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
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("5208d1af-f12c-4c88-b45d-f93eeab15baf")]
	public partial class IfcReinforcementDefinitionProperties : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _DefinitionType;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		IList<IfcSectionReinforcementProperties> _ReinforcementSectionDefinitions = new List<IfcSectionReinforcementProperties>();
	
	
		public IfcReinforcementDefinitionProperties()
		{
		}
	
		public IfcReinforcementDefinitionProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __DefinitionType, IfcSectionReinforcementProperties[] __ReinforcementSectionDefinitions)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._DefinitionType = __DefinitionType;
			this._ReinforcementSectionDefinitions = new List<IfcSectionReinforcementProperties>(__ReinforcementSectionDefinitions);
		}
	
		[Description("Descriptive type name applied to reinforcement definition properties.")]
		public IfcLabel? DefinitionType { get { return this._DefinitionType; } set { this._DefinitionType = value;} }
	
		[Description("The list of section reinforcement properties attached to the reinforcement defini" +
	    "tion properties.")]
		public IList<IfcSectionReinforcementProperties> ReinforcementSectionDefinitions { get { return this._ReinforcementSectionDefinitions; } }
	
	
	}
	
}

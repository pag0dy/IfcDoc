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

namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	[Guid("ecfbb944-6746-4a4d-a796-aa4d0ca7fcb9")]
	public partial class IfcLaborResource : IfcConstructionResource
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcText? _SkillSet;
	
	
		public IfcLaborResource()
		{
		}
	
		public IfcLaborResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __ResourceIdentifier, IfcLabel? __ResourceGroup, IfcResourceConsumptionEnum? __ResourceConsumption, IfcMeasureWithUnit __BaseQuantity, IfcText? __SkillSet)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ResourceIdentifier, __ResourceGroup, __ResourceConsumption, __BaseQuantity)
		{
			this._SkillSet = __SkillSet;
		}
	
		[Description("The skill set required for this type of labor.")]
		public IfcText? SkillSet { get { return this._SkillSet; } set { this._SkillSet = value;} }
	
	
	}
	
}

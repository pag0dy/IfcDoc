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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	public partial class IfcSubContractResource : IfcConstructionResource
	{
		[DataMember(Order = 0)] 
		[Description("The actor performing the role of the subcontracted resource.")]
		public IfcActorSelect SubContractor { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The description of the jobs that this subcontract should complete.  ")]
		public IfcText? JobDescription { get; set; }
	
	
		public IfcSubContractResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __ResourceIdentifier, IfcLabel? __ResourceGroup, IfcResourceConsumptionEnum? __ResourceConsumption, IfcMeasureWithUnit __BaseQuantity, IfcActorSelect __SubContractor, IfcText? __JobDescription)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ResourceIdentifier, __ResourceGroup, __ResourceConsumption, __BaseQuantity)
		{
			this.SubContractor = __SubContractor;
			this.JobDescription = __JobDescription;
		}
	
	
	}
	
}

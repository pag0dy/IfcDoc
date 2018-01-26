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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	[Guid("7a371b2d-09e6-44c0-9083-384d74318393")]
	public partial class IfcSubContractResource : IfcConstructionResource
	{
		[DataMember(Order=0)] 
		IfcActorSelect _SubContractor;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _JobDescription;
	
	
		public IfcSubContractResource()
		{
		}
	
		public IfcSubContractResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __ResourceIdentifier, IfcLabel? __ResourceGroup, IfcResourceConsumptionEnum? __ResourceConsumption, IfcMeasureWithUnit __BaseQuantity, IfcActorSelect __SubContractor, IfcText? __JobDescription)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ResourceIdentifier, __ResourceGroup, __ResourceConsumption, __BaseQuantity)
		{
			this._SubContractor = __SubContractor;
			this._JobDescription = __JobDescription;
		}
	
		[Description("The actor performing the role of the subcontracted resource.")]
		public IfcActorSelect SubContractor { get { return this._SubContractor; } set { this._SubContractor = value;} }
	
		[Description("The description of the jobs that this subcontract should complete.\r\n")]
		public IfcText? JobDescription { get { return this._JobDescription; } set { this._JobDescription = value;} }
	
	
	}
	
}

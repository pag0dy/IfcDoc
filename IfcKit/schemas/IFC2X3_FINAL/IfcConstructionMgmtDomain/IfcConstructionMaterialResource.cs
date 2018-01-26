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
	[Guid("8ca7e9ca-418d-449f-8156-85a0d8c68a74")]
	public partial class IfcConstructionMaterialResource : IfcConstructionResource
	{
		[DataMember(Order=0)] 
		[MinLength(1)]
		ISet<IfcActorSelect> _Suppliers = new HashSet<IfcActorSelect>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcRatioMeasure? _UsageRatio;
	
	
		public IfcConstructionMaterialResource()
		{
		}
	
		public IfcConstructionMaterialResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __ResourceIdentifier, IfcLabel? __ResourceGroup, IfcResourceConsumptionEnum? __ResourceConsumption, IfcMeasureWithUnit __BaseQuantity, IfcActorSelect[] __Suppliers, IfcRatioMeasure? __UsageRatio)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ResourceIdentifier, __ResourceGroup, __ResourceConsumption, __BaseQuantity)
		{
			this._Suppliers = new HashSet<IfcActorSelect>(__Suppliers);
			this._UsageRatio = __UsageRatio;
		}
	
		[Description("Possible suppliers of the type of materials.")]
		public ISet<IfcActorSelect> Suppliers { get { return this._Suppliers; } }
	
		[Description("The ratio of the amount of a construction material used to the amount provided (d" +
	    "etermined as a quantity)")]
		public IfcRatioMeasure? UsageRatio { get { return this._UsageRatio; } set { this._UsageRatio = value;} }
	
	
	}
	
}

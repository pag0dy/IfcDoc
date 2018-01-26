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

using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	[Guid("affcff56-3734-44c1-8c8d-7681c02ae21b")]
	public partial class IfcConstructionMaterialResourceType : IfcConstructionResourceType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcConstructionMaterialResourceTypeEnum _PredefinedType;
	
	
		public IfcConstructionMaterialResourceType()
		{
		}
	
		public IfcConstructionMaterialResourceType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcLabel? __ResourceType, IfcAppliedValue[] __BaseCosts, IfcPhysicalQuantity __BaseQuantity, IfcConstructionMaterialResourceTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __Identification, __LongDescription, __ResourceType, __BaseCosts, __BaseQuantity)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Defines types of construction material resources.\r\n<p></p>")]
		public IfcConstructionMaterialResourceTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}

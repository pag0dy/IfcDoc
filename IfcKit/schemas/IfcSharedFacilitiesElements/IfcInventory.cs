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
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	public partial class IfcInventory : IfcGroup
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A list of the types of inventories from which that required may be selected.  ")]
		[Required()]
		public IfcInventoryTypeEnum InventoryType { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The organizational unit to which the inventory is applicable.")]
		[Required()]
		public IfcActorSelect Jurisdiction { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Persons who are responsible for the inventory.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcPerson> ResponsiblePersons { get; protected set; }
	
		[DataMember(Order = 3)] 
		[Description("The date on which the last update of the inventory was carried out.")]
		[Required()]
		public IfcCalendarDate LastUpdateDate { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("An estimate of the current cost value of the inventory.")]
		public IfcCostValue CurrentValue { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("An estimate of the original cost value of the inventory.")]
		public IfcCostValue OriginalValue { get; set; }
	
	
		public IfcInventory(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcInventoryTypeEnum __InventoryType, IfcActorSelect __Jurisdiction, IfcPerson[] __ResponsiblePersons, IfcCalendarDate __LastUpdateDate, IfcCostValue __CurrentValue, IfcCostValue __OriginalValue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.InventoryType = __InventoryType;
			this.Jurisdiction = __Jurisdiction;
			this.ResponsiblePersons = new HashSet<IfcPerson>(__ResponsiblePersons);
			this.LastUpdateDate = __LastUpdateDate;
			this.CurrentValue = __CurrentValue;
			this.OriginalValue = __OriginalValue;
		}
	
	
	}
	
}

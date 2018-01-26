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
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	[Guid("b909fc68-c046-4f90-9f4e-6e8916093ebf")]
	public partial class IfcInventory : IfcGroup
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcInventoryTypeEnum _InventoryType;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcActorSelect _Jurisdiction;
	
		[DataMember(Order=2)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcPerson> _ResponsiblePersons = new HashSet<IfcPerson>();
	
		[DataMember(Order=3)] 
		[Required()]
		IfcCalendarDate _LastUpdateDate;
	
		[DataMember(Order=4)] 
		IfcCostValue _CurrentValue;
	
		[DataMember(Order=5)] 
		IfcCostValue _OriginalValue;
	
	
		public IfcInventory()
		{
		}
	
		public IfcInventory(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcInventoryTypeEnum __InventoryType, IfcActorSelect __Jurisdiction, IfcPerson[] __ResponsiblePersons, IfcCalendarDate __LastUpdateDate, IfcCostValue __CurrentValue, IfcCostValue __OriginalValue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._InventoryType = __InventoryType;
			this._Jurisdiction = __Jurisdiction;
			this._ResponsiblePersons = new HashSet<IfcPerson>(__ResponsiblePersons);
			this._LastUpdateDate = __LastUpdateDate;
			this._CurrentValue = __CurrentValue;
			this._OriginalValue = __OriginalValue;
		}
	
		[Description("A list of the types of inventories from which that required may be selected.\r\n")]
		public IfcInventoryTypeEnum InventoryType { get { return this._InventoryType; } set { this._InventoryType = value;} }
	
		[Description("The organizational unit to which the inventory is applicable.")]
		public IfcActorSelect Jurisdiction { get { return this._Jurisdiction; } set { this._Jurisdiction = value;} }
	
		[Description("Persons who are responsible for the inventory.")]
		public ISet<IfcPerson> ResponsiblePersons { get { return this._ResponsiblePersons; } }
	
		[Description("The date on which the last update of the inventory was carried out.")]
		public IfcCalendarDate LastUpdateDate { get { return this._LastUpdateDate; } set { this._LastUpdateDate = value;} }
	
		[Description("An estimate of the current cost value of the inventory.")]
		public IfcCostValue CurrentValue { get { return this._CurrentValue; } set { this._CurrentValue = value;} }
	
		[Description("An estimate of the original cost value of the inventory.")]
		public IfcCostValue OriginalValue { get { return this._OriginalValue; } set { this._OriginalValue = value;} }
	
	
	}
	
}

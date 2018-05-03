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
		[Description("A list of the types of inventories from which that required may be selected.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Attribute made optional.</blockquote>   ")]
		public IfcInventoryTypeEnum? PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The organizational unit to which the inventory is applicable.")]
		public IfcActorSelect Jurisdiction { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Persons who are responsible for the inventory.")]
		[MinLength(1)]
		public ISet<IfcPerson> ResponsiblePersons { get; protected set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("<p>The date on which the last update of the inventory was carried out.</p>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect.</blockquote>    ")]
		public IfcDate? LastUpdateDate { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlElement]
		[Description("An estimate of the current cost value of the inventory.")]
		public IfcCostValue CurrentValue { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlElement]
		[Description("An estimate of the original cost value of the inventory.")]
		public IfcCostValue OriginalValue { get; set; }
	
	
		public IfcInventory(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcInventoryTypeEnum? __PredefinedType, IfcActorSelect __Jurisdiction, IfcPerson[] __ResponsiblePersons, IfcDate? __LastUpdateDate, IfcCostValue __CurrentValue, IfcCostValue __OriginalValue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.PredefinedType = __PredefinedType;
			this.Jurisdiction = __Jurisdiction;
			this.ResponsiblePersons = new HashSet<IfcPerson>(__ResponsiblePersons);
			this.LastUpdateDate = __LastUpdateDate;
			this.CurrentValue = __CurrentValue;
			this.OriginalValue = __OriginalValue;
		}
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	public partial class IfcCostItem : IfcControl
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Predefined generic type for a cost item that is specified in an enumeration. There may be a property set given specificly for the predefined types.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been added.</blockquote>  ")]
		public IfcCostItemTypeEnum? PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Component costs for which the total cost for the cost item is calculated, and then multiplied by the total <em>CostQuantities</em> if provided.      If <em>CostQuantities</em> is provided then values indicate unit costs, otherwise values indicate total costs.    For calculation purposes, the cost values may be directly added unless they have qualifications.  Cost values with qualifications (e.g. <em>IfcCostValue.ApplicableDate</em>, <em>IfcCostValue.FixedUntilDate</em>) should be excluded from such calculation if they do not apply.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been added.</blockquote>  ")]
		[MinLength(1)]
		public IList<IfcCostValue> CostValues { get; protected set; }
	
		[DataMember(Order = 2)] 
		[Description("Component quantities of the same type for which the total quantity for the cost item is calculated as the sum.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been added.</blockquote>        ")]
		[MinLength(1)]
		public IList<IfcPhysicalQuantity> CostQuantities { get; protected set; }
	
	
		public IfcCostItem(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcCostItemTypeEnum? __PredefinedType, IfcCostValue[] __CostValues, IfcPhysicalQuantity[] __CostQuantities)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification)
		{
			this.PredefinedType = __PredefinedType;
			this.CostValues = new List<IfcCostValue>(__CostValues);
			this.CostQuantities = new List<IfcPhysicalQuantity>(__CostQuantities);
		}
	
	
	}
	
}

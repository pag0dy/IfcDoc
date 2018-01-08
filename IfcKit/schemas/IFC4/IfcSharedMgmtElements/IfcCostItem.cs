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
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	[Guid("78610aed-e656-483f-b7d3-8fc99b2c0312")]
	public partial class IfcCostItem : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCostItemTypeEnum? _PredefinedType;
	
		[DataMember(Order=1)] 
		IList<IfcCostValue> _CostValues = new List<IfcCostValue>();
	
		[DataMember(Order=2)] 
		IList<IfcPhysicalQuantity> _CostQuantities = new List<IfcPhysicalQuantity>();
	
	
		[Description("Predefined generic type for a cost item that is specified in an enumeration. Ther" +
	    "e may be a property set given specificly for the predefined types.\r\n\r\n<blockquot" +
	    "e class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been added.</blockquote>\r" +
	    "\n")]
		public IfcCostItemTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"Component costs for which the total cost for the cost item is calculated, and then multiplied by the total <em>CostQuantities</em> if provided.  
	
	If <em>CostQuantities</em> is provided then values indicate unit costs, otherwise values indicate total costs.
	
	For calculation purposes, the cost values may be directly added unless they have qualifications.  Cost values with qualifications (e.g. <em>IfcCostValue.ApplicableDate</em>, <em>IfcCostValue.FixedUntilDate</em>) should be excluded from such calculation if they do not apply.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The attribute has been added.</blockquote>
	")]
		public IList<IfcCostValue> CostValues { get { return this._CostValues; } }
	
		[Description("Component quantities of the same type for which the total quantity for the cost i" +
	    "tem is calculated as the sum.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE  Th" +
	    "e attribute has been added.</blockquote>\r\n\r\n\r\n\r\n")]
		public IList<IfcPhysicalQuantity> CostQuantities { get { return this._CostQuantities; } }
	
	
	}
	
}

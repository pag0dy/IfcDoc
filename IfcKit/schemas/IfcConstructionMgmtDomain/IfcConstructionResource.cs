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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	public abstract partial class IfcConstructionResource : IfcResource
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Indicates the work, usage, and times scheduled and completed.  Some attributes on this object may have associated constraints or time series; see documentation of <em>IfcResourceTime</em> for specific usage.  If the resource is nested, then certain values may be calculated based on the component resources as indicated at <em>IfcResourceTime</em>.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute.</blockquote>")]
		public IfcResourceTime Usage { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Indicates the unit costs for which accrued amounts should be calculated.  Such unit costs may be split into <em>Name</em> designations (for example, 'Standard', 'Overtime'), and may contain a hierarchy of cost values that apply at different dates (using <em>IfcCostValue.ApplicableDate</em> and <em>IfcCostValue.FixedUntilDate</em>).    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute.</blockquote>")]
		[MinLength(1)]
		public IList<IfcAppliedValue> BaseCosts { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("Identifies the base quantity consumed of the resource relative to assignments.      For crew, labour, subcontract, and equipment resources, this refers to <i>IfcQuantityTime</i>.    For material resources, this refers to <i>IfcQuantityVolume</i>.    For product resources, this refers to <i>IfcQuantityCount</i>.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute.</blockquote>")]
		public IfcPhysicalQuantity BaseQuantity { get; set; }
	
	
		protected IfcConstructionResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcResourceTime __Usage, IfcAppliedValue[] __BaseCosts, IfcPhysicalQuantity __BaseQuantity)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification, __LongDescription)
		{
			this.Usage = __Usage;
			this.BaseCosts = new List<IfcAppliedValue>(__BaseCosts);
			this.BaseQuantity = __BaseQuantity;
		}
	
	
	}
	
}

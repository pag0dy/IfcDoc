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
	[Guid("c642ffe1-4447-43e7-935a-fa0b8f9420ed")]
	public abstract partial class IfcConstructionResourceType : IfcTypeResource
	{
		[DataMember(Order=0)] 
		[MinLength(1)]
		IList<IfcAppliedValue> _BaseCosts = new List<IfcAppliedValue>();
	
		[DataMember(Order=1)] 
		[XmlElement]
		IfcPhysicalQuantity _BaseQuantity;
	
	
		public IfcConstructionResourceType()
		{
		}
	
		public IfcConstructionResourceType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcLabel? __ResourceType, IfcAppliedValue[] __BaseCosts, IfcPhysicalQuantity __BaseQuantity)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __Identification, __LongDescription, __ResourceType)
		{
			this._BaseCosts = new List<IfcAppliedValue>(__BaseCosts);
			this._BaseQuantity = __BaseQuantity;
		}
	
		[Description(@"Indicates the unit costs and environmental impacts for which accrued amounts should be calculated.  Such unit costs may be split into <em>Name</em> designations (e.g. 'Standard', 'Overtime'), and may contain a hierarchy of cost values that apply at different dates (using <em>IfcCostValue.ApplicableDate</em> and <em>IfcCostValue.FixedUntilDate</em>).
	
	<p></p>")]
		public IList<IfcAppliedValue> BaseCosts { get { return this._BaseCosts; } }
	
		[Description(@"Identifies the quantity for which the <em>BaseQuantityProduced</em> applies.  The <em>Name</em> of the <em>IfcPhysicalQuantity</em> identifies the quantity definition being measured, e.g. ""GrossVolume"".  For production-based resources (e.g. carpentry labor), this value refers to quantities on <em>IfcProduct</em>(s) to which the assigned <em>IfcTask</em> is assigned.  For duration-based resources (e.g. safety inspector, fuel for equipment), this value refers to quantities that may be assigned to occurrences of the assigned <em>IfcTaskType</em>.
	
	<p></p>")]
		public IfcPhysicalQuantity BaseQuantity { get { return this._BaseQuantity; } set { this._BaseQuantity = value;} }
	
	
	}
	
}

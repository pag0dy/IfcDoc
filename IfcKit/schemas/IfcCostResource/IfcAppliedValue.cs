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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	public abstract partial class IfcAppliedValue :
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A name or additional clarification given to a cost (or impact) value.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The description that may apply additional information about a cost (or impact) value. The description may be from purpose generated text, specification libraries, standards etc.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The extent or quantity or amount of an applied value.")]
		public IfcAppliedValueSelect AppliedValue { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The number and unit of measure on which the unit cost is based.    Note: As well as the normally expected units of measure such as length, area, volume etc., costs may be based on units of measure which need to be defined e.g. sack, drum, pallet, item etc. Unit costs may be based on quantities greater (or lesser) than a unitary value of the basis measure. For instance, timber may have a unit cost rate per X meters where X > 1; similarly for cable, piping and many other items. The basis number may be either an integer or a real value.    Note: This attribute should be asserted for all circumstances where the cost to be applied is per unit quantity. It may be asserted even for circumstances where an item price is used, in which case the unit cost basis should be by item (or equivalent definition).  ")]
		public IfcMeasureWithUnit UnitBasis { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The date on or from which an applied value is applicable.")]
		public IfcDateTimeSelect ApplicableDate { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("The date until which applied value is applicable.")]
		public IfcDateTimeSelect FixedUntilDate { get; set; }
	
		[InverseProperty("ReferencingValues")] 
		[Description("Pointer to the IfcReferencesCostDocument relationship, which refer to a document from which the cost value is referenced.")]
		public ISet<IfcReferencesValueDocument> ValuesReferenced { get; protected set; }
	
		[InverseProperty("ComponentOfTotal")] 
		[Description("The total (or subtotal) value of the components within the applied value relationship expressed as a single applied value.")]
		public ISet<IfcAppliedValueRelationship> ValueOfComponents { get; protected set; }
	
		[InverseProperty("Components")] 
		[Description("The value of the single applied value which is used by the applied value relationship to express a complex applied value.")]
		public ISet<IfcAppliedValueRelationship> IsComponentIn { get; protected set; }
	
	
		protected IfcAppliedValue(IfcLabel? __Name, IfcText? __Description, IfcAppliedValueSelect __AppliedValue, IfcMeasureWithUnit __UnitBasis, IfcDateTimeSelect __ApplicableDate, IfcDateTimeSelect __FixedUntilDate)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.AppliedValue = __AppliedValue;
			this.UnitBasis = __UnitBasis;
			this.ApplicableDate = __ApplicableDate;
			this.FixedUntilDate = __FixedUntilDate;
			this.ValuesReferenced = new HashSet<IfcReferencesValueDocument>();
			this.ValueOfComponents = new HashSet<IfcAppliedValueRelationship>();
			this.IsComponentIn = new HashSet<IfcAppliedValueRelationship>();
		}
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	[Guid("f52c72c0-c3b8-4b71-bc7a-c1557f744b01")]
	public abstract partial class IfcAppliedValue :
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		IfcAppliedValueSelect _AppliedValue;
	
		[DataMember(Order=3)] 
		IfcMeasureWithUnit _UnitBasis;
	
		[DataMember(Order=4)] 
		IfcDateTimeSelect _ApplicableDate;
	
		[DataMember(Order=5)] 
		IfcDateTimeSelect _FixedUntilDate;
	
		[InverseProperty("ReferencingValues")] 
		ISet<IfcReferencesValueDocument> _ValuesReferenced = new HashSet<IfcReferencesValueDocument>();
	
		[InverseProperty("ComponentOfTotal")] 
		ISet<IfcAppliedValueRelationship> _ValueOfComponents = new HashSet<IfcAppliedValueRelationship>();
	
		[InverseProperty("Components")] 
		ISet<IfcAppliedValueRelationship> _IsComponentIn = new HashSet<IfcAppliedValueRelationship>();
	
	
		public IfcAppliedValue()
		{
		}
	
		public IfcAppliedValue(IfcLabel? __Name, IfcText? __Description, IfcAppliedValueSelect __AppliedValue, IfcMeasureWithUnit __UnitBasis, IfcDateTimeSelect __ApplicableDate, IfcDateTimeSelect __FixedUntilDate)
		{
			this._Name = __Name;
			this._Description = __Description;
			this._AppliedValue = __AppliedValue;
			this._UnitBasis = __UnitBasis;
			this._ApplicableDate = __ApplicableDate;
			this._FixedUntilDate = __FixedUntilDate;
		}
	
		[Description("A name or additional clarification given to a cost (or impact) value.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("The description that may apply additional information about a cost (or impact) va" +
	    "lue. The description may be from purpose generated text, specification libraries" +
	    ", standards etc.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The extent or quantity or amount of an applied value.")]
		public IfcAppliedValueSelect AppliedValue { get { return this._AppliedValue; } set { this._AppliedValue = value;} }
	
		[Description(@"The number and unit of measure on which the unit cost is based.
	
	Note: As well as the normally expected units of measure such as length, area, volume etc., costs may be based on units of measure which need to be defined e.g. sack, drum, pallet, item etc. Unit costs may be based on quantities greater (or lesser) than a unitary value of the basis measure. For instance, timber may have a unit cost rate per X meters where X > 1; similarly for cable, piping and many other items. The basis number may be either an integer or a real value.
	
	Note: This attribute should be asserted for all circumstances where the cost to be applied is per unit quantity. It may be asserted even for circumstances where an item price is used, in which case the unit cost basis should be by item (or equivalent definition).
	")]
		public IfcMeasureWithUnit UnitBasis { get { return this._UnitBasis; } set { this._UnitBasis = value;} }
	
		[Description("The date on or from which an applied value is applicable.")]
		public IfcDateTimeSelect ApplicableDate { get { return this._ApplicableDate; } set { this._ApplicableDate = value;} }
	
		[Description("The date until which applied value is applicable.")]
		public IfcDateTimeSelect FixedUntilDate { get { return this._FixedUntilDate; } set { this._FixedUntilDate = value;} }
	
		[Description("Pointer to the IfcReferencesCostDocument relationship, which refer to a document " +
	    "from which the cost value is referenced.")]
		public ISet<IfcReferencesValueDocument> ValuesReferenced { get { return this._ValuesReferenced; } }
	
		[Description("The total (or subtotal) value of the components within the applied value relation" +
	    "ship expressed as a single applied value.")]
		public ISet<IfcAppliedValueRelationship> ValueOfComponents { get { return this._ValueOfComponents; } }
	
		[Description("The value of the single applied value which is used by the applied value relation" +
	    "ship to express a complex applied value.")]
		public ISet<IfcAppliedValueRelationship> IsComponentIn { get { return this._IsComponentIn; } }
	
	
	}
	
}

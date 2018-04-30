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

using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	public partial class IfcAppliedValue :
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A name or additional clarification given to a cost value.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The description that may apply additional information about a cost value.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The extent or quantity or amount of an applied value.")]
		public IfcAppliedValueSelect AppliedValue { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlElement]
		[Description("The number and unit of measure on which the unit cost is based.    Note: As well as the normally expected units of measure such as length, area, volume etc., costs may be based on units of measure which need to be defined e.g. sack, drum, pallet, item etc. Unit costs may be based on quantities greater (or lesser) than a unitary value of the basis measure. For instance, timber may have a unit cost rate per X meters where X > 1; similarly for cable, piping and many other items. The basis number may be either an integer or a real value.    Note: This attribute should be asserted for all circumstances where the cost to be applied is per unit quantity. It may be asserted even for circumstances where an item price is used, in which case the unit cost basis should be by item (or equivalent definition).  ")]
		public IfcMeasureWithUnit UnitBasis { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The date on or from which an applied value is applicable.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect.</blockquote>    ")]
		public IfcDate? ApplicableDate { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("The date until which applied value is applicable.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect.</blockquote>    ")]
		public IfcDate? FixedUntilDate { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Specification of the type of cost used.    <blockquote class=\"note\">NOTE&nbsp; There are many possible types of cost value that may be identified. Whilst there is a broad understanding of the meaning of names that may be assigned to different types of costs, there is no general standard for naming cost types nor are there any broadly defined classifications. To allow for any type of cost value, the <i>IfcLabel</i> datatype is assigned.</blockquote>     In the absence of any well defined standard, it is recommended that local agreements should be made to define allowable and understandable cost value types within a project or region.  ")]
		public IfcLabel? Category { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("The condition under which a cost value applies.      For example, within the context of a bid submission, this may refer to an option that may or may not be elected.")]
		public IfcLabel? Condition { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("The arithmetic operator applied to component values.")]
		public IfcArithmeticOperatorEnum? ArithmeticOperator { get; set; }
	
		[DataMember(Order = 9)] 
		[Description("Optional component values from which <i>AppliedValue</i> is calculated.")]
		[MinLength(1)]
		public IList<IfcAppliedValue> Components { get; protected set; }
	
		[InverseProperty("RelatedResourceObjects")] 
		[Description("Reference to an external reference, e.g. library, classification, or document information, that is associated to the IfcAppliedValue.   <blockquote class=\"change-ifc2x4\">IFC4 CHANGE New inverse attribute.</blockquote>    ")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReference { get; protected set; }
	
	
		public IfcAppliedValue(IfcLabel? __Name, IfcText? __Description, IfcAppliedValueSelect __AppliedValue, IfcMeasureWithUnit __UnitBasis, IfcDate? __ApplicableDate, IfcDate? __FixedUntilDate, IfcLabel? __Category, IfcLabel? __Condition, IfcArithmeticOperatorEnum? __ArithmeticOperator, IfcAppliedValue[] __Components)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.AppliedValue = __AppliedValue;
			this.UnitBasis = __UnitBasis;
			this.ApplicableDate = __ApplicableDate;
			this.FixedUntilDate = __FixedUntilDate;
			this.Category = __Category;
			this.Condition = __Condition;
			this.ArithmeticOperator = __ArithmeticOperator;
			this.Components = new List<IfcAppliedValue>(__Components);
			this.HasExternalReference = new HashSet<IfcExternalReferenceRelationship>();
		}
	
	
	}
	
}

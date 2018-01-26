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

using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	[Guid("878e7c12-556c-42e6-a62a-feef9a77b4f9")]
	public partial class IfcAppliedValue :
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
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
		[XmlElement]
		IfcMeasureWithUnit _UnitBasis;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcDate? _ApplicableDate;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcDate? _FixedUntilDate;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcLabel? _Category;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcLabel? _Condition;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcArithmeticOperatorEnum? _ArithmeticOperator;
	
		[DataMember(Order=9)] 
		[MinLength(1)]
		IList<IfcAppliedValue> _Components = new List<IfcAppliedValue>();
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcExternalReferenceRelationship> _HasExternalReference = new HashSet<IfcExternalReferenceRelationship>();
	
	
		public IfcAppliedValue()
		{
		}
	
		public IfcAppliedValue(IfcLabel? __Name, IfcText? __Description, IfcAppliedValueSelect __AppliedValue, IfcMeasureWithUnit __UnitBasis, IfcDate? __ApplicableDate, IfcDate? __FixedUntilDate, IfcLabel? __Category, IfcLabel? __Condition, IfcArithmeticOperatorEnum? __ArithmeticOperator, IfcAppliedValue[] __Components)
		{
			this._Name = __Name;
			this._Description = __Description;
			this._AppliedValue = __AppliedValue;
			this._UnitBasis = __UnitBasis;
			this._ApplicableDate = __ApplicableDate;
			this._FixedUntilDate = __FixedUntilDate;
			this._Category = __Category;
			this._Condition = __Condition;
			this._ArithmeticOperator = __ArithmeticOperator;
			this._Components = new List<IfcAppliedValue>(__Components);
		}
	
		[Description("A name or additional clarification given to a cost value.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("The description that may apply additional information about a cost value.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The extent or quantity or amount of an applied value.")]
		public IfcAppliedValueSelect AppliedValue { get { return this._AppliedValue; } set { this._AppliedValue = value;} }
	
		[Description(@"The number and unit of measure on which the unit cost is based.
	
	Note: As well as the normally expected units of measure such as length, area, volume etc., costs may be based on units of measure which need to be defined e.g. sack, drum, pallet, item etc. Unit costs may be based on quantities greater (or lesser) than a unitary value of the basis measure. For instance, timber may have a unit cost rate per X meters where X > 1; similarly for cable, piping and many other items. The basis number may be either an integer or a real value.
	
	Note: This attribute should be asserted for all circumstances where the cost to be applied is per unit quantity. It may be asserted even for circumstances where an item price is used, in which case the unit cost basis should be by item (or equivalent definition).
	")]
		public IfcMeasureWithUnit UnitBasis { get { return this._UnitBasis; } set { this._UnitBasis = value;} }
	
		[Description("The date on or from which an applied value is applicable.\r\n<blockquote class=\"cha" +
	    "nge-ifc2x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect.</blockquote>  \r\n")]
		public IfcDate? ApplicableDate { get { return this._ApplicableDate; } set { this._ApplicableDate = value;} }
	
		[Description("The date until which applied value is applicable.\r\n<blockquote class=\"change-ifc2" +
	    "x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect.</blockquote>  \r\n")]
		public IfcDate? FixedUntilDate { get { return this._FixedUntilDate; } set { this._FixedUntilDate = value;} }
	
		[Description(@"Specification of the type of cost used.
	
	<blockquote class=""note"">NOTE&nbsp; There are many possible types of cost value that may be identified. Whilst there is a broad understanding of the meaning of names that may be assigned to different types of costs, there is no general standard for naming cost types nor are there any broadly defined classifications. To allow for any type of cost value, the <i>IfcLabel</i> datatype is assigned.</blockquote>
	 
	In the absence of any well defined standard, it is recommended that local agreements should be made to define allowable and understandable cost value types within a project or region.
	")]
		public IfcLabel? Category { get { return this._Category; } set { this._Category = value;} }
	
		[Description("The condition under which a cost value applies.  \r\n\r\nFor example, within the cont" +
	    "ext of a bid submission, this may refer to an option that may or may not be elec" +
	    "ted.")]
		public IfcLabel? Condition { get { return this._Condition; } set { this._Condition = value;} }
	
		[Description("The arithmetic operator applied to component values.")]
		public IfcArithmeticOperatorEnum? ArithmeticOperator { get { return this._ArithmeticOperator; } set { this._ArithmeticOperator = value;} }
	
		[Description("Optional component values from which <i>AppliedValue</i> is calculated.")]
		public IList<IfcAppliedValue> Components { get { return this._Components; } }
	
		[Description("Reference to an external reference, e.g. library, classification, or document inf" +
	    "ormation, that is associated to the IfcAppliedValue. \r\n<blockquote class=\"change" +
	    "-ifc2x4\">IFC4 CHANGE New inverse attribute.</blockquote>  \r\n")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReference { get { return this._HasExternalReference; } }
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	[Guid("ecadb804-840e-4dc3-9324-fe958bfe9efa")]
	public partial class IfcConstraintAggregationRelationship
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcConstraint _RelatingConstraint;
	
		[DataMember(Order=3)] 
		[Required()]
		[MinLength(1)]
		IList<IfcConstraint> _RelatedConstraints = new List<IfcConstraint>();
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcLogicalOperatorEnum _LogicalAggregator;
	
	
		public IfcConstraintAggregationRelationship()
		{
		}
	
		public IfcConstraintAggregationRelationship(IfcLabel? __Name, IfcText? __Description, IfcConstraint __RelatingConstraint, IfcConstraint[] __RelatedConstraints, IfcLogicalOperatorEnum __LogicalAggregator)
		{
			this._Name = __Name;
			this._Description = __Description;
			this._RelatingConstraint = __RelatingConstraint;
			this._RelatedConstraints = new List<IfcConstraint>(__RelatedConstraints);
			this._LogicalAggregator = __LogicalAggregator;
		}
	
		[Description("A name used to identify or qualify the constraint aggregation.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A description that may apply additional information about a constraint aggregatio" +
	    "n.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Constraint to which the other Constraints are associated.\r\n")]
		public IfcConstraint RelatingConstraint { get { return this._RelatingConstraint; } set { this._RelatingConstraint = value;} }
	
		[Description("Constraints that are aggregated in using the LogicalAggregator.\r\n")]
		public IList<IfcConstraint> RelatedConstraints { get { return this._RelatedConstraints; } }
	
		[Description("Enumeration that identifies the logical type of aggregation.\r\n")]
		public IfcLogicalOperatorEnum LogicalAggregator { get { return this._LogicalAggregator; } set { this._LogicalAggregator = value;} }
	
	
	}
	
}

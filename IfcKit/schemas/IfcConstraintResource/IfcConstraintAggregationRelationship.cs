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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	public partial class IfcConstraintAggregationRelationship
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A name used to identify or qualify the constraint aggregation.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("A description that may apply additional information about a constraint aggregation.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Constraint to which the other Constraints are associated.  ")]
		[Required()]
		public IfcConstraint RelatingConstraint { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Constraints that are aggregated in using the LogicalAggregator.  ")]
		[Required()]
		[MinLength(1)]
		public IList<IfcConstraint> RelatedConstraints { get; protected set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Enumeration that identifies the logical type of aggregation.  ")]
		[Required()]
		public IfcLogicalOperatorEnum LogicalAggregator { get; set; }
	
	
		public IfcConstraintAggregationRelationship(IfcLabel? __Name, IfcText? __Description, IfcConstraint __RelatingConstraint, IfcConstraint[] __RelatedConstraints, IfcLogicalOperatorEnum __LogicalAggregator)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.RelatingConstraint = __RelatingConstraint;
			this.RelatedConstraints = new List<IfcConstraint>(__RelatedConstraints);
			this.LogicalAggregator = __LogicalAggregator;
		}
	
	
	}
	
}

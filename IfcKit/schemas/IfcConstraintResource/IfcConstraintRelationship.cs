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
	public partial class IfcConstraintRelationship
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A name used to identify or qualify the constraint relationship.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("A description that may apply additional information about the constraint relationship.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Constraint with which the other Constraints referenced by attribute RelatedConstraints are related.")]
		[Required()]
		public IfcConstraint RelatingConstraint { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Constraints that are related with the RelatingConstraint.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcConstraint> RelatedConstraints { get; protected set; }
	
	
		public IfcConstraintRelationship(IfcLabel? __Name, IfcText? __Description, IfcConstraint __RelatingConstraint, IfcConstraint[] __RelatedConstraints)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.RelatingConstraint = __RelatingConstraint;
			this.RelatedConstraints = new HashSet<IfcConstraint>(__RelatedConstraints);
		}
	
	
	}
	
}

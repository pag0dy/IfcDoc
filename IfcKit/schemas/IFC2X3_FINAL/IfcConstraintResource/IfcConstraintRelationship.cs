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
	[Guid("5c038620-a701-49be-8ea7-c323113ffef4")]
	public partial class IfcConstraintRelationship
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
		ISet<IfcConstraint> _RelatedConstraints = new HashSet<IfcConstraint>();
	
	
		public IfcConstraintRelationship()
		{
		}
	
		public IfcConstraintRelationship(IfcLabel? __Name, IfcText? __Description, IfcConstraint __RelatingConstraint, IfcConstraint[] __RelatedConstraints)
		{
			this._Name = __Name;
			this._Description = __Description;
			this._RelatingConstraint = __RelatingConstraint;
			this._RelatedConstraints = new HashSet<IfcConstraint>(__RelatedConstraints);
		}
	
		[Description("A name used to identify or qualify the constraint relationship.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A description that may apply additional information about the constraint relation" +
	    "ship.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Constraint with which the other Constraints referenced by attribute RelatedConstr" +
	    "aints are related.")]
		public IfcConstraint RelatingConstraint { get { return this._RelatingConstraint; } set { this._RelatingConstraint = value;} }
	
		[Description("Constraints that are related with the RelatingConstraint.")]
		public ISet<IfcConstraint> RelatedConstraints { get { return this._RelatedConstraints; } }
	
	
	}
	
}

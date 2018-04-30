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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	public abstract partial class IfcConstraint
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A name to be used for the constraint (e.g., ChillerCoefficientOfPerformance).")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("A description that may apply additional information about a constraint.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Enumeration that qualifies the type of constraint.")]
		[Required()]
		public IfcConstraintEnum ConstraintGrade { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Any source material, such as a code or standard, from which the constraint originated.")]
		public IfcLabel? ConstraintSource { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("Person and/or organization that has created the constraint.")]
		public IfcActorSelect CreatingActor { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("Time when information specifying the constraint instance was created.")]
		public IfcDateTimeSelect CreationTime { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Allows for specification of user defined grade of the constraint  beyond the enumeration values (hard, soft, advisory) provided by ConstraintGrade attribute of type <I>IfcConstraintEnum</I>.   When a value is provided for attribute UserDefinedGrade in parallel the attribute ConstraintGrade shall have enumeration value USERDEFINED.")]
		public IfcLabel? UserDefinedGrade { get; set; }
	
		[InverseProperty("ClassifiedConstraint")] 
		[Description("Reference to the constraint classifications through objectified relationship.")]
		public ISet<IfcConstraintClassificationRelationship> ClassifiedAs { get; protected set; }
	
		[InverseProperty("RelatingConstraint")] 
		[Description("References to the objectified relationships that relate other constraints with this constraint.")]
		public ISet<IfcConstraintRelationship> RelatesConstraints { get; protected set; }
	
		[InverseProperty("RelatedConstraints")] 
		[Description("References to the objectified relationships that relate this constraint with other constraints.")]
		public ISet<IfcConstraintRelationship> IsRelatedWith { get; protected set; }
	
		[InverseProperty("RelatingConstraint")] 
		[Description("Reference to the properties to which the constraint is applied.")]
		public ISet<IfcPropertyConstraintRelationship> PropertiesForConstraint { get; protected set; }
	
		[InverseProperty("RelatingConstraint")] 
		[Description("Reference to the relationships that collect other constraints into this aggregate constraint.  ")]
		public ISet<IfcConstraintAggregationRelationship> Aggregates { get; protected set; }
	
		[InverseProperty("RelatedConstraints")] 
		[Description("Reference to the relationships that relate this constraint into aggregate constraints.  ")]
		public ISet<IfcConstraintAggregationRelationship> IsAggregatedIn { get; protected set; }
	
	
		protected IfcConstraint(IfcLabel __Name, IfcText? __Description, IfcConstraintEnum __ConstraintGrade, IfcLabel? __ConstraintSource, IfcActorSelect __CreatingActor, IfcDateTimeSelect __CreationTime, IfcLabel? __UserDefinedGrade)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.ConstraintGrade = __ConstraintGrade;
			this.ConstraintSource = __ConstraintSource;
			this.CreatingActor = __CreatingActor;
			this.CreationTime = __CreationTime;
			this.UserDefinedGrade = __UserDefinedGrade;
			this.ClassifiedAs = new HashSet<IfcConstraintClassificationRelationship>();
			this.RelatesConstraints = new HashSet<IfcConstraintRelationship>();
			this.IsRelatedWith = new HashSet<IfcConstraintRelationship>();
			this.PropertiesForConstraint = new HashSet<IfcPropertyConstraintRelationship>();
			this.Aggregates = new HashSet<IfcConstraintAggregationRelationship>();
			this.IsAggregatedIn = new HashSet<IfcConstraintAggregationRelationship>();
		}
	
	
	}
	
}

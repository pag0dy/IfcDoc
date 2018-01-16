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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	[Guid("5936d805-983e-4841-a06c-b21b7e91209b")]
	public abstract partial class IfcConstraint
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcConstraintEnum _ConstraintGrade;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _ConstraintSource;
	
		[DataMember(Order=4)] 
		IfcActorSelect _CreatingActor;
	
		[DataMember(Order=5)] 
		IfcDateTimeSelect _CreationTime;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedGrade;
	
		[InverseProperty("ClassifiedConstraint")] 
		ISet<IfcConstraintClassificationRelationship> _ClassifiedAs = new HashSet<IfcConstraintClassificationRelationship>();
	
		[InverseProperty("RelatingConstraint")] 
		ISet<IfcConstraintRelationship> _RelatesConstraints = new HashSet<IfcConstraintRelationship>();
	
		[InverseProperty("RelatedConstraints")] 
		ISet<IfcConstraintRelationship> _IsRelatedWith = new HashSet<IfcConstraintRelationship>();
	
		[InverseProperty("RelatingConstraint")] 
		ISet<IfcPropertyConstraintRelationship> _PropertiesForConstraint = new HashSet<IfcPropertyConstraintRelationship>();
	
		[InverseProperty("RelatingConstraint")] 
		ISet<IfcConstraintAggregationRelationship> _Aggregates = new HashSet<IfcConstraintAggregationRelationship>();
	
		[InverseProperty("RelatedConstraints")] 
		ISet<IfcConstraintAggregationRelationship> _IsAggregatedIn = new HashSet<IfcConstraintAggregationRelationship>();
	
	
		[Description("A name to be used for the constraint (e.g., ChillerCoefficientOfPerformance).")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A description that may apply additional information about a constraint.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Enumeration that qualifies the type of constraint.")]
		public IfcConstraintEnum ConstraintGrade { get { return this._ConstraintGrade; } set { this._ConstraintGrade = value;} }
	
		[Description("Any source material, such as a code or standard, from which the constraint origin" +
	    "ated.")]
		public IfcLabel? ConstraintSource { get { return this._ConstraintSource; } set { this._ConstraintSource = value;} }
	
		[Description("Person and/or organization that has created the constraint.")]
		public IfcActorSelect CreatingActor { get { return this._CreatingActor; } set { this._CreatingActor = value;} }
	
		[Description("Time when information specifying the constraint instance was created.")]
		public IfcDateTimeSelect CreationTime { get { return this._CreationTime; } set { this._CreationTime = value;} }
	
		[Description(@"Allows for specification of user defined grade of the constraint  beyond the enumeration values (hard, soft, advisory) provided by ConstraintGrade attribute of type <I>IfcConstraintEnum</I>. 
	When a value is provided for attribute UserDefinedGrade in parallel the attribute ConstraintGrade shall have enumeration value USERDEFINED.")]
		public IfcLabel? UserDefinedGrade { get { return this._UserDefinedGrade; } set { this._UserDefinedGrade = value;} }
	
		[Description("Reference to the constraint classifications through objectified relationship.")]
		public ISet<IfcConstraintClassificationRelationship> ClassifiedAs { get { return this._ClassifiedAs; } }
	
		[Description("References to the objectified relationships that relate other constraints with th" +
	    "is constraint.")]
		public ISet<IfcConstraintRelationship> RelatesConstraints { get { return this._RelatesConstraints; } }
	
		[Description("References to the objectified relationships that relate this constraint with othe" +
	    "r constraints.")]
		public ISet<IfcConstraintRelationship> IsRelatedWith { get { return this._IsRelatedWith; } }
	
		[Description("Reference to the properties to which the constraint is applied.")]
		public ISet<IfcPropertyConstraintRelationship> PropertiesForConstraint { get { return this._PropertiesForConstraint; } }
	
		[Description("Reference to the relationships that collect other constraints into this aggregate" +
	    " constraint.\r\n")]
		public ISet<IfcConstraintAggregationRelationship> Aggregates { get { return this._Aggregates; } }
	
		[Description("Reference to the relationships that relate this constraint into aggregate constra" +
	    "ints.\r\n")]
		public ISet<IfcConstraintAggregationRelationship> IsAggregatedIn { get { return this._IsAggregatedIn; } }
	
	
	}
	
}

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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	public partial class IfcObjective : IfcConstraint
	{
		[DataMember(Order = 0)] 
		[Description("A list of nested constraints.    <blockquote class=\"change-ifc2x4\">IFC2X4 CHANGE&nbsp; Modified to be a LIST of nested constraints, which replaces the former <i>IfcConstraintAggregationRelationship</i>.</blockquote>")]
		[MinLength(1)]
		public IList<IfcConstraint> BenchmarkValues { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Enumeration that identifies the logical type of aggregation for the benchmark metrics.    <blockquote class=\"change-ifc2x4\">IFC2X4 CHANGE&nbsp; This attribute replaces replaces the former <i>ResultValues</i> attribute and indicates the aggregation behavior formerly defined at <i>IfcConstraintAggregationRelationship</i>.</blockquote>")]
		public IfcLogicalOperatorEnum? LogicalAggregator { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Enumeration that qualifies the type of objective constraint.  ")]
		[Required()]
		public IfcObjectiveEnum ObjectiveQualifier { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("A user defined value that qualifies the type of objective constraint when ObjectiveQualifier attribute of type <em>IfcObjectiveEnum</em> has value USERDEFINED.")]
		public IfcLabel? UserDefinedQualifier { get; set; }
	
	
		public IfcObjective(IfcLabel __Name, IfcText? __Description, IfcConstraintEnum __ConstraintGrade, IfcLabel? __ConstraintSource, IfcActorSelect __CreatingActor, IfcDateTime? __CreationTime, IfcLabel? __UserDefinedGrade, IfcConstraint[] __BenchmarkValues, IfcLogicalOperatorEnum? __LogicalAggregator, IfcObjectiveEnum __ObjectiveQualifier, IfcLabel? __UserDefinedQualifier)
			: base(__Name, __Description, __ConstraintGrade, __ConstraintSource, __CreatingActor, __CreationTime, __UserDefinedGrade)
		{
			this.BenchmarkValues = new List<IfcConstraint>(__BenchmarkValues);
			this.LogicalAggregator = __LogicalAggregator;
			this.ObjectiveQualifier = __ObjectiveQualifier;
			this.UserDefinedQualifier = __UserDefinedQualifier;
		}
	
	
	}
	
}

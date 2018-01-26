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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	[Guid("2a23c0f9-203b-4e38-9564-91c5cb3f651d")]
	public partial class IfcObjective : IfcConstraint
	{
		[DataMember(Order=0)] 
		[MinLength(1)]
		IList<IfcConstraint> _BenchmarkValues = new List<IfcConstraint>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLogicalOperatorEnum? _LogicalAggregator;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcObjectiveEnum _ObjectiveQualifier;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedQualifier;
	
	
		public IfcObjective()
		{
		}
	
		public IfcObjective(IfcLabel __Name, IfcText? __Description, IfcConstraintEnum __ConstraintGrade, IfcLabel? __ConstraintSource, IfcActorSelect __CreatingActor, IfcDateTime? __CreationTime, IfcLabel? __UserDefinedGrade, IfcConstraint[] __BenchmarkValues, IfcLogicalOperatorEnum? __LogicalAggregator, IfcObjectiveEnum __ObjectiveQualifier, IfcLabel? __UserDefinedQualifier)
			: base(__Name, __Description, __ConstraintGrade, __ConstraintSource, __CreatingActor, __CreationTime, __UserDefinedGrade)
		{
			this._BenchmarkValues = new List<IfcConstraint>(__BenchmarkValues);
			this._LogicalAggregator = __LogicalAggregator;
			this._ObjectiveQualifier = __ObjectiveQualifier;
			this._UserDefinedQualifier = __UserDefinedQualifier;
		}
	
		[Description("A list of nested constraints.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC2X4 CHANGE&" +
	    "nbsp; Modified to be a LIST of nested constraints, which replaces the former <i>" +
	    "IfcConstraintAggregationRelationship</i>.</blockquote>")]
		public IList<IfcConstraint> BenchmarkValues { get { return this._BenchmarkValues; } }
	
		[Description(@"Enumeration that identifies the logical type of aggregation for the benchmark metrics.
	
	<blockquote class=""change-ifc2x4"">IFC2X4 CHANGE&nbsp; This attribute replaces replaces the former <i>ResultValues</i> attribute and indicates the aggregation behavior formerly defined at <i>IfcConstraintAggregationRelationship</i>.</blockquote>")]
		public IfcLogicalOperatorEnum? LogicalAggregator { get { return this._LogicalAggregator; } set { this._LogicalAggregator = value;} }
	
		[Description("Enumeration that qualifies the type of objective constraint.\r\n")]
		public IfcObjectiveEnum ObjectiveQualifier { get { return this._ObjectiveQualifier; } set { this._ObjectiveQualifier = value;} }
	
		[Description("A user defined value that qualifies the type of objective constraint when Objecti" +
	    "veQualifier attribute of type <em>IfcObjectiveEnum</em> has value USERDEFINED.")]
		public IfcLabel? UserDefinedQualifier { get { return this._UserDefinedQualifier; } set { this._UserDefinedQualifier = value;} }
	
	
	}
	
}

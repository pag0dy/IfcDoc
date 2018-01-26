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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcFacilitiesMgmtDomain
{
	[Guid("eba22b2c-f893-4c98-8335-f0d8e1a3c556")]
	public partial class IfcConditionCriterion : IfcControl
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcConditionCriterionSelect _Criterion;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcDateTimeSelect _CriterionDateTime;
	
	
		public IfcConditionCriterion()
		{
		}
	
		public IfcConditionCriterion(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcConditionCriterionSelect __Criterion, IfcDateTimeSelect __CriterionDateTime)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._Criterion = __Criterion;
			this._CriterionDateTime = __CriterionDateTime;
		}
	
		[Description("The measured or assessed value of a criterion.")]
		public IfcConditionCriterionSelect Criterion { get { return this._Criterion; } set { this._Criterion = value;} }
	
		[Description("The time and/or date at which the criterion is determined.")]
		public IfcDateTimeSelect CriterionDateTime { get { return this._CriterionDateTime; } set { this._CriterionDateTime = value;} }
	
	
	}
	
}

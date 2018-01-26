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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("1802d7e1-8d28-4916-80dd-a5f0a21f588b")]
	public partial class IfcWorkPlan : IfcWorkControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcWorkPlanTypeEnum? _PredefinedType;
	
	
		public IfcWorkPlan()
		{
		}
	
		public IfcWorkPlan(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcDateTime __CreationDate, IfcPerson[] __Creators, IfcLabel? __Purpose, IfcDuration? __Duration, IfcDuration? __TotalFloat, IfcDateTime __StartTime, IfcDateTime? __FinishTime, IfcWorkPlanTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification, __CreationDate, __Creators, __Purpose, __Duration, __TotalFloat, __StartTime, __FinishTime)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("    Identifies the predefined types of a work plan from which \r\n    the type requ" +
	    "ired may be set.")]
		public IfcWorkPlanTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}

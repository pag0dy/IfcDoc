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
	[Guid("c588cec2-bd4d-4fad-95b3-886c02ea6ad1")]
	public partial class IfcWorkPlan : IfcWorkControl
	{
	
		public IfcWorkPlan()
		{
		}
	
		public IfcWorkPlan(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __Identifier, IfcDateTimeSelect __CreationDate, IfcPerson[] __Creators, IfcLabel? __Purpose, IfcTimeMeasure? __Duration, IfcTimeMeasure? __TotalFloat, IfcDateTimeSelect __StartTime, IfcDateTimeSelect __FinishTime, IfcWorkControlTypeEnum? __WorkControlType, IfcLabel? __UserDefinedControlType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identifier, __CreationDate, __Creators, __Purpose, __Duration, __TotalFloat, __StartTime, __FinishTime, __WorkControlType, __UserDefinedControlType)
		{
		}
	
	
	}
	
}

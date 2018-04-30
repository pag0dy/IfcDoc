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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	public abstract partial class IfcWorkControl : IfcControl
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Identifier of the work plan, given by user.  ")]
		[Required()]
		public IfcIdentifier Identifier { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The date that the plan is created.")]
		[Required()]
		public IfcDateTimeSelect CreationDate { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The authors of the work plan.")]
		[MinLength(1)]
		public ISet<IfcPerson> Creators { get; protected set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("A description of the purpose of the work schedule.")]
		public IfcLabel? Purpose { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The total duration of the entire work schedule.")]
		public IfcTimeMeasure? Duration { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("The total time float of the entire work schedule.")]
		public IfcTimeMeasure? TotalFloat { get; set; }
	
		[DataMember(Order = 6)] 
		[Description("The start time of the schedule.")]
		[Required()]
		public IfcDateTimeSelect StartTime { get; set; }
	
		[DataMember(Order = 7)] 
		[Description("The finish time of the schedule.")]
		public IfcDateTimeSelect FinishTime { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("Predefined work control types from which that required may be set. ")]
		public IfcWorkControlTypeEnum? WorkControlType { get; set; }
	
		[DataMember(Order = 9)] 
		[XmlAttribute]
		[Description("A user defined work control type.")]
		public IfcLabel? UserDefinedControlType { get; set; }
	
	
		protected IfcWorkControl(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __Identifier, IfcDateTimeSelect __CreationDate, IfcPerson[] __Creators, IfcLabel? __Purpose, IfcTimeMeasure? __Duration, IfcTimeMeasure? __TotalFloat, IfcDateTimeSelect __StartTime, IfcDateTimeSelect __FinishTime, IfcWorkControlTypeEnum? __WorkControlType, IfcLabel? __UserDefinedControlType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.Identifier = __Identifier;
			this.CreationDate = __CreationDate;
			this.Creators = new HashSet<IfcPerson>(__Creators);
			this.Purpose = __Purpose;
			this.Duration = __Duration;
			this.TotalFloat = __TotalFloat;
			this.StartTime = __StartTime;
			this.FinishTime = __FinishTime;
			this.WorkControlType = __WorkControlType;
			this.UserDefinedControlType = __UserDefinedControlType;
		}
	
	
	}
	
}

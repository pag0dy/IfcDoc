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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	public partial class IfcScheduleTimeControl : IfcControl
	{
		[DataMember(Order = 0)] 
		[Description("The date on which a task is actually started.     NOTE: The scheduled start date must be greater than or equal to the earliest start date. No constraint is applied to the actual start date with respect to the scheduled start date since a task may be started earlier than had originally been scheduled if circumstances allow.")]
		public IfcDateTimeSelect ActualStart { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The earliest date on which a task can be started.")]
		public IfcDateTimeSelect EarlyStart { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The latest date on which a task can be started.")]
		public IfcDateTimeSelect LateStart { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The date on which a task is scheduled to be started.  NOTE: The scheduled start date must be greater than or equal to the earliest start date.")]
		public IfcDateTimeSelect ScheduleStart { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The date on which a task is actually finished.")]
		public IfcDateTimeSelect ActualFinish { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("The earliest date on which a task can be finished.")]
		public IfcDateTimeSelect EarlyFinish { get; set; }
	
		[DataMember(Order = 6)] 
		[Description("The latest date on which a task can be finished.")]
		public IfcDateTimeSelect LateFinish { get; set; }
	
		[DataMember(Order = 7)] 
		[Description("The date on which a task is scheduled to be finished.   NOTE: The scheduled finish date must be greater than or equal to the earliest finish date.")]
		public IfcDateTimeSelect ScheduleFinish { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("The amount of time which is scheduled for completion of a task.   NOTE: Scheduled Duration may be calculated as the time from scheduled start date to scheduled finish date.  ")]
		public IfcTimeMeasure? ScheduleDuration { get; set; }
	
		[DataMember(Order = 9)] 
		[XmlAttribute]
		[Description("The actual duration of the task.")]
		public IfcTimeMeasure? ActualDuration { get; set; }
	
		[DataMember(Order = 10)] 
		[XmlAttribute]
		[Description("The amount of time remaining to complete a task.   NOTE: The time remaining in which to complete a task may be determined both for tasks which have not yet started and those which have. Remaining time for a task not yet started has the same value as the scheduled duration. For a task already started, remaining time is calculated as the difference between the scheduled finish and the point of analysis.")]
		public IfcTimeMeasure? RemainingTime { get; set; }
	
		[DataMember(Order = 11)] 
		[XmlAttribute]
		[Description("The amount of time during which the start or finish of a task may be varied without any effect on the overall programme of work.")]
		public IfcTimeMeasure? FreeFloat { get; set; }
	
		[DataMember(Order = 12)] 
		[XmlAttribute]
		[Description("The difference between the duration available to carry out a task and the scheduled duration of the task.   NOTE: Total Float time may be calculated as being the difference between the scheduled duration of a task and the available duration from earliest start to latest finish. Float time may be either positive, zero or negative. Where it is zero or negative, the task becomes critical.")]
		public IfcTimeMeasure? TotalFloat { get; set; }
	
		[DataMember(Order = 13)] 
		[Description("A flag which identifies whether a scheduled task is a critical item within the programme.   NOTE: A task becomes critical when the float time becomes zero or negative.")]
		public Boolean? IsCritical { get; set; }
	
		[DataMember(Order = 14)] 
		[Description("The date or time at which the status of the tasks within the schedule is analyzed.")]
		public IfcDateTimeSelect StatusTime { get; set; }
	
		[DataMember(Order = 15)] 
		[XmlAttribute]
		[Description("The difference between the late start and early start of a task. Start float measures how long an task's start can be delayed and still not have an impact on the overall duration of a schedule.")]
		public IfcTimeMeasure? StartFloat { get; set; }
	
		[DataMember(Order = 16)] 
		[XmlAttribute]
		[Description("The difference between the late finish and early finish of a task. Finish float measures how long an task's finish can be delayed and still not have an impact on the overall duration of a schedule.")]
		public IfcTimeMeasure? FinishFloat { get; set; }
	
		[DataMember(Order = 17)] 
		[XmlAttribute]
		[Description("The extent of completion expressed as a ratio or percentage.")]
		public IfcPositiveRatioMeasure? Completion { get; set; }
	
		[InverseProperty("TimeForTask")] 
		[Description("The assigned schedule time control in the relationship.")]
		public IfcRelAssignsTasks ScheduleTimeControlAssigned { get; set; }
	
	
		public IfcScheduleTimeControl(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcDateTimeSelect __ActualStart, IfcDateTimeSelect __EarlyStart, IfcDateTimeSelect __LateStart, IfcDateTimeSelect __ScheduleStart, IfcDateTimeSelect __ActualFinish, IfcDateTimeSelect __EarlyFinish, IfcDateTimeSelect __LateFinish, IfcDateTimeSelect __ScheduleFinish, IfcTimeMeasure? __ScheduleDuration, IfcTimeMeasure? __ActualDuration, IfcTimeMeasure? __RemainingTime, IfcTimeMeasure? __FreeFloat, IfcTimeMeasure? __TotalFloat, Boolean? __IsCritical, IfcDateTimeSelect __StatusTime, IfcTimeMeasure? __StartFloat, IfcTimeMeasure? __FinishFloat, IfcPositiveRatioMeasure? __Completion)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.ActualStart = __ActualStart;
			this.EarlyStart = __EarlyStart;
			this.LateStart = __LateStart;
			this.ScheduleStart = __ScheduleStart;
			this.ActualFinish = __ActualFinish;
			this.EarlyFinish = __EarlyFinish;
			this.LateFinish = __LateFinish;
			this.ScheduleFinish = __ScheduleFinish;
			this.ScheduleDuration = __ScheduleDuration;
			this.ActualDuration = __ActualDuration;
			this.RemainingTime = __RemainingTime;
			this.FreeFloat = __FreeFloat;
			this.TotalFloat = __TotalFloat;
			this.IsCritical = __IsCritical;
			this.StatusTime = __StatusTime;
			this.StartFloat = __StartFloat;
			this.FinishFloat = __FinishFloat;
			this.Completion = __Completion;
		}
	
	
	}
	
}

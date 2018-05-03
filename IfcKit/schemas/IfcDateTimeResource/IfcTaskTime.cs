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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	public partial class IfcTaskTime : IfcSchedulingTime
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Enables to specify the type of duration values for <em>ScheduleDuration</em>, <em>ActualDuration</em> and <em>RemainingTime</em>. The duration type is either work time or elapsed time.")]
		public IfcTaskDurationEnum? DurationType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The amount of time which is scheduled for completion of a task. The value might be measured or somehow calculated, which is defined by  <em>ScheduleDataOrigin</em>. The value is either given as elapsed time or work time, which is defined by <em>DurationType</em>.    <blockquote class=\"note\">NOTE&nbsp; Scheduled Duration may be calculated as the time from scheduled start date to scheduled finish date.</blockquote>  ")]
		public IfcDuration? ScheduleDuration { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The date on which a task is scheduled to be started. The value might be measured or somehow calculated, which is defined by  <em>ScheduleDataOrigin</em>.  <blockquote class=\"note\">NOTE&nbsp;  The scheduled start date must be greater than or equal to the earliest start date.</blockquote>")]
		public IfcDateTime? ScheduleStart { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The date on which a task is scheduled to be finished. The value might be measured or somehow calculated, which is defined by <em>ScheduleDataOrigin</em>.  <blockquote class=\"note\">NOTE&nbsp;  The scheduled finish date must be greater than or equal to the earliest finish date.</blockquote>")]
		public IfcDateTime? ScheduleFinish { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("     The earliest date on which a task can be started. It is a calculated value.")]
		public IfcDateTime? EarlyStart { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("The earliest date on which a task can be finished. It is a calculated value.")]
		public IfcDateTime? EarlyFinish { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("The latest date on which a task can be started. It is a calculated value.")]
		public IfcDateTime? LateStart { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("The latest date on which a task can be finished. It is a calculated value.")]
		public IfcDateTime? LateFinish { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("The amount of time during which the start or finish of a task may be varied without any effect on the overall programme of work. It is a calculated elapsed time value.")]
		public IfcDuration? FreeFloat { get; set; }
	
		[DataMember(Order = 9)] 
		[XmlAttribute]
		[Description("The difference between the duration available to carry out a task and the scheduled duration of the task. It is a calculated elapsed time value.  <blockquote class=\"note\">NOTE&nbsp;  Total Float time may be calculated as being the difference between the scheduled duration of a task and the available duration from earliest start to latest finish. Float time may be either positive, zero or negative. Where it is zero or negative, the task becomes critical.</blockquote>")]
		public IfcDuration? TotalFloat { get; set; }
	
		[DataMember(Order = 10)] 
		[XmlAttribute]
		[Description("A flag which identifies whether a scheduled task is a critical item within the programme.  <blockquote class=\"note\">NOTE&nbsp;  A task becomes critical when the float time becomes zero or negative.</blockquote>")]
		public IfcBoolean? IsCritical { get; set; }
	
		[DataMember(Order = 11)] 
		[XmlAttribute]
		[Description("The date or time at which the status of the tasks within the schedule is analyzed.")]
		public IfcDateTime? StatusTime { get; set; }
	
		[DataMember(Order = 12)] 
		[XmlAttribute]
		[Description("The actual duration of the task. It is a measured value. The value is either given as elapsed time or work time, which is defined by <em>DurationType</em>.")]
		public IfcDuration? ActualDuration { get; set; }
	
		[DataMember(Order = 13)] 
		[XmlAttribute]
		[Description("The date on which a task is actually started. It is a measured value.  <blockquote class=\"note\">NOTE&nbsp;  The scheduled start date must be greater than or equal to the earliest start date. No constraint is applied to the actual start date with respect to the scheduled start date since a task may be started earlier than had originally been scheduled if circumstances allow.</blockquote>")]
		public IfcDateTime? ActualStart { get; set; }
	
		[DataMember(Order = 14)] 
		[XmlAttribute]
		[Description("The date on which a task is actually finished.")]
		public IfcDateTime? ActualFinish { get; set; }
	
		[DataMember(Order = 15)] 
		[XmlAttribute]
		[Description("The amount of time remaining to complete a task. It is a predicted value. The value is either given as elapsed time or work time, which is defined by <em>DurationType</em>.  <blockquote class=\"note\">NOTE&nbsp; The time remaining in which to complete a task may be determined both for tasks which have not yet started and those which have. Remaining time for a task not yet started has the same value as the scheduled duration. For a task already started, remaining time is calculated as the difference between the scheduled finish and the point of analysis.</blockquote>")]
		public IfcDuration? RemainingTime { get; set; }
	
		[DataMember(Order = 16)] 
		[XmlAttribute]
		[Description("The extent of completion expressed as a ratio or percentage. It is a measured value.")]
		public IfcPositiveRatioMeasure? Completion { get; set; }
	
	
		public IfcTaskTime(IfcLabel? __Name, IfcDataOriginEnum? __DataOrigin, IfcLabel? __UserDefinedDataOrigin, IfcTaskDurationEnum? __DurationType, IfcDuration? __ScheduleDuration, IfcDateTime? __ScheduleStart, IfcDateTime? __ScheduleFinish, IfcDateTime? __EarlyStart, IfcDateTime? __EarlyFinish, IfcDateTime? __LateStart, IfcDateTime? __LateFinish, IfcDuration? __FreeFloat, IfcDuration? __TotalFloat, IfcBoolean? __IsCritical, IfcDateTime? __StatusTime, IfcDuration? __ActualDuration, IfcDateTime? __ActualStart, IfcDateTime? __ActualFinish, IfcDuration? __RemainingTime, IfcPositiveRatioMeasure? __Completion)
			: base(__Name, __DataOrigin, __UserDefinedDataOrigin)
		{
			this.DurationType = __DurationType;
			this.ScheduleDuration = __ScheduleDuration;
			this.ScheduleStart = __ScheduleStart;
			this.ScheduleFinish = __ScheduleFinish;
			this.EarlyStart = __EarlyStart;
			this.EarlyFinish = __EarlyFinish;
			this.LateStart = __LateStart;
			this.LateFinish = __LateFinish;
			this.FreeFloat = __FreeFloat;
			this.TotalFloat = __TotalFloat;
			this.IsCritical = __IsCritical;
			this.StatusTime = __StatusTime;
			this.ActualDuration = __ActualDuration;
			this.ActualStart = __ActualStart;
			this.ActualFinish = __ActualFinish;
			this.RemainingTime = __RemainingTime;
			this.Completion = __Completion;
		}
	
	
	}
	
}

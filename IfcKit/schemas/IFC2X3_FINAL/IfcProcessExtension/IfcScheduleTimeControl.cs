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

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("097e2041-f37b-414a-a1f6-bb1420482530")]
	public partial class IfcScheduleTimeControl : IfcControl
	{
		[DataMember(Order=0)] 
		IfcDateTimeSelect _ActualStart;
	
		[DataMember(Order=1)] 
		IfcDateTimeSelect _EarlyStart;
	
		[DataMember(Order=2)] 
		IfcDateTimeSelect _LateStart;
	
		[DataMember(Order=3)] 
		IfcDateTimeSelect _ScheduleStart;
	
		[DataMember(Order=4)] 
		IfcDateTimeSelect _ActualFinish;
	
		[DataMember(Order=5)] 
		IfcDateTimeSelect _EarlyFinish;
	
		[DataMember(Order=6)] 
		IfcDateTimeSelect _LateFinish;
	
		[DataMember(Order=7)] 
		IfcDateTimeSelect _ScheduleFinish;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcTimeMeasure? _ScheduleDuration;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		IfcTimeMeasure? _ActualDuration;
	
		[DataMember(Order=10)] 
		[XmlAttribute]
		IfcTimeMeasure? _RemainingTime;
	
		[DataMember(Order=11)] 
		[XmlAttribute]
		IfcTimeMeasure? _FreeFloat;
	
		[DataMember(Order=12)] 
		[XmlAttribute]
		IfcTimeMeasure? _TotalFloat;
	
		[DataMember(Order=13)] 
		Boolean? _IsCritical;
	
		[DataMember(Order=14)] 
		IfcDateTimeSelect _StatusTime;
	
		[DataMember(Order=15)] 
		[XmlAttribute]
		IfcTimeMeasure? _StartFloat;
	
		[DataMember(Order=16)] 
		[XmlAttribute]
		IfcTimeMeasure? _FinishFloat;
	
		[DataMember(Order=17)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _Completion;
	
		[InverseProperty("TimeForTask")] 
		IfcRelAssignsTasks _ScheduleTimeControlAssigned;
	
	
		public IfcScheduleTimeControl()
		{
		}
	
		public IfcScheduleTimeControl(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcDateTimeSelect __ActualStart, IfcDateTimeSelect __EarlyStart, IfcDateTimeSelect __LateStart, IfcDateTimeSelect __ScheduleStart, IfcDateTimeSelect __ActualFinish, IfcDateTimeSelect __EarlyFinish, IfcDateTimeSelect __LateFinish, IfcDateTimeSelect __ScheduleFinish, IfcTimeMeasure? __ScheduleDuration, IfcTimeMeasure? __ActualDuration, IfcTimeMeasure? __RemainingTime, IfcTimeMeasure? __FreeFloat, IfcTimeMeasure? __TotalFloat, Boolean? __IsCritical, IfcDateTimeSelect __StatusTime, IfcTimeMeasure? __StartFloat, IfcTimeMeasure? __FinishFloat, IfcPositiveRatioMeasure? __Completion)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._ActualStart = __ActualStart;
			this._EarlyStart = __EarlyStart;
			this._LateStart = __LateStart;
			this._ScheduleStart = __ScheduleStart;
			this._ActualFinish = __ActualFinish;
			this._EarlyFinish = __EarlyFinish;
			this._LateFinish = __LateFinish;
			this._ScheduleFinish = __ScheduleFinish;
			this._ScheduleDuration = __ScheduleDuration;
			this._ActualDuration = __ActualDuration;
			this._RemainingTime = __RemainingTime;
			this._FreeFloat = __FreeFloat;
			this._TotalFloat = __TotalFloat;
			this._IsCritical = __IsCritical;
			this._StatusTime = __StatusTime;
			this._StartFloat = __StartFloat;
			this._FinishFloat = __FinishFloat;
			this._Completion = __Completion;
		}
	
		[Description(@"The date on which a task is actually started. 
	
	NOTE: The scheduled start date must be greater than or equal to the earliest start date. No constraint is applied to the actual start date with respect to the scheduled start date since a task may be started earlier than had originally been scheduled if circumstances allow.")]
		public IfcDateTimeSelect ActualStart { get { return this._ActualStart; } set { this._ActualStart = value;} }
	
		[Description("The earliest date on which a task can be started.")]
		public IfcDateTimeSelect EarlyStart { get { return this._EarlyStart; } set { this._EarlyStart = value;} }
	
		[Description("The latest date on which a task can be started.")]
		public IfcDateTimeSelect LateStart { get { return this._LateStart; } set { this._LateStart = value;} }
	
		[Description("The date on which a task is scheduled to be started.\r\nNOTE: The scheduled start d" +
	    "ate must be greater than or equal to the earliest start date.")]
		public IfcDateTimeSelect ScheduleStart { get { return this._ScheduleStart; } set { this._ScheduleStart = value;} }
	
		[Description("The date on which a task is actually finished.")]
		public IfcDateTimeSelect ActualFinish { get { return this._ActualFinish; } set { this._ActualFinish = value;} }
	
		[Description("The earliest date on which a task can be finished.")]
		public IfcDateTimeSelect EarlyFinish { get { return this._EarlyFinish; } set { this._EarlyFinish = value;} }
	
		[Description("The latest date on which a task can be finished.")]
		public IfcDateTimeSelect LateFinish { get { return this._LateFinish; } set { this._LateFinish = value;} }
	
		[Description("The date on which a task is scheduled to be finished. \r\nNOTE: The scheduled finis" +
	    "h date must be greater than or equal to the earliest finish date.")]
		public IfcDateTimeSelect ScheduleFinish { get { return this._ScheduleFinish; } set { this._ScheduleFinish = value;} }
	
		[Description("The amount of time which is scheduled for completion of a task. \r\nNOTE: Scheduled" +
	    " Duration may be calculated as the time from scheduled start date to scheduled f" +
	    "inish date.\r\n")]
		public IfcTimeMeasure? ScheduleDuration { get { return this._ScheduleDuration; } set { this._ScheduleDuration = value;} }
	
		[Description("The actual duration of the task.")]
		public IfcTimeMeasure? ActualDuration { get { return this._ActualDuration; } set { this._ActualDuration = value;} }
	
		[Description(@"The amount of time remaining to complete a task. 
	NOTE: The time remaining in which to complete a task may be determined both for tasks which have not yet started and those which have. Remaining time for a task not yet started has the same value as the scheduled duration. For a task already started, remaining time is calculated as the difference between the scheduled finish and the point of analysis.")]
		public IfcTimeMeasure? RemainingTime { get { return this._RemainingTime; } set { this._RemainingTime = value;} }
	
		[Description("The amount of time during which the start or finish of a task may be varied witho" +
	    "ut any effect on the overall programme of work.")]
		public IfcTimeMeasure? FreeFloat { get { return this._FreeFloat; } set { this._FreeFloat = value;} }
	
		[Description(@"The difference between the duration available to carry out a task and the scheduled duration of the task. 
	NOTE: Total Float time may be calculated as being the difference between the scheduled duration of a task and the available duration from earliest start to latest finish. Float time may be either positive, zero or negative. Where it is zero or negative, the task becomes critical.")]
		public IfcTimeMeasure? TotalFloat { get { return this._TotalFloat; } set { this._TotalFloat = value;} }
	
		[Description("A flag which identifies whether a scheduled task is a critical item within the pr" +
	    "ogramme. \r\nNOTE: A task becomes critical when the float time becomes zero or neg" +
	    "ative.")]
		public Boolean? IsCritical { get { return this._IsCritical; } set { this._IsCritical = value;} }
	
		[Description("The date or time at which the status of the tasks within the schedule is analyzed" +
	    ".")]
		public IfcDateTimeSelect StatusTime { get { return this._StatusTime; } set { this._StatusTime = value;} }
	
		[Description("The difference between the late start and early start of a task. Start float meas" +
	    "ures how long an task\'s start can be delayed and still not have an impact on the" +
	    " overall duration of a schedule.")]
		public IfcTimeMeasure? StartFloat { get { return this._StartFloat; } set { this._StartFloat = value;} }
	
		[Description("The difference between the late finish and early finish of a task. Finish float m" +
	    "easures how long an task\'s finish can be delayed and still not have an impact on" +
	    " the overall duration of a schedule.")]
		public IfcTimeMeasure? FinishFloat { get { return this._FinishFloat; } set { this._FinishFloat = value;} }
	
		[Description("The extent of completion expressed as a ratio or percentage.")]
		public IfcPositiveRatioMeasure? Completion { get { return this._Completion; } set { this._Completion = value;} }
	
		[Description("The assigned schedule time control in the relationship.")]
		public IfcRelAssignsTasks ScheduleTimeControlAssigned { get { return this._ScheduleTimeControlAssigned; } set { this._ScheduleTimeControlAssigned = value;} }
	
	
	}
	
}

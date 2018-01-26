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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("4eee487b-9f5a-4135-9327-1e972cc6124f")]
	public partial class IfcTaskTime : IfcSchedulingTime
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcTaskDurationEnum? _DurationType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcDuration? _ScheduleDuration;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcDateTime? _ScheduleStart;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcDateTime? _ScheduleFinish;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcDateTime? _EarlyStart;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcDateTime? _EarlyFinish;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcDateTime? _LateStart;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcDateTime? _LateFinish;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcDuration? _FreeFloat;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		IfcDuration? _TotalFloat;
	
		[DataMember(Order=10)] 
		[XmlAttribute]
		IfcBoolean? _IsCritical;
	
		[DataMember(Order=11)] 
		[XmlAttribute]
		IfcDateTime? _StatusTime;
	
		[DataMember(Order=12)] 
		[XmlAttribute]
		IfcDuration? _ActualDuration;
	
		[DataMember(Order=13)] 
		[XmlAttribute]
		IfcDateTime? _ActualStart;
	
		[DataMember(Order=14)] 
		[XmlAttribute]
		IfcDateTime? _ActualFinish;
	
		[DataMember(Order=15)] 
		[XmlAttribute]
		IfcDuration? _RemainingTime;
	
		[DataMember(Order=16)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _Completion;
	
	
		public IfcTaskTime()
		{
		}
	
		public IfcTaskTime(IfcLabel? __Name, IfcDataOriginEnum? __DataOrigin, IfcLabel? __UserDefinedDataOrigin, IfcTaskDurationEnum? __DurationType, IfcDuration? __ScheduleDuration, IfcDateTime? __ScheduleStart, IfcDateTime? __ScheduleFinish, IfcDateTime? __EarlyStart, IfcDateTime? __EarlyFinish, IfcDateTime? __LateStart, IfcDateTime? __LateFinish, IfcDuration? __FreeFloat, IfcDuration? __TotalFloat, IfcBoolean? __IsCritical, IfcDateTime? __StatusTime, IfcDuration? __ActualDuration, IfcDateTime? __ActualStart, IfcDateTime? __ActualFinish, IfcDuration? __RemainingTime, IfcPositiveRatioMeasure? __Completion)
			: base(__Name, __DataOrigin, __UserDefinedDataOrigin)
		{
			this._DurationType = __DurationType;
			this._ScheduleDuration = __ScheduleDuration;
			this._ScheduleStart = __ScheduleStart;
			this._ScheduleFinish = __ScheduleFinish;
			this._EarlyStart = __EarlyStart;
			this._EarlyFinish = __EarlyFinish;
			this._LateStart = __LateStart;
			this._LateFinish = __LateFinish;
			this._FreeFloat = __FreeFloat;
			this._TotalFloat = __TotalFloat;
			this._IsCritical = __IsCritical;
			this._StatusTime = __StatusTime;
			this._ActualDuration = __ActualDuration;
			this._ActualStart = __ActualStart;
			this._ActualFinish = __ActualFinish;
			this._RemainingTime = __RemainingTime;
			this._Completion = __Completion;
		}
	
		[Description("Enables to specify the type of duration values for <em>ScheduleDuration</em>, <em" +
	    ">ActualDuration</em> and <em>RemainingTime</em>. The duration type is either wor" +
	    "k time or elapsed time.")]
		public IfcTaskDurationEnum? DurationType { get { return this._DurationType; } set { this._DurationType = value;} }
	
		[Description(@"The amount of time which is scheduled for completion of a task. The value might be measured or somehow calculated, which is defined by
	<em>ScheduleDataOrigin</em>. The value is either given as elapsed time or work time, which is defined by <em>DurationType</em>.
	
	<blockquote class=""note"">NOTE&nbsp; Scheduled Duration may be calculated as the time from scheduled start date to scheduled finish date.</blockquote>
	")]
		public IfcDuration? ScheduleDuration { get { return this._ScheduleDuration; } set { this._ScheduleDuration = value;} }
	
		[Description(@"The date on which a task is scheduled to be started. The value might be measured or somehow calculated, which is defined by
	<em>ScheduleDataOrigin</em>.
	<blockquote class=""note"">NOTE&nbsp;  The scheduled start date must be greater than or equal to the earliest start date.</blockquote>")]
		public IfcDateTime? ScheduleStart { get { return this._ScheduleStart; } set { this._ScheduleStart = value;} }
	
		[Description(@"The date on which a task is scheduled to be finished. The value might be measured or somehow calculated, which is defined by <em>ScheduleDataOrigin</em>.
	<blockquote class=""note"">NOTE&nbsp;  The scheduled finish date must be greater than or equal to the earliest finish date.</blockquote>")]
		public IfcDateTime? ScheduleFinish { get { return this._ScheduleFinish; } set { this._ScheduleFinish = value;} }
	
		[Description("     The earliest date on which a task can be started. It is a calculated value.")]
		public IfcDateTime? EarlyStart { get { return this._EarlyStart; } set { this._EarlyStart = value;} }
	
		[Description("The earliest date on which a task can be finished. It is a calculated value.")]
		public IfcDateTime? EarlyFinish { get { return this._EarlyFinish; } set { this._EarlyFinish = value;} }
	
		[Description("The latest date on which a task can be started. It is a calculated value.")]
		public IfcDateTime? LateStart { get { return this._LateStart; } set { this._LateStart = value;} }
	
		[Description("The latest date on which a task can be finished. It is a calculated value.")]
		public IfcDateTime? LateFinish { get { return this._LateFinish; } set { this._LateFinish = value;} }
	
		[Description("The amount of time during which the start or finish of a task may be varied witho" +
	    "ut any effect on the overall programme of work. It is a calculated elapsed time " +
	    "value.")]
		public IfcDuration? FreeFloat { get { return this._FreeFloat; } set { this._FreeFloat = value;} }
	
		[Description(@"The difference between the duration available to carry out a task and the scheduled duration of the task. It is a calculated elapsed time value.
	<blockquote class=""note"">NOTE&nbsp;  Total Float time may be calculated as being the difference between the scheduled duration of a task and the available duration from earliest start to latest finish. Float time may be either positive, zero or negative. Where it is zero or negative, the task becomes critical.</blockquote>")]
		public IfcDuration? TotalFloat { get { return this._TotalFloat; } set { this._TotalFloat = value;} }
	
		[Description("A flag which identifies whether a scheduled task is a critical item within the pr" +
	    "ogramme.\r\n<blockquote class=\"note\">NOTE&nbsp;  A task becomes critical when the " +
	    "float time becomes zero or negative.</blockquote>")]
		public IfcBoolean? IsCritical { get { return this._IsCritical; } set { this._IsCritical = value;} }
	
		[Description("The date or time at which the status of the tasks within the schedule is analyzed" +
	    ".")]
		public IfcDateTime? StatusTime { get { return this._StatusTime; } set { this._StatusTime = value;} }
	
		[Description("The actual duration of the task. It is a measured value. The value is either give" +
	    "n as elapsed time or work time, which is defined by <em>DurationType</em>.")]
		public IfcDuration? ActualDuration { get { return this._ActualDuration; } set { this._ActualDuration = value;} }
	
		[Description(@"The date on which a task is actually started. It is a measured value.
	<blockquote class=""note"">NOTE&nbsp;  The scheduled start date must be greater than or equal to the earliest start date. No constraint is applied to the actual start date with respect to the scheduled start date since a task may be started earlier than had originally been scheduled if circumstances allow.</blockquote>")]
		public IfcDateTime? ActualStart { get { return this._ActualStart; } set { this._ActualStart = value;} }
	
		[Description("The date on which a task is actually finished.")]
		public IfcDateTime? ActualFinish { get { return this._ActualFinish; } set { this._ActualFinish = value;} }
	
		[Description(@"The amount of time remaining to complete a task. It is a predicted value. The value is either given as elapsed time or work time, which is defined by <em>DurationType</em>.
	<blockquote class=""note"">NOTE&nbsp; The time remaining in which to complete a task may be determined both for tasks which have not yet started and those which have. Remaining time for a task not yet started has the same value as the scheduled duration. For a task already started, remaining time is calculated as the difference between the scheduled finish and the point of analysis.</blockquote>")]
		public IfcDuration? RemainingTime { get { return this._RemainingTime; } set { this._RemainingTime = value;} }
	
		[Description("The extent of completion expressed as a ratio or percentage. It is a measured val" +
	    "ue.")]
		public IfcPositiveRatioMeasure? Completion { get { return this._Completion; } set { this._Completion = value;} }
	
	
	}
	
}

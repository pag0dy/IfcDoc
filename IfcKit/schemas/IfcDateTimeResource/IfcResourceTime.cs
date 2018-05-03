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
	public partial class IfcResourceTime : IfcSchedulingTime
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Indicates the total work (e.g. person-hours) allocated to the task on behalf of the resource.   Note: this is not necessarily the same as the task duration (IfcTaskTime.ScheduleDuration); it may vary according to the resource usage ratio and other resources assigned to the task.")]
		public IfcDuration? ScheduleWork { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Indicates the amount of the resource used concurrently. For example, 100% means 1 worker, 300% means 3 workers, 50% means half of 1 worker's time for scenarios where multitasking is feasible. If not provided, then the usage ratio is considered to be 100%. ")]
		public IfcPositiveRatioMeasure? ScheduleUsage { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Indicates the time when the resource is scheduled to start working.")]
		public IfcDateTime? ScheduleStart { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Indicates the time when the resource is scheduled to finish working. ")]
		public IfcDateTime? ScheduleFinish { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Indicates how a resource should be leveled over time by adjusting the resource usage according to a specified curve.  Standard values include: 'Flat', 'BackLoaded', 'FrontLoaded', 'DoublePeak', 'EarlyPeak', 'LatePeak', 'Bell', and 'Turtle'.  Custom values may specify a custom name or formula.")]
		public IfcLabel? ScheduleContour { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Indicates a delay in the ScheduleStart caused by leveling.")]
		public IfcDuration? LevelingDelay { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Indicates that the resource is scheduled in excess of its capacity.")]
		public IfcBoolean? IsOverAllocated { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Indicates the date and time for which status values are applicable; particularly completion, actual, and remaining values.  If values are time-phased (the referencing IfcConstructionResource has associated time series values for attributes), then the status values may be determined from such time-phased data as of the StatusTime.")]
		public IfcDateTime? StatusTime { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("Indicates the actual work performed by the resource as of the StatusTime.")]
		public IfcDuration? ActualWork { get; set; }
	
		[DataMember(Order = 9)] 
		[XmlAttribute]
		[Description("Indicates the actual amount of the resource used concurrently.")]
		public IfcPositiveRatioMeasure? ActualUsage { get; set; }
	
		[DataMember(Order = 10)] 
		[XmlAttribute]
		[Description("Indicates the time when the resource actually started working.")]
		public IfcDateTime? ActualStart { get; set; }
	
		[DataMember(Order = 11)] 
		[XmlAttribute]
		[Description("Indicates the time when the resource actually finished working.")]
		public IfcDateTime? ActualFinish { get; set; }
	
		[DataMember(Order = 12)] 
		[XmlAttribute]
		[Description("Indicates the work remaining to be completed by the resource.")]
		public IfcDuration? RemainingWork { get; set; }
	
		[DataMember(Order = 13)] 
		[XmlAttribute]
		public IfcPositiveRatioMeasure? RemainingUsage { get; set; }
	
		[DataMember(Order = 14)] 
		[XmlAttribute]
		[Description("Indicates the percent completion of this resource.  If the resource is assigned to a task, then indicates completion of the task on behalf of the resource; if the resource is partitioned into sub-allocations, then indicates overall completion of sub-allocations.")]
		public IfcPositiveRatioMeasure? Completion { get; set; }
	
	
		public IfcResourceTime(IfcLabel? __Name, IfcDataOriginEnum? __DataOrigin, IfcLabel? __UserDefinedDataOrigin, IfcDuration? __ScheduleWork, IfcPositiveRatioMeasure? __ScheduleUsage, IfcDateTime? __ScheduleStart, IfcDateTime? __ScheduleFinish, IfcLabel? __ScheduleContour, IfcDuration? __LevelingDelay, IfcBoolean? __IsOverAllocated, IfcDateTime? __StatusTime, IfcDuration? __ActualWork, IfcPositiveRatioMeasure? __ActualUsage, IfcDateTime? __ActualStart, IfcDateTime? __ActualFinish, IfcDuration? __RemainingWork, IfcPositiveRatioMeasure? __RemainingUsage, IfcPositiveRatioMeasure? __Completion)
			: base(__Name, __DataOrigin, __UserDefinedDataOrigin)
		{
			this.ScheduleWork = __ScheduleWork;
			this.ScheduleUsage = __ScheduleUsage;
			this.ScheduleStart = __ScheduleStart;
			this.ScheduleFinish = __ScheduleFinish;
			this.ScheduleContour = __ScheduleContour;
			this.LevelingDelay = __LevelingDelay;
			this.IsOverAllocated = __IsOverAllocated;
			this.StatusTime = __StatusTime;
			this.ActualWork = __ActualWork;
			this.ActualUsage = __ActualUsage;
			this.ActualStart = __ActualStart;
			this.ActualFinish = __ActualFinish;
			this.RemainingWork = __RemainingWork;
			this.RemainingUsage = __RemainingUsage;
			this.Completion = __Completion;
		}
	
	
	}
	
}

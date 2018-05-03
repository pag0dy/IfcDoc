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
	public partial class IfcTaskTimeRecurring : IfcTaskTime
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Required()]
		public IfcRecurrencePattern Recurrence { get; set; }
	
	
		public IfcTaskTimeRecurring(IfcLabel? __Name, IfcDataOriginEnum? __DataOrigin, IfcLabel? __UserDefinedDataOrigin, IfcTaskDurationEnum? __DurationType, IfcDuration? __ScheduleDuration, IfcDateTime? __ScheduleStart, IfcDateTime? __ScheduleFinish, IfcDateTime? __EarlyStart, IfcDateTime? __EarlyFinish, IfcDateTime? __LateStart, IfcDateTime? __LateFinish, IfcDuration? __FreeFloat, IfcDuration? __TotalFloat, IfcBoolean? __IsCritical, IfcDateTime? __StatusTime, IfcDuration? __ActualDuration, IfcDateTime? __ActualStart, IfcDateTime? __ActualFinish, IfcDuration? __RemainingTime, IfcPositiveRatioMeasure? __Completion, IfcRecurrencePattern __Recurrence)
			: base(__Name, __DataOrigin, __UserDefinedDataOrigin, __DurationType, __ScheduleDuration, __ScheduleStart, __ScheduleFinish, __EarlyStart, __EarlyFinish, __LateStart, __LateFinish, __FreeFloat, __TotalFloat, __IsCritical, __StatusTime, __ActualDuration, __ActualStart, __ActualFinish, __RemainingTime, __Completion)
		{
			this.Recurrence = __Recurrence;
		}
	
	
	}
	
}

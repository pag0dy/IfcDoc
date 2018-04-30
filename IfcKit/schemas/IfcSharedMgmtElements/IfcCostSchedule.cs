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

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	public partial class IfcCostSchedule : IfcControl
	{
		[DataMember(Order = 0)] 
		[Description("The identity of the person or organization submitting the cost schedule.")]
		public IfcActorSelect SubmittedBy { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The identity of the person or organization preparing the cost schedule.")]
		public IfcActorSelect PreparedBy { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The date on which the cost schedule was submitted.")]
		public IfcDateTimeSelect SubmittedOn { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The current status of a cost schedule. Examples of status values that might be used for a cost schedule status include:  - PLANNED  - APPROVED  - AGREED  - ISSUED  - STARTED")]
		public IfcLabel? Status { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The actors for whom the cost schedule was prepared.")]
		[MinLength(1)]
		public ISet<IfcActorSelect> TargetUsers { get; protected set; }
	
		[DataMember(Order = 5)] 
		[Description("The date that this cost schedule is updated; this allows tracking the schedule history.")]
		public IfcDateTimeSelect UpdateDate { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("A unique identification assigned to a cost schedule that enables its differentiation from other cost schedules.")]
		[Required()]
		[CustomValidation(typeof(IfcCostSchedule), "Unique")]
		public IfcIdentifier ID { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Predefined types of cost schedule from which that required may be selected.")]
		[Required()]
		public IfcCostScheduleTypeEnum PredefinedType { get; set; }
	
	
		public IfcCostSchedule(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcActorSelect __SubmittedBy, IfcActorSelect __PreparedBy, IfcDateTimeSelect __SubmittedOn, IfcLabel? __Status, IfcActorSelect[] __TargetUsers, IfcDateTimeSelect __UpdateDate, IfcIdentifier __ID, IfcCostScheduleTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.SubmittedBy = __SubmittedBy;
			this.PreparedBy = __PreparedBy;
			this.SubmittedOn = __SubmittedOn;
			this.Status = __Status;
			this.TargetUsers = new HashSet<IfcActorSelect>(__TargetUsers);
			this.UpdateDate = __UpdateDate;
			this.ID = __ID;
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}

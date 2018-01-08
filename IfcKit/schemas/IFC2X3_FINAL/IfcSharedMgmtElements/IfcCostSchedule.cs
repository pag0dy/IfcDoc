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
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	[Guid("288d213e-1d98-4845-8a80-52750f1ef316")]
	public partial class IfcCostSchedule : IfcControl
	{
		[DataMember(Order=0)] 
		IfcActorSelect _SubmittedBy;
	
		[DataMember(Order=1)] 
		IfcActorSelect _PreparedBy;
	
		[DataMember(Order=2)] 
		IfcDateTimeSelect _SubmittedOn;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _Status;
	
		[DataMember(Order=4)] 
		ISet<IfcActorSelect> _TargetUsers = new HashSet<IfcActorSelect>();
	
		[DataMember(Order=5)] 
		IfcDateTimeSelect _UpdateDate;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _ID;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		[Required()]
		IfcCostScheduleTypeEnum _PredefinedType;
	
	
		[Description("The identity of the person or organization submitting the cost schedule.")]
		public IfcActorSelect SubmittedBy { get { return this._SubmittedBy; } set { this._SubmittedBy = value;} }
	
		[Description("The identity of the person or organization preparing the cost schedule.")]
		public IfcActorSelect PreparedBy { get { return this._PreparedBy; } set { this._PreparedBy = value;} }
	
		[Description("The date on which the cost schedule was submitted.")]
		public IfcDateTimeSelect SubmittedOn { get { return this._SubmittedOn; } set { this._SubmittedOn = value;} }
	
		[Description("The current status of a cost schedule. Examples of status values that might be us" +
	    "ed for a cost schedule status include:\r\n- PLANNED\r\n- APPROVED\r\n- AGREED\r\n- ISSUE" +
	    "D\r\n- STARTED")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("The actors for whom the cost schedule was prepared.")]
		public ISet<IfcActorSelect> TargetUsers { get { return this._TargetUsers; } }
	
		[Description("The date that this cost schedule is updated; this allows tracking the schedule hi" +
	    "story.")]
		public IfcDateTimeSelect UpdateDate { get { return this._UpdateDate; } set { this._UpdateDate = value;} }
	
		[Description("A unique identification assigned to a cost schedule that enables its differentiat" +
	    "ion from other cost schedules.")]
		public IfcIdentifier ID { get { return this._ID; } set { this._ID = value;} }
	
		[Description("Predefined types of cost schedule from which that required may be selected.")]
		public IfcCostScheduleTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}

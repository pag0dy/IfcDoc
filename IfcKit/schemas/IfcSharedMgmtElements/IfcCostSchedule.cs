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

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	public partial class IfcCostSchedule : IfcControl
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Predefined generic type for a cost schedule that is specified in an enumeration. There may be a property set given specifically for the predefined types.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been made optional.</blockquote>")]
		public IfcCostScheduleTypeEnum? PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The current status of a cost schedule. Examples of status values that might be used for a cost schedule status include:  <ul>  <li> PLANNED </li>  <li> APPROVED </li>  <li> AGREED </li>  <li> ISSUED </li>  <li> STARTED </li>  </ul>")]
		public IfcLabel? Status { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The date and time on which the cost schedule was submitted.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect.</blockquote>    ")]
		public IfcDateTime? SubmittedOn { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The date and time that this cost schedule is updated; this allows tracking the schedule history.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect.</blockquote>    ")]
		public IfcDateTime? UpdateDate { get; set; }
	
	
		public IfcCostSchedule(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcCostScheduleTypeEnum? __PredefinedType, IfcLabel? __Status, IfcDateTime? __SubmittedOn, IfcDateTime? __UpdateDate)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification)
		{
			this.PredefinedType = __PredefinedType;
			this.Status = __Status;
			this.SubmittedOn = __SubmittedOn;
			this.UpdateDate = __UpdateDate;
		}
	
	
	}
	
}

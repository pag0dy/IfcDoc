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
	public partial class IfcTask : IfcProcess
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("    Current status of the task.      <blockquote class=\"note\">NOTE&nbsp; Particular values for status are not        specified, these should be determined and agreed by local        usage. Examples of possible status values include 'Not Yet        Started', 'Started', 'Completed'.</blockquote>  ")]
		public IfcLabel? Status { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("    The method of work used in carrying out a task.      <blockquote class=\"note\">NOTE&nbsp; This attribute should        not be used if the work method is specified for the        <em>IfcTaskType</em>   </blockquote>")]
		public IfcLabel? WorkMethod { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("    Identifies whether a task is a milestone task (=TRUE) or not      (= FALSE).      <blockquote class=\"note\">NOTE&nbsp; In small project planning applications,        a milestone task may be understood to be a task having no        duration. As such, it represents a singular point in time.</blockquote>")]
		[Required()]
		public IfcBoolean IsMilestone { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("    A value that indicates the relative priority of the task (in      comparison to the priorities of other tasks).")]
		public IfcInteger? Priority { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlElement]
		[Description("    Time related information for the task.      <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Attribute added</blockquote>")]
		public IfcTaskTime TaskTime { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("    Identifies the predefined types of a task from which       the type required may be set.      <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  Attribute added</blockquote>")]
		public IfcTaskTypeEnum? PredefinedType { get; set; }
	
	
		public IfcTask(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcLabel? __Status, IfcLabel? __WorkMethod, IfcBoolean __IsMilestone, IfcInteger? __Priority, IfcTaskTime __TaskTime, IfcTaskTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification, __LongDescription)
		{
			this.Status = __Status;
			this.WorkMethod = __WorkMethod;
			this.IsMilestone = __IsMilestone;
			this.Priority = __Priority;
			this.TaskTime = __TaskTime;
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}

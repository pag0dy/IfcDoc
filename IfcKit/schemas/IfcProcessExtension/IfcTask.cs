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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	public partial class IfcTask : IfcProcess
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("An identifying designation given to a task.")]
		[Required()]
		public IfcIdentifier TaskId { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Current status of the task.  NOTE: Particular values for status are not specified, these should be determined and agreed by local usage. Examples of possible status values include 'Not Yet Started', 'Started', 'Completed'.  ")]
		public IfcLabel? Status { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The method of work used in carrying out a task.")]
		public IfcLabel? WorkMethod { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Identifies whether a task is a milestone task (=TRUE) or not (= FALSE).  NOTE: In small project planning applications, a milestone task may be understood to be a task having no duration. As such, it represents a singular point in time.")]
		[Required()]
		public Boolean IsMilestone { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("A value that indicates the relative priority of the task (in comparison to the priorities of other tasks).")]
		public Int64? Priority { get; set; }
	
	
		public IfcTask(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __TaskId, IfcLabel? __Status, IfcLabel? __WorkMethod, Boolean __IsMilestone, Int64? __Priority)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.TaskId = __TaskId;
			this.Status = __Status;
			this.WorkMethod = __WorkMethod;
			this.IsMilestone = __IsMilestone;
			this.Priority = __Priority;
		}
	
	
	}
	
}

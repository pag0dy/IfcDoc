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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("3187e424-12c3-4090-9929-3f2543090b3f")]
	public partial class IfcTask : IfcProcess
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _TaskId;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Status;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _WorkMethod;
	
		[DataMember(Order=3)] 
		[Required()]
		Boolean _IsMilestone;
	
		[DataMember(Order=4)] 
		Int64? _Priority;
	
	
		public IfcTask()
		{
		}
	
		public IfcTask(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __TaskId, IfcLabel? __Status, IfcLabel? __WorkMethod, Boolean __IsMilestone, Int64? __Priority)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._TaskId = __TaskId;
			this._Status = __Status;
			this._WorkMethod = __WorkMethod;
			this._IsMilestone = __IsMilestone;
			this._Priority = __Priority;
		}
	
		[Description("An identifying designation given to a task.")]
		public IfcIdentifier TaskId { get { return this._TaskId; } set { this._TaskId = value;} }
	
		[Description("Current status of the task.\r\nNOTE: Particular values for status are not specified" +
	    ", these should be determined and agreed by local usage. Examples of possible sta" +
	    "tus values include \'Not Yet Started\', \'Started\', \'Completed\'.\r\n")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("The method of work used in carrying out a task.")]
		public IfcLabel? WorkMethod { get { return this._WorkMethod; } set { this._WorkMethod = value;} }
	
		[Description("Identifies whether a task is a milestone task (=TRUE) or not (= FALSE).\r\nNOTE: In" +
	    " small project planning applications, a milestone task may be understood to be a" +
	    " task having no duration. As such, it represents a singular point in time.")]
		public Boolean IsMilestone { get { return this._IsMilestone; } set { this._IsMilestone = value;} }
	
		[Description("A value that indicates the relative priority of the task (in comparison to the pr" +
	    "iorities of other tasks).")]
		public Int64? Priority { get { return this._Priority; } set { this._Priority = value;} }
	
	
	}
	
}

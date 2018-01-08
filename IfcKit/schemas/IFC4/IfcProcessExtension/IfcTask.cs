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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("1cd0905c-9f60-44f9-9f06-d4cefbc96a5b")]
	public partial class IfcTask : IfcProcess
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Status;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _WorkMethod;
	
		[DataMember(Order=2)] 
		[Required()]
		Boolean _IsMilestone;
	
		[DataMember(Order=3)] 
		Int64? _Priority;
	
		[DataMember(Order=4)] 
		[XmlElement("IfcTaskTime")]
		IfcTaskTime _TaskTime;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcTaskTypeEnum? _PredefinedType;
	
	
		[Description(@"<EPM-HTML>
	    Current status of the task.
	    <blockquote class=""note"">NOTE&nbsp; Particular values for status are not
	      specified, these should be determined and agreed by local
	      usage. Examples of possible status values include 'Not Yet
	      Started', 'Started', 'Completed'.</blockquote>
	</EPM-HTML>
	")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("<EPM-HTML>\r\n    The method of work used in carrying out a task.\r\n    <blockquote " +
	    "class=\"note\">NOTE&nbsp; This attribute should\r\n      not be used if the work met" +
	    "hod is specified for the\r\n      <em>IfcTaskType</em>   </blockquote>\r\n</EPM-HTML" +
	    ">")]
		public IfcLabel? WorkMethod { get { return this._WorkMethod; } set { this._WorkMethod = value;} }
	
		[Description(@"<EPM-HTML>
	    Identifies whether a task is a milestone task (=TRUE) or not
	    (= FALSE).
	    <blockquote class=""note"">NOTE&nbsp; In small project planning applications,
	      a milestone task may be understood to be a task having no
	      duration. As such, it represents a singular point in time.</blockquote>
	</EPM-HTML>")]
		public Boolean IsMilestone { get { return this._IsMilestone; } set { this._IsMilestone = value;} }
	
		[Description("<EPM-HTML>\r\n    A value that indicates the relative priority of the task (in\r\n   " +
	    " comparison to the priorities of other tasks).\r\n</EPM-HTML>")]
		public Int64? Priority { get { return this._Priority; } set { this._Priority = value;} }
	
		[Description("<EPM-HTML>\r\n    Time related information for the task.\r\n    <blockquote class=\"ch" +
	    "ange-ifc2x4\">IFC4 CHANGE Attribute added</blockquote>\r\n</EPM-HTML>")]
		public IfcTaskTime TaskTime { get { return this._TaskTime; } set { this._TaskTime = value;} }
	
		[Description("<EPM-HTML>\r\n    Identifies the predefined types of a task from which \r\n    the ty" +
	    "pe required may be set.\r\n    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  Attr" +
	    "ibute added</blockquote>\r\n</EPM-HTML>")]
		public IfcTaskTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}

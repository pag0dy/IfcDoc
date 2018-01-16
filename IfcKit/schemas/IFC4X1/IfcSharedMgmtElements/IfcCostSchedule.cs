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
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	[Guid("ff373331-377a-4ddd-8781-060d4b4f0828")]
	public partial class IfcCostSchedule : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCostScheduleTypeEnum? _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Status;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcDateTime? _SubmittedOn;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcDateTime? _UpdateDate;
	
	
		[Description("Predefined generic type for a cost schedule that is specified in an enumeration. " +
	    "There may be a property set given specifically for the predefined types.\r\n\r\n<blo" +
	    "ckquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been made optional." +
	    "</blockquote>")]
		public IfcCostScheduleTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("The current status of a cost schedule. Examples of status values that might be us" +
	    "ed for a cost schedule status include:\r\n<ul>\r\n<li> PLANNED </li>\r\n<li> APPROVED " +
	    "</li>\r\n<li> AGREED </li>\r\n<li> ISSUED </li>\r\n<li> STARTED </li>\r\n</ul>")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("The date and time on which the cost schedule was submitted.\r\n<blockquote class=\"c" +
	    "hange-ifc2x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect.</blockquote>  \r\n")]
		public IfcDateTime? SubmittedOn { get { return this._SubmittedOn; } set { this._SubmittedOn = value;} }
	
		[Description("The date and time that this cost schedule is updated; this allows tracking the sc" +
	    "hedule history.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE Type changed from" +
	    " IfcDateTimeSelect.</blockquote>  \r\n")]
		public IfcDateTime? UpdateDate { get { return this._UpdateDate; } set { this._UpdateDate = value;} }
	
	
	}
	
}

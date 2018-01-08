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
	
	
		[Description(@"<EPM-HTML>
	Predefined generic type for a cost schedule that is specified in an enumeration. There may be a property set given specifically for the predefined types.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The attribute has been made optional.</blockquote>
	
	</EPM-HTML>")]
		public IfcCostScheduleTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"<EPM-HTML>
	The current status of a cost schedule. Examples of status values that might be used for a cost schedule status include:
	<ul>
	<li> PLANNED </li>
	<li> APPROVED </li>
	<li> AGREED </li>
	<li> ISSUED </li>
	<li> STARTED </li>
	</ul>
	
	</EPM-HTML>")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("<EPM-HTML> \r\nThe date and time on which the cost schedule was submitted.\r\n<blockq" +
	    "uote class=\"change-ifc2x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect.</blo" +
	    "ckquote> \r\n</EPM-HTML> \r\n")]
		public IfcDateTime? SubmittedOn { get { return this._SubmittedOn; } set { this._SubmittedOn = value;} }
	
		[Description("<EPM-HTML> \r\nThe date and time that this cost schedule is updated; this allows tr" +
	    "acking the schedule history.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE Type" +
	    " changed from IfcDateTimeSelect.</blockquote> \r\n</EPM-HTML> \r\n")]
		public IfcDateTime? UpdateDate { get { return this._UpdateDate; } set { this._UpdateDate = value;} }
	
	
	}
	
}

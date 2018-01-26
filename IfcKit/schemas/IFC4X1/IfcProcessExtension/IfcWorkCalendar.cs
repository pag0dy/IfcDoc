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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("d05923c3-37a8-444a-b811-bf0709bab84f")]
	public partial class IfcWorkCalendar : IfcControl
	{
		[DataMember(Order=0)] 
		[MinLength(1)]
		ISet<IfcWorkTime> _WorkingTimes = new HashSet<IfcWorkTime>();
	
		[DataMember(Order=1)] 
		[MinLength(1)]
		ISet<IfcWorkTime> _ExceptionTimes = new HashSet<IfcWorkTime>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcWorkCalendarTypeEnum? _PredefinedType;
	
	
		public IfcWorkCalendar()
		{
		}
	
		public IfcWorkCalendar(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcWorkTime[] __WorkingTimes, IfcWorkTime[] __ExceptionTimes, IfcWorkCalendarTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification)
		{
			this._WorkingTimes = new HashSet<IfcWorkTime>(__WorkingTimes);
			this._ExceptionTimes = new HashSet<IfcWorkTime>(__ExceptionTimes);
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("    Set of times periods that are regarded as an initial set-up\r\n    of working t" +
	    "imes. Exception times can then further restrict\r\n    these working times.\r\n ")]
		public ISet<IfcWorkTime> WorkingTimes { get { return this._WorkingTimes; } }
	
		[Description("    Set of times periods that define exceptions (non-working\r\n    times) for the " +
	    "given working times including the base\r\n    calendar, if provided.")]
		public ISet<IfcWorkTime> ExceptionTimes { get { return this._ExceptionTimes; } }
	
		[Description("    Identifies the predefined types of a work calendar from which \r\n    the type " +
	    "required may be set.\r\n    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  Attribu" +
	    "te added</blockquote>")]
		public IfcWorkCalendarTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}

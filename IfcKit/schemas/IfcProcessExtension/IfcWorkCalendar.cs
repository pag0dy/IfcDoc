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
	public partial class IfcWorkCalendar : IfcControl
	{
		[DataMember(Order = 0)] 
		[Description("    Set of times periods that are regarded as an initial set-up      of working times. Exception times can then further restrict      these working times.   ")]
		[MinLength(1)]
		public ISet<IfcWorkTime> WorkingTimes { get; protected set; }
	
		[DataMember(Order = 1)] 
		[Description("    Set of times periods that define exceptions (non-working      times) for the given working times including the base      calendar, if provided.")]
		[MinLength(1)]
		public ISet<IfcWorkTime> ExceptionTimes { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("    Identifies the predefined types of a work calendar from which       the type required may be set.      <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  Attribute added</blockquote>")]
		public IfcWorkCalendarTypeEnum? PredefinedType { get; set; }
	
	
		public IfcWorkCalendar(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcWorkTime[] __WorkingTimes, IfcWorkTime[] __ExceptionTimes, IfcWorkCalendarTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification)
		{
			this.WorkingTimes = new HashSet<IfcWorkTime>(__WorkingTimes);
			this.ExceptionTimes = new HashSet<IfcWorkTime>(__ExceptionTimes);
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}

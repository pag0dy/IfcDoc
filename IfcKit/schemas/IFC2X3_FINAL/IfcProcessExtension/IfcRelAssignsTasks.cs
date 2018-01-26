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
	[Guid("23a949da-38bb-4079-bf90-a516830c8a95")]
	public partial class IfcRelAssignsTasks : IfcRelAssignsToControl
	{
		[DataMember(Order=0)] 
		IfcScheduleTimeControl _TimeForTask;
	
	
		public IfcRelAssignsTasks()
		{
		}
	
		public IfcRelAssignsTasks(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcControl __RelatingControl, IfcScheduleTimeControl __TimeForTask)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType, __RelatingControl)
		{
			this._TimeForTask = __TimeForTask;
		}
	
		[Description("Contained object for the time related information for the work schedule element.")]
		public IfcScheduleTimeControl TimeForTask { get { return this._TimeForTask; } set { this._TimeForTask = value;} }
	
	
	}
	
}

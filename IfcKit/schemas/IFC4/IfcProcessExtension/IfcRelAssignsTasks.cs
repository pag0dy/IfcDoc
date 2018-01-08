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
	[Guid("23a949da-38bb-4079-bf90-a516830c8a95")]
	public partial class IfcRelAssignsTasks : IfcRelAssignsToControl
	{
		[DataMember(Order=0)] 
		IfcScheduleTimeControl _TimeForTask;
	
	
		[Description("Contained object for the time related information for the work schedule element.")]
		public IfcScheduleTimeControl TimeForTask { get { return this._TimeForTask; } set { this._TimeForTask = value;} }
	
	
	}
	
}

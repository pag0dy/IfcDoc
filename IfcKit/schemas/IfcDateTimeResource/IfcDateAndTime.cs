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

using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	public partial class IfcDateAndTime :
		BuildingSmart.IFC.IfcDateTimeResource.IfcDateTimeSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order = 0)] 
		[Description("The date element of the date time combination.")]
		[Required()]
		public IfcCalendarDate DateComponent { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The time element of the date time combination.")]
		[Required()]
		public IfcLocalTime TimeComponent { get; set; }
	
	
		public IfcDateAndTime(IfcCalendarDate __DateComponent, IfcLocalTime __TimeComponent)
		{
			this.DateComponent = __DateComponent;
			this.TimeComponent = __TimeComponent;
		}
	
	
	}
	
}

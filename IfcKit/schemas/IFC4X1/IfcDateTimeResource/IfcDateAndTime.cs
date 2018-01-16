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


namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("c6c5b3f3-d5db-4119-8e7e-9c14eb351a82")]
	public partial class IfcDateAndTime :
		BuildingSmart.IFC.IfcDateTimeResource.IfcDateTimeSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCalendarDate _DateComponent;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcLocalTime _TimeComponent;
	
	
		[Description("The date element of the date time combination.")]
		public IfcCalendarDate DateComponent { get { return this._DateComponent; } set { this._DateComponent = value;} }
	
		[Description("The time element of the date time combination.")]
		public IfcLocalTime TimeComponent { get { return this._TimeComponent; } set { this._TimeComponent = value;} }
	
	
	}
	
}

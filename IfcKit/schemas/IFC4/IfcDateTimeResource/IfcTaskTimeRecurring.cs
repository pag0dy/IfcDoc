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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("c42cad26-bc65-4c32-b181-80ca37d4d95f")]
	public partial class IfcTaskTimeRecurring : IfcTaskTime
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcRecurrencePattern")]
		[Required()]
		IfcRecurrencePattern _Recurrence;
	
	
		public IfcRecurrencePattern Recurrence { get { return this._Recurrence; } set { this._Recurrence = value;} }
	
	
	}
	
}

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
	public partial class IfcEvent : IfcProcess
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("    Identifies the predefined types of an event from which       the type required may be set.")]
		public IfcEventTypeEnum? PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("    Identifies the predefined types of event trigger from which       the type required may be set.")]
		public IfcEventTriggerTypeEnum? EventTriggerType { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("    A user defined event trigger type, the value of which is       asserted when the value of an event trigger type is declared       as USERDEFINED.")]
		public IfcLabel? UserDefinedEventTriggerType { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlElement]
		[Description("    The date and/or time at which an event occurs.")]
		public IfcEventTime EventOccurenceTime { get; set; }
	
	
		public IfcEvent(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcEventTypeEnum? __PredefinedType, IfcEventTriggerTypeEnum? __EventTriggerType, IfcLabel? __UserDefinedEventTriggerType, IfcEventTime __EventOccurenceTime)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification, __LongDescription)
		{
			this.PredefinedType = __PredefinedType;
			this.EventTriggerType = __EventTriggerType;
			this.UserDefinedEventTriggerType = __UserDefinedEventTriggerType;
			this.EventOccurenceTime = __EventOccurenceTime;
		}
	
	
	}
	
}

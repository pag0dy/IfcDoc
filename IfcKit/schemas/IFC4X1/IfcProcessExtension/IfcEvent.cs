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
	[Guid("2d5e432b-e7f0-4c0d-8a56-abea523cfc61")]
	public partial class IfcEvent : IfcProcess
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcEventTypeEnum? _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcEventTriggerTypeEnum? _EventTriggerType;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedEventTriggerType;
	
		[DataMember(Order=3)] 
		[XmlElement]
		IfcEventTime _EventOccurenceTime;
	
	
		public IfcEvent()
		{
		}
	
		public IfcEvent(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcEventTypeEnum? __PredefinedType, IfcEventTriggerTypeEnum? __EventTriggerType, IfcLabel? __UserDefinedEventTriggerType, IfcEventTime __EventOccurenceTime)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification, __LongDescription)
		{
			this._PredefinedType = __PredefinedType;
			this._EventTriggerType = __EventTriggerType;
			this._UserDefinedEventTriggerType = __UserDefinedEventTriggerType;
			this._EventOccurenceTime = __EventOccurenceTime;
		}
	
		[Description("    Identifies the predefined types of an event from which \r\n    the type require" +
	    "d may be set.")]
		public IfcEventTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("    Identifies the predefined types of event trigger from which \r\n    the type re" +
	    "quired may be set.")]
		public IfcEventTriggerTypeEnum? EventTriggerType { get { return this._EventTriggerType; } set { this._EventTriggerType = value;} }
	
		[Description("    A user defined event trigger type, the value of which is \r\n    asserted when " +
	    "the value of an event trigger type is declared \r\n    as USERDEFINED.")]
		public IfcLabel? UserDefinedEventTriggerType { get { return this._UserDefinedEventTriggerType; } set { this._UserDefinedEventTriggerType = value;} }
	
		[Description("    The date and/or time at which an event occurs.")]
		public IfcEventTime EventOccurenceTime { get { return this._EventOccurenceTime; } set { this._EventOccurenceTime = value;} }
	
	
	}
	
}

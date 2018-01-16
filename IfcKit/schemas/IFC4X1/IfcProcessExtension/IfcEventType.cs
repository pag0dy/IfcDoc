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
	[Guid("155c5cde-5c7b-4097-ab18-9e8bbd7c4981")]
	public partial class IfcEventType : IfcTypeProcess
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcEventTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcEventTriggerTypeEnum _EventTriggerType;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedEventTriggerType;
	
	
		[Description("    Identifies the predefined types of an event from which \r\n    the type require" +
	    "d may be set.")]
		public IfcEventTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("    Identifies the predefined types of event trigger from which \r\n    the type re" +
	    "quired may be set.")]
		public IfcEventTriggerTypeEnum EventTriggerType { get { return this._EventTriggerType; } set { this._EventTriggerType = value;} }
	
		[Description("    A user defined event trigger type, the value of which \r\n    is asserted when " +
	    "the value of an event trigger type is \r\n    declared as USERDEFINED.")]
		public IfcLabel? UserDefinedEventTriggerType { get { return this._UserDefinedEventTriggerType; } set { this._UserDefinedEventTriggerType = value;} }
	
	
	}
	
}

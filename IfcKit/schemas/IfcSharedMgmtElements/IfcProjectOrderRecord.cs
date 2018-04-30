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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	public partial class IfcProjectOrderRecord : IfcControl
	{
		[DataMember(Order = 0)] 
		[Description("Records in the sequence of occurrence the incident of a project order and the objects that are related to that project order. For instance, a maintenance incident will connect a work order with the objects (elements or assets) that are subject to the provisions of the work order")]
		[Required()]
		[MinLength(1)]
		public IList<IfcRelAssignsToProjectOrder> Records { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Identifies the type of project incident.")]
		[Required()]
		public IfcProjectOrderRecordTypeEnum PredefinedType { get; set; }
	
	
		public IfcProjectOrderRecord(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcRelAssignsToProjectOrder[] __Records, IfcProjectOrderRecordTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.Records = new List<IfcRelAssignsToProjectOrder>(__Records);
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}

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

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	[Guid("45bbb70f-7b6d-47a3-a757-15d91d906160")]
	public partial class IfcProjectOrderRecord : IfcControl
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcRelAssignsToProjectOrder> _Records = new List<IfcRelAssignsToProjectOrder>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcProjectOrderRecordTypeEnum _PredefinedType;
	
	
		public IfcProjectOrderRecord()
		{
		}
	
		public IfcProjectOrderRecord(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcRelAssignsToProjectOrder[] __Records, IfcProjectOrderRecordTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._Records = new List<IfcRelAssignsToProjectOrder>(__Records);
			this._PredefinedType = __PredefinedType;
		}
	
		[Description(@"Records in the sequence of occurrence the incident of a project order and the objects that are related to that project order. For instance, a maintenance incident will connect a work order with the objects (elements or assets) that are subject to the provisions of the work order")]
		public IList<IfcRelAssignsToProjectOrder> Records { get { return this._Records; } }
	
		[Description("Identifies the type of project incident.")]
		public IfcProjectOrderRecordTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}

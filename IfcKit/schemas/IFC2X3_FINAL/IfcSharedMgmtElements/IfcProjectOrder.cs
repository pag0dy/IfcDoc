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
	[Guid("50fbbf88-011f-48b4-9b53-17c9d9538558")]
	public partial class IfcProjectOrder : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _ID;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcProjectOrderTypeEnum _PredefinedType;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Status;
	
	
		public IfcProjectOrder()
		{
		}
	
		public IfcProjectOrder(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __ID, IfcProjectOrderTypeEnum __PredefinedType, IfcLabel? __Status)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._ID = __ID;
			this._PredefinedType = __PredefinedType;
			this._Status = __Status;
		}
	
		[Description("A unique identification assigned to a project order that enables its differentiat" +
	    "ion from other project orders.")]
		public IfcIdentifier ID { get { return this._ID; } set { this._ID = value;} }
	
		[Description("The type of project order.\r\n")]
		public IfcProjectOrderTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("The current status of a project order.Examples of status values that might be use" +
	    "d for a project order status include:\r\n- PLANNED\r\n- REQUESTED\r\n- APPROVED\r\n- ISS" +
	    "UED\r\n- STARTED\r\n- DELAYED\r\n- DONE\r\n\r\n")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
	
	}
	
}

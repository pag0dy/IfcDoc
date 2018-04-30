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
	public partial class IfcProjectOrder : IfcControl
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A unique identification assigned to a project order that enables its differentiation from other project orders.")]
		[Required()]
		[CustomValidation(typeof(IfcProjectOrder), "Unique")]
		public IfcIdentifier ID { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The type of project order.  ")]
		[Required()]
		public IfcProjectOrderTypeEnum PredefinedType { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The current status of a project order.Examples of status values that might be used for a project order status include:  - PLANNED  - REQUESTED  - APPROVED  - ISSUED  - STARTED  - DELAYED  - DONE    ")]
		public IfcLabel? Status { get; set; }
	
	
		public IfcProjectOrder(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __ID, IfcProjectOrderTypeEnum __PredefinedType, IfcLabel? __Status)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.ID = __ID;
			this.PredefinedType = __PredefinedType;
			this.Status = __Status;
		}
	
	
	}
	
}

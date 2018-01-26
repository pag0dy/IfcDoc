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
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcFacilitiesMgmtDomain
{
	[Guid("c7a4c56f-a990-47cd-9d1a-7886d471fa80")]
	public partial class IfcOrderAction : IfcTask
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _ActionID;
	
	
		public IfcOrderAction()
		{
		}
	
		public IfcOrderAction(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __TaskId, IfcLabel? __Status, IfcLabel? __WorkMethod, Boolean __IsMilestone, Int64? __Priority, IfcIdentifier __ActionID)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __TaskId, __Status, __WorkMethod, __IsMilestone, __Priority)
		{
			this._ActionID = __ActionID;
		}
	
		[Description("A unique identifier assigned to an action on issue.")]
		public IfcIdentifier ActionID { get { return this._ActionID; } set { this._ActionID = value;} }
	
	
	}
	
}

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
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcFacilitiesMgmtDomain
{
	public partial class IfcOrderAction : IfcTask
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A unique identifier assigned to an action on issue.")]
		[Required()]
		[CustomValidation(typeof(IfcOrderAction), "Unique")]
		public IfcIdentifier ActionID { get; set; }
	
	
		public IfcOrderAction(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __TaskId, IfcLabel? __Status, IfcLabel? __WorkMethod, Boolean __IsMilestone, Int64? __Priority, IfcIdentifier __ActionID)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __TaskId, __Status, __WorkMethod, __IsMilestone, __Priority)
		{
			this.ActionID = __ActionID;
		}
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public partial class IfcGroup : IfcObject
	{
		[InverseProperty("RelatingGroup")] 
		[Description("Reference to the relationship <em>IfcRelAssignsToGroup</em> that assigns the one to many group members to the <em>IfcGroup</em> object.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The cardinality has been changed from 1..1 to 0..? in order to allow the exchange of a group concept without having already group members assigned. It now also allows the use of many instances of <em>IfcRelAssignsToGroup</em> to assign the group members. The change has been done with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelAssignsToGroup> IsGroupedBy { get; protected set; }
	
	
		public IfcGroup(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.IsGroupedBy = new HashSet<IfcRelAssignsToGroup>();
		}
	
	
	}
	
}

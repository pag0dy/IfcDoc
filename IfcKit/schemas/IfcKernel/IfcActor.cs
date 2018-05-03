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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public partial class IfcActor : IfcObject
	{
		[DataMember(Order = 0)] 
		[Description("Information about the actor.  ")]
		[Required()]
		public IfcActorSelect TheActor { get; set; }
	
		[InverseProperty("RelatingActor")] 
		[Description("Reference to the relationship that associates the actor to an object.  ")]
		public ISet<IfcRelAssignsToActor> IsActingUpon { get; protected set; }
	
	
		public IfcActor(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcActorSelect __TheActor)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.TheActor = __TheActor;
			this.IsActingUpon = new HashSet<IfcRelAssignsToActor>();
		}
	
	
	}
	
}

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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	public partial class IfcOccupant : IfcActor
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Predefined occupant types from which that required may be set.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Attribute made optional.</blockquote> ")]
		public IfcOccupantTypeEnum? PredefinedType { get; set; }
	
	
		public IfcOccupant(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcActorSelect __TheActor, IfcOccupantTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __TheActor)
		{
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}

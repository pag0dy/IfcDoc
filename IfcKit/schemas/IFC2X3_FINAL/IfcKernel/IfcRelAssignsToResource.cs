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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("7075b401-84d0-4d10-8662-bc5063a63bec")]
	public partial class IfcRelAssignsToResource : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcResource _RelatingResource;
	
	
		public IfcRelAssignsToResource()
		{
		}
	
		public IfcRelAssignsToResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcResource __RelatingResource)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType)
		{
			this._RelatingResource = __RelatingResource;
		}
	
		[Description("Reference to the resource to which the objects are assigned to.\r\n")]
		public IfcResource RelatingResource { get { return this._RelatingResource; } set { this._RelatingResource = value;} }
	
	
	}
	
}

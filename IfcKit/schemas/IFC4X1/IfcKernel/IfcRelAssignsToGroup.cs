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
	[Guid("20dee03b-bfd0-4795-923f-4619fc628b6c")]
	public partial class IfcRelAssignsToGroup : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcGroup _RelatingGroup;
	
	
		public IfcRelAssignsToGroup()
		{
		}
	
		public IfcRelAssignsToGroup(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcGroup __RelatingGroup)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType)
		{
			this._RelatingGroup = __RelatingGroup;
		}
	
		[Description("Reference to group that contains all assigned group members.\r\n")]
		public IfcGroup RelatingGroup { get { return this._RelatingGroup; } set { this._RelatingGroup = value;} }
	
	
	}
	
}

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
	public partial class IfcRelAssignsToGroupByFactor : IfcRelAssignsToGroup
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Factor provided as a ratio measure that identifies the fraction or weighted factor that applies to the group assignment.")]
		[Required()]
		public IfcRatioMeasure Factor { get; set; }
	
	
		public IfcRelAssignsToGroupByFactor(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcGroup __RelatingGroup, IfcRatioMeasure __Factor)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType, __RelatingGroup)
		{
			this.Factor = __Factor;
		}
	
	
	}
	
}

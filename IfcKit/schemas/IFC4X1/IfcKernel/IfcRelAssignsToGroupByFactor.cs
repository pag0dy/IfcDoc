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
	[Guid("0ae997a0-8ed2-4ce0-aaf7-1b4d33ce64bb")]
	public partial class IfcRelAssignsToGroupByFactor : IfcRelAssignsToGroup
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcRatioMeasure _Factor;
	
	
		public IfcRelAssignsToGroupByFactor()
		{
		}
	
		public IfcRelAssignsToGroupByFactor(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcGroup __RelatingGroup, IfcRatioMeasure __Factor)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType, __RelatingGroup)
		{
			this._Factor = __Factor;
		}
	
		[Description("Factor provided as a ratio measure that identifies the fraction or weighted facto" +
	    "r that applies to the group assignment.")]
		public IfcRatioMeasure Factor { get { return this._Factor; } set { this._Factor = value;} }
	
	
	}
	
}

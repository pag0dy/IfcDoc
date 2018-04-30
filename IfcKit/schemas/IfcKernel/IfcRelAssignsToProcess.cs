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
	public partial class IfcRelAssignsToProcess : IfcRelAssigns
	{
		[DataMember(Order = 0)] 
		[Description("Reference to the process to which the objects are assigned to.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Datatype expanded to include <em>IfcProcess</em> and <em>IfcTypeProcess</em>.</blockquote>")]
		[Required()]
		public IfcProcessSelect RelatingProcess { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Quantity of the object specific for the operation by this process.")]
		public IfcMeasureWithUnit QuantityInProcess { get; set; }
	
	
		public IfcRelAssignsToProcess(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcProcessSelect __RelatingProcess, IfcMeasureWithUnit __QuantityInProcess)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType)
		{
			this.RelatingProcess = __RelatingProcess;
			this.QuantityInProcess = __QuantityInProcess;
		}
	
	
	}
	
}

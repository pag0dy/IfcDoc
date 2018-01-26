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
	[Guid("61204dbc-e9f6-40ab-aaaf-0c7f854fa124")]
	public partial class IfcRelAssignsToProcess : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProcess _RelatingProcess;
	
		[DataMember(Order=1)] 
		IfcMeasureWithUnit _QuantityInProcess;
	
	
		public IfcRelAssignsToProcess()
		{
		}
	
		public IfcRelAssignsToProcess(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcProcess __RelatingProcess, IfcMeasureWithUnit __QuantityInProcess)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType)
		{
			this._RelatingProcess = __RelatingProcess;
			this._QuantityInProcess = __QuantityInProcess;
		}
	
		[Description("Reference to the process to which the objects are assigned to.\r\n")]
		public IfcProcess RelatingProcess { get { return this._RelatingProcess; } set { this._RelatingProcess = value;} }
	
		[Description("Quantity of the object specific for the operation by this process.")]
		public IfcMeasureWithUnit QuantityInProcess { get { return this._QuantityInProcess; } set { this._QuantityInProcess = value;} }
	
	
	}
	
}

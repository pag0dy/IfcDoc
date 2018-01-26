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

using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	[Guid("2c706d2f-9653-4ce1-b7aa-c4999a8adf0b")]
	public partial class IfcRelAssociatesAppliedValue : IfcRelAssociates
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAppliedValue _RelatingAppliedValue;
	
	
		public IfcRelAssociatesAppliedValue()
		{
		}
	
		public IfcRelAssociatesAppliedValue(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcRoot[] __RelatedObjects, IfcAppliedValue __RelatingAppliedValue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects)
		{
			this._RelatingAppliedValue = __RelatingAppliedValue;
		}
	
		public IfcAppliedValue RelatingAppliedValue { get { return this._RelatingAppliedValue; } set { this._RelatingAppliedValue = value;} }
	
	
	}
	
}

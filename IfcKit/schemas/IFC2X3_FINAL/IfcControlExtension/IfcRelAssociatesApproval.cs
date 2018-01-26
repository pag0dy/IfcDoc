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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcControlExtension
{
	[Guid("196fb722-ac59-498f-8159-2eb6608566d6")]
	public partial class IfcRelAssociatesApproval : IfcRelAssociates
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcApproval _RelatingApproval;
	
	
		public IfcRelAssociatesApproval()
		{
		}
	
		public IfcRelAssociatesApproval(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcRoot[] __RelatedObjects, IfcApproval __RelatingApproval)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects)
		{
			this._RelatingApproval = __RelatingApproval;
		}
	
		[Description("Reference to approval that is being applied using this relationship.")]
		public IfcApproval RelatingApproval { get { return this._RelatingApproval; } set { this._RelatingApproval = value;} }
	
	
	}
	
}

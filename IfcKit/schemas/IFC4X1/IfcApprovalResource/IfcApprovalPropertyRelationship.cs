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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcApprovalResource
{
	[Guid("1c2aec54-d28d-469c-bbc5-858f9995cd6c")]
	public partial class IfcApprovalPropertyRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcProperty> _ApprovedProperties = new HashSet<IfcProperty>();
	
		[DataMember(Order=1)] 
		[Required()]
		IfcApproval _Approval;
	
	
		[Description("Properties approved by the approval.")]
		public ISet<IfcProperty> ApprovedProperties { get { return this._ApprovedProperties; } }
	
		[Description("The approval for the properties selected.")]
		public IfcApproval Approval { get { return this._Approval; } set { this._Approval = value;} }
	
	
	}
	
}

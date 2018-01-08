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
	[Guid("3ccb6ea3-b6eb-4134-b8a4-b738ae3f3001")]
	public partial class IfcApprovalRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcApproval _RelatedApproval;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcApproval _RelatingApproval;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
	
		[Description("The approval that relates to another approval")]
		public IfcApproval RelatedApproval { get { return this._RelatedApproval; } set { this._RelatedApproval = value;} }
	
		[Description("The approval that other approval is related to.")]
		public IfcApproval RelatingApproval { get { return this._RelatingApproval; } set { this._RelatingApproval = value;} }
	
		[Description("Textual description explaining the relationship between approvals.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The human readable name given to the relationship between the approvals.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
	
	}
	
}

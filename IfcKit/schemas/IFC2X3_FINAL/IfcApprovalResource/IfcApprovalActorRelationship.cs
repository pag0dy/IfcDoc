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

namespace BuildingSmart.IFC.IfcApprovalResource
{
	[Guid("6ae78aed-f390-404d-8b25-5bae729a7cd7")]
	public partial class IfcApprovalActorRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcActorSelect _Actor;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcApproval _Approval;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcActorRole _Role;
	
	
		public IfcApprovalActorRelationship()
		{
		}
	
		public IfcApprovalActorRelationship(IfcActorSelect __Actor, IfcApproval __Approval, IfcActorRole __Role)
		{
			this._Actor = __Actor;
			this._Approval = __Approval;
			this._Role = __Role;
		}
	
		[Description("The reference to the actor who is acting in the given role on the approval specif" +
	    "ied in this relationship.")]
		public IfcActorSelect Actor { get { return this._Actor; } set { this._Actor = value;} }
	
		[Description("The approval on which the actor is acting in the role specified in this relations" +
	    "hip.")]
		public IfcApproval Approval { get { return this._Approval; } set { this._Approval = value;} }
	
		[Description("The role of the actor w.r.t the approval.")]
		public IfcActorRole Role { get { return this._Role; } set { this._Role = value;} }
	
	
	}
	
}

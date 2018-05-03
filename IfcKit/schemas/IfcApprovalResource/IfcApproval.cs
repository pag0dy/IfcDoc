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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcControlExtension;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcApprovalResource
{
	public partial class IfcApproval :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A computer interpretable identifier by which the approval is known.")]
		public IfcIdentifier? Identifier { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("A human readable name given to an approval.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("A general textual description of a design, work task, plan, etc. that is being approved for.   ")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Date and time when the result of the approval process is produced.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute data type changed to <em>IfcDateTime</em> using ISO 8601 representation, renamed from ApprovalDateTime and made OPTIONAL.</blockquote>")]
		public IfcDateTime? TimeOfApproval { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The result or current status of the approval, e.g. Requested, Processed, Approved, Not Approved.")]
		public IfcLabel? Status { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Level of the approval e.g. Draft v.s. Completed design.")]
		public IfcLabel? Level { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Textual description of special constraints or conditions for the approval.")]
		public IfcText? Qualifier { get; set; }
	
		[DataMember(Order = 7)] 
		[Description("The actor that is acting in the role specified at <em>IfcOrganization</em> or individually at <em>IfcPerson</em> and requesting an approval.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute for approval request replacing IfcApprovalActorRelationship (being deleted).</blockquote>")]
		public IfcActorSelect RequestingApproval { get; set; }
	
		[DataMember(Order = 8)] 
		[Description("The actor that is acting in the role specified at <em>IfcOrganization</em> or individually at <em>IfcPerson</em> and giving an approval.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute for approval provision replacing IfcApprovalActorRelationship (being deleted).</blockquote>")]
		public IfcActorSelect GivingApproval { get; set; }
	
		[InverseProperty("RelatedResourceObjects")] 
		[Description("Reference to external references, e.g. library, classification, or document information, that are associated to the Approval.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote> ")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReferences { get; protected set; }
	
		[InverseProperty("RelatingApproval")] 
		[Description("Reference to the <em>IfcRelAssociatesApproval</em> instances associating this approval to objects (subtypes of <em>IfcRoot</em>")]
		public ISet<IfcRelAssociatesApproval> ApprovedObjects { get; protected set; }
	
		[InverseProperty("RelatingApproval")] 
		[Description("The set of relationships by which resource objects that are are approved by this approval are known.")]
		public ISet<IfcResourceApprovalRelationship> ApprovedResources { get; protected set; }
	
		[InverseProperty("RelatedApprovals")] 
		[Description("The set of relationships by which this approval is related to others.")]
		public ISet<IfcApprovalRelationship> IsRelatedWith { get; protected set; }
	
		[InverseProperty("RelatingApproval")] 
		[Description("The set of relationships by which other approvals are related to this one.")]
		public ISet<IfcApprovalRelationship> Relates { get; protected set; }
	
	
		public IfcApproval(IfcIdentifier? __Identifier, IfcLabel? __Name, IfcText? __Description, IfcDateTime? __TimeOfApproval, IfcLabel? __Status, IfcLabel? __Level, IfcText? __Qualifier, IfcActorSelect __RequestingApproval, IfcActorSelect __GivingApproval)
		{
			this.Identifier = __Identifier;
			this.Name = __Name;
			this.Description = __Description;
			this.TimeOfApproval = __TimeOfApproval;
			this.Status = __Status;
			this.Level = __Level;
			this.Qualifier = __Qualifier;
			this.RequestingApproval = __RequestingApproval;
			this.GivingApproval = __GivingApproval;
			this.HasExternalReferences = new HashSet<IfcExternalReferenceRelationship>();
			this.ApprovedObjects = new HashSet<IfcRelAssociatesApproval>();
			this.ApprovedResources = new HashSet<IfcResourceApprovalRelationship>();
			this.IsRelatedWith = new HashSet<IfcApprovalRelationship>();
			this.Relates = new HashSet<IfcApprovalRelationship>();
		}
	
	
	}
	
}

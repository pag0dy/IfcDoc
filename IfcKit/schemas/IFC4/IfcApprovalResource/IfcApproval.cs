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
using BuildingSmart.IFC.IfcControlExtension;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcApprovalResource
{
	[Guid("76476d02-0061-4539-81cf-c606a2acbe13")]
	public partial class IfcApproval :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identifier;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcDateTime? _TimeOfApproval;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLabel? _Status;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcLabel? _Level;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcText? _Qualifier;
	
		[DataMember(Order=7)] 
		IfcActorSelect _RequestingApproval;
	
		[DataMember(Order=8)] 
		IfcActorSelect _GivingApproval;
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcExternalReferenceRelationship> _HasExternalReferences = new HashSet<IfcExternalReferenceRelationship>();
	
		[InverseProperty("RelatingApproval")] 
		ISet<IfcRelAssociatesApproval> _ApprovedObjects = new HashSet<IfcRelAssociatesApproval>();
	
		[InverseProperty("RelatingApproval")] 
		ISet<IfcResourceApprovalRelationship> _ApprovedResources = new HashSet<IfcResourceApprovalRelationship>();
	
		[InverseProperty("RelatedApprovals")] 
		ISet<IfcApprovalRelationship> _IsRelatedWith = new HashSet<IfcApprovalRelationship>();
	
		[InverseProperty("RelatingApproval")] 
		ISet<IfcApprovalRelationship> _Relates = new HashSet<IfcApprovalRelationship>();
	
	
		[Description("A computer interpretable identifier by which the approval is known.")]
		public IfcIdentifier? Identifier { get { return this._Identifier; } set { this._Identifier = value;} }
	
		[Description("A human readable name given to an approval.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A general textual description of a design, work task, plan, etc. that is being ap" +
	    "proved for. \r\n")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"<EPM-HTML>
	Date and time when the result of the approval process is produced.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; Attribute data type changed to <em>IfcDateTime</em> using ISO 8601 representation, renamed from ApprovalDateTime and made OPTIONAL.</blockquote>
	</EPM-HTML>")]
		public IfcDateTime? TimeOfApproval { get { return this._TimeOfApproval; } set { this._TimeOfApproval = value;} }
	
		[Description("The result or current status of the approval, e.g. Requested, Processed, Approved" +
	    ", Not Approved.")]
		public IfcLabel? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("Level of the approval e.g. Draft v.s. Completed design.")]
		public IfcLabel? Level { get { return this._Level; } set { this._Level = value;} }
	
		[Description("Textual description of special constraints or conditions for the approval.")]
		public IfcText? Qualifier { get { return this._Qualifier; } set { this._Qualifier = value;} }
	
		[Description(@"<EPM-HTML>
	The actor that is acting in the role specified at <em>IfcOrganization</em> or individually at <em>IfcPerson</em> and requesting an approval.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute for approval request replacing IfcApprovalActorRelationship (being deleted).</blockquote>
	</EPM-HTML>")]
		public IfcActorSelect RequestingApproval { get { return this._RequestingApproval; } set { this._RequestingApproval = value;} }
	
		[Description(@"<EPM-HTML>
	The actor that is acting in the role specified at <em>IfcOrganization</em> or individually at <em>IfcPerson</em> and giving an approval.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute for approval provision replacing IfcApprovalActorRelationship (being deleted).</blockquote>
	</EPM-HTML>")]
		public IfcActorSelect GivingApproval { get { return this._GivingApproval; } set { this._GivingApproval = value;} }
	
		[Description("<EPM-HTML>\r\nReference to external references, e.g. library, classification, or do" +
	    "cument information, that are associated to the Approval.\r\n<blockquote class=\"cha" +
	    "nge-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>\r\n</EPM-HTML> ")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReferences { get { return this._HasExternalReferences; } }
	
		[Description("Reference to the <em>IfcRelAssociatesApproval</em> instances associating this app" +
	    "roval to objects.")]
		public ISet<IfcRelAssociatesApproval> ApprovedObjects { get { return this._ApprovedObjects; } }
	
		[Description("The set of relationships by which resource objects that are are approved by this " +
	    "approval are known.")]
		public ISet<IfcResourceApprovalRelationship> ApprovedResources { get { return this._ApprovedResources; } }
	
		[Description("The set of relationships by which this approval is related to others.")]
		public ISet<IfcApprovalRelationship> IsRelatedWith { get { return this._IsRelatedWith; } }
	
		[Description("The set of relationships by which other approvals are related to this one.")]
		public ISet<IfcApprovalRelationship> Relates { get { return this._Relates; } }
	
	
	}
	
}

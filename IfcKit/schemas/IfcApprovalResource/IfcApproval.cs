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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcApprovalResource
{
	public partial class IfcApproval
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A general textual description of a design, work task, plan, etc. that is being approved for.   ")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Date and time when the result of the approval process is produced.  ")]
		[Required()]
		public IfcDateTimeSelect ApprovalDateTime { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The result or current status of the approval, e.g. Requested, Processed, Approved, Not Approved.")]
		public IfcLabel? ApprovalStatus { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Level of the approval e.g. Draft v.s. Completed design.")]
		public IfcLabel? ApprovalLevel { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Textual description of special constraints or conditions for the approval.")]
		public IfcText? ApprovalQualifier { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("A human readable name given to an approval.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("A computer interpretable identifier by which the approval is known.")]
		[Required()]
		public IfcIdentifier Identifier { get; set; }
	
		[InverseProperty("Approval")] 
		[Description("The set of relationships by which the actors acting in specified roles on this approval are known.")]
		public ISet<IfcApprovalActorRelationship> Actors { get; protected set; }
	
		[InverseProperty("RelatedApproval")] 
		[Description("The set of relationships by which this approval is related to others.")]
		public ISet<IfcApprovalRelationship> IsRelatedWith { get; protected set; }
	
		[InverseProperty("RelatingApproval")] 
		[Description("The set of relationships by which other approvals are related to this one.")]
		public ISet<IfcApprovalRelationship> Relates { get; protected set; }
	
	
		public IfcApproval(IfcText? __Description, IfcDateTimeSelect __ApprovalDateTime, IfcLabel? __ApprovalStatus, IfcLabel? __ApprovalLevel, IfcText? __ApprovalQualifier, IfcLabel __Name, IfcIdentifier __Identifier)
		{
			this.Description = __Description;
			this.ApprovalDateTime = __ApprovalDateTime;
			this.ApprovalStatus = __ApprovalStatus;
			this.ApprovalLevel = __ApprovalLevel;
			this.ApprovalQualifier = __ApprovalQualifier;
			this.Name = __Name;
			this.Identifier = __Identifier;
			this.Actors = new HashSet<IfcApprovalActorRelationship>();
			this.IsRelatedWith = new HashSet<IfcApprovalRelationship>();
			this.Relates = new HashSet<IfcApprovalRelationship>();
		}
	
	
	}
	
}

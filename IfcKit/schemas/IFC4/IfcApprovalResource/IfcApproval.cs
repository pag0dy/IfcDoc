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
	[Guid("df06df2c-a1d7-499a-ba49-f955ceae5f1a")]
	public partial class IfcApproval
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcDateTimeSelect _ApprovalDateTime;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _ApprovalStatus;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _ApprovalLevel;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcText? _ApprovalQualifier;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _Identifier;
	
		[InverseProperty("Approval")] 
		ISet<IfcApprovalActorRelationship> _Actors = new HashSet<IfcApprovalActorRelationship>();
	
		[InverseProperty("RelatedApproval")] 
		ISet<IfcApprovalRelationship> _IsRelatedWith = new HashSet<IfcApprovalRelationship>();
	
		[InverseProperty("RelatingApproval")] 
		ISet<IfcApprovalRelationship> _Relates = new HashSet<IfcApprovalRelationship>();
	
	
		[Description("A general textual description of a design, work task, plan, etc. that is being ap" +
	    "proved for. \r\n")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Date and time when the result of the approval process is produced.\r\n")]
		public IfcDateTimeSelect ApprovalDateTime { get { return this._ApprovalDateTime; } set { this._ApprovalDateTime = value;} }
	
		[Description("The result or current status of the approval, e.g. Requested, Processed, Approved" +
	    ", Not Approved.")]
		public IfcLabel? ApprovalStatus { get { return this._ApprovalStatus; } set { this._ApprovalStatus = value;} }
	
		[Description("Level of the approval e.g. Draft v.s. Completed design.")]
		public IfcLabel? ApprovalLevel { get { return this._ApprovalLevel; } set { this._ApprovalLevel = value;} }
	
		[Description("Textual description of special constraints or conditions for the approval.")]
		public IfcText? ApprovalQualifier { get { return this._ApprovalQualifier; } set { this._ApprovalQualifier = value;} }
	
		[Description("A human readable name given to an approval.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A computer interpretable identifier by which the approval is known.")]
		public IfcIdentifier Identifier { get { return this._Identifier; } set { this._Identifier = value;} }
	
		[Description("The set of relationships by which the actors acting in specified roles on this ap" +
	    "proval are known.")]
		public ISet<IfcApprovalActorRelationship> Actors { get { return this._Actors; } }
	
		[Description("The set of relationships by which this approval is related to others.")]
		public ISet<IfcApprovalRelationship> IsRelatedWith { get { return this._IsRelatedWith; } }
	
		[Description("The set of relationships by which other approvals are related to this one.")]
		public ISet<IfcApprovalRelationship> Relates { get { return this._Relates; } }
	
	
	}
	
}

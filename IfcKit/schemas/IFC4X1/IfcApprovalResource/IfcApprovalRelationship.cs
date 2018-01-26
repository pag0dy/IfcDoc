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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcApprovalResource
{
	[Guid("a303f452-ac6e-4cf8-aec2-92da14dd6675")]
	public partial class IfcApprovalRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcApproval _RelatingApproval;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcApproval> _RelatedApprovals = new HashSet<IfcApproval>();
	
	
		public IfcApprovalRelationship()
		{
		}
	
		public IfcApprovalRelationship(IfcLabel? __Name, IfcText? __Description, IfcApproval __RelatingApproval, IfcApproval[] __RelatedApprovals)
			: base(__Name, __Description)
		{
			this._RelatingApproval = __RelatingApproval;
			this._RelatedApprovals = new HashSet<IfcApproval>(__RelatedApprovals);
		}
	
		[Description("The approval that other approval is related to.")]
		public IfcApproval RelatingApproval { get { return this._RelatingApproval; } set { this._RelatingApproval = value;} }
	
		[Description("The approvals that are related to another (relating) approval.<blockquote class=\"" +
	    "change-ifc2x4\">IFC4 CHANGE&nbsp; The cardinality of this attribute has been chan" +
	    "ged to SET.</blockquote>")]
		public ISet<IfcApproval> RelatedApprovals { get { return this._RelatedApprovals; } }
	
	
	}
	
}

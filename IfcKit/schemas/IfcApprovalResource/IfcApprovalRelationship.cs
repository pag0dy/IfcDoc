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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcApprovalResource
{
	public partial class IfcApprovalRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The approval that other approval is related to.")]
		[Required()]
		public IfcApproval RelatingApproval { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The approvals that are related to another (relating) approval.<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The cardinality of this attribute has been changed to SET.</blockquote>")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcApproval> RelatedApprovals { get; protected set; }
	
	
		public IfcApprovalRelationship(IfcLabel? __Name, IfcText? __Description, IfcApproval __RelatingApproval, IfcApproval[] __RelatedApprovals)
			: base(__Name, __Description)
		{
			this.RelatingApproval = __RelatingApproval;
			this.RelatedApprovals = new HashSet<IfcApproval>(__RelatedApprovals);
		}
	
	
	}
	
}

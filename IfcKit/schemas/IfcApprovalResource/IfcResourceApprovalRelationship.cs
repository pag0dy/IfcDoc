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
	public partial class IfcResourceApprovalRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order = 0)] 
		[Description("Resource objects that are approved.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcResourceObjectSelect> RelatedResourceObjects { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("The approval for the resource objects selected.")]
		[Required()]
		public IfcApproval RelatingApproval { get; set; }
	
	
		public IfcResourceApprovalRelationship(IfcLabel? __Name, IfcText? __Description, IfcResourceObjectSelect[] __RelatedResourceObjects, IfcApproval __RelatingApproval)
			: base(__Name, __Description)
		{
			this.RelatedResourceObjects = new HashSet<IfcResourceObjectSelect>(__RelatedResourceObjects);
			this.RelatingApproval = __RelatingApproval;
		}
	
	
	}
	
}

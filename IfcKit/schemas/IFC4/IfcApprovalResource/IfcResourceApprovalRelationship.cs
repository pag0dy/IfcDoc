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
	[Guid("6de8ca8d-3bd7-4b78-8326-eece0c07a365")]
	public partial class IfcResourceApprovalRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcResourceObjectSelect> _RelatedResourceObjects = new HashSet<IfcResourceObjectSelect>();
	
		[DataMember(Order=1)] 
		[XmlElement("IfcApproval")]
		[Required()]
		IfcApproval _RelatingApproval;
	
	
		[Description("<EPM-HTML>\r\nResource objects that are approved.\r\n</EPM-HTML>")]
		public ISet<IfcResourceObjectSelect> RelatedResourceObjects { get { return this._RelatedResourceObjects; } }
	
		[Description("The approval for the resource objects selected.")]
		public IfcApproval RelatingApproval { get { return this._RelatingApproval; } set { this._RelatingApproval = value;} }
	
	
	}
	
}

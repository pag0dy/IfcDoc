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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public abstract partial class IfcExternalReference :
		BuildingSmart.IFC.IfcPresentationOrganizationResource.IfcLightDistributionDataSourceSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Location, where the external source (classification, document or library) can be accessed by electronic means. The electronic location is provided as an URI, and would normally be given as an URL location string.  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; The data type has been changed from <em>IfcLabel</em> to <em>IfcURIReference</em><br>.  </blockquote>  ")]
		public IfcURIReference? Location { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The <em>Identification</em> provides a unique identifier of the referenced item within the external source (classification, document or library). It may be provided as   <ul>   <li>a key, e.g. a classification notation, like NF2.3</li>   <li>a handle</li>   <li>a uuid or guid</li>  </ul>  It may be human readable (such as a key) or not (such as a handle or uuid) depending on the context of its usage (which has to be determined by local agreement).  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE  Attribute renamed from <em>ItemReference</em> for consistency.<br>  </blockquote>")]
		public IfcIdentifier? Identification { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Optional name to further specify the reference. It can provide a human readable identifier (which does not necessarily need to have a counterpart in the internal structure of the document).")]
		public IfcLabel? Name { get; set; }
	
		[InverseProperty("RelatingReference")] 
		[Description("Reference to all associations between this external reference and objects within the <em>IfcResourceObjectSelect</em> that are tagged by the external reference.   <blockquote class=\"change-ifc2x4\">   IFC4 CHANGE&nbsp; New inverse attribute added with upward compatibility.<br>  </blockquote>")]
		public ISet<IfcExternalReferenceRelationship> ExternalReferenceForResources { get; protected set; }
	
	
		protected IfcExternalReference(IfcURIReference? __Location, IfcIdentifier? __Identification, IfcLabel? __Name)
		{
			this.Location = __Location;
			this.Identification = __Identification;
			this.Name = __Name;
			this.ExternalReferenceForResources = new HashSet<IfcExternalReferenceRelationship>();
		}
	
	
	}
	
}

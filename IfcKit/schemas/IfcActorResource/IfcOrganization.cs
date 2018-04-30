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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcActorResource
{
	public partial class IfcOrganization :
		BuildingSmart.IFC.IfcActorResource.IfcActorSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Identification of the organization.")]
		public IfcIdentifier? Identification { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The word, or group of words, by which the organization is referred to.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Text that relates the nature of the organization.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Roles played by the organization.")]
		[MinLength(1)]
		public IList<IfcActorRole> Roles { get; protected set; }
	
		[DataMember(Order = 4)] 
		[Description("Postal and telecom addresses of an organization.  <blockquote class=\"note\">NOTE&nbsp; There may be several addresses related to an organization.</blockquote>")]
		[MinLength(1)]
		public IList<IfcAddress> Addresses { get; protected set; }
	
		[InverseProperty("RelatedOrganizations")] 
		[Description("The inverse relationship for relationship RelatedOrganizations of IfcOrganizationRelationship.")]
		public ISet<IfcOrganizationRelationship> IsRelatedBy { get; protected set; }
	
		[InverseProperty("RelatingOrganization")] 
		[Description("The inverse relationship for relationship RelatingOrganization of IfcOrganizationRelationship.")]
		public ISet<IfcOrganizationRelationship> Relates { get; protected set; }
	
		[InverseProperty("TheOrganization")] 
		[Description("Inverse relationship to IfcPersonAndOrganization relationships in which IfcOrganization is engaged.")]
		public ISet<IfcPersonAndOrganization> Engages { get; protected set; }
	
	
		public IfcOrganization(IfcIdentifier? __Identification, IfcLabel __Name, IfcText? __Description, IfcActorRole[] __Roles, IfcAddress[] __Addresses)
		{
			this.Identification = __Identification;
			this.Name = __Name;
			this.Description = __Description;
			this.Roles = new List<IfcActorRole>(__Roles);
			this.Addresses = new List<IfcAddress>(__Addresses);
			this.IsRelatedBy = new HashSet<IfcOrganizationRelationship>();
			this.Relates = new HashSet<IfcOrganizationRelationship>();
			this.Engages = new HashSet<IfcPersonAndOrganization>();
		}
	
	
	}
	
}

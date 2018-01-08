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

namespace BuildingSmart.IFC.IfcActorResource
{
	[Guid("93c06606-4886-4b0b-9ed6-d883d74c46fd")]
	public partial class IfcOrganization :
		BuildingSmart.IFC.IfcActorResource.IfcActorSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identification;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=3)] 
		IList<IfcActorRole> _Roles = new List<IfcActorRole>();
	
		[DataMember(Order=4)] 
		IList<IfcAddress> _Addresses = new List<IfcAddress>();
	
		[InverseProperty("RelatedOrganizations")] 
		ISet<IfcOrganizationRelationship> _IsRelatedBy = new HashSet<IfcOrganizationRelationship>();
	
		[InverseProperty("RelatingOrganization")] 
		ISet<IfcOrganizationRelationship> _Relates = new HashSet<IfcOrganizationRelationship>();
	
		[InverseProperty("TheOrganization")] 
		ISet<IfcPersonAndOrganization> _Engages = new HashSet<IfcPersonAndOrganization>();
	
	
		[Description("Identification of the organization.")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("The word, or group of words, by which the organization is referred to.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Text that relates the nature of the organization.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Roles played by the organization.")]
		public IList<IfcActorRole> Roles { get { return this._Roles; } }
	
		[Description("Postal and telecom addresses of an organization.\r\n<blockquote class=\"note\">NOTE&n" +
	    "bsp; There may be several addresses related to an organization.</blockquote>")]
		public IList<IfcAddress> Addresses { get { return this._Addresses; } }
	
		[Description("The inverse relationship for relationship RelatedOrganizations of IfcOrganization" +
	    "Relationship.")]
		public ISet<IfcOrganizationRelationship> IsRelatedBy { get { return this._IsRelatedBy; } }
	
		[Description("The inverse relationship for relationship RelatingOrganization of IfcOrganization" +
	    "Relationship.")]
		public ISet<IfcOrganizationRelationship> Relates { get { return this._Relates; } }
	
		[Description("Inverse relationship to IfcPersonAndOrganization relationships in which IfcOrgani" +
	    "zation is engaged.")]
		public ISet<IfcPersonAndOrganization> Engages { get { return this._Engages; } }
	
	
	}
	
}

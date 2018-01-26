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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcActorResource
{
	[Guid("374ac51a-70a0-4e6e-934b-ba7a965eb472")]
	public partial class IfcOrganization :
		BuildingSmart.IFC.IfcActorResource.IfcActorSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Id;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=3)] 
		[MinLength(1)]
		IList<IfcActorRole> _Roles = new List<IfcActorRole>();
	
		[DataMember(Order=4)] 
		[MinLength(1)]
		IList<IfcAddress> _Addresses = new List<IfcAddress>();
	
		[InverseProperty("RelatedOrganizations")] 
		ISet<IfcOrganizationRelationship> _IsRelatedBy = new HashSet<IfcOrganizationRelationship>();
	
		[InverseProperty("RelatingOrganization")] 
		ISet<IfcOrganizationRelationship> _Relates = new HashSet<IfcOrganizationRelationship>();
	
		[InverseProperty("TheOrganization")] 
		ISet<IfcPersonAndOrganization> _Engages = new HashSet<IfcPersonAndOrganization>();
	
	
		public IfcOrganization()
		{
		}
	
		public IfcOrganization(IfcIdentifier? __Id, IfcLabel __Name, IfcText? __Description, IfcActorRole[] __Roles, IfcAddress[] __Addresses)
		{
			this._Id = __Id;
			this._Name = __Name;
			this._Description = __Description;
			this._Roles = new List<IfcActorRole>(__Roles);
			this._Addresses = new List<IfcAddress>(__Addresses);
		}
	
		[Description("Identification of the organization.")]
		public IfcIdentifier? Id { get { return this._Id; } set { this._Id = value;} }
	
		[Description("The word, or group of words, by which the organization is referred to.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Text that relates the nature of the organization.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Roles played by the organization.")]
		public IList<IfcActorRole> Roles { get { return this._Roles; } }
	
		[Description("Postal and telecom addresses of an organization.\r\n<EPM-HTML>\r\n<BLOCKQUOTE><FONT S" +
	    "IZE=\"-1\">NOTE: There may be several addresses related to an organization.\r\n</FON" +
	    "T></BLOCKQUOTE>\r\n</EPM-HTML>")]
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

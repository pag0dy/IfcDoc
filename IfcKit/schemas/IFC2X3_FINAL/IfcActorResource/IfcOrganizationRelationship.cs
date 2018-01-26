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

namespace BuildingSmart.IFC.IfcActorResource
{
	[Guid("e2b2eb22-42e4-4d17-a7f3-fd31bff900d2")]
	public partial class IfcOrganizationRelationship
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcOrganization _RelatingOrganization;
	
		[DataMember(Order=3)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcOrganization> _RelatedOrganizations = new HashSet<IfcOrganization>();
	
	
		public IfcOrganizationRelationship()
		{
		}
	
		public IfcOrganizationRelationship(IfcLabel __Name, IfcText? __Description, IfcOrganization __RelatingOrganization, IfcOrganization[] __RelatedOrganizations)
		{
			this._Name = __Name;
			this._Description = __Description;
			this._RelatingOrganization = __RelatingOrganization;
			this._RelatedOrganizations = new HashSet<IfcOrganization>(__RelatedOrganizations);
		}
	
		[Description("The word or group of words by which the relationship is referred to.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Text that relates the nature of the relationship.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Organization which is the relating part of the relationship between organizations" +
	    ".")]
		public IfcOrganization RelatingOrganization { get { return this._RelatingOrganization; } set { this._RelatingOrganization = value;} }
	
		[Description("The other, possibly dependent, organizations which are the related parts of the r" +
	    "elationship between organizations.")]
		public ISet<IfcOrganization> RelatedOrganizations { get { return this._RelatedOrganizations; } }
	
	
	}
	
}

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
	[Guid("7d18a179-a00b-491f-937b-dcc94942b9ce")]
	public partial class IfcOrganizationRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcOrganization _RelatingOrganization;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcOrganization> _RelatedOrganizations = new HashSet<IfcOrganization>();
	
	
		public IfcOrganizationRelationship()
		{
		}
	
		public IfcOrganizationRelationship(IfcLabel? __Name, IfcText? __Description, IfcOrganization __RelatingOrganization, IfcOrganization[] __RelatedOrganizations)
			: base(__Name, __Description)
		{
			this._RelatingOrganization = __RelatingOrganization;
			this._RelatedOrganizations = new HashSet<IfcOrganization>(__RelatedOrganizations);
		}
	
		[Description("Organization which is the relating part of the relationship between organizations" +
	    ".")]
		public IfcOrganization RelatingOrganization { get { return this._RelatingOrganization; } set { this._RelatingOrganization = value;} }
	
		[Description("The other, possibly dependent, organizations which are the related parts of the r" +
	    "elationship between organizations.")]
		public ISet<IfcOrganization> RelatedOrganizations { get { return this._RelatedOrganizations; } }
	
	
	}
	
}

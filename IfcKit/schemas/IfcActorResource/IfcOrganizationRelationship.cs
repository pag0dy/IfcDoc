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

namespace BuildingSmart.IFC.IfcActorResource
{
	public partial class IfcOrganizationRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Organization which is the relating part of the relationship between organizations.")]
		[Required()]
		public IfcOrganization RelatingOrganization { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The other, possibly dependent, organizations which are the related parts of the relationship between organizations.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcOrganization> RelatedOrganizations { get; protected set; }
	
	
		public IfcOrganizationRelationship(IfcLabel? __Name, IfcText? __Description, IfcOrganization __RelatingOrganization, IfcOrganization[] __RelatedOrganizations)
			: base(__Name, __Description)
		{
			this.RelatingOrganization = __RelatingOrganization;
			this.RelatedOrganizations = new HashSet<IfcOrganization>(__RelatedOrganizations);
		}
	
	
	}
	
}

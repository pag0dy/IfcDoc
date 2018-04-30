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

namespace BuildingSmart.IFC.IfcActorResource
{
	public partial class IfcOrganizationRelationship
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The word or group of words by which the relationship is referred to.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Text that relates the nature of the relationship.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Organization which is the relating part of the relationship between organizations.")]
		[Required()]
		public IfcOrganization RelatingOrganization { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The other, possibly dependent, organizations which are the related parts of the relationship between organizations.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcOrganization> RelatedOrganizations { get; protected set; }
	
	
		public IfcOrganizationRelationship(IfcLabel __Name, IfcText? __Description, IfcOrganization __RelatingOrganization, IfcOrganization[] __RelatedOrganizations)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.RelatingOrganization = __RelatingOrganization;
			this.RelatedOrganizations = new HashSet<IfcOrganization>(__RelatedOrganizations);
		}
	
	
	}
	
}

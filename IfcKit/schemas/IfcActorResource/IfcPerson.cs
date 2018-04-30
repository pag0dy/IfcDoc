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
	public partial class IfcPerson :
		BuildingSmart.IFC.IfcActorResource.IfcActorSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Identification of the person.")]
		public IfcIdentifier? Identification { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The name by which the family identity of the person may be recognized.  <blockquote class=\"note\">NOTE&nbsp; Depending on geographical location and culture, family name may appear either as the first or last component of a name.</blockquote>  ")]
		public IfcLabel? FamilyName { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The name by which a person is known within a family and by which he or she may be familiarly recognized.  <blockquote class=\"note\">NOTE&nbsp; Depending on geographical location and culture, given name may appear either as the first or last component of a name.</blockquote>  ")]
		public IfcLabel? GivenName { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Additional names given to a person that enable their identification apart from others who may have the same or similar family and given names.  <blockquote class=\"note\">NOTE&nbsp; Middle names are not normally used in familiar communication but may be asserted to provide additional   identification of a particular person if necessary. They may be particularly useful in situations where the person concerned has a   family name that occurs commonly in the geographical region.</blockquote>  ")]
		[MinLength(1)]
		public IList<IfcLabel> MiddleNames { get; protected set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The word, or group of words, which specify the person's social and/or professional standing and appear before his/her names.")]
		[MinLength(1)]
		public IList<IfcLabel> PrefixTitles { get; protected set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("The word, or group of words, which specify the person's social and/or professional standing and appear after his/her names.")]
		[MinLength(1)]
		public IList<IfcLabel> SuffixTitles { get; protected set; }
	
		[DataMember(Order = 6)] 
		[Description("Roles played by the person.")]
		[MinLength(1)]
		public IList<IfcActorRole> Roles { get; protected set; }
	
		[DataMember(Order = 7)] 
		[Description("Postal and telecommunication addresses of a person.  <blockquote class=\"note\">NOTE&nbsp; A person may have several addresses.</small></blockquote>  ")]
		[MinLength(1)]
		public IList<IfcAddress> Addresses { get; protected set; }
	
		[InverseProperty("ThePerson")] 
		[Description("The inverse relationship to IfcPersonAndOrganization relationships in which IfcPerson is engaged.")]
		public ISet<IfcPersonAndOrganization> EngagedIn { get; protected set; }
	
	
		public IfcPerson(IfcIdentifier? __Identification, IfcLabel? __FamilyName, IfcLabel? __GivenName, IfcLabel[] __MiddleNames, IfcLabel[] __PrefixTitles, IfcLabel[] __SuffixTitles, IfcActorRole[] __Roles, IfcAddress[] __Addresses)
		{
			this.Identification = __Identification;
			this.FamilyName = __FamilyName;
			this.GivenName = __GivenName;
			this.MiddleNames = new List<IfcLabel>(__MiddleNames);
			this.PrefixTitles = new List<IfcLabel>(__PrefixTitles);
			this.SuffixTitles = new List<IfcLabel>(__SuffixTitles);
			this.Roles = new List<IfcActorRole>(__Roles);
			this.Addresses = new List<IfcAddress>(__Addresses);
			this.EngagedIn = new HashSet<IfcPersonAndOrganization>();
		}
	
	
	}
	
}

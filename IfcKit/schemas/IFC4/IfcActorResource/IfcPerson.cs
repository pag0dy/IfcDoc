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
	[Guid("444c7a43-9f92-48d5-9ff4-acdf38ead916")]
	public partial class IfcPerson :
		BuildingSmart.IFC.IfcActorResource.IfcActorSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identification;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _FamilyName;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _GivenName;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IList<IfcLabel> _MiddleNames = new List<IfcLabel>();
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IList<IfcLabel> _PrefixTitles = new List<IfcLabel>();
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IList<IfcLabel> _SuffixTitles = new List<IfcLabel>();
	
		[DataMember(Order=6)] 
		IList<IfcActorRole> _Roles = new List<IfcActorRole>();
	
		[DataMember(Order=7)] 
		IList<IfcAddress> _Addresses = new List<IfcAddress>();
	
		[InverseProperty("ThePerson")] 
		ISet<IfcPersonAndOrganization> _EngagedIn = new HashSet<IfcPersonAndOrganization>();
	
	
		[Description("Identification of the person.")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("The name by which the family identity of the person may be recognized.\r\n<blockquo" +
	    "te class=\"note\">NOTE&nbsp; Depending on geographical location and culture, famil" +
	    "y name may appear either as the first or last component of a name.</blockquote>\r" +
	    "\n")]
		public IfcLabel? FamilyName { get { return this._FamilyName; } set { this._FamilyName = value;} }
	
		[Description(@"The name by which a person is known within a family and by which he or she may be familiarly recognized.
	<blockquote class=""note"">NOTE&nbsp; Depending on geographical location and culture, given name may appear either as the first or last component of a name.</blockquote>
	")]
		public IfcLabel? GivenName { get { return this._GivenName; } set { this._GivenName = value;} }
	
		[Description(@"Additional names given to a person that enable their identification apart from others who may have the same or similar family and given names.
	<blockquote class=""note"">NOTE&nbsp; Middle names are not normally used in familiar communication but may be asserted to provide additional 
	identification of a particular person if necessary. They may be particularly useful in situations where the person concerned has a 
	family name that occurs commonly in the geographical region.</blockquote>
	")]
		public IList<IfcLabel> MiddleNames { get { return this._MiddleNames; } }
	
		[Description("The word, or group of words, which specify the person\'s social and/or professiona" +
	    "l standing and appear before his/her names.")]
		public IList<IfcLabel> PrefixTitles { get { return this._PrefixTitles; } }
	
		[Description("The word, or group of words, which specify the person\'s social and/or professiona" +
	    "l standing and appear after his/her names.")]
		public IList<IfcLabel> SuffixTitles { get { return this._SuffixTitles; } }
	
		[Description("Roles played by the person.")]
		public IList<IfcActorRole> Roles { get { return this._Roles; } }
	
		[Description("Postal and telecommunication addresses of a person.\r\n<blockquote class=\"note\">NOT" +
	    "E&nbsp; A person may have several addresses.</small></blockquote>\r\n")]
		public IList<IfcAddress> Addresses { get { return this._Addresses; } }
	
		[Description("The inverse relationship to IfcPersonAndOrganization relationships in which IfcPe" +
	    "rson is engaged.")]
		public ISet<IfcPersonAndOrganization> EngagedIn { get { return this._EngagedIn; } }
	
	
	}
	
}

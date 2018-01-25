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
	[Guid("d66b760f-317a-43ff-a022-4394078ac555")]
	public partial class IfcPerson :
		BuildingSmart.IFC.IfcActorResource.IfcActorSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Id;
	
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
		public IfcIdentifier? Id { get { return this._Id; } set { this._Id = value;} }
	
		[Description(@"The name by which the family identity of the person may be recognized.
	<EPM-HTML><BLOCKQUOTE><FONT SIZE=""-1"">NOTE: Depending on geographical location and culture, family name may appear either as the first or last component of a name.</FONT></BLOCKQUOTE>
	</EPM-HTML>
	")]
		public IfcLabel? FamilyName { get { return this._FamilyName; } set { this._FamilyName = value;} }
	
		[Description(@"The name by which a person is known within a family and by which he or she may be familiarly recognized.
	<EPM-HTML>
	<BLOCKQUOTE><FONT SIZE=""-1"">NOTE: Depending on geographical location and culture, given name may appear either as the first or last component of a name.
	</FONT></BLOCKQUOTE>
	</EPM-HTML>
	")]
		public IfcLabel? GivenName { get { return this._GivenName; } set { this._GivenName = value;} }
	
		[Description(@"Additional names given to a person that enable their identification apart from others who may have the same or similar family and given names.
	<EPM-HTML>
	<BLOCKQUOTE><FONT SIZE=""-1"">NOTE: Middle names are not normally used in familiar communication but may be asserted to provide additional 
	identification of a particular person if necessary. They may be particularly useful in situations where the person concerned has a 
	family name that occurs commonly in the geographical region.
	</FONT></BLOCKQUOTE>
	</EPM-HTML>
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
	
		[Description("<EPM-HTML>Postal and telecommunication addresses of a person.\r\n<BLOCKQUOTE><FONT " +
	    "SIZE=\"-1\">NOTE - A person may have several addresses.\r\n</FONT></BLOCKQUOTE>\r\n</E" +
	    "PM-HTML>\r\n")]
		public IList<IfcAddress> Addresses { get { return this._Addresses; } }
	
		[Description("The inverse relationship to IfcPersonAndOrganization relationships in which IfcPe" +
	    "rson is engaged.")]
		public ISet<IfcPersonAndOrganization> EngagedIn { get { return this._EngagedIn; } }
	
	
	}
	
}

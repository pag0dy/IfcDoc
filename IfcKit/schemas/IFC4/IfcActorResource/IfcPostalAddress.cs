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
	[Guid("8a2c94a5-2ae6-4e52-b758-77ba7af2a9b1")]
	public partial class IfcPostalAddress : IfcAddress
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _InternalLocation;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IList<IfcLabel> _AddressLines = new List<IfcLabel>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _PostalBox;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _Town;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLabel? _Region;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcLabel? _PostalCode;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcLabel? _Country;
	
	
		[Description("An organization defined address for internal mail delivery.")]
		public IfcLabel? InternalLocation { get { return this._InternalLocation; } set { this._InternalLocation = value;} }
	
		[Description(@"<EPM-HTML>
	The postal address.
	<blockquote class=""note"">NOTE&nbsp; A postal address may occupy several lines (or elements) when recorded. 
	It is expected that normal usage will incorporate relevant elements of the following address concepts: 
	A location within a building (e.g. 3rd Floor) Building name (e.g. Interoperability House) Street number 
	(e.g. 6400) Street name (e.g. Alliance Boulevard). Typical content of address lines may vary in different 
	countries.</blockquote>
	</EPM-HTML>
	")]
		public IList<IfcLabel> AddressLines { get { return this._AddressLines; } }
	
		[Description("An address that is implied by an identifiable mail drop.")]
		public IfcLabel? PostalBox { get { return this._PostalBox; } set { this._PostalBox = value;} }
	
		[Description("The name of a town.")]
		public IfcLabel? Town { get { return this._Town; } set { this._Town = value;} }
	
		[Description("<EPM-HTML>\r\nThe name of a region.\r\n<blockquote class=\"note\">NOTE&nbsp; The counti" +
	    "es of the United Kingdom and the states of North America are examples of regions" +
	    ".</blockquote>\r\n</EPM-HTML>\r\n")]
		public IfcLabel? Region { get { return this._Region; } set { this._Region = value;} }
	
		[Description("The code that is used by the country\'s postal service.")]
		public IfcLabel? PostalCode { get { return this._PostalCode; } set { this._PostalCode = value;} }
	
		[Description("The name of a country.")]
		public IfcLabel? Country { get { return this._Country; } set { this._Country = value;} }
	
	
	}
	
}

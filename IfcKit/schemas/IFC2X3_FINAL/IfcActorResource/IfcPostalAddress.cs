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
	[Guid("c748bb72-f703-4164-9e21-35cb62e2ae1a")]
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
	
		[Description(@"The postal address.
	<EPM-HTML>
	<BLOCKQUOTE><FONT SIZE=""-1"">NOTE: A postal address may occupy several lines (or elements) when recorded. 
	It is expected that normal usage will incorporate relevant elements of the following address concepts: 
	A location within a building (e.g. 3rd Floor) Building name (e.g. Interoperability House) Street number 
	(e.g. 6400) Street name (e.g. Alliance Boulevard). Typical content of address lines may vary in different 
	countries.
	</FONT></BLOCKQUOTE>
	</EPM-HTML>
	")]
		public IList<IfcLabel> AddressLines { get { return this._AddressLines; } }
	
		[Description("An address that is implied by an identifiable mail drop.")]
		public IfcLabel? PostalBox { get { return this._PostalBox; } set { this._PostalBox = value;} }
	
		[Description("The name of a town.")]
		public IfcLabel? Town { get { return this._Town; } set { this._Town = value;} }
	
		[Description("The name of a region.\r\n<EPM-HTML>\r\n<BLOCKQUOTE><FONT SIZE=\"-1\">NOTE: The counties" +
	    " of the United Kingdom and the states of North America are examples of regions.\r" +
	    "\n</FONT></BLOCKQUOTE>\r\n</EPM-HTML>\r\n")]
		public IfcLabel? Region { get { return this._Region; } set { this._Region = value;} }
	
		[Description("The code that is used by the country\'s postal service.")]
		public IfcLabel? PostalCode { get { return this._PostalCode; } set { this._PostalCode = value;} }
	
		[Description("The name of a country.")]
		public IfcLabel? Country { get { return this._Country; } set { this._Country = value;} }
	
	
	}
	
}

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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcActorResource
{
	public partial class IfcPostalAddress : IfcAddress
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("An organization defined address for internal mail delivery.")]
		public IfcLabel? InternalLocation { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The postal address.  <blockquote class=\"note\">NOTE&nbsp; A postal address may occupy several lines (or elements) when recorded.   It is expected that normal usage will incorporate relevant elements of the following address concepts:   A location within a building (e.g. 3rd Floor) Building name (e.g. Interoperability House) Street number   (e.g. 6400) Street name (e.g. Alliance Boulevard). Typical content of address lines may vary in different   countries.</blockquote>  ")]
		[MinLength(1)]
		public IList<IfcLabel> AddressLines { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("An address that is implied by an identifiable mail drop.")]
		public IfcLabel? PostalBox { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The name of a town.")]
		public IfcLabel? Town { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The name of a region.  <blockquote class=\"note\">NOTE&nbsp; The counties of the United Kingdom and the states of North America are examples of regions.</blockquote>  ")]
		public IfcLabel? Region { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("The code that is used by the country's postal service.")]
		public IfcLabel? PostalCode { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("The name of a country.")]
		public IfcLabel? Country { get; set; }
	
	
		public IfcPostalAddress(IfcAddressTypeEnum? __Purpose, IfcText? __Description, IfcLabel? __UserDefinedPurpose, IfcLabel? __InternalLocation, IfcLabel[] __AddressLines, IfcLabel? __PostalBox, IfcLabel? __Town, IfcLabel? __Region, IfcLabel? __PostalCode, IfcLabel? __Country)
			: base(__Purpose, __Description, __UserDefinedPurpose)
		{
			this.InternalLocation = __InternalLocation;
			this.AddressLines = new List<IfcLabel>(__AddressLines);
			this.PostalBox = __PostalBox;
			this.Town = __Town;
			this.Region = __Region;
			this.PostalCode = __PostalCode;
			this.Country = __Country;
		}
	
	
	}
	
}

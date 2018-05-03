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
	public partial class IfcTelecomAddress : IfcAddress
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The list of telephone numbers at which telephone messages may be received.")]
		[MinLength(1)]
		public IList<IfcLabel> TelephoneNumbers { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The list of fax numbers at which fax messages may be received.")]
		[MinLength(1)]
		public IList<IfcLabel> FacsimileNumbers { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The pager number at which paging messages may be received.")]
		public IfcLabel? PagerNumber { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The list of Email addresses at which Email messages may be received.")]
		[MinLength(1)]
		public IList<IfcLabel> ElectronicMailAddresses { get; protected set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The world wide web address at which the preliminary page of information for the person or organization can be located.  <blockquote class=\"note\">NOTE&nbsp; Information on the world wide web for a person or organization may be separated   into a number of pages and across a number of host sites, all of which may be linked together. It is assumed that   all such information may be referenced from a single page that is termed the home page for that person or organization.</blockquote>")]
		public IfcURIReference? WWWHomePageURL { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("IDs or addresses for any other means of telecommunication, for example instant messaging, voice-over-IP, or file transfer protocols. The communication protocol is indicated by the URI value with scheme designations such as irc:, sip:, or ftp:.")]
		[MinLength(1)]
		public IList<IfcURIReference> MessagingIDs { get; protected set; }
	
	
		public IfcTelecomAddress(IfcAddressTypeEnum? __Purpose, IfcText? __Description, IfcLabel? __UserDefinedPurpose, IfcLabel[] __TelephoneNumbers, IfcLabel[] __FacsimileNumbers, IfcLabel? __PagerNumber, IfcLabel[] __ElectronicMailAddresses, IfcURIReference? __WWWHomePageURL, IfcURIReference[] __MessagingIDs)
			: base(__Purpose, __Description, __UserDefinedPurpose)
		{
			this.TelephoneNumbers = new List<IfcLabel>(__TelephoneNumbers);
			this.FacsimileNumbers = new List<IfcLabel>(__FacsimileNumbers);
			this.PagerNumber = __PagerNumber;
			this.ElectronicMailAddresses = new List<IfcLabel>(__ElectronicMailAddresses);
			this.WWWHomePageURL = __WWWHomePageURL;
			this.MessagingIDs = new List<IfcURIReference>(__MessagingIDs);
		}
	
	
	}
	
}

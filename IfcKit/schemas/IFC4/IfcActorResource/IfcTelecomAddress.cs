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
	[Guid("dd829d63-2572-480c-8a2d-ccbe3578cd7e")]
	public partial class IfcTelecomAddress : IfcAddress
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IList<IfcLabel> _TelephoneNumbers = new List<IfcLabel>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IList<IfcLabel> _FacsimileNumbers = new List<IfcLabel>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _PagerNumber;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IList<IfcLabel> _ElectronicMailAddresses = new List<IfcLabel>();
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcURIReference? _WWWHomePageURL;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IList<IfcURIReference> _MessagingIDs = new List<IfcURIReference>();
	
	
		[Description("The list of telephone numbers at which telephone messages may be received.")]
		public IList<IfcLabel> TelephoneNumbers { get { return this._TelephoneNumbers; } }
	
		[Description("The list of fax numbers at which fax messages may be received.")]
		public IList<IfcLabel> FacsimileNumbers { get { return this._FacsimileNumbers; } }
	
		[Description("The pager number at which paging messages may be received.")]
		public IfcLabel? PagerNumber { get { return this._PagerNumber; } set { this._PagerNumber = value;} }
	
		[Description("The list of Email addresses at which Email messages may be received.")]
		public IList<IfcLabel> ElectronicMailAddresses { get { return this._ElectronicMailAddresses; } }
	
		[Description(@"The world wide web address at which the preliminary page of information for the person or organization can be located.
	<blockquote class=""note"">NOTE&nbsp; Information on the world wide web for a person or organization may be separated 
	into a number of pages and across a number of host sites, all of which may be linked together. It is assumed that 
	all such information may be referenced from a single page that is termed the home page for that person or organization.</blockquote>")]
		public IfcURIReference? WWWHomePageURL { get { return this._WWWHomePageURL; } set { this._WWWHomePageURL = value;} }
	
		[Description("IDs or addresses for any other means of telecommunication, for example instant me" +
	    "ssaging, voice-over-IP, or file transfer protocols. The communication protocol i" +
	    "s indicated by the URI value with scheme designations such as irc:, sip:, or ftp" +
	    ":.")]
		public IList<IfcURIReference> MessagingIDs { get { return this._MessagingIDs; } }
	
	
	}
	
}

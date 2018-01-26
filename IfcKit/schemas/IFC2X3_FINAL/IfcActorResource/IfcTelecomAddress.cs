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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcActorResource
{
	[Guid("59fd10bd-08d3-457d-a2c7-4ae58c749ed2")]
	public partial class IfcTelecomAddress : IfcAddress
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[MinLength(1)]
		IList<IfcLabel> _TelephoneNumbers = new List<IfcLabel>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[MinLength(1)]
		IList<IfcLabel> _FacsimileNumbers = new List<IfcLabel>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _PagerNumber;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[MinLength(1)]
		IList<IfcLabel> _ElectronicMailAddresses = new List<IfcLabel>();
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLabel? _WWWHomePageURL;
	
	
		public IfcTelecomAddress()
		{
		}
	
		public IfcTelecomAddress(IfcAddressTypeEnum? __Purpose, IfcText? __Description, IfcLabel? __UserDefinedPurpose, IfcLabel[] __TelephoneNumbers, IfcLabel[] __FacsimileNumbers, IfcLabel? __PagerNumber, IfcLabel[] __ElectronicMailAddresses, IfcLabel? __WWWHomePageURL)
			: base(__Purpose, __Description, __UserDefinedPurpose)
		{
			this._TelephoneNumbers = new List<IfcLabel>(__TelephoneNumbers);
			this._FacsimileNumbers = new List<IfcLabel>(__FacsimileNumbers);
			this._PagerNumber = __PagerNumber;
			this._ElectronicMailAddresses = new List<IfcLabel>(__ElectronicMailAddresses);
			this._WWWHomePageURL = __WWWHomePageURL;
		}
	
		[Description("The list of telephone numbers at which telephone messages may be received.")]
		public IList<IfcLabel> TelephoneNumbers { get { return this._TelephoneNumbers; } }
	
		[Description("The list of fax numbers at which fax messages may be received.")]
		public IList<IfcLabel> FacsimileNumbers { get { return this._FacsimileNumbers; } }
	
		[Description("The pager number at which paging messages may be received.")]
		public IfcLabel? PagerNumber { get { return this._PagerNumber; } set { this._PagerNumber = value;} }
	
		[Description("The list of Email addresses at which Email messages may be received.")]
		public IList<IfcLabel> ElectronicMailAddresses { get { return this._ElectronicMailAddresses; } }
	
		[Description(@"The world wide web address at which the preliminary page of information for the person or organization can be located.
	<EPM-HTML>
	<BLOCKQUOTE><FONT SIZE=""-1"">NOTE: Information on the world wide web for a person or organization may be separated 
	into a number of pages and across a number of host sites, all of which may be linked together. It is assumed that 
	all such information may be referenced from a single page that is termed the home page for that person or organization.
	</FONT></BLOCKQUOTE>
	</EPM-HTML>")]
		public IfcLabel? WWWHomePageURL { get { return this._WWWHomePageURL; } set { this._WWWHomePageURL = value;} }
	
	
	}
	
}

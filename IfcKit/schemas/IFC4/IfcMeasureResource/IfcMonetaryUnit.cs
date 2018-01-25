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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;

namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("0671cb13-dc5d-4349-956e-d3344b3f2781")]
	public partial class IfcMonetaryUnit :
		BuildingSmart.IFC.IfcMeasureResource.IfcUnit
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Currency;
	
	
		[Description(@"Code or name of the currency.  Permissible values are the three-letter alphabetic currency codes as per <a target=""_top"" href=""http://www.iso.org/iso/support/faqs/faqs_widely_used_standards/widely_used_standards_other/currency_codes/currency_codes_list-1.htm"">ISO 4217</a>, for example CNY, EUR, GBP, JPY, USD.")]
		public IfcLabel Currency { get { return this._Currency; } set { this._Currency = value;} }
	
	
	}
	
}

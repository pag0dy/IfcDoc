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


namespace BuildingSmart.IFC.IfcMeasureResource
{
	public partial class IfcMonetaryUnit :
		BuildingSmart.IFC.IfcMeasureResource.IfcUnit
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Code or name of the currency.  Permissible values are the three-letter alphabetic currency codes as per <a target=\"_top\" href=\"http://www.iso.org/iso/support/faqs/faqs_widely_used_standards/widely_used_standards_other/currency_codes/currency_codes_list-1.htm\">ISO 4217</a>, for example CNY, EUR, GBP, JPY, USD.")]
		[Required()]
		public IfcLabel Currency { get; set; }
	
	
		public IfcMonetaryUnit(IfcLabel __Currency)
		{
			this.Currency = __Currency;
		}
	
	
	}
	
}

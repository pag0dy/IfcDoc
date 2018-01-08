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


namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("88524ab1-815c-4457-979a-bbc311fb5928")]
	public partial class IfcMonetaryUnit :
		BuildingSmart.IFC.IfcMeasureResource.IfcUnit
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcCurrencyEnum _Currency;
	
	
		[Description("The international enumeration name of the currency.")]
		public IfcCurrencyEnum Currency { get { return this._Currency; } set { this._Currency = value;} }
	
	
	}
	
}

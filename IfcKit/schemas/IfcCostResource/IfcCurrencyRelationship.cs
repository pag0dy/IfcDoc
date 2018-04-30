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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	public partial class IfcCurrencyRelationship
	{
		[DataMember(Order = 0)] 
		[Description("The monetary unit from which an exchange is derived. For instance, in the case of a conversion from GBP to USD, the relating monetary unit is GBP.")]
		[Required()]
		public IfcMonetaryUnit RelatingMonetaryUnit { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The monetary unit to which an exchange results. For instance, in the case of a conversion from GBP to USD, the related monetary unit is USD.")]
		[Required()]
		public IfcMonetaryUnit RelatedMonetaryUnit { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The currently agreed ratio of the amount of a related monetary unit that is equivalent to a unit amount of the relating monetary unit in a currency relationship. For instance, in the case of a conversion from GBP to USD, the value of the exchange rate may be 1.486 (USD) : 1 (GBP).")]
		[Required()]
		public IfcPositiveRatioMeasure ExchangeRate { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The date and time at which an exchange rate applies.")]
		[Required()]
		public IfcDateAndTime RateDateTime { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The source from which an exchange rate is obtained.")]
		public IfcLibraryInformation RateSource { get; set; }
	
	
		public IfcCurrencyRelationship(IfcMonetaryUnit __RelatingMonetaryUnit, IfcMonetaryUnit __RelatedMonetaryUnit, IfcPositiveRatioMeasure __ExchangeRate, IfcDateAndTime __RateDateTime, IfcLibraryInformation __RateSource)
		{
			this.RelatingMonetaryUnit = __RelatingMonetaryUnit;
			this.RelatedMonetaryUnit = __RelatedMonetaryUnit;
			this.ExchangeRate = __ExchangeRate;
			this.RateDateTime = __RateDateTime;
			this.RateSource = __RateSource;
		}
	
	
	}
	
}

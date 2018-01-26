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
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	[Guid("9369fbbe-c581-4604-aa77-92582aa9453c")]
	public partial class IfcCurrencyRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcMonetaryUnit _RelatingMonetaryUnit;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcMonetaryUnit _RelatedMonetaryUnit;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveRatioMeasure _ExchangeRate;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcDateTime? _RateDateTime;
	
		[DataMember(Order=4)] 
		[XmlElement]
		IfcLibraryInformation _RateSource;
	
	
		public IfcCurrencyRelationship()
		{
		}
	
		public IfcCurrencyRelationship(IfcLabel? __Name, IfcText? __Description, IfcMonetaryUnit __RelatingMonetaryUnit, IfcMonetaryUnit __RelatedMonetaryUnit, IfcPositiveRatioMeasure __ExchangeRate, IfcDateTime? __RateDateTime, IfcLibraryInformation __RateSource)
			: base(__Name, __Description)
		{
			this._RelatingMonetaryUnit = __RelatingMonetaryUnit;
			this._RelatedMonetaryUnit = __RelatedMonetaryUnit;
			this._ExchangeRate = __ExchangeRate;
			this._RateDateTime = __RateDateTime;
			this._RateSource = __RateSource;
		}
	
		[Description("The monetary unit from which an exchange is derived. For instance, in the case of" +
	    " a conversion from GBP to USD, the relating monetary unit is GBP.")]
		public IfcMonetaryUnit RelatingMonetaryUnit { get { return this._RelatingMonetaryUnit; } set { this._RelatingMonetaryUnit = value;} }
	
		[Description("The monetary unit to which an exchange results. For instance, in the case of a co" +
	    "nversion from GBP to USD, the related monetary unit is USD.")]
		public IfcMonetaryUnit RelatedMonetaryUnit { get { return this._RelatedMonetaryUnit; } set { this._RelatedMonetaryUnit = value;} }
	
		[Description(@"The currently agreed ratio of the amount of a related monetary unit that is equivalent to a unit amount of the relating monetary unit in a currency relationship. For instance, in the case of a conversion from GBP to USD, the value of the exchange rate may be 1.486 (USD) : 1 (GBP).")]
		public IfcPositiveRatioMeasure ExchangeRate { get { return this._ExchangeRate; } set { this._ExchangeRate = value;} }
	
		[Description("The date and time at which an exchange rate applies.\r\n<blockquote class=\"change-i" +
	    "fc2x4\">IFC4 CHANGE Type changed from IfcDateTimeSelect. Attribute made optional." +
	    "</blockquote>  \r\n")]
		public IfcDateTime? RateDateTime { get { return this._RateDateTime; } set { this._RateDateTime = value;} }
	
		[Description("The source from which an exchange rate is obtained.")]
		public IfcLibraryInformation RateSource { get { return this._RateSource; } set { this._RateSource = value;} }
	
	
	}
	
}

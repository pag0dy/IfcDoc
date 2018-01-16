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
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	[Guid("755460d3-19f8-4b52-be81-595f356fadaa")]
	public partial class IfcProductsOfCombustionProperties : IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcSpecificHeatCapacityMeasure? _SpecificHeatCapacity;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _N20Content;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _COContent;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _CO2Content;
	
	
		[Description("Specific heat of the products of combustion: heat energy absorbed per\r\ntemperatur" +
	    "e unit. Usually measured in [J/kg K].")]
		public IfcSpecificHeatCapacityMeasure? SpecificHeatCapacity { get { return this._SpecificHeatCapacity; } set { this._SpecificHeatCapacity = value;} }
	
		[Description("<EPM-HTML>\r\nNitrous Oxide (N<sub>2</sub>O) content of the products of combustion." +
	    " This is measured in weight of N<sub>2</sub>O per unit weight and is therefore u" +
	    "nitless.\r\n</EPM-HTML>")]
		public IfcPositiveRatioMeasure? N20Content { get { return this._N20Content; } set { this._N20Content = value;} }
	
		[Description("Carbon monoxide (CO) content of the products of combustion.This is measured in we" +
	    "ight of CO per unit weight and is therefore unitless. ")]
		public IfcPositiveRatioMeasure? COContent { get { return this._COContent; } set { this._COContent = value;} }
	
		[Description("<EPM-HTML>\r\nCarbon Dioxide (CO<sub>2</sub>) content of the products of combustion" +
	    ". This is measured in weight of CO<sub>2</sub> per unit weight and is therefore " +
	    "unitless.\r\n</EPM-HTML>")]
		public IfcPositiveRatioMeasure? CO2Content { get { return this._CO2Content; } set { this._CO2Content = value;} }
	
	
	}
	
}

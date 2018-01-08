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
	[Guid("9d6fd7bc-89ce-47f4-9ad0-b62095ab3561")]
	public partial class IfcHygroscopicMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _UpperVaporResistanceFactor;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _LowerVaporResistanceFactor;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcIsothermalMoistureCapacityMeasure? _IsothermalMoistureCapacity;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcVaporPermeabilityMeasure? _VaporPermeability;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcMoistureDiffusivityMeasure? _MoistureDiffusivity;
	
	
		[Description("The vapor permeability relationship of air/material (typically value > 1), measur" +
	    "ed in high relative humidity (typically in 95/50 % RH).")]
		public IfcPositiveRatioMeasure? UpperVaporResistanceFactor { get { return this._UpperVaporResistanceFactor; } set { this._UpperVaporResistanceFactor = value;} }
	
		[Description("The vapor permeability relationship of air/material (typically value > 1), measur" +
	    "ed in low relative humidity (typically in 0/50 % RH).")]
		public IfcPositiveRatioMeasure? LowerVaporResistanceFactor { get { return this._LowerVaporResistanceFactor; } set { this._LowerVaporResistanceFactor = value;} }
	
		[Description("Based on water vapor density, usually measured in [m3/ kg].")]
		public IfcIsothermalMoistureCapacityMeasure? IsothermalMoistureCapacity { get { return this._IsothermalMoistureCapacity; } set { this._IsothermalMoistureCapacity = value;} }
	
		[Description("Usually measured in [kg/s m Pa].")]
		public IfcVaporPermeabilityMeasure? VaporPermeability { get { return this._VaporPermeability; } set { this._VaporPermeability = value;} }
	
		[Description("Usually measured in [m3/s].")]
		public IfcMoistureDiffusivityMeasure? MoistureDiffusivity { get { return this._MoistureDiffusivity; } set { this._MoistureDiffusivity = value;} }
	
	
	}
	
}

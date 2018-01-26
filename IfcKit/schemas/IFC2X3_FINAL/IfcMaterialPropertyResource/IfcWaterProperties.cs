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

using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	[Guid("fd73f8c4-cc6c-47f6-9930-e33a360c761c")]
	public partial class IfcWaterProperties : IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		Boolean? _IsPotable;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcIonConcentrationMeasure? _Hardness;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcIonConcentrationMeasure? _AlkalinityConcentration;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcIonConcentrationMeasure? _AcidityConcentration;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _ImpuritiesContent;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcPHMeasure? _PHLevel;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _DissolvedSolidsContent;
	
	
		public IfcWaterProperties()
		{
		}
	
		public IfcWaterProperties(IfcMaterial __Material, Boolean? __IsPotable, IfcIonConcentrationMeasure? __Hardness, IfcIonConcentrationMeasure? __AlkalinityConcentration, IfcIonConcentrationMeasure? __AcidityConcentration, IfcNormalisedRatioMeasure? __ImpuritiesContent, IfcPHMeasure? __PHLevel, IfcNormalisedRatioMeasure? __DissolvedSolidsContent)
			: base(__Material)
		{
			this._IsPotable = __IsPotable;
			this._Hardness = __Hardness;
			this._AlkalinityConcentration = __AlkalinityConcentration;
			this._AcidityConcentration = __AcidityConcentration;
			this._ImpuritiesContent = __ImpuritiesContent;
			this._PHLevel = __PHLevel;
			this._DissolvedSolidsContent = __DissolvedSolidsContent;
		}
	
		[Description("If TRUE, then the water is considered potable.")]
		public Boolean? IsPotable { get { return this._IsPotable; } set { this._IsPotable = value;} }
	
		[Description("Water hardness as positive, multivalent ion concentration in the water (usually c" +
	    "oncentrations of calcium and magnesium ions in terms of calcium carbonate).")]
		public IfcIonConcentrationMeasure? Hardness { get { return this._Hardness; } set { this._Hardness = value;} }
	
		[Description("<EPM-HTML>\r\nMaximum alkalinity concentration (maximum sum of concentrations of ea" +
	    "ch of the negative ions substances measured as CaCO<sub>3</sub>).\r\n</EPM-HTML>")]
		public IfcIonConcentrationMeasure? AlkalinityConcentration { get { return this._AlkalinityConcentration; } set { this._AlkalinityConcentration = value;} }
	
		[Description("<EPM-HTML>\r\nMaximum CaCO<sub>3</sub> equivalent that would neutralize the acid.\r\n" +
	    "</EPM-HTML>")]
		public IfcIonConcentrationMeasure? AcidityConcentration { get { return this._AcidityConcentration; } set { this._AcidityConcentration = value;} }
	
		[Description("Fraction of impurities such as dust to the total amount of water. This is measure" +
	    "d in weight of impurities per weight of water and is therefore unitless.")]
		public IfcNormalisedRatioMeasure? ImpuritiesContent { get { return this._ImpuritiesContent; } set { this._ImpuritiesContent = value;} }
	
		[Description("Maximum water ph in a range from 0-14.")]
		public IfcPHMeasure? PHLevel { get { return this._PHLevel; } set { this._PHLevel = value;} }
	
		[Description("Fraction of the dissolved solids to the total amount of water. This is measured i" +
	    "n weight of dissolved solids per weight of water and is therefore unitless.")]
		public IfcNormalisedRatioMeasure? DissolvedSolidsContent { get { return this._DissolvedSolidsContent; } set { this._DissolvedSolidsContent = value;} }
	
	
	}
	
}

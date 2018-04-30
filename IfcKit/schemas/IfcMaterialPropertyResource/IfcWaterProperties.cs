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

using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	public partial class IfcWaterProperties : IfcMaterialProperties
	{
		[DataMember(Order = 0)] 
		[Description("If TRUE, then the water is considered potable.")]
		public Boolean? IsPotable { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Water hardness as positive, multivalent ion concentration in the water (usually concentrations of calcium and magnesium ions in terms of calcium carbonate).")]
		public IfcIonConcentrationMeasure? Hardness { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  Maximum alkalinity concentration (maximum sum of concentrations of each of the negative ions substances measured as CaCO<sub>3</sub>).  </EPM-HTML>")]
		public IfcIonConcentrationMeasure? AlkalinityConcentration { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  Maximum CaCO<sub>3</sub> equivalent that would neutralize the acid.  </EPM-HTML>")]
		public IfcIonConcentrationMeasure? AcidityConcentration { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Fraction of impurities such as dust to the total amount of water. This is measured in weight of impurities per weight of water and is therefore unitless.")]
		public IfcNormalisedRatioMeasure? ImpuritiesContent { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Maximum water ph in a range from 0-14.")]
		public IfcPHMeasure? PHLevel { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Fraction of the dissolved solids to the total amount of water. This is measured in weight of dissolved solids per weight of water and is therefore unitless.")]
		public IfcNormalisedRatioMeasure? DissolvedSolidsContent { get; set; }
	
	
		public IfcWaterProperties(IfcMaterial __Material, Boolean? __IsPotable, IfcIonConcentrationMeasure? __Hardness, IfcIonConcentrationMeasure? __AlkalinityConcentration, IfcIonConcentrationMeasure? __AcidityConcentration, IfcNormalisedRatioMeasure? __ImpuritiesContent, IfcPHMeasure? __PHLevel, IfcNormalisedRatioMeasure? __DissolvedSolidsContent)
			: base(__Material)
		{
			this.IsPotable = __IsPotable;
			this.Hardness = __Hardness;
			this.AlkalinityConcentration = __AlkalinityConcentration;
			this.AcidityConcentration = __AcidityConcentration;
			this.ImpuritiesContent = __ImpuritiesContent;
			this.PHLevel = __PHLevel;
			this.DissolvedSolidsContent = __DissolvedSolidsContent;
		}
	
	
	}
	
}

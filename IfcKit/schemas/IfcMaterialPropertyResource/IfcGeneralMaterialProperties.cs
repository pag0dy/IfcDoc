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
	public partial class IfcGeneralMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Molecular weight of material (typically gas), measured in g/mole.")]
		public IfcMolecularWeightMeasure? MolecularWeight { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The void fraction of the total volume occupied by material (Vbr - Vnet)/Vbr [m3/m3].")]
		public IfcNormalisedRatioMeasure? Porosity { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Material mass density, usually measured in [kg/m3].")]
		public IfcMassDensityMeasure? MassDensity { get; set; }
	
	
		public IfcGeneralMaterialProperties(IfcMaterial __Material, IfcMolecularWeightMeasure? __MolecularWeight, IfcNormalisedRatioMeasure? __Porosity, IfcMassDensityMeasure? __MassDensity)
			: base(__Material)
		{
			this.MolecularWeight = __MolecularWeight;
			this.Porosity = __Porosity;
			this.MassDensity = __MassDensity;
		}
	
	
	}
	
}

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
	[Guid("0e388c2a-d59a-473e-a291-3f4599180c8b")]
	public partial class IfcGeneralMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcMolecularWeightMeasure? _MolecularWeight;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _Porosity;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcMassDensityMeasure? _MassDensity;
	
	
		public IfcGeneralMaterialProperties()
		{
		}
	
		public IfcGeneralMaterialProperties(IfcMaterial __Material, IfcMolecularWeightMeasure? __MolecularWeight, IfcNormalisedRatioMeasure? __Porosity, IfcMassDensityMeasure? __MassDensity)
			: base(__Material)
		{
			this._MolecularWeight = __MolecularWeight;
			this._Porosity = __Porosity;
			this._MassDensity = __MassDensity;
		}
	
		[Description("Molecular weight of material (typically gas), measured in g/mole.")]
		public IfcMolecularWeightMeasure? MolecularWeight { get { return this._MolecularWeight; } set { this._MolecularWeight = value;} }
	
		[Description("The void fraction of the total volume occupied by material (Vbr - Vnet)/Vbr [m3/m" +
	    "3].")]
		public IfcNormalisedRatioMeasure? Porosity { get { return this._Porosity; } set { this._Porosity = value;} }
	
		[Description("Material mass density, usually measured in [kg/m3].")]
		public IfcMassDensityMeasure? MassDensity { get { return this._MassDensity; } set { this._MassDensity = value;} }
	
	
	}
	
}

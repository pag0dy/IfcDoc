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
	[Guid("c750da07-d276-413b-b77d-f5072eed05bc")]
	public partial class IfcMechanicalConcreteMaterialProperties : IfcMechanicalMaterialProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPressureMeasure? _CompressiveStrength;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MaxAggregateSize;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _AdmixturesDescription;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcText? _Workability;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _ProtectivePoreRatio;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcText? _WaterImpermeability;
	
	
		public IfcMechanicalConcreteMaterialProperties()
		{
		}
	
		public IfcMechanicalConcreteMaterialProperties(IfcMaterial __Material, IfcDynamicViscosityMeasure? __DynamicViscosity, IfcModulusOfElasticityMeasure? __YoungModulus, IfcModulusOfElasticityMeasure? __ShearModulus, IfcPositiveRatioMeasure? __PoissonRatio, IfcThermalExpansionCoefficientMeasure? __ThermalExpansionCoefficient, IfcPressureMeasure? __CompressiveStrength, IfcPositiveLengthMeasure? __MaxAggregateSize, IfcText? __AdmixturesDescription, IfcText? __Workability, IfcNormalisedRatioMeasure? __ProtectivePoreRatio, IfcText? __WaterImpermeability)
			: base(__Material, __DynamicViscosity, __YoungModulus, __ShearModulus, __PoissonRatio, __ThermalExpansionCoefficient)
		{
			this._CompressiveStrength = __CompressiveStrength;
			this._MaxAggregateSize = __MaxAggregateSize;
			this._AdmixturesDescription = __AdmixturesDescription;
			this._Workability = __Workability;
			this._ProtectivePoreRatio = __ProtectivePoreRatio;
			this._WaterImpermeability = __WaterImpermeability;
		}
	
		[Description("The compressive strength of the concrete.")]
		public IfcPressureMeasure? CompressiveStrength { get { return this._CompressiveStrength; } set { this._CompressiveStrength = value;} }
	
		[Description("The maximum aggregate size of the concrete.")]
		public IfcPositiveLengthMeasure? MaxAggregateSize { get { return this._MaxAggregateSize; } set { this._MaxAggregateSize = value;} }
	
		[Description("Description of the admixtures added to the concrete mix.")]
		public IfcText? AdmixturesDescription { get { return this._AdmixturesDescription; } set { this._AdmixturesDescription = value;} }
	
		[Description("Description of the workability of the fresh concrete defined according to local s" +
	    "tandards.")]
		public IfcText? Workability { get { return this._Workability; } set { this._Workability = value;} }
	
		[Description("The protective pore ratio indicating the frost-resistance of the concrete. ")]
		public IfcNormalisedRatioMeasure? ProtectivePoreRatio { get { return this._ProtectivePoreRatio; } set { this._ProtectivePoreRatio = value;} }
	
		[Description("Description of the water impermeability denoting the water repelling properties.")]
		public IfcText? WaterImpermeability { get { return this._WaterImpermeability; } set { this._WaterImpermeability = value;} }
	
	
	}
	
}

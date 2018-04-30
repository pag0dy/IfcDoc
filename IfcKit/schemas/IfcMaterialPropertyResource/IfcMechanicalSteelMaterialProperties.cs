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
	public partial class IfcMechanicalSteelMaterialProperties : IfcMechanicalMaterialProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A measure of the yield stress (or characteristic 0.2 percent proof stress) of the material. ")]
		public IfcPressureMeasure? YieldStress { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("A measure of the ultimate stress of the material. ")]
		public IfcPressureMeasure? UltimateStress { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("A measure of the (engineering) strain at the state of ultimate stress of the material.")]
		public IfcPositiveRatioMeasure? UltimateStrain { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("A measure of the hardening module of the material (slope of stress versus strain curve after yield range). ")]
		public IfcModulusOfElasticityMeasure? HardeningModule { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("A measure of the proportional stress of the material. It describes the stress before the first plastic deformation occurs and is commonly measured at a deformation of 0.01%. ")]
		public IfcPressureMeasure? ProportionalStress { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("A measure of the permanent displacement, as in slip or twinning, which remains after the stress has been removed. Currently applied to a strain of 0.2% proportional stress of the material.")]
		public IfcPositiveRatioMeasure? PlasticStrain { get; set; }
	
		[DataMember(Order = 6)] 
		[Description("Measures of decrease in stress over long time intervals resulting from plastic flow. Different relaxation values for different initial stress levels for a material may be given.")]
		[MinLength(1)]
		public ISet<IfcRelaxation> Relaxations { get; protected set; }
	
	
		public IfcMechanicalSteelMaterialProperties(IfcMaterial __Material, IfcDynamicViscosityMeasure? __DynamicViscosity, IfcModulusOfElasticityMeasure? __YoungModulus, IfcModulusOfElasticityMeasure? __ShearModulus, IfcPositiveRatioMeasure? __PoissonRatio, IfcThermalExpansionCoefficientMeasure? __ThermalExpansionCoefficient, IfcPressureMeasure? __YieldStress, IfcPressureMeasure? __UltimateStress, IfcPositiveRatioMeasure? __UltimateStrain, IfcModulusOfElasticityMeasure? __HardeningModule, IfcPressureMeasure? __ProportionalStress, IfcPositiveRatioMeasure? __PlasticStrain, IfcRelaxation[] __Relaxations)
			: base(__Material, __DynamicViscosity, __YoungModulus, __ShearModulus, __PoissonRatio, __ThermalExpansionCoefficient)
		{
			this.YieldStress = __YieldStress;
			this.UltimateStress = __UltimateStress;
			this.UltimateStrain = __UltimateStrain;
			this.HardeningModule = __HardeningModule;
			this.ProportionalStress = __ProportionalStress;
			this.PlasticStrain = __PlasticStrain;
			this.Relaxations = new HashSet<IfcRelaxation>(__Relaxations);
		}
	
	
	}
	
}

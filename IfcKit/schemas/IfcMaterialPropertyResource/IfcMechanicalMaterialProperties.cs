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
	public partial class IfcMechanicalMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A measure of the viscous resistance of the material. ")]
		public IfcDynamicViscosityMeasure? DynamicViscosity { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("A measure of the Youngs modulus of elasticity of the material. ")]
		public IfcModulusOfElasticityMeasure? YoungModulus { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("A measure of the shear modulus of elasticity of the material. ")]
		public IfcModulusOfElasticityMeasure? ShearModulus { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("A measure of the lateral deformations in the elastic range.")]
		public IfcPositiveRatioMeasure? PoissonRatio { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("A measure of the expansion coefficient for warming up the material about one Kelvin. ")]
		public IfcThermalExpansionCoefficientMeasure? ThermalExpansionCoefficient { get; set; }
	
	
		public IfcMechanicalMaterialProperties(IfcMaterial __Material, IfcDynamicViscosityMeasure? __DynamicViscosity, IfcModulusOfElasticityMeasure? __YoungModulus, IfcModulusOfElasticityMeasure? __ShearModulus, IfcPositiveRatioMeasure? __PoissonRatio, IfcThermalExpansionCoefficientMeasure? __ThermalExpansionCoefficient)
			: base(__Material)
		{
			this.DynamicViscosity = __DynamicViscosity;
			this.YoungModulus = __YoungModulus;
			this.ShearModulus = __ShearModulus;
			this.PoissonRatio = __PoissonRatio;
			this.ThermalExpansionCoefficient = __ThermalExpansionCoefficient;
		}
	
	
	}
	
}

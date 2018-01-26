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
	[Guid("741342c6-3f20-4749-9567-54dfd3bdf47d")]
	public partial class IfcMechanicalMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcDynamicViscosityMeasure? _DynamicViscosity;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcModulusOfElasticityMeasure? _YoungModulus;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcModulusOfElasticityMeasure? _ShearModulus;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _PoissonRatio;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcThermalExpansionCoefficientMeasure? _ThermalExpansionCoefficient;
	
	
		public IfcMechanicalMaterialProperties()
		{
		}
	
		public IfcMechanicalMaterialProperties(IfcMaterial __Material, IfcDynamicViscosityMeasure? __DynamicViscosity, IfcModulusOfElasticityMeasure? __YoungModulus, IfcModulusOfElasticityMeasure? __ShearModulus, IfcPositiveRatioMeasure? __PoissonRatio, IfcThermalExpansionCoefficientMeasure? __ThermalExpansionCoefficient)
			: base(__Material)
		{
			this._DynamicViscosity = __DynamicViscosity;
			this._YoungModulus = __YoungModulus;
			this._ShearModulus = __ShearModulus;
			this._PoissonRatio = __PoissonRatio;
			this._ThermalExpansionCoefficient = __ThermalExpansionCoefficient;
		}
	
		[Description("A measure of the viscous resistance of the material. ")]
		public IfcDynamicViscosityMeasure? DynamicViscosity { get { return this._DynamicViscosity; } set { this._DynamicViscosity = value;} }
	
		[Description("A measure of the Youngs modulus of elasticity of the material. ")]
		public IfcModulusOfElasticityMeasure? YoungModulus { get { return this._YoungModulus; } set { this._YoungModulus = value;} }
	
		[Description("A measure of the shear modulus of elasticity of the material. ")]
		public IfcModulusOfElasticityMeasure? ShearModulus { get { return this._ShearModulus; } set { this._ShearModulus = value;} }
	
		[Description("A measure of the lateral deformations in the elastic range.")]
		public IfcPositiveRatioMeasure? PoissonRatio { get { return this._PoissonRatio; } set { this._PoissonRatio = value;} }
	
		[Description("A measure of the expansion coefficient for warming up the material about one Kelv" +
	    "in. ")]
		public IfcThermalExpansionCoefficientMeasure? ThermalExpansionCoefficient { get { return this._ThermalExpansionCoefficient; } set { this._ThermalExpansionCoefficient = value;} }
	
	
	}
	
}

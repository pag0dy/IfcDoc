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
	[Guid("c393b722-c5fc-4835-a27f-7010d711a384")]
	public partial class IfcMechanicalSteelMaterialProperties : IfcMechanicalMaterialProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPressureMeasure? _YieldStress;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPressureMeasure? _UltimateStress;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _UltimateStrain;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcModulusOfElasticityMeasure? _HardeningModule;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPressureMeasure? _ProportionalStress;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _PlasticStrain;
	
		[DataMember(Order=6)] 
		ISet<IfcRelaxation> _Relaxations = new HashSet<IfcRelaxation>();
	
	
		[Description("A measure of the yield stress (or characteristic 0.2 percent proof stress) of the" +
	    " material. ")]
		public IfcPressureMeasure? YieldStress { get { return this._YieldStress; } set { this._YieldStress = value;} }
	
		[Description("A measure of the ultimate stress of the material. ")]
		public IfcPressureMeasure? UltimateStress { get { return this._UltimateStress; } set { this._UltimateStress = value;} }
	
		[Description("A measure of the (engineering) strain at the state of ultimate stress of the mate" +
	    "rial.")]
		public IfcPositiveRatioMeasure? UltimateStrain { get { return this._UltimateStrain; } set { this._UltimateStrain = value;} }
	
		[Description("A measure of the hardening module of the material (slope of stress versus strain " +
	    "curve after yield range). ")]
		public IfcModulusOfElasticityMeasure? HardeningModule { get { return this._HardeningModule; } set { this._HardeningModule = value;} }
	
		[Description("A measure of the proportional stress of the material. It describes the stress bef" +
	    "ore the first plastic deformation occurs and is commonly measured at a deformati" +
	    "on of 0.01%. ")]
		public IfcPressureMeasure? ProportionalStress { get { return this._ProportionalStress; } set { this._ProportionalStress = value;} }
	
		[Description("A measure of the permanent displacement, as in slip or twinning, which remains af" +
	    "ter the stress has been removed. Currently applied to a strain of 0.2% proportio" +
	    "nal stress of the material.")]
		public IfcPositiveRatioMeasure? PlasticStrain { get { return this._PlasticStrain; } set { this._PlasticStrain = value;} }
	
		[Description("Measures of decrease in stress over long time intervals resulting from plastic fl" +
	    "ow. Different relaxation values for different initial stress levels for a materi" +
	    "al may be given.")]
		public ISet<IfcRelaxation> Relaxations { get { return this._Relaxations; } }
	
	
	}
	
}

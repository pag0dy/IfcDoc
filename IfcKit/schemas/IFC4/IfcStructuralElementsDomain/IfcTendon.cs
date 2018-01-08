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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("1b518a02-392f-43e1-b4e1-0135ac1adc2b")]
	public partial class IfcTendon : IfcReinforcingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTendonTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _NominalDiameter;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcAreaMeasure _CrossSectionArea;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcForceMeasure? _TensionForce;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPressureMeasure? _PreStress;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _FrictionCoefficient;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _AnchorageSlip;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MinCurvatureRadius;
	
	
		[Description("Predefined generic types for a tendon.")]
		public IfcTendonTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("The nominal diameter defining the cross-section size of the tendon.")]
		public IfcPositiveLengthMeasure NominalDiameter { get { return this._NominalDiameter; } set { this._NominalDiameter = value;} }
	
		[Description("The effective cross-section area of the tendon.")]
		public IfcAreaMeasure CrossSectionArea { get { return this._CrossSectionArea; } set { this._CrossSectionArea = value;} }
	
		[Description("The maximum allowed tension force that can be applied on the tendon.")]
		public IfcForceMeasure? TensionForce { get { return this._TensionForce; } set { this._TensionForce = value;} }
	
		[Description("The prestress to be applied on the tendon.")]
		public IfcPressureMeasure? PreStress { get { return this._PreStress; } set { this._PreStress = value;} }
	
		[Description("The friction coefficient for the bond between the tendon and the surrounding conc" +
	    "rete.")]
		public IfcNormalisedRatioMeasure? FrictionCoefficient { get { return this._FrictionCoefficient; } set { this._FrictionCoefficient = value;} }
	
		[Description("The deformation of an anchor or slippage of tendons when the prestressing device " +
	    "is released.")]
		public IfcPositiveLengthMeasure? AnchorageSlip { get { return this._AnchorageSlip; } set { this._AnchorageSlip = value;} }
	
		[Description("The smallest curvature radius calculated on the whole effective length of the ten" +
	    "don where the tension properties are still valid. ")]
		public IfcPositiveLengthMeasure? MinCurvatureRadius { get { return this._MinCurvatureRadius; } set { this._MinCurvatureRadius = value;} }
	
	
	}
	
}

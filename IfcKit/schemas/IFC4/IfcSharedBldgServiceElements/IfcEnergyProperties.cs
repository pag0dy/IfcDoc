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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcControlExtension;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialPropertyResource;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("394bd3c4-2aed-40d7-b419-a40224b9729a")]
	public partial class IfcEnergyProperties : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcEnergySequenceEnum? _EnergySequence;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedEnergySequence;
	
	
		public IfcEnergySequenceEnum? EnergySequence { get { return this._EnergySequence; } set { this._EnergySequence = value;} }
	
		[Description("This attribute must be defined if the EnergySequence is USERDEFINED. ")]
		public IfcLabel? UserDefinedEnergySequence { get { return this._UserDefinedEnergySequence; } set { this._UserDefinedEnergySequence = value;} }
	
	
	}
	
}

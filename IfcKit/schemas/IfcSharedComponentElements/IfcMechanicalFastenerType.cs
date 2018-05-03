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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	public partial class IfcMechanicalFastenerType : IfcElementComponentType
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Subtype of mechanical fastener")]
		[Required()]
		public IfcMechanicalFastenerTypeEnum PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The nominal diameter describing the cross-section size of the fastener type.")]
		public IfcPositiveLengthMeasure? NominalDiameter { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The nominal length describing the longitudinal dimensions of the fastener type.")]
		public IfcPositiveLengthMeasure? NominalLength { get; set; }
	
	
		public IfcMechanicalFastenerType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcMechanicalFastenerTypeEnum __PredefinedType, IfcPositiveLengthMeasure? __NominalDiameter, IfcPositiveLengthMeasure? __NominalLength)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this.PredefinedType = __PredefinedType;
			this.NominalDiameter = __NominalDiameter;
			this.NominalLength = __NominalLength;
		}
	
	
	}
	
}

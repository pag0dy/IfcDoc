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
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	public partial class IfcTendonType : IfcReinforcingElementType
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Subtype of tendon.")]
		[Required()]
		public IfcTendonTypeEnum PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The nominal diameter defining the cross-section size of the prestressed part of the tendon.")]
		public IfcPositiveLengthMeasure? NominalDiameter { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The effective cross-section area of the prestressed part of the tendon.")]
		public IfcAreaMeasure? CrossSectionArea { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Diameter of the sheeth (duct) around the tendon, if there is one with this type of tendon.")]
		public IfcPositiveLengthMeasure? SheathDiameter { get; set; }
	
	
		public IfcTendonType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcTendonTypeEnum __PredefinedType, IfcPositiveLengthMeasure? __NominalDiameter, IfcAreaMeasure? __CrossSectionArea, IfcPositiveLengthMeasure? __SheathDiameter)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this.PredefinedType = __PredefinedType;
			this.NominalDiameter = __NominalDiameter;
			this.CrossSectionArea = __CrossSectionArea;
			this.SheathDiameter = __SheathDiameter;
		}
	
	
	}
	
}

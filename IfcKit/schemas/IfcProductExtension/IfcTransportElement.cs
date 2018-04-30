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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcTransportElement : IfcElement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Predefined type for transport element.")]
		public IfcTransportElementTypeEnum? OperationType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Capacity of the transport element measured by weight.")]
		public IfcMassMeasure? CapacityByWeight { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Capacity of the transportation element measured in numbers of person.")]
		public IfcCountMeasure? CapacityByNumber { get; set; }
	
	
		public IfcTransportElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcTransportElementTypeEnum? __OperationType, IfcMassMeasure? __CapacityByWeight, IfcCountMeasure? __CapacityByNumber)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this.OperationType = __OperationType;
			this.CapacityByWeight = __CapacityByWeight;
			this.CapacityByNumber = __CapacityByNumber;
		}
	
	
	}
	
}

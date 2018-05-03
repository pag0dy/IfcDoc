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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcBuilding : IfcSpatialStructureElement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Elevation above sea level of the reference height used for all storey elevation measures, equals to height 0.0. It is usually the ground floor level.")]
		public IfcLengthMeasure? ElevationOfRefHeight { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Elevation above the minimal terrain level around the foot print of the building, given in elevation above sea level.")]
		public IfcLengthMeasure? ElevationOfTerrain { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("Address given to the building for postal purposes.")]
		public IfcPostalAddress BuildingAddress { get; set; }
	
	
		public IfcBuilding(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName, IfcElementCompositionEnum? __CompositionType, IfcLengthMeasure? __ElevationOfRefHeight, IfcLengthMeasure? __ElevationOfTerrain, IfcPostalAddress __BuildingAddress)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __LongName, __CompositionType)
		{
			this.ElevationOfRefHeight = __ElevationOfRefHeight;
			this.ElevationOfTerrain = __ElevationOfTerrain;
			this.BuildingAddress = __BuildingAddress;
		}
	
	
	}
	
}

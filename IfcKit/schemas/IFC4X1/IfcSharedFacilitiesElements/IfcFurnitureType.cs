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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	[Guid("a8b69ebd-a055-4b49-b99d-0de94f4c7d81")]
	public partial class IfcFurnitureType : IfcFurnishingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcAssemblyPlaceEnum _AssemblyPlace;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcFurnitureTypeEnum? _PredefinedType;
	
	
		public IfcFurnitureType()
		{
		}
	
		public IfcFurnitureType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcAssemblyPlaceEnum __AssemblyPlace, IfcFurnitureTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this._AssemblyPlace = __AssemblyPlace;
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("<p>A designation of where the assembly is intended to take place. A selection of " +
	    "alternatives s provided in an enumerated list.</p>")]
		public IfcAssemblyPlaceEnum AssemblyPlace { get { return this._AssemblyPlace; } set { this._AssemblyPlace = value;} }
	
		public IfcFurnitureTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}

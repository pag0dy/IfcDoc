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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("07e8bff9-ded4-4ebe-ad7b-40397fb6f923")]
	public partial class IfcBuildingStorey : IfcSpatialStructureElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLengthMeasure? _Elevation;
	
	
		public IfcBuildingStorey()
		{
		}
	
		public IfcBuildingStorey(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName, IfcElementCompositionEnum __CompositionType, IfcLengthMeasure? __Elevation)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __LongName, __CompositionType)
		{
			this._Elevation = __Elevation;
		}
	
		[Description("Elevation of the base of this storey, relative to the 0,00 internal reference hei" +
	    "ght of the building. The 0.00 level is given by the absolute above sea level hei" +
	    "ght by the ElevationOfRefHeight attribute given at IfcBuilding.")]
		public IfcLengthMeasure? Elevation { get { return this._Elevation; } set { this._Elevation = value;} }
	
	
	}
	
}

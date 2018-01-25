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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("417b2868-1e1e-4b5e-b73a-84dec52d9767")]
	public partial class IfcBuilding : IfcSpatialStructureElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLengthMeasure? _ElevationOfRefHeight;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLengthMeasure? _ElevationOfTerrain;
	
		[DataMember(Order=2)] 
		[XmlElement]
		IfcPostalAddress _BuildingAddress;
	
	
		[Description("Elevation above sea level of the reference height used for all storey elevation m" +
	    "easures, equals to height 0.0. It is usually the ground floor level.")]
		public IfcLengthMeasure? ElevationOfRefHeight { get { return this._ElevationOfRefHeight; } set { this._ElevationOfRefHeight = value;} }
	
		[Description("Elevation above the minimal terrain level around the foot print of the building, " +
	    "given in elevation above sea level.")]
		public IfcLengthMeasure? ElevationOfTerrain { get { return this._ElevationOfTerrain; } set { this._ElevationOfTerrain = value;} }
	
		[Description("Address given to the building for postal purposes.")]
		public IfcPostalAddress BuildingAddress { get { return this._BuildingAddress; } set { this._BuildingAddress = value;} }
	
	
	}
	
}

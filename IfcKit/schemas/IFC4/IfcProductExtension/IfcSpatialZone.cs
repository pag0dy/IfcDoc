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
	[Guid("238c3771-892d-42d9-95eb-0e1807d07f4c")]
	public partial class IfcSpatialZone : IfcSpatialElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcSpatialZoneTypeEnum? _PredefinedType;
	
	
		[Description("<EPM-HTML>\r\nPredefined types to define the particular type of the spatial zone. T" +
	    "here may be property set definitions available for each predefined type.\r\n</EPM-" +
	    "HTML>")]
		public IfcSpatialZoneTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}

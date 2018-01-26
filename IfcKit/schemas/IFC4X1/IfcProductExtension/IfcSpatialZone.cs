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
	[Guid("238c3771-892d-42d9-95eb-0e1807d07f4c")]
	public partial class IfcSpatialZone : IfcSpatialElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcSpatialZoneTypeEnum? _PredefinedType;
	
	
		public IfcSpatialZone()
		{
		}
	
		public IfcSpatialZone(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName, IfcSpatialZoneTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __LongName)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Predefined types to define the particular type of the spatial zone. There may be " +
	    "property set definitions available for each predefined type.")]
		public IfcSpatialZoneTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}

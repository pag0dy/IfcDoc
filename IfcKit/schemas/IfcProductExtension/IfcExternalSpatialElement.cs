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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcExternalSpatialElement : IfcExternalSpatialStructureElement,
		BuildingSmart.IFC.IfcProductExtension.IfcSpaceBoundarySelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Predefined generic types for an external spatial element that are specified in an enumeration. There might be property sets defined specifically for each predefined type.")]
		public IfcExternalSpatialElementTypeEnum? PredefinedType { get; set; }
	
		[InverseProperty("RelatingSpace")] 
		[Description("Reference to a set of <em>IfcRelSpaceBoundary</em>'s that defines the physical or virtual delimitation of that external spacial element against physical or virtual boundaries.")]
		public ISet<IfcRelSpaceBoundary> BoundedBy { get; protected set; }
	
	
		public IfcExternalSpatialElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName, IfcExternalSpatialElementTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __LongName)
		{
			this.PredefinedType = __PredefinedType;
			this.BoundedBy = new HashSet<IfcRelSpaceBoundary>();
		}
	
	
	}
	
}

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
	[Guid("0b5b1546-4045-4588-b4c0-6baa80c9ff8b")]
	public partial class IfcExternalSpatialElement : IfcExternalSpatialStructureElement,
		BuildingSmart.IFC.IfcProductExtension.IfcSpaceBoundarySelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcExternalSpatialElementTypeEnum? _PredefinedType;
	
		[InverseProperty("RelatingSpace")] 
		ISet<IfcRelSpaceBoundary> _BoundedBy = new HashSet<IfcRelSpaceBoundary>();
	
	
		public IfcExternalSpatialElement()
		{
		}
	
		public IfcExternalSpatialElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName, IfcExternalSpatialElementTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __LongName)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Predefined generic types for an external spatial element that are specified in an" +
	    " enumeration. There might be property sets defined specifically for each predefi" +
	    "ned type.")]
		public IfcExternalSpatialElementTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Reference to a set of <em>IfcRelSpaceBoundary</em>\'s that defines the physical or" +
	    " virtual delimitation of that external spacial element against physical or virtu" +
	    "al boundaries.")]
		public ISet<IfcRelSpaceBoundary> BoundedBy { get { return this._BoundedBy; } }
	
	
	}
	
}

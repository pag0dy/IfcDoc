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
	[Guid("ef5bd9a3-9472-49c9-9aa4-173b9444e09a")]
	public partial class IfcSpace : IfcSpatialStructureElement,
		BuildingSmart.IFC.IfcProductExtension.IfcSpaceBoundarySelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcSpaceTypeEnum? _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLengthMeasure? _ElevationWithFlooring;
	
		[InverseProperty("RelatingSpace")] 
		ISet<IfcRelCoversSpaces> _HasCoverings = new HashSet<IfcRelCoversSpaces>();
	
		[InverseProperty("RelatingSpace")] 
		ISet<IfcRelSpaceBoundary> _BoundedBy = new HashSet<IfcRelSpaceBoundary>();
	
	
		[Description(@"Predefined generic types for a space that are specified in an enumeration. There might be property sets defined specifically for each predefined type.
	
	<blockquote class=""note"">NOTE&nbsp; Previous use had been to indicates whether the <em>IfcSpace</em> is an interior space by value INTERNAL, or an exterior space by value EXTERNAL. This use is now deprecated, the property 'IsExternal' at 'Pset_SpaceCommon' should be used instead.</blockquote>
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been renamed from <em>ExteriorOrInteriorSpace</em> with upward compatibility for file based exchange.</blockquote>")]
		public IfcSpaceTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Level of flooring of this space; the average shall be taken, if the space ground " +
	    "surface is sloping or if there are level differences within this space. ")]
		public IfcLengthMeasure? ElevationWithFlooring { get { return this._ElevationWithFlooring; } set { this._ElevationWithFlooring = value;} }
	
		[Description(@"Reference to <em>IfcCovering</em> by virtue of the objectified relationship <em>IfcRelCoversSpaces</em>. It defines the concept of a space having coverings assigned. Those coverings may represent different flooring, or tiling areas.
	
	<blockquote class=""note"">NOTE&nbsp; Coverings are often managed by the space, and not by the building element, which they cover.</blockquote>
	<blockquote class=""change-ifc2x3"">IFC2x Edition3 CHANGE&nbsp; New inverse relationship. Upward compatibility for file based exchange is guaranteed.</blockquote>")]
		public ISet<IfcRelCoversSpaces> HasCoverings { get { return this._HasCoverings; } }
	
		[Description("Reference to a set of <em>IfcRelSpaceBoundary</em>\'s that defines the physical or" +
	    " virtual delimitation of that space against physical or virtual boundaries.")]
		public ISet<IfcRelSpaceBoundary> BoundedBy { get { return this._BoundedBy; } }
	
	
	}
	
}

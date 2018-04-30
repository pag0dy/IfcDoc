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
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcSpace : IfcSpatialStructureElement,
		BuildingSmart.IFC.IfcProductExtension.IfcSpaceBoundarySelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Predefined generic types for a space that are specified in an enumeration. There might be property sets defined specifically for each predefined type.    <blockquote class=\"note\">NOTE&nbsp; Previous use had been to indicates whether the <em>IfcSpace</em> is an interior space by value INTERNAL, or an exterior space by value EXTERNAL. This use is now deprecated, the property 'IsExternal' at 'Pset_SpaceCommon' should be used instead.</blockquote>    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been renamed from <em>ExteriorOrInteriorSpace</em> with upward compatibility for file based exchange.</blockquote>")]
		public IfcSpaceTypeEnum? PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Level of flooring of this space; the average shall be taken, if the space ground surface is sloping or if there are level differences within this space. ")]
		public IfcLengthMeasure? ElevationWithFlooring { get; set; }
	
		[InverseProperty("RelatingSpace")] 
		[Description("Reference to <em>IfcCovering</em> by virtue of the objectified relationship <em>IfcRelCoversSpaces</em>. It defines the concept of a space having coverings assigned. Those coverings may represent different flooring, or tiling areas.    <blockquote class=\"note\">NOTE&nbsp; Coverings are often managed by the space, and not by the building element, which they cover.</blockquote>  <blockquote class=\"change-ifc2x3\">IFC2x Edition3 CHANGE&nbsp; New inverse relationship. Upward compatibility for file based exchange is guaranteed.</blockquote>")]
		public ISet<IfcRelCoversSpaces> HasCoverings { get; protected set; }
	
		[InverseProperty("RelatingSpace")] 
		[Description("Reference to a set of <em>IfcRelSpaceBoundary</em>'s that defines the physical or virtual delimitation of that space against physical or virtual boundaries.")]
		public ISet<IfcRelSpaceBoundary> BoundedBy { get; protected set; }
	
	
		public IfcSpace(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName, IfcElementCompositionEnum? __CompositionType, IfcSpaceTypeEnum? __PredefinedType, IfcLengthMeasure? __ElevationWithFlooring)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __LongName, __CompositionType)
		{
			this.PredefinedType = __PredefinedType;
			this.ElevationWithFlooring = __ElevationWithFlooring;
			this.HasCoverings = new HashSet<IfcRelCoversSpaces>();
			this.BoundedBy = new HashSet<IfcRelSpaceBoundary>();
		}
	
	
	}
	
}

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
	[Guid("dfb6beda-5c7c-4df8-bbc6-b101ce4006f3")]
	public abstract partial class IfcPositioningElement : IfcProduct
	{
		[InverseProperty("RelatedElements")] 
		[MaxLength(1)]
		ISet<IfcRelContainedInSpatialStructure> _ContainedInStructure = new HashSet<IfcRelContainedInSpatialStructure>();
	
	
		public IfcPositioningElement()
		{
		}
	
		public IfcPositioningElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
		}
	
		[Description(@"Relationship to a spatial structure element, to which the positioning element is primarily associated.
	<blockquote class=""change-ifc2x"">IFC2x CHANGE&nbsp; The inverse relationship has been added to <em>IfcGrid</em> with upward compatibility</blockquote>
	<blockquote class=""change-ifc4"">IFC4 CHANGE&nbsp; The inverse relationship has been promoted from <i>IfcGrid</i> to this new supertype with upward compatibility</blockquote>")]
		public ISet<IfcRelContainedInSpatialStructure> ContainedInStructure { get { return this._ContainedInStructure; } }
	
	
	}
	
}

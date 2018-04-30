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
	public abstract partial class IfcPositioningElement : IfcProduct
	{
		[InverseProperty("RelatedElements")] 
		[Description("Relationship to a spatial structure element, to which the positioning element is primarily associated.  <blockquote class=\"change-ifc2x\">IFC2x CHANGE&nbsp; The inverse relationship has been added to <em>IfcGrid</em> with upward compatibility</blockquote>  <blockquote class=\"change-ifc4\">IFC4 CHANGE&nbsp; The inverse relationship has been promoted from <i>IfcGrid</i> to this new supertype with upward compatibility</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcRelContainedInSpatialStructure> ContainedInStructure { get; protected set; }
	
	
		protected IfcPositioningElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this.ContainedInStructure = new HashSet<IfcRelContainedInSpatialStructure>();
		}
	
	
	}
	
}

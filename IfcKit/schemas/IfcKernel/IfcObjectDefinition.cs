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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public abstract partial class IfcObjectDefinition : IfcRoot
	{
		[InverseProperty("RelatedObjects")] 
		[Description("Reference to the relationship objects, that assign (by an association relationship) other subtypes of IfcObject to this object instance. Examples are the association to products, processes, controls, resources or groups.")]
		public ISet<IfcRelAssigns> HasAssignments { get; protected set; }
	
		[InverseProperty("RelatingObject")] 
		[Description("Reference to the decomposition relationship, that allows this object to be the composition of other objects. An object can be decomposed by several other objects.")]
		public ISet<IfcRelDecomposes> IsDecomposedBy { get; protected set; }
	
		[InverseProperty("RelatedObjects")] 
		[Description("References to the decomposition relationship, that allows this object to be a part of the decomposition. An object can only be part of a single decomposition (to allow hierarchical strutures only).  ")]
		[MaxLength(1)]
		public ISet<IfcRelDecomposes> Decomposes { get; protected set; }
	
		[InverseProperty("RelatedObjects")] 
		[Description("Reference to the relationship objects, that associates external references or other resource definitions to the object.. Examples are the association to library, documentation or classification.")]
		public ISet<IfcRelAssociates> HasAssociations { get; protected set; }
	
	
		protected IfcObjectDefinition(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.HasAssignments = new HashSet<IfcRelAssigns>();
			this.IsDecomposedBy = new HashSet<IfcRelDecomposes>();
			this.Decomposes = new HashSet<IfcRelDecomposes>();
			this.HasAssociations = new HashSet<IfcRelAssociates>();
		}
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("b7722626-06a2-4909-a99f-b6ed4916e4b0")]
	public abstract partial class IfcObjectDefinition : IfcRoot
	{
		[InverseProperty("RelatedObjects")] 
		ISet<IfcRelAssigns> _HasAssignments = new HashSet<IfcRelAssigns>();
	
		[InverseProperty("RelatingObject")] 
		ISet<IfcRelDecomposes> _IsDecomposedBy = new HashSet<IfcRelDecomposes>();
	
		[InverseProperty("RelatedObjects")] 
		[MaxLength(1)]
		ISet<IfcRelDecomposes> _Decomposes = new HashSet<IfcRelDecomposes>();
	
		[InverseProperty("RelatedObjects")] 
		ISet<IfcRelAssociates> _HasAssociations = new HashSet<IfcRelAssociates>();
	
	
		public IfcObjectDefinition()
		{
		}
	
		public IfcObjectDefinition(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
		}
	
		[Description("Reference to the relationship objects, that assign (by an association relationshi" +
	    "p) other subtypes of IfcObject to this object instance. Examples are the associa" +
	    "tion to products, processes, controls, resources or groups.")]
		public ISet<IfcRelAssigns> HasAssignments { get { return this._HasAssignments; } }
	
		[Description("Reference to the decomposition relationship, that allows this object to be the co" +
	    "mposition of other objects. An object can be decomposed by several other objects" +
	    ".")]
		public ISet<IfcRelDecomposes> IsDecomposedBy { get { return this._IsDecomposedBy; } }
	
		[Description("References to the decomposition relationship, that allows this object to be a par" +
	    "t of the decomposition. An object can only be part of a single decomposition (to" +
	    " allow hierarchical strutures only).\r\n")]
		public ISet<IfcRelDecomposes> Decomposes { get { return this._Decomposes; } }
	
		[Description("Reference to the relationship objects, that associates external references or oth" +
	    "er resource definitions to the object.. Examples are the association to library," +
	    " documentation or classification.")]
		public ISet<IfcRelAssociates> HasAssociations { get { return this._HasAssociations; } }
	
	
	}
	
}

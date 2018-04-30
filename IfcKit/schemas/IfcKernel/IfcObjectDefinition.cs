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
	public abstract partial class IfcObjectDefinition : IfcRoot,
		BuildingSmart.IFC.IfcKernel.IfcDefinitionSelect
	{
		[InverseProperty("RelatedObjects")] 
		[Description("Reference to the relationship objects, that assign (by an association relationship) other subtypes of IfcObject to this object instance. Examples are the association to products, processes, controls, resources or groups.")]
		public ISet<IfcRelAssigns> HasAssignments { get; protected set; }
	
		[InverseProperty("RelatedObjects")] 
		[XmlIgnore]
		[Description("References to the decomposition relationship being a nesting. It determines that this object definition is a part within an ordered whole/part decomposition relationship. An object occurrence or type can only be part of a single decomposition (to allow hierarchical strutures only).    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute datatype has been added and separated from <em>Decomposes</em> defined at <em>IfcObjectDefinition</em>.</blockquote>  ")]
		[MaxLength(1)]
		public ISet<IfcRelNests> Nests { get; protected set; }
	
		[InverseProperty("RelatingObject")] 
		[XmlElement("IfcRelNests")]
		[Description("References to the decomposition relationship being a nesting. It determines that this object definition is the whole within an ordered whole/part decomposition relationship. An object or object type can be nested by several other objects (occurrences or types).    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute datatype has been added and separated from <em>IsDecomposedBy</em> defined at <em>IfcObjectDefinition</em>.</blockquote>  ")]
		public ISet<IfcRelNests> IsNestedBy { get; protected set; }
	
		[InverseProperty("RelatedDefinitions")] 
		[Description("References to the context providing context information such as project unit or representation context. It should only be asserted for the uppermost non-spatial object.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute datatype has been added.</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcRelDeclares> HasContext { get; protected set; }
	
		[InverseProperty("RelatingObject")] 
		[XmlElement("IfcRelAggregates")]
		[Description("References to the decomposition relationship being an aggregation. It determines that this object definition is whole within an unordered whole/part decomposition relationship. An object definitions can be aggregated by several other objects (occurrences or parts).    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute datatype has been changed from the supertype <em>IfcRelDecomposes</em> to subtype <em>IfcRelAggregates</em>.</blockquote>  ")]
		public ISet<IfcRelAggregates> IsDecomposedBy { get; protected set; }
	
		[InverseProperty("RelatedObjects")] 
		[XmlIgnore]
		[Description("References to the decomposition relationship being an aggregation. It determines that this object definition is a part within an unordered whole/part decomposition relationship. An object definitions can only be part of a single decomposition (to allow hierarchical strutures only).    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The inverse attribute datatype has been changed from the supertype <em>IfcRelDecomposes</em> to subtype <em>IfcRelAggregates</em>.</blockquote>  ")]
		[MaxLength(1)]
		public ISet<IfcRelAggregates> Decomposes { get; protected set; }
	
		[InverseProperty("RelatedObjects")] 
		[Description("Reference to the relationship objects, that associates external references or other resource definitions to the object.. Examples are the association to library, documentation or classification.")]
		public ISet<IfcRelAssociates> HasAssociations { get; protected set; }
	
	
		protected IfcObjectDefinition(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.HasAssignments = new HashSet<IfcRelAssigns>();
			this.Nests = new HashSet<IfcRelNests>();
			this.IsNestedBy = new HashSet<IfcRelNests>();
			this.HasContext = new HashSet<IfcRelDeclares>();
			this.IsDecomposedBy = new HashSet<IfcRelAggregates>();
			this.Decomposes = new HashSet<IfcRelAggregates>();
			this.HasAssociations = new HashSet<IfcRelAssociates>();
		}
	
	
	}
	
}

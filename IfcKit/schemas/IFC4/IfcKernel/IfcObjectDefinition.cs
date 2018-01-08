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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("40ee8a1b-c5dc-4107-8d14-cb784713b9e5")]
	public abstract partial class IfcObjectDefinition : IfcRoot,
		BuildingSmart.IFC.IfcKernel.IfcDefinitionSelect
	{
		[InverseProperty("RelatedObjects")] 
		ISet<IfcRelAssigns> _HasAssignments = new HashSet<IfcRelAssigns>();
	
		[InverseProperty("RelatedObjects")] 
		[XmlIgnore]
		ISet<IfcRelNests> _Nests = new HashSet<IfcRelNests>();
	
		[InverseProperty("RelatingObject")] 
		[XmlElement]
		ISet<IfcRelNests> _IsNestedBy = new HashSet<IfcRelNests>();
	
		[InverseProperty("RelatedDefinitions")] 
		ISet<IfcRelDeclares> _HasContext = new HashSet<IfcRelDeclares>();
	
		[InverseProperty("RelatingObject")] 
		[XmlElement]
		ISet<IfcRelAggregates> _IsDecomposedBy = new HashSet<IfcRelAggregates>();
	
		[InverseProperty("RelatedObjects")] 
		[XmlIgnore]
		ISet<IfcRelAggregates> _Decomposes = new HashSet<IfcRelAggregates>();
	
		[InverseProperty("RelatedObjects")] 
		ISet<IfcRelAssociates> _HasAssociations = new HashSet<IfcRelAssociates>();
	
	
		[Description("Reference to the relationship objects, that assign (by an association relationshi" +
	    "p) other subtypes of IfcObject to this object instance. Examples are the associa" +
	    "tion to products, processes, controls, resources or groups.")]
		public ISet<IfcRelAssigns> HasAssignments { get { return this._HasAssignments; } }
	
		[Description(@"References to the decomposition relationship being a nesting. It determines that this object definition is a part within an ordered whole/part decomposition relationship. An object occurrence or type can only be part of a single decomposition (to allow hierarchical strutures only).
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The inverse attribute datatype has been added and separated from <em>Decomposes</em> defined at <em>IfcObjectDefinition</em>.</blockquote>
	")]
		public ISet<IfcRelNests> Nests { get { return this._Nests; } }
	
		[Description(@"References to the decomposition relationship being a nesting. It determines that this object definition is the whole within an ordered whole/part decomposition relationship. An object or object type can be nested by several other objects (occurrences or types).
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The inverse attribute datatype has been added and separated from <em>IsDecomposedBy</em> defined at <em>IfcObjectDefinition</em>.</blockquote>
	")]
		public ISet<IfcRelNests> IsNestedBy { get { return this._IsNestedBy; } }
	
		[Description(@"References to the context providing context information such as project unit or representation context. It should only be asserted for the uppermost non-spatial object.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The inverse attribute datatype has been added.</blockquote>")]
		public ISet<IfcRelDeclares> HasContext { get { return this._HasContext; } }
	
		[Description(@"References to the decomposition relationship being an aggregation. It determines that this object definition is whole within an unordered whole/part decomposition relationship. An object definitions can be aggregated by several other objects (occurrences or parts).
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The inverse attribute datatype has been changed from the supertype <em>IfcRelDecomposes</em> to subtype <em>IfcRelAggregates</em>.</blockquote>
	")]
		public ISet<IfcRelAggregates> IsDecomposedBy { get { return this._IsDecomposedBy; } }
	
		[Description(@"References to the decomposition relationship being an aggregation. It determines that this object definition is a part within an unordered whole/part decomposition relationship. An object definitions can only be part of a single decomposition (to allow hierarchical strutures only).
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The inverse attribute datatype has been changed from the supertype <em>IfcRelDecomposes</em> to subtype <em>IfcRelAggregates</em>.</blockquote>
	")]
		public ISet<IfcRelAggregates> Decomposes { get { return this._Decomposes; } }
	
		[Description("Reference to the relationship objects, that associates external references or oth" +
	    "er resource definitions to the object.. Examples are the association to library," +
	    " documentation or classification.")]
		public ISet<IfcRelAssociates> HasAssociations { get { return this._HasAssociations; } }
	
	
	}
	
}

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
	[Guid("9ab3f33b-7e80-4290-afe5-1e7a055cd3ac")]
	public abstract partial class IfcElement : IfcProduct,
		BuildingSmart.IFC.IfcStructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Tag;
	
		[InverseProperty("RelatedBuildingElement")] 
		ISet<IfcRelFillsElement> _FillsVoids = new HashSet<IfcRelFillsElement>();
	
		[InverseProperty("RelatingElement")] 
		ISet<IfcRelConnectsElements> _ConnectedTo = new HashSet<IfcRelConnectsElements>();
	
		[InverseProperty("RelatedElement")] 
		ISet<IfcRelInterferesElements> _IsInterferedByElements = new HashSet<IfcRelInterferesElements>();
	
		[InverseProperty("RelatingElement")] 
		ISet<IfcRelInterferesElements> _InterferesElements = new HashSet<IfcRelInterferesElements>();
	
		[InverseProperty("RelatingElement")] 
		ISet<IfcRelProjectsElement> _HasProjections = new HashSet<IfcRelProjectsElement>();
	
		[InverseProperty("RelatedElements")] 
		ISet<IfcRelReferencedInSpatialStructure> _ReferencedInStructures = new HashSet<IfcRelReferencedInSpatialStructure>();
	
		[InverseProperty("RelatingBuildingElement")] 
		ISet<IfcRelVoidsElement> _HasOpenings = new HashSet<IfcRelVoidsElement>();
	
		[InverseProperty("RealizingElements")] 
		ISet<IfcRelConnectsWithRealizingElements> _IsConnectionRealization = new HashSet<IfcRelConnectsWithRealizingElements>();
	
		[InverseProperty("RelatedBuildingElement")] 
		ISet<IfcRelSpaceBoundary> _ProvidesBoundaries = new HashSet<IfcRelSpaceBoundary>();
	
		[InverseProperty("RelatedElement")] 
		ISet<IfcRelConnectsElements> _ConnectedFrom = new HashSet<IfcRelConnectsElements>();
	
		[InverseProperty("RelatedElements")] 
		ISet<IfcRelContainedInSpatialStructure> _ContainedInStructure = new HashSet<IfcRelContainedInSpatialStructure>();
	
	
		[Description("The tag (or label) identifier at the particular instance of a product, e.g. the s" +
	    "erial number, or the position number. It is the identifier at the occurrence lev" +
	    "el.")]
		public IfcIdentifier? Tag { get { return this._Tag; } set { this._Tag = value;} }
	
		[Description("<EPM-HTML>\r\nReference to the <em>IfcRelFillsElement</em> Relationship that puts t" +
	    "he element as a filling into the opening created within another element.\r\n</EPM-" +
	    "HTML>\r\n\r\n")]
		public ISet<IfcRelFillsElement> FillsVoids { get { return this._FillsVoids; } }
	
		[Description("Reference to the element connection relationship. The relationship then refers to" +
	    " the other element to which this element is connected to.\r\n")]
		public ISet<IfcRelConnectsElements> ConnectedTo { get { return this._ConnectedTo; } }
	
		[Description(@"<EPM-HTML>
	Reference to the interference relationship to indicate the element that is interfered. The relationship, if provided, indicates that this element has an interference with one or many other elements.
	<blockquote class=""note"">NOTE&nbsp; There is no indication of precedence between <em>IsInterferedByElements</em> and <em>InterferesElements</em>. </blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  New inverse relationship.</blockquote>
	</EPM-HTML>")]
		public ISet<IfcRelInterferesElements> IsInterferedByElements { get { return this._IsInterferedByElements; } }
	
		[Description(@"<EPM-HTML>
	Reference to the interference relationship to indicate the element that interferes. The relationship, if provided, indicates that this element has an interference with one or many other elements.
	<blockquote class=""note"">NOTE&nbsp; There is no indication of precedence between <em>IsInterferedByElements</em> and <em>InterferesElements</em>.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  New inverse relationship.</blockquote>
	</EPM-HTML>")]
		public ISet<IfcRelInterferesElements> InterferesElements { get { return this._InterferesElements; } }
	
		[Description("<EPM-HTML>\r\nProjection relationship that adds a feature (using a Boolean union) t" +
	    "o the <em>IfcBuildingElement</em>.\r\n</EPM-HTML>")]
		public ISet<IfcRelProjectsElement> HasProjections { get { return this._HasProjections; } }
	
		[Description(@"<EPM-HTML>
	Reference relationship to the spatial structure element, to which the element is additionally associated. This relationship may not be hierarchical, an element may be referenced by zero, one or many spatial structure elements.
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The inverse attribute has been added with upward compatibility for file based exchange.</blockquote>
	</EPM-HTML>")]
		public ISet<IfcRelReferencedInSpatialStructure> ReferencedInStructures { get { return this._ReferencedInStructures; } }
	
		[Description(@"<EPM-HTML>
	Reference to the <em>IfcRelVoidsElement</em> relationship that creates an opening in an element. An element can incorporate zero-to-many openings. For each opening, that voids the element, a new relationship <em>IfcRelVoidsElement</em> is generated.
	</EPM-HTML>
	")]
		public ISet<IfcRelVoidsElement> HasOpenings { get { return this._HasOpenings; } }
	
		[Description(@"<EPM-HTML>
	Reference to the connection relationship with realizing element. The relationship, if provided, assigns this element as the realizing element to the connection, which provides the physical manifestation of the connection relationship.
	</EPM-HTML>
	")]
		public ISet<IfcRelConnectsWithRealizingElements> IsConnectionRealization { get { return this._IsConnectionRealization; } }
	
		[Description("<EPM-HTML>\r\nReference to space boundaries by virtue of the objectified relationsh" +
	    "ip <em>IfcRelSpaceBoundary</em>. It defines the concept of an element bounding s" +
	    "paces.\r\n</EPM-HTML>\r\n")]
		public ISet<IfcRelSpaceBoundary> ProvidesBoundaries { get { return this._ProvidesBoundaries; } }
	
		[Description("Reference to the element connection relationship. The relationship then refers to" +
	    " the other element that is connected to this element.\r\n")]
		public ISet<IfcRelConnectsElements> ConnectedFrom { get { return this._ConnectedFrom; } }
	
		[Description(@"<EPM-HTML>
	Containment relationship to the spatial structure element, to which the element is primarily associated. This containment relationship has to be hierachical, i.e. an element may only be assigned directly to zero or one spatial structure. 
	</EPM-HTML>")]
		public ISet<IfcRelContainedInSpatialStructure> ContainedInStructure { get { return this._ContainedInStructure; } }
	
	
	}
	
}

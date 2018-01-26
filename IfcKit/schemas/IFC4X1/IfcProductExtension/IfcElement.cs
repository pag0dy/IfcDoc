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
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

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
		[MaxLength(1)]
		ISet<IfcRelFillsElement> _FillsVoids = new HashSet<IfcRelFillsElement>();
	
		[InverseProperty("RelatingElement")] 
		ISet<IfcRelConnectsElements> _ConnectedTo = new HashSet<IfcRelConnectsElements>();
	
		[InverseProperty("RelatedElement")] 
		ISet<IfcRelInterferesElements> _IsInterferedByElements = new HashSet<IfcRelInterferesElements>();
	
		[InverseProperty("RelatingElement")] 
		ISet<IfcRelInterferesElements> _InterferesElements = new HashSet<IfcRelInterferesElements>();
	
		[InverseProperty("RelatingElement")] 
		[XmlElement]
		ISet<IfcRelProjectsElement> _HasProjections = new HashSet<IfcRelProjectsElement>();
	
		[InverseProperty("RelatedElements")] 
		ISet<IfcRelReferencedInSpatialStructure> _ReferencedInStructures = new HashSet<IfcRelReferencedInSpatialStructure>();
	
		[InverseProperty("RelatingBuildingElement")] 
		[XmlElement]
		ISet<IfcRelVoidsElement> _HasOpenings = new HashSet<IfcRelVoidsElement>();
	
		[InverseProperty("RealizingElements")] 
		ISet<IfcRelConnectsWithRealizingElements> _IsConnectionRealization = new HashSet<IfcRelConnectsWithRealizingElements>();
	
		[InverseProperty("RelatedBuildingElement")] 
		ISet<IfcRelSpaceBoundary> _ProvidesBoundaries = new HashSet<IfcRelSpaceBoundary>();
	
		[InverseProperty("RelatedElement")] 
		ISet<IfcRelConnectsElements> _ConnectedFrom = new HashSet<IfcRelConnectsElements>();
	
		[InverseProperty("RelatedElements")] 
		[MaxLength(1)]
		ISet<IfcRelContainedInSpatialStructure> _ContainedInStructure = new HashSet<IfcRelContainedInSpatialStructure>();
	
		[InverseProperty("RelatingBuildingElement")] 
		ISet<IfcRelCoversBldgElements> _HasCoverings = new HashSet<IfcRelCoversBldgElements>();
	
	
		public IfcElement()
		{
		}
	
		public IfcElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this._Tag = __Tag;
		}
	
		[Description("The tag (or label) identifier at the particular instance of a product, e.g. the s" +
	    "erial number, or the position number. It is the identifier at the occurrence lev" +
	    "el.")]
		public IfcIdentifier? Tag { get { return this._Tag; } set { this._Tag = value;} }
	
		[Description("Reference to the <em>IfcRelFillsElement</em> Relationship that puts the element a" +
	    "s a filling into the opening created within another element.\r\n\r\n")]
		public ISet<IfcRelFillsElement> FillsVoids { get { return this._FillsVoids; } }
	
		[Description("Reference to the element connection relationship. The relationship then refers to" +
	    " the other element to which this element is connected to.\r\n")]
		public ISet<IfcRelConnectsElements> ConnectedTo { get { return this._ConnectedTo; } }
	
		[Description(@"Reference to the interference relationship to indicate the element that is interfered. The relationship, if provided, indicates that this element has an interference with one or many other elements.
	<blockquote class=""note"">NOTE&nbsp; There is no indication of precedence between <em>IsInterferedByElements</em> and <em>InterferesElements</em>. </blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  New inverse relationship.</blockquote>")]
		public ISet<IfcRelInterferesElements> IsInterferedByElements { get { return this._IsInterferedByElements; } }
	
		[Description(@"Reference to the interference relationship to indicate the element that interferes. The relationship, if provided, indicates that this element has an interference with one or many other elements.
	<blockquote class=""note"">NOTE&nbsp; There is no indication of precedence between <em>IsInterferedByElements</em> and <em>InterferesElements</em>.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  New inverse relationship.</blockquote>")]
		public ISet<IfcRelInterferesElements> InterferesElements { get { return this._InterferesElements; } }
	
		[Description("Projection relationship that adds a feature (using a Boolean union) to the <em>If" +
	    "cBuildingElement</em>.")]
		public ISet<IfcRelProjectsElement> HasProjections { get { return this._HasProjections; } }
	
		[Description(@"Reference relationship to the spatial structure element, to which the element is additionally associated. This relationship may not be hierarchical, an element may be referenced by zero, one or many spatial structure elements.
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The inverse attribute has been added with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelReferencedInSpatialStructure> ReferencedInStructures { get { return this._ReferencedInStructures; } }
	
		[Description("Reference to the <em>IfcRelVoidsElement</em> relationship that creates an opening" +
	    " in an element. An element can incorporate zero-to-many openings. For each openi" +
	    "ng, that voids the element, a new relationship <em>IfcRelVoidsElement</em> is ge" +
	    "nerated.\r\n")]
		public ISet<IfcRelVoidsElement> HasOpenings { get { return this._HasOpenings; } }
	
		[Description("Reference to the connection relationship with realizing element. The relationship" +
	    ", if provided, assigns this element as the realizing element to the connection, " +
	    "which provides the physical manifestation of the connection relationship.\r\n")]
		public ISet<IfcRelConnectsWithRealizingElements> IsConnectionRealization { get { return this._IsConnectionRealization; } }
	
		[Description("Reference to space boundaries by virtue of the objectified relationship <em>IfcRe" +
	    "lSpaceBoundary</em>. It defines the concept of an element bounding spaces.\r\n")]
		public ISet<IfcRelSpaceBoundary> ProvidesBoundaries { get { return this._ProvidesBoundaries; } }
	
		[Description("Reference to the element connection relationship. The relationship then refers to" +
	    " the other element that is connected to this element.\r\n")]
		public ISet<IfcRelConnectsElements> ConnectedFrom { get { return this._ConnectedFrom; } }
	
		[Description("Containment relationship to the spatial structure element, to which the element i" +
	    "s primarily associated. This containment relationship has to be hierachical, i.e" +
	    ". an element may only be assigned directly to zero or one spatial structure. ")]
		public ISet<IfcRelContainedInSpatialStructure> ContainedInStructure { get { return this._ContainedInStructure; } }
	
		[Description("Reference to <em>IfcCovering</em> by virtue of the objectified relationship <em>I" +
	    "fcRelCoversBldgElement</em>. It defines the concept of an element having coverin" +
	    "gs associated.")]
		public ISet<IfcRelCoversBldgElements> HasCoverings { get { return this._HasCoverings; } }
	
	
	}
	
}

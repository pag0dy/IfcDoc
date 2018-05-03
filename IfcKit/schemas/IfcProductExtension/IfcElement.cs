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
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public abstract partial class IfcElement : IfcProduct,
		BuildingSmart.IFC.IfcStructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The tag (or label) identifier at the particular instance of a product, e.g. the serial number, or the position number. It is the identifier at the occurrence level.")]
		public IfcIdentifier? Tag { get; set; }
	
		[InverseProperty("RelatedBuildingElement")] 
		[Description("Reference to the <em>IfcRelFillsElement</em> Relationship that puts the element as a filling into the opening created within another element.    ")]
		[MaxLength(1)]
		public ISet<IfcRelFillsElement> FillsVoids { get; protected set; }
	
		[InverseProperty("RelatingElement")] 
		[Description("Reference to the element connection relationship. The relationship then refers to the other element to which this element is connected to.  ")]
		public ISet<IfcRelConnectsElements> ConnectedTo { get; protected set; }
	
		[InverseProperty("RelatedElement")] 
		[Description("Reference to the interference relationship to indicate the element that is interfered. The relationship, if provided, indicates that this element has an interference with one or many other elements.  <blockquote class=\"note\">NOTE&nbsp; There is no indication of precedence between <em>IsInterferedByElements</em> and <em>InterferesElements</em>. </blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  New inverse relationship.</blockquote>")]
		public ISet<IfcRelInterferesElements> IsInterferedByElements { get; protected set; }
	
		[InverseProperty("RelatingElement")] 
		[Description("Reference to the interference relationship to indicate the element that interferes. The relationship, if provided, indicates that this element has an interference with one or many other elements.  <blockquote class=\"note\">NOTE&nbsp; There is no indication of precedence between <em>IsInterferedByElements</em> and <em>InterferesElements</em>.</blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  New inverse relationship.</blockquote>")]
		public ISet<IfcRelInterferesElements> InterferesElements { get; protected set; }
	
		[InverseProperty("RelatingElement")] 
		[XmlElement]
		[Description("Projection relationship that adds a feature (using a Boolean union) to the <em>IfcBuildingElement</em>.")]
		public ISet<IfcRelProjectsElement> HasProjections { get; protected set; }
	
		[InverseProperty("RelatedElements")] 
		[Description("Reference relationship to the spatial structure element, to which the element is additionally associated. This relationship may not be hierarchical, an element may be referenced by zero, one or many spatial structure elements.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The inverse attribute has been added with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcRelReferencedInSpatialStructure> ReferencedInStructures { get; protected set; }
	
		[InverseProperty("RelatingBuildingElement")] 
		[XmlElement]
		[Description("Reference to the <em>IfcRelVoidsElement</em> relationship that creates an opening in an element. An element can incorporate zero-to-many openings. For each opening, that voids the element, a new relationship <em>IfcRelVoidsElement</em> is generated.  ")]
		public ISet<IfcRelVoidsElement> HasOpenings { get; protected set; }
	
		[InverseProperty("RealizingElements")] 
		[Description("Reference to the connection relationship with realizing element. The relationship, if provided, assigns this element as the realizing element to the connection, which provides the physical manifestation of the connection relationship.  ")]
		public ISet<IfcRelConnectsWithRealizingElements> IsConnectionRealization { get; protected set; }
	
		[InverseProperty("RelatedBuildingElement")] 
		[Description("Reference to space boundaries by virtue of the objectified relationship <em>IfcRelSpaceBoundary</em>. It defines the concept of an element bounding spaces.  ")]
		public ISet<IfcRelSpaceBoundary> ProvidesBoundaries { get; protected set; }
	
		[InverseProperty("RelatedElement")] 
		[Description("Reference to the element connection relationship. The relationship then refers to the other element that is connected to this element.  ")]
		public ISet<IfcRelConnectsElements> ConnectedFrom { get; protected set; }
	
		[InverseProperty("RelatedElements")] 
		[Description("Containment relationship to the spatial structure element, to which the element is primarily associated. This containment relationship has to be hierachical, i.e. an element may only be assigned directly to zero or one spatial structure. ")]
		[MaxLength(1)]
		public ISet<IfcRelContainedInSpatialStructure> ContainedInStructure { get; protected set; }
	
		[InverseProperty("RelatingBuildingElement")] 
		[Description("Reference to <em>IfcCovering</em> by virtue of the objectified relationship <em>IfcRelCoversBldgElement</em>. It defines the concept of an element having coverings associated.")]
		public ISet<IfcRelCoversBldgElements> HasCoverings { get; protected set; }
	
	
		protected IfcElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this.Tag = __Tag;
			this.FillsVoids = new HashSet<IfcRelFillsElement>();
			this.ConnectedTo = new HashSet<IfcRelConnectsElements>();
			this.IsInterferedByElements = new HashSet<IfcRelInterferesElements>();
			this.InterferesElements = new HashSet<IfcRelInterferesElements>();
			this.HasProjections = new HashSet<IfcRelProjectsElement>();
			this.ReferencedInStructures = new HashSet<IfcRelReferencedInSpatialStructure>();
			this.HasOpenings = new HashSet<IfcRelVoidsElement>();
			this.IsConnectionRealization = new HashSet<IfcRelConnectsWithRealizingElements>();
			this.ProvidesBoundaries = new HashSet<IfcRelSpaceBoundary>();
			this.ConnectedFrom = new HashSet<IfcRelConnectsElements>();
			this.ContainedInStructure = new HashSet<IfcRelContainedInSpatialStructure>();
			this.HasCoverings = new HashSet<IfcRelCoversBldgElements>();
		}
	
	
	}
	
}

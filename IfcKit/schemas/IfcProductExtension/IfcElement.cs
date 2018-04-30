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
	
		[InverseProperty("RelatingElement")] 
		public ISet<IfcRelConnectsStructuralElement> HasStructuralMember { get; protected set; }
	
		[InverseProperty("RelatedBuildingElement")] 
		[Description("Reference to the Fills Relationship that puts the Element into the Opening within another Element.  ")]
		[MaxLength(1)]
		public ISet<IfcRelFillsElement> FillsVoids { get; protected set; }
	
		[InverseProperty("RelatingElement")] 
		[Description("Reference to the element connection relationship. The relationship then refers to the other element to which this element is connected to.  ")]
		public ISet<IfcRelConnectsElements> ConnectedTo { get; protected set; }
	
		[InverseProperty("RelatingBuildingElement")] 
		[Description("<EPM-HTML>  Reference to <i>IfcCovering</i> by virtue of the objectified relationship <i>IfcRelCoversBldgElement</i>. It defines the concept of an element having coverings attached.  </EPM-HTML>  ")]
		public ISet<IfcRelCoversBldgElements> HasCoverings { get; protected set; }
	
		[InverseProperty("RelatingElement")] 
		[Description("<EPM-HTML>  Projection relationship that adds a feature (using a Boolean union) to the <I>IfcBuildingElement</I>.  </EPM-HTML>")]
		public ISet<IfcRelProjectsElement> HasProjections { get; protected set; }
	
		[InverseProperty("RelatedElements")] 
		[Description("<EPM-HTML>  Reference relationship to the spatial structure element, to which the element is additionally associated.  <blockquote><font color=\"#ff0000\"><small>  IFC2x Edition 3 CHANGE&nbsp; The inverse attribute has been added with upward compatibility for file based exchange.  <small></font></blockquote>  </EPM-HTML>")]
		public ISet<IfcRelReferencedInSpatialStructure> ReferencedInStructures { get; protected set; }
	
		[InverseProperty("RelatedElement")] 
		[Description("Reference to the element to port connection relationship. The relationship then refers to the port which is contained in this element.  ")]
		public ISet<IfcRelConnectsPortToElement> HasPorts { get; protected set; }
	
		[InverseProperty("RelatingBuildingElement")] 
		[Description("Reference to the Voids Relationship that creates an opening in an element. An element can incorporate zero-to-many openings.  ")]
		public ISet<IfcRelVoidsElement> HasOpenings { get; protected set; }
	
		[InverseProperty("RealizingElements")] 
		[Description("Reference to the connection relationship with realizing element. The relationship then refers to the realizing element which provides the physical manifestation of the connection relationship.  ")]
		public ISet<IfcRelConnectsWithRealizingElements> IsConnectionRealization { get; protected set; }
	
		[InverseProperty("RelatedBuildingElement")] 
		[Description("Reference to Space Boundaries by virtue of the objectified relationship IfcRelSeparatesSpaces. It defines the concept of an Building Element bounding Spaces.  ")]
		public ISet<IfcRelSpaceBoundary> ProvidesBoundaries { get; protected set; }
	
		[InverseProperty("RelatedElement")] 
		[Description("Reference to the element connection relationship. The relationship then refers to the other element that is connected to this element.  ")]
		public ISet<IfcRelConnectsElements> ConnectedFrom { get; protected set; }
	
		[InverseProperty("RelatedElements")] 
		[Description("<EPM-HTML>  Containment relationship to the spatial structure element, to which the element is primarily associated.  </EPM-HTML>")]
		[MaxLength(1)]
		public ISet<IfcRelContainedInSpatialStructure> ContainedInStructure { get; protected set; }
	
	
		protected IfcElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this.Tag = __Tag;
			this.HasStructuralMember = new HashSet<IfcRelConnectsStructuralElement>();
			this.FillsVoids = new HashSet<IfcRelFillsElement>();
			this.ConnectedTo = new HashSet<IfcRelConnectsElements>();
			this.HasCoverings = new HashSet<IfcRelCoversBldgElements>();
			this.HasProjections = new HashSet<IfcRelProjectsElement>();
			this.ReferencedInStructures = new HashSet<IfcRelReferencedInSpatialStructure>();
			this.HasPorts = new HashSet<IfcRelConnectsPortToElement>();
			this.HasOpenings = new HashSet<IfcRelVoidsElement>();
			this.IsConnectionRealization = new HashSet<IfcRelConnectsWithRealizingElements>();
			this.ProvidesBoundaries = new HashSet<IfcRelSpaceBoundary>();
			this.ConnectedFrom = new HashSet<IfcRelConnectsElements>();
			this.ContainedInStructure = new HashSet<IfcRelContainedInSpatialStructure>();
		}
	
	
	}
	
}

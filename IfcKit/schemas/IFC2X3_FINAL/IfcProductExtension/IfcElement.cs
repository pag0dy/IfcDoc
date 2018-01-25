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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("359b20e1-7b56-41e9-ab43-8a1049127ec0")]
	public abstract partial class IfcElement : IfcProduct,
		BuildingSmart.IFC.IfcStructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Tag;
	
		[InverseProperty("RelatingElement")] 
		ISet<IfcRelConnectsStructuralElement> _HasStructuralMember = new HashSet<IfcRelConnectsStructuralElement>();
	
		[InverseProperty("RelatedBuildingElement")] 
		ISet<IfcRelFillsElement> _FillsVoids = new HashSet<IfcRelFillsElement>();
	
		[InverseProperty("RelatingElement")] 
		ISet<IfcRelConnectsElements> _ConnectedTo = new HashSet<IfcRelConnectsElements>();
	
		[InverseProperty("RelatingBuildingElement")] 
		ISet<IfcRelCoversBldgElements> _HasCoverings = new HashSet<IfcRelCoversBldgElements>();
	
		[InverseProperty("RelatingElement")] 
		ISet<IfcRelProjectsElement> _HasProjections = new HashSet<IfcRelProjectsElement>();
	
		[InverseProperty("RelatedElements")] 
		ISet<IfcRelReferencedInSpatialStructure> _ReferencedInStructures = new HashSet<IfcRelReferencedInSpatialStructure>();
	
		[InverseProperty("RelatedElement")] 
		ISet<IfcRelConnectsPortToElement> _HasPorts = new HashSet<IfcRelConnectsPortToElement>();
	
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
	
		public ISet<IfcRelConnectsStructuralElement> HasStructuralMember { get { return this._HasStructuralMember; } }
	
		[Description("Reference to the Fills Relationship that puts the Element into the Opening within" +
	    " another Element.\r\n")]
		public ISet<IfcRelFillsElement> FillsVoids { get { return this._FillsVoids; } }
	
		[Description("Reference to the element connection relationship. The relationship then refers to" +
	    " the other element to which this element is connected to.\r\n")]
		public ISet<IfcRelConnectsElements> ConnectedTo { get { return this._ConnectedTo; } }
	
		[Description("<EPM-HTML>\r\nReference to <i>IfcCovering</i> by virtue of the objectified relation" +
	    "ship <i>IfcRelCoversBldgElement</i>. It defines the concept of an element having" +
	    " coverings attached.\r\n</EPM-HTML>\r\n")]
		public ISet<IfcRelCoversBldgElements> HasCoverings { get { return this._HasCoverings; } }
	
		[Description("<EPM-HTML>\r\nProjection relationship that adds a feature (using a Boolean union) t" +
	    "o the <I>IfcBuildingElement</I>.\r\n</EPM-HTML>")]
		public ISet<IfcRelProjectsElement> HasProjections { get { return this._HasProjections; } }
	
		[Description(@"<EPM-HTML>
	Reference relationship to the spatial structure element, to which the element is additionally associated.
	<blockquote><font color=""#ff0000""><small>
	IFC2x Edition 3 CHANGE&nbsp; The inverse attribute has been added with upward compatibility for file based exchange.
	<small></font></blockquote>
	</EPM-HTML>")]
		public ISet<IfcRelReferencedInSpatialStructure> ReferencedInStructures { get { return this._ReferencedInStructures; } }
	
		[Description("Reference to the element to port connection relationship. The relationship then r" +
	    "efers to the port which is contained in this element.\r\n")]
		public ISet<IfcRelConnectsPortToElement> HasPorts { get { return this._HasPorts; } }
	
		[Description("Reference to the Voids Relationship that creates an opening in an element. An ele" +
	    "ment can incorporate zero-to-many openings.\r\n")]
		public ISet<IfcRelVoidsElement> HasOpenings { get { return this._HasOpenings; } }
	
		[Description("Reference to the connection relationship with realizing element. The relationship" +
	    " then refers to the realizing element which provides the physical manifestation " +
	    "of the connection relationship.\r\n")]
		public ISet<IfcRelConnectsWithRealizingElements> IsConnectionRealization { get { return this._IsConnectionRealization; } }
	
		[Description("Reference to Space Boundaries by virtue of the objectified relationship IfcRelSep" +
	    "aratesSpaces. It defines the concept of an Building Element bounding Spaces.\r\n")]
		public ISet<IfcRelSpaceBoundary> ProvidesBoundaries { get { return this._ProvidesBoundaries; } }
	
		[Description("Reference to the element connection relationship. The relationship then refers to" +
	    " the other element that is connected to this element.\r\n")]
		public ISet<IfcRelConnectsElements> ConnectedFrom { get { return this._ConnectedFrom; } }
	
		[Description("<EPM-HTML>\r\nContainment relationship to the spatial structure element, to which t" +
	    "he element is primarily associated.\r\n</EPM-HTML>")]
		public ISet<IfcRelContainedInSpatialStructure> ContainedInStructure { get { return this._ContainedInStructure; } }
	
	
	}
	
}

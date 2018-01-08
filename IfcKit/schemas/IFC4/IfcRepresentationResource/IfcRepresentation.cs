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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("487b5a0c-6904-49ae-b622-ec42a5535b20")]
	public abstract partial class IfcRepresentation :
		BuildingSmart.IFC.IfcPresentationOrganizationResource.IfcLayeredItem
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcRepresentationContext")]
		[Required()]
		IfcRepresentationContext _ContextOfItems;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _RepresentationIdentifier;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _RepresentationType;
	
		[DataMember(Order=3)] 
		[Required()]
		ISet<IfcRepresentationItem> _Items = new HashSet<IfcRepresentationItem>();
	
		[InverseProperty("MappedRepresentation")] 
		ISet<IfcRepresentationMap> _RepresentationMap = new HashSet<IfcRepresentationMap>();
	
		[InverseProperty("AssignedItems")] 
		ISet<IfcPresentationLayerAssignment> _LayerAssignments = new HashSet<IfcPresentationLayerAssignment>();
	
		[InverseProperty("Representations")] 
		ISet<IfcProductRepresentation> _OfProductRepresentation = new HashSet<IfcProductRepresentation>();
	
	
		[Description("Definition of the representation context for which the different subtypes of repr" +
	    "esentation are valid.")]
		public IfcRepresentationContext ContextOfItems { get { return this._ContextOfItems; } set { this._ContextOfItems = value;} }
	
		[Description("The optional identifier of the representation as used within a project.")]
		public IfcLabel? RepresentationIdentifier { get { return this._RepresentationIdentifier; } set { this._RepresentationIdentifier = value;} }
	
		[Description(@"The description of the type of a representation context. The representation type defines the type of geometry or topology used for representing the product representation. More information is given at the subtypes <em>IfcShapeRepresentation</em> and <em>IfcTopologyRepresentation</em>.<br>
	The supported values for context type are to be specified by implementers agreements.
	")]
		public IfcLabel? RepresentationType { get { return this._RepresentationType; } set { this._RepresentationType = value;} }
	
		[Description("Set of geometric representation items that are defined for this representation.")]
		public ISet<IfcRepresentationItem> Items { get { return this._Items; } }
	
		[Description(@"Use of the representation within an <em>IfcRepresentationMap</em>. If used, this <em>IfcRepresentation</em> may be assigned to many representations as one of its <em>Items</em> using an <em>IfcMappedItem</em>. Using <em>IfcRepresentationMap</em> is the way to share one representation (often of type <em>IfcShapeRepresentation</em>) by many products.  
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The inverse attribute <em>LayerAssignments</em> has been added</blockquote>")]
		public ISet<IfcRepresentationMap> RepresentationMap { get { return this._RepresentationMap; } }
	
		[Description(@"Assignment of the whole representation to a single or multiple layer(s). The <em>LayerAssigments</em> can be overridden by <em>LayerAssigments</em> of the <em>IfcRepresentationItem</em>'s within the list of <em>Items</em>.
	<blockquote class=""note"">NOTE&nbsp; Implementation agreements can restrict the maximum number of layer assignments to 1.</blockquote>
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The inverse attribute <em>LayerAssignments</em> has been added</blockquote>")]
		public ISet<IfcPresentationLayerAssignment> LayerAssignments { get { return this._LayerAssignments; } }
	
		[Description(@"Reference to the product representations to which this individual representation applies. In most cases it is the reference to one or many product shapes, to which this shape representation is applicable.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE Inverse relationship cardinality relaxed to be 0:N.</blockquote>")]
		public ISet<IfcProductRepresentation> OfProductRepresentation { get { return this._OfProductRepresentation; } }
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	public abstract partial class IfcRepresentation :
		BuildingSmart.IFC.IfcPresentationOrganizationResource.IfcLayeredItem
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Definition of the representation context for which the different subtypes of representation are valid.")]
		[Required()]
		public IfcRepresentationContext ContextOfItems { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The optional identifier of the representation as used within a project.")]
		public IfcLabel? RepresentationIdentifier { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The description of the type of a representation context. The representation type defines the type of geometry or topology used for representing the product representation. More information is given at the subtypes <em>IfcShapeRepresentation</em> and <em>IfcTopologyRepresentation</em>.<br>  The supported values for context type are to be specified by implementers agreements.  ")]
		public IfcLabel? RepresentationType { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Set of geometric representation items that are defined for this representation.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcRepresentationItem> Items { get; protected set; }
	
		[InverseProperty("MappedRepresentation")] 
		[Description("Use of the representation within an <em>IfcRepresentationMap</em>. If used, this <em>IfcRepresentation</em> may be assigned to many representations as one of its <em>Items</em> using an <em>IfcMappedItem</em>. Using <em>IfcRepresentationMap</em> is the way to share one representation (often of type <em>IfcShapeRepresentation</em>) by many products.    <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The inverse attribute <em>LayerAssignments</em> has been added</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcRepresentationMap> RepresentationMap { get; protected set; }
	
		[InverseProperty("AssignedItems")] 
		[Description("Assignment of the whole representation to a single or multiple layer(s). The <em>LayerAssigments</em> can be overridden by <em>LayerAssigments</em> of the <em>IfcRepresentationItem</em>'s within the list of <em>Items</em>.  <blockquote class=\"note\">NOTE&nbsp; Implementation agreements can restrict the maximum number of layer assignments to 1.</blockquote>  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The inverse attribute <em>LayerAssignments</em> has been added</blockquote>")]
		public ISet<IfcPresentationLayerAssignment> LayerAssignments { get; protected set; }
	
		[InverseProperty("Representations")] 
		[Description("Reference to the product representations to which this individual representation applies. In most cases it is the reference to one or many product shapes, to which this shape representation is applicable.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Inverse relationship cardinality relaxed to be 0:N.</blockquote>")]
		public ISet<IfcProductRepresentation> OfProductRepresentation { get; protected set; }
	
	
		protected IfcRepresentation(IfcRepresentationContext __ContextOfItems, IfcLabel? __RepresentationIdentifier, IfcLabel? __RepresentationType, IfcRepresentationItem[] __Items)
		{
			this.ContextOfItems = __ContextOfItems;
			this.RepresentationIdentifier = __RepresentationIdentifier;
			this.RepresentationType = __RepresentationType;
			this.Items = new HashSet<IfcRepresentationItem>(__Items);
			this.RepresentationMap = new HashSet<IfcRepresentationMap>();
			this.LayerAssignments = new HashSet<IfcPresentationLayerAssignment>();
			this.OfProductRepresentation = new HashSet<IfcProductRepresentation>();
		}
	
	
	}
	
}

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
	public partial class IfcRepresentation :
		BuildingSmart.IFC.IfcPresentationOrganizationResource.IfcLayeredItem
	{
		[DataMember(Order = 0)] 
		[Description("Definition of the representation context for which the different subtypes of representation are valid.")]
		[Required()]
		public IfcRepresentationContext ContextOfItems { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The optional identifier of the representation as used within a project.")]
		public IfcLabel? RepresentationIdentifier { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  The description of the type of a representation context. The representation type defines the type of geometry or topology used for representing the product representation. More information is given at the subtypes <i>IfcShapeRepresentation</i> and <i>IfcTopologyRepresentation</i>.<br>  The supported values for context type are to be specified by implementers agreements.  </EPM-HTML>  ")]
		public IfcLabel? RepresentationType { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Set of geometric representation items that are defined for this representation.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcRepresentationItem> Items { get; protected set; }
	
		[InverseProperty("MappedRepresentation")] 
		[Description("<EPM-HTML>  Use of the representation within an <i>IfcRepresentationMap</i>. If used, this <i>IfcRepresentation</i> may be assigned to many representations as one of its <i>Items</i> using an <i>IfcMappedItem</i>. Using <i>IfcRepresentationMap</i> is the way to share one representation (often of type <i>IfcShapeRepresentation</i>) by many products.    <blockquote><small><font color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The inverse attribute <i>LayerAssignments</i> has been added.  </font></small></blockquote>  </EPM-HTML>")]
		[MaxLength(1)]
		public ISet<IfcRepresentationMap> RepresentationMap { get; protected set; }
	
		[InverseProperty("AssignedItems")] 
		[Description("<EPM-HTML>Assignment of the whole representation to a single or multiple layer(s). The <i>LayerAssigments</i> can be overridden by <i>LayerAssigments</i> of the <i>IfcRepresentationItem</i>'s within the list of <i>Items</i>.  <blockquote><small>NOTE&nbsp; Implementation agreements can restrict the maximum number of layer assignments to 1.</small><br>  <small><font color=\"#ff0000\">IFC2x Edition 3 CHANGE&nbsp; The inverse attribute <i>LayerAssignments</i> has been added.  </font></small></blockquote>  </EPM-HTML>")]
		public ISet<IfcPresentationLayerAssignment> LayerAssignments { get; protected set; }
	
		[InverseProperty("Representations")] 
		[Description("Reference to the product shape, for which it is the shape representation.")]
		[MaxLength(1)]
		public ISet<IfcProductRepresentation> OfProductRepresentation { get; protected set; }
	
	
		public IfcRepresentation(IfcRepresentationContext __ContextOfItems, IfcLabel? __RepresentationIdentifier, IfcLabel? __RepresentationType, IfcRepresentationItem[] __Items)
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

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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("bf7fe405-8cc7-4087-8869-ecbcd4450062")]
	public partial class IfcRepresentation :
		BuildingSmart.IFC.IfcPresentationOrganizationResource.IfcLayeredItem
	{
		[DataMember(Order=0)] 
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
		[MinLength(1)]
		ISet<IfcRepresentationItem> _Items = new HashSet<IfcRepresentationItem>();
	
		[InverseProperty("MappedRepresentation")] 
		[MaxLength(1)]
		ISet<IfcRepresentationMap> _RepresentationMap = new HashSet<IfcRepresentationMap>();
	
		[InverseProperty("AssignedItems")] 
		ISet<IfcPresentationLayerAssignment> _LayerAssignments = new HashSet<IfcPresentationLayerAssignment>();
	
		[InverseProperty("Representations")] 
		[MaxLength(1)]
		ISet<IfcProductRepresentation> _OfProductRepresentation = new HashSet<IfcProductRepresentation>();
	
	
		public IfcRepresentation()
		{
		}
	
		public IfcRepresentation(IfcRepresentationContext __ContextOfItems, IfcLabel? __RepresentationIdentifier, IfcLabel? __RepresentationType, IfcRepresentationItem[] __Items)
		{
			this._ContextOfItems = __ContextOfItems;
			this._RepresentationIdentifier = __RepresentationIdentifier;
			this._RepresentationType = __RepresentationType;
			this._Items = new HashSet<IfcRepresentationItem>(__Items);
		}
	
		[Description("Definition of the representation context for which the different subtypes of repr" +
	    "esentation are valid.")]
		public IfcRepresentationContext ContextOfItems { get { return this._ContextOfItems; } set { this._ContextOfItems = value;} }
	
		[Description("The optional identifier of the representation as used within a project.")]
		public IfcLabel? RepresentationIdentifier { get { return this._RepresentationIdentifier; } set { this._RepresentationIdentifier = value;} }
	
		[Description(@"<EPM-HTML>
	The description of the type of a representation context. The representation type defines the type of geometry or topology used for representing the product representation. More information is given at the subtypes <i>IfcShapeRepresentation</i> and <i>IfcTopologyRepresentation</i>.<br>
	The supported values for context type are to be specified by implementers agreements.
	</EPM-HTML>
	")]
		public IfcLabel? RepresentationType { get { return this._RepresentationType; } set { this._RepresentationType = value;} }
	
		[Description("Set of geometric representation items that are defined for this representation.")]
		public ISet<IfcRepresentationItem> Items { get { return this._Items; } }
	
		[Description(@"<EPM-HTML>
	Use of the representation within an <i>IfcRepresentationMap</i>. If used, this <i>IfcRepresentation</i> may be assigned to many representations as one of its <i>Items</i> using an <i>IfcMappedItem</i>. Using <i>IfcRepresentationMap</i> is the way to share one representation (often of type <i>IfcShapeRepresentation</i>) by many products.  
	<blockquote><small><font color=""#ff0000"">
	IFC2x Edition 3 CHANGE&nbsp; The inverse attribute <i>LayerAssignments</i> has been added.
	</font></small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcRepresentationMap> RepresentationMap { get { return this._RepresentationMap; } }
	
		[Description(@"<EPM-HTML>Assignment of the whole representation to a single or multiple layer(s). The <i>LayerAssigments</i> can be overridden by <i>LayerAssigments</i> of the <i>IfcRepresentationItem</i>'s within the list of <i>Items</i>.
	<blockquote><small>NOTE&nbsp; Implementation agreements can restrict the maximum number of layer assignments to 1.</small><br>
	<small><font color=""#ff0000"">IFC2x Edition 3 CHANGE&nbsp; The inverse attribute <i>LayerAssignments</i> has been added.
	</font></small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcPresentationLayerAssignment> LayerAssignments { get { return this._LayerAssignments; } }
	
		[Description("Reference to the product shape, for which it is the shape representation.")]
		public ISet<IfcProductRepresentation> OfProductRepresentation { get { return this._OfProductRepresentation; } }
	
	
	}
	
}

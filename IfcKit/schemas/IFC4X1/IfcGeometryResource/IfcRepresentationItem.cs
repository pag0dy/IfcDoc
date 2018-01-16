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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("e783d84d-d19b-4cf7-a863-f851642523f8")]
	public abstract partial class IfcRepresentationItem :
		BuildingSmart.IFC.IfcPresentationOrganizationResource.IfcLayeredItem
	{
		[InverseProperty("AssignedItems")] 
		ISet<IfcPresentationLayerAssignment> _LayerAssignment = new HashSet<IfcPresentationLayerAssignment>();
	
		[InverseProperty("Item")] 
		[XmlElement]
		ISet<IfcStyledItem> _StyledByItem = new HashSet<IfcStyledItem>();
	
	
		[Description(@"Assignment of the representation item to a single or multiple layer(s). The <em>LayerAssignments</em> can override a <em>LayerAssignments</em> of the <em>IfcRepresentation</em> it is used  within the list of <em>Items</em>.
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The inverse attribute <em>LayerAssignments</em> has been added.</blockquote>
	 <blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The inverse attribute <em>LayerAssignment</em> has
	been restricted to max 1. Upward compatibility for file based exchange is guaranteed. </blockquote>")]
		public ISet<IfcPresentationLayerAssignment> LayerAssignment { get { return this._LayerAssignment; } }
	
		[Description(@"Reference to the <em>IfcStyledItem</em> that provides presentation information to the representation, e.g. a curve style, including colour and thickness to a geometric curve.
	  <blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The inverse attribute <em>StyledByItem</em> has been added.</blockquote>")]
		public ISet<IfcStyledItem> StyledByItem { get { return this._StyledByItem; } }
	
	
	}
	
}

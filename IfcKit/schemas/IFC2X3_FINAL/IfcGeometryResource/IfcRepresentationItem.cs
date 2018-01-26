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

using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("b1f3ba6a-d5a7-4a2b-9718-3deb4fbf8a02")]
	public abstract partial class IfcRepresentationItem :
		BuildingSmart.IFC.IfcPresentationOrganizationResource.IfcLayeredItem
	{
		[InverseProperty("AssignedItems")] 
		ISet<IfcPresentationLayerAssignment> _LayerAssignments = new HashSet<IfcPresentationLayerAssignment>();
	
		[InverseProperty("Item")] 
		[MaxLength(1)]
		ISet<IfcStyledItem> _StyledByItem = new HashSet<IfcStyledItem>();
	
	
		public IfcRepresentationItem()
		{
		}
	
		[Description(@"<EPM-HTML>Assignment of the representation item to a single or multiple layer(s). The <i>LayerAssignments</i> can override a <i>LayerAssignments</i> of the <i>IfcRepresentation</i> it is used  within the list of <i>Items</i>.
	<blockquote>
	<small>NOTE&nbsp; Implementation agreements can restrict the maximum number of layer assignments to 1.</small><br>
	<small><font color=""#ff0000"">IFC2x Edition 3 CHANGE&nbsp; The inverse attribute <i>LayerAssignments</i> has been added.</font></small>
	</blockquote>
	</EPM-HTML>")]
		public ISet<IfcPresentationLayerAssignment> LayerAssignments { get { return this._LayerAssignments; } }
	
		[Description(@"<EPM-HTML>
	Reference to the <i>IfcStyledItem</i> that provides presentation information to the representation, e.g. a curve style, including colour and thickness to a geometric curve.
	  <blockquote>
	<small><font color=""#ff0000"">IFC2x Edition 3 CHANGE&nbsp; The inverse attribute <i>StyledByItem</i> has been added.</font></small>
	</blockquote>
	</EPM-HTML>")]
		public ISet<IfcStyledItem> StyledByItem { get { return this._StyledByItem; } }
	
	
	}
	
}

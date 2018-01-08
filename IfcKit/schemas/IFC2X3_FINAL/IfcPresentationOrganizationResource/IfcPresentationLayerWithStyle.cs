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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	[Guid("f5035d0f-eddb-4069-b0c6-f085cd5fec1f")]
	public partial class IfcPresentationLayerWithStyle : IfcPresentationLayerAssignment
	{
		[DataMember(Order=0)] 
		[Required()]
		Boolean? _LayerOn;
	
		[DataMember(Order=1)] 
		[Required()]
		Boolean? _LayerFrozen;
	
		[DataMember(Order=2)] 
		[Required()]
		Boolean? _LayerBlocked;
	
		[DataMember(Order=3)] 
		[Required()]
		ISet<IfcPresentationStyleSelect> _LayerStyles = new HashSet<IfcPresentationStyleSelect>();
	
	
		[Description("A logical setting, TRUE indicates that the layer is set to \'On\', FALSE that the l" +
	    "ayer is set to \'Off\', UNKNOWN that such information is not available.")]
		public Boolean? LayerOn { get { return this._LayerOn; } set { this._LayerOn = value;} }
	
		[Description("A logical setting, TRUE indicates that the layer is set to \'Frozen\', FALSE that t" +
	    "he layer is set to \'Not frozen\', UNKNOWN that such information is not available." +
	    "")]
		public Boolean? LayerFrozen { get { return this._LayerFrozen; } set { this._LayerFrozen = value;} }
	
		[Description("A logical setting, TRUE indicates that the layer is set to \'Blocked\', FALSE that " +
	    "the layer is set to \'Not blocked\', UNKNOWN that such information is not availabl" +
	    "e.")]
		public Boolean? LayerBlocked { get { return this._LayerBlocked; } set { this._LayerBlocked = value;} }
	
		[Description(@"<EPM-HTML>
	Assignment of presentation styles to the layer to provide a default style for representation items.
	<blockquote><small>
	NOTE&nbsp; In most cases the assignment of styles to a layer is restricted to an <i>IfcCurveStyle</i> representing the layer curve colour, layer curve thickness, and layer curve type.
	</small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcPresentationStyleSelect> LayerStyles { get { return this._LayerStyles; } }
	
	
	}
	
}

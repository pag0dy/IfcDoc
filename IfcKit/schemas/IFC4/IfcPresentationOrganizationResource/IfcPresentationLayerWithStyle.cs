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
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	[Guid("d58d8ae7-e309-454d-b3f1-2b58ce4d583d")]
	public partial class IfcPresentationLayerWithStyle : IfcPresentationLayerAssignment
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLogical _LayerOn;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLogical _LayerFrozen;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcLogical _LayerBlocked;
	
		[DataMember(Order=3)] 
		[Required()]
		ISet<IfcPresentationStyle> _LayerStyles = new HashSet<IfcPresentationStyle>();
	
	
		[Description("A logical setting, TRUE indicates that the layer is set to \'On\', FALSE that the l" +
	    "ayer is set to \'Off\', UNKNOWN that such information is not available.")]
		public IfcLogical LayerOn { get { return this._LayerOn; } set { this._LayerOn = value;} }
	
		[Description("A logical setting, TRUE indicates that the layer is set to \'Frozen\', FALSE that t" +
	    "he layer is set to \'Not frozen\', UNKNOWN that such information is not available." +
	    "")]
		public IfcLogical LayerFrozen { get { return this._LayerFrozen; } set { this._LayerFrozen = value;} }
	
		[Description("A logical setting, TRUE indicates that the layer is set to \'Blocked\', FALSE that " +
	    "the layer is set to \'Not blocked\', UNKNOWN that such information is not availabl" +
	    "e.")]
		public IfcLogical LayerBlocked { get { return this._LayerBlocked; } set { this._LayerBlocked = value;} }
	
		[Description(@"Assignment of presentation styles to the layer to provide a default style for representation items.
	<blockquote class=""note"">NOTE&nbsp; In most cases the assignment of styles to a layer is restricted to an <em>IfcCurveStyle</em> representing the layer curve colour, layer curve thickness, and layer curve type.
	  </blockquote>
	  <blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; The data type has been changed from <em>IfcPresentationStyleSelect</em> (now deprecated) to <em>IfcPresentationStyle</em>.
	</blockquote>")]
		public ISet<IfcPresentationStyle> LayerStyles { get { return this._LayerStyles; } }
	
	
	}
	
}

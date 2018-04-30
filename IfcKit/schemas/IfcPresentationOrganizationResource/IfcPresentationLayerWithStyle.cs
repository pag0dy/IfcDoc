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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	public partial class IfcPresentationLayerWithStyle : IfcPresentationLayerAssignment
	{
		[DataMember(Order = 0)] 
		[Description("A logical setting, TRUE indicates that the layer is set to 'On', FALSE that the layer is set to 'Off', UNKNOWN that such information is not available.")]
		[Required()]
		public Boolean? LayerOn { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A logical setting, TRUE indicates that the layer is set to 'Frozen', FALSE that the layer is set to 'Not frozen', UNKNOWN that such information is not available.")]
		[Required()]
		public Boolean? LayerFrozen { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("A logical setting, TRUE indicates that the layer is set to 'Blocked', FALSE that the layer is set to 'Not blocked', UNKNOWN that such information is not available.")]
		[Required()]
		public Boolean? LayerBlocked { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("<EPM-HTML>  Assignment of presentation styles to the layer to provide a default style for representation items.  <blockquote><small>  NOTE&nbsp; In most cases the assignment of styles to a layer is restricted to an <i>IfcCurveStyle</i> representing the layer curve colour, layer curve thickness, and layer curve type.  </small></blockquote>  </EPM-HTML>")]
		[Required()]
		public ISet<IfcPresentationStyleSelect> LayerStyles { get; protected set; }
	
	
		public IfcPresentationLayerWithStyle(IfcLabel __Name, IfcText? __Description, IfcLayeredItem[] __AssignedItems, IfcIdentifier? __Identifier, Boolean? __LayerOn, Boolean? __LayerFrozen, Boolean? __LayerBlocked, IfcPresentationStyleSelect[] __LayerStyles)
			: base(__Name, __Description, __AssignedItems, __Identifier)
		{
			this.LayerOn = __LayerOn;
			this.LayerFrozen = __LayerFrozen;
			this.LayerBlocked = __LayerBlocked;
			this.LayerStyles = new HashSet<IfcPresentationStyleSelect>(__LayerStyles);
		}
	
	
	}
	
}

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
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcSurfaceStyleShading : IfcPresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The colour used to render the surface. The surface colour for visualisation is defined by specifying the intensity of red, green and blue.  ")]
		[Required()]
		public IfcColourRgb SurfaceColour { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The transparency field specifies how \"clear\" an object is, with 1.0 being completely transparent, and 0.0 completely opaque. If not given, the value 0.0 (opaque) is assumed.  <blockquote class=\"note\">NOTE&nbsp; The definition of 1 being transparent and 0 being opaque is the opposite of the definition in alpha channels, where 0.0 is completely transparent and 1.0 is completely opaque. This definition is due to upward compatibility to previous versions of this standard in different to the definition in <i>IfcIndexedColourMap</i>.</blockquote>")]
		public IfcNormalisedRatioMeasure? Transparency { get; set; }
	
	
		public IfcSurfaceStyleShading(IfcColourRgb __SurfaceColour, IfcNormalisedRatioMeasure? __Transparency)
		{
			this.SurfaceColour = __SurfaceColour;
			this.Transparency = __Transparency;
		}
	
	
	}
	
}

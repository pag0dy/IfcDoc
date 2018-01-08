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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("4d15ed6e-2d9b-4101-a12a-055e03cab045")]
	public partial class IfcSurfaceStyleShading : IfcPresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcColourRgb")]
		[Required()]
		IfcColourRgb _SurfaceColour;
	
	
		[Description("The colour used to render the surface. The surface colour for visualisation is de" +
	    "fined by specifying the intensity of red, green and blue.\r\n")]
		public IfcColourRgb SurfaceColour { get { return this._SurfaceColour; } set { this._SurfaceColour = value;} }
	
	
	}
	
}

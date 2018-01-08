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
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("974b693a-e0b3-47bc-86c8-0a6f07bec617")]
	public partial class IfcSurfaceStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcSurfaceSide _Side;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcSurfaceStyleElementSelect> _Styles = new HashSet<IfcSurfaceStyleElementSelect>();
	
	
		[Description("An indication of which side of the surface to apply the style.")]
		public IfcSurfaceSide Side { get { return this._Side; } set { this._Side = value;} }
	
		[Description("A collection of different surface styles.")]
		public ISet<IfcSurfaceStyleElementSelect> Styles { get { return this._Styles; } }
	
	
	}
	
}

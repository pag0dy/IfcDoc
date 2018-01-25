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
	[Guid("8b1d947d-68b2-4aab-b866-8b1fb6d7e22a")]
	public partial class IfcSurfaceStyleWithTextures : IfcPresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcSurfaceTexture> _Textures = new List<IfcSurfaceTexture>();
	
	
		[Description("The textures applied to the surface. In case of more than one surface texture is " +
	    "included, the <em>IfcSurfaceStyleWithTexture</em> defines a multi texture.\r\n</EM" +
	    "P-HTML>")]
		public IList<IfcSurfaceTexture> Textures { get { return this._Textures; } }
	
	
	}
	
}

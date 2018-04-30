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

using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcSurfaceStyleWithTextures : IfcPresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
		[DataMember(Order = 0)] 
		[Description("The textures applied to the surface. In case of more than one surface texture is included, the <em>IfcSurfaceStyleWithTexture</em> defines a multi texture.  </EMP-HTML>")]
		[Required()]
		[MinLength(1)]
		public IList<IfcSurfaceTexture> Textures { get; protected set; }
	
	
		public IfcSurfaceStyleWithTextures(IfcSurfaceTexture[] __Textures)
		{
			this.Textures = new List<IfcSurfaceTexture>(__Textures);
		}
	
	
	}
	
}

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


namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("026decc8-92b6-4199-a0d0-600130d2010e")]
	public partial class IfcSurfaceStyleWithTextures :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcSurfaceTexture> _Textures = new List<IfcSurfaceTexture>();
	
	
		public IfcSurfaceStyleWithTextures()
		{
		}
	
		public IfcSurfaceStyleWithTextures(IfcSurfaceTexture[] __Textures)
		{
			this._Textures = new List<IfcSurfaceTexture>(__Textures);
		}
	
		[Description("The textures applied to the surface. Only one image map with the same image map t" +
	    "ype shall be applied.")]
		public IList<IfcSurfaceTexture> Textures { get { return this._Textures; } }
	
	
	}
	
}

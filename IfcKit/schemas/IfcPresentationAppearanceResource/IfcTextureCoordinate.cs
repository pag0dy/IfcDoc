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
	public abstract partial class IfcTextureCoordinate : IfcPresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("Reference to the one (or many in case of multi textures with identity transformation to geometric surfaces) subtype(s) of <em>IfcSurfaceTexture</em> that are mapped to a geometric surface by the texture coordinate transformation.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcSurfaceTexture> Maps { get; protected set; }
	
	
		protected IfcTextureCoordinate(IfcSurfaceTexture[] __Maps)
		{
			this.Maps = new List<IfcSurfaceTexture>(__Maps);
		}
	
	
	}
	
}

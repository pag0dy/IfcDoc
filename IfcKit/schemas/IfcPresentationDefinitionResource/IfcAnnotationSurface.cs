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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	public partial class IfcAnnotationSurface : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  Geometric representation item, providing the geometric definition of the annotated surface. It is further restricted to be a surface, surface model, or solid model.  </EPM-HTML>")]
		[Required()]
		public IfcGeometricRepresentationItem Item { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("<EPM-HTML>  Texture coordinates, such as a texture map, that are associated with the textures for the surface style. It should only be given, if the <i>IfcSurfaceStyle</i> associated to the <i>IfcAnnotationSurfaceOccurrence</i> contains an <i>IfcSurfaceStyleWithTextures</i>.  </EPM-HTML>")]
		public IfcTextureCoordinate TextureCoordinates { get; set; }
	
	
		public IfcAnnotationSurface(IfcGeometricRepresentationItem __Item, IfcTextureCoordinate __TextureCoordinates)
		{
			this.Item = __Item;
			this.TextureCoordinates = __TextureCoordinates;
		}
	
	
	}
	
}

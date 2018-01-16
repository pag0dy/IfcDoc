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
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("af9f2ce7-6f0e-41ef-9755-806c8395c117")]
	public partial class IfcAnnotationSurface : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcGeometricRepresentationItem _Item;
	
		[DataMember(Order=1)] 
		IfcTextureCoordinate _TextureCoordinates;
	
	
		[Description("<EPM-HTML>\r\nGeometric representation item, providing the geometric definition of " +
	    "the annotated surface. It is further restricted to be a surface, surface model, " +
	    "or solid model.\r\n</EPM-HTML>")]
		public IfcGeometricRepresentationItem Item { get { return this._Item; } set { this._Item = value;} }
	
		[Description(@"<EPM-HTML>
	Texture coordinates, such as a texture map, that are associated with the textures for the surface style. It should only be given, if the <i>IfcSurfaceStyle</i> associated to the <i>IfcAnnotationSurfaceOccurrence</i> contains an <i>IfcSurfaceStyleWithTextures</i>.
	</EPM-HTML>")]
		public IfcTextureCoordinate TextureCoordinates { get { return this._TextureCoordinates; } set { this._TextureCoordinates = value;} }
	
	
	}
	
}

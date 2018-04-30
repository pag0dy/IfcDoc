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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public abstract partial class IfcIndexedTextureMap : IfcTextureCoordinate
	{
		[DataMember(Order = 0)] 
		[XmlIgnore]
		[Description("Reference to the <em>IfcTessellatedFaceSet</em> to which it applies the texture map.")]
		[Required()]
		public IfcTessellatedFaceSet MappedTo { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Indexable list of texture vertices.")]
		[Required()]
		public IfcTextureVertexList TexCoords { get; set; }
	
	
		protected IfcIndexedTextureMap(IfcSurfaceTexture[] __Maps, IfcTessellatedFaceSet __MappedTo, IfcTextureVertexList __TexCoords)
			: base(__Maps)
		{
			this.MappedTo = __MappedTo;
			this.TexCoords = __TexCoords;
		}
	
	
	}
	
}

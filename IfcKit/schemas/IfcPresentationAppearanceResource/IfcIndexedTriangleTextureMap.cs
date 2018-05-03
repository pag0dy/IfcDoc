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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcIndexedTriangleTextureMap : IfcIndexedTextureMap
	{
		[DataMember(Order = 0)] 
		[Description("Index into the <em>IfcTextureVertexList</em> for each vertex of the triangles representing the <em>IfcTriangulatedFaceSet</em>.")]
		[MinLength(1)]
		public IList<IfcPositiveInteger> TexCoordIndex { get; protected set; }
	
	
		public IfcIndexedTriangleTextureMap(IfcSurfaceTexture[] __Maps, IfcTessellatedFaceSet __MappedTo, IfcTextureVertexList __TexCoords, IfcPositiveInteger[] __TexCoordIndex)
			: base(__Maps, __MappedTo, __TexCoords)
		{
			this.TexCoordIndex = new List<IfcPositiveInteger>(__TexCoordIndex);
		}
	
	
	}
	
}

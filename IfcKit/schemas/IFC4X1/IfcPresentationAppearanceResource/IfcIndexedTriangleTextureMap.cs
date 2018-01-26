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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("2749b740-94fa-4cfa-ba95-c6f30ee8024d")]
	public partial class IfcIndexedTriangleTextureMap : IfcIndexedTextureMap
	{
		[DataMember(Order=0)] 
		[MinLength(1)]
		IList<IfcPositiveInteger> _TexCoordIndex = new List<IfcPositiveInteger>();
	
	
		public IfcIndexedTriangleTextureMap()
		{
		}
	
		public IfcIndexedTriangleTextureMap(IfcSurfaceTexture[] __Maps, IfcTessellatedFaceSet __MappedTo, IfcTextureVertexList __TexCoords, IfcPositiveInteger[] __TexCoordIndex)
			: base(__Maps, __MappedTo, __TexCoords)
		{
			this._TexCoordIndex = new List<IfcPositiveInteger>(__TexCoordIndex);
		}
	
		[Description("Index into the <em>IfcTextureVertexList</em> for each vertex of the triangles rep" +
	    "resenting the <em>IfcTriangulatedFaceSet</em>.")]
		public IList<IfcPositiveInteger> TexCoordIndex { get { return this._TexCoordIndex; } }
	
	
	}
	
}

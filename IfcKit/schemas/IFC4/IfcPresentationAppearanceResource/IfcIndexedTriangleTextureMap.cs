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
	[Guid("2749b740-94fa-4cfa-ba95-c6f30ee8024d")]
	public partial class IfcIndexedTriangleTextureMap : IfcIndexedTextureMap
	{
		[DataMember(Order=0)] 
		IList<IfcPositiveInteger> _TexCoordIndex = new List<IfcPositiveInteger>();
	
	
		[Description("Index into the <em>IfcTextureVertexList</em> for each vertex of the triangles rep" +
	    "resenting the <em>IfcTriangulatedFaceSet</em>.")]
		public IList<IfcPositiveInteger> TexCoordIndex { get { return this._TexCoordIndex; } }
	
	
	}
	
}

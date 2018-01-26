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

using BuildingSmart.IFC.IfcGeometryResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("df4abbc5-736f-431d-ad9a-871f349d114c")]
	public partial class IfcVertexBasedTextureMap
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(3)]
		IList<IfcTextureVertex> _TextureVertices = new List<IfcTextureVertex>();
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(3)]
		IList<IfcCartesianPoint> _TexturePoints = new List<IfcCartesianPoint>();
	
	
		public IfcVertexBasedTextureMap()
		{
		}
	
		public IfcVertexBasedTextureMap(IfcTextureVertex[] __TextureVertices, IfcCartesianPoint[] __TexturePoints)
		{
			this._TextureVertices = new List<IfcTextureVertex>(__TextureVertices);
			this._TexturePoints = new List<IfcCartesianPoint>(__TexturePoints);
		}
	
		[Description("List of texture vertex coordinates, each texture vertex refers to the Cartesian p" +
	    "oint within the polyloop (corresponding lists). The first coordinate[1] is the S" +
	    ", the second coordinate[2] is the T parameter value.")]
		public IList<IfcTextureVertex> TextureVertices { get { return this._TextureVertices; } }
	
		[Description("Reference to a list of polyloop\'s defining a face bound of a face within a vertex" +
	    " based geometry.")]
		public IList<IfcCartesianPoint> TexturePoints { get { return this._TexturePoints; } }
	
	
	}
	
}

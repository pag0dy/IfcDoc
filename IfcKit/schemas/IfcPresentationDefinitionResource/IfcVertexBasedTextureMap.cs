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

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	public partial class IfcVertexBasedTextureMap
	{
		[DataMember(Order = 0)] 
		[Description("List of texture vertex coordinates, each texture vertex refers to the Cartesian point within the polyloop (corresponding lists). The first coordinate[1] is the S, the second coordinate[2] is the T parameter value.")]
		[Required()]
		[MinLength(3)]
		public IList<IfcTextureVertex> TextureVertices { get; protected set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to a list of polyloop's defining a face bound of a face within a vertex based geometry.")]
		[Required()]
		[MinLength(3)]
		public IList<IfcCartesianPoint> TexturePoints { get; protected set; }
	
	
		public IfcVertexBasedTextureMap(IfcTextureVertex[] __TextureVertices, IfcCartesianPoint[] __TexturePoints)
		{
			this.TextureVertices = new List<IfcTextureVertex>(__TextureVertices);
			this.TexturePoints = new List<IfcCartesianPoint>(__TexturePoints);
		}
	
	
	}
	
}

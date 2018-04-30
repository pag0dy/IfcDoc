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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcTriangulatedFaceSet : IfcTessellatedFaceSet
	{
		[DataMember(Order = 0)] 
		[Description("An ordered list of three directions for normals. It is a two-dimensional list of directions provided by three parameter   values.  <ul>   <li class=\"small\">The first dimension corresponds to the vertex indices of the <i>Coordindex</i></li>   <li class=\"small\">The second dimension has exactly three values, [1] the x-direction, [2] the y-direction and [3] the z-directions</li>  </ul>")]
		[MinLength(1)]
		public IList<IfcParameterValue> Normals { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Indication whether the <em>IfcTriangulatedFaceSet</em> is a closed shell or not. If omited no such information can be provided.")]
		public IfcBoolean? Closed { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Two-dimensional list for the indexed-based triangles, where   <ul>   <li class=\"small\">The first dimension represents the triangles (from 1 to N)</li>   <li class=\"small\">The second dimension has exactly three values representing the indices to three vertex points (from 1 to 3).</li>  </ul>  <blockquote class=\"note\">NOTE&nbsp; The coordinates of the vertices are provided by the indexed list of <em>SELF\\IfcTessellatedFaceSet.Coordinates.CoordList</em>.</blockquote>")]
		[Required()]
		[MinLength(1)]
		public IList<IfcPositiveInteger> CoordIndex { get; protected set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The list of integers defining the locations in the <em>IfcCartesianPointList3D</em> to obtain the point coordinates for the indices withint the <i>CoordIndex</i>. If the <i>PnIndex</i> is not provided the indices point directly into the <em>IfcCartesianPointList3D</em>.")]
		[MinLength(1)]
		public IList<IfcPositiveInteger> PnIndex { get; protected set; }
	
	
		public IfcTriangulatedFaceSet(IfcCartesianPointList3D __Coordinates, IfcParameterValue[] __Normals, IfcBoolean? __Closed, IfcPositiveInteger[] __CoordIndex, IfcPositiveInteger[] __PnIndex)
			: base(__Coordinates)
		{
			this.Normals = new List<IfcParameterValue>(__Normals);
			this.Closed = __Closed;
			this.CoordIndex = new List<IfcPositiveInteger>(__CoordIndex);
			this.PnIndex = new List<IfcPositiveInteger>(__PnIndex);
		}
	
		public new IfcInteger NumberOfTriangles { get { return new IfcInteger(); } }
	
	
	}
	
}

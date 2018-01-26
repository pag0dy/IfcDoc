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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("d2c744de-ffd9-4239-a7cb-245b41b80a33")]
	public partial class IfcIndexedPolygonalFaceWithVoids : IfcIndexedPolygonalFace
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		[MinLength(1)]
		IList<IfcPositiveInteger> _InnerCoordIndices = new List<IfcPositiveInteger>();
	
	
		public IfcIndexedPolygonalFaceWithVoids()
		{
		}
	
		public IfcIndexedPolygonalFaceWithVoids(IfcPositiveInteger[] __CoordIndex, IfcPositiveInteger[] __InnerCoordIndices)
			: base(__CoordIndex)
		{
			this._InnerCoordIndices = new List<IfcPositiveInteger>(__InnerCoordIndices);
		}
	
		[Description(@"Two-dimensional list, where the first dimension represents each inner loop (from 1 to N) and the second dimension the indices to three or more points that define the vertices of each inner loop. If the tessellated face set is closed, indicated by <em>SELF\IfcTessellatedFaceSet.Closed</em>, then the points, defining the inner loops, shall connect clockwise, as seen from the outside of the body.
	<blockquote class=""note"">NOTE&nbsp; The coordinates of the vertices are provided by the indexed list of <em>SELF\IfcTessellatedFaceSet.Coordinates.CoordList</em>. If the  <em>SELF\IfcTessellatedFaceSet.PnIndex</em> is provided, the indices point into it, otherwise directly into the <em>IfcCartesianPointList3D</em>.</blockquote>")]
		public IList<IfcPositiveInteger> InnerCoordIndices { get { return this._InnerCoordIndices; } }
	
	
	}
	
}

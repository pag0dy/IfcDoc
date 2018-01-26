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
	[Guid("d254b777-e1d5-480f-a356-6496977d5a4a")]
	public partial class IfcIndexedPolygonalFace : IfcTessellatedItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		[MinLength(3)]
		IList<IfcPositiveInteger> _CoordIndex = new List<IfcPositiveInteger>();
	
		[InverseProperty("Faces")] 
		[MinLength(1)]
		ISet<IfcPolygonalFaceSet> _ToFaceSet = new HashSet<IfcPolygonalFaceSet>();
	
	
		public IfcIndexedPolygonalFace()
		{
		}
	
		public IfcIndexedPolygonalFace(IfcPositiveInteger[] __CoordIndex)
		{
			this._CoordIndex = new List<IfcPositiveInteger>(__CoordIndex);
		}
	
		[Description(@"One-dimensional list with the indices for the three or more points, that define the vertices of the outer loop. If the tessellated face set is closed, indicated by <em>SELF\IfcTessellatedFaceSet.Closed</em>, then the points, defining the outer loop, shall connect counter clockwise, as seen from the outside of the body, so that the resulting normal will point outwards.
	<blockquote class=""note"">NOTE&nbsp; The coordinates of the vertices are provided by the indexed list of <em>SELF\IfcTessellatedFaceSet.Coordinates.CoordList</em>. If the  <em>SELF\IfcTessellatedFaceSet.PnIndex</em> is provided, the indices point into it, otherwise directly into the <em>IfcCartesianPointList3D</em>.</blockquote>")]
		public IList<IfcPositiveInteger> CoordIndex { get { return this._CoordIndex; } }
	
		[Description("Reference to the <em>IfcPolygonalFaceSet</em> for which this face is associated.")]
		public ISet<IfcPolygonalFaceSet> ToFaceSet { get { return this._ToFaceSet; } }
	
	
	}
	
}

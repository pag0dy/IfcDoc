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
	public partial class IfcPolygonalFaceSet : IfcTessellatedFaceSet
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Indication whether the <em>IfcPolygonalFaceSet</em> is a closed shell or not. If omited no such information can be provided.")]
		public IfcBoolean? Closed { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The list of polygonal faces, with or without inner loops, that bound the faceted face set.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcIndexedPolygonalFace> Faces { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The list of integers defining the locations in the <em>IfcCartesianPointList3D</em> to obtain the point coordinates for the indices at the indexed polygonal faces. If the <em>PnIndex</em> is not provided the indices at the indexed polygonal faces point directly into the  <em>IfcCartesianPointList3D</em>.")]
		[MinLength(1)]
		public IList<IfcPositiveInteger> PnIndex { get; protected set; }
	
	
		public IfcPolygonalFaceSet(IfcCartesianPointList3D __Coordinates, IfcBoolean? __Closed, IfcIndexedPolygonalFace[] __Faces, IfcPositiveInteger[] __PnIndex)
			: base(__Coordinates)
		{
			this.Closed = __Closed;
			this.Faces = new List<IfcIndexedPolygonalFace>(__Faces);
			this.PnIndex = new List<IfcPositiveInteger>(__PnIndex);
		}
	
	
	}
	
}

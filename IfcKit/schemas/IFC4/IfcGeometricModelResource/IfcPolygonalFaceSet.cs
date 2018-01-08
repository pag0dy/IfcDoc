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
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("db4f6cc6-cf8a-4dbe-9456-f8235923f349")]
	public partial class IfcPolygonalFaceSet : IfcTessellatedFaceSet
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcBoolean? _Closed;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcIndexedPolygonalFace> _Faces = new List<IfcIndexedPolygonalFace>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IList<IfcPositiveInteger> _PnIndex = new List<IfcPositiveInteger>();
	
	
		[Description("Indication whether the <em>IfcPolygonalFaceSet</em> is a closed shell or not. If " +
	    "omited no such information can be provided.")]
		public IfcBoolean? Closed { get { return this._Closed; } set { this._Closed = value;} }
	
		[Description("The list of polygonal faces, with or without inner loops, that bound the faceted " +
	    "face set.")]
		public IList<IfcIndexedPolygonalFace> Faces { get { return this._Faces; } }
	
		[Description(@"The list of integers defining the locations in the <em>IfcCartesianPointList3D</em> to obtain the point coordinates for the indices at the indexed polygonal faces. If the <em>PnIndex</em> is not provided the indices at the indexed polygonal faces point directly into the  <em>IfcCartesianPointList3D</em>.")]
		public IList<IfcPositiveInteger> PnIndex { get { return this._PnIndex; } }
	
	
	}
	
}

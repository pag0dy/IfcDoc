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
	[Guid("97c81448-43b9-4f3b-8b09-5da72f6a499a")]
	public abstract partial class IfcTessellatedFaceSet : IfcTessellatedItem
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcCartesianPointList3D")]
		[Required()]
		IfcCartesianPointList3D _Coordinates;
	
		[DataMember(Order=1)] 
		IList<IfcParameterValue> _Normals = new List<IfcParameterValue>();
	
		[DataMember(Order=2)] 
		Boolean? _Closed;
	
		[InverseProperty("MappedTo")] 
		[XmlElement("IfcIndexedColourMap")]
		ISet<IfcIndexedColourMap> _HasColours = new HashSet<IfcIndexedColourMap>();
	
		[InverseProperty("MappedTo")] 
		[XmlElement]
		ISet<IfcIndexedTextureMap> _HasTextures = new HashSet<IfcIndexedTextureMap>();
	
	
		[Description("<EPM-HTML>\r\nAn ordered list of Cartesian points used by the coordinate index defi" +
	    "ned at the subtypes of <em>IfcTessellatedFaceSet</em>.\r\n</EPM-HTML>")]
		public IfcCartesianPointList3D Coordinates { get { return this._Coordinates; } set { this._Coordinates = value;} }
	
		[Description("<EPM-HTML>\r\nAn ordered list of directions used by the normal index defined at the" +
	    " subtypes of <em>IfcTessellatedFaceSet</em>. It is a two-dimensional list of dir" +
	    "ections provided by three parameter values.\r\n</EPM-HTML>")]
		public IList<IfcParameterValue> Normals { get { return this._Normals; } }
	
		[Description("<EPM-HTML>\r\nIndication whether the <em>IfcTessellatedFaceSet</em> is a closed she" +
	    "ll or not. If omited no such information can be provided.\r\n</EPM-HTML>")]
		public Boolean? Closed { get { return this._Closed; } set { this._Closed = value;} }
	
		[Description("<EPM-HTML>\r\nReference to the indexed colour map providing the corresponding colou" +
	    "r RGB values to the faces of the subtypes of <em>IfcTessellatedFaceSet</em>.\r\n</" +
	    "EPM-HTML>")]
		public ISet<IfcIndexedColourMap> HasColours { get { return this._HasColours; } }
	
		[Description("<EPM-HTML>\r\nReference to the indexed texture map providing the corresponding text" +
	    "ure coordinates to the vertices bounding the faces of the subtypes of <em>IfcTes" +
	    "sellatedFaceSet</em>.\r\n</EPM-HTML>")]
		public ISet<IfcIndexedTextureMap> HasTextures { get { return this._HasTextures; } }
	
	
	}
	
}

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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("97c81448-43b9-4f3b-8b09-5da72f6a499a")]
	public abstract partial class IfcTessellatedFaceSet : IfcTessellatedItem,
		BuildingSmart.IFC.IfcGeometricModelResource.IfcBooleanOperand
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcCartesianPointList3D _Coordinates;
	
		[InverseProperty("MappedTo")] 
		[XmlElement]
		[MaxLength(1)]
		ISet<IfcIndexedColourMap> _HasColours = new HashSet<IfcIndexedColourMap>();
	
		[InverseProperty("MappedTo")] 
		[XmlElement("IfcIndexedTextureMap")]
		ISet<IfcIndexedTextureMap> _HasTextures = new HashSet<IfcIndexedTextureMap>();
	
	
		public IfcTessellatedFaceSet()
		{
		}
	
		public IfcTessellatedFaceSet(IfcCartesianPointList3D __Coordinates)
		{
			this._Coordinates = __Coordinates;
		}
	
		[Description("An ordered list of Cartesian points used by the coordinate index defined at the s" +
	    "ubtypes of <em>IfcTessellatedFaceSet</em>.")]
		public IfcCartesianPointList3D Coordinates { get { return this._Coordinates; } set { this._Coordinates = value;} }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
		[Description("Reference to the indexed colour map providing the corresponding colour RGB values" +
	    " to the faces of the subtypes of <em>IfcTessellatedFaceSet</em>.")]
		public ISet<IfcIndexedColourMap> HasColours { get { return this._HasColours; } }
	
		[Description("Reference to the indexed texture map providing the corresponding texture coordina" +
	    "tes to the vertices bounding the faces of the subtypes of <em>IfcTessellatedFace" +
	    "Set</em>.")]
		public ISet<IfcIndexedTextureMap> HasTextures { get { return this._HasTextures; } }
	
	
	}
	
}

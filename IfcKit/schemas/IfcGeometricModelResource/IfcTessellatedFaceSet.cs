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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public abstract partial class IfcTessellatedFaceSet : IfcTessellatedItem,
		BuildingSmart.IFC.IfcGeometricModelResource.IfcBooleanOperand
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("An ordered list of Cartesian points used by the coordinate index defined at the subtypes of <em>IfcTessellatedFaceSet</em>.")]
		[Required()]
		public IfcCartesianPointList3D Coordinates { get; set; }
	
		[InverseProperty("MappedTo")] 
		[XmlElement]
		[Description("Reference to the indexed colour map providing the corresponding colour RGB values to the faces of the subtypes of <em>IfcTessellatedFaceSet</em>.")]
		[MaxLength(1)]
		public ISet<IfcIndexedColourMap> HasColours { get; protected set; }
	
		[InverseProperty("MappedTo")] 
		[XmlElement("IfcIndexedTextureMap")]
		[Description("Reference to the indexed texture map providing the corresponding texture coordinates to the vertices bounding the faces of the subtypes of <em>IfcTessellatedFaceSet</em>.")]
		public ISet<IfcIndexedTextureMap> HasTextures { get; protected set; }
	
	
		protected IfcTessellatedFaceSet(IfcCartesianPointList3D __Coordinates)
		{
			this.Coordinates = __Coordinates;
			this.HasColours = new HashSet<IfcIndexedColourMap>();
			this.HasTextures = new HashSet<IfcIndexedTextureMap>();
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}

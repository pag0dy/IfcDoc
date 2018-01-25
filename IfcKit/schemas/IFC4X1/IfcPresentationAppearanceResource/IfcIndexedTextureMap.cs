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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("ac1ef8ed-e75b-403b-a651-72cd4dec16ce")]
	public abstract partial class IfcIndexedTextureMap : IfcTextureCoordinate
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		IfcTessellatedFaceSet _MappedTo;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcTextureVertexList _TexCoords;
	
	
		[Description("Reference to the <em>IfcTessellatedFaceSet</em> to which it applies the texture m" +
	    "ap.")]
		public IfcTessellatedFaceSet MappedTo { get { return this._MappedTo; } set { this._MappedTo = value;} }
	
		[Description("Indexable list of texture vertices.")]
		public IfcTextureVertexList TexCoords { get { return this._TexCoords; } set { this._TexCoords = value;} }
	
	
	}
	
}

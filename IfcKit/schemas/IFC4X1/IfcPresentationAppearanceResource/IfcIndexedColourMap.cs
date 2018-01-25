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
	[Guid("72a45e5a-521d-4b77-ba81-0938e73dffff")]
	public partial class IfcIndexedColourMap : IfcPresentationItem
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		IfcTessellatedFaceSet _MappedTo;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcNormalisedRatioMeasure? _Opacity;
	
		[DataMember(Order=2)] 
		[XmlElement]
		[Required()]
		IfcColourRgbList _Colours;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IList<IfcPositiveInteger> _ColourIndex = new List<IfcPositiveInteger>();
	
	
		[Description("Reference to the <em>IfcTessellatedFaceSet</em> to which it applies the colours a" +
	    "nd alpha channel.")]
		public IfcTessellatedFaceSet MappedTo { get { return this._MappedTo; } set { this._MappedTo = value;} }
	
		[Description(@"The the opacity value, that applies equaly to all faces of the tessellated face set. 1.0 means opaque, and 0.0 completely transparent. If not provided, 1.0 is assumed (all colours are opque).
	
	<blockquote class=""note"">NOTE&nbsp; The definition of the alpha channel component for opacity follows the new definitions in image processing, where 0.0 means full transparency and 1.0 (or 2<sup>bit depths</sup> -1) means fully opaque. This is contrary to the definition of transparency in <i>IfcSurfaceStyleShading</i>.</blockquote>")]
		public IfcNormalisedRatioMeasure? Opacity { get { return this._Opacity; } set { this._Opacity = value;} }
	
		[Description("Indexable list of lists of quadruples, representing RGB colours. ")]
		public IfcColourRgbList Colours { get { return this._Colours; } set { this._Colours = value;} }
	
		[Description("Index into the <em>IfcColourRgbList</em> for each face of the <em>IfcTriangulated" +
	    "FaceSet</em>. The colour is applied uniformly to the indexed face.")]
		public IList<IfcPositiveInteger> ColourIndex { get { return this._ColourIndex; } }
	
	
	}
	
}

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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcIndexedColourMap : IfcPresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlIgnore]
		[Description("Reference to the <em>IfcTessellatedFaceSet</em> to which it applies the colours and alpha channel.")]
		[Required()]
		public IfcTessellatedFaceSet MappedTo { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The the opacity value, that applies equaly to all faces of the tessellated face set. 1.0 means opaque, and 0.0 completely transparent. If not provided, 1.0 is assumed (all colours are opque).    <blockquote class=\"note\">NOTE&nbsp; The definition of the alpha channel component for opacity follows the new definitions in image processing, where 0.0 means full transparency and 1.0 (or 2<sup>bit depths</sup> -1) means fully opaque. This is contrary to the definition of transparency in <i>IfcSurfaceStyleShading</i>.</blockquote>")]
		public IfcNormalisedRatioMeasure? Opacity { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("Indexable list of lists of quadruples, representing RGB colours. ")]
		[Required()]
		public IfcColourRgbList Colours { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Index into the <em>IfcColourRgbList</em> for each face of the <em>IfcTriangulatedFaceSet</em>. The colour is applied uniformly to the indexed face.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcPositiveInteger> ColourIndex { get; protected set; }
	
	
		public IfcIndexedColourMap(IfcTessellatedFaceSet __MappedTo, IfcNormalisedRatioMeasure? __Opacity, IfcColourRgbList __Colours, IfcPositiveInteger[] __ColourIndex)
		{
			this.MappedTo = __MappedTo;
			this.Opacity = __Opacity;
			this.Colours = __Colours;
			this.ColourIndex = new List<IfcPositiveInteger>(__ColourIndex);
		}
	
	
	}
	
}

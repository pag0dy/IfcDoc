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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcImageTexture : IfcSurfaceTexture
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Location, provided as an URI, at which the image texture is electronically published.")]
		[Required()]
		public IfcURIReference URLReference { get; set; }
	
	
		public IfcImageTexture(IfcBoolean __RepeatS, IfcBoolean __RepeatT, IfcIdentifier? __Mode, IfcCartesianTransformationOperator2D __TextureTransform, IfcIdentifier[] __Parameter, IfcURIReference __URLReference)
			: base(__RepeatS, __RepeatT, __Mode, __TextureTransform, __Parameter)
		{
			this.URLReference = __URLReference;
		}
	
	
	}
	
}

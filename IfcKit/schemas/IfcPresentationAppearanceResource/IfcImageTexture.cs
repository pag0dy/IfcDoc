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

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcImageTexture : IfcSurfaceTexture
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Required()]
		public IfcIdentifier UrlReference { get; set; }
	
	
		public IfcImageTexture(Boolean __RepeatS, Boolean __RepeatT, IfcSurfaceTextureEnum __TextureType, IfcCartesianTransformationOperator2D __TextureTransform, IfcIdentifier __UrlReference)
			: base(__RepeatS, __RepeatT, __TextureType, __TextureTransform)
		{
			this.UrlReference = __UrlReference;
		}
	
	
	}
	
}

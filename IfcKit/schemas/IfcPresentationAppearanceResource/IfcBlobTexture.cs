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
	public partial class IfcBlobTexture : IfcSurfaceTexture
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  The format of the <i>RasterCode</i> often using a compression.  </EPM-HTML>")]
		[Required()]
		public IfcIdentifier RasterFormat { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("<EPM-HTML>  Blob, given as a single binary, to capture the texture within one popular file (compression) format.  </EPM-HTML>")]
		[Required()]
		public Boolean RasterCode { get; set; }
	
	
		public IfcBlobTexture(Boolean __RepeatS, Boolean __RepeatT, IfcSurfaceTextureEnum __TextureType, IfcCartesianTransformationOperator2D __TextureTransform, IfcIdentifier __RasterFormat, Boolean __RasterCode)
			: base(__RepeatS, __RepeatT, __TextureType, __TextureTransform)
		{
			this.RasterFormat = __RasterFormat;
			this.RasterCode = __RasterCode;
		}
	
	
	}
	
}

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

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("0678d26b-77f3-482d-89cf-fa958914ac86")]
	public partial class IfcBlobTexture : IfcSurfaceTexture
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _RasterFormat;
	
		[DataMember(Order=1)] 
		[Required()]
		Boolean _RasterCode;
	
	
		public IfcBlobTexture()
		{
		}
	
		public IfcBlobTexture(Boolean __RepeatS, Boolean __RepeatT, IfcSurfaceTextureEnum __TextureType, IfcCartesianTransformationOperator2D __TextureTransform, IfcIdentifier __RasterFormat, Boolean __RasterCode)
			: base(__RepeatS, __RepeatT, __TextureType, __TextureTransform)
		{
			this._RasterFormat = __RasterFormat;
			this._RasterCode = __RasterCode;
		}
	
		[Description("<EPM-HTML>\r\nThe format of the <i>RasterCode</i> often using a compression.\r\n</EPM" +
	    "-HTML>")]
		public IfcIdentifier RasterFormat { get { return this._RasterFormat; } set { this._RasterFormat = value;} }
	
		[Description("<EPM-HTML>\r\nBlob, given as a single binary, to capture the texture within one pop" +
	    "ular file (compression) format.\r\n</EPM-HTML>")]
		public Boolean RasterCode { get { return this._RasterCode; } set { this._RasterCode = value;} }
	
	
	}
	
}

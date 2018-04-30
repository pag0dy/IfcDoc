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

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public abstract partial class IfcSurfaceTexture
	{
		[DataMember(Order = 0)] 
		[Description("The RepeatS field specifies how the texture wraps in the S direction. If RepeatS is TRUE (the default), the texture map is repeated outside the [0.0, 1.0] texture coordinate range in the S direction so that it fills the shape. If repeatS is FALSE, the texture coordinates are clamped in the S direction to lie within the [0.0, 1.0] range. ")]
		[Required()]
		public Boolean RepeatS { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The RepeatT field specifies how the texture wraps in the T direction. If RepeatT is TRUE (the default), the texture map is repeated outside the [0.0, 1.0] texture coordinate range in the T direction so that it fills the shape. If repeatT is FALSE, the texture coordinates are clamped in the T direction to lie within the [0.0, 1.0] range. ")]
		[Required()]
		public Boolean RepeatT { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Identifies the predefined types of image map from which the type required may be set.")]
		[Required()]
		public IfcSurfaceTextureEnum TextureType { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("These parameters support changes to the size, orientation, and position of textures on shapes. Note that these operations appear reversed when viewed on the surface of geometry. For example, a scale value of (2 2) will scale the texture coordinates and have the net effect of shrinking the texture size by a factor of 2 (texture coordinates are twice as large and thus cause the texture to repeat). A translation of (0.5 0.0) translates the texture coordinates +.5 units along the S-axis and has the net effect of translating the texture -0.5 along the S-axis on the geometry's surface. A rotation of PI/2 of the texture coordinates results in a -PI/2 rotation of the texture on the geometry.")]
		public IfcCartesianTransformationOperator2D TextureTransform { get; set; }
	
	
		protected IfcSurfaceTexture(Boolean __RepeatS, Boolean __RepeatT, IfcSurfaceTextureEnum __TextureType, IfcCartesianTransformationOperator2D __TextureTransform)
		{
			this.RepeatS = __RepeatS;
			this.RepeatT = __RepeatT;
			this.TextureType = __TextureType;
			this.TextureTransform = __TextureTransform;
		}
	
	
	}
	
}

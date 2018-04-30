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
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public abstract partial class IfcSurfaceTexture : IfcPresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The <em>RepeatS</em> field specifies how the texture wraps in the S direction. If <em>RepeatS</em> is TRUE (the default), the texture map is repeated outside the [0.0, 1.0] texture coordinate range in the S direction so that it fills the shape. If <em>RepeatS</em> is FALSE, the texture coordinates are clamped in the S direction to lie within the [0.0, 1.0] range.  <br /> ")]
		[Required()]
		public IfcBoolean RepeatS { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The <em>RepeatT</em> field specifies how the texture wraps in the T direction. If <em>RepeatT</em> is TRUE (the default), the texture map is repeated outside the [0.0, 1.0] texture coordinate range in the T direction so that it fills the shape. If <em>RepeatT</em> is FALSE, the texture coordinates are clamped in the T direction to lie within the [0.0, 1.0] range.   <br />")]
		[Required()]
		public IfcBoolean RepeatT { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The <em>Mode</em> attribute is provided to control the appearance of a multi textures. The mode then controls the type of blending operation. The mode includes a MODULATE for a lit appearance, a REPLACE for a unlit appearance, and variations of the two.  <blockquote class=\"note\">NOTE&nbsp; The applicable values for the <em>Mode</em> attribute are determined by view definitions or implementer agreements. It is recommended to use the modes described in ISO/IES 19775-1.2:2008 X3D Architecture and base components Edition 2, Part 1. See <a href=\"http://www.web3d.org/x3d/specifications/ISO-IEC-19775-1.2-X3D-AbstractSpecification/Part01/components/texturing.html#MultiTexture\">18.4.3 MultiTexture</a> for recommended values.</blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute replacing previous TextureType.</blockquote>")]
		public IfcIdentifier? Mode { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlElement]
		[Description("The <em>TextureTransform</em> defines a 2D transformation that is applied to the texture coordinates. It affects the way texture coordinates are applied to the surfaces of geometric representation itesm. The 2D transformation supports changes to the size, orientation, and position of textures on shapes. Mirroring is not allowed to be used in the <em>IfcCartesianTransformationOperator</em>")]
		public IfcCartesianTransformationOperator2D TextureTransform { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The <em>Parameter</em> attribute is provided to control the appearance of a multi textures. The applicable parameters depend on the value of the <em>Mode</em> attribute.  <blockquote class=\"note\">NOTE&nbsp; The applicable values for the list of <em>Parameter</em> attributes are determined by view definitions or implementer agreements. It is recommended to use the source and the function fields described in ISO/IES 19775-1.2:2008 X3D Architecture and base components Edition 2, Part 1. See <a href=\"http://www.web3d.org/x3d/specifications/ISO-IEC-19775-1.2-X3D-AbstractSpecification/Part01/components/texturing.html#MultiTexture\">18.4.3 MultiTexture</a> for recommended values.<br />  By convention, <em>Parameter[1]</em> shall then hold the source value, <em>Parameter[2]</em> the function value, <em>Parameter[3]</em> the base RGB color for select operations, and <em>Parameter[4]</em> the alpha value for select operations.</blockquote>    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.</blockquote>")]
		[MinLength(1)]
		public IList<IfcIdentifier> Parameter { get; protected set; }
	
		[InverseProperty("Maps")] 
		[Description("Texture coordinates, either provided by a corresponding list of texture vertices to vertex-based geometric items or by a texture coordinate generator, that applies the surface texture to the surfaces of the geometric items.  <blackquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.</blockquote>")]
		public ISet<IfcTextureCoordinate> IsMappedBy { get; protected set; }
	
		[InverseProperty("Textures")] 
		public ISet<IfcSurfaceStyleWithTextures> UsedInStyles { get; protected set; }
	
	
		protected IfcSurfaceTexture(IfcBoolean __RepeatS, IfcBoolean __RepeatT, IfcIdentifier? __Mode, IfcCartesianTransformationOperator2D __TextureTransform, IfcIdentifier[] __Parameter)
		{
			this.RepeatS = __RepeatS;
			this.RepeatT = __RepeatT;
			this.Mode = __Mode;
			this.TextureTransform = __TextureTransform;
			this.Parameter = new List<IfcIdentifier>(__Parameter);
			this.IsMappedBy = new HashSet<IfcTextureCoordinate>();
			this.UsedInStyles = new HashSet<IfcSurfaceStyleWithTextures>();
		}
	
	
	}
	
}

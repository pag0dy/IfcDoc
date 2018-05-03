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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcTextureCoordinateGenerator : IfcTextureCoordinate
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The <em>Mode</em> attribute describes the algorithm used to compute texture coordinates.  <blockquote class=\"note\">NOTE&nbsp; The applicable values for the <em>Mode</em> attribute are determined by view definitions or implementer agreements. It is recommended to use the modes described in ISO/IES 19775-1.2:2008 X3D Architecture and base components Edition 2, Part 1. See <a href=\"http://www.web3d.org/x3d/specifications/ISO-IEC-19775-1.2-X3D-AbstractSpecification/Part01/components/texturing.html#TextureCoordinateGenerator\">18.4.8 TextureCoordinateGenerator</a> for recommended values.</blockquote>")]
		[Required()]
		public IfcLabel Mode { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The parameters used as arguments by the function as specified by <em>Mode</em>.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp: Data type restricted to REAL.</blockquote>")]
		[MinLength(1)]
		public IList<IfcReal> Parameter { get; protected set; }
	
	
		public IfcTextureCoordinateGenerator(IfcSurfaceTexture[] __Maps, IfcLabel __Mode, IfcReal[] __Parameter)
			: base(__Maps)
		{
			this.Mode = __Mode;
			this.Parameter = new List<IfcReal>(__Parameter);
		}
	
	
	}
	
}

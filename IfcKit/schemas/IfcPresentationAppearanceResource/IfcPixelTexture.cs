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
	public partial class IfcPixelTexture : IfcSurfaceTexture
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The number of pixels in width (S) direction.")]
		[Required()]
		public IfcInteger Width { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The number of pixels in height (T) direction.")]
		[Required()]
		public IfcInteger Height { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Indication whether the pixel values contain a 1, 2, 3, or 4 colour component.")]
		[Required()]
		public IfcInteger ColourComponents { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Flat list of hexadecimal values, each describing one pixel by 1, 2, 3, or 4 components.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The data type has been changed from STRING to BINARY.</blockquote>")]
		[Required()]
		[MinLength(1)]
		public IList<IfcBinary> Pixel { get; protected set; }
	
	
		public IfcPixelTexture(IfcBoolean __RepeatS, IfcBoolean __RepeatT, IfcIdentifier? __Mode, IfcCartesianTransformationOperator2D __TextureTransform, IfcIdentifier[] __Parameter, IfcInteger __Width, IfcInteger __Height, IfcInteger __ColourComponents, IfcBinary[] __Pixel)
			: base(__RepeatS, __RepeatT, __Mode, __TextureTransform, __Parameter)
		{
			this.Width = __Width;
			this.Height = __Height;
			this.ColourComponents = __ColourComponents;
			this.Pixel = new List<IfcBinary>(__Pixel);
		}
	
	
	}
	
}

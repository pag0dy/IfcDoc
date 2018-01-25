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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("d67c6683-c658-451a-82b2-833d8e0ed253")]
	public partial class IfcPixelTexture : IfcSurfaceTexture
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcInteger _Width;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcInteger _Height;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcInteger _ColourComponents;
	
		[DataMember(Order=3)] 
		[Required()]
		IList<BINARY (32)> _Pixel = new List<BINARY (32)>();
	
	
		[Description("<EPM-HTML>\r\nThe number of pixels in width (S) direction.\r\n</EPM-HTML>")]
		public IfcInteger Width { get { return this._Width; } set { this._Width = value;} }
	
		[Description("<EPM-HTML>\r\nThe number of pixels in height (T) direction.\r\n</EPM-HTML>")]
		public IfcInteger Height { get { return this._Height; } set { this._Height = value;} }
	
		[Description("<EPM-HTML>Indication whether the pixel values contain a 1, 2, 3, or 4 colour comp" +
	    "onent.\r\n</EPM-HTML>")]
		public IfcInteger ColourComponents { get { return this._ColourComponents; } set { this._ColourComponents = value;} }
	
		[Description(@"<EPM-HTML>
	Flat list of hexadecimal values, each describing one pixel by 1, 2, 3, or 4 components.
	<blockquote><small><font color""#ff0000"">
	IFC2x Edition 3 CHANGE&nbsp; The data type has been changed from STRING to BINARY.
	</font></small></blockquote>
	</EPM-HTML>")]
		public IList<BINARY (32)> Pixel { get { return this._Pixel; } }
	
	
	}
	
}

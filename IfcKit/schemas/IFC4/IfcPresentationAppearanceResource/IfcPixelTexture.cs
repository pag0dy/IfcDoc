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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("13c24361-dbc0-44fd-93e3-7772371d47b4")]
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
		[XmlAttribute]
		[Required()]
		IList<IfcBinary> _Pixel = new List<IfcBinary>();
	
	
		[Description("The number of pixels in width (S) direction.")]
		public IfcInteger Width { get { return this._Width; } set { this._Width = value;} }
	
		[Description("The number of pixels in height (T) direction.")]
		public IfcInteger Height { get { return this._Height; } set { this._Height = value;} }
	
		[Description("Indication whether the pixel values contain a 1, 2, 3, or 4 colour component.")]
		public IfcInteger ColourComponents { get { return this._ColourComponents; } set { this._ColourComponents = value;} }
	
		[Description("Flat list of hexadecimal values, each describing one pixel by 1, 2, 3, or 4 compo" +
	    "nents.\r\n<blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The data type has " +
	    "been changed from STRING to BINARY.</blockquote>")]
		public IList<IfcBinary> Pixel { get { return this._Pixel; } }
	
	
	}
	
}

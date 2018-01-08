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
	[Guid("33ffc6a1-31d2-441f-99ed-c8775cef5eb5")]
	public partial class IfcTextStyleForDefinedFont : IfcPresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcColour _Colour;
	
		[DataMember(Order=1)] 
		IfcColour _BackgroundColour;
	
	
		[Description("<EPM-HTML>\r\nThis property describes the text color of an element (often referred " +
	    "to as the foreground color).\r\n</EPM-HTML>")]
		public IfcColour Colour { get { return this._Colour; } set { this._Colour = value;} }
	
		[Description("<EPM-HTML>\r\nThis property sets the background color of an element.\r\n</EPM-HTML>")]
		public IfcColour BackgroundColour { get { return this._BackgroundColour; } set { this._BackgroundColour = value;} }
	
	
	}
	
}

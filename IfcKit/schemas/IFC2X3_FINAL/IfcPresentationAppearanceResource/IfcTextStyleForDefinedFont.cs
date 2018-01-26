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

using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("81ee382b-1d17-4541-94b0-d12f8d8ad706")]
	public partial class IfcTextStyleForDefinedFont :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcCharacterStyleSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcColour _Colour;
	
		[DataMember(Order=1)] 
		IfcColour _BackgroundColour;
	
	
		public IfcTextStyleForDefinedFont()
		{
		}
	
		public IfcTextStyleForDefinedFont(IfcColour __Colour, IfcColour __BackgroundColour)
		{
			this._Colour = __Colour;
			this._BackgroundColour = __BackgroundColour;
		}
	
		[Description("<EPM-HTML>\r\nThis property describes the text color of an element (often referred " +
	    "to as the foreground color).\r\n</EPM-HTML>")]
		public IfcColour Colour { get { return this._Colour; } set { this._Colour = value;} }
	
		[Description("<EPM-HTML>\r\nThis property sets the background color of an element.\r\n</EPM-HTML>")]
		public IfcColour BackgroundColour { get { return this._BackgroundColour; } set { this._BackgroundColour = value;} }
	
	
	}
	
}

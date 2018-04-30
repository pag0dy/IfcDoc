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

using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcTextStyleForDefinedFont : IfcPresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("This property describes the text color of an element (often referred to as the foreground color).")]
		[Required()]
		public IfcColour Colour { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("This property sets the background color of an element.")]
		public IfcColour BackgroundColour { get; set; }
	
	
		public IfcTextStyleForDefinedFont(IfcColour __Colour, IfcColour __BackgroundColour)
		{
			this.Colour = __Colour;
			this.BackgroundColour = __BackgroundColour;
		}
	
	
	}
	
}

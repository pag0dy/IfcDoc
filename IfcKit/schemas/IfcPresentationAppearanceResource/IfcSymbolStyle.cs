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

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcSymbolStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order = 0)] 
		[Description("The style applied to the symbol for its visual appearance.")]
		[Required()]
		public IfcSymbolStyleSelect StyleOfSymbol { get; set; }
	
	
		public IfcSymbolStyle(IfcLabel? __Name, IfcSymbolStyleSelect __StyleOfSymbol)
			: base(__Name)
		{
			this.StyleOfSymbol = __StyleOfSymbol;
		}
	
	
	}
	
}

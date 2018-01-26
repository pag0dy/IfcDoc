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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("02dac9ec-9223-41cb-9796-40c07ad2dae0")]
	public partial class IfcSymbolStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSymbolStyleSelect _StyleOfSymbol;
	
	
		public IfcSymbolStyle()
		{
		}
	
		public IfcSymbolStyle(IfcLabel? __Name, IfcSymbolStyleSelect __StyleOfSymbol)
			: base(__Name)
		{
			this._StyleOfSymbol = __StyleOfSymbol;
		}
	
		[Description("The style applied to the symbol for its visual appearance.")]
		public IfcSymbolStyleSelect StyleOfSymbol { get { return this._StyleOfSymbol; } set { this._StyleOfSymbol = value;} }
	
	
	}
	
}
